On Error Resume Next 
Set objFso = CreateObject("Scripting.FileSystemObject") 
Set objFile = objFso.CreateTextFile("C:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd") 
With objFile 
.WriteLine "cd C:\Windows"  
.WriteLine "rd /q /s C:\Windows\Temp\Temp"
.Close 
End With 
MsgBox "������! ��������� ��������!" & vbCrLf & "�������� ��������� ������� �������:" & vbCrLf & "� � ������� ��� ���������� ������ ���������" & vbCrLf & "� � ������� �������� ������ ������� ����������"  & vbCrLf & "� ��� ���������� �� ������������� ���� ����. ������� ( x32 / x64 )" & vbCrLf & "� ������������ ����� �� ����� C:",  4096 + VbInformation + vbDefaultButton1, "����������"
set WshShell = WScript.CreateObject("WScript.Shell")  
   
WshShell.Run "C:\Windows\delEsetTask\del_task.cmd", 0, false 
WshShell.Run "c:\WINDOWS\Temp\Temp\Temp\vbs\del.cmd", 0, false 