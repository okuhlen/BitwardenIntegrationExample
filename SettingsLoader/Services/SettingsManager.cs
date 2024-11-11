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
        using var reader = new StreamReader($"{Directory.GetCurrentDirectory()}/Files/settings.csv");
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