<%@ Page language="c#" Inherits="mla_gui.NewColumn"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="MlaProp" Src="../common/mlaprop.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	

	<script type="text/javascript">
	<!--
		function _prefill(pLength, pPrecision, pScale, pNullable) {
			document.getElementById(sLengthId).value = pLength;
			document.getElementById(sPrecisionId).value = pPrecision;
			document.getElementById(sScaleId).value = pScale;
			document.getElementById(sAllowNullsId).checked = pNullable;
			return (true);
		}

		function _disable(pLength, pPrecision, pScale) {
			document.getElementById(sLengthId).disabled = pLength;
			document.getElementById(sPrecisionId).disabled = pPrecision;
			document.getElementById(sScaleId).disabled = pScale;
			return (true);
		}

		function predisable(pObj) {
			var sType = pObj.options[pObj.options.selectedIndex].text;
			switch (sType) {
				case "bigint" : _disable(1, 1, 1); break;
				case "binary" : _disable(0, 1, 1); break;
				case "bit" : _disable(1, 1, 1); break;
				case "char" : _disable(0, 1, 1); break;
				case "date" : _disable(1, 1, 1); break;
				case "datetime" : _disable(1, 1, 1); break;
				case "datetimeoffset" : _disable(1, 1, 0); break;
				case "datetime2" : _disable(1, 1, 0); break;
				case "decimal" : _disable(1, 0, 0); break;
				case "float" : _disable(1, 1, 1); break;
				case "image" : _disable(1, 1, 1); break;
				case "int" : _disable(1, 1, 1); break;
				case "money" : _disable(1, 1, 1); break;
				case "nchar" : _disable(0, 1, 1); break;
				case "ntext" : _disable(1, 1, 1); break;
				case "numeric" : _disable(1, 0, 0); break;
				case "nvarchar" : _disable(0, 1, 1); break;
				case "real" : _disable(1, 1, 1); break;
				case "smalldatetime" : _disable(1, 1, 1); break;
				case "smallint" : _disable(1, 1, 1); break;
				case "smallmoney" : _disable(1, 1, 1); break;
				case "text" : _disable(1, 1, 1); break;
				case "time" : _disable(1, 1, 0); break;
				case "timestamp" : _disable(1, 1, 1); break;
				case "tinyint" : _disable(1, 1, 1); break;
				case "uniqueidentifier" : _disable(1, 1, 1); break;
				case "varbinary" : _disable(0, 1, 1); break;
				case "varchar" : _disable(0, 1, 1); break;
				default : _disable(1, 1, 1); break;
			}
			return (true);
		}

		function prefill(pObj) {			
			var sType = pObj.options[pObj.options.selectedIndex].text;
			switch (sType) {
				case "bigint" : _prefill(4, 3, 0, 1); break;
				case "binary" : _prefill(10, 0, 0, 1); break;
				case "bit" : _prefill(1, 0, 0, 0); break;
				case "char" : _prefill(10, 0, 0, 1); break;
				case "date" : _prefill(3, 0, 0, 1); break;
				case "datetime" : _prefill(8, 0, 0, 1); break;
				case "datetimeoffset" : _prefill(8, 0, 2, 1); break;
				case "datetime2" : _prefill(8, 0, 2, 1); break;
				case "decimal" : _prefill(9, 18, 0, 1); break;
				case "float" : _prefill(8, 53, 0, 1); break;
				case "image" : _prefill(16, 0, 0, 1); break;
				case "int" : _prefill(4, 10, 0, 1); break;
				case "money" : _prefill(8, 19, 4, 1); break;
				case "nchar" : _prefill(10, 0, 0, 1); break;
				case "ntext" : _prefill(16, 0, 0, 1); break;
				case "numeric" : _prefill(9, 18, 0, 1); break;
				case "nvarchar" : _prefill(50, 0, 0, 1); break;
				case "real" : _prefill(4, 24, 0, 1); break;
				case "smalldatetime" : _prefill(4, 0, 0, 1); break;
				case "smallint" : _prefill(2, 5, 0, 1); break;
				case "smallmoney" : _prefill(4, 10, 4, 1); break;
				case "text" : _prefill(16, 0, 0, 1); break;
				case "time" : _prefill(8, 0, 2, 1); break;
				case "timestamp" : _prefill(8, 0, 0, 1); break;
				case "tinyint" : _prefill(1, 3, 0, 1); break;
				case "uniqueidentifier" : _prefill(16, 0, 0, 1); break;
				case "varbinary" : _prefill(50, 0, 0, 1); break;
				case "varchar" : _prefill(50, 0, 0, 1); break;
				default : _prefill("", "", "", 1); break;
			}
			predisable(pObj);
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
					<MyLittleAdmin:MlaProp 
						id="mlaprop" 
						runat="server" 
					/>		
					</div>
				<div id="zTab_Options" class="zonetab">
					<MyLittleAdmin:MlaProp 
						id="mlaprop_options" 
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