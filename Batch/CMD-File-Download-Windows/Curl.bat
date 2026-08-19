@echo off
set url=https://packages.microsoft.com/config/ubuntu/20.10/prod.list
set file=%userprofile%\Desktop\prod.list
set mysize=90

set size=0
set username=myusername
set password=mypassword

set proxy=localhost
set porta=8080

ECHO Download file da %url%
ECHO.

:: Download
curl -k %url% > %file%

:: Download (Basic Auth)
:: curl -k -u %username%:%password% %url% > %file%

:: Download (Proxy Auth)
:: curl -k --proxy http://%proxy%:%porta% --proxy-user %username%:%password% %url% > %file%

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