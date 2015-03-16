 <div class="contain-to-grid sticky">
 	<nav class="top-bar" data-topbar>
		<ul class="title-area">
			<li class="name">
				<h1><a href="/default.asp">tiradoonline.com</a></h1>
			</li>
			<li class="toggle-topbar menu-icon">
				<a href="#">
					<img src="/images/icons/menu.jpg" alt="Menu" width="23" height="66" border="0">&nbsp;&nbsp;&nbsp;
				  Menu
				</a>
			</li>
		</ul>
		
		<!-- RESPONSIVE MENU -->
		<section class="top-bar-section">
			<ul class="right">
				<li class="has-dropdown">
					<a href="#">Resume</a>
					<ul class="dropdown">
						<li><a href="/default.asp">Cover Letter</a></li>
						<li><a href="/html.asp">HTML</a></li>
					</ul>
				</li>
				<li class="has-dropdown">
					<a href="#">Downloads</a>
					<ul class="dropdown">
						<li class="has-dropdown">
							<a href="#">Resumes</a>
							<!-- #include virtual="/includes/resumeDownloadsMenu.inc" -->
						</li>
					</ul>
				</li>
				<li class="has-dropdown">
						<li class="has-dropdown">
							<a href="#">Sample Code</a>
							<ul class="dropdown">
								<li><a href="/sample_code/theodore_tirado_samples.zip">ASP.NET (C#)</a></li>
								<li><a href="/sample_code/Ted_Tirado_Samples.zip">Classic ASP (VBScript)</a></li>
								<li><a href="/sample_code/sql.zip">T-SQL</a></li>
								<li><a href="/sample_code/tiradoonline.com.zip">C# Solution - tiradoonline.com</a></li>
								<li><a href="/sample_code/vb_net_airline_code_documentation.zip">Airline Booking Engine - VB.NET
								</a></li>
							</ul>
						</li>
				</li>
				<li class="has-dropdown">
					<a href="#">Screen Shots</a>
					<ul class="dropdown">
				<%
					Set objFileSystem = Server.CreateObject("Scripting.FileSystemObject")
					set objFolder = objFileSystem.GetFolder(Server.MapPath("/images/screenshots/"))

					For Each Folder in objFolder.SubFolders
						SubFolderName = Folder.Name
				%>
						<li><a href="/screenshots.asp?FolderName=<%= Server.URLEncode(SubFolderName) %>"><%= SubFolderName %></a></li>
				<%
					Next

					Set objFolder = Nothing
					Set objFileSystem = Nothing					
				%>
					</ul>
				</li>
				<li class="has-dropdown">
					<a href="#">Contact</a>
					<ul class="dropdown">
						<li><a href="#" data-reveal-id="modalPhone"><img src="/images/menu/phone.gif" alt="Phone" width="69" height="33" border="0" class="iconMenu"></a></li>
						<li><a href="#" data-reveal-id="modalTextMessage"><img src="/images/menu/text.gif" alt="Text" width="69" height="33" border="0" class="iconMenu"></a></li>
						<li><a href="#" data-reveal-id="modalEmail"><img src="/images/menu/email.gif" alt="Email" width="69" height="33" border="0" class="iconMenu"></a></li>
						<li><a href="#" data-reveal-id="modalFax"><img src="/images/menu/fax.gif" alt="Fax" width="69" height="33" border="0" class="iconMenu"></a></li>
					</ul>
				</li>
				<li class="has-dropdown">
					<a href="#">Follow</a>
					<ul class="dropdown">
						<li><a href="https://www.linkedin.com/in/teddytirado" target="_blank"><img src="/images/follow/linked_in.gif" alt="LinkedIn" border="0" class="iconMenu"></a></li>
						<li><a href="http://www.facebook.com/teddytirado" target="_blank"><img src="/images/follow/facebook.gif" alt="LinkedIn" border="0" class="iconMenu"></a></li>
						<li><a href="https://twitter.com/teddytirado" target="_blank"><img src="/images/follow/twitter.gif" alt="LinkedIn" border="0" class="iconMenu"></a></li>
						<li><a href="https://myspace.com/teddytirado" target="_blank"><img src="/images/follow/myspace.gif" alt="LinkedIn" border="0" class="iconMenu"></a></li>
					</ul>
				</li>
			</ul>
		</section>
	</nav>
 </div>
 
<!-- #include virtual="/includes/modals/phone.inc" -->

<!-- #include virtual="/includes/modals/text.inc" -->

<!-- #include virtual="/includes/modals/email.inc" -->

<!-- #include virtual="/includes/modals/fax.inc" -->

