using ApplicationUtilities.Configuration;
using ApplicationUtilities.Services;
using Bitwarden.Sdk;
using Microsoft.Extensions.Options;

namespace SampleWebApi.Providers;

public sealed class BitwardenSecretManagerProvider(BitwardenSecretsConfiguration bitwardenSecretsConfiguration) : ConfigurationProvider
{
    public override void Load()
    {
        // use bitwarden client to fetch all the secrets
        using var bitwardenClient = new BitwardenClient(new());
        bitwardenClient.AccessTokenLogin(bitwardenSecretsConfiguration.AccessToken);

        var secretIdentifiers = bitwardenClient.Secrets.List(new Guid(bitwardenSecretsConfiguration.OrganizationId));

        var secrets = new List<(string Key, string Value, string Note)>();
        foreach (var secretId in secretIdentifiers.Data.Select(x => x.Id))
        {
            var value = bitwardenClient.Secrets.Get(secretId);
            secrets.Add(new (value.Key, value.Value, value.Note));
        }
        
        var settingItems = new Dictionary<string, string>();

        // each key name has abbreviation: [class_name]_[field_name]
        // in a real world scenario, you may need to write out code which better loads settings into the app config
        foreach (var secret in secrets)
        {
            var keyValue = secret.Key.Split("_");
            settingItems.Add($"{keyValue[0]}:{keyValue[1]}", secret.Value);
        }
        
        Data = settingItems;
        base.Load();
    }
}