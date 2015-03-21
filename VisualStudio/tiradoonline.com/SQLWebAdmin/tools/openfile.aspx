<%@ Page language="c#" Inherits="mla_gui.OpenFile"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body>	

	<form runat="server" id="mainForm" enctype="multipart/form-data">

			<div id="zPageContent"><div id="zPageContent_Container" runat="server">				
				<div id="zForm_Container">

					<asp:Label id="zOpenFileHelp" runat="server" /><br />
					<label id="lOpenFile" for="fOpenFile" class="classic" runat="server"></label>
					<input type="file"
						id="fOpenFile" 
						class="longcontrol" 
						runat="server" 
					/><br clear="all" />

				</div>

				<div id="zFormButton">
					<asp:Button Text="Cancel" id="btnCancel" class="mediumcontrol" Runat="server" />
					<asp:Button Text="Submit" id="btnSubmit" class="mediumcontrol" onclick="btnSubmit_Click" Runat="server" />
				</div>

			</div></div>

	</form>

</body>
</html>