On Error Resume Next
set WshShell = WScript.CreateObject("WScript.Shell")   
WshShell.Run "%TEMP%\Zayavka\install.cmd", 0, false    
set oShell = WScript.CreateObject ("WScript.Shell")
oShell.Popup "Запуск установки! ждите....", 5, "Информация"