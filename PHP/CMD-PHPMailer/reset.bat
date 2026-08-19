@echo off
if exist "%~dp0\src\settings.csv" (
del "%~dp0\src\settings.csv"
start "" email.bat
exit
) else (
start "" email.bat
exit
)
