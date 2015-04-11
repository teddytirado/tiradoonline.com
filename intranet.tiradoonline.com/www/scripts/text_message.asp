<% If UCase(Request.ServerVariables("REQUEST_METHOD")) = "POST" Then %>

<!-- #include virtual="/includes/globals.inc" -->
<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/functions.inc" -->
<%
	On Error Resume Next
	FromEmail				= Trim(Request("FromEmail"))
	TextMessage				= Trim(Request("TextMessage"))

	'Response.End	
	sql = "sp_TextMessage_insert " & _
			Session("UserID") & ", " & _
			"'" & SQLEncode(FromEmail)& "', " & _
    		"'" & SQLEncode(TextMessage)& "'"
	oConn.Execute sql

	v_ToEmail = Application("AdministratorEmail")
	v_FromEmail = FromEmail
	v_Subject = FromEmail & " has sent you a Text Message from " & Request.ServerVariables("SERVER_NAME")
	
	v_BodyText = ""
	v_BodyText = v_BodyText & "Date/Time:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Now & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "From Email:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & FromEmail & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Text Message:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & TextMessage & "<br><br>" & vbCrLF & vbCrLF

	v_isHTML = true
		
	
	If Err.Number = 0 AND oConn.Errors.Count = 0 Then	
		SendEmail v_ToEmail, v_FromEmail, v_CC, v_Subject, v_BodyText, v_attachment, v_isHTML

		v_ToEmail = Application("TextMessageEmail")
		v_CC = ""
		v_BodyText = TextMessage
		SendEmail v_ToEmail, v_FromEmail, v_CC, v_Subject, v_BodyText, v_attachment, v_isHTML

		Response.Write "1"
	Else
		For x = 0 to oConn.Errors.Count 
			Response.Write "ADODB Error: " & oConn.Errors(x).Description & "<br>"
		Next
		Response.Write "<p>ASP Error: " & Err.Description & "<br>"
	End If
%>
<!-- #include virtual="/includes/close_connection.inc" -->


<% End If %>