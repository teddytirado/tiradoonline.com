<%@ Page language="c#" Inherits="mla_gui.BackUp"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="WaitingBox" Src="../common/mlawaitingbox.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	
	<script type="text/javascript">
	<!--
		function showExpirationInfo(pValue) {
			var zDay = document.getElementById("zExpirationDay");
			var zDate = document.getElementById("zExpirationDate");
			switch (pValue) {
				case "never" : 
					zDay.style.display = "none";
					zDate.style.display = "none";
					break;
				case "duration" :
					zDay.style.display = "";
					zDate.style.display = "none";
					break;
				case "date" :
					zDay.style.display = "none";
					zDate.style.display = "";
					break;
			}
			return (false);
		}

		function showDestinationInfo(pValue) {
			var zBd= document.getElementById("zDestinationBd");
			var zFile = document.getElementById("zDestinationFile");
			switch (pValue) {
				case "file" : 
					zBd.style.display = "none";
					zFile.style.display = "";
					break;
				case "device" :
					zBd.style.display = "";
					zFile.style.display = "none";
					break;
			}
			return (false);
		}

		function showLogInfo(pValue) {
			var zLog= document.getElementById("zTransactionLog");
			zLog.style.display = ((pValue == "log") ? "" : "none");
			return (false);
		}

		function showMediaCheckInfo(pValue) {
			var zChk= document.getElementById("zMediaSetName_check");
			zChk.style.display = (pValue ? "" : "none");
			return (true);
		}

		function showCheckSumInfo(pValue) {
			var zChk= document.getElementById("zContinueOnCheckSumError");
			zChk.style.display = (pValue ? "" : "none");
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
						<MyLittleAdmin:MlaFormElement
							id="fDatabase"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>					
						<MyLittleAdmin:MlaFormElement
							id="fBackUpType"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<br />

						<MyLittleAdmin:MlaFormElement
							id="fSetName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						<MyLittleAdmin:MlaFormElement
							id="fSetDescription"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>

						<br />

						<MyLittleAdmin:MlaFormElement
							id="fSetExpiration"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<div id="zExpirationDay" style="display: none;">
							<MyLittleAdmin:MlaFormElement
								id="fSetExpirationDay"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>
						</div>
						<div id="zExpirationDate" style="display: none;">
							<MyLittleAdmin:MlaFormElement
								id="fSetExpirationDate"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>
						</div>
						
						<br />

						<MyLittleAdmin:MlaFormElement
							id="fDestinationType"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>
						<div id="zDestinationBd">
							<MyLittleAdmin:MlaFormElement
								id="fBackUpDevice"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="DropDownList"
								runat="server"
							/>
						</div>
						<div id="zDestinationFile" style="display: none;">
							<MyLittleAdmin:MlaFormElement
								id="fFileLocation"
								CssClass="longcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>
						</div>
					</div>

					<div id="zTab_Options" class="zonetab">
					
						<asp:Label id="fOverwriteMedia" class="listTitle" runat="server" /><br />
						<asp:radioButton GroupName="OverwriteOption" id="fBackUpExistingMediaSet" runat="server" />
							<div style="margin-left: 50px;">
								<MyLittleAdmin:MlaFormElement
									id="fAppendOverwrite"
									CssClass="longcontrol"
									LabelCssClass="classic"
									Type="DropDownList"
									runat="server"
								/>
								<MyLittleAdmin:MlaFormElement
									id="fCheckMediaSetName"
									CssClass="mediumcontrol"
									LabelCssClass="cbclassic"
									Type="CheckBox"
									runat="server"
								/>	
								<div id="zMediaSetName_check" style="display: none;">
									<MyLittleAdmin:MlaFormElement
										id="fMediaSetName_check"
										CssClass="mediumcontrol"
										LabelCssClass="classic"
										Type="TextBox"
										runat="server"
									/>	
								</div>
							</div>

						<asp:radioButton GroupName="OverwriteOption" id="fBackUpNewMediaSet" runat="server" />
							<div style="margin-left: 50px;">
							<MyLittleAdmin:MlaFormElement
								id="fNewMediaSetName"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>	
							<MyLittleAdmin:MlaFormElement
								id="fNewMediaSetDescription"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="TextBox"
								runat="server"
							/>	
							</div>

						<br />

						<asp:Label id="fReliability" class="listTitle" runat="server" />
						<MyLittleAdmin:MlaFormElement
							id="fVerifyBackup"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>	
						<MyLittleAdmin:MlaFormElement
							id="fPerformCheckSum"
							CssClass="mediumcontrol"
							LabelCssClass="cbclassic"
							Type="CheckBox"
							runat="server"
						/>	
						<div id="zContinueOnCheckSumError" style="display: none;">
							<MyLittleAdmin:MlaFormElement
								id="fContinueOnCheckSumError"
								CssClass="mediumcontrol"
								LabelCssClass="cbclassic"
								Type="CheckBox"
								runat="server"
							/>	
						</div>

						<br />
						<div id="zTransactionLog" style="display: none;">
							<asp:Label id="fTransactionLog" class="listTitle" runat="server" /><br />
							<asp:radioButton GroupName="TransLog" id="fTransLog_Truncate" runat="server" />
							<br />
							<asp:radioButton GroupName="TransLog" id="fTransLog_Backup" runat="server" />
						</div>

						<br />
						<asp:Label id="fCompression" class="listTitle" runat="server" />
						<div id="zCompression">
							<MyLittleAdmin:MlaFormElement
								id="fCompressionType"
								CssClass="mediumcontrol"
								LabelCssClass="classic"
								Type="DropDownList"
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