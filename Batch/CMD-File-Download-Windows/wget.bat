@echo off
set url=https://www.7-zip.org/a/7z1900-x64.exe
set file=%userprofile%\Desktop\7z1900-x64.exe
set mysize=1447178

set size=0
set username=myusername
set password=mypassword

set proxy=localhost
set porta=8080

ECHO Download file da %url%
ECHO.

:: Download
wget -O %file% %url%

:: Download (Basic Auth)
:: wget --http-user=%username% --http-password=%password% %file% %url%

:: Download (Proxy Auth)
:: wget -e use_proxy=on -e http_proxy=http://%proxy%:%porta%/ -e proxy_user=%username% -e proxy_passwd=%password% %file% %url%

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
