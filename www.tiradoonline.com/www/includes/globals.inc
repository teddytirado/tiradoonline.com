<%
	MachineName = ".\SQL2K8"
	ConnectionString = "driver={SQL SERVER};server=" & MachineName & ";uid=tiradoonline_user;pwd=Sixpak141414;database=tiradoonline;"
	Debugging = false
	ErrorMessage = Trim(Request("ErrorMessage"))
	SCRIPT_NAME = Request.ServerVariables("SCRIPT_NAME")
	SERVER_NAME = Request.ServerVariables("SERVER_NAME")
	SubmitButton = Trim(Request("SubmitButton"))
	Template = Trim(Request("Template"))
	THEME_COLOR = "#336699"
	
	'******************
	'CONSTANTS
	'*****************
	REQUIRED_ICON = "<img src='http://" & SERVER_NAME & "/images/icons/required.gif' title='Required' style='padding-left:5px'>"
	TEDDY_PHOTO = "<img src=""http://" & SERVER_NAME & "/images/photos/teddy.jpg"" alt=""Theodore Tirado"" width=""311"" height=""551"" hspace=""0"" vspace=""0"" border=""0"" class=""photoTeddy"">"
	YIELD_ICON = "<img src='http://" & SERVER_NAME & "/images/icons/yield.gif' width='20' height='20' title='ERROR!!!' style='padding-right:5px'>"
	
	url_string = "/scripts/download_resume.asp" & _
	"?Action=download" & _
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