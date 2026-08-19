@echo off
>nul 2>&1 "%systemroot%\system32\cacls.exe" "%systemroot%\system32\config\system"
If '%errorlevel%' neq '0' (Goto uacprompt) else (goto gotadmin)
:uacprompt
Echo set uac = createobject^("shell.application"^) > "%temp%\getadmin.vbs"
Echo uac.shellexecute "%~s0", "", "", "runas", 1 >> "%temp%\getadmin.vbs"
"%temp%\getadmin.vbs"
Exit /b
:gotadmin
If exist "%temp%\getadmin.vbs" (del "%temp%\getadmin.vbs")

set /p "scheda=Inserisci il nome della scheda di rete: "

rem pulizia dns attuali
netsh interface ipv4 set dnsservers name="%scheda%" source=dhcp

timeout /t 2

rem imposto i nuovi dns
netsh interface ipv4 add dnsserver "%scheda%" 8.8.8.8
netsh interface ipv4 add dnsserver "%scheda%" 8.8.4.4

pause