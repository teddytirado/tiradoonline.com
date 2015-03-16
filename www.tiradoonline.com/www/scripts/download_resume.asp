<!-- #include virtual="/includes/globals.inc" -->
<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/functions.inc" -->
<%
	Action					= Trim(Request("Action"))
	FullName				= Trim(Request("FullName"))
    Company					= Trim(Request("Company"))
	Phone					= Trim(Request("Phone"))
    Email					= Trim(Request("Email"))
    Comments				= Trim(Request("Comments"))
    Website					= Trim(Request("Website"))
	ReferencedByID			= Trim(Request("ReferencedByID"))
    ResumeDownloadTypeID	= Trim(Request("ResumeDownloadTypeID"))
    Referer					= Trim(Request("Referer"))
	SessionID				= Trim(Request("SessionID"))
	Attachment		    	= Trim(Request("Attachment"))
	If Referer = "" Then Referer = Request.ServerVariables("HTTP_REFERER")

	'Response.End	
	sql = "sp_ResumeDownloads_insert " & _
			"'" & SQLEncode(FullName)& "', " & _
    		"'" & SQLEncode(Company)& "', " & _
			"'" & SQLEncode(Phone)& "', " & _
    		"'" & SQLEncode(Email)& "', " & _
    		"'" & SQLEncode(Comments)& "', " & _
    		"'" & SQLEncode(Website)& "', " & _
			SQLEncode(ReferencedByID)& ", " & _
    		SQLEncode(ResumeDownloadTypeID)& ", " & _
    		"'" & SQLEncode(Referer)& "', " & _
    		"'" & SQLEncode(SessionID)& "'"
		'Response.Write sql
		'Response.End			
	Set ors = oConn.Execute(sql)
	Attachment = ors.Fields(0).Value

	v_ToEmail = Session("AdministratorEmail")
	v_FromEmail = Session("AdministratorEmail")
	v_CC = ""
	v_Subject = "Someone has downloaded your resume from " & Request.ServerVariables("SERVER_NAME")
	v_attachment = Server.MapPath("/resumes/") & "\" & Attachment
	
	v_BodyText = ""
	v_BodyText = v_BodyText & "Date/Time:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Now & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Name:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & FullName & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Company:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Company & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Phone:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Phone & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Email:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Email & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Comments:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Comments & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Website:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Website & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "ReferencedByID:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & ReferencedByID & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "ResumeDownloadTypeID:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & ResumeDownloadTypeID & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Referer:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Referer & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Session:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & SessionID & "<br><br>" & vbCrLF & vbCrLF

	v_BodyText = v_BodyText & "Attachment:<br>" & vbCrLF
	v_BodyText = v_BodyText & "----------------------------------------<br>" & vbCrLF
	v_BodyText = v_BodyText & Attachment & vbCrLF & vbCrLF
	v_isHTML = true
		
	SendEmail v_ToEmail, v_FromEmail, v_CC, v_Subject, v_BodyText, v_attachment, v_isHTML

	Response.Write "1"
	
	If Action = "download" Then
		Response.Redirect "/resumes/" & Attachment
	End If
	
%>
<!-- #include virtual="/includes/close_connection.inc" -->
