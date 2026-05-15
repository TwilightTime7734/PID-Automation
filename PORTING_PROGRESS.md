# WinForms Porting Progress Log

Last updated: 2026-05-14 (America/Los_Angeles)
Project: `D:\VisualStudioCommunity\DronePidTuningAssistant.WinForms`
Source reference only: `D:\VisualStudioCode\Python` (Python code is not edited)

## Ground Rules
1. Recreate the Python app in C# WinForms one section at a time.
2. Keep UI Designer-editable: use `MainForm.Designer.cs` for layout (no full runtime UI construction).
3. Do not modify Python project files while porting.
4. Keep progress notes here after each work session.

## Current Status
1. Standalone WinForms project is created and opens in Visual Studio Community.
2. FC USB Serial Port section is implemented:
   - Port list refresh
   - Baud rate selection
   - Connect/Disconnect handlers
3. Transmitter PPM Channel Mapping section is implemented:
   - Roll/Pitch/Throttle channel selectors
   - Mapping save/load via `%LOCALAPPDATA%\DronePidTuningAssistantWinForms\settings.json`
4. Channel Test section is implemented (Designer-based):
   - Roll/Pitch/Throttle test buttons
   - Inputs for target angle, settle time, baseline time, throttle pulse
   - Live status, pulse value, roll/pitch angle labels
   - Pulse visualization bar
   - Throttle safety confirmation prompt
5. Telemetry section is implemented (Designer-based):
   - `Start Live`, `Stop Live`, and `Snapshot` actions
   - Live Roll/Pitch/Yaw readout fields
   - Last-updated timestamp field
   - Live polling loop with connection gating and safe stop on disconnect
   - Live data source switched from placeholder values to real INAV MSP `MSP_ATTITUDE` reads
6. Main form remains Designer-managed and editable in Visual Studio.
7. PID tuning workflow/charting section is started (Designer-based):
   - `Run Roll`, `Run Pitch`, `Re-test`, `Finish Axis`, `Apply Recommended PID` actions
   - Active-axis state and recommendation text panel
   - Tuning run history table
   - Score trend chart panel (drawn from accumulated runs)
   - Telemetry-driven scoring pass (noise-based first-pass heuristic)
   - `Apply Recommended PID` now writes real INAV PID values over MSP and saves to FC
   - Manual PID controls added (axis/gain/points with `PID -` / `PID +`)
   - `Read FC` and `Save FC` actions added for PID workflow parity
   - Persistent on-form PID snapshot panel added (Roll/Pitch P/I/D) with refresh after reads/writes
8. Docking framework integrated:
   - Free DockPanel Suite (`DockPanelSuite` NuGet, v3.1.1) installed
   - Porting-area sections hosted in dockable tool windows (drag, float, re-dock, resize)
   - Dock layout persists/restores per machine (`docklayout_<MACHINE>.xml`)

## In-Progress Task
1. Continue section-by-section UI/behavior parity from Python to WinForms.
2. Keep all new sections Designer-compatible.
3. Record each completed section and remaining deltas in this file.

## Next Target Sections
1. Refine scoring/recommendation logic toward Python parity (`choose_combined_recommendation` behavior).
2. Expand chart cards/plots toward Python chart-strip parity.
3. Add FF display/read parity (`mc_cd_roll`, `mc_cd_pitch`) and include it in manual readout panel.

## Session Notes
### 2026-05-14
1. Re-established context after chat reset.
2. Confirmed Python repo is separate and currently untouched for porting work.
3. Confirmed WinForms project path and existing migrated sections.
4. Added this persistent log for recovery and continuity.
5. Ported Channel Test section into Designer-managed WinForms layout and code-behind behavior.
6. Verified compile with `dotnet build` (success; one existing designer warning `CS8669`).
7. Ported Telemetry section into Designer-managed WinForms layout and code-behind loop/snapshot behavior.
8. Verified compile with `dotnet build` (success; same existing designer warning `CS8669`).
9. Implemented real MSPv2 INAV telemetry in C# serial service (`MSP_FC_VARIANT`, `MSP_API_VERSION`, `MSP_FC_VERSION`, `MSP_ATTITUDE`) and wired it into live telemetry + snapshot updates.
10. Started PID workflow/charting UI and behavior with telemetry-driven run scoring, recommendation generation, run logging table, and score trend chart.
11. Implemented MSP2 INAV setting API in C# serial service and wired `Apply Recommended PID` to real FC write+verify+save flow (`mc_[p|i|d]_[roll|pitch]`).
12. Added manual PID +/- controls and FC PID read/save actions to the WinForms workflow section.
13. Added always-visible PID snapshot panel (Roll/Pitch P/I/D) and wired automatic refresh after `Read FC`, manual PID write, recommended PID apply, and save.
14. Switched to modern free docking package (`DockPanelSuite`) and replaced static panel stack with runtime dock workspace + dock contents.
15. Added machine-specific dock layout persistence/restore using DockPanel Suite XML serialization.

## 2026-05-14 - MainForm rewrite pass (serial UI reliability)
- Updated `MainForm.cs` serial UI state handling so FC/Arduino Connect buttons are disabled until a port is selected, and always disabled while already connected.
- Kept disconnect behavior explicit: Disconnect is enabled only when connected for each line.
- Added combo selection change hooks (`cboPort`, `cboArduinoPort`) to refresh button states immediately.
- Ensured app close path clears Arduino connected state and disposes serial resources.
- Verification: `dotnet build -t:Compile` passed (existing nullable warning in designer remains).

## 2026-05-14 - Step 1 + Step 2 wiring (connection-gated workflow + control path)
- Added workflow state gating in `MainForm.cs` so controls are enabled/disabled based on live connection state:
  - Telemetry controls require FC connection.
  - PID workflow controls require FC connection and are disabled during channel-test activity.
  - Channel test controls require at least one control path (FC direct or Arduino TX).
- Added active control-path selection logic:
  - Prefers Arduino path when Arduino is connected.
  - Falls back to FC direct when FC is connected.
  - Displays current path in channel visual status (`Path: ...`) when idle.
- Channel test status now explicitly includes path used (e.g. `via Arduino TX` or `via FC Direct`).
- Compile verification: `dotnet build -t:Compile` passed (existing designer warning only).
