/* javascript file for assignment 4, Yoonsuk Cho #7135551 */

// initialize simplecart module
simpleCart({
	cartColumns: [
		{ attr: "name", label: "Name"},
		{ attr: "option", label: "Option"},
		{ view: "currency", attr: "price", label: "Unit Price"},
		{ view: "decrement" , label: false , text: "-" } ,
		{ attr: "quantity" , label: "Qty" } ,
		{ view: "increment" , label: false , text: "+" } ,
		{ view: "currency", attr: "total", label: "SubTotal" },
		{ view: "remove", text: "Remove", label: false}
	],

	cartStyle: "table", 
	checkout: { 
		type: "SendForm" , 
        url: "http://localhost/receipt.php" 
	},
	currency: "CAD",
	data: {},
	language: "english-us",
	excludeFromCheckout: [],
	shippingCustom: function() {
		var totalAmt = simpleCart.total();
		var shipC = 0;
		if (totalAmt > 0 && totalAmt <= 25)
		{
			shipC = 3;
		}
		else if (totalAmt > 25 && totalAmt <= 50)
		{
			shipC = 4;
		} 
		else if (totalAmt > 50 && totalAmt <= 75)
		{
			shipC = 5;
		} 
		else if (totalAmt > 75)
		{
			shipC = 6;
		}
		return shipC;
	},
	shippingFlatRate: 0,
	shippingQuantityRate: 0,
	shippingTotalRate: 0,
	taxRate: 0.13,
	taxShipping: false,
	beforeAdd		: null,
	afterAdd		: null,
	load			: null,
	beforeSave		: null,
	afterSave		: null,
	update			: null,
	ready			: null,
	checkoutSuccess	: null,
	checkoutFail	: null,
	beforeRemove    : null
});


// simple callback example
simpleCart.bind( 'beforeCheckout' , function( data ){
	if (simpleCart.quantity() == 0) 
	{
		alert("For order, you should select least one item.");
		return false;
	}
	
	var errMsg = checkValue();
	if (errMsg == "")
	{
		data.fname = $("#fname").val();
		data.lname = "";
		data.street = "";
		data.lname = $("#lname").val();
		data.street = $("#street").val();
		data.city = $("#city").val();
		data.province = $("#province").val();
		data.postal = $("#postal").val();
		data.email = $("#email").val();
		
		return true;
	} 
	else
	{
		alert(errMsg);
		return false;
	}
});


// member variables
var ptrnStr = /^[a-zA-Z\.\s]{3,50}$/;
var ptrnNum = /^[0-9\.]*$/;
var ptrnSpe = /^[a-zA-Z0-9#\)\(+=._-\s]+$/;
var ptrnPost = /([A-Z]\d){3}/i;
var ptrnEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9])+$/;
var focusErr = null;

// trim input value
function makeTrim(eleName)
{
	var name = "#" + eleName;
	var str = $(name).val();
	while(str.startsWith(" "))
	{
		str = str.slice(1);
	}
	while(str.endsWith(" "))
	{
		str = str.slice(0, str.length-1);
	}
	$(name).val(str);
	if (eleName != "email")
	{
		makeCapital(eleName);
	}
	return str;
}


// make the first character capitalize
function makeCapital(eleName)
{
	var name = "#" + eleName;
	var str = $(name).val();
	if (str.length > 0)
	{
	    var strArr = str.split(" ");
	    var newStr = "";
	    for (i = 0 ; i < strArr.length; i++)
	    {
	        strArr[i] = strArr[i].charAt(0).toUpperCase() + strArr[i].slice(1);
	        if (strArr[i] != "")
	        {
	            newStr += strArr[i] + " ";
	        }
	    }
	    if (newStr.endsWith(" "))
	    {
	        newStr = newStr.slice(0, newStr.length-1);
	    }
	    $(name).val(newStr);
	}
}

// check string values
function chkStr(eleName, msgName, msg, isMan)
{
	var name = "#" + eleName;
	var valEle = $(name);
	valStr = valEle.val();

	if (valStr.length > 0)
	{
		if (eleName == "email")
		{
			if (!ptrnEmail.test(valStr)) 
			{
				msg = msg + "Enter a valid email address. [" + msgName + "].\n";
				if (focusErr === null)
				{
					focusErr = valEle;
				}
			}
		} else {
			if (!ptrnStr.test(valStr)) 
			{
				msg = msg + "Only alphabets are allowed and" + 
							" the length should be between 3 to 50. [" + msgName + "].\n";
				if (focusErr === null)
				{
					focusErr = valEle;
				}
			}
		}
	}
	else
	{
		if (isMan)
		{
			msg = msg + "Please check the mandatory field. [" + msgName + "].\n";
			if (focusErr === null)
			{
				focusErr = valEle;
			}
		}
	}
	
	return msg; 
}

// check number values
function chkNum(eleName, msgName, msg, isMan)
{
	var name = "#" + eleName;
	var valEle = $(name);
	if (!ptrnNum.test(valEle.val())) 
	{
		msg = msg + "Only numbers are allowed. [" + msgName + "].\n";
		if (focusErr === null)
		{
			focusErr = valEle;
		}
	}
	return msg; 
}

// check all input values and generate result message
function checkValue() 
{

	return "";  // for server test
	
	var errMsg = "";
	focusErr = null;
	var errMsg = "";
	
	errMsg = chkStr("fname", "First Name", errMsg, true);
	errMsg = chkStr("lname", "Last Name", errMsg, true);
	errMsg = chkStr("email", "Email", errMsg, true);
	errMsg = chkStr("city", "City", errMsg, true);

	valEle = $("#street");
	makeTrim("street");
	if (valEle.val().length == 0) 
	{
		errMsg = errMsg + "Please check the mandatory field. [Street].\n";
	}
	if (valEle.val().length > 0 && !ptrnSpe.test(valEle.val())) 
	{
		errMsg = errMsg + "Some specific characters[!$@%^&*] are not allowed [Address].\n";
		if (focusErr === null)
		{
			focusErr = valEle;
		}
	}	

	errMsg = chkStr("city", "city", errMsg, false);
	
	valEle = $("#postal");
	if (valEle.val().length == 0) 
	{
		errMsg = errMsg + "Please check the mandatory field. [Postal Code].\n";
	}	
	if (valEle.val().length > 0 && !ptrnPost.test(valEle.val())) 
	{
		errMsg = errMsg + "Wrong format error. [Postal code - ex) A1A2A3].\n";
		if (focusErr === null)
		{
			focusErr = valEle;
		}
	}
	
	if (focusErr != null)
	{
		focusErr.focus();
	}	

	return errMsg;
}

// make postal code to upper case 
function postUpperCase() 
{
	makeTrim("postal");
	var valEle = $("#postal");
	valEle.val(valEle.val().toUpperCase());
}

// make input to trim and upper case 
$('input[type="text"]').not('.item_Quantity').on('blur', function (e) {
	makeTrim(e.target.id);
});


// make postal to upper case 
$('input[id=postal]').on('blur', function (e) {
	postUpperCase(e.target.id);
});

// change tax rate
$('select[id=province]').on('change', function (e) {
	var prv = e.target.value;
	if (prv =="AB") 
	{
		simpleCart.taxRate(0.05);
	}
	else if (prv =="BC") 
	{
		simpleCart.taxRate(0.12);
	}
	else if (prv =="MB") 
	{
		simpleCart.taxRate(0.13);
	}
	else if (prv =="NB") 
	{
		simpleCart.taxRate(0.13);
	}
	else if (prv =="NL") 
	{
		simpleCart.taxRate(0.13);
	}
	else if (prv =="NS") 
	{
		simpleCart.taxRate(0.15);
	}
	else if (prv =="NT") 
	{
		simpleCart.taxRate(0.05);
	}
	else if (prv =="NU") 
	{
		simpleCart.taxRate(0.05);
	}
	else if (prv =="ON") 
	{
		simpleCart.taxRate(0.13);
	}
	else if (prv =="PE") 
	{
		simpleCart.taxRate(0.14);
	}
	else if (prv =="QC") 
	{
		simpleCart.taxRate(0.14975);
	}
	else if (prv =="SK") 
	{
		simpleCart.taxRate(0.10);
	} 
	else if (prv =="YT") 
	{
		simpleCart.taxRate(0.05);
	}
	simpleCart.update();
});

// init cart
$( document ).ready(function() {
    simpleCart.empty();
});

// make postal to upper case 
$('input[id=postal]').on('blur', function (e) {
	postUpperCase(e.target.id);
});

//Test Data
/* 
$("#fname").val("Tom");
$("#lname").val("Jackson");
$("#street").val("123 King st.");
$("#city").val("Waterloo");
$("#province").val("ON");
$("#postal").val("N1N2N3");
$("#email").val("tom.jackson@abc.def");
 */

