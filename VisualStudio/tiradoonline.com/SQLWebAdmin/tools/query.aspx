<%@ Page language="c#" Inherits="mla_gui.NewQuery"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="WaitingBox" Src="../common/mlawaitingbox.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	<script type="text/javascript">
	<!--
		function openfile(pObj) {
			var oWnd = window.open("openfile.aspx?id=" + pObj, "mla_openfile", "width=500,height=100");
			return (false);
		}		
		
		function refreshCM(pContent) {
			cmEditor.setValue(pContent);
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

					<div id="zTab_Query" class="zonetab">

						<MyLittleAdmin:MlaFormElement
							id="fDatabaseName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<asp:TextBox
							id="fQuery" 
							runat="server" 
						/>	
					</div>

					<div id="zTab_Options" class="zonetab">
						<asp:Label id="zRowCountHelp" runat="server" /><br/>
						<MyLittleAdmin:MlaFormElement
							id="fRowCount"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						<br/><asp:Label id="zTextSizeHelp" runat="server" /><br/>
						<MyLittleAdmin:MlaFormElement
							id="fTextSize"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						<br/><asp:Label id="zBatchSeparatorHelp" runat="server" /><br/>
						<MyLittleAdmin:MlaFormElement
							id="fBatchSeparator"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						<br/>
						<MyLittleAdmin:MlaFormElement
							id="fDisplayQuery"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
					</div>

					<div id="zTab_Results" class="zonetab">
						<asp:PlaceHolder id="PH_Results" runat="server"/>
					</div>

					<div id="zTab_Messages" class="zonetab">
						<asp:PlaceHolder id="PH_Messages" runat="server"/>
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