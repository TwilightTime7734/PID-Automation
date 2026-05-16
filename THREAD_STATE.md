Thread state snapshot

- created: 2026-05-15
- workspace: D:\VisualStudioCommunity\DronePidTuningAssistant.WinForms
- branch: main (local)
- current primary file: MainForm.cs

Recent actions taken in this thread:
- Disabled restoring persisted dock layouts (TryRestoreDockLayout now returns false).
- Disabled saving persisted dock layouts (SaveDockLayout is a no-op).
- Removed calls that initialized or mutated runtime dock workspace (InitializeDockWorkspace call commented out in constructor).
- Deleted saved layout folder: %LOCALAPPDATA%\DronePidTuningAssistantWinForms (including docklayout_*.xml).
- Performed dotnet clean & build; output: bin\Debug\net8.0-windows\DronePidTuningAssistant.WinForms.dll

What to read next if thread context changes:
- MainForm.cs - runtime UI and docking changes
- MainForm.Designer.cs - designer layout to preserve
- Services\LayoutSettingsService.cs - channel mapping persistence

Notes & next steps:
- If the app still shows an unexpected layout, search and delete any remaining docklayout_*.xml files on the machine.
- To restore persistence behavior later, revert changes in MainForm.cs for TryRestoreDockLayout and SaveDockLayout, and re-enable InitializeDockWorkspace in the constructor.

Short commands used:
- Get-ChildItem -Path $env:LOCALAPPDATA -Recurse -Filter 'docklayout_*.xml'
- Remove-Item -Path 'C:\Users\<user>\AppData\Local\DronePidTuningAssistantWinForms' -Recurse -Force
- dotnet clean
- dotnet build -c Debug

State owner: GitHub Copilot (automated change record)