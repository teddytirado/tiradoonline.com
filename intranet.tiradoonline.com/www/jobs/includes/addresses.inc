				<%
					sql = "SELECT TotalAddresses = (SELECT COUNT(*) FROM JobCompanyAddress WHERE JobCompanyID = " & JobCompanyID & ")"
					WriteDebugger sql, Debugging, 0
					Set ors = oConn.Execute(sql)
					TotalAddresses = ors.Fields(0).Value
					ors.Close
					Set ors = Nothing

					sql = "SELECT a.*, b.State, TotalAddresses = (SELECT COUNT(*) FROM JobCompanyAddress WHERE JobCompanyID = " & JobCompanyID & ") FROM JobCompanyAddress a, States b WHERE a.StateID = b.StateID AND a.JobCompanyID = " & JobCompanyID & " ORDER BY create_dt"
					WriteDebugger sql, Debugging, 0
					Set ors = oConn.Execute(sql)
				%>
				<table cellpadding="5" class"GridViewAlteringRows" width="100%">
				<tr>
					<td class="JobsTheme">
						<b>Company&nbsp;Addresses&nbsp;(<%= TotalAddresses %>)&nbsp;[&nbsp;<a href="<%= SCRIPT_NAME %>?Template=company_address&JobCompanyID=<%= JobCompanyID %>">New</a>&nbsp;]</b>
					</td>
				</tr>
				<%
					If NOT ors.EOF Then
						Do Until ors.EOF
							v_JobCompanyAddressID = ors("JobCompanyAddressID")
							v_JobCompanyAddress1 = ors("JobCompanyAddress1")
							v_JobCompanyAddress2 = ors("JobCompanyAddress2")
							v_JobCompanyAddressCity = ors("JobCompanyAddressCity")
							v_State = ors("State")
							v_JobCompanyAddressZipCode = ors("JobCompanyAddressZipCode")
				%>
				<tr class="GridViewRow">
					<td>
					<a href="<%= SCRIPT_NAME %>?Template=company_address&JobCompanyID=<%= JobCompanyID %>&JobCompanyAddressID=<%= v_JobCompanyAddressID %>">
					<% If v_JobCompanyAddress1 <> "" Then %>
						<%= v_JobCompanyAddress1 %><br />
					<% End If %>
					<% If v_JobCompanyAddress2 <> "" Then %>
						<%= v_JobCompanyAddress2 %><br />
					<% End If %>
					<% If v_JobCompanyAddressCity <> "" Then %>
						<%= v_JobCompanyAddressCity %>,&nbsp;
					<% End If %>
					<% If v_State <> "" Then %>
						<%= v_State %>&nbsp;
					<% End If %>
					<%= v_JobCompanyAddressZipCode %>
					</a>
					</td>
				</tr>
				<%
							ors.MoveNext
						Loop
						ors.Close
				%>
			<% 
				Else
			%>
			<tr>
				<td colspan="2" class="ErrorMessage" bgcolor="#ffffff">
					No&nbsp;records&nbsp;found.
				</td>
			</tr>
			<%
				End If
				Set ors = Nothing
				
			%>
				</table>
