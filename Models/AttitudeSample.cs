namespace DronePidTuningAssistant.WinForms.Models;

public sealed class AttitudeSample
{
    public double RollDeg { get; init; }
    public double PitchDeg { get; init; }
    public double YawDeg { get; init; }
    public DateTime TimestampLocal { get; init; }
}
