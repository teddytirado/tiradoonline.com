<!-- #include virtual="/includes/globals.inc" -->

<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/functions.inc" -->
<%
	On Error Resume Next
	Template = Trim(Request("Template"))
	If Template = "" Then Template = "coverletter.asp"
	'Session.Abandon
	
	'If Session("SessionID") = "" Then
		
		SessionID = Session.SessionID
		IPAddress = Request.ServerVariables("REMOTE_ADDR")
		Browser = Request.ServerVariables("HTTP_USER_AGENT")
		Referer = Trim(Request("Referer"))
		If Referer = "" Then 
			If Request.ServerVariables("HTTP_REFERER") <> "" Then
				Referer = Request.ServerVariables("HTTP_REFERER")
			Else
				Referer = "Email"
			End If
		End If
		
		sql = "sp_Sessions_insert " & _
			"'" & SQLEncode(SessionID) & "', " & _ 
			"'" & SQLEncode(SCRIPT_NAME) & "', " & _ 
			"'" & SQLEncode(Request.ServerVariables("SERVER_NAME")) & "', " & _ 
			"'" & SQLEncode(IPAddress) & "', " & _ 
			"'" & SQLEncode(Browser) & "', " & _ 
			"'" & SQLEncode(Referer) & "'"
		'Response.Write sql
		'Response.End			
		Set ors = oConn.Execute(sql)
		returnValue = ors.Fields(0).Value
		ors.Close
		Set ors = Nothing
		
		If CStr(returnValue) = "1" Then
			v_ToEmail = Application("AdministratorEmail")
			v_FromEmail = Application("AdministratorEmail")
			v_CC = ""
			v_Subject = "Someone has visited " & Request.ServerVariables("SERVER_NAME")
			v_BodyText = ""
			v_BodyText = v_BodyText & "Date/Time:<br>" & vbCrLF
			v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
			v_BodyText = v_BodyText & Now & "<br><br>" & vbCrLF & vbCrLF
			v_BodyText = v_BodyText & "SessionID:<br>" & vbCrLF
			v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
			v_BodyText = v_BodyText & SessionID & "<br><br>" & vbCrLF & vbCrLF
			v_BodyText = v_BodyText & "IP Address:<br>" & vbCrLF
			v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
			v_BodyText = v_BodyText & IPAddress & "<br><br>" & vbCrLF & vbCrLF
			v_BodyText = v_BodyText & "Browser:<br>" & vbCrLF
			v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
			v_BodyText = v_BodyText & Browser & "<br><br>" & vbCrLF & vbCrLF
			v_BodyText = v_BodyText & "Referer:<br>" & vbCrLF
			v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
			v_BodyText = v_BodyText & Referer & vbCrLF & vbCrLF
	
			v_isHTML = true
			
			SendEmail v_ToEmail, v_FromEmail, v_CC, v_Subject, v_BodyText, v_attachment, v_isHTML
	
			Session("SessionID") = SessionID	
			Session("Referer") = Referer	
		End If
	'End If


%>

<!-- #include virtual="/includes/open_header.inc" -->

	<%= TEDDY_PHOTO %>

	<div style="text-align: left">

		<%= GetResumeHTML() %>
		
		<div class="clearBoth"></div>
	
		<!-- #include virtual="/includes/resumeDownloads.inc" -->
	</div>

<!-- #include virtual="/includes/close_header.inc" -->
<!-- #include virtual="/includes/close_connection.inc" -->
