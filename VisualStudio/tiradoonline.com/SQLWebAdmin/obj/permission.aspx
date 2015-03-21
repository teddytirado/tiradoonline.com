<%@ Page language="c#" Inherits="mla_gui.Permission"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="MlaDatagrid" Src="../common/mladatagrid.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	

	<script type="text/javascript">
	<!--
		function _cb(pObj) {
			var sAction = pObj.name.substring(pObj.name.length-1, pObj.name.length);
			var sRoot = pObj.id.substring(0, pObj.id.length-1);
			switch (sAction) {
				case "G" : 
					if (pObj.checked) {
						document.getElementById(sRoot + "D").checked = false;
					} else {
						document.getElementById(sRoot + "W").checked = false;
					}
					break;
				case "W" :
					if (pObj.checked) {
						document.getElementById(sRoot + "D").checked = false;
						document.getElementById(sRoot + "G").checked = true;
					}
					break;
				case "D" :
					if (pObj.checked) {
						document.getElementById(sRoot + "W").checked = false;
						document.getElementById(sRoot + "G").checked = false;
					}
					break;
			}
			return (true);
		}
	//-->
	</script>

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

						<label id="labelPrincipal" for="dropdownPrincipal" class="classic" runat="server"></label>
						<asp:DropDownList 
							id="dropdownPrincipal" 
							class="longcontrol" 
							AutoPostBack="true"
							OnSelectedIndexChanged="ChangePrincipal"
							runat="server" 
						/>
						<br clear="all" /><br />

						<div id="zPermission">
							<asp:Label id="labelExplicitPermission" runat="server" class="classic"/><br /><br />
							 <table class="formList" cellspacing="0" rules="all">
								<theader>
									<tr class="formHeaderCell">
										<td><asp:Label id="labelPermission" runat="server" /></td>
										<td><asp:Label id="labelGrantor" runat="server" /></td>
										<td class="cbperm"><asp:Label id="labelGrant" runat="server" /></td>
										<td class="cbperm"><asp:Label id="labelWithGrant" runat="server" /></td>
										<td class="cbperm"><asp:Label id="labelDeny" runat="server" /></td>
									</tr>
								</theader>
								<tbody>
							<asp:Repeater id="rptPermission" runat="server">
								<ItemTemplate>
											 <tr class="" id="oPermRow" Runat="server">
												<td> <asp:PlaceHolder id="oPermDesc" Runat="server"/> </td>
												<td> <asp:PlaceHolder id="oGrantorDesc" Runat="server"/> </td>
												<td class="cbperm"> <asp:PlaceHolder id="oGrant" Runat="server"/> </td>
												<td class="cbperm"> <asp:PlaceHolder id="oWithGrant" Runat="server"/> </td>
												<td class="cbperm"> <asp:PlaceHolder id="oDeny" Runat="server"/> </td>
											 </tr>
								</ItemTemplate>
							</asp:Repeater>
								</tbody>
							</table>
						</div>

						<div id="zFormButton">
							<asp:Button id="btnCancel" class="mediumcontrol" onclick="btnCancel_Click" Runat="server" />
							<asp:Button id="btnApply" class="mediumcontrol" onclick="btnApply_Click" Runat="server" />
						</div>

					</div>
				</div>

			</div>

		</div></div>
	</form>
</body>
</html>