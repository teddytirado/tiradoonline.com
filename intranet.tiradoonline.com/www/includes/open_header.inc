<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
	<meta content="text/html;charset=utf-8" http-equiv="Content-Type">
	<meta content="utf-8" http-equiv="encoding">
	<link rel="icon" type="image/ico" href="/images/icons/logo.ico" /> 
	<link rel="shortcut icon" href="/images/icons/logo.ico" />
	<title><%= PageTitle %>: <%= Session("FullName") %></title>
	<link href="/includes/jquery/themes/base/jquery-ui.css" rel="stylesheet">
	<script src="/includes/jquery/jquery.js"></script>
	<script src="/includes/jquery/ui/jquery-ui.js"></script>
	<script src="/includes/jquery/ui/jquery.contextmenu.js"></script>
	<!-- #include virtual="/includes/css/global.css" -->
	<!-- #include virtual="/includes/js/functions.js" -->
	
	<!-- JMOBILE -->
	<!-- 
	<script src="/includes/jmobile/jquery.mobile.js"></script>
	<link href="/includes/jmobile/jquery.mobile.css" rel="stylesheet">
	 -->
	<!-- DATEPICKER -->
	<link rel="stylesheet" media="screen" type="text/css" href="/includes/datepicker/css/datepicker.css" />
	<script type="text/javascript" src="/includes/datepicker/js/datepicker.js"></script></head>

	<!-- DATEPICKER -->
	<link href="/foundation/css/normalize.css" rel="stylesheet" type="text/css" />
	<link href="/foundation/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="/foundation/js/vendor/modernizr.js" type="text/javascript"></script>


</head>

<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0" marginwidth="0" marginheight="0" onLoad="SetDateTime()">

<!-- <label for="search-basic">Search Input:</label>
<input type="search" name="search" id="search-basic" value="" />
 --><div id="LoginBoxSite">

	<table id="navigationMenu" style="position:relative" cellspacing=0 cellpadding=0 border=0>
	<tr valign="top">
		<td>
		<!-- #include virtual="/includes/navigation.inc" -->
		</td>
		<td>


<!-- 	<div style="width:1200px;position:absolute;left:<%= navWidth + 80 %>"> -->
	<div id="mainContent" style="width:1200px;position:absolute;left:<%= navWidth + 80 %>">
		<table cellspacing=0 cellpadding=0 border=0>
		<tr valign="top">
			<td valign=top width="100%">
				<a href="/home.asp" title="Bankingintranet.tiradoonline.com"><img src="/images/header/logo_banner.gif" title="Bankingintranet.tiradoonline.com" border="0"></a>
		
				<table cellspacing=1 cellpadding=0 width="100%" border=0>
				<tr class="<%= PageTheme %>">
					<td class="Header">
						<table cellspacing=0 cellpadding=3 border=0 width="100%">
						<tr class="<%= PageTheme %>">
							<td>&nbsp;&nbsp;&nbsp;<%= HeaderTitle %>:&nbsp;&nbsp;<%= Session("FullName") %></td>
							<td align="right"><span id="TodaysDate" name="TodaysDate" />&nbsp;&nbsp;&nbsp;</td>
						</tr>
						</table>
					</td>
				</tr>
				</table>
				<table cellspacing=1 cellpadding=0 border=0 width="<%= MainContentWidth %>">
				<tr>
					<td width="<%= MainContentWidth %>">
						


