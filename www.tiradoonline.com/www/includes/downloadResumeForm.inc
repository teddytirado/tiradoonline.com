<form action="<%= SCRIPT_NAME %>" id="downloadResumeForm" name="downloadResumeForm">
	<div id="divErrorMessage" name="divErrorMessage" class="ErrorMessage"></div>
	<label for="FullName">Full Name:&nbsp;<%= REQUIRED_ICON %></label>
	<input type="text" id="FullName" name="FullName" />

	<label for="Email">Email:&nbsp;<%= REQUIRED_ICON %></label>
	<input type="text" id="Email" name="Email" value="" />

	<label for="Company">Company:</label>
	<input type="text" id="Company" name="Company" value="" />

	<label for="Phone">Phone:</label>
	<input type="text" id="Phone" name="Phone" value="" />

	<label for="Phone">Website:</label>
	<input type="text" id="Website" name="Website" value="" />

	<label for="Phone">How&nbsp;did you find me?</label>
	<%= SelectBox(oConn, "sp_ReferencedBy_UserID_get " & Session("UserID"), "ReferencedByID", ReferencedByID, "") %>				

	<label for="Phone">Resume&nbsp;Version:</label>
	<%= SelectBox(oConn, "sp_ResumeDownloadType_UserID_get " & Session("UserID"), "ResumeDownloadTypeID", ResumeDownloadTypeID, "") %>				

	<label for="Comments">Comments:</label>
	<textarea id="Comments" name="Comments" style="height:100px;" value=""></textarea>
	
	<p />
	
	<input type="submit" id="buttonDownloadResume" name="buttonDownloadResume" value="Download Resume" />
</form>


<script type="text/javascript">

	$('#downloadResumeForm').submit
	(
		function(evt)
		{
			var $FullName				= $('#FullName');
			var $Company				= $('#Company');
			var $Phone					= $('#Phone');
			var $Email					= $('#Email');
			var $Comments				= $('#Comments');
			var $Website				= $('#Website');
			var $ReferencedByID			= $('#ReferencedByID');
			var $ResumeDownloadTypeID	= $('#ResumeDownloadTypeID');
			var $Referer				= '<%= Session("Referer") %>';
			var $SessionID				= '<%= Session("SessionID") %>';
			
			if ($FullName.val() == '')
			{
				$FullName.addClass('ErrorMessageElement');
				showError($('#divErrorMessage'), "Invalid Full Name");
				return false;
			}
			else if ( $Email.val() == '' || !isEmail($Email.val()) )
			{
				showError($('#divErrorMessage'), "Invalid Email");
				return false;
			}
			
			var $url_string = "/scripts/download_resume.asp";
			$url_string += "?FullName=" + escape($FullName.val());
			$url_string += "&Company=" + escape($Company.val());
			$url_string += "&Phone=" + escape($Phone.val());
			$url_string += "&Email=" + escape($Email.val());
			$url_string += "&Comments=" + escape($Comments.val());
			$url_string += "&Website=" + escape($Website.val());
			$url_string += "&ReferencedByID=" + escape($ReferencedByID.val());
			$url_string += "&ResumeDownloadTypeID" + escape($ResumeDownloadTypeID.val());
			$url_string += "&Referer=" + escape($Referer);
			$url_string += "&SessionID=" + escape($SessionID);
			alert($url_string);
			
			return false;
		}
	);
</script>
