<%@ Page language="c#" Inherits="mla_gui.ShrinkDb"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="WaitingBox" Src="../common/mlawaitingbox.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	<script type="text/javascript">
	<!--
		function showFreeSpaceInfo(pValue) {
			var zSpace= document.getElementById("zFreeSpaceInfo");
			zSpace.style.display = (pValue ? "" : "none");
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
						<asp:Label id="zShrinkInfo" runat="server" /><br /><br />

						<MyLittleAdmin:MlaFormElement
							id="fDatabase"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>					

						<br />

						<asp:Label id="zDatabaseSize" class="listTitle" runat="server" /><br />
						<MyLittleAdmin:MlaFormElement
							id="fAllocatedSpace"
							CssClass="shortcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>	
						<MyLittleAdmin:MlaFormElement
							id="fAvailableFreeSpace"
							CssClass="shortcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>							

						<br />

						<asp:Label id="zShrinkAction" class="listTitle" runat="server" /><br />
						<MyLittleAdmin:MlaFormElement
							id="fReorganize"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
						<asp:Label id="zShrinkWarning" runat="server" /><br />
						<div id="zFreeSpaceInfo" style="display: none;">
							<MyLittleAdmin:MlaFormElement
								id="fFreeSpace"
								CssClass="shortcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>
						</div>
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