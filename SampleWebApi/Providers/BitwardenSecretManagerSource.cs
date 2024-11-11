using ApplicationUtilities.Configuration;
using Microsoft.Extensions.Options;

namespace SampleWebApi.Providers;

public sealed class BitwardenSecretManagerSource(IOptions<BitwardenSecretsConfiguration> bitwardenSecretsConfiguration) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder) => new BitwardenSecretManagerProvider(bitwardenSecretsConfiguration);
}