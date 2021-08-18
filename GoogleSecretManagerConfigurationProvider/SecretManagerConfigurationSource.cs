using Microsoft.Extensions.Configuration;

namespace GoogleSecretManagerConfigurationProvider
{
    public class SecretManagerConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// Creates new SecretsManagerConfigurationProvider
        /// </summary>
        /// <param name="builder"></param>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SecretManagerConfigurationProvider();
        }
    }
}
