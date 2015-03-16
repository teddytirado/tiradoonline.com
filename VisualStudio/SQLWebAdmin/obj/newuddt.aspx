<%@ Page language="c#" Inherits="mla_gui.NewUDDT"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	<script type="text/javascript">
	<!--
		function moreInfo(pType) {
			var zLength = document.getElementById("zLength");
			var zPrecisionScale = document.getElementById("zPrecisionScale");
			if (pType == "106" || pType == "108") {
				zLength.style.display = "none";
				zPrecisionScale.style.display = "";
				return (false);
			}
			if (pType == "167" 
				|| pType == "165" 
				|| pType == "173" 
				|| pType == "175" 
				|| pType == "231" 
				|| pType == "239" 
			) {
				zPrecisionScale.style.display = "none";
				zLength.style.display = "";
				return (false);
			}
			zPrecisionScale.style.display = "none";
			zLength.style.display = "none";
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
							id="fSchema"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							runat="server"
						/>					
						<MyLittleAdmin:MlaFormElement
							id="fName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fType"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<div id="zPrecisionScale" style="display: none;">
							<div style="float: left;">
								<MyLittleAdmin:MlaFormElement
									id="fPrecision"
									CssClass="mediumcontrol"
									LabelCssClass="classic"
									Type="TextBox"
									runat="server"
								/>
							</div>
							<div style="float: left; margin-left: 5px;">
								<MyLittleAdmin:MlaFormElement
									id="fScale"
									CssClass="mediumcontrol"
									LabelCssClass="classic"
									Type="TextBox"
									runat="server"
								/>
							</div>
							<br clear="both" />
						</div>
						<div id="zLength" style="display: none;">
							<MyLittleAdmin:MlaFormElement
								id="fLength"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>
						</div>

						<MyLittleAdmin:MlaFormElement
							id="fAllowNulls"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
					</div>

					<div id="zTab_Binding" class="zonetab">
						<MyLittleAdmin:MlaFormElement
							id="fDefault"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fRule"
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