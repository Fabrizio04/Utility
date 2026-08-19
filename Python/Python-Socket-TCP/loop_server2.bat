@echo off
set python=C:\Python27\python.exe
:socket
cls
%python% "%~dp0\src\server_socket_2.py"
pause
goto socket