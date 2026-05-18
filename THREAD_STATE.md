# THREAD_STATE

## Project
- Repo: `D:\VisualStudioCommunity\DronePidTuningAssistant.WinForms`
- Python reference path: `D:\VisualStudioCode\Python`

## Current UI State
- INAV PID section rebuilt as a matrix in `grpPidWorkflow`:
  - `TableLayoutPanel` with PID headers and Roll/Pitch/Yaw rows.
  - Read-only PID textboxes by default.
  - Extra action column with buttons: `Read FC`, `Editable`, `Write FC`.
  - `Editable` toggles textbox edit mode and turns green when enabled.
- `lvTuningRuns` removed from layout and designer.
- `pnlScoreChart` now renders run graphs (Python-style format):
  - Positive/negative response lines.
  - Dashed target lines.
  - Zero line and grid.
  - Recommendation text and run title.

## Behavior State
- PID textbox population:
  - Populates from FC on connect and on `Read FC`.
  - Refreshes after manual/apply/save operations.
  - Handles missing FC keys gracefully (`--`).
- Simulation mode:
  - On enable, PID boxes populate with safe defaults.
  - Channel tests allowed in simulation (no Arduino-required blocking dialog).
  - PID tuning runs in simulation now capture graph-series data so chart updates.

## Safe Simulation PID Defaults
- Roll: `P=40`, `I=50`, `D=30`, `FF=40`
- Pitch: `P=40`, `I=50`, `D=30`, `FF=40`
- Yaw: `P=45`, `I=55`, `D=0`, `FF=35`

## Recent Commits
- `0067c42` Enable simulation channel tests and chart rendering; remove tuning list view
- `4e60b0c` Add editable PID matrix column with FC read/write controls

## Notes
- `Services/ArduinoTrainerCableClient.cs` is currently untracked and not included in those commits.
- User confirmation (May 18, 2026): rebuilt design is working great.
- User confirmation (May 18, 2026): USB FC connection and FC read functions are working fine.
