<!-- #include virtual="/includes/login.inc" -->
<!-- #include virtual="/includes/globals.inc" -->

<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/page_logs.inc" -->

<!-- #include virtual="/includes/functions.inc" -->
<%
	MoviesDirectory = SettingsDirectory("MoviesDirectory")
	If isNull(MoviesDirectory) Then MoviesDirectory = ""
	DirectoryExists = true
	Set objFileSystem = CreateObject("Scripting.FileSystemObject")
   	If NOT objFileSystem.FolderExists(MoviesDirectory) Then 
		MusicErrorMessage = MusicErrorMessage & "Music Directory does not exist."
		DirectoryExists = false
	End If
	Set objFileSystem = Nothing
	
	If NOT DirectoryExists Then Response.Redirect "/settings/settings.asp?Template=settings&MusicErrorMessage=" & Server.URLEncode(MusicErrorMessage)
	PageTheme = "musicTheme"
	PageThemeColor = MUSIC_THEME
	PageTitle = "Music"
	HeaderTitle = "Music"
	Response.Buffer = true
%>
<!-- #include virtual = "/includes/upload.inc" -->

<%
    Set Upload = New FreeASPUpload
	'Response.Write "Session(""MusicDirectory""):&nbsp;" & Session("MusicDirectory")
   	Upload.Save(Session("MusicDirectory"))
	Set Upload = Nothing

	If InStr(Request.ServerVariables("HTTP_CONTENT_TYPE"), "multipart/form-data") > 0 Then
		MusicErrorMessage = Server.URLEncode("Music Uploaded created.")
		Response.Redirect SCRIPT_NAME & "?MusicErrorMessage=" & MusicErrorMessage & "&CurrentDirectory="&  Server.URLEncode(Session("MusicDirectory"))
	End If
%>
<%
	If Request.ServerVariables("REQUEST_METHOD") = "POST" Then 
		CurrentDirectory = Trim(Request("PostCurrentDirectory"))
	Else
		CurrentDirectory = Trim(Request("CurrentDirectory"))
	End If
	If CurrentDirectory = "" Then 
		sql = "sp_Settings_get " & Session("UserID")
		Set ors = oConn.Execute(sql)
		If NOT ors.EOF Then
			CurrentDirectory = ors("MusicDirectory")
			ors.Close
		End If
		Set ors = Nothing
	End If
	
	If SubmitButton = "ChangeDirectory" Then
		If Request.ServerVariables("REQUEST_METHOD") = "POST" Then 
			CurrentDirectory = Trim(Request("PostCurrentDirectory"))
		Else
			CurrentDirectory = Trim(Request("CurrentDirectory"))
		End If
		If CurrentDirectory = "" Then CurrentDirectory = Music_Directory
		Session("MusicDirectory") = CurrentDirectory
		Response.Redirect SCRIPT_NAME & "?CurrentDirectory="&  Server.URLEncode(CurrentDirectory)
	ElseIf SubmitButton = "CreateFolder" Then
		FolderCreate CurrentDirectory
		MusicErrorMessage = Server.URLEncode("Folder created.")
		Response.Redirect SCRIPT_NAME & "?MusicErrorMessage=" & MusicErrorMessage & "&CurrentDirectory="&  Server.URLEncode(CurrentDirectory)
	ElseIf SubmitButton = "Upload File" Then
		'Response.Write "<b>" & CurrentDirectory & "\" & FileName & "&nbsp;uploaded.</b><p>"
	End If

%>
<!-- #include virtual="/includes/open_header.inc" -->
<%
	If Session("MusicDirectory") = "" Then Session("MusicDirectory") = Music_Directory
%>

				<% If Template = "" Then %>
				<!-- #include file="templates/home.tem" -->
				<% ElseIf Template = "player" Then %>
				<!-- #include file="templates/player.tem" -->
				<% End If %>

<input type="hidden" id="PostCurrentDirectory" name="PostCurrentDirectory" value="<%= CurrentDirectory %>" />
<!-- #include virtual="/includes/jquery.inc" -->
<!-- #include virtual="/includes/close_header.inc" -->
<!-- #include virtual="/includes/close_connection.inc" -->
