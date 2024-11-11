using ApplicationUtilities.Configuration;
using ApplicationUtilities.Services;
using Microsoft.Extensions.Options;

namespace SampleWebApi.Providers;

public sealed class BitwardenSecretManagerProvider(IOptions<BitwardenSecretsConfiguration> bitwardenSecretsConfiguration) : ConfigurationProvider
{
    public override void Load()
    {
        var secretsManager = new SecretManager(bitwardenSecretsConfiguration);
        var secrets = secretsManager.ListSecrets();
        
        
    }
}