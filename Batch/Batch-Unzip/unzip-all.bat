@echo off
setlocal

rem set folderZipPath="C:\Users\Fabrizio\Desktop\%%~na\"
rem set folderPath="C:\Users\Fabrizio\Desktop\%%~nxa"

set folderZipPath="C:\Users\Fabrizio\Desktop\"
set folderPath="C:\Users\Fabrizio\Desktop\"

if not exist %folderZipPath% (
echo Zip File Folder Not Found.
echo Please update %%folderZipPath%% env variable
pause>nul
exit /b
)

set folderZipPath=%folderZipPath:\"=\%%%~na\"%


if not exist %folderPath% (
echo Folder Path Not Found.
echo Please update %%folderPath%% env variable
pause>nul
exit /b
)

set folderPath=%folderPath:\"=\%%%~nxa\"%

cd /d %~dp0
echo Unzip All Zip from %folderZipPath% to %folderPath%
echo Please wait...
echo.
for %%a in (*.zip) do (
ECHO Processing %folderZipPath%
Call :UnZipFile %folderZipPath% %folderPath%
echo.
)
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