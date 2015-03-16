

					</td>
				</tr>
				</table>
			</td>
		</tr>
		</table>

	</div>
		</td>
	</tr>
	</table>

</div>

<script language="JavaScript">
<!--
	function Logout()
	{
		alert("Your session has timed out");
		redirectURL = "/default.asp?SubmitButton=Logout"
		location.href = redirectURL;
		
	}
	
	setTimeout("Logout()", <%= Session.Timeout * 60000 %>);
	
//-->
</script>

<!-- #include virtual="/includes/modals/spinner.inc" -->

<% If Debugging Then %>
<br clear="all">
<!-- #include virtual="/includes/debug.inc" -->
<% End If %>
    <!--*******************************************************
        FOUNDATION 
    *******************************************************-->
    <script src="/foundation/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="/foundation/js/foundation/foundation.js" type="text/javascript"></script>
    <script src="/foundation/js/foundation/foundation.interchange.js" type="text/javascript"></script>
    <script src="/foundation/js/foundation.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        //$(document).foundation();
    </script>

</body>
</html>
