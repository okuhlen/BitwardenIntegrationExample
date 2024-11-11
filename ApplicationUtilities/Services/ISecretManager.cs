namespace ApplicationUtilities.Services;

public interface ISecretManager
{
    void LoadSecret(string key, string value, string? note);

    void ClearSecrets();
    
    IEnumerable<(string Key, string Value, string? Note)> ListSecrets();
}