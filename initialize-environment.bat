@ECHO OFF
PUSHD %~dp0
PowerShell.exe -NoProfile -ExecutionPolicy Bypass -Command "& './build.ps1' -Target InitializeEnvironment"

IF %errorlevel% neq 0 PAUSE

