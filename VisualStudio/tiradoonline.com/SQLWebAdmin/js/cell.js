
var mla_currentCell = null;

// Generic Table Functions
function getRow(pCell) {
	return (pCell.parentNode);
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

// Table Cell Edit
function editCell(pCell, pParam1, pParam2, pParam3, pParam4) {
	// we cannot edit more than one cell once
	if (mla_currentCell != null) return (false);
	// stores initial state
	mla_currentCell = pCell;
	pCell.initialHtml = pCell.innerHTML;
	pCell.initialText = (pCell.innerText) ? ltrim(pCell.innerText) : ltrim(pCell.textContent);
	pCell.DbId = pParam1;
	pCell.ObjId = pParam2;
	pCell.ItemId = pParam3;
	pCell.ObjType = pParam4;
	// creates an input box
	var oInput = document.createElement("input");
	oInput.setAttribute("type", "text");
	oInput.setAttribute("id", "mla__editcell__input");
	oInput.setAttribute("class", "cellEdit"); oInput.setAttribute("className", "cellEdit");
	oInput.setAttribute("value", pCell.initialText);
	// manages event
	oInput.onmousedown = function (e) { window.event.cancelBubble = true; }
	oInput.onkeydown = function(e) { 
		nKey = (window.event) ? window.event.keyCode : e.keyCode ;
		if (nKey == 27 || nKey == 13) _editCurrentCell(nKey);
	}
	addEvent(document.getElementById("zFullZone"), "mousedown", _editCurrentCell);
	// displays the input box
	pCell.replaceChild(oInput, pCell.firstChild);
	oInput.focus(); 	oInput.select();
}

function _editCurrentCell(nKey) {
	if (nKey == 27) {
		mla_currentCell.innerHTML = mla_currentCell.initialHtml;
		mla_currentCell = null;
		removeEvent(document.getElementById("zFullZone"), "mousedown", _editCurrentCell);
		return (false);
	} else {
		var sNewName = document.getElementById("mla__editcell__input").value;
		if (sNewName == mla_currentCell.initialText) {
			mla_currentCell.innerHTML = mla_currentCell.initialHtml;
			mla_currentCell = null;
		} else {
			mla_currentCell.innerHTML = "renaming...";
			var sParam = "d=" + mla_currentCell.DbId + "&id=" + mla_currentCell.ObjId + "&cid=" + mla_currentCell.ItemId + "&t=" + mla_currentCell.ObjType + "&new=" + encodeURIComponent(sNewName);
			xPostBack2("rename.aspx", true, null, sParam);
		}
		removeEvent(document.getElementById("zFullZone"), "mousedown", _editCurrentCell);
		return (false);
	}
}

// Table Cell Delete
function deleteCell(pCell, pParam1, pParam2, pParam3, pParam4) {
	// stores initial state
	mla_currentCell = pCell;
	pCell.initialHtml = pCell.innerHTML;
	pCell.initialText = (pCell.innerText) ? ltrim(pCell.innerText) : ltrim(pCell.textContent);
	pCell.DbId = pParam1;
	pCell.ObjId = pParam2;
	pCell.ItemId = pParam3;
	pCell.ObjType = pParam4;
	if (confirm("Do you really wanna drop this object ?")) {
		mla_currentCell.innerHTML = "deleting...";
		var sParam = "d=" + mla_currentCell.DbId + "&id=" + mla_currentCell.ObjId + "&cid=" + mla_currentCell.ItemId + "&t=" + mla_currentCell.ObjType;
		xPostBack2("drop.aspx", true, null, sParam);
	} else {
		mla_currentCell = null;
	}
}

// FUNCTIONS CALLED FROM POSTBACK URL
function _updateCurrentCell(pNewValue) {
	var sHtml = mla_currentCell.initialHtml;
	sHtml = sHtml.replace(mla_currentCell.initialText + "</A>", pNewValue + "</A>");
	mla_currentCell.innerHTML = sHtml;
	mla_currentCell = null;
	return (true);
}

function _deleteCurrentCell() {
	var oTr = mla_currentCell.parentNode;
	var oTable = getTable(mla_currentCell);
	oTable.deleteRow(oTr.rowIndex);
	mla_currentCell = null;
	return (true);
}