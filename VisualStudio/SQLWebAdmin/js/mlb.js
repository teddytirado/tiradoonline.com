//
// myLittleBox v1.0
//
// Web site : http://www.mylittletools.net
//	 Email : webmaster@mylittletools.net
//	 (c) 2000-2005, Elian Chrebor, myLittleTools.net,  All rights reserved.
//
// This file is NOT freeware.
//	 You cannot re-distribute it without any agreement with myLittleTools.net.
// Contact webmaster@mylittletools.net for more info.
//
//	 Logs :
//		20060118 : first release
//


Mouse = {}; 
Mouse.doc = document; 
Mouse.MouseMoveHandler = function (e) { 
     e = e || window.event; 
     Mouse.x = (Mouse.doc.body.scrollLeft || 0) + e.clientX; 
     Mouse.y = (Mouse.doc.body.scrollTop || 0) + e.clientY; 
     Mouse.currentTarget = e.target || e.srcElement; 
     return true; 
}; 
if (Mouse.doc.attachEvent) 
   Mouse.doc.attachEvent("onmousemove",Mouse.MouseMoveHandler); 
else if (Mouse.doc.addEventListener) 
   Mouse.doc.addEventListener("mousemove",Mouse.MouseMoveHandler,false); 


var mlb_objects = new Array();

function myLittleBox(pPostbackUrl, pHeight, pWidth) {
	this.div = "";
	this.iframe = "";
	if (pPostbackUrl) this.postbackurl = pPostbackUrl; else this.postbackurl = "";
	if (pHeight) this.height = pHeight; else this.height = "130px";
	if (pWidth) this.width = pWidth; else this.width = "150px";

	this.init = init;
	this.showBox = showBox;
	this.hideBox = hideBox;
	this.top = _top;
	this.left = _left;

	this.init();
	mlb_objects[mlb_objects.length] = this;
}

function createBox() {
	var _iframe = document.createElement("iframe");
	_iframe.frameborder=0;
	_iframe.className = "mlb_iframe";
	_iframe.style.display = "none";
	document.body.appendChild(_iframe);
	var _div = document.createElement("div");
	_div.className = "mlb_div";
	_div.style.display = "none";
	_div.onmousedown = 
	_div.onmouseup = 
	_div.onmouseover = function (e) { };

	document.body.appendChild(_div);
	var oThis;
	for (var i = 0; i < mlb_objects.length; i++) {
		oThis = mlb_objects[i];
		oThis.iframe = _iframe;
		oThis.div = _div
	}
}

function init() {
	addEvent(window, "load", createBox);
}

function showBox(pParam) {
	var sCompleteUrl = this.postbackurl + ((pParam) ? "?" + pParam : "");
	this.div.innerHTML = "retrieving data...";
	this.div.style.top = this.top() + "px";
	this.div.style.left = this.left() + "px";
	this.div.style.height = this.height;
	this.div.style.width = this.width;
	this.iframe.style.width = this.div.style.width;
	this.iframe.style.height = this.div.style.height; 
	this.iframe.style.top = this.div.style.top;
	this.iframe.style.left = this.div.style.left;
	this.iframe.style.zIndex = 1; 
	this.iframe.style.display = "none"; 
	this.div.style.display = "";
	this.iframe.style.display = "block";
	addEvent(document.getElementById("zFullZone"), "mousedown", _hideBox);

	xPostBack(sCompleteUrl, true, this.div);

	return false;
}

function hideBox(e) {
	this.div.style.display = "none";
	this.iframe.style.display = "none"; 
}

function _top() {
	var nTop = Mouse.y;
	if (nTop + parseInt(this.height) > document.body.clientHeight) nTop = nTop - parseInt(this.height) ;
	return (nTop);
}

function _left() {
	var nLeft = Mouse.x;
	return (nLeft);
}

// *********** //

function _hideBox() {
	var oThis = mlb_objects[0];
	oThis.hideBox();
	removeEvent(document.getElementById("zFullZone"), "mousedown", _hideBox);
	return (false);
}