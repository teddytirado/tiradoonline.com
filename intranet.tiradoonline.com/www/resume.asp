<!-- #include virtual="/includes/globals.inc" -->
<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/functions.inc" -->

<%
	Email = Trim(Request("Email"))
	
	If SubmitButton = "Send Resume" Then
		v_ToEmail = Email
		v_FromEmail = Application("AdministratorEmail")
		v_CC = Application("AdministratorEmail")
		v_Subject = "Resume - Theodore Tirado"
		v_attachment = Server.MapPath("/resumes") & "\Theodore_Tirado_Resume_with_Cover_Letter.pdf"
		BodyText = GetResumeHTML()

		
		v_BodyText = "<html><head><body>" & BodyText & "</body></head></html>"

		SendEmail v_ToEmail, v_FromEmail, v_CC, v_Subject, v_BodyText, v_attachment, v_isHTML
		
		ErrorMessage = Server.URLEncode("Resume sent to " & Email & " and " & Application("AdministratorEmail"))
				
		Response.Redirect SCRIPT_NAME & "?ErrorMessage=" & ErrorMessage
	End If	
%>

<!-- #include virtual="/includes/open_header.inc" -->

<form action="<%= SCRIPT_NAME %>" method="post" id="formSendResume" name="formSendResume">
<%
	If ErrorMessage <> "" Then 
%>
	<div class="ErrorMessage"><%= ErrorMessage %></div>
	&nbsp;<br>
<%
	End If
%>

<table border="0" width="100%">
<tr valign="top">
	<td width="100%">
		<div id="divErrorMessage" name="divErrorMessage" class="ErrorMessage"></div>
		<label for="Email">Email:&nbsp;<%= REQUIRED_ICON %></label>
		<input type="text" id="Email" name="Email" />
		<input type="submit" id="SubmitButton" name="SubmitButton" value="Send Resume" />

	</td>
</tr>
</table>

</form>

<script type="text/javascript">

	$('#formSendResume').submit
	(
		function(evt)
		{
			var $Email = $('#Email');
			
			if ( $Email.val() == '' || !isEmail($Email.val()) )
			{
				showError($('#divErrorMessage'), "Invalid Email");
				return false;
			}
			
			return true;
		}
	);

</script>


<!-- #include virtual="/includes/close_header.inc" -->
<!-- #include virtual="/includes/close_connection.inc" -->

