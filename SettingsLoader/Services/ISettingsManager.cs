namespace SettingsLoader.Services;

public interface ISettingsManager
{
    Task LoadSecrets();

    void ClearSecrets();
}