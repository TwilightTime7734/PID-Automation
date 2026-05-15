using System.Text.Json;
using DronePidTuningAssistant.WinForms.Models;

namespace DronePidTuningAssistant.WinForms.Services;

public sealed class LayoutSettingsService
{
    private readonly string _settingsPath;

    public LayoutSettingsService()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var folder = Path.Combine(appData, "DronePidTuningAssistantWinForms");
        Directory.CreateDirectory(folder);
        _settingsPath = Path.Combine(folder, "settings.json");
    }

    public ChannelMapping LoadMapping()
    {
        if (!File.Exists(_settingsPath))
        {
            return new ChannelMapping();
        }

        try
        {
            var json = File.ReadAllText(_settingsPath);
            var settings = JsonSerializer.Deserialize<AppSettings>(json);
            return settings?.ChannelMapping ?? new ChannelMapping();
        }
        catch
        {
            return new ChannelMapping();
        }
    }

    public void SaveMapping(ChannelMapping mapping)
    {
        var settings = new AppSettings { ChannelMapping = mapping };
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_settingsPath, json);
    }

    private sealed class AppSettings
    {
        public ChannelMapping ChannelMapping { get; set; } = new();
    }
}
