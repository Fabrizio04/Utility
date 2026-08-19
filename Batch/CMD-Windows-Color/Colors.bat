@echo off

:: Color
set "Foreground_Black=%ESC%[30m"
set "Foreground_Red=%ESC%[31m"
set "Foreground_Green=%ESC%[32m"
set "Foreground_Yellow=%ESC%[33m"
set "Foreground_Blue=%ESC%[34m"
set "Foreground_Magenta=%ESC%[35m"
set "Foreground_Cyan=%ESC%[36m"
set "Foreground_White=%ESC%[37m"
set "Foreground_Extended=%ESC%[38m"
set "Foreground_Default=%ESC%[39m"

:: Bright Color
set "Foreground_Bright_Black=%ESC%[90m"
set "Foreground_Bright_Red=%ESC%[91m"
set "Foreground_Bright_Green=%ESC%[92m"
set "Foreground_Bright_Yellow=%ESC%[93m"
set "Foreground_Bright_Blue=%ESC%[94m"
set "Foreground_Bright_Magenta=%ESC%[95m"
set "Foreground_Bright_Cyan=%ESC%[96m"
set "Foreground_Bright_White=%ESC%[97m"

:: Background
set "Background_Black=%ESC%[40m"
set "Background_Red=%ESC%[41m"
set "Background_Green=%ESC%[42m"
set "Background_Yellow=%ESC%[43m"
set "Background_Blue=%ESC%[44m"
set "Background_Magenta=%ESC%[45m"
set "Background_Cyan=%ESC%[46m"
set "Background_White=%ESC%[47m"
set "Background_Extended=%ESC%[48m"
set "Background_Default=%ESC%[49m"

:: Bright Background
set "Background_Bright_Black=%ESC%[100m"
set "Background_Bright_Red=%ESC%[101m"
set "Background_Bright_Green=%ESC%[102m"
set "Background_Bright_Yellow=%ESC%[103m"
set "Background_Bright_Blue=%ESC%[104m"
set "Background_Bright_Magenta=%ESC%[105m"
set "Background_Bright_Cyan=%ESC%[106m"
set "Background_Bright_White=%ESC%[107m"

set "ENDC=%ESC%[0m"

echo %Background_Cyan%%Foreground_Red%Test 1%ENDC% %Background_Bright_White%%Foreground_Bright_Black%Test 2%ENDC% %Background_Bright_Red%%Foreground_Bright_Green%Test 3%ENDC%