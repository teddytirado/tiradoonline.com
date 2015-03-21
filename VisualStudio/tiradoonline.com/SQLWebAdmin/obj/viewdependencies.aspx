<%@ Page language="c#" Inherits="mla_gui.ViewDependencies"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="ObjectList" Src="../common/objectlist.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	

	<form runat="server" id="mainForm">
		<div id="zFullZone"><div id="zFullZone_1">

			<MyLittleAdmin:PageHeader 
				id="pageheader" 
				runat="server" 
			/>		

			<div id="zPageContent"><div id="zPageContent_Container" runat="server">				

					<div class="dependenciesTitle"><asp:Label id="oDependenciesOn" runat="server" /></div>
					<MyLittleAdmin:ObjectList
						id="objectlist" 
						runat="server" 
					/>

					&nbsp;<br />
					<div class="dependenciesTitle"><asp:Label id="oDependenciesOff" runat="server" /></div>
					<MyLittleAdmin:ObjectList
						id="objectlist2" 
						runat="server" 
					/>


			</div></div>
			
		</div></div>
	</form>

</body>
</html>