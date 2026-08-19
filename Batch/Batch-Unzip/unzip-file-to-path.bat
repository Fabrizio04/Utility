<# : unzip-file-to-path.bat

@echo off
setlocal

echo Please select Zip File

for /f "delims=" %%I in ('powershell -noprofile "iex (${%~f0} | out-string)"') do (
    set zipFile="%%~I"
)

if ['%zipFile%']==[''] (
echo Zip File Not Found.
echo Please select a Zip file
pause>nul
exit /b
)

echo Please select folder path

set "psCommand="(new-object -COM 'Shell.Application')^
.BrowseForFolder(0,'Please choose a folder.',0,0).self.path""

for /f "usebackq delims=" %%I in (`powershell %psCommand%`) do set "folder=%%I"

setlocal enabledelayedexpansion

if ["%folder%"]==[""] (
echo Path not found, please select correct path to unzip.
pause>nul
exit /b
)

set folderPath="%folder%"

cd /d %~dp0
echo Unzip %zipFile% to %folderPath%
echo Please wait...

set vbs="%temp%\_.vbs"
if exist %vbs% del /f /q %vbs%
>%vbs%  echo Set fso = CreateObject("Scripting.FileSystemObject")
>>%vbs% echo If NOT fso.FolderExists(%folderPath%) Then
>>%vbs% echo fso.CreateFolder(%folderPath%)
>>%vbs% echo End If
>>%vbs% echo set objShell = CreateObject("Shell.Application")
>>%vbs% echo set FilesInZip=objShell.NameSpace(%zipFile%).items
>>%vbs% echo objShell.NameSpace(%folderPath%).CopyHere(FilesInZip)
>>%vbs% echo Set fso = Nothing
>>%vbs% echo Set objShell = Nothing
cscript //nologo %vbs%
if exist %vbs% del /f /q %vbs%

echo Done!
echo Press any key to exit
pause>nul
exit /b

: file selector #>

Add-Type -AssemblyName System.Windows.Forms
$f = new-object Windows.Forms.OpenFileDialog
$f.InitialDirectory = pwd
$f.Filter = "Zip Files (*.zip)|*.zip|All Files (*.*)|*.*"
$f.ShowHelp = $true
$f.Multiselect = $true
[void]$f.ShowDialog()
if ($f.Multiselect) { $f.FileNames } else { $f.FileName }