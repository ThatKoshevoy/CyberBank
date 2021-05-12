Set WshShell = CreateObject("WScript.Shell")
WshShell.Run chr(34) & "parse_news.exe" & Chr(34), 0
Set WshShell = Nothing