@echo off
set url=https://www.7-zip.org/a/7z1900-x64.exe
set file=%userprofile%\Desktop\7z1900-x64.exe
set mysize=1447178

set size=0
set username=myusername
set password=mypassword

set proxy=localhost
set porta=8080
@set c=0

ECHO Download file da %url%

:: Single Job Download
:: bitsadmin /transfer debjob /download /priority normal %url% %file%


:: Multi Job Download
bitsadmin /create debjob
bitsadmin /addfile debjob %url% %file%

:: Basic Auth
:: bitsadmin /setcredentials debjob SERVER BASIC %username% %password%

:: Proxy Auth
:: bitsadmin /setcredentials debjob PROXY BASIC %username% %password%
:: bitsadmin /setproxysettings debjob OVERRIDE %proxy%:%porta% "<local>"

bitsadmin /SetPriority debjob "FOREGROUND"
bitsadmin /resume debjob

:WAIT_DUMP_DATA_DOWNLOAD_LOOP_START
    call bitsadmin /info debjob /verbose | find "STATE: TRANSFERRED"
    if %ERRORLEVEL% equ 0 goto WAIT_DUMP_DATA_DOWNLOAD_LOOP_END
    call bitsadmin /RawReturn /GetBytesTransferred debjob
	@set /a "d=%c%+1"
	@set c=%d%
	if %c%==5 goto TIMEOUT_DOWNLOAD
    timeout 2
    goto WAIT_DUMP_DATA_DOWNLOAD_LOOP_START
:WAIT_DUMP_DATA_DOWNLOAD_LOOP_END

call bitsadmin /Complete debjob

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

:TIMEOUT_DOWNLOAD
bitsadmin /reset
ECHO Errore
ECHO Premi un tasto per chiudere
pause>nul
exit

:filesize
set size=%~z1