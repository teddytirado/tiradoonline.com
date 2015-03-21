<%@ Control language="c#" Inherits="MyLittleAdmin.MetaHeader"  ClassName="MetaHeader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en-US" lang="en-US">

	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<meta http-equiv="Content-Script-Type" content="text/javascript" />
		<meta http-equiv="Content-Style-Type" content="text/css" />
		<meta http-equiv="Content-Language" content="en-US" />

		<asp:PlaceHolder id="PH_Description" runat="server"/>
		<asp:PlaceHolder id="PH_Keywords" runat="server"/>

		<meta name="author" content="myLittleTools, Elian Chrebor" />
		<meta name="copyright" content="(c) 2005-08, myLittleTools, Elian Chrebor" />
		
		<asp:PlaceHolder id="PH_Title" runat="server"/>

		<asp:PlaceHolder id="PH_Css" runat="server"/>
		<asp:PlaceHolder id="PH_Javascript" runat="server"/>
	</head>