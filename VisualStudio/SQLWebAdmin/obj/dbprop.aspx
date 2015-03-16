<%@ Page language="c#" Inherits="mla_gui.DatabaseProperties"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="MlaProp" Src="../common/mlaprop.ascx" %>
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
				<div id="zForm_Container">

					<MyLittleAdmin:MlaTab
						id="zTabs"
						runat="server"
					/>
					
					<div id="zTab_General" class="zonetab">
						<MyLittleAdmin:MlaProp 
							id="mlaprop_general" 
							runat="server" 
						/>		
					</div>

					<div id="zTab_Files" class="zonetab">
						<MyLittleAdmin:ObjectList
							id="filelist" 
							runat="server" 
						/>
					</div>

					<div id="zTab_Options" class="zonetab">
						<MyLittleAdmin:MlaProp 
							id="mlaprop_options" 
							runat="server" 
						/>		
					</div>

				</div>
			</div></div>
			
		</div></div>
	</form>

</body>
</html>