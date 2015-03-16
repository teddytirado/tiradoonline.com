<%@ Page language="c#" Inherits="mla_gui.navbar"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="navbar_resize();">
	<script type="text/javascript"><!--
	window.onresize = navbar_resize;
	//-->
	</script>
	<form runat="server" id="mainForm">

		<div id="navbarLogo">
			<div style="padding: 2px 0 0 2px;">
				<a href="#" onclick="reduceFrame(); return (false);"><img id="navbar_reduce" width="16" height="16" alt="Reduce" runat="server" /></a>
			</div>
		</div>

		<MyLittleAdmin:NavBar 
			id="oNavbar" 
			class="navbar" 
			runat="server" 
		/>

	</form>
</body>
</html>
