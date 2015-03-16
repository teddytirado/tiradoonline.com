<%@ Page language="c#" Inherits="mla_gui.NewStatistics"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	<script type="text/javascript">
	<!--
		function showSampleInfo(pValue) {
			var oLabel= document.getElementById("fSample_lControl");
			var oSample= document.getElementById("fSample_cControl");
			oLabel.disabled = pValue;
			oSample.disabled = pValue;
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
							id="fStatisticsName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						<br />

						<div id="zIndexColumns">
							<asp:Label id="zColumns" class="listTitle" runat="server" />
							<div id="zColumnList">
								<asp:PlaceHolder id="zFields" runat="server" />
							</div>
						</div>
					</div>
					<div id="zTab_Options" class="zonetab">
						<MyLittleAdmin:MlaFormElement
							id="fFullscan"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fSample"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fNorecompute"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
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