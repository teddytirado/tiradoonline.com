<div id="modalEmail" class="reveal-modal" data-reveal>
 
 	<div class="closeButton">
		<a class="close-reveal-modal"><img src="/images/icons/x.gif" alt="Close" width="30" height="30" border="0" /></a>
	</div>
 

 <table width="700">
 <tr valign="middle">
 	<td>
	<img src="/images/modals/email.gif" alt="Email" width="512" height="476" border="0">
	</td>
	<td>
<form action="<%= SCRIPT_NAME %>" id="formEmail" name="formEmail">
	<div id="divEmailErrorMessage" name="divEmailErrorMessage" class="ErrorMessage"></div>
	<label for="EmailFromEmail">From:&nbsp;<%= REQUIRED_ICON %></label>
	<input type="text" id="EmailFromEmail" name="EmailFromEmail" />
	
	<label for="BodyText">Email Message:&nbsp;<%= REQUIRED_ICON %></label>
	<textarea id="BodyText" name="BodyText" style="height:300px;" value=""></textarea>
	
	<p />
	
	<input type="button" id="buttonSendEmail" name="buttonSendEmail" value="Send Email to <%= Application("AdministratorName") %>" />
</form>
	</td>
</tr>
</table>
</div>

<script type="text/javascript">
	
	$('#buttonSendEmail').click
	(
		function()
		{
			var $EmailFromEmail = $('#EmailFromEmail');
			var $BodyText = $('#BodyText');
			
			if ( $EmailFromEmail.val() == '' || !isEmail($EmailFromEmail.val()) )
			{
				$EmailFromEmail.addClass('ErrorMessageElement');
				showError($('#divEmailErrorMessage'), "Invalid Email");
				$EmailFromEmail.focus();
			}
			else if ($BodyText.val() == '')
			{
				$BodyText.addClass('ErrorMessageElement');
				showError($('#divEmailErrorMessage'), "Invalid Email Message");
				$BodyText.focus();
			}
			else
			{
				url = '/scripts/email.asp';
				// Send the data using post
				
				var posting = $.post( url, { EmailFromEmail: $EmailFromEmail.val(), BodyText: $BodyText.val()  } );
				// Put the results in a div
				posting.done
				(
					function( data )
					{
						$EmailFromEmail.addClass('ErrorMessageElement');
						if (data == "1")
						{
							showError($('#divEmailErrorMessage'), "Email sent to <%= Application("AdministratorName") %>");
							$BodyText.val('');
						}
						else
							showError($('#divEmailErrorMessage'), data);
					}
				);					
			}	
			
		
		}
	);

</script>