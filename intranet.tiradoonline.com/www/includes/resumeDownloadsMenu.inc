<%
	sql = "sp_ResumeDownloadType_UserID_get " & Session("UserID")
	'Response.Write sql
	'Response.End
	Set ors = oConn.Execute(sql)
	If Not ors.EOF Then
%>
	<ul class="dropdown">
	<%
			Do Until ors.EOF
				ResumeDownloadTypeID = ors("ResumeDownloadTypeID")
				ResumeDownloadTypeName = ors("ResumeDownloadTypeName")
				ResumeDownloadTypeFileName = ors("ResumeDownloadTypeFileName")
				icon = "word"
				If Instr(ResumeDownloadTypeFileName, ".pdf") > 0 Then icon = "pdf"
				docURL = url_string & "&ResumeDownloadTypeID=" & ResumeDownloadTypeID & "&Attachment=" & Server.URLEncode(ResumeDownloadTypeFileName)
	%>
		<li>
			<a href="<%= docURL %>"><img src="http://<%= SERVER_NAME %>/images/icons/<%= icon %>.gif" class="iconMenu" /></a>
			<a href="#"><%=  ResumeDownloadTypeName %></a>
		</li>
	<%
				ors.MoveNext
			Loop
	%>
	</ul>
	<%
			ors.Close
		End If
		Set ors = Nothing
	%>
