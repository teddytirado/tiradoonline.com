<%@ Page language="c#" Inherits="mla_gui.NewDatabase"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	<script type="text/javascript">
	<!--
		function setFileGroup(pValue, pLine) {
			var oFileGroup = document.getElementById("fFileGroup_" + pLine);
			if (pValue == "filestream" && oFileGroup.value == "PRIMARY") oFileGroup.value = "MEDIA";
			if (pValue == "data" && oFileGroup.value == "MEDIA") oFileGroup.value = "PRIMARY";
			oFileGroup.disabled = (pValue == "log");
			return (false);
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
						<MyLittleAdmin:MlaFormElement
							id="fDatabaseName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>	
						<MyLittleAdmin:MlaFormElement
							id="fOwner"
							CssClass="longcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fUseFullTextIndexing"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>	
					</div>

					<div id="zTab_Files" class="zonetab">
						<asp:Table id="fFileTable" runat="server" />
						<asp:Button Text="Add" id="btnAdd" class="mediumcontrol" onclick="btnAdd_Click" runat="server" />
					</div>

					<div id="zTab_Options" class="zonetab">
						<MyLittleAdmin:MlaFormElement
							id="fCollation"
							CssClass="longcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fRecoveryModel"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fCompatibilityLevel"
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