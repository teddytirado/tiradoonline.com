var navbar_aDiv = Array();
var navbar_sParentClass = "";

function navbar_hideAllDivBut(pDiv) {	
	var oParentDiv, oChildrenDiv;
	for (i = 0; i < navbar_aDiv.length; i++) {
		if (navbar_aDiv[i][1] != pDiv) {
			oParentDiv = document.getElementById(navbar_aDiv[i][0]);
			oChildrenDiv = document.getElementById(navbar_aDiv[i][1]);
			if (oChildrenDiv.style.display != "none") {
				oParentDiv.className = navbar_sParentClass;
				oChildrenDiv.style.display = "none";
			}
		}
	}
}

function navbar_showHideDiv(pParentObj, pExpandedFlag, pSelectedClass) {
	var oDiv = document.getElementById(pParentObj.id + '_Children');
	if (oDiv) {
		if (oDiv.style.display == "none") {
			if (!pExpandedFlag) navbar_hideAllDivBut(oDiv.id);
			oDiv.style.display = "";
			navbar_sParentClass = pParentObj.className;
			pParentObj.className = pSelectedClass;
		}
	}
}

function navbar_addDiv(pParentDiv, pChildrenDiv) {
	navbar_aDiv[navbar_aDiv.length] = Array(pParentDiv, pChildrenDiv);
}

function navbar_displayBar(pDiv, pFlag) {
	var oNavbar = document.getElementById(pDiv);
	oNavbar.style.display = ((pFlag) ? "" : "none");
}
