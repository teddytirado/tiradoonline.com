<%
	If JobCompanyID <> "" Then
	sql = "SELECT * FROM JobCompany WHERE JobCompanyID = " & JobCompanyID
	WriteDebugger sql, Debugging, 0
	Set ors = oConn.Execute(sql)
	JobCompanyName = ors("JobCompanyName")
	JobCompanyWebsite = ors("JobCompanyWebsite")
	JobCompanyLinkedIn = ors("JobCompanyLinkedIn")
	JobCompanyTwitter = ors("JobCompanyTwitter")
	JobCompanyFacebook = ors("JobCompanyFacebook")
	JobCompanyGooglePlus = ors("JobCompanyGooglePlus")
	JobCompanyYouTube = ors("JobCompanyYouTube")
	ors.Close
	Set ors = Nothing
	End If
%>
<table cellpadding="5" class"GridViewAlteringRows" width="100%">
<tr>
	<td class="JobsTheme">
		<b><a href="<%= SCRIPT_NAME %>?Template=company&JobCompanyID=<%= JobCompanyID %>">Company&nbsp;Information</a></b>&nbsp;&nbsp;
		<a href="<%= SCRIPT_NAME %>?Template=company">[&nbsp;New&nbsp;Company]</a>
		<% If JobCompanyID <> "" Then %>
		&nbsp;[&nbsp;<a href="<%= SCRIPT_NAME %>?Template=job_interview&JobCompanyID=<%= JobCompanyID %>">New&nbsp;Interview</a>&nbsp;]</b>
		<% End If %>
	</td>
</tr>
<tr class="GridViewRow">
	<td>
		<div><a href="<%= SCRIPT_NAME %>?Template=company&JobCompanyID=<%= JobCompanyID %>" title="<%= JobCompanyName %>"><%= JobCompanyName %></a></div>
		<% If JobCompanyWebsite <> "" Then %>
			<div><a href="http://<%= FormatWebsite(JobCompanyWebsite) %>" target="_blank"><%= JobCompanyWebsite %></a></div>
		<% End If %>
		<% If JobCompanyLinkedIn <> "" Then %>
			<a href="http://<%= FormatWebsite(JobCompanyLinkedIn) %>" target="_blank"><%= LINKEDIN_ICON %></a>&nbsp;&nbsp;
		<% End If %>
		<% If JobCompanyTwitter <> "" Then %>
			<a href="http://<%= FormatWebsite(JobCompanyTwitter) %>" target="_blank"><%= TWITTER_ICON %></a>&nbsp;&nbsp;
		<% End If %>
		<% If JobCompanyFacebook <> "" Then %>
			<a href="http://<%= FormatWebsite(JobCompanyFacebook) %>" target="_blank"><%= FACEBOOK_ICON %></a>&nbsp;&nbsp;
		<% End If %>
		<% If JobCompanyGooglePlus <> "" Then %>
			<a href="http://<%= FormatWebsite(JobCompanyGooglePlus) %>" target="_blank"><%= GOOGLEPLUS_ICON %></a>&nbsp;&nbsp;
		<% End If %>
		<% If JobCompanyYouTube <> "" Then %>
			<a href="http://<%= FormatWebsite(JobCompanyYouTube) %>" target="_blank"><%= YOUTUBE_ICON %></a>&nbsp;&nbsp;
		<% End If %>
	</td>
</tr>
</table>
