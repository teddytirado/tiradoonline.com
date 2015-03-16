<% If UCase(Request.ServerVariables("REQUEST_METHOD")) = "POST" Then %>

<!-- #include virtual="/includes/globals.inc" -->
<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/functions.inc" -->
<%
	On Error Resume Next
	EmailFromEmail				= Trim(Request("EmailFromEmail"))
	BodyText				= Trim(Request("BodyText"))

	'Response.End	
	sql = "sp_WebsiteEmail_insert " & _
			Session("UserID") & ", " & _
			"'" & SQLEncode(EmailFromEmail)& "', " & _
    		"'" & SQLEncode(BodyText)& "'"
	oConn.Execute sql

	v_ToEmail = Application("AdministratorEmail")
	v_EmailFromEmail = Application("AdministratorEmail")
	v_Subject = EmailFromEmail & " has sent you an Email from " & Request.ServerVariables("SERVER_NAME")
	
	v_BodyText = ""
	v_BodyText = v_BodyText & "Date/Time:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Now & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "From Email:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & EmailFromEmail & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Email Message:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & BodyText & "<br><br>" & vbCrLF & vbCrLF

	v_isHTML = true
		
	
	If Err.Number = 0 AND oConn.Errors.Count = 0 Then	

		SendEmail v_ToEmail, v_EmailFromEmail, v_CC, v_Subject, v_BodyText, v_attachment, v_isHTML

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