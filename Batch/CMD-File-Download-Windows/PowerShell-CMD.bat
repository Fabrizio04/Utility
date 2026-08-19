@echo off
set url=https://www.7-zip.org/a/7z1900-x64.exe
set file=%userprofile%\Desktop\7z1900-x64.exe
set mysize=1447178

set size=0
set username=myusername
set password=mypassword

set proxy=http://localhost
set porta=8080

ECHO Download file da %url%

:: Download
PowerShell -NoLogo -Command "$webClient=new-object System.Net.WebClient; $webClient.DownloadFile('%url%', '%file%')"

:: Download (Basic Auth)
:: PowerShell -NoLogo -Command "$webClient=new-object System.Net.WebClient; $webClient.Credentials=new-object System.Net.NetworkCredential('%username%', '%password%'); $webClient.DownloadFile('%url%', '%file%')"

:: Download (Proxy Auth)
:: PowerShell -NoLogo -Command "$webClient=new-object System.Net.WebClient; $WebProxy=New-Object System.Net.WebProxy('%proxy%:%porta%',$true); $Credentials=New-Object Net.NetworkCredential('%username%', '%password%'); $Credentials=$Credentials.GetCredential('%proxy%','%porta%', 'KERBEROS'); $WebProxy.Credentials=$Credentials; $webClient.Proxy=$WebProxy; $webClient.DownloadFile('%url%', '%file%')"

timeout /t 2

if exist %file% call :filesize %file%

ECHO.

if '%size%'=='%mysize%' (
ECHO Download completato
) else (
ECHO Errore
)

ECHO Premi un tasto per chiudere
pause>nul
exit

:filesize
set size=%~z1