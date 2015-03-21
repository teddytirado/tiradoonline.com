<%@ Page language="c#" Inherits="mla_gui.Preferences"  %>

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
				<div id="zForm_Container">

					<MyLittleAdmin:MlaTab
						id="zTabs"
						runat="server"
					/>
					
					<div id="zTab_General" class="zonetab">

						<MyLittleAdmin:MlaFormElement
							id="fLanguage"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fSkin"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fDateFormat"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fRecordCountPerPage"
							CssClass="shortcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fCsvSeparator"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fXlsExportFormat"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						
					</div>

				</div>

				<div id="zFormButton">
					<asp:Button Text="Submit" id="btnSubmit" class="mediumcontrol" onclick="btnSubmit_Click" Runat="server" />
				</div>


			</div></div>
			
		</div></div>
	</form>

</body>
</html>