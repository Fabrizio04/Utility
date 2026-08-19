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

FOR /F "tokens=3,*" %%A IN ('netsh interface show interface^|find "Connessione"') DO (
   rem echo %%B
   rem echo connected : %%B
   echo.%%B | findstr /C:"Ethernet">nul && (
	  rem true
	  
	  rem pulizia dns attuali
      netsh interface ipv4 set dnsservers name="%%B" source=dhcp
	  
	  timeout /t 2
	  
	  rem imposto i nuovi dns
	  netsh interface ipv4 add dnsserver "%%B" 8.8.8.8
      netsh interface ipv4 add dnsserver "%%B" 8.8.4.4
	  
   ) || (
      rem false
   )
)

rem netsh interface show interface

pause