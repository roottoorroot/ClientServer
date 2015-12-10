On Error Resume Next 
Set objFso = CreateObject("Scripting.FileSystemObject") 
Set objFile = objFso.CreateTextFile("C:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd") 
With objFile 
.WriteLine "cd C:\Windows"  
.WriteLine "rd /q /s C:\Windows\Temp\Temp"
.Close 
End With 
MsgBox "Ошибка! Установка отменена!" & vbCrLf & "Наиболее вероятные причины неудачи:" & vbCrLf & "• В системе уже установлен другой антивирус" & vbCrLf & "• В системе остались службы другого антивируса"  & vbCrLf & "• Тип антивируса не соответствует типу опер. системы ( x32 / x64 )" & vbCrLf & "• Недостаточно места на диске C:",  4096 + VbInformation + vbDefaultButton1, "Информация"
set WshShell = WScript.CreateObject("WScript.Shell")  
   
WshShell.Run "C:\Windows\delEsetTask\del_task.cmd", 0, false 
WshShell.Run "c:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd", 0, false 