<!-- #include virtual="/includes/globals.inc" -->
<!-- #include virtual="/includes/open_connection.inc" -->
<%
	PageTheme = "CreditCardsTheme"
	PageThemeColor = CREDITCARDS_THEME
	PageTitle = "Credit Cards"
	HeaderTitle = "Credit Cards"
	Response.Buffer = true
%>
<!-- #include virtual="/includes/page_logs.inc" -->

<!-- #include virtual="/includes/functions.inc" -->
<%
	CreditCardID = Trim(Request("CreditCardID"))
	CreditCardName = Trim(Request("CreditCardName"))
	CreditLimit = Trim(Request("CreditLimit"))
	If CreditLimit = "" Then CreditLimit = 0
	MinimumPayment = Trim(Request("MinimumPayment"))
	If MinimumPayment = "" Then MinimumPayment = 0
	CreditAvailable = Trim(Request("CreditAvailable"))
	If CreditAvailable = "" Then CreditAvailable = 0
	ClosingDate = Trim(Request("ClosingDate"))
	DueDate = Trim(Request("DueDate"))
	Percentage = Trim(Request("Percentage"))
	If Percentage = "" Then Percentage = 0.0
	Payments = Trim(Request("Payments"))
	If Payments = "" Then Payments = 0.0
	OrderBy = Trim(Request("OrderBy"))
	If OrderBy = "" Then OrderBy = "CreditCardName"
	
	If SubmitButton = "Create Credit Card" Then
		sql = "INSERT INTO CreditCard (UserID, CreditCardName, CreditLimit, MinimumPayment, CreditAvailable, ClosingDate, DueDate, Percentage, Payments) VALUES (" & _
			  Session("UserID") & ", " & _
			  "'" & SQLEncode(CreditCardName) & "', " & _
			  CreditLimit & ", " & _
			  MinimumPayment & ", " & _
			  CreditAvailable & ", " & _
			  ClosingDate & ", " & _
			  DueDate & ", " & _
			  Percentage & ", " & _
			  Payments & ")"
		WriteDebugger sql, Debugging, 0
		'Response.End
		oConn.Execute(sql)
		CreditCardErrorMessage = Server.URLEncode("Credit Card '" & CreditCardName & "' added.")
		Response.Redirect SCRIPT_NAME & "?Template=View&CreditCardErrorMessage=" & CreditCardErrorMessage
	ElseIf SubmitButton = "Save Credit Card" Then
		sql = "UPDATE CreditCard SET " & _
			  "CreditCardName = '" & SQLEncode(CreditCardName) & "', " & _
			  "CreditLimit = " & CreditLimit & ", " & _
			  "MinimumPayment = " & MinimumPayment & ", " & _
			  "CreditAvailable = " & CreditAvailable & ", " & _
			  "ClosingDate = " & SQLEncode(ClosingDate) & ", " & _
			  "DueDate = " & SQLEncode(DueDate) & ", " & _
			  "Percentage = " & Percentage & ", " & _
			  "Payments = " & Payments & " " & _
			  "WHERE CreditCardID = " & CreditCardID
		WriteDebugger sql, Debugging, 0
		oConn.Execute(sql)
		CreditCardErrorMessage = Server.URLEncode("Credit Card '" & CreditCardName & "' saved.")
		Response.Redirect SCRIPT_NAME & "?Template=View&CreditCardErrorMessage=" & CreditCardErrorMessage
	End If	
%>

<!-- #include virtual="/includes/open_header.inc" -->


				<form action="<%= SCRIPT_NAME %>" method="post">
				<table cellspacing=0 cellpadding=2 border=0 bgcolor="#ffffff" width="100%">
				<tr>
					<td align="right"><b>&nbsp;&nbsp;&nbsp;Credit&nbsp;Card&nbsp;Name:</b></font>&nbsp;</td>
					<td>
						<%= formTextBox("CreditCard_Name", "40", "", "CreditCardsElement", "Credit Card Name", "Invalid Credt Card Name") %>
						
						<%= Button("Button", "Create Credit Card", "Button", "", "Create Credit Card", "formCreditCardCreate()") %>&nbsp;&nbsp;
						<%= Button("Button", "View All Credit Card Info", "Button", "", "", "location.href='" & SCRIPT_NAME & "?Template=View'") %>
					</td>
				</tr>
				</table>
				<input type="hidden" id="Template" name="Template" value="<%= Template %>" />
				</form>
				&nbsp;<br />
				<% If CreditCardErrorMessage <> "" Then %>
				<div class="ErrorMessage"><%= CreditCardErrorMessage %></div>
				&nbsp;<br />
				<% End If %>
				<% If Template = "" Then %>
					<% CreditCardImageID = "home" %>
					<!-- #include file="templates/home.tem" -->
				<% ElseIf Template = "View" Then %>
					<!-- #include file="templates/view_creditcards.tem" -->
				<% Else %>
					<!-- #include file="templates/edit_creditcard.tem" -->
				<% End If %>
				


<!-- #include virtual="/includes/jquery.inc" -->
<!-- #include virtual="/includes/close_header.inc" -->
<!-- #include virtual="/includes/close_connection.inc" -->