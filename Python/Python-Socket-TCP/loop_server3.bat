@echo off
set python3="%userprofile%\AppData\Local\Programs\Python\Python39\python.exe"
:socket
cls
%python3% "%~dp0\src\server_socket_3.py"
pause
goto socket