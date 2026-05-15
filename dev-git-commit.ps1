param(
    [Parameter(Mandatory = $true)]
    [string]$Message
)

$ErrorActionPreference = "Stop"

if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
    Write-Error "git is not installed or not in PATH."
    exit 1
}

git rev-parse --is-inside-work-tree *> $null
if ($LASTEXITCODE -ne 0) {
    Write-Error "Current directory is not a git repository."
    exit 1
}

git add -A
git commit -m $Message

if ($LASTEXITCODE -eq 0) {
    Write-Host "Commit created: $Message"
}
