<%@ Page language="c#" Inherits="mla_gui.NewUser"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
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
						<MyLittleAdmin:MlaFormElement
							id="fUserName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fLoginName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fDefaultSchema"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<br />

						<div id="zOwnedSchemas">
							<asp:Label id="zOwnedSchemasTitle" class="listTitle" runat="server" />
							<asp:CheckBoxList
								id="fOwnedSchemas"
								CssClass="checkboxlist"
								CellPadding = "0"
								CellSpacing= "0"
								runat="server"
							/>
						</div>
						<br />

						<div id="zRoleMembers">
							<asp:Label id="zRoleMembersTitle" class="listTitle" runat="server" />
							<asp:CheckBoxList
								id="fRoleMembers"
								CssClass="checkboxlist"
								CellPadding = "0"
								CellSpacing= "0"
								runat="server"
							/>
						</div>

					</div>
				</div>

				<div id="zFormButton">
					<asp:Button id="btnCancel" class="mediumcontrol" onclick="btnCancel_Click" Runat="server" />
					<asp:Button id="btnSubmit" class="mediumcontrol" onclick="btnSubmit_Click" Runat="server" />
				</div>

			</div></div>
			
		</div></div>
	</form>

</body>
</html>