<!-- #include virtual="/includes/login.inc" -->
<!-- #include virtual="/includes/globals.inc" -->
<%
	PageTheme = "recoveryTheme"
	PageThemeColor = RECOVERY_THEME
	PageTitle = "Recovery"
	HeaderTitle = "Recovery"
	Response.Buffer = true
%>

<!-- #include virtual="/includes/open_connection.inc" -->
<!-- #include virtual="/includes/page_logs.inc" -->

<!-- #include virtual="/includes/functions.inc" -->
<%
	'*** RECOVERY PROGRAMS
	RecoveryProgramID = Trim(Request("RecoveryProgramID"))
	RecoveryTypeID = Trim(Request("RecoveryTypeID"))
	ProgramName = Trim(Request("ProgramName"))
	start_dt = Trim(Request("start_dt"))	
	end_dt = Trim(Request("end_dt"))
	sober_dt = Trim(Request("sober_dt"))
	
	'*** RECOVERY COUNSELORS
	RecoveryCounselorID = Trim(Request("RecoveryCounselorID"))
	FirstName = Trim(Request("FirstName"))
	LastName = Trim(Request("LastName"))
	
	'*** RECOVERY GROUPS
	RecoveryGroupID = Trim(Request("RecoveryGroupID"))
	RecoveryGroupName = Trim(Request("RecoveryGroupName"))
	
	'*** RECOVERY GROUP SESSIONS
	RecoveryGroupSessionID = Trim(Request("RecoveryGroupSessionID"))
	RecoveryGroupSessionDate = Trim(Request("RecoveryGroupSessionDate"))
	If RecoveryGroupSessionDate = "" Then RecoveryGroupSessionDate = FormatDateTime(Now, 2)
	RecoveryGroupSessionTime = Trim(Request("RecoveryGroupSessionTime"))
	RecoveryGroupSessionDateTime = Trim(RecoveryGroupSessionDate & " " & RecoveryGroupSessionTime)
	ScheduledGroup = Trim(Request("ScheduledGroup"))
	If ScheduledGroup = "" Then ScheduledGroup = "0"
	'ScheduledGroup = CBool(ScheduledGroup)
	Comments = Trim(Request("Comments"))
	RecoveryGroupSessionDatePickerStartDate = Trim(Request("RecoveryGroupSessionDatePickerStartDate"))
	RecoveryGroupSessionDatePickerEndDate = Trim(Request("RecoveryGroupSessionDatePickerEndDate"))
	If RecoveryGroupSessionDatePickerEndDate = "" Then RecoveryGroupSessionDatePickerEndDate = Date

	'*** RECOVERY URINE
	RecoveryUrineID = Trim(Request("RecoveryUrineID"))
	RecoveryUrineDateTime = Trim(Request("RecoveryUrineDateTime"))
	RecoveryUrineResult = Trim(Request("RecoveryUrineResult"))
	If RecoveryUrine = "" Then RecoveryUrine = "0"
	RecoveryUrineDescription = Trim(Request("RecoveryUrineDescription"))
%>
<!-- #include virtual="/includes/open_header.inc" -->

				<% If Template = "" Then %>
				<!-- #include file="templates/home.tem" -->
				<% ElseIf LCase(Template) = "recovery_types" Then %>
				<!-- #include file="templates/recovery_types.tem" -->
				<% ElseIf LCase(Template) = "recovery_programs" Then %>
				<!-- #include file="templates/recovery_programs.tem" -->
				<% ElseIf LCase(Template) = "recovery_counselors" Then %>
				<!-- #include file="templates/recovery_counselors.tem" -->
				<% ElseIf LCase(Template) = "recovery_groups" Then %>
					<!-- #include file="templates/recovery_groups.tem" -->
				<% ElseIf LCase(Template) = "recovery_group_sessions" Then %>
					<!-- #include file="templates/recovery_group_sessions.tem" -->
				<% ElseIf LCase(Template) = "recovery_urine" Then %>
					<!-- #include file="templates/recovery_urine.tem" -->
				<% End If %>

<!-- #include virtual="/includes/jquery.inc" -->
<!-- #include virtual="/includes/close_header.inc" -->
<!-- #include virtual="/includes/close_connection.inc" -->
