using System.Globalization;
using ApplicationUtilities.Services;
using CsvHelper;
using CsvHelper.Configuration;
using SettingsLoader.Models;

namespace SettingsLoader.Services;

public sealed class SettingsManager(ISecretManager secretManager) : ISettingsManager
{
    private readonly CsvConfiguration _csvConfiguration = new(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = true,
        Delimiter = ","
    };
    
    public async Task LoadSecrets()
    {
        var assembly = typeof(SecretManager).Assembly;
        var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(name => name.EndsWith("settings.csv"));

        if (resourceName is null)
        {
            throw new Exception("No settings.csv file was found as an embedded resource.");
        }

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream is null)
        {
            throw new Exception("Failed to load the embedded resource stream for settings.csv.");
        }

        using var reader = new StreamReader(stream);
        using var csvReader = new CsvReader(reader, _csvConfiguration);

        await foreach (var row in csvReader.GetRecordsAsync<SettingRow>())
        {
            var key = $"{row.ObjectName}_{row.Key}";
            secretManager.LoadSecret(key, row.Value, row.Note);
        }
    }

    public void ClearSecrets()
    {
        secretManager.ClearSecrets();
    }
}