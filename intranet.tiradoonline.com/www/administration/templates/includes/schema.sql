<%
		DatabaseName = "Teddy"
		FileName = Server.MapPath("/") & "\teddy\sql\schema.sql"
		sql_string = ReadFile(FileName)
		sql_string = Replace(sql_string, "%%%DatabaseName%%%", DatabaseName)
		TextFileName = Server.MapPath("/") & "\teddy\logs\sql\" & Month(Date) & "_" & Day(Date) & "_" & Year(Date) & ".sql"
		sql_string = sql_string & "SET NOCOUNT ON" & vbCrLF
		sql_string = sql_string & "GO" & vbCrLF
		sql_string = sql_string & "BEGIN TRANSACTION" & vbCrLF
		sql_string = sql_string & vbTab & "BEGIN" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM BALANCE" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM TRANSACTIONS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM LOGINS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM HOURS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM PAYCHECKS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM COMPANIES" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM CCBALANCE" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM CREDITCARD" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM BILLS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "DELETE FROM USERS" & vbCrLF
		sql_string = sql_string & vbCrLF

		sql = "SELECT * FROM USERS"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT USERS ON" & vbCrLF
		Do Until ors.EOF
			sql_string = sql_string & vbTab & vbTab & "INSERT INTO USERS (USERID, USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, HOURLYRATE, SENDREPORTS, ADMINISTRATOR, UPDATE_BY, UPDATE_DT, CREATE_DT) VALUES (" & ors("USERID") & ", '" & ors("USERNAME") & "', '" & ors("PASSWORD") & "', '" & ors("FIRSTNAME") & "', '" & ors("LASTNAME") & "', '" & ors("EMAIL") & "', " & ors("HOURLYRATE") & ", " & ors("SENDREPORTS") & ", '" & ors("ADMINISTRATOR") & "', '" & ors("UPDATE_BY") & "', '" & ors("UPDATE_DT") & "', '" & ors("CREATE_DT") & "')" & vbCrLF
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT USERS OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing


		sql = "SELECT * FROM TRANSACTIONS"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT TRANSACTIONS ON" & vbCrLF
		Do Until ors.EOF
			Description = ors("DESCRIPTION")
			If InStr(Description, "'") Then
				sql_string = sql_string & vbTab & vbTab & "INSERT INTO TRANSACTIONS (TRANSACTIONID, TRANSACTIONTYPE, DESCRIPTION) VALUES (" & ors("TRANSACTIONID") & ", " & ors("TRANSACTIONTYPE") & ", '" & Replace(Description,"'","''") & "')" & vbCrLF
			Else
				sql_string = sql_string & vbTab & vbTab & "INSERT INTO TRANSACTIONS (TRANSACTIONID, TRANSACTIONTYPE, DESCRIPTION) VALUES (" & ors("TRANSACTIONID") & ", " & ors("TRANSACTIONTYPE") & ", '" & Description & "')" & vbCrLF
			End If
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT TRANSACTIONS OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing


		sql = "SELECT * FROM BALANCE"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT BALANCE ON" & vbCrLF
		Do Until ors.EOF
			Comment = ors("Comment")
			If InStr(Comment, "'") Then
				sql_string = sql_string & vbTab & vbTab & "INSERT INTO BALANCE (BALANCEID, USERID, TRANSACTIONID, BALANCEDATE, PAYMENT, COMMENT, UPDATE_DT) VALUES (" & ors("BALANCEID") & ", " & ors("USERID") & ", " & ors("TRANSACTIONID") & ", '" & ors("BALANCEDATE") & "', " & ors("PAYMENT") & ", '" & Replace(Comment, "'", "''") & "', '" & ors("UPDATE_DT") &"')" & vbCrLF
			Else
				sql_string = sql_string & vbTab & vbTab & "INSERT INTO BALANCE (BALANCEID, USERID, TRANSACTIONID, BALANCEDATE, PAYMENT, UPDATE_DT) VALUES (" & ors("BALANCEID") & ", " & ors("USERID") & ", " & ors("TRANSACTIONID") & ", '" & ors("BALANCEDATE") & "', " & ors("PAYMENT") & ", '" & ors("UPDATE_DT") &"')" & vbCrLF
			End If
			ors.MoveNext
		Loop	
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT BALANCE OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing


		sql = "SELECT * FROM LOGS"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT LOGS ON" & vbCrLF
		Do Until ors.EOF
			sql_string = sql_string & vbTab & vbTab & "INSERT INTO LOGS (LOGID, LOGDATE, LOGDESC) VALUES (" & ors("LOGID") & ", '" & ors("LOGDATE") & "', '" & Replace(ors("LOGDESC"), "'", "''") & "')" & vbCrLF
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT LOGS OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing


		sql = "SELECT * FROM LOGINS"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT LOGINS ON" & vbCrLF
		Do Until ors.EOF
			sql_string = sql_string & vbTab & vbTab & "INSERT INTO LOGINS (LOGINID, USERID, LOGINDATE, BROWSER, IPADDRESS) VALUES (" & ors("LOGINID") & ", " & ors("USERID") & ", '" & ors("LOGINDATE") & "', '" & ors("BROWSER") & "', '" & ors("IPADDRESS") & "')" & vbCrLF
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT LOGINS OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing


		sql = "SELECT * FROM COMPANIES"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT COMPANIES ON" & vbCrLF
		Do Until ors.EOF
			sql_string = sql_string & vbTab & vbTab & "INSERT INTO COMPANIES (COMPANYID, USERID, COMPANYNAME) VALUES (" & ors("COMPANYID") & ", " & ors("USERID") & ", '" & Replace(ors("COMPANYNAME"), "'", "''") & "')" & vbCrLF
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT COMPANIES OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing


		sql = "SELECT * FROM HOURS"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT HOURS ON" & vbCrLF
		Do Until ors.EOF
			sql_string = sql_string & vbTab & vbTab & "INSERT INTO HOURS (HOURSID, COMPANYID, WORKDATE, STARTHOUR, ENDHOUR, LUNCHHOUR) VALUES (" & ors("HOURSID") & ", " & ors("COMPANYID") & ", '" & ors("WORKDATE") & "', " & ors("STARTHOUR") & ", " & ors("ENDHOUR") & ", " & ors("LUNCHHOUR") & ")" & vbCrLF
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT HOURS OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing


		sql = "SELECT * FROM PAYCHECKS"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT PAYCHECKS ON" & vbCrLF
		Do Until ors.EOF
			sql_string = sql_string & vbTab & vbTab & "INSERT INTO PAYCHECKS (PAYCHECKID, COMPANYID, PAYMENTDATE, HOURLYRATE, GROSS, FEDERAL, SOCIALSECURITY, MEDICARE, NY_WITHHOLDING, NY_DISABILITY, NY_CITY) VALUES (" & ors("PAYCHECKID") & ", " & ors("COMPANYID") & ", '" & ors("PAYMENTDATE") & "', " & ors("HOURLYRATE") & ", " & ors("GROSS") & ", " & ors("FEDERAL") & ", " & ors("SOCIALSECURITY") & ", " & ors("MEDICARE") & ", " & ors("NY_WITHHOLDING") & ", " & ors("NY_DISABILITY") & ", " & ors("NY_CITY") & ")" & vbCrLF
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT PAYCHECKS OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing

		sql = "SELECT * FROM CREDITCARD"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT CREDITCARD ON" & vbCrLF
		Do Until ors.EOF
			sql_string = sql_string & vbTab & vbTab & "INSERT INTO CREDITCARD (CCID, USERID, CCNAME, CCLIMIT, CCEXPIRATION) VALUES (" & ors("CCID") & ", " & ors("USERID") & ", '" & ors("CCNAME") & "', " & ors("CCLIMIT") & ", '" & ors("CCEXPIRATION") & "')" & vbCrLF
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT CREDITCARD OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing

		sql = "SELECT * FROM CCBALANCE"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT CCBALANCE ON" & vbCrLF
		Do Until ors.EOF
			sql_string = sql_string & vbTab & vbTab & "INSERT INTO CCBALANCE (CCBALANCEID, CCID, CCDATE, CCDESCRIPTION, CCPAYMENT, UPDATE_DT) VALUES (" & ors("CCBALANCEID") & ", " & ors("CCID") & ", '" & ors("CCDATE") & "', '" & Replace(ors("CCDESCRIPTION"), "'", "''") & "', " & ors("CCPAYMENT") & ", '" & ors("UPDATE_DT") & "')" & vbCrLF
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT CCBALANCE OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing

		sql = "SELECT * FROM BILLS"
		Set ors = oConn.Execute(sql)
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT BILLS ON" & vbCrLF
		Do Until ors.EOF
			sql_string = sql_string & vbTab & vbTab & "INSERT INTO BILLS (BILLID, USERID, BILLDAY, BILLDESC) VALUES (" & ors("BILLID") & ", " & ors("USERID") & ", " & ors("BILLDAY") & ", '" & Replace(ors("BILLDESC"), "'", "''") & "')" & vbCrLF
			ors.MoveNext
		Loop
		sql_string = sql_string & vbTab & vbTab & "SET IDENTITY_INSERT BILLS OFF" & vbCrLF
		sql_string = sql_string & vbCrLF
		ors.Close
		Set ors = Nothing

		sql_string = sql_string & vbTab & vbTab & "IF @@error = 0" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & "BEGIN" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "COMMIT TRANSACTION" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM USERS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM TRANSACTIONS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM BALANCE" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM LOGS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM LOGINS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM COMPANIES" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM HOURS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM PAYCHECKS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM CREDITCARD" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM CCBALANCE" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & vbTab & "SELECT * FROM BILLS" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & "END" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & "ELSE" & vbCrLF
		sql_string = sql_string & vbTab & vbTab & vbTab & "ROLLBACK TRANSACTION" & vbCrLF
		sql_string = sql_string & vbTab & "END" & vbCrLF
		sql_string = sql_string & "GO" & vbCrLF
		sql_string = sql_string & "SET NOCOUNT OFF" & vbCrLF
		sql_string = sql_string & "GO" & vbCrLF

		sql = "INSERT INTO LOGS (LOGDESC) VALUES ('BACKUP EXECUTED BY " & Session("UserName") & " - Total time: " & TotalTime & "')"
%>