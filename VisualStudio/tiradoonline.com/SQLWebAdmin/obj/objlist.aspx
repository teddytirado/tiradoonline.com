<%@ Page language="c#" Inherits="mla_gui.ObjList"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="ObjectList" Src="../common/objectlist.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	<form runat="server" id="mainForm">

		<MyLittleAdmin:MlaBox
			id="menubox"
			JsId="oMenuBox" 
			Height="200px"
			Width="150px"
			runat="server" 
		/>

		<div id="zFullZone"><div id="zFullZone_1">
			<MyLittleAdmin:PageHeader 
				id="pageheader" 
				runat="server" 
			/>	
		
			<div id="zPageContent"><div id="zPageContent_Container" runat="server">	
				<MyLittleAdmin:ObjectList
					id="objectlist" 
					runat="server" 
				/>
			</div>

		</div></div>
	</form>
</body>
</html>