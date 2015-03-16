// *************************
// *  DEFINE CONSTANT VARIABLES
// *************************
var XML_FILE 		= "database/login.xml";

// *************************
// *  GRAB VARIABLES FROM XML CONFIGURATION FILE
// *************************
if (window.XMLHttpRequest) {// code for IE7 +, Firefox, Chrome, Opera, Safari
	var xmlhttp = new XMLHttpRequest();
}
else {// code for IEMAX_BOXES, IE5
	var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
}

// *************************
// *  OPEN XML FILE
// *************************
try {
	xmlhttp.open("GET", XML_FILE, false);
	xmlhttp.send();
	var xmlDoc = xmlhttp.responseXML; 	
}
catch (e) {
	alert(e);
}

try {	
	var users = xmlDoc.getElementsByTagName("login");
}
catch (e) {
	alert("Could not find <users> element.");
}

function validateLogin(username, password) {

	for (var x=0; x < users.length; x++) {
		try {
			xml_username  = users[x].getElementsByTagName("username")[0].childNodes[0].nodeValue;
			xml_password = users[x].getElementsByTagName("password")[0].childNodes[0].nodeValue;

			if(username == xml_username && password == xml_password) {
				return true;
			}				
		}
		catch (e) {
			alert(e);
			alert("Could not find <users> element.");
		}
	}

	return false;
}

