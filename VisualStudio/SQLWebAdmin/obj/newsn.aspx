<%@ Page language="c#" Inherits="mla_gui.NewSynonym"  %>

<%@ Register TagPrefix="MyLittleAdmin" TagName="MetaHeader" Src="../common/metaheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" TagName="PageHeader" Src="../common/pageheader.ascx" %>
<%@ Register TagPrefix="MyLittleAdmin" Namespace="MyLittleAdmin" Assembly="mla_sql" %>

<MyLittleAdmin:MetaHeader id="metaheader" DefaultXmlFile="../xml/defaultheader.xml" runat="server" />

<body onload="content_resize();">	

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
							id="fSynonymName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>					
						<MyLittleAdmin:MlaFormElement
							id="fSynonymSchema"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="DropDownList"
							runat="server"
						/>

						<br /><br />

						<MyLittleAdmin:MlaFormElement
							id="fServerName"
							CssClass="mediumcontrol"
							LabelCssClass="classic"
							Type="TextBox"
							runat="server"
						/>
						
						<label id="lDatabaseName" for="fDatabaseName" class="classic" runat="server"></label>
						<asp:DropDownList 
							id="fDatabaseName" 
							class="mediumcontrol" 
							AutoPostBack="true"
							OnSelectedIndexChanged="ChangeDatabase"
							runat="server" 
						/><br clear="all" />

						<label id="lSchema" for="fSchema" class="classic" runat="server"></label>
						<asp:DropDownList 
							id="fSchema" 
							class="mediumcontrol" 
							AutoPostBack="true"
							OnSelectedIndexChanged="ChangeSchema"
							runat="server" 
						/><br clear="all" />

						<label id="lObjectType" for="fObjectType" class="classic" runat="server"></label>
						<asp:DropDownList 
							id="fObjectType" 
							class="mediumcontrol" 
							AutoPostBack="true"
							OnSelectedIndexChanged="ChangeObjectType"
							runat="server" 
						/><br clear="all" />

						<MyLittleAdmin:MlaFormElement
							id="fObjectName"
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