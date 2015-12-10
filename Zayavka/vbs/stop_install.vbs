MsgBox "В системе обнаружена установленная версия антивируса NOD" & vbCrLf & "Необходимо удалить все предыдущие версии, после чего запустить установку еще раз." & vbCrLf & "" & vbCrLf & "Установка антивируса будет отменена!" & vbCrLf, 4096, "Предупреждение"

	Set objFso = CreateObject("Scripting.FileSystemObject") 
	Set objFile = objFso.CreateTextFile("C:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd") 
	With objFile 
		.WriteLine "cd C:\Windows"  
		.WriteLine "rd /q /s C:\Windows\Temp\Temp"
		.Close 
	End With 
	
	set oShell = WScript.CreateObject ("WScript.Shell")
	oShell.Popup "Установка отменена!", 3, "Информация", 4096
	
	set WshShell = WScript.CreateObject("WScript.Shell")  
	WshShell.Run "c:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd", 0, false    
