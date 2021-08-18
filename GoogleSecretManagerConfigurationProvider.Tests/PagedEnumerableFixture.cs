using System.Collections.Generic;
using Google.Api.Gax;

namespace GoogleSecretManagerConfigurationProvider.Tests
{
    internal class PagedEnumerableFixture<TResponse, TResource> : PagedEnumerable<TResponse, TResource>
    {
        private readonly IEnumerable<TResource> _resources;

        public PagedEnumerableFixture(IEnumerable<TResource> resources)
        {
            _resources = resources;
        }

        public override IEnumerator<TResource> GetEnumerator()
        {
            return _resources.GetEnumerator();
        }
    }
}
