echo off


set CURRENT_USER_ROFILE=%USERPROFILE%\����稩 �⮫\*.*
rem set CURRENT_USER_PROFILE_DOC=%USERPROFILE%\��� ���㬥���\


rem ===========================�������� �� ����� admin==========================================================

reg query HKLM\SOFTWARE\Microsoft\.NETFramework | find /i "v4." 
cls

if %ERRORLEVEL% == 1 ( 
CD .

start /WAIT "" "%TEMP%\Zayavka\dotNetFx40_Full_x86_x64.exe"
)



if %ERRORLEVEL% == 0 GOTO M1
IF EXIST "C:\ProgramData\" (
start "" "%USERPROFILE%\Documents\Zayavka\vbs\iserrore.vbs"
)
IF NOT EXIST "C:\ProgramData\" (
start "" "%USERPROFILE%\����稩 �⮫\Zayavka\vbs\iserrore.vbs"
)
GOTO M3


rem ===========================XP===============================================================

:M1
IF EXIST "C:\ProgramData\" (
GOTO M2
)

echo ok_xp

md "%USERPROFILE%\��� ���㬥���\Zayavka"

IF EXIST "%USERPROFILE%\��� ���㬥���\Zayavka" (
echo directory_is_develop
)

IF NOT EXIST "%USERPROFILE%\��� ���㬥���\Zayavka" (
GOTO M3
)

XCOPY /y /E "%TEMP%\Zayavka" "%USERPROFILE%\��� ���㬥���\Zayavka"
xcopy /y "%USERPROFILE%\��� ���㬥���\Zayavka\zayavka(KCP).exe.lnk" "%USERPROFILE%\����稩 �⮫"

IF EXIST "%USERPROFILE%\����稩 �⮫\Zayavka.exe.lnk" (
echo EXE_on_desktop
)
del /q /s "%TEMP%\Zayavka"
echo File_del
PAUSE
EXIT



rem ===========================7ka===============================================================


:M2 
echo ok_7

md "%USERPROFILE%\Documents\Zayavka"

IF EXIST "%USERPROFILE%\Documents\Zayavka" (
echo directory_is_develop
)
IF NOT EXIST "%USERPROFILE%\Documents\Zayavka" (
GOTO M3
)

XCOPY /y /E %TEMP%\Zayavka "%USERPROFILE%\Documents\Zayavka"
xcopy /y "%USERPROFILE%\Documents\Zayavka\Zayavka7.exe" "%USERPROFILE%\Desktop\"
IF EXIST "%USERPROFILE%\Desktop\Zayavka7.exe.lnk" (
echo EXE_on_desktop
)
del /q /s "%TEMP%\Zayavka"
echo File_del
PAUSE
EXIT

rem ===========================AND===============================================================

:M3
pause
EXIT