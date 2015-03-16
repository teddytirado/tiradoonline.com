  
  </div>


</div>

<script src="/includes/foundation/js/vendor/jquery.js" type="text/javascript"></script>
<script src="/includes/foundation/js/foundation/foundation.js" type="text/javascript"></script>
<script src="/includes/foundation/js/foundation/foundation.interchange.js" type="text/javascript"></script>
<script src="/includes/foundation/js/foundation.min.js" type="text/javascript"></script>

<script type="text/javascript">

    $(document).foundation();

	$('input[type=text]').focus
	(
		function()
		{
			$('#divErrorMessage').hide();
			$('input[type=text]').removeClass('ErrorMessageElement');
		}
	);

	$(".container").fadeIn(2000);
</script>

</body>
</html>
