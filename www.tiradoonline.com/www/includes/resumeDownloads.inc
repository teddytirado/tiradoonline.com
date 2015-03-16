<%
	sql = "sp_ResumeDownloadType_UserID_get " & Session("UserID")
	'Response.Write sql
	'Response.End
	Set ors = oConn.Execute(sql)
	If Not ors.EOF Then
%>
	<table cellpadding="0" border="0" align="center" width="100%">
	<tr align="center">
	<%
			Do Until ors.EOF
				ResumeDownloadTypeID = ors("ResumeDownloadTypeID")
				ResumeDownloadTypeName = ors("ResumeDownloadTypeName")
				ResumeDownloadTypeName = Replace(ResumeDownloadTypeName, "w/", "<br>w/")
				ResumeDownloadTypeFileName = ors("ResumeDownloadTypeFileName")
				icon = "word"
				If Instr(ResumeDownloadTypeFileName, ".pdf") > 0 Then icon = "pdf"
				docURL = url_string & "&ResumeDownloadTypeID=" & ResumeDownloadTypeID & "&Attachment=" & Server.URLEncode(ResumeDownloadTypeFileName)
	%>
		<td class="iconImage" height="100" align="center">
			<div style="text-align:center">
			<a href="<%= docURL %>"><img src="http://<%= SERVER_NAME %>/images/icons/<%= icon %>.gif" /></a>
			<div class="clearBoth"></div>
			<%=  ResumeDownloadTypeName %>
			</div>
		</td>
	<%
				ors.MoveNext
			Loop
	%>
	</tr>
	</table>
	<%
			ors.Close
		End If
		Set ors = Nothing
	%>
