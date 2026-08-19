@echo off
:: Parametri condivisione share
set shareIP=192.168.1.10
set sharePath=\\192.168.1.10\share
set shareLetter=Z
set shareUsername=DOMINIO\utente
set sharePassword=myPassword
set sharePingCheck=true

:: Parametri installazione stampante
set infPath=path\to\my\driver\folder\oemsetup.inf
set driverName=DRIVER NAME
set ipAddress=192.168.1.11
set portName=192.168.1.11_TCP_IP
set printName=Stampante di RETE
set architecture=x64

:: Inizio programma
title Installazione stampante %printName%

:: Verifica share condivisa
cls
if '%sharePingCheck%' == 'true' (
ping %shareIP% -n 1 -w 1000 >nul
if errorlevel 1 (
ECHO Impossibile stabilire una connessione con la share.
ECHO.
ECHO Verificare la connessione alla rete.
ECHO.
ECHO Premi un tasto per chiudere.
pause>nul
exit
)
)

:: Richiesta Controllo Account Utente (UAC)
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"
if '%errorlevel%' NEQ '0' (
echo Apertura UAC ...
goto UACPrompt
) else (
goto gotAdmin
)

:UACPrompt
echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
set params = %*:"="
if '%1' == '/d' (
echo UAC.ShellExecute "cmd.exe", "/c %~s0 %params% %1", "", "runas", 1 >> "%temp%\getadmin.vbs"
) else (
echo UAC.ShellExecute "cmd.exe", "/c %~s0 %params%", "", "runas", 1 >> "%temp%\getadmin.vbs"
)
"%temp%\getadmin.vbs"
del "%temp%\getadmin.vbs"
exit /B

:: Connessione alla share di rete
:gotAdmin
ECHO Connessione a %shareIP%
for /l %%a in (1, 1, 15) do ( 
if exist %sharePath% (
goto cont
) else (
net use Z: %sharePath% /user:%shareUsername% %sharePassword%
)
)
:cont
ECHO Accesso eseguito correttamente
ECHO.

:: Installazione stampante
echo Installo il driver nel PC... 
printui /ia /m "%driverName%" /f "%shareLetter%:\%infPath%" /h %architecture%
echo Aggiungo la porta di rete nel PC...
PowerShell -NoLogo -Command "add-printerport -name '%portName%' -printerhostaddress '%ipAddress%'"
echo Aggiungo la stampante %printName%...
PowerShell -NoLogo -Command "add-printer -name '%printName%' -drivername '%driverName%' -port '%portName%'"

:: Imposta stampante come predefinita
if '%1' == '/d' (
echo Imposto la stampante predefinita... 
RUNDLL32 PRINTUI.DLL,PrintUIEntry /y /n "%printName%"
)

ECHO.
ECHO Chiusura connessione a %shareIP%
net use %shareLetter%: /delete
ECHO Fatto, premi un tasto qualsiasi per chiudere.
pause>nul