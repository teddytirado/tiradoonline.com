function bankingTransaction (  ){
	this.transactionid = "1001"
	this.bankingdate = "8/27/12";
	this.transactiontypename = "Rent";
	this.transactionamount = 9.99;
	this.getInfo = function(){
		return this.transactionid;
	}
}

function formatNumber($num, $decPlaces) {
	$numArray = $num.split(".");
	//alert($numArray.length);
	if($numArray.length > 1) {
		$dec = $numArray[1];
		if($dec.length > parseInt($decPlaces)) {
			if($dec.substring($decPlaces + 1, 1) >= 5)
				$dec = parsetInt($dec.substring(1, $decPlaces)) + 1;
			else
				$dec = parsetInt($dec.substring(1, $decPlaces));
		} 
		else {
			for(x = 0; $decPlaces - $dec.length; x++) {
				$dec += "0";
			}
		}
		return numArray[0] + "." + $dec;
	}
	else
		$num;

}


function getAmountColor(v_number) {
	if (v_number < 0)
		return "<span class='negative_number'>" + v_number + "</span>";
	else
		return "<span class='positive_number'>" + v_number + "</span>";
}

function getAccounts(elementobject, selected) {
	$.get("database/tiradointeractive.xml", 
	function($xml) {
		
		$xml = $($xml);
		elementobject.empty();
		$xml.find('account').each(
			function() {
				$accountid = this.getElementsByTagName("accountid")[0].childNodes[0].nodeValue;
				$accountname = this.getElementsByTagName("accountname")[0].childNodes[0].nodeValue;
				if(selected == $accountid)
					$(elementobject).append("<option value='" + $accountid + "' SELECTED>" + $accountname + "</option>");
				else
					$(elementobject).append("<option value='" + $accountid + "'>" + $accountname + "</option>");
			}
		)
	});

	elementobject.val(selected);
}

function getCategories(elementobject, $accountID, selected) {
	$.get("database/tiradointeractive.xml", 
	function($xml) {
		
		$xml = $($xml);
		elementobject.empty();
		$xml.find('account').each(
			function() {
				$accountid = this.getElementsByTagName("accountid")[0].childNodes[0].nodeValue;
				$accountname = this.getElementsByTagName("accountname")[0].childNodes[0].nodeValue;

				if ($accountID != $accountid) {
					if($accountid == selected) 
						$(elementobject).append("<option value='" + $accountid + "' SELECTED>" + $accountname + "</option>");
					else
						$(elementobject).append("<option value='" + $accountid + "'>" + $accountname + "</option>");
				}

			}
		);
	});

	//elementobject.val(selected);
}

function getTransactions(elementobject) {
	$.get("database/tiradointeractive.xml", 
	function($xml) {
		
		$xml = $($xml);
		$('#tableBanking TBODY').text('');
		var $counter = 1;
		var $bankingrow = "";

		// GET PREVIOUS BALANCE		
		$xml.find('balances').each (
			function() {
				$previousbalance = this.getElementsByTagName("previousbalance")[0].childNodes[0].nodeValue;
			}
		);

		var $balance = parseFloat($previousbalance);
		$('#previousbalance').html(getAmountColor($balance));
		$('#bankingaccountid').val("1002");
		$('#bankingaccountmonth').val("9");
		$('#bankingaccountyear').val("2012");

		$xml.find('transaction').each(
			function() {	
				try {
					$transactionid = this.getElementsByTagName("transactionid")[0].childNodes[0].nodeValue;
					$transactiondate = this.getElementsByTagName("transactiondate")[0].childNodes[0].nodeValue;
					$transactionaccountid = this.getElementsByTagName("accountid")[0].childNodes[0].nodeValue;
					$transactionaccountname = this.getElementsByTagName("accountname")[0].childNodes[0].nodeValue;
					$transactiontypeid = this.getElementsByTagName("transactiontypeid")[0].childNodes[0].nodeValue;
					$transactiontypename = this.getElementsByTagName("transactiontypename")[0].childNodes[0].nodeValue;
					$transactionamount = this.getElementsByTagName("amount")[0].childNodes[0].nodeValue;
					eval('var transaction' + $transactionid + ' = new bankingTransaction();');
					eval('transaction' + $transactionid + '.transactionid = ' + $transactionid + ';');
					$balance += parseFloat($transactionamount);
					//$balance = formatNumber(String($balance)));
					$transactionmemo = this.getElementsByTagName("memo")[0].childNodes[0].nodeValue;
					var $bankingrow = "";
					$bankingrow += "<tr valign='top' class='bankingTableRow'  transactionid='" + $transactionid + "' transactiondate='" + $transactiondate+ "' transactionaccountid='" + $transactionaccountid + "' transactiontypeid='" + $transactiontypeid + "' transactionamount='" + $transactionamount + "'  transactionmemo='"+ $transactionmemo + "'>\n";
					$bankingrow += "<td align='right' rowspan='2'>" + $transactiondate + "</td>\n";
					//$bankingrow += "<td rowspan='2'>" + $transactionaccountname + "</td>\n";
					$bankingrow += "<td><a href='#'  transactionid='" + $transactionid + "' transactiondate='" + $transactiondate+ "' transactionaccountid='" + $transactionaccountid + "' transactiontypeid='" + $transactiontypeid + "' transactionamount='" + $transactionamount + "'  transactionmemo='"+ $transactionmemo + "'>" + $transactiontypename + "</td>\n";
					$bankingrow += "<td align='right' rowspan='2'>" + getAmountColor($transactionamount) + "</td>\n";
					$bankingrow += "<td align='right' rowspan='2'>" + getAmountColor($balance) + "</td>\n";
					$bankingrow += "</tr>\n";
					$bankingrow += "<tr valign='top' class='bankingTableData_white'><td>" + $transactionmemo + "</td></tr>\n"
					$('#tableBanking TBODY').append($bankingrow);
					$counter++;
				} catch (evt) {
					alert(evt);
				}
			}
		)
		$( "tr a").parent().parent().click
			(function(e) {
				e.preventDefault();
				$( "#dialogTransaction" ).dialog( "open" );
				$( "#transactiondate" ).val($(this).attr('transactiondate'));
				//$( "#transactionaccountid").val($(this).attr('transactionaccountid'));
				//$( "#transactiontypeid").val($(this).attr('transactiontypeid'));
				$( "#transactionamount" ).val($(this).attr('transactionamount'));
				$( "#transactionmemo" ).val($(this).attr('transactionmemo'));
				getTransactionTypes($( "#transactiontypeid"), $(this).attr('transactiontypeid') );				
				getAccounts($( "#transactionaccountid"), $(this).attr('transactionaccountid') );				

				//getTransactions($('#tableBanking TBODY'));
			});
		$( "tr")
			.mouseenter(function(e) {
				if(this.className == 'bankingTableRow') {
					this.className = 'bankingTableRow_HOVER';					
				} 
			})
			.mouseleave(function(e) {
				if(this.className == 'bankingTableRow_HOVER') {
					this.className = 'bankingTableRow';					
				} 
		})
	});

}
	
function getTransactionsDateBox(elementobjectmonth, elementobjectyear, hiddenfield) {

	selectedmonth = "5"
	selectedyear = "2005"
	elementobjectmonth.empty();
	elementobjectyear.empty();

	if($hiddenfield = "")
		$hiddenfield = new Date();

	$.get("database/tiradointeractive.xml", 
	function($xml) {
		
		$xml = $($xml);
		$xml.find('month').each(
			function() {
				$monthid = this.getElementsByTagName("monthid")[0].childNodes[0].nodeValue;
				$monthname = this.getElementsByTagName("monthname")[0].childNodes[0].nodeValue;

				if(selectedmonth == $monthid)
					elementobjectmonth.append("<option value='" + $monthid + "' SELECTED>" + $monthname + "</option>");
				else
					elementobjectmonth.append("<option value='" + $monthid + "'>" + $monthname + "</option>");

			}
		)
	});

	for (x = 2012; x >= 2000; x--) {
		if(parseInt(x) == parseInt(selectedyear))
			elementobjectyear.append("<option value='" + x + "' SELECTED>" + x + "</option>");
		else
			elementobjectyear.append("<option value='" + x + "'>" + x + "</option>");
	}
		
}

function getTransactionTypes(elementobject, selected) {
		
	$.get("database/tiradointeractive.xml", 
	function($xml) {
		
		$xml = $($xml);
		elementobject.empty();
		$xml.find('transactiontype').each(
			function() {
				$transactiontypeid = this.getElementsByTagName("transactiontypeid")[0].childNodes[0].nodeValue;
				$transactiontypename = this.getElementsByTagName("transactiontypename")[0].childNodes[0].nodeValue;
				if(selected == $transactiontypeid)
					$(elementobject).append("<option value='" + $transactiontypeid + "' SELECTED>" + $transactiontypename + "</option>");
				else
					$(elementobject).append("<option value='" + $transactiontypeid + "'>" + $transactiontypename + "</option>");

			}
		)
	});
	
}
