// left trims
function ltrim(pStr) {
	if (pStr == null) return ("");
	var oRegExp = new RegExp("^[ ]*", "gim");
	return (pStr.replace(oRegExp, ""));
}

// checks whether a text input contains a numeric value
function _isNumeric(pString) {
	var oRegExp = /^[-+]?[0-9]+(?:[.,]?[0-9]+)?$/;
	return (oRegExp.test(pString)); 
}

function isNumeric(pObj) {
	return (_isNumeric(pObj.value)); 
}

// event
function addEvent(obj, evType, fn){ 
	if (obj.addEventListener) { 
		obj.addEventListener(evType, fn, false); 
		return true; 
	} else if (obj.attachEvent) { 
		var r = obj.attachEvent("on"+evType, fn); 
		return r; 
	} else { return false; } 
}

function removeEvent(obj, evType, fn){ 
	if (obj.removeEventListener) { 
		obj.removeEventListener(evType, fn, false); 
		return true; 
	} else if (obj.detachEvent) { 
		var r = obj.detachEvent("on"+evType, fn); 
		return r; 
	} else { return false; } 
}

// misc.
function displaydiv(pImg, pDiv) {
	var oDiv = document.getElementById(pDiv);
	if (oDiv.style.display == "none") {
		oDiv.style.display = "";
		pImg.src = "../skin/default/img/treeview/mlt_red.gif";
	} else {
		oDiv.style.display = "none";
		pImg.src = "../skin/default/img/treeview/mlt_exp.gif";
	}
	return (false);
}

function sql_saveas() {
	var oTextArea = document.getElementById("__mla__script__textarea");
	var sSql = oTextArea.value;
	var oWnd = window.open("", "mla_script", "width=1,height=1");
	oWnd.moveTo(-500, -500);
    oWnd.document.write(sSql)
    oWnd.document.close();
	oWnd.document.charset = "UTF-8";
	oWnd.focus(); 
    if (oWnd.document.execCommand("SaveAs", null, "*.sql")) alert("File has been saved");
    oWnd.close();

}

function reloadBar() {
	window.parent.frames['nav'].location.reload();
}

function enableCM(pTextArea, pReadOnly) {
	var bReadOnly;
	if (pReadOnly == null) bReadOnly = false;
	else bReadOnly = (pReadOnly == true);
	var cmEditor = CodeMirror.fromTextArea(document.getElementById(pTextArea), {
        lineNumbers: true,
        matchBrackets: true,
		readOnly: bReadOnly,
		mode: "text/x-tsql",
		indentUnit: 4,
        indentWithTabs: true,
        enterMode: "keep",
        tabMode: "shift"
      });	
	  return (cmEditor);
}
