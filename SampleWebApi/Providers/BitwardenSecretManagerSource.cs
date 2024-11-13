using ApplicationUtilities.Configuration;

namespace SampleWebApi.Providers;

public sealed class BitwardenSecretManagerSource(BitwardenSecretsConfiguration bitwardenSecretsConfiguration) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder) => new BitwardenSecretManagerProvider(bitwardenSecretsConfiguration);
}