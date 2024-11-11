using ApplicationUtilities.Configuration;
using ApplicationUtilities.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SettingsLoader.Services;

Console.WriteLine("Sample Settings Loader");
Console.WriteLine("====================================");
Console.WriteLine();
Console.WriteLine("Now loading settings into secrets manager from the settings file. Please wait...");
Console.WriteLine();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IConfiguration>(configuration);
serviceCollection.Configure<BitwardenSecretsConfiguration>(configuration.GetSection(nameof(BitwardenSecretsConfiguration)));
serviceCollection.AddTransient<ISecretManager, SecretManager>();
serviceCollection.AddTransient<ISettingsManager, SettingsManager>();
var provider = serviceCollection.BuildServiceProvider();

var settingsManager = provider.GetRequiredService<ISettingsManager>();
Console.WriteLine("Now clearing settings...");
settingsManager.ClearSecrets();
Console.WriteLine("Now loading settings...");
await settingsManager.LoadSecrets();
Console.WriteLine();
Console.WriteLine("Settings have been successfully loaded into Bitwarden Secret Manager. You may consume secrets in your app");
Console.ReadKey();