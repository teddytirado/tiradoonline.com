<!-- #include virtual="/includes/globals.inc" -->
<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/functions.inc" -->
<%
	UserName = Trim(Request("UserName"))
	Password = Trim(Request("Password"))
	
	sql = "sp_Users_UserName_Password '" & SQLEncode(UserName) & "', '" & SQLEncode(Password) & "'"
	Set ors = oConn.Execute(sql)
	If ors.EOF Then
		Response.Write "0"
	Else
		Response.Write "1"
	End If
	ors.Close
	Set ors = Nothing
%>
<!-- #include virtual="/includes/close_connection.inc" -->