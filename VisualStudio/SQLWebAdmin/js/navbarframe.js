var navbar_sFramesetId = "mla_frameset";
var navbar_sNavFrameId = "navbar";
var navbar_sNavDivId = "oNavbar";
var navbar_sReduceImgId = "navbar_reduce";
var navbar_nParentHeight = 24;
var navbar_nParentCount = 8
var navbar_nFrameWidthOpened = 350;
var navbar_nFrameWidthReduced = 20;
//var navbar_sReduceImgSrc = "../images/navbar/reducenavbar.gif";
//var navbar_sOpenImgSrc = "../images/navbar/opennavbar.gif";

function reduceFrame() {
	var oFrameset = parent.document.getElementById(navbar_sFramesetId);
	navbar_displayBar(navbar_sNavDivId, oFrameset.reduced);
	oFrameset.setAttribute("cols", ((oFrameset.reduced) ? navbar_nFrameWidthOpened : navbar_nFrameWidthReduced) + ",*");
	document.getElementById(navbar_sReduceImgId).src = ((oFrameset.reduced) ? navbar_sReduceImgSrc : navbar_sOpenImgSrc);
	oFrameset.reduced = !(oFrameset.reduced) ;
	return (true);
}

function changeClassProperty(pClass, pProperty, pValue) {
	var aDiv = document.getElementsByTagName("div");
	for (var i = 0; i < aDiv.length; i++)
		if (aDiv[i].className == pClass)
			eval("aDiv[i].style." + pProperty + " = \"" + pValue + "\";");
	return (true);
}

function navbar_resize() {
	var nHeight = document.documentElement.clientHeight;
	var nChildrenHeight = Math.max(2 * navbar_nParentHeight, nHeight - (navbar_nParentHeight * navbar_nParentCount) - 2);
	changeClassProperty("navbar", "height", nHeight + "px");
	changeClassProperty("navbarChildren", "height", nChildrenHeight + "px");
	return (true);
}
