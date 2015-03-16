<%@ Page language="c#" Inherits="mla_gui.NewFKey"  %>

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
							id="fTableName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						
						<MyLittleAdmin:MlaFormElement
							id="fFKeyName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>

						<br />

						<div style="float: left;">
							<label id="labelPKeyTable" for="dropdownPKeyTable" class="classic" runat="server"></label>
							<asp:DropDownList 
								id="dropdownPKeyTable" 
								class="mediumcontrol" 
								AutoPostBack="true"
								OnSelectedIndexChanged="ChangePKTable"
								runat="server" 
							/>

							<MyLittleAdmin:MlaFormElement
								id="fPKeyColumn_1"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="DropDownList"
								runat="server"
							/>
							<MyLittleAdmin:MlaFormElement
								id="fPKeyColumn_2"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="DropDownList"
								runat="server"
							/>
							<MyLittleAdmin:MlaFormElement
								id="fPKeyColumn_3"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="DropDownList"
								runat="server"
							/>

						</div>

						<div style="float: left; margin-left: 5px;">
							<MyLittleAdmin:MlaFormElement
								id="fFKeyTable"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>
							<MyLittleAdmin:MlaFormElement
								id="fFKeyColumn_1"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="DropDownList"
								runat="server"
							/>
							<MyLittleAdmin:MlaFormElement
								id="fFKeyColumn_2"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="DropDownList"
								runat="server"
							/>
							<MyLittleAdmin:MlaFormElement
								id="fFKeyColumn_3"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="DropDownList"
								runat="server"
							/>
						</div>
						<br clear="all" /><br />

					</div>

					<div id="zTab_Options" class="zonetab">
					
						<MyLittleAdmin:MlaFormElement
							id="fEnforceReplication"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fEnforceFKeyConstraint"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fDeleteRule"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fUpdateRule"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

					</div>
				
				</div>

				<div id="zFormButton">
					<asp:Button Text="Cancel" id="btnCancel" class="mediumcontrol" onclick="btnCancel_Click" Runat="server" />
					<asp:Button Text="Submit" id="btnSubmit" class="mediumcontrol" onclick="btnSubmit_Click" Runat="server" />
				</div>

			</div></div>
			
		</div></div>
	</form>

</body>
</html>