
<%@ Control language="c#" Inherits="MyLittleAdmin.MlaProp"  ClassName="MlaProp" %>

<asp:Repeater id="rptProp" runat="server">
	<HeaderTemplate>
		 <table class="propList" cellspacing="0" rules="all">
			<tbody>
	</HeaderTemplate>
	<ItemTemplate>
		 <tr class="propItemRow" id="oRowElt" Runat="server">
			<td class="propTreeCell"> <asp:PlaceHolder id="oTreeElt" Runat="server"/> </td>
			<td class="propLabelCell"> <asp:PlaceHolder id="oLabelElt" Runat="server"/> </td>
			<td class="propElementCell"> <asp:PlaceHolder id="oFormElt" Runat="server"/> </td>
		 </tr>
	</ItemTemplate>
	<FooterTemplate>
			</tbody>
		</table>
	</FooterTemplate>
</asp:Repeater>					

