using ApplicationUtilities.Configuration;
using Bitwarden.Sdk;
using Microsoft.Extensions.Options;

namespace ApplicationUtilities.Services;

public sealed class SecretManager(IOptions<BitwardenSecretsConfiguration> secretsConfiguration) : ISecretManager
{
    private readonly BitwardenSecretsConfiguration _secretsConfiguration = secretsConfiguration.Value;
    private const string DefaultNote = "No notes were supplied";

    public void LoadSecret(string key, string value, string? note)
    {
        using var bitwardenClient = new BitwardenClient(new());
        bitwardenClient.AccessTokenLogin(_secretsConfiguration.AccessToken);

        bitwardenClient.Secrets.Create(key, value, note ?? DefaultNote, new Guid(_secretsConfiguration.OrganizationId),
            new[] { new Guid(_secretsConfiguration.ProjectId) });
    }

    /// <summary>
    /// This clears all secrets from the secrets manager. This should only be used from the settings loader app
    /// </summary>
    public void ClearSecrets()
    {
        using var bitwardenClient = new BitwardenClient(new());
        bitwardenClient.AccessTokenLogin(_secretsConfiguration.AccessToken);

        var secrets = bitwardenClient.Secrets.List(new Guid(_secretsConfiguration.OrganizationId));
        foreach (var secret in secrets.Data)
        {
            bitwardenClient.Secrets.Delete(new [] { secret.Id });
        }
    }

    /// <summary>
    /// This retrieves all secrets from the secrets manager. This should be used when loading all secrets into app config source
    /// </summary>
    /// <returns>List of secrets, in tuples</returns>
    public IEnumerable<(string Key, string Value, string? Note)> ListSecrets()
    {
        using var bitwardenClient = new BitwardenClient(new());
        bitwardenClient.AccessTokenLogin(_secretsConfiguration.AccessToken);

        var secretIdentifiers = bitwardenClient.Secrets.List(new Guid(_secretsConfiguration.OrganizationId));

        foreach (var secretId in secretIdentifiers.Data.Select(x => x.Id))
        {
            var value = bitwardenClient.Secrets.Get(secretId);
            yield return new (value.Key, value.Value, value.Note);
        }
    }
}