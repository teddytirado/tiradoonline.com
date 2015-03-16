<%@ Control language="c#" Inherits="MyLittleAdmin.WaitingBox"  ClassName="WaitingBox" %>

<div id="WaitingBox">
	<div id="WaitingBoxCache"> </div>
	<div id="WaitingBox2">
		<iframe class="waitingBoxIFrame"></iframe>
		<div class="waitingBoxDiv">
			<div id="zMessage" runat="server" />
		</div>
	</div>
</div>