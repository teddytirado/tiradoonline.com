function content_resize() {
	var oHeaderDiv = document.getElementById("zPageHeader");
	var oContentDiv =  document.getElementById("zPageContent_Container");
	var nDocumentHeight = document.documentElement.clientHeight;
	var nHeaderHeight = oHeaderDiv.clientHeight;
	var nContentHeight = nDocumentHeight - nHeaderHeight - 12;
	oContentDiv.style.height = nContentHeight + "px";
	oContentDiv.style.width = oHeaderDiv.clientWidth - 15 + "px"; // "100%";
	return (true);
}

window.onresize = content_resize;