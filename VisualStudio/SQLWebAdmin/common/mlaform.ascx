
<%@ Control language="c#" Inherits="MyLittleAdmin.MlaForm"  ClassName="MlaForm" %>

<asp:Repeater id="rptRow" runat="server">
	<HeaderTemplate>
		 <table class="formList" cellspacing="0" rules="all">
			<thead>
				<tr><td class="formHeaderCell">Column</td><td class="objListHeaderCell">Value</td></tr>
			</thead>
			<tbody>
	</HeaderTemplate>
	<ItemTemplate>
		 <tr class="formItemRow">
			<td class="formLabelCell"> <asp:PlaceHolder id="oLabelElt" Runat="server"/> </td>
			<td class="formElementCell"> <asp:PlaceHolder id="oFormElt" Runat="server"/> </td>
		 </tr>
	</ItemTemplate>
	<AlternatingItemTemplate>
		 <tr class="formAltItemRow">
			<td class="formLabelCell"> <asp:PlaceHolder id="oLabelElt" Runat="server"/> </td>
			<td class="formElementCell"> <asp:PlaceHolder id="oFormElt" Runat="server"/> </td>
		 </tr>
	</AlternatingItemTemplate>
	<FooterTemplate>
			</tbody>
		</table>
	</FooterTemplate>
</asp:Repeater>					

<div id="zFormButton">
	<asp:Button Text="Cancel" id="btnCancel" class="mediumcontrol" Runat="server" />
	<asp:Button Text="Submit" id="btnSubmit" class="mediumcontrol" Runat="server" />
</div>