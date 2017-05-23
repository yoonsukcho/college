// PROG1800 Sec2 , Assignment 5, 14 April 2016. Yoonsuk Cho #7135551
// javascript file of index.php 
// function event setting

// call when loading this file
$(function(){

// set function of all buttons onClick event
	$('input[type=button]').on('click', function (e) {
		$("div").each(function(){
			if (this.id.endsWith("Div") && (e.target.id + "Div" != this.id) )
			{
				$(this).hide();
			} else {

				$(this).show();
			}
		});
	});
	
// set function of all forms onSubmit event
	$('form').on('submit', function(e) {
		var act = $(this).attr("id").substring(0, $(this).attr("id").length - 4);
		errMsg = checkMandatory(act);
		if (errMsg != "")
		{
			alert(errMsg);
			return false;
		}
		if (this.id.endsWith("Form"))
		{
			$(this).attr("method", "POST");
			$(this).attr("action", act + "Result.php");
		}
	});
	
// set function of provState select onChange event
	$('select[id=provState]').on('change', function (e) {
		if ($("#provState option:selected").text().match(/CA$/) )
		{
			$('#country').val("Canada");
		}
		else
		{
			$('#country').val("U.S.A.");
		}
	});
	
// set ajax function of vendorNumber select onChange event
	$('#vendorNumber').on('change', function (e) {
		$.ajax({
			  method: "POST",
			  url: "queryResultAjax.php",
			  data: { "vendorNo": e.target.value }
			})
			.done(function( msg ) {
				$("#ajaxResult").html(msg);
		});
	});
	
	$("#parts").click();
	$('select[id=provState]').change();
	$("#vendorNumber").change();
});


// check fields if it is mandatory
// focus at the first field which has occured error
// argument: form name
function checkMandatory(formName)
{
	var fields;
	var errField = "";
	var errMsg = "";
	if (formName == "parts")
	{
		fields = {	"vendorNo":"Vendor Name", "description":"Description", 
					"onHand":"onHand", "onOrder":"onOrder", 
					"cost":"Cost", "listPrice":"List Price"	};
	}
	else if (formName == "vendors")
	{
		fields = {	"vendorName":"Vendor Name", "address1":"Address", 
					"city":"City", "provState":"Province or State", 
					"postalZip":"Postal or Zip", "country":"Country", 
					"phone":"Phone"	};
	}
	else
	{
		fields = {	"vendorNo":"Vendor No"	};
	}
	
	$.each( fields, function( name, sign ){
		if ($.trim($('#' + name).val()) === "") 
		{
			errMsg = errMsg + sign + " is a mandatory Field.\n";
			if (errField == "")
			{
				$('#' + name).focus();
				errField = name;
			}
		}
	});

	return errMsg;
	
}
