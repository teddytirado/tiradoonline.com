var mla_currentCell = null;

function getContainerWidth() {
	return (document.getElementById("zPageContent_Container").clientWidth);
}

function getCell(pCellObj) {
	if (pCellObj.nodeName == "TD") return (pCellObj)
	var oCell = pCellObj.parentNode;
	while (oCell.nodeName != "TD")
		oCell = oCell.parentNode;
	return (oCell);
}

function getRow(pCell) {
	return (pCell.parentNode);
}

function getExtPropName(pCellObj) {
	var oCell = getCell(pCellObj);
	var oRow = getRow(oCell);
	// gets 2nd cell
	var oTmpCell, o2ndCell;
	var j = 0;
	for (var i = 0; i < oRow.childNodes.length; i++) {
		if (oRow.childNodes[i].nodeName == "TD") {
			oTmpCell = oRow.childNodes[i];
			j++;
			if (j==2) {
				o2ndCell = oTmpCell;
				break;
			}
		}
	}
	var sName = "";
	if (o2ndCell.title != "") sName = ltrim(o2ndCell.title);
	else	sName = (o2ndCell.innerText) ? ltrim(o2ndCell.innerText) : ltrim(o2ndCell.textContent);
	return (sName);
}

function getTable(pCell) {
	var oTr = getRow(pCell);
	var oTable = oTr.parentNode;
	while (oTable.nodeName != "TABLE") {
		oTable = oTable.parentNode;
		if (oTable == null) break;
	}
	return (oTable);
}

function getPKInput(pCell) {
	// gets 1st cell
	var oRow = pCell.parentNode;
	var o1stCell;
	for (var i = 0; i < oRow.childNodes.length; i++) {
		if (oRow.childNodes[i].nodeName == "TD") {
			o1stCell = oRow.childNodes[i];
			break;
		}
	}
	var oInput;
	for (var i = 0; i < o1stCell.childNodes.length; i++) {
		if (o1stCell.childNodes[i].nodeName == "INPUT") {
			oInput = o1stCell.childNodes[i];
			break;
		}
	}
	return (oInput);
}

function mla_editCell(pCell, pColumnName, pType, pDbId, pObjId) {
	// we cannot edit more than one cell once
	if (mla_currentCell != null) return (false);
	// stores initial state
	mla_currentCell = pCell;
	pCell.columnName = pColumnName;
	pCell.columnType = pType;
	pCell.DbId = pDbId;
	pCell.ObjId = pObjId;
	if (pCell.title != "") pCell.initialText = ltrim(pCell.title)
	else	pCell.initialText = (pCell.innerText) ? ltrim(pCell.innerText) : ltrim(pCell.textContent);
	if (pCell.firstChild.nodeName == "SPAN" && pCell.initialText == "NULL") pCell.initialText = "";
	pCell.initialHtml = pCell.innerHTML;
	// creates an input box
	var oInput = document.createElement("input");
	oInput.setAttribute("type", "text");
	oInput.setAttribute("id", "mla__editcell__input");
	oInput.setAttribute("class", "cellEdit"); oInput.setAttribute("className", "cellEdit");
	oInput.setAttribute("value", pCell.initialText);
	oInput.width = pCell.clientWidth - 13;	
	// manages event
	oInput.onmousedown = function (e) { window.event.cancelBubble = true; }
	oInput.onkeydown = function(e) { 
		nKey = (window.event) ? window.event.keyCode : e.keyCode ;
		if (nKey == 27 || nKey == 13) _editCell(nKey);
	}
	addEvent(document.getElementById("zFullZone"), "mousedown", _editCell);
	// displays the input box
	mla_currentCell.containerWidth = getContainerWidth();
	for (var i = 1; i < pCell.childNodes.length; i++)
		pCell.removeChild(pCell.childNodes[i]);
	pCell.replaceChild(oInput, pCell.firstChild);
	document.getElementById("zPageContent_Container").width = pCell.containerWidth ;
	oInput.focus(); 	oInput.select();
}

function mla_editExtProp(pCell, pDbId, pExtPropName, pLevel0Type, pLevel0Name, pLevel1Type, pLevel1Name, pLevel2Type, pLevel2Name) {
	// we cannot edit more than one cell once
	if (mla_currentCell != null) return (false);
	// stores initial state
	mla_currentCell = pCell;
	pCell.DbId = pDbId;
	pCell.ExtPropName = pExtPropName;
	pCell.Level0Type = pLevel0Type;
	pCell.Level0Name = pLevel0Name;
	pCell.Level1Type = pLevel1Type;
	pCell.Level1Name = pLevel1Name;
	pCell.Level2Type = pLevel2Type;
	pCell.Level2Name = pLevel2Name;
	if (pCell.title != "") pCell.initialText = ltrim(pCell.title)
	else	pCell.initialText = (pCell.innerText) ? ltrim(pCell.innerText) : ltrim(pCell.textContent);
	if (pCell.firstChild.nodeName == "SPAN" && pCell.initialText == "NULL") pCell.initialText = "";
	pCell.initialHtml = pCell.innerHTML;
	// creates an input box
	var oInput = document.createElement("input");
	oInput.setAttribute("type", "text");
	oInput.setAttribute("id", "mla__editcell__input");
	oInput.setAttribute("class", "cellEdit"); oInput.setAttribute("className", "cellEdit");
	oInput.setAttribute("value", pCell.initialText);
	oInput.width = pCell.clientWidth - 13;	
	// manages event
	oInput.onmousedown = function (e) { window.event.cancelBubble = true; }
	oInput.onkeydown = function(e) { 
		nKey = (window.event) ? window.event.keyCode : e.keyCode ;
		if (nKey == 27 || nKey == 13) _editExtProp(nKey);
	}
	addEvent(document.getElementById("zFullZone"), "mousedown", _editCell);
	// displays the input box
	mla_currentCell.containerWidth = getContainerWidth();
	for (var i = 1; i < pCell.childNodes.length; i++)
		pCell.removeChild(pCell.childNodes[i]);
	pCell.replaceChild(oInput, pCell.firstChild);
	document.getElementById("zPageContent_Container").width = pCell.containerWidth ;
	oInput.focus(); 	oInput.select();
}

function mla_deleteRow(pCellObj, pDbId, pObjId) {
	// we cannot edit more than one cell once
	if (mla_currentCell != null) return (false);
	var oCell = getCell(pCellObj);	
	var oInput = getPKInput(oCell) ;
	if (confirm("Do you really wanna drop this row ?"))	{
		mla_currentCell = oCell;
		var sParam = "d=" + pDbId + "&id=" + pObjId + "&pk=" + encodeURIComponent(oInput.value);
		xPostBack2("delete.aspx", true, null, sParam);
	}
	return (false);
}

function mla_deleteExtProp(pCellObj, pDbId, pLevel0Type, pLevel0Name, pLevel1Type, pLevel1Name, pLevel2Type, pLevel2Name) {
	// we cannot edit more than one cell once
	if (mla_currentCell != null) return (false);
	var oCell = getCell(pCellObj);	
	if (confirm("Do you really wanna drop this row ?"))	{
		mla_currentCell = oCell;
		var sParam = "d=" + pDbId + "&n=" + encodeURIComponent(getExtPropName(pCellObj))
				+ "&l0t=" + encodeURIComponent(pLevel0Type) + "&l0n=" + encodeURIComponent(pLevel0Name)
				+ "&l1t=" + encodeURIComponent(pLevel1Type) + "&l1n=" + encodeURIComponent(pLevel1Name)
				+ "&l2t=" + encodeURIComponent(pLevel2Type) + "&l2n=" + encodeURIComponent(pLevel2Name)
			;
		xPostBack2("ep_delete.aspx", true, null, sParam);
	}
	return (false);
}

function mla_editRow(pCellObj, pDbId, pObjId) {
	var oCell = getCell(pCellObj);	
	var oInput = getPKInput(oCell) ;
	document.location = "row.aspx?d=" + pDbId + "&id=" + pObjId + "&pk=" + encodeURIComponent(oInput.value);
	return (false);
}

function mla_modifyExtProp(pCellObj, pDbId, pLevel0Type, pLevel0Name, pLevel1Type, pLevel1Name, pLevel2Type, pLevel2Name, pAdditionalParam) {
	var oCell = getCell(pCellObj);	
	document.location = "newextprop.aspx?" 
				+ "d=" + pDbId + "&n=" + encodeURIComponent(getExtPropName(pCellObj))
				+ "&l0t=" + encodeURIComponent(pLevel0Type) + "&l0n=" + encodeURIComponent(pLevel0Name)
				+ "&l1t=" + encodeURIComponent(pLevel1Type) + "&l1n=" + encodeURIComponent(pLevel1Name)
				+ "&l2t=" + encodeURIComponent(pLevel2Type) + "&l2n=" + encodeURIComponent(pLevel2Name)
				+ "&" + pAdditionalParam
			;
	return (false);
}

function _esc(pStr) { return (pStr.replace(/</g, "&lt;")); }

function _editCell(nKey) {
	if (nKey == 27) {
		document.getElementById("zPageContent_Container").width = mla_currentCell.containerWidth ;
		mla_currentCell.innerHTML = _esc(mla_currentCell.initialHtml);
		mla_currentCell = null;
		removeEvent(document.getElementById("zFullZone"), "mousedown", _editCell);
		return (false);
	} else {
		var sNewValue = document.getElementById("mla__editcell__input").value;
		mla_currentCell.newValue = sNewValue;
		if (sNewValue == mla_currentCell.initialText) {
			for (var i = 0; i < mla_currentCell.childNodes.length; i++)
				mla_currentCell.removeChild(mla_currentCell.childNodes[i]);
			mla_currentCell.innerHTML = mla_currentCell.initialHtml;
			document.getElementById("zPageContent_Container").width = mla_currentCell.containerWidth ;
			mla_currentCell = null;
		} else {
			// gets 1st cell
			var oInput = getPKInput(mla_currentCell) ;
			mla_currentCell.innerHTML = "updating...";
			var sParam = "d=" + mla_currentCell.DbId + "&id=" + mla_currentCell.ObjId + "&c=" + encodeURIComponent(mla_currentCell.columnName) + "&v=" + encodeURIComponent(mla_currentCell.newValue) + "&pk=" + encodeURIComponent(oInput.value);
			xPostBack2("update.aspx", true, null, sParam);
		}
		removeEvent(document.getElementById("zFullZone"), "mousedown", _editCell);
		return (false);
	}
}

function _editExtProp(nKey) {
	if (nKey == 27) {
		document.getElementById("zPageContent_Container").width = mla_currentCell.containerWidth ;
		mla_currentCell.innerHTML = mla_currentCell.initialHtml;
		mla_currentCell = null;
		removeEvent(document.getElementById("zFullZone"), "mousedown", _editCell);
		return (false);
	} else {
		var sNewValue = document.getElementById("mla__editcell__input").value;
		mla_currentCell.newValue = sNewValue;
		if (sNewValue == mla_currentCell.initialText) {
			for (var i = 0; i < mla_currentCell.childNodes.length; i++)
				mla_currentCell.removeChild(mla_currentCell.childNodes[i]);
			mla_currentCell.innerHTML = mla_currentCell.initialHtml;
			document.getElementById("zPageContent_Container").width = mla_currentCell.containerWidth ;
			mla_currentCell = null;
		} else {
			// gets 1st cell
			mla_currentCell.innerHTML = "updating...";
			var sParam = "d=" + mla_currentCell.DbId + "&n=" + encodeURIComponent(mla_currentCell.ExtPropName) + "&v=" + encodeURIComponent(mla_currentCell.newValue) 
				+ "&l0t=" + encodeURIComponent(mla_currentCell.Level0Type) + "&l0n=" + encodeURIComponent(mla_currentCell.Level0Name)
				+ "&l1t=" + encodeURIComponent(mla_currentCell.Level1Type) + "&l1n=" + encodeURIComponent(mla_currentCell.Level1Name)
				+ "&l2t=" + encodeURIComponent(mla_currentCell.Level2Type) + "&l2n=" + encodeURIComponent(mla_currentCell.Level2Name);		
			xPostBack2("ep_update.aspx", true, null, sParam);
		}
		removeEvent(document.getElementById("zFullZone"), "mousedown", _editCell);
		return (false);
	}
}

// FUNCTIONS CALLED FROM POSTBACK URL
function _updateCell(pSuccessFlag) {
	document.getElementById("zPageContent_Container").width = mla_currentCell.containerWidth ;
	mla_currentCell.innerHTML = ((pSuccessFlag) ? _esc(mla_currentCell.newValue) : mla_currentCell.initialHtml);
	mla_currentCell = null;
	return (false);
}

function _deleteRow(pSuccessFlag) {
	if (pSuccessFlag) {
		var oTr = mla_currentCell.parentNode;
		var oTable = getTable(mla_currentCell);
		oTable.deleteRow(oTr.rowIndex);
	}
	mla_currentCell = null;
	return (true);
}