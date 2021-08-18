using System;
using Microsoft.Extensions.Configuration;

namespace GoogleSecretManagerConfigurationProvider
{
    public static class SecretManagerConfigurationExtensions
    {
        /// <summary>
        /// Add SecretManagerConfigurationSource to the build configuration
        /// </summary>
        /// <param name="configurationBuilder"></param>
        public static IConfigurationBuilder AddGoogleSecretsManager(this IConfigurationBuilder configurationBuilder)
        {
            if (configurationBuilder == null)
            {
                throw new ArgumentNullException(nameof(configurationBuilder));
            }

            configurationBuilder.Add(new SecretManagerConfigurationSource());

            return configurationBuilder;
        }
    }
}
