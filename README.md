# DronePidTuningAssistant.WinForms

Standalone C# WinForms port scaffold. This project is intentionally separate from the Python app.

## Open in Visual Studio Community

1. Install `.NET 8 SDK` (or newer Windows-compatible SDK).
2. Open `DronePidTuningAssistant.WinForms.csproj` in Visual Studio Community.
3. Build and run.

## Current Status

- Basic WinForms shell is implemented.
- `FC USB Serial Port` section is implemented (port list, baud selection, refresh, connect, disconnect).
- `Transmitter PPM Channel Mapping` UI exists with vertical `Roll`, `Pitch`, `Throttle` inputs.
- Mapping is saved/loaded from:
  - `%LOCALAPPDATA%\\DronePidTuningAssistantWinForms\\settings.json`
- Ongoing migration log:
  - `PORTING_PROGRESS.md`

## Porting Plan

1. Add serial/USB connection controls and transport service.
2. Port channel test behaviors.
3. Port telemetry read loop and live status updates.
4. Port PID tuning workflow and charting.
