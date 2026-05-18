# sync-hard-reset.ps1
# Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

git fetch origin
git reset --hard origin/main
