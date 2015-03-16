<!-- #include virtual="/includes/login.inc" -->
<!-- #include virtual="/includes/globals.inc" -->

<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/page_logs.inc" -->


<%
	Response.Buffer = true
	Session("Navigation") = "calendar"
	Template = Trim(Request("Template"))

	CurrentMonth = Trim(Request("CurrentMonth"))
	CurrentYear = Trim(Request("CurrentYear"))
	If CurrentMonth = "" Then
		CurrentMonth = Month(Date)
		CurrentYear = Year(Date)
	Else
		CurrentMonth = CInt(CurrentMonth)
		CurrentYear = CInt(CurrentYear)
	End If
	If CurrentMonth = 12 Then 
		NextMonth = 1
		NextYear = CurrentYear + 1
	Else
		NextMonth = CurrentMonth + 1
		NextYear = CurrentYear
	End If
	If CurrentMonth = 1 Then 
		PreviousMonth = 12
		PreviousYear = CurrentYear - 1
	Else
		PreviousMonth = CurrentMonth - 1
		PreviousYear = CurrentYear
	End If
%>
<html>
<head>
	<title>Calendar: <%= Session("FullName") %></title>
	<link rel="stylesheet" type="text/css" href="/styles/css/global.css">
	<!-- #include virtual="/includes/functions.js" -->
	<link href="/includes/jquery/jquery.css" rel="stylesheet">
	<link href="/includes/jquery/jquery.css" rel="stylesheet">
	<script src="/includes/jquery/jquery.js"></script>
	<script src="/includes/jquery/jquery-ui.js"></script>
</head>
<body bgcolor="#ffffff" link="#0000ff" alink="#0000ff" vlink="#0000ff" onLoad="SetDateTime()">
<table cellspacing=0 cellpadding=0 border=0 height="100%" align="left" width="120">
<tr>
	<td align=right valign=top>
		<!-- #include virtual="/includes/navigation.inc" -->
	</td>
</tr>
</table>
<table cellspacing=0 cellpadding=0 border=0 height="100%" width="680">
<tr>
	<td width="100%" valign=top>
		<table cellspacing=1 cellpadding=0 width="100%" border=0>
		<tr>
			<td bgcolor="#ce9a31">
				<table cellspacing=0 cellpadding=0 border=0 width="100%">
				<tr>
					<td>&nbsp;&nbsp;&nbsp;<font face="Verdana,Arial" size=2 color="#ffffff"><b>Calendar:</b></font>&nbsp;&nbsp;<font face="Verdana,Arial" size=2 color="#ffffff"><b><%= Session("FullName") %></b></td>
					<td align="right"><span id="TodaysDate" style="font-family:Verdana;font-size:10pt;font-weight:bold;color:white;position:relative;"></span>&nbsp;&nbsp;&nbsp;</td>
				</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td bgcolor="#c6ba9c">
				<% If Template = "" Then %>
				<!-- #include file="templates/calendar.tem" -->
				<% ElseIf Template = "Reminders" Then %>
				<!-- #include file="templates/Reminders.tem" -->
				<% End If %>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
<% If InStr(LCase(Request.ServerVariables("HTTP_USER_AGENT")), "webtv") > 0 Then %>
<p>
<center>

[ <a href="/banking/banking.asp" style="text-decoration:none;"><font face="Verdana,Arial" size=2 color="#0000ff">Back</a> ]
</center>
<% End If %>

</body>
</html>
<!-- #include virtual="/includes/jquery.inc" -->
<!-- #include virtual="/includes/close_header.inc" -->
<!-- #include virtual="/includes/close_connection.inc" -->
