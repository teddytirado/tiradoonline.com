<%@ Page language="c#" Inherits="mla_gui.CsvImport"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="WaitingBox" Src="../common/mlawaitingbox.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	<script type="text/javascript">
	<!--
		function showOtherSeparator(pValue) {
			var zOtherSep= document.getElementById("zOtherSep");
			zOtherSep.style.display = ((pValue == "other") ? "" : "none");
			return (false);
		}
	//-->
	</script>


	<form runat="server" id="mainForm" enctype="multipart/form-data">
		<div id="zFullZone"><div id="zFullZone_1">

			<MyLittleAdmin:PageHeader 
				id="pageheader" 
				runat="server" 
			/>		

			<div id="zPageContent"><div id="zPageContent_Container" runat="server">				

				<MyLittleAdmin:WaitingBox 
					id="WaitingBox"
					runat="server" 
				/>

				<div id="zForm_Container">
					
					<MyLittleAdmin:MlaTab
						id="zTabs"
						runat="server"
					/>

					<div id="zTab_General" class="zonetab">

						<asp:Label id="zCsvImportHelp" runat="server" />
						<br /><br />

						<label id="lDatabaseName" for="fDatabaseName" class="classic" runat="server"></label>
						<asp:DropDownList 
							id="fDatabaseName" 
							class="longcontrol" 
							AutoPostBack="true"
							OnSelectedIndexChanged="ChangeDatabase"
							runat="server" 
						/><br clear="all" />

						<label id="lTableName" for="fTableName" class="classic" runat="server"></label>
						<asp:DropDownList 
							id="fTableName" 
							class="longcontrol" 
							AutoPostBack="true"
							OnSelectedIndexChanged="ChangeTable"
							runat="server" 
						/><br clear="all" />

						<div id="zColumns">
							<asp:Label id="zColumnsTitle" class="listTitle" runat="server" />
							<div style="margin-left: 140px;">
							<asp:CheckBoxList
								id="fColumns"
								CssClass="checkboxlist"
								CellPadding = "0"
								CellSpacing= "0"
								runat="server"
							/>
							</div>
						</div>

						<asp:Label id="zCsvFile" class="listTitle" runat="server" /><br />
						<label id="lCsvFile" for="fCsvFile" class="classic" runat="server"></label>
						<input type="file"
							id="fCsvFile" 
							class="longcontrol" 
							runat="server" 
						/><br clear="all" />

					</div>

					<div id="zTab_Options" class="zonetab">
						<MyLittleAdmin:MlaFormElement
							id="fColumnSeparator"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<div id="zOtherSep" style="display: none;">
							<MyLittleAdmin:MlaFormElement
								id="fSpecificColumnSeparator"
								CssClass="tinycontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>
						</div>
						<MyLittleAdmin:MlaFormElement
							id="fColumnNameOn1stLine"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fEnableIdentity"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
						
						<br />

						<MyLittleAdmin:MlaFormElement
							id="fCountAtOnce"
							CssClass="tinycontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>

						<br />

						<asp:radioButton GroupName="CSVExecOption" id="fCSVExecOption_Append" runat="server" />
						<br />
						<asp:radioButton GroupName="CSVExecOption" id="fCSVExecOption_Delete" runat="server" />

					</div>

					<div id="zTab_Messages" class="zonetab">
						<div id="zMessage" runat="server" />
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