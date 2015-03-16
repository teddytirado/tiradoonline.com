//
// myLittleTree v2.0
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
//		20071210 : displays only the N first items and add a (display more) link
//		20050829 : dynamic loading using xmlhttp
//		20050826 : xhtml generation
//		20020701 : expandNode function added
//		20020618 : first release
//


// Images
var mlt_blank = new Image(16,16);
var mlt_exp = new Image(16,16);
var mlt_exp_last = new Image(16,16);
var mlt_red = new Image(16,16);
var mlt_red_last = new Image(16,16);
var mlt_node = new Image(16,16);
var mlt_node_last = new Image(16,16);
var mlt_line = new Image(16,16);
var mlt_loading = new Image(16, 16);

// String
var mlt_Error = "Cannot initialize myLittleTree object. Dynamic navigation is disabled.";
var mlt_Alt = "Click to expand or reduce."
var mlt_dcPrefix = "dc_";
var mlt_Loading = "Retrieving data...";
var mlt_DisplayAll = "(display all)"

// config
var mltInitialDisplayCount = 50;

// checks browser
var mlt_DOM = (document.getElementById) ? true : false;
var mlt_NS4 = (document.layers) ? true : false;
var mlt_IE = (document.all) ? true : false;
var mlt_IE4 = mlt_IE && !mlt_DOM;
var mlt_Mac = (navigator.appVersion.indexOf("Mac") != -1);
var mlt_IE4M = mlt_IE4 && mlt_Mac;
var mlt_Opera = (navigator.userAgent.indexOf("Opera")!=-1);
var mlt_isOK = !mlt_Opera && !mlt_IE4M && (mlt_DOM);

// xmlhttp
var mlt_synchro = true;

// Constructor
function myLittleTree_Folder(pId, pFatherId, pDescription, pIcon, pLink, pTarget, pCSSClass) {
	this.fatherId = pFatherId;
	this.id = pId;
	this.description = pDescription;
	this.link = pLink;
	this.target = pTarget;
	this.icon = pIcon;
	this.CSSClass = pCSSClass;
	this.isOpened = false;
	this.children = new Array();
	this.imageopen = "";
	this.imageclose = "";
	this.isDynamic = false;
	this.hasBeenLoaded = false;
	this.contentUrl = "";
	this.lineStatus = "";
	this.fullDisplay = false;
	this.isDisplayAllChildren = false;
}

function myLittleTree(pLitteralName, pImageFolder) {
	if (arguments.length > 0) this.litteralName = pLitteralName 
	else {
		alert(mlt_Error);
		mlt_isOK = false;
	}
	this.imageFolder = ((arguments.length > 1) ? pImageFolder : "");
	this.folderCount = 0;
	this.root = "";
	this.index = new Array();
	this.tree = new Array();
	this.addFolder = mlt_addFolder;
	this.addDynamicFolder = mlt_addDynamicFolder;
	this.createHTML = mlt_createHTML;
	this.clickNode = mlt_clickNode;
	this.expandNode = mlt_expandNode;
	this.addDynamicItem = mlt_addDynamicItem;
	this.renderDynamicFolder = mlt_renderDynamicFolder;
	this.reloadDynamicFolder = mlt_reloadDynamicFolder;
	this.displayAllChildren = mlt_displayAllChildren;
	this.addDisplayAll = mlt_addDisplayAll;
	mlt_setImages(this.imageFolder);
}

// defines images
function mlt_setImages(pImageFolder) {
	mlt_blank.src = pImageFolder + "mlt_blank.gif";
	mlt_exp.src = pImageFolder + "mlt_exp.gif";
	mlt_exp_last.src = pImageFolder + "mlt_exp_last.gif";
	mlt_red.src = pImageFolder + "mlt_red.gif";
	mlt_red_last.src = pImageFolder + "mlt_red_last.gif";
	mlt_node.src = pImageFolder + "mlt_node.gif";
	mlt_node_last.src = pImageFolder + "mlt_node_last.gif";
	mlt_line.src = pImageFolder + "mlt_line.gif";
	mlt_loading.src = pImageFolder + "mlt_loading.gif";
}

// Adds a Node
function mlt_addFolder(pId, pFatherId, pDescription, pIcon, pLink, pTarget, pCSSClass) {
	var myIcon, myLink, myTarget, myCSSClass;
	myIcon = ((arguments.length > 3) ? pIcon : "");
	myLink = ((arguments.length > 4) ? pLink : "");
	myTarget = ((arguments.length > 5) ? pTarget : "");
	myCSSClass = ((arguments.length > 6) ? pCSSClass : "");
	this.tree[this.folderCount] = new myLittleTree_Folder(pId, pFatherId, pDescription, myIcon, myLink, myTarget, myCSSClass);
	this.index[pId] = this.folderCount++;
	if (pFatherId != null) this.tree[this.index[pFatherId]].children[this.tree[this.index[pFatherId]].children.length] = pId 
	else this.root = pId;
	return (true);
}

// Adds a "dynamic" node
function mlt_addDynamicFolder(pContentUrl, pId, pFatherId, pDescription, pIcon, pLink, pTarget, pCSSClass) {
	var myIcon, myLink, myTarget, myCSSClass;
	myIcon = ((arguments.length > 4) ? pIcon : "");
	myLink = ((arguments.length > 5) ? pLink : "");
	myTarget = ((arguments.length > 6) ? pTarget : "");
	myCSSClass = ((arguments.length > 7) ? pCSSClass : "");
	this.addFolder(pId, pFatherId, pDescription, myIcon, myLink, myTarget, myCSSClass);
	this.tree[this.index[pId]].isDynamic = true;
	this.tree[this.index[pId]].contentUrl = pContentUrl;
	this.tree[this.folderCount] = new myLittleTree_Folder(mlt_dcPrefix + pId, pId, "", "", "", "", "");
	this.index[mlt_dcPrefix + pId] = this.folderCount++;
	this.tree[this.index[pId]].children[this.tree[this.index[pId]].children.length] = mlt_dcPrefix + pId;
	return (true);
}

// Opens/Closes a Node
function mlt_clickNode(pNodeId) {
	var myFolder, myImg;
	var myNode = this.tree[this.index[pNodeId]];
	myNode.isOpened = !(myNode.isOpened);
	document.getElementById("img_" + myNode.id).src = ((myNode.isOpened) ? myNode.imageclose : myNode.imageopen);
	if (myNode.isDynamic) {
		if (myNode.isOpened) mlt_loadContent(myNode);
		else document.getElementById(mlt_dcPrefix + myNode.id).style.display = "none";
	}
	for (var i = 0; i < myNode.children.length; i++) {
		if (myNode.isOpened) {
			document.getElementById(myNode.children[i]).style.display = "block";
			myFolder = this.tree[this.index[myNode.children[i]]];			
			myImg = document.getElementById("img_" + myNode.children[i]);
			if (myImg) myImg.src = this.tree[this.index[myNode.children[i]]].imageopen;
		} else {
			if (this.tree[this.index[myNode.children[i]]].isOpened) this.clickNode(myNode.children[i]);
			document.getElementById(myNode.children[i]).style.display = "none";
		}
	}
	return (true);
}

// Expands a full Node
function mlt_expandNode(pNodeId) {
	if (! mlt_isOK) return (false);
	var myNode = this.tree[this.index[pNodeId]];
	myNode.isOpened = true;
	document.getElementById("img_" + myNode.id).src = myNode.imageclose;
	for (var i = 0; i < myNode.children.length; i++) {
		document.getElementById(myNode.children[i]).style.display = "block";
	}
	return (true);
}

// computes HTML code
function mlt_createHTML() {
	var myIcon = "";
	if (this.tree[this.index[this.root]].icon != "") myIcon = "<img src=\"" + this.imageFolder + this.tree[this.index[this.root]].icon + "\" style=\"border: 0; vertical-align: top;\" alt=\"myLittleTree\" /> ";
	var myHTML = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"";
	if (mlt_isOK) myHTML += " style=\"display: block;\"";
	myHTML += " id=\"" + this.root + "\" summary=\"" + this.root + "\"><tr><td nowrap=\"nowrap\">&nbsp;</td><td nowrap=\"nowrap\"";
	myHTML += ((this.tree[this.index[this.root]].CSSClass == "") ? ">" : " class=\"" + this.tree[this.index[this.root]].CSSClass + "\">");
	myHTML += myIcon;
	if (this.tree[this.index[this.root]].link != "") {
		myHTML += "<a href=\"" + this.tree[this.index[this.root]].link + "\"";
		if (this.tree[this.index[this.root]].CSSClass != "") myHTML += " class=\"" + this.tree[this.index[this.root]].CSSClass + "\"";
		myHTML += ((this.tree[this.index[this.root]].target == "") ? ">" : " target=\"" + this.tree[this.index[this.root]].target + "\">");
	}
	myHTML += this.tree[this.index[this.root]].description;
	if (this.tree[this.index[this.root]].link != "") myHTML += "</a>";
	myHTML += "</td></tr></table>\n";
	myHTML += mlt_createNodeHTML(this, this.root, "");
	return (myHTML);
}

function mlt_createNodeHTML(pObj, pNodeId, pLineStatus) {
	var myNode, myIndex, myHTML = "", myCollapse, j, myLineStatus, myIcon, myStyle, myAlt;
	myNode = pObj.tree[pObj.index[pNodeId]];
	if (myNode.isDynamic) {
		myHTML += "<div id=\"" + mlt_dcPrefix + myNode.id + "\" style=\"display:none; \"></div>";
	} else {
		for (var i = 0; i < myNode.children.length; i++) {
			myIndex = pObj.index[myNode.children[i]];
			myStyle = ((pNodeId == pObj.root) ? "block" : "none");
			if (pObj.tree[myIndex].children.length > 0) {
				if (i == myNode.children.length-1) {
					pObj.tree[myIndex].imageopen = mlt_exp_last.src;
					pObj.tree[myIndex].imageclose = mlt_red_last.src;
					myAlt = mlt_Alt;
				} else {
					pObj.tree[myIndex].imageopen = mlt_exp.src;
					pObj.tree[myIndex].imageclose = mlt_red.src;
					myAlt = mlt_Alt;
				}
			} else {
				if (i == myNode.children.length-1) {
					pObj.tree[myIndex].imageopen = mlt_node_last.src;
					pObj.tree[myIndex].imageclose = mlt_node_last.src;
					myAlt = "";
				} else {
					pObj.tree[myIndex].imageopen = mlt_node.src;
					pObj.tree[myIndex].imageclose = mlt_node.src;
					myAlt = "";
				}
			}
			myCollapse = "<img src=\"" + mlt_blank.src + "\" style=\"border: 0;\" width=\"5\" alt=\"\" />";
			if (pLineStatus.length >= 1)
				for (j = 0; j < pLineStatus.length ; j++)
					myCollapse += ((pLineStatus.charAt(j) == "1") ? "<img src=\"" + mlt_blank.src + "\" style=\"border: 0;\" alt=\"\" />" : "<img src=\"" + mlt_line.src + "\" style=\"border: 0;\" alt=\"\" />");
			if (mlt_isOK) myCollapse += ((pObj.tree[myIndex].children.length > 0) ? "<a href=\"#\" onclick=\"" + pObj.litteralName + ".clickNode('" + pObj.tree[myIndex].id + "'); return false;\"><img src=\"" + pObj.tree[myIndex].imageopen + "\" style=\"border: 0;\" id=\"img_" + pObj.tree[myIndex].id + "\" alt=\"" + myAlt + "\" /></a>" : "<img src=\"" + pObj.tree[myIndex].imageopen + "\" style=\"border: 0;\" id=\"img_" + pObj.tree[myIndex].id + "\" alt=\"" + myAlt + "\" />");
			else myCollapse += "<img src=\"" + pObj.tree[myIndex].imageclose + "\" style=\"border: 0;\" id=\"img_" + pObj.tree[myIndex].id + "\" alt=\"" + myAlt + "\" />";
			myIcon = "";
			if (pObj.tree[myIndex].icon != "") myIcon = "<img src=\"" + pObj.imageFolder + pObj.tree[myIndex].icon + "\" style=\"border: 0; vertical-align: top;\" alt=\"myLittleTree\" />";
			myHTML += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"";
			if (mlt_isOK) myHTML += " style=\"display: " + myStyle + ";\"";
			myHTML += " ID=\"" + pObj.tree[myIndex].id + "\" summary=\"" + pObj.tree[myIndex].id + "\"><tr><td nowrap=\"nowrap\">" + myCollapse + "</td><td nowrap=\"nowrap\"";
			myHTML += ((pObj.tree[myIndex].CSSClass == "") ? ">" : " class=\"" + pObj.tree[myIndex].CSSClass + "\">");
			myHTML += myIcon + "&nbsp;";

			if (pObj.tree[myIndex].link != "") {
				myHTML += "<a href=\"" + pObj.tree[myIndex].link + "\"";
				if (pObj.tree[myIndex].CSSClass != "") myHTML += " class=\"" + pObj.tree[myIndex].CSSClass + "\"";
				myHTML += ((pObj.tree[myIndex].target == "") ? ">" : " target=\"" + pObj.tree[myIndex].target + "\">");
			} else if (pObj.tree[myIndex].isDisplayAllChildren) {
				myHTML += "<a href=\"#\" onclick=\"" + pObj.litteralName + ".displayAllChildren('" + pObj.tree[myIndex].fatherId + "'); return false;\"";
				if (pObj.tree[myIndex].CSSClass != "") myHTML += " class=\"" + pObj.tree[myIndex].CSSClass + "\"";
				myHTML += ((pObj.tree[myIndex].target == "") ? ">" : " target=\"" + pObj.tree[myIndex].target + "\">");
			}

			myHTML += pObj.tree[myIndex].description;
			if (pObj.tree[myIndex].link != "") myHTML += "</a>";

			myHTML += "</td></tr></table>\n";
			if (pObj.tree[myIndex].children.length > 0) {
				myLineStatus = pLineStatus;
				myLineStatus += ((i == myNode.children.length-1) ? "1" : "0");
				pObj.tree[myIndex].lineStatus = myLineStatus;
				myHTML += mlt_createNodeHTML(pObj, pObj.tree[myIndex].id,  pObj.tree[myIndex].lineStatus);
			}
		}
	}
	return (myHTML);
}

// loads dynamic content using xmlhttp
function mlt_loadContent(pFolder) {
	if (mlt_connect) {
		alert(mlt_HttpError);
		return (false);
	}
	var myDiv = document.getElementById(mlt_dcPrefix + pFolder.id);
	myDiv.style.display = "block";
	if (! pFolder.hasBeenLoaded) {
		myDiv.innerHTML += "<p class=\"treeviewLoading\">" + mlt_Loading + " <img src=\"" + mlt_loading.src + "\"/></p>";
		pFolder.children = Array();
		xPostBack(pFolder.contentUrl, mlt_synchro);
	}
}

function mlt_addDynamicItem(pId, pFatherId, pDescription, pIcon, pLink, pTarget, pCSSClass, pContentURL) {
	var nChildrenCount = this.tree[this.index[pFatherId]].children.length;
	var bFullDisplay = this.tree[this.index[pFatherId]].fullDisplay;
	if ( bFullDisplay || nChildrenCount < mltInitialDisplayCount) {
		var myContentURL = ((arguments.length > 7) ? pContentURL : "");
		if (myContentURL == "") this.addFolder(pId, pFatherId, pDescription, pIcon, pLink, pTarget, pCSSClass);
		else this.addDynamicFolder(myContentURL, pId, pFatherId, pDescription, pIcon, pLink, pTarget, pCSSClass);
		return (true);
	} else if ( nChildrenCount == mltInitialDisplayCount) {
		 this.addDisplayAll(pFatherId);
		 return (false);
	}
	return (false);
}

function mlt_addDisplayAll(pFatherId) {
	var sId = "da_" + pFatherId;
	this.tree[this.folderCount] = new myLittleTree_Folder(sId, pFatherId, mlt_DisplayAll, "more.gif", "", "", "");
	this.tree[this.folderCount].	isDisplayAllChildren = true;
	this.index[sId] = this.folderCount++;
	this.tree[this.index[pFatherId]].children[this.tree[this.index[pFatherId]].children.length] = sId; 
	return (true);
}


function mlt_renderDynamicFolder(pNodeId) {
	var oNode = this.tree[this.index[pNodeId]];
	oNode.isDynamic = false;
	var sHtml = mlt_createNodeHTML(this, oNode.id, oNode.lineStatus) ;
	document.getElementById(mlt_dcPrefix + pNodeId).innerHTML = sHtml;
	this.expandNode(pNodeId);
	oNode.isDynamic = true;
	oNode.hasBeenLoaded = true;
}

function mlt_reloadDynamicFolder(pNodeId) {
	mlt_synchro = false;
	var oNode = this.tree[this.index[pNodeId]];
	if (oNode.isDynamic) { oNode.hasBeenLoaded = false; }
	oNode.isOpened = false;
	oNode.fullDisplay = true;
	this.clickNode(oNode.id);
	mlt_synchro = true;
}

function mlt_displayAllChildren(pNodeId) {
	var oNode = this.tree[this.index[pNodeId]];
	oNode.hasBeenLoaded = false;
	oNode.isOpened = false;
	oNode.fullDisplay = true;
	this.clickNode(oNode.id);
}