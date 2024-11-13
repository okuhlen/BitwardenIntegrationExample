using ApplicationUtilities.Configuration;
using SampleWebApi.Providers;

namespace SampleWebApi.Extensions;

public static class BitwardenConfigurationHelper
{
    public static ConfigurationManager AddBitwardenSecretManagerConfiguration(this ConfigurationManager configurationManager)
    {
        var bitwardenConfig = new BitwardenSecretsConfiguration();
        configurationManager.GetSection(nameof(BitwardenSecretsConfiguration)).Bind(bitwardenConfig);
        
        IConfigurationBuilder builder = configurationManager;
        builder.Add(new BitwardenSecretManagerSource(bitwardenConfig));

        return configurationManager;
    }
}