<%@ Page language="c#" Inherits="mla_gui.Restore"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="WaitingBox" Src="../common/mlawaitingbox.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	<script type="text/javascript">
	<!--
		function showNewDatabase(pValue) {
			var zNewDb= document.getElementById("zNewDb");
			zNewDb.style.display = ((pValue == "") ? "" : "none");
			return (false);
		}

		function showFromFile(pValue) {
			var zFromFile = document.getElementById("zFromFile");
			zFromFile.style.display = ((pValue == "") ? "" : "none");
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
					
						<asp:Label id="zDestination" class="listTitle" runat="server" /><br />
						<asp:Label id="zDestinationHelp" runat="server" />
						<br /><br />

						<MyLittleAdmin:MlaFormElement
							id="fDatabaseName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<div id="zNewDb">
							<MyLittleAdmin:MlaFormElement
								id="fNewDatabaseName"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>
						</div>

						<br /><br />
						<asp:Label id="zSource" class="listTitle" runat="server" /><br />
						<asp:Label id="zSourceHelp" runat="server" /><br /><br />
						
						<MyLittleAdmin:MlaFormElement
							id="fBackupDevice"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<div id="zFromFile">
							<MyLittleAdmin:MlaFormElement
								id="fFile"
								CssClass="longcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>
						</div>
						<MyLittleAdmin:MlaFormElement
							id="fPosition"
							CssClass="shortcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>

					</div>

					<div id="zTab_Options" class="zonetab">

						<asp:Label id="zRestore" class="listTitle" runat="server" />

						<MyLittleAdmin:MlaFormElement
							id="fOverwriteDatabase"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fPreserveSettings"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fRestrictAccess"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>

						<br /><br />
						<asp:Label id="zRecovery" class="listTitle" runat="server" />
						<MyLittleAdmin:MlaFormElement
							id="fRecoveryState"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
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