<%@ Control language="c#" Inherits="MyLittleAdmin.PageHeader"  ClassName="PageHeader" %>

<div id="zPageHeader">
	<div id="zPageHeader_Container">
		<div id="zPageHeader_Icon">
			<asp:HyperLink id="linkUp" runat="server" />
			<asp:HyperLink id="linkRefresh" href="#" runat="server" />
			<asp:HyperLink id="linkSynchro" href="#" runat="server" />
		</div>
		<div id="zPageHeader_ObjectInfo">			
			<asp:Image id="imgObject" runat="server" /><span id="labelObjectName" class="objName" runat="server">Object Name</span>
		</div>
		<div>
			<div id="zPageHeader_ObjectPath"><span id="labelObjectPath" runat="server">Object path</span></div>
			<div id="zPageHeader_ItemCount"><span id="labelItemCount" runat="server">Item Count</span></div>
		</div>

		<div id="zPageHeader_Icon2">
			<asp:PlaceHolder id="PH_Icons2" runat="server" />
		</div>

	</div>
</div>