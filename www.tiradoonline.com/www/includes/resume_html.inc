<%
	sql = "select jobcoverlettertext from jobcoverletter where jobcoverletterid = 1002"
	Set ors = oConn.Execute(sql)
	Response.Write ors.Fields(0).Value
	ors.Close
	Set ors = Nothing
%>