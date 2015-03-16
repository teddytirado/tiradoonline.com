var mlt_HttpUrlError = "URL that was requested does not exist.";
var mlt_HttpError = "Another query is current performed... please wait a few seconds and try again...";

var mlt_http, mlt_connect = false;
var mlt_div = null;

// receives response
function handleHttpResponse() {
	if (mlt_http.readyState == 4) {
		mlt_connect = false;
		if (mlt_http.status==200) {
			if (mlt_div) mlt_div.innerHTML = mlt_http.responseText;
			else eval(mlt_http.responseText);
		} else {
			alert(mlt_HttpUrlError);
			if (mlt_div) mlt_div.innerHTML = "<strong>Error " + mlt_http.status + "</strong><br /><em>" + mlt_http.statusText + "</em>";
		}
	}	
}

// launches the URL (get method)
function xPostBack(pURL, pSyncFlag, pDiv) {
	if (mlt_connect) {
		alert(mlt_HttpError);
		return (false);
	}
	mlt_connect = true;
	mlt_div = pDiv;
	mlt_http = getHttpObject();
	mlt_http.open("GET", pURL, pSyncFlag);
	if (pSyncFlag) mlt_http.onreadystatechange = handleHttpResponse;
	mlt_http.send(null);
	if (! pSyncFlag) {
		mlt_connect = false;
		if (mlt_http.status==200) {
			if (mlt_div) mlt_div.innerHTML = mlt_http.responseText;
			else eval(mlt_http.responseText);
		} else {
			alert(mlt_HttpUrlError + "\nError " + mlt_http.status + "\n" + pURL);
			if (mlt_div) mlt_div.innerHTML = "<strong>Error " + mlt_http.status + "</strong><br /><em>" + mlt_http.statusText + "</em>";
		}
	}
	return (true);
}

// launches the URL (post method)
function xPostBack2(pURL, pSyncFlag, pDiv, pParam) {
	if (mlt_connect) {
		alert(mlt_HttpError);
		return (false);
	}
	mlt_connect = true;
	mlt_div = pDiv;
	mlt_http = getHttpObject();
	mlt_http.open("POST", pURL, pSyncFlag);
	mlt_http.onreadystatechange = handleHttpResponse;
	mlt_http.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"); 
	mlt_http.send(pParam);
	return (true);
}

// JS function to read a server page
function getHttpObject() {
  var xmlhttp;
  /*@cc_on
  @if (@_jscript_version >= 5)
	try { xmlhttp = new ActiveXObject("Msxml2.XMLHTTP"); }
	catch (e) { 
	  try { xmlhttp = new ActiveXObject("Microsoft.XMLHTTP"); }
	  catch (E) { xmlhttp = false; }
	}
  @else
  xmlhttp = false;
  @end @*/
  if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
	try { xmlhttp = new XMLHttpRequest(); }
	catch (e) { xmlhttp = false; }
  }
  return(xmlhttp);
}