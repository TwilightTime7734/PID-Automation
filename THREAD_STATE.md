Thread state snapshot

- updated: 2026-05-16
- workspace: D:\VisualStudioCommunity\DronePidTuningAssistant.WinForms
- branch: main (local)
- primary files: MainForm.cs, MainForm.Designer.cs

Current project state:
- DockPanelSuite/docking framework has been removed from the WinForms project.
- Main layout is currently Designer-driven (runtime layout helper methods were removed from MainForm.cs).
- Serial Ports section now uses:
  - FC row controls: cboPort, cboBaud, btnFcConnect, btnFcDisconnect
  - Arduino row controls: cboArduinoPort, cboArduinoBaud, btnArduinoConnect, btnArduinoDisconnect
  - Refresh control: btnRefreshPorts
- Duplicate old right-side serial buttons were removed.
- Channel mapping combos are renamed and present in designer:
  - cboCH1, cboCH2, cboCH3, cboCH4
- Static combo items moved into designer for:
  - cboBaud / cboArduinoBaud (9600, 115200; default 115200)
  - cboCH1..cboCH4 (1..8)
- Dynamic serial port list population remains in MainForm.cs (PopulatePortCombos / RefreshPortList).

User directive for future designer edits:
- User controls layout manually.
- When modifying MainForm.Designer.cs, keep layout properties constrained to:
  - Dock = None
  - Anchor = Top, Left
  - AutoSize = false
- Do not make broad layout refactors unless explicitly requested.

Line ending policy:
- User expects CRLF-only edits.
- Apply CRLF normalization after file edits.

If context changes next thread should read:
- MainForm.Designer.cs (authoritative form layout + control declarations)
- MainForm.cs (serial/telemetry/PID behavior and button enable-state logic)
- DronePidTuningAssistant.WinForms.csproj (package/dependency state)

Backups created during this thread:
- MainForm.cs.pre-rename.bak
- MainForm.Designer.cs.pre-rename.bak

Last known successful compile:
- dotnet build -t:Compile (success, 0 errors)
