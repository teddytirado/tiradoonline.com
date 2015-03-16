<%@ Page language="c#" Inherits="mla_gui.ChangePassword"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	

	<script type="text/javascript">
	<!--
		function checkpwd() {
			var oPwd = document.getElementById("fNewPassword_cControl");
			var oConfirmPwd = document.getElementById("fConfirmPassword_cControl");
			if (oPwd.value == oConfirmPwd.value) return (true);
			else {
				oConfirmPwd.focus();
				alert("Please confirm new password");
				return (false);
			}
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
							id="fLogin"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fOldPassword"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fNewPassword"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fConfirmPassword"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
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