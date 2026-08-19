@echo off
setlocal EnableDelayedExpansion

taskkill /f /im vlc.exe>nul

start "" "C:\Users\Fabrizio\Desktop\TLC 1.lnk"
start "" "C:\Users\Fabrizio\Desktop\TLC 2.lnk"

timeout /t 2>nul
rem pause

set first=false

for /f "tokens=1-2,12" %%a in ('cmdow /t /p') do (
  if '%%c'=='vlc' (
    rem echo '!first!'
	rem pause
	
	if '!first!'=='true' (
	  cmdow %%a /hid /mov 953 0 /siz 974 1039 /act /vis
	) else (
	  rem echo %%a
	  cmdow %%a /hid /mov -7 0 /siz 974 1039 /act /vis
	  set first=true
	)
	
  )
)