<div id="modalTextMessage" class="reveal-modal" data-reveal>
 
 	<div class="closeButton">
		<a class="close-reveal-modal"><img src="/images/icons/x.gif" alt="Close" width="30" height="30" border="0" /></a>
	</div>
 
 <table width="700">
 <tr valign="middle">
 	<td>
		<img src="/images/modals/text.gif" alt="Text Message" width="512" height="476" border="0">
	</td>
	<td>
<form action="<%= SCRIPT_NAME %>" id="textMessageForm" name="textMessageForm">
	<div id="divTextMessageErrorMessage" name="divTextMessageErrorMessage" class="ErrorMessage"></div>
	<label for="FromEmail">Your&nbsp;Email:&nbsp;<%= REQUIRED_ICON %></label>
	<input type="text" id="FromEmail" name="FromEmail" />
	
	<label for="TextMessage">Text&nbsp;Message:&nbsp;<%= REQUIRED_ICON %></label>
	<textarea id="TextMessage" name="TextMessage" style="height:300px;" value=""></textarea>
	
	<p />
	
	<input type="button" id="buttonSendTextMessage" name="buttonSendTextMessage" value="Send Text Message to <%= Application("AdministratorName") %>" />
</form>
	</td>
</tr>
</table>
</div>

<script type="text/javascript">
	
	$('#buttonSendTextMessage').click
	(
		function()
		{
			var $FromEmail = $('#FromEmail');
			var $TextMessage = $('#TextMessage');
			
			if ( $FromEmail.val() == '' || !isEmail($FromEmail.val()) )
			{
				$FromEmail.addClass('ErrorMessageElement');
				showError($('#divTextMessageErrorMessage'), "Invalid Email");
				$FromEmail.focus();
			}
			else if ($TextMessage.val() == '')
			{
				$TextMessage.addClass('ErrorMessageElement');
				showError($('#divTextMessageErrorMessage'), "Invalid Text Message");
				$TextMessage.focus();
			}
			else
			{
				// **** SEND TEXT MESSAGE
				url = '/scripts/text_message.asp';
				// Send the data using post
				
				var posting = $.post( url, { FromEmail: $FromEmail.val(), TextMessage: $TextMessage.val()  } );
				// Put the results in a div
				posting.done
				(
					function( data )
					{
						$FromEmail.addClass('ErrorMessageElement');
						if (data == "1")
						{
							showError($('#divTextMessageErrorMessage'), "Text Message sent to <%= Application("AdministratorName") %>");
							$TextMessage.val('');
						}
						else
							showError($('#divTextMessageErrorMessage'), data);
					}
				);			
			}	
			
		
		}
	);

</script>