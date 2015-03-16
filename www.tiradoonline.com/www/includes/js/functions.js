<script type="text/javascript">

	function isEmail(email_string) {
		validEmail = true;
		
    	var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

		if(email_string == "") {
			validEmail = false;
		} 
		else if(!filter.test(email_string)) {
			validEmail = false;
		}

		return validEmail;
	}

	function showError(objErrorMessage, errorMessage)
	{
		errorMessage = "<%= YIELD_ICON %>" + errorMessage + "<br><br>";

		objErrorMessage.hide();
		objErrorMessage.fadeIn(2000).html(errorMessage);
	}

</script>