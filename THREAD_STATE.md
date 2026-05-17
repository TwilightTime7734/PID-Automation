Thread state snapshot

- updated: 2026-05-17
- workspace: D:\VisualStudioCommunity\DronePidTuningAssistant.WinForms
- python source project: D:\VisualStudioCode\Python
- branch: main (local)
- primary files: MainForm.cs, MainForm.Designer.cs, Services/SerialPortService.cs, Services/ArduinoTrainerCableClient.cs

Current project state:
- DockPanelSuite/docking framework removed.
- Form layout is currently panel-based in Designer (TableLayoutPanel/FlowLayoutPanel were converted to Panel).
- Top row layout (Serial Ports / Mapping / Channel Test) is currently unlocked/responsive:
  - grpUsb: Dock=Left
  - grpMapping: Dock=Left
  - grpChannelTest: Dock=Fill
  - channelTestLayout: Dock=Fill
- Serial Ports section has FC and Arduino rows plus status labels:
  - FC: cboPort, cboBaud, btnFcConnect, btnFcDisconnect
  - Arduino: cboArduinoPort, cboArduinoBaud, btnArduinoConnect, btnArduinoDisconnect
  - Status labels: lblFCStatus (FC), lblArduinoStatus (Arduino)
- Added Trainer pin UI in Serial Ports:
  - lblTrainerPin + cboTrainerPin
  - cboTrainerPin items: 3, 5, 6, 9, 10, 11
  - selected pin is used on Arduino connect/reconnect and can be changed live while connected.

Porting status (Python -> WinForms):
- FC MSP path: implemented in SerialPortService.cs
  - attitude read, setting get/set, save settings.
- Arduino trainer-cable Telemetrix path: implemented in ArduinoTrainerCableClient.cs
  - command 62: begin
  - command 63: end
  - command 64: set single channel pulse
  - command 65: set all 8 channel pulses
  - command 66: center
  - command 67: status
  - command 68: set output pin
  - status parser includes legacy 76-byte payload hint.
- MainForm integration:
  - ConnectArduinoUsb: open serial, set selected trainer pin, begin, center controls.
  - DisconnectArduinoUsb: end and close Arduino transport.
  - OnArduinoBaudChanged: reconnect + set selected pin + begin + center.
  - OnTrainerPinChanged: live pin switch while connected.
- Channel test path:
  - RunChannelTestAsync sends actual Arduino trainer pulses via channel mapping (A/E/T/R -> CH1..CH4 combo mapping).
  - centers controls at the end.
- PID workflow:
  - PID control enablement is FC USB-only (Arduino connection does not enable PID controls).
  - PID button alignment/wording has been cleaned up in Designer.
  - pidButtonLayout is in grpPidWorkflow; lvTuningRuns belongs in pnlScoreChart (restored).
  - if Arduino connected, uses dynamic scoring path with baseline angular-rate sampling + positive/negative direction capture + angle-target neutralization.
  - if Arduino not connected, uses legacy noise-only scoring fallback.

User directives to preserve:
- User controls layout manually.
- Use CRLF line endings only.
- Before editing designer files, ask user to close Designer tabs.

Backups present:
- MainForm.cs.pre-rename.bak
- MainForm.Designer.cs.pre-rename.bak
- MainForm.Designer.cs.bak-before-panel-convert
- MainForm.Designer.cs.bak-before-flow-to-panel

Last known successful compile:
- dotnet build (success, 0 errors, 0 warnings)
