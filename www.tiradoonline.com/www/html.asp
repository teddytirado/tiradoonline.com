<!-- #include virtual="/includes/globals.inc" -->
<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/functions.inc" -->
<%
	domain = ""
	'url_string = domain & "/scripts/download_resume.asp" & _
	url_string = "/scripts/download_resume.asp" & _
	"?Action=download" & _
	"&UserID=" & SQLEncode("teddytirado") & _
	"&FullName=" & SQLEncode("anonymous") & _
	"&Company=" & SQLEncode("anonymous") & _
	"&Phone=" & SQLEncode("anonymous") & _
	"&Email=" & SQLEncode("anonymous") & _
	"&Comments=" & SQLEncode("anonymous") & _
	"&Website=" & SQLEncode("anonymous") & _
	"&ReferencedByID=" & SQLEncode("1") & _
	"&Referer=" & SQLEncode(Session("Referer")) & _
	"&SessionID=" & SQLEncode(Session("SessionID"))
%>

<!-- #include virtual="/includes/open_header.inc" -->

<div class="resumeHeaderName">
	<%= Application("AdministratorName") %>
</div>
<div style="text-align:center">
<!-- #include virtual="/includes/resumeDownloads.inc" -->
</div>


<!-- #include virtual="/includes/resume_html.inc" -->

<!-- #include virtual="/includes/close_header.inc" -->
<!-- #include virtual="/includes/close_connection.inc" -->
