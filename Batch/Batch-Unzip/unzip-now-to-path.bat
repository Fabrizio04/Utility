@echo off
setlocal

set "zipFile=%1"

if not exist %zipFile% (
echo Zip File Not Found.
echo Please drag and drop Zip file to "unzip-to-path.bat"
pause>nul
exit /b
)

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
Call :UnZipFile %folderPath% %zipFile%
echo Done!
echo Press any key to exit
pause>nul
exit /b

:UnZipFile <ExtractTo> <newzipfile>
set vbs="%temp%\_.vbs"
if exist %vbs% del /f /q %vbs%
>%vbs%  echo Set fso = CreateObject("Scripting.FileSystemObject")
>>%vbs% echo If NOT fso.FolderExists(%1) Then
>>%vbs% echo fso.CreateFolder(%1)
>>%vbs% echo End If
>>%vbs% echo set objShell = CreateObject("Shell.Application")
>>%vbs% echo set FilesInZip=objShell.NameSpace(%2).items
>>%vbs% echo objShell.NameSpace(%1).CopyHere(FilesInZip)
>>%vbs% echo Set fso = Nothing
>>%vbs% echo Set objShell = Nothing
cscript //nologo %vbs%
if exist %vbs% del /f /q %vbs%
