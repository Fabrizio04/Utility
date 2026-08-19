@echo off
setlocal

set folderPath="C:\Users\Fabrizio\Desktop\Aaaa\"
set zipFile="C:\Users\Fabrizio\Desktop\file.zip"

if not exist %zipFile% (
echo Zip File Not Found.
echo Please update %%zipFile%% env variable
pause>nul
exit /b
)

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