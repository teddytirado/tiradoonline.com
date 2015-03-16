<!-- #include virtual="/includes/login.inc" -->
<!-- #include virtual="/includes/globals.inc" -->

<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/page_logs.inc" -->


<%
	Response.Buffer = true
	Session("Navigation") = "email"
	Template = Trim(Request("Template"))
%>
<html>
<head>
	<title>Email: <%= Session("FullName") %></title>
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
			<td bgcolor="#0000aa">
				<table cellspacing=0 cellpadding=0 border=0 width="100%">
				<tr>
					<td>&nbsp;&nbsp;&nbsp;<font face="Verdana,Arial" size=2 color="#639AFF"><b>Email:</b></font>&nbsp;&nbsp;<font face="Verdana,Arial" size=2 color="#ffffff"><b><%= Session("FullName") %></b></td>
					<td align="right"><span id="TodaysDate" style="font-family:Verdana;font-size:10pt;font-weight:bold;color:white;position:relative;"></span>&nbsp;&nbsp;&nbsp;</td>
				</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td bgcolor="#000066">
				<!-- #include file="templates/email.tem" -->
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
</body>
</html>
<!-- #include virtual="/includes/jquery.inc" -->
<!-- #include virtual="/includes/close_header.inc" -->
<!-- #include virtual="/includes/close_connection.inc" -->
