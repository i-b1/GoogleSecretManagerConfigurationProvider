# [Google Secret Manager](https://cloud.google.com/secret-manager/) Configuration Provider for ASP.NET Core

Configure secret manager as configuration source in Program.cs
```
public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, config) => config.AddGoogleSecretsManager())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
```

Default Service Account that application is running under must have appropriate permissions granted (e.g. Secret Manager User)

*Article:*
[Google Secret Manager Configuration Provider for ASP.NET Core](https://dev.to/ib1/google-secret-manager-configuration-provider-for-asp-net-core-3gpk)
