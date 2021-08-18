using System.Collections.Generic;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.SecretManager.V1;
using Google.Protobuf;
using Moq;
using Xunit;

namespace GoogleSecretManagerConfigurationProvider.Tests
{
    public class SecretManagerConfigurationProviderTests
    {
        private readonly Mock<SecretManagerServiceClient> _mockClient;
        private readonly List<Secret> _secrets;
        private readonly PagedEnumerableFixture<ListSecretsResponse, Secret> _response;
        private const string _projectId = "GCPProjectId";

        public SecretManagerConfigurationProviderTests()
        {
            _secrets = new List<Secret>
            {
                new Secret
                {
                    SecretName = new SecretName(_projectId, "Secret1")
                },
                new Secret
                {
                    SecretName = new SecretName(_projectId, "Secret2")
                },
                new Secret
                {
                    SecretName = new SecretName(_projectId, "Secret3")
                }
            };

            _mockClient = new Mock<SecretManagerServiceClient>();
            _response = new PagedEnumerableFixture<ListSecretsResponse, Secret>(_secrets);
            _mockClient.Setup(x => x.ListSecrets(It.Is<ProjectName>(p => p.ProjectId == _projectId), null, null, null)).Returns(_response);

            foreach (var secret in _secrets)
            {
                var response = new AccessSecretVersionResponse
                {
                    Payload = new SecretPayload
                    {
                        Data = ByteString.CopyFromUtf8($"{secret.SecretName.SecretId}-data")
                    }
                };
                _mockClient.Setup(
                    x => x.AccessSecretVersion(
                        It.Is<SecretVersionName>(svn => svn.ProjectId == secret.SecretName.ProjectId &&
                                svn.SecretId == secret.SecretName.SecretId &&
                                svn.SecretVersionId == "latest"), null))
                    .Returns(response);
            }
        }

        [Fact()]
        public void Should_Retrieve_Secrets()
        {
            var configurationProvider = new SecretManagerConfigurationProvider(_mockClient.Object, _projectId);
            configurationProvider.Load();

            foreach (var secret in _secrets)
            {
                configurationProvider.TryGet(secret.SecretName.SecretId, out string value);
                Assert.Equal($"{secret.SecretName.SecretId}-data", value);
            }
        }
    }
}