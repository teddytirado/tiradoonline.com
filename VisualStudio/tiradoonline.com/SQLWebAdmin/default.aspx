<%@ Page language="c#" Inherits="mla_gui.connection"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="xml/defaultheader.xml" runat="server" />

<body>

	<script type="text/javascript"><!--
		function displayOptions(pObj) {
			var oOptionsDiv = document.getElementById("optionsDiv");
			var oButtonDiv= document.getElementById("buttonsDiv");
			oButtonDiv.style.display = "none";
			if (oOptionsDiv.style.display == "none") {
				oOptionsDiv.style.display = "";
				pObj.value = pObj.value.substr(0, pObj.value.length-2) + "<<";
			} else {
				oOptionsDiv.style.display = "none";
				pObj.value = pObj.value.substr(0, pObj.value.length-2) + ">>";
			}
			oButtonDiv.style.display = "";
			return (false);
		}

		function displayAuthentication() {
			var oAuthList = document.getElementById("listAuthentication");
			var oLogin = document.getElementById("txtLogin");
			var oPwd = document.getElementById("txtPassword");
			if (oAuthList.value == "windows") {
				oLogin.value = "";
				oPwd.value = "";
				oLogin.disabled = true;
				oPwd.disabled = true;
			} else {
				oLogin.disabled = false;
				oPwd.disabled = false;
			}
			return (false);
		}
	//-->
	</script>

	<form runat="server" id="mainForm">
		
		<div id="connDlgBox">

			<div id="headerDiv"><img id="headerDlgBoxImg" width="400" height="80" alt="myLittleAdmin" runat="server" /></div>

			<div id="serverDiv">
				<fieldset>
					<legend id="legendServer" runat="server">Server</legend>
					<asp:PlaceHolder id="PHServerName" runat="server" />

<label for="txtDatabase" id="labelDatabase" class="logon" runat="server">Database:</label>
<asp:TextBox id="txtDatabase" class="mediumcontrol" runat="server" />

					<label for="listAuthentication" id="labelAuthentication" class="logon" runat="server">Authentication:</label>
					<asp:DropDownList id="listAuthentication" class="mediumcontrol" runat="server" />
					<br clear="all"/>
					<label for="txtLogin" id="labelLogin" class="logon" runat="server">Login:</label>
					<asp:TextBox id="txtLogin" class="mediumcontrol" runat="server" />
					<br clear="all"/>
					<label for="txtPassword" id="labelPassword" class="logon" runat="server">Password:</label>
					<asp:TextBox id="txtPassword" textmode="password" class="mediumcontrol" runat="server" />
					<br clear="all"/>
				</fieldset>
			</div>

			<div id="optionsDiv" style="display: none;">
				<fieldset>
					<legend id="legendProperties" runat="server">Connection properties</legend>
					<label for="listProtocol" id="labelProtocol" class="logon" runat="server">Network protocol:</label>
					<asp:DropDownList id="listProtocol" class="mediumcontrol" runat="server" />
					<br clear="all"/>
					<label for="txtPacketSize" id="labelPacketSize" class="logon" runat="server">Network packet size:</label>
					<asp:TextBox id="txtPacketSize" class="mediumcontrol" runat="server" /> <span id="spanBytes" runat="server">bytes</span>
					<br clear="all"/>
					<label for="txtConnectionTimeOut" id="labelConnTimeOut" class="logon" runat="server">Connection time-out:</label>
					<asp:TextBox id="txtConnectionTimeOut" class="mediumcontrol" runat="server" /> <span id="spanSeconds1" runat="server">seconds</span>
					<br clear="all"/>
					<label for="txtExecutionTimeOut" id="labelExecTimeOut" class="logon" runat="server">Execution time-out:</label>
					<asp:TextBox id="txtExecutionTimeOut" class="mediumcontrol" runat="server" /> <span id="spanSeconds2" runat="server">seconds</span>
					<br clear="all"/>
					<label for="checkEncryptConnection" id="labelEncryptConn"  class="logon" runat="server">Encrypt connection:</label>
					<asp:CheckBox id="checkEncryptConnection" runat="server" />
					<br clear="all"/>
				</fieldset>
			</div>

			<div id="buttonsDiv" class="btnDlgDiv">
				<asp:Button id="btnConnect" onclick="btnConnect_Click" Text="Connect" runat="server" />
				<input type="button" id="btnOptions" value="Options &gt;&gt;" runat="server" />
			</div>

		</div>

		<div id="zInfo" runat="server" />

	</form>
</body>
</html>
