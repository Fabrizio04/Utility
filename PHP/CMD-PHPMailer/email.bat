@echo off
title Send Mail from CMD by Fabrizio Amorelli
if exist "%~dp0\src\settings.csv" (
goto via
)

:debug
cls
set /p dbg= Debug [si - no]: || set dbg=NothingChosen
if '%dbg%'=='NothingChosen' (
goto debug
) else (
if '%dbg%'=='si' (
set dbg=2
goto host
) else if '%dbg%'=='no' (
set dbg=0
goto host
) else (
goto debug
)
)

:host
cls
set /p host= Server SMTP: || set host=NothingChosen
if '%host%'=='NothingChosen' (
goto host
) else (
goto au
)


:au
cls
set /p auth= Autenticazione [si - no]: || set auth=NothingChosen

if '%auth%'=='NothingChosen' (
goto au
) else (
if '%auth%'=='si' (
goto ausi
) else if '%auth%'=='no' (
goto smtpsecure
) else (
goto au
)
)

:ausi
cls
set /p user= Username: || set user=NothingChosen
if '%user%'=='NothingChosen' (
goto ausi
) else (
goto passw
)

:passw
cls
set /p psw= Password: || set psw=NothingChosen
if '%psw%'=='NothingChosen' (
goto passw
) else (
goto smtpsecure
)

:smtpsecure
cls
set /p smtpsec= Sicurezza SMTP [ssl - tsl - no]: || set smtpsec=NothingChosen

if '%smtpsec%'=='NothingChosen' (
goto smtpsecure
) else (
if '%smtpsec%'=='ssl' (
set smtpsec=ssl
goto porta
) else if '%smtpsec%'=='tsl' (
set smtpsec=tsl
goto porta
) else if '%smtpsec%'=='no' (
set smtpsec=no
goto porta
) else (
goto smtpsecure
)
)

:porta
cls
set /p prt= Porta: || set prt=NothingChosen
if '%prt%'=='NothingChosen' (
goto porta
) else (
goto fine
)

:fine
echo %dbg%;%host%;%auth%;%user%;%psw%;%smtpsec%;%prt% > "%~dp0\src\settings.csv"
goto via

:via
cd "%~dp0\php"
php "%~dp0\src\program.php"
ECHO.
pause
exit