<%
	Function GetResumeHTML()
		sql = "select jobcoverlettertext from jobcoverletter where jobcoverletterid = 1004"
		Set ors = oConn.Execute(sql)
		BodyText = ors.Fields(0).Value
		ors.Close
		Set ors = Nothing
		
		GetResumeHTML = BodyText
	End Function
	
	Function ReadFile(FileName)
		Set ReadFileObj = CreateObject("Scripting.FileSystemObject")

		Set InStream = ReadFileObj.OpenTextFile(FileName)
		FileContents = Trim(Instream.ReadAll)
		InStream.Close
		Set InStream = Nothing
			Set ReadFileObj = Nothing
		ReadFile = FileContents
	End Function
	
	Function SelectBox(connection, sqlString, SelectBoxName, SelectBoxValue, cssClass)
		x_str = ""
		x_str = x_str & "<select id=""" & SelectBoxName & """ name=""" & SelectBoxName & """ class=""" & cssClass & """>" & vbCrLF
	
		Set ors_Select = connection.Execute(sqlString)
		If isNull(SelectBoxValue) Then SelectBoxValue = ""
		If NOT ors_Select.EOF Then
			Do Until ors_Select.EOF
				'Response.Write Trim(CStr(SelectBoxValue)) & "=" & Trim(CStr(ors_Select.Fields(0).Value)) & "<br>"
				If Trim(CStr(SelectBoxValue)) = Trim(CStr(ors_Select.Fields(0).Value)) Then
					x_str = x_str & "<option value=""" & ors_Select.Fields(0).Value & """ SELECTED>" & ors_Select.Fields(1).Value & "</option>" & vbCrLF
				Else
					x_str = x_str & "<option value=""" & ors_Select.Fields(0).Value & """>" & ors_Select.Fields(1).Value & "</option>" & vbCrLF
				End If
				ors_Select.MoveNext
			Loop
			ors_Select.Close
		End If
	
		Set ors_Select = Nothing
	
		x_str = x_str & "</select>"
		SelectBox = x_str
	End Function

	Sub SendEmail(v_ToEmail, v_FromEmail, v_CC, v_Subject, v_BodyText, v_attachment, v_isHTML)
		'If UCase(Request.ServerVariables("SERVER_NAME")) <> "local.www.tiradoonline.com" Then
			Const cdoSendUsingPickup = 1 'Send message using the local SMTP service pickup directory.
			Const cdoSendUsingPort = 2 'Send the message using the network (SMTP over the network).

			Const cdoAnonymous = 0 'Do not authenticate
			Const cdoBasic = 1 'basic (clear-text) authentication
			Const cdoNTLM = 2 'NTLM

			Set myMail = Server.CreateObject("CDO.Message")
		
			myMail.Subject = v_Subject
			myMail.From = v_FromEmail
			myMail.To = v_ToEmail

			If v_CC <> "" OR v_CC <> null Then 
				myMail.Cc = v_CC
			End If
			
			If v_attachment <> "" Then
				myMail.AddAttachment v_attachment
			End If
			
			myMail.HTMLBody = v_BodyText

			myMail.Configuration.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusing") = cdoSendUsingPort

			'Name or IP of remote SMTP server
			myMail.Configuration.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "smtp.tiradoonline.com"

			'Server port
			myMail.Configuration.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = "587"
	
			'Type of authentication, NONE, Basic (Base64 encoded), NTLM
			myMail.Configuration.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = cdoBasic

			'Your UserID on the SMTP server
			myMail.Configuration.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "teddy@tiradoonline.com"

			'Your password on the SMTP server
			myMail.Configuration.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "sixpak141414"
		
			myMail.Configuration.Fields.Update

			On Error Resume Next 
	 		myMail.Send
		
			set myMail = Nothing
		'End If
	End Sub

	Function SQLEncode(v_sql)
		SQLEncode = Replace(v_sql, "'", "''")
	End Function


	Function ValidateZipCode(v_City, v_ZipCode)
		sql = sp_ZipCode_Validate_get " & _
		      "'" & SQLEncode(v_City) & "', " & _
		      "'" & SQLEncode(v_State) & "', " & _
		      "'" & SQLEncode(v_ZipCode) & "', " & _
		Set ors = oConn.Execute(sql)
		If ors.EOF Then
			ValidateZipCode = false
		Else
			ValidateZipCode = true
		End If
	End Function
%>