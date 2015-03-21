<%@ Page language="c#" Inherits="mla_gui.NewTable"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	
	<script type="text/javascript">
	<!--
		function ps(pObj) {
			var oFg = document.getElementById("fOnFileGroup_cControl");
			var oTfg = document.getElementById("fTextImageOnFileGroup_cControl");
			oFg.disabled = (pObj.value != "");
			oTfg.disabled = (pObj.value != "");
			return (false);
		}

		function fg() {
			var oFg = document.getElementById("fOnFileGroup_cControl");
			var oTfg = document.getElementById("fTextImageOnFileGroup_cControl");
			var oPs = document.getElementById("fOnPartitionScheme_cControl");
			oPs.disabled = ((oFg.value != "") || (oTfg.value != ""))
			return (false);
		}

		function _prefill(pObjNumber, pLength, pPrecision, pScale, pNullable) {
			document.getElementById("length_" + pObjNumber).value = pLength;
			document.getElementById("precision_" + pObjNumber).value = pPrecision;
			document.getElementById("scale_" + pObjNumber).value = pScale;
			document.getElementById("allownulls_" + pObjNumber).checked = pNullable;
			document.getElementById("identity_" + pObjNumber).value = false;
			document.getElementById("idseed_" + pObjNumber).value = "";
			document.getElementById("idinc_" + pObjNumber).value = "";
			return (true);
		}

		function _disable(pObjNumber, pLength, pPrecision, pScale, pIdentity, pRowGuid, pFilestream) {
			document.getElementById("length_" + pObjNumber).disabled = pLength;
			document.getElementById("precision_" + pObjNumber).disabled = pPrecision;
			document.getElementById("scale_" + pObjNumber).disabled = pScale;
			document.getElementById("identity_" + pObjNumber).disabled = pIdentity;
			document.getElementById("idseed_" + pObjNumber).disabled = pIdentity;
			document.getElementById("idinc_" + pObjNumber).disabled = pIdentity;
			document.getElementById("rowguid_" + pObjNumber).disabled = pRowGuid;
			try { document.getElementById("filestream_" + pObjNumber).disabled = pFilestream; } 
			catch(err) { }
			return (true);
		}

		function checkIdentity(pObj) {		
			var nObjNumber = pObj.name.substring(pObj.name.lastIndexOf("_")+1, pObj.name.length);
			if (document.getElementById("allownulls_" + nObjNumber).checked) {
				alert("uncheck nullable"); return (false); 
			} else {
				if (document.getElementById("identity_" + nObjNumber).checked) {
					document.getElementById("idinc_" + nObjNumber).value = 1;
					document.getElementById("idseed_" + nObjNumber).value = 1;
				} else {
					document.getElementById("idinc_" + nObjNumber).value = "";
					document.getElementById("idseed_" + nObjNumber).value = "";
				}
				return (true);
			}
		}

		function checkNullable(pObj) {
			var nObjNumber = pObj.name.substring(pObj.name.lastIndexOf("_")+1, pObj.name.length);
			if (document.getElementById("identity_" + nObjNumber).checked) {
				alert("uncheck identity before"); return (false); 
			} else return (true);
		}

		function prefill(pObj) {
			var nObjNumber = pObj.name.substring(pObj.name.lastIndexOf("_")+1, pObj.name.length);
			var sType = pObj.options[pObj.options.selectedIndex].text;
			switch (sType) {
				case "bigint" : _prefill(nObjNumber, 4, 3, 0, 1); _disable(nObjNumber, 1, 1, 1, 0, 1, 1); break;
				case "binary" : _prefill(nObjNumber, 10, 0, 0, 1); _disable(nObjNumber, 0, 1, 1, 1, 1, 1); break;
				case "bit" : _prefill(nObjNumber, 1, 0, 0, 0); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "char" : _prefill(nObjNumber, 10, 0, 0, 1); _disable(nObjNumber, 0, 1, 1, 1, 1, 1); break;
				case "datetime" : _prefill(nObjNumber, 8, 0, 0, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "decimal" : _prefill(nObjNumber, 9, 18, 0, 1); _disable(nObjNumber, 1, 0, 0, 0, 1, 1); break;
				case "float" : _prefill(nObjNumber, 8, 53, 0, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "image" : _prefill(nObjNumber, 16, 0, 0, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "int" : _prefill(nObjNumber, 4, 10, 0, 1); _disable(nObjNumber, 1, 1, 1, 0, 1, 1); break;
				case "money" : _prefill(nObjNumber, 8, 19, 4, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "nchar" : _prefill(nObjNumber, 10, 0, 0, 1); _disable(nObjNumber, 0, 1, 1, 1, 1, 1); break;
				case "ntext" : _prefill(nObjNumber, 16, 0, 0, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "numeric" : _prefill(nObjNumber, 9, 18, 0, 1); _disable(nObjNumber, 1, 0, 0, 0, 1, 1); break;
				case "nvarchar" : _prefill(nObjNumber, 50, 0, 0, 1); _disable(nObjNumber, 0, 1, 1, 1, 1, 1); break;
				case "real" : _prefill(nObjNumber, 4, 24, 0, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "smalldatetime" : _prefill(nObjNumber, 4, 0, 0, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "smallint" : _prefill(nObjNumber, 2, 5, 0, 1); _disable(nObjNumber, 1, 1, 1, 0, 1, 1); break;
				case "smallmoney" : _prefill(nObjNumber, 4, 10, 4, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "text" : _prefill(nObjNumber, 16, 0, 0, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "timestamp" : _prefill(nObjNumber, 8, 0, 0, 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
				case "tinyint" : _prefill(nObjNumber, 1, 3, 0, 1); _disable(nObjNumber, 1, 1, 1, 0, 1, 1); break;
				case "uniqueidentifier" : _prefill(nObjNumber, 16, 0, 0, 1); _disable(nObjNumber, 1, 1, 1, 1, 0, 1); break;
				case "varbinary" : _prefill(nObjNumber, 50, 0, 0, 1); _disable(nObjNumber, 0, 1, 1, 1, 1, 0); break;
				case "varchar" : _prefill(nObjNumber, 50, 0, 0, 1); _disable(nObjNumber, 0, 1, 1, 1, 1, 1); break;
				default : _prefill(nObjNumber, "", "", "", 1); _disable(nObjNumber, 1, 1, 1, 1, 1, 1); break;
			}
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
							id="fSchema"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						<br />
						<asp:Table id="fTable" runat="server" />
						<asp:Button Text="Add" id="btnAdd" class="mediumcontrol" onclick="btnAdd_Click" runat="server" />
					</div>

					<div id="zTab_Options" class="zonetab">

						<MyLittleAdmin:MlaFormElement
							id="fQuotedIdentifier"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>
						<br />

						<MyLittleAdmin:MlaFormElement
							id="fOnPartitionScheme"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fOnFileGroup"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fTextImageOnFileGroup"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<MyLittleAdmin:MlaFormElement
							id="fFilestreamOnFileGroup"
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