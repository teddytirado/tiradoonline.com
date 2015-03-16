<!-- #include virtual="/includes/globals.inc" -->
<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/functions.inc" -->
<%
	ImageSize = "100%"
	FolderName = Trim(Request("FolderName"))
	FolderName = Server.MapPath("/images/screenshots" & "/" & FolderName) 
	Set FileObj = Server.CreateObject("Scripting.FileSystemObject")
	Set FolderObj = FileObj.GetFolder(FolderName)
	Set colFiles = FolderObj.Files
	TotalFiles = FolderObj.Files.Count - 1
	Set FolderObj = Nothing
	Set FileObj = Nothing
	
	FolderName = "/images/screenshots" & "/" & Trim(Request("FolderName")) & "/"
	
	SessionID = Session.SessionID
	Session("ScreenShots") = SessionID
	IPAddress = Request.ServerVariables("REMOTE_ADDR")
	Browser = Request.ServerVariables("HTTP_USER_AGENT")
	Referer = Request.ServerVariables("HTTP_REFERER")
	If Referer = "" Then Referer = "Email"
	
	sql = "sp_Sessions_insert " & _
		"'" & SQLEncode(SessionID) & "', " & _ 
		"'" & SQLEncode(SCRIPT_NAME) & "', " & _ 
		"'" & SQLEncode(Request.ServerVariables("SERVER_NAME")) & "', " & _ 
		"'" & SQLEncode(IPAddress) & "', " & _ 
		"'" & SQLEncode(Browser) & "', " & _ 
		"'" & SQLEncode(Referer) & "'"

	Set ors = oConn.Execute(sql)
	returnValue = ors.Fields(0).Value
	ors.Close
	Set ors = Nothing
	
	If CStr(returnValue) = "1" Then
	
		v_ToEmail = Application("AdministratorEmail")
		v_FromEmail = Application("AdministratorEmail")
		v_CC = ""
		v_Subject = "Someone has viewed screen shots on " & SERVER_NAME
		
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
		
	End If
%>
<!-- #include virtual="/includes/open_header.inc" -->

<ul class="example-orbit" data-orbit width="100%" height="100%">
<% Counter = 1 %>
<% For Each objFile in colFiles %>
<li data-orbit-slide="headline-<%= Counter %>" data-options="animation_speed:500'">
    <img src="<%= FolderName %><%= objFile.Name %>" alt="Slide <%= Counter %>" />
</li>	
  <% Counter = Counter + 1 %>
<% Next %>
</ul>

<script type="text/javascript">
	$imageCounter = 1;
	$totalFiles = <%= TotalFiles %>;
	//$('#divCounter').html($imageCounter + '&nbsp;/&nbsp;<%= TotalFiles %>');

	$('#imgScreenShot').click
	(
		function()
		{
			window.open( $('#imgScreenShot').attr('src'));
		}
	);
</script>

<script>

    $(document).foundation('orbit', {
  timer_speed: 10000,
  pause_on_hover: true,
  resume_on_mouseout: true,
  animation_speed: 500,
  bullets: true,
  stack_on_small: true,
  container_class: 'orbit-container',
  stack_on_small_class: 'orbit-stack-on-small',
  next_class: 'orbit-next',
  prev_class: 'orbit-prev',
  timer_container_class: 'orbit-timer',
  timer_paused_class: 'paused',
  timer_progress_class: 'orbit-progress',
  slides_container_class: 'orbit-slides-container',
  bullets_container_class: 'orbit-bullets',
  bullets_active_class: 'active',
  slide_number_class: 'orbit-slide-number',
  caption_class: 'orbit-caption',
  active_slide_class: 'active',
  orbit_transition_class: 'orbit-transitioning'
});

</script>
<!-- #include virtual="/includes/close_header.inc" -->
<!-- #include virtual="/includes/close_connection.inc" -->
