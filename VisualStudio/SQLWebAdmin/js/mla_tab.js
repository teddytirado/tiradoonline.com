	function tab_show(pZoneId) {
		for (var i = 0; i < tab_aTabsId.length; i++) {
			document.getElementById("zTab_" + tab_aTabsId[i]).style.display = "none";	
			document.getElementById("t" + tab_aTabsId[i]).className = "tab";	
		}
		document.getElementById("zTab_" + pZoneId).style.display = "";
		document.getElementById("t" + pZoneId).className = "tab tabselected";	
		return (false);
	}