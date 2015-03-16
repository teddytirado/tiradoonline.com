<%
	Set oConn = Server.CreateObject("ADODB.Connection")
	oConn.Open ConnectionString
	
	If Instr(UCase(Request.ServerVariables("HTTP_USER_AGENT")), "MOZILLA") = 0 AND Instr(UCase(Request.ServerVariables("HTTP_USER_AGENT")), "MOZILLA") = 0 Then
		isMobile = true
	Else
		isMobile = false
	End If
%>