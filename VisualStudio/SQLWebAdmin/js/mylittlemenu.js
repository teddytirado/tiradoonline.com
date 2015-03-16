//
// myLittleMenu v1.0
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
//		20051213 : first release
//

var mlm_objects = new Array();
var mlm_HttpUrlError = "URL that was requested does not exist.";

function myLittleMenu(pRemoteUrl) {
	this.remoteUrl = pRemoteUrl;
	this.div = "";
	this.iframe = "";
	this.http = getHttpObject();
	this.handleHttpResponse = handleHttpResponse;
	this.init = init;
	this.init();
	mlm_objects[mlm_objects.length] = this;
}

function createMenuDiv() {
	var _iframe = document.createElement("iframe");
	_iframe.frameborder=0;
	_iframe.className = "mlm_iframe";
	_iframe.style.display = "none";
	document.body.appendChild(_iframe);

	var _div = document.createElement("div");
	_div.className = "mlm_menu";
	_div.style.display = "none";
	document.body.appendChild(_div);

	var oThis;
	for (var i = 0; i < mls_objects.length; i++) {
		oThis = mls_objects[i];
		oThis.iframe = _iframe;
		oThis.div = _div
	}
}

function init() {
	window.onload = createMenuDiv;
}
