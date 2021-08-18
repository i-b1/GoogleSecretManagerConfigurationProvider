namespace GoogleSecretManagerConfigurationProvider
{
    public static class GoogleProject
    {
        /// <summary>
        /// Get the Google Cloud Platform Project ID from the platform it is running on,
        /// or from the appsettings.json configuration if not running on Google Cloud Platform.
        /// </summary>
        /// <returns>
        /// The ID of the GCP Project this service is running on, or the AppConfig:GcpSettings:ProjectId
        /// from the configuration if not running on GCP.
        /// </returns>
        public static string GetProjectId()
        {
            var instance = Google.Api.Gax.Platform.Instance();
            var projectId = instance?.ProjectId;
            if (string.IsNullOrEmpty(projectId))
            {
                return null;
            }
            return projectId;
        }
    }
}
