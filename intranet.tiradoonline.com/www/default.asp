<!-- #include virtual="/includes/login.inc" -->
<!-- #include virtual="/includes/globals.inc" -->

<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/page_logs.inc" -->

<!-- #include virtual="/includes/functions.inc" -->
<!-- <h1>Days of Sobriety: <%= DateDiff("d", "11/14/13", Date) %></h1> -->
<%
	Response.ExpiresAbsolute = Date - 1
	PageThemeColor = Application("ThemeColor")
	If Session("UserID") = "" Then UserID = Session("DefaultUserID")	
	Title = "tiradoonline.com login"

	LoginErrorMessage = Trim(Request("LoginErrorMessage"))
	ForgotPasswordErrorMessage = Trim(Request("ForgotPasswordErrorMessage"))
	CreateAccountErrorMessage = Trim(Request("CreateAccountErrorMessage"))
	
	CreateAccountUserName = Trim(Request("CreateAccountUserName"))
	LoginUserName = Trim(Request("LoginUserName"))
	
	CreateAccountPassword = Trim(Request("CreateAccountPassword"))
	CreateAccountConfirmPassword = Trim(Request("CreateAccountConfirmPassword"))
	LoginPassword = Trim(Request("LoginPassword"))

	ForgotPassword_Email = Trim(Request("ForgotPassword_Email"))
	CreateAccount_Email = Trim(Request("CreateAccount_Email"))
	Email = Trim(Request("Email"))

	CreateAccountFirstName = Trim(Request("CreateAccountFirstName"))
	CreateAccountLastName = Trim(Request("CreateAccountLastName"))

	SelectedTab = Trim(Request("SelectedTab"))
	If SelectedTab = "" Then SelectedTab = "0"

	Administrator = Trim(Request("Administrator"))
	If Administrator = "" Then Administrator = "0"
	Email = Trim(Request("Email"))
	MobileEmail = Trim(Request("MobileEmail"))

	Contacts = Trim(Request("Contacts"))
	If Contacts = "" Then Contacts = "0"

	Documents = Trim(Request("Documents"))
	If Documents = "" Then Documents = "0"

	PersonalInformation = Trim(Request("PersonalInformation"))
	If PersonalInformation = "" Then PersonalInformation = "0"

	Banking = Trim(Request("Banking"))
	If Banking = "" Then Banking = "0"

	CreditCards = Trim(Request("CreditCards"))
	If CreditCards = "" Then CreditCards = "0"

	Photos = Trim(Request("Photos"))
	If Photos = "" Then Photos = "0"

	Music = Trim(Request("Music"))
	If Music = "" Then Music = "0"

	MovieCollection = Trim(Request("MovieCollection"))
	If MovieCollection = "" Then MovieCollection = "0"

	Movies = Trim(Request("Movies"))
	If Movies = "" Then Movies = "0"

	Snippets = Trim(Request("Snippets"))
	If Snippets = "" Then Snippets = "0"

	Health = Trim(Request("Health"))
	If Health = "" Then Health = "0"

	Jobs = Trim(Request("Jobs"))
	If Jobs = "" Then Jobs = "0"

	Recovery = Trim(Request("Recovery"))
	If Recovery = "" Then Recovery = "0"

	Notes = Trim(Request("Notes"))
	If Notes = "" Then Notes = "0"

	Timesheet = Trim(Request("Timesheet"))
	If Timesheet = "" Then Timesheet = "0"

	Notes = Trim(Request("Notes"))
	If Notes = "" Then Notes = "0"

	tiradoonline = Trim(Request("tiradoonline"))
	If tiradooline = "" Then tiradoonline = "0"

	If SubmitButton = "" Then
		LoginUserName = Request.Cookies("LoginUserName")
	End If
	
	If SubmitButton = "Logout" Then
		oConn.Close
		Set oConn = Nothing
		Session.Abandon
		Response.Redirect SCRIPT_NAME
	End If
		
	If SubmitButton = "Login" OR SubmitButton = "LoginAs" Then
		If Trim(Request("UserID")) <> "" Then
			sql = "SELECT * FROM Users WHERE UserID = " & Trim(Request("UserID"))
			WriteDebugger sql, Debugging, 0
			Set ors = oConn.Execute(sql)
			If NOT ors.EOF Then
				LoginUserName = ors("UserName")
				LoginPassword = ors("Password")
				Response.Cookies("LoginUserName") = ""
				Response.Cookies("LoginPassword") = ""
				ors.Close
			End If
			Set ors = Nothing
		End If
		
		
    	sql = "SELECT * FROM Users WHERE UserName='" & SQLEncode(LoginUserName) & "' AND Password = '" & SQLEncode(LoginPassword) & "' AND Active = 1"
		WriteDebugger sql, Debugging, 0
		Set ors = oConn.Execute(sql)

		Session("Administrator") = null
		If ors.EOF Then
			LoginErrorMessage = "Invalid Login"
			sql = "sp_Logs_insert '" & Request.ServerVariables("SERVER_NAME") & "', 'INVALID LOGIN - USERNAME: " & LoginUserName & ", PASSWORD: " & LoginPassword  & ", IP: " & Request.ServerVariables("REMOTE_ADDR") & ", BROWSER: " & Request.ServerVariables("HTTP_USER_AGENT") & "'"
			WriteDebugger sql, Debugging, 0
			oConn.Execute sql
			
		Else
			Session("LoginUserID") = ""
			UserID = ors("UserID")
			Email = ors("Email")
			Administrator = ors("Administrator")
			Contacts = ors("Contacts")
			PersonalInformation = ors("PersonalInformation")
			Banking = ors("Banking")
			Documents = ors("Documents")
			CreditCards = ors("CreditCards")
			Photos = ors("Photos")
			Music = ors("Music")
			MovieCollection = ors("MovieCollection")
			Movies = ors("Movies")
			Snippets = ors("Snippets")
			Health = ors("Health")
			Jobs = ors("Jobs")
			Recovery = ors("Recovery")
			Timesheet = ors("Timesheet")
			Notes = ors("Notes")
			tiradoonline = ors("tiradoonline")

			Session("Email") = Email
			Session("UserName") = UserName
			Session("UserID") = UserID
			Session("Administrator") = Administrator
			Session("FullName") = ors("FirstName") & " " & ors("LastName")
			Session("Contacts") = Contacts
			Session("PersonalInformation") = PersonalInformation
			Session("Banking") = Banking
			Session("Documents") = Documents
			Session("CreditCards") = CreditCards
			Session("Photos") = Photos
			Session("Music") = Music
			Session("MovieCollection") = MovieCollection
			Session("Movies") = Movies
			Session("Snippets") = Snippets
			Session("Health") = Health
			Session("Jobs") = Jobs
			Session("Recovery") = Recovery
			Session("Timesheet") = Timesheet
			Session("Notes") = Notes
			Session("tiradoonline") = tiradoonline

			'Response.Cookies("LoginPassword") = LoginPassword
			'Response.Cookies("LoginPassword").Expires = Date + 1
			
			If PreviousPage = "" Then
				Response.Cookies("LoginUserName") = LoginUserName
				Response.Cookies("LoginUserName").Expires = Date + 30
				Session("Administrator") = Administrator
			End If

			sql = "sp_Logins_insert " & _
				  UserID & ", " & _
				  "'" & Request.ServerVariables("HTTP_USER_AGENT") & "', " & _
				  "'" & Request.ServerVariables("REMOTE_ADDR") & "'"
			WriteDebugger sql, Debugging, 0
			oConn.Execute sql
    	    isMobile = false
		    if Request.ServerVariables("http_x_wap_profile") <> "" then isMobile = true
		    
			'If isMobile Then
			'    Session("isMobile") = true
			'	Response.Redirect "/mobile"
			'Else
				sql = "sp_Settings_get " & UserID
				Set ors = oConn.Execute(sql)
				If NOT ors.EOF Then
					vPreviousPage = ors("PreviousPage")
					ors.Close
				End If
				Set ors = Nothing
				
				'Response.Write InStr(UCase(vPreviousPage), "DEFAULT.ASP")
				If vPreviousPage <> "" AND NOT isNull(vPreviousPage) AND InStr(UCase(vPreviousPage), "DEFAULT.ASP") < 1 Then
				'If vPreviousPage <> "" AND NOT isNull(vPreviousPage) Then
					RedirectURL = vPreviousPage
				Else
					RedirectURL = "/home.asp?ErrorMessage=" & Server.URLEncode(ErrorMessage)
				End If
				
				subject = LoginUserName & " has logged in"
				If UCase(LoginUserName) <> "TEDDY" Then 
					SendEmail Application("AdministratorEmail"), Application("AdministratorEmail"), "", subject, subject & "<br>" & Request.ServerVariables("HTTP_USER_AGENT"), true
				End If

				Response.Redirect RedirectURL
				'Response.Redirect "users/users.asp?Login=yes&UserID=" & UserID & "&Action=Edit"
			'End If
			
		End If
	ElseIf SubmitButton = "Forgot Password" Then
    	sql = "SELECT * FROM Users WHERE Email='" & SQLEncode(ForgotPassword_Email) & "' AND Active = 1"
		WriteDebugger sql, Debugging, 0
		Set ors = oConn.Execute(sql)

		If ors.EOF Then
			ForgotPasswordErrorMessage = "Email Address: '" & ForgotPassword_Email & "' not found."
			sql = "sp_Logs_insert '" & Request.ServerVariables("SERVER_NAME") & "', '" & SQLEncode(Email) & "'"
			WriteDebugger sql, Debugging, 0
			oConn.Execute sql
		Else
			v_UserName = ors("UserName")
			v_Password = ors("Password")
			
			sql = "sp_Settings_get " & Session("DefaultUserID")
			WriteDebugger sql, Debugging, 0
			Set orsSettings = oConn.Execute(sql)
			If NOT orsSettings.EOF Then
				AdministratorEmail = orsSettings("AdministratorEmail")
				orsSettings.Close
			End If
			Set orsSettings = Nothing
			
			sql = "sp_EmailTemplates_get " & Session("DefaultUserID")
			WriteDebugger sql, Debugging, 0
			Set ors = oConn.Execute(sql)
			If NOT ors.EOF Then
				Subject = ors("ForgotPasswordSubject")
				BodyText = ors("ForgotPasswordEmail")
				BodyText = Replace(BodyText, "###USERNAME###", v_UserName)
				BodyText = Replace(BodyText, "###PASSWORD###", v_Password)
				BodyText = "<pre>" & BodyText & "</pre>"
				ors.Close
			End If
			Set ors = Nothing

			SendEmail ForgotPassword_Email, AdministratorEmail, AdministratorEmail, Subject, BodyText, 1
			ErrorMessage = "Login information emailed to: '" & ForgotPassword_Email & "'"
			
			Response.Redirect SCRIPT_NAME & "?LoginErrorMessage=" & Server.URLEncode(ErrorMessage)
			
			ors.Close
		End If
		Set ors = Nothing
	ElseIf SubmitButton = "Create Account" Then
		AccountExists = false

    	sql = "SELECT * FROM Users WHERE UserName='" & SQLEncode(CreateAccountUserName) & "'"
		WriteDebugger sql, Debugging, 0
		Set ors = oConn.Execute(sql)

		If ors.EOF Then
	    	sql = "SELECT * FROM Users WHERE Email='" & SQLEncode(CreateAccount_Email) & "'"
			WriteDebugger sql, Debugging, 0
			Set ors2 = oConn.Execute(sql)
			If NOT ors2.EOF Then
				CreateAccountErrorMessage = "Email: '" & CreateAccount_Email & "' exists."
				ors2.Close
				AccountExists = true
				CreateAccount_Email = ""
			End If
			Set ors2 = Nothing
		Else
			ors.Close
			CreateAccountErrorMessage = "Username: '" & CreateAccountUserName & "' exists."
			AccountExists = true
			CreateAccountUserName = ""
		End If
		Set ors = Nothing
		
		If NOT AccountExists Then
			sql = "sp_Users_insert " & _
					"'" & CreateAccountUserName & "', " & _
					"'" & CreateAccountPassword & "', " & _
					"'" & CreateAccountFirstName & "', " & _
					"'" & CreateAccountLastName & "', " & _
					"'" & CreateAccount_Email & "', " & _
					"'" & MobileEmail & "', " & _
					Administrator & ", " & _
					"1, " & _ 
					"1, " & _ 
					Documents & ", " & _ 
					"1, " & _ 
					"1, " & _ 
					Photos & ", " & _ 
					Music & ", " & _ 
					MovieCollection & ", " & _ 
					Movies & ", " & _ 
					"1, " & _ 
					"1, " & _ 
					"1, " & _ 
					Recovery & ", " & _ 
					"1, " & _ 
					Notes & ", " & _ 
					tiradoonline
			WriteDebugger sql, Debugging, 0
			Set ors = oConn.Execute(sql)
			If NOT ors.EOF Then
				UserID = ors("UserID")
				ors.Close
			End If
			Set ors = Nothing

			sql = "sp_Settings_get " & Session("DefaultUserID")
			WriteDebugger sql, Debugging, 0
			Set orsSettings = oConn.Execute(sql)
			If NOT orsSettings.EOF Then
				AdministratorEmail = orsSettings("AdministratorEmail")
				orsSettings.Close
			End If
			Set orsSettings = Nothing
			
			sql = "sp_EmailTemplates_get " & Session("DefaultUserID")
			WriteDebugger sql, Debugging, 0
			Set ors = oConn.Execute(sql)
			If NOT ors.EOF Then
				Subject = ors("CreateAccountSubject")
				BodyText = ors("CreateAccountEmail")
				BodyText = Replace(BodyText, "###FIRSTNAME###", CreateAccountFirstName)
				BodyText = Replace(BodyText, "###LASTNAME###", CreateAccountLastName)
				BodyText = Replace(BodyText, "###USERNAME###", CreateAccountUserName)
				BodyText = Replace(BodyText, "###PASSWORD###", CreateAccountPassword)
				BodyText = "<pre>" & BodyText & "</pre>"
				ors.Close
			End If
			Set ors = Nothing
			'Response.Write BodyText
			SendEmail CreateAccount_Email, AdministratorEmail, AdministratorEmail, Subject, BodyText, 1
			ErrorMessage = "Account created."
			RedirectURL = SCRIPT_NAME & "?SubmitButton=Login&LoginUserName=" & Server.URLEncode(CreateAccountUserName) & "&LoginPassword=" & Server.URLEncode(CreateAccountPassword) & "&ErrorMessage=" & Server.URLEncode(ErrorMessage)
			Response.Redirect RedirectURL
		Else
			SelectedTab = 2
		End If
	End If
%>
<html>
<head>
    <title><%= Title %></title>
	<link rel="icon" type="image/ico" href="/images/icons/logo.ico" /> 
	<link rel="shortcut icon" href="/images/icons/logo.ico" />
	<!-- #include virtual="/includes/css/global.css" -->
	<link href="/includes/jquery/themes/base/jquery-ui.css" rel="stylesheet">
	<script src="/includes/jquery/jquery.js"></script>
	<script src="/includes/jquery/ui/jquery-ui.js"></script>
	<!-- #include virtual="/includes/js/functions.js" -->
</head>

<body>
	
<div id="LoginBoxLogin" class="shadow">
<table cellspacing=0 cellpadding=3 bgcolor="<%= Application("ThemeColor") %>" border="0" width="650">
<tr>
	<td>
		<table cellspacing=0 cellpadding=2 border=0 bgcolor=#ffffff width="100%">
		<tr>
			<td colspan="2" bgcolor="<%= Application("ThemeColor") %>" align=center>&nbsp;&nbsp;&nbsp;<font color=#ffffff face="Verdana"><b><%= UCase(Title) %></b></font>&nbsp;&nbsp;&nbsp;</td>
		</tr>
		<tr>
			<td>
				<%= LOGO %>
			</td>
			<td align=center valign="middle">
				<div id="tabs">
					<ul>
						<li><a href="#tabs-1" title="Login">Login</a></li>
						<li><a href="#tabs-2" title="Forgot&nbsp;Password">Forgot&nbsp;Password</a></li>
						<li><a href="#tabs-3" title="Create&nbsp;Account">Create&nbsp;Account</a></li>
					</ul>
					
					<!--
					**********************************
					LOGIN
					**********************************
					-->
					<div id="tabs-1" name="tabs-1">
					<p>

						&nbsp;<br />
						&nbsp;<br />
						<form action="<%= SCRIPT_NAME %>" method="post" id="formLogin" name="formLogin">
						<table cellspacing=0 cellpadding=3 border=0 width="100%" style="float:left">
						<tr>
							<td>&nbsp;</td>
							<td class="ErrorMessage"><div id="LoginErrorMessage" name="LoginErrorMessage"><%= LoginErrorMessage %></div></td>
						</tr>
						<tr>
							<td align="right"><b>Username:</td>
							<td>
								<%= formTextBox("LoginUserName", "20", LoginUserName, "HomeElement", "Username", "Invalid Username") %>
								<%= REQUIRED_ICON %>
							</td>
						</tr>
						<tr>
							<td align="right"><b>Password:</td>
							<td>
								<%= formPassword("LoginPassword", "20", LoginPassword, "HomeElement", "Password", "Invalid Password") %>
								<%= REQUIRED_ICON %>
							</td>
						</tr>
						<tr>
							<td>&nbsp;&nbsp;</td>
							<td>&nbsp;<br />
								<%= Submit_Button("SubmitButton", "Login", "Button", "", "Login") %>
							</td>
						</tr>
						</table>
						<input type="hidden" id="SelectedTab" name="SelectedTab" value="0" />
						</form>
					</p>
					</div>


					<!--
					**********************************
					FORGOT PASSWORD
					**********************************
					-->
					<div id="tabs-2" name="tabs-2">
					<p>
						&nbsp;<br />
						&nbsp;<br />
						<form action="<%= SCRIPT_NAME %>" method="post" id="formForgotPassword" name="formForgotPassword">
						<table cellspacing=0 cellpadding=3 border=0 width="100%" style="float:left">
						<tr>
							<td>&nbsp;</td>
							<td class="ErrorMessage"><div id="ForgotPasswordErrorMessage" name="ForgotPasswordErrorMessage"><%= ForgotPasswordErrorMessage %></div></td>
						</tr>
						<tr>
							<td align="right"><b>Email&nbsp;Address:</td>
							<td>
								<%= formTextBox("ForgotPassword_Email", "40", ForgotPassword_Email, "HomeElement", "Email", "Invalid Email Address") %>
								<%= REQUIRED_ICON %>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
							<td>
								<%= Submit_Button("SubmitButton", "ForgotPassword", "Button", "", "ForgotPassword") %>&nbsp;&nbsp;
							</td>
						</tr>
						</table>
						<input type="hidden" id="SelectedTab" name="SelectedTab" value="1" />
						</form>
					</p>
					</div>


					<!--
					**********************************
					CREATE ACCOUNT
					**********************************
					-->
					<div id="tabs-3" name="tabs-1">
					<p>
						<%
							SubmitButtonValue = "Create"
						%>
						<form action="<%= SCRIPT_NAME %>" method="post" id="formCreateAccount" name="formCreateAccount">
						<!-- #include virtual="/includes/forms/account.inc" -->
						<input type="hidden" id="SelectedTab" name="SelectedTab" value="1" />
						</form>
					</p>
					</div>
				</div>				

			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
</div>

<script type="text/javascript">
	var usernameArray = [];
	var emailArray = [];
	<%
		sql = "sp_Users_get"
		Set ors = oConn.Execute(sql)
		
		If NOT ors.EOF Then				
			Do Until ors.EOF
				UserName = ors("UserName")
				Email = ors("Email")
	%>
	usernameArray.push( "<%= Username %>" );
	<% If Trim(Email) <> "" Then %>
	emailArray.push( "<%= Email %>" );
	<% End If %>
	<%
				ors.MoveNext
			Loop
			ors.Close
		End If 
		Set ors = Nothing
	%>

    $('#LoginBoxLogin').fadeIn(3000);
	//$('#LoginBoxLogin').slideDown(2000);

	$("#tabs").tabs(
		{
  			active: <%= SelectedTab %>
		}
	);
	
</script>
<!-- #include virtual="/includes/modals/spinner.inc" -->
<!-- #include virtual="/includes/jquery.inc" -->
</body>
</html>
<!-- #include virtual="/includes/close_connection.inc" -->
