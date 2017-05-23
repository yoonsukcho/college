//----- JavaScript file for assignment 2, Yoonsuk Cho #7135551 ----//

//Basic Member Variable
var endYear = new Date().getFullYear();
var ptrnStr = /^[a-zA-Z\.\s]{3,50}$/;
var ptrnNum = /^[0-9\.]*$/;
var ptrnSpe = /^[a-zA-Z0-9#\)\(+=._-\s]+$/;
var ptrnPost = /([A-Z]\d){3}/i;
var ptrnEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9])+$/;
var focusErr = null;

// Submit function
function submitForm() 
{
	var retVal = checkValue();
	if (retVal == "")
	{
		document.form.submit();		
	}
	else
	{
		alert(retVal);
	}
}

// trim input value
function makeTrim(eleName)
{
	var str = document.getElementById(eleName).value;
	while(str.startsWith(" "))
	{
		str = str.slice(1);
	}
	while(str.endsWith(" "))
	{
		str = str.slice(0, str.length-1);
	}
	document.getElementById(eleName).value = str;
	if (eleName != "Email")
	{
		makeCapital(eleName);
	}
	return str;
}


// make the first character capitalize
function makeCapital(eleName)
{
	var str = document.getElementById(eleName).value;
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
	    document.getElementById(eleName).value = newStr;
	}
}

// check string values
function chkStr(eleName, msgName, msg, isMan)
{
	var valEle = document.getElementById(eleName);
	valStr = valEle.value;

	if (valStr.length > 0)
	{
		if (eleName == "Email")
		{
			if (!ptrnEmail.test(valEle.value)) 
			{
				msg = msg + "Enter a valid email address. [" + msgName + "].\n";
				if (focusErr === null)
				{
					focusErr = valEle;
				}
			}
		} else {
			if (!ptrnStr.test(valEle.value)) 
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
	var valEle = document.getElementById(eleName);
	if (!ptrnNum.test(valEle.value)) 
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
	var errMsg = "";
	focusErr = null;
	var errMsg = "";
	
	errMsg = chkStr("Surname", "Surname", errMsg, true);
	errMsg = chkStr("Givenname", "Given Name", errMsg, true);
	errMsg = chkStr("Email", "Email", errMsg, true);
	errMsg = chkStr("BirthCity", "Place of birth City", errMsg, true);
	errMsg = chkStr("BirthCountry", "Place of birth Country", errMsg, true);

	errMsg = chkNum("Height", "Height", errMsg, true);
	errMsg = chkNum("Weight", "Weight", errMsg, false);

	valEle = document.getElementById("Address");
	makeTrim("Address");
	if (valEle.value.length > 0 && !ptrnSpe.test(valEle.value)) 
	{
		errMsg = errMsg + "Some specific characters[!$@%^&*] are not allowed [Address].\n";
		if (focusErr === null)
		{
			focusErr = valEle;
		}
	}	

	errMsg = chkStr("City", "City", errMsg, false);
	
	valEle = document.getElementById("PostalCode");
	if (valEle.value.length > 0 && !ptrnPost.test(valEle.value)) 
	{
		errMsg = errMsg + "Wrong format error. [Postal code - ex) A1A2A3].\n";
		if (focusErr === null)
		{
			focusErr = valEle;
		}
	}
	if (Confirm.checked != true)
	{
		errMsg = errMsg + "Confirm must be checked.";
		if (focusErr === null)
		{
			focusErr = document.getElementById("Confirm");
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
	makeTrim("PostalCode");
	var valEle = document.getElementById("PostalCode");
	valEle.value = valEle.value.toUpperCase();
}

// initialize year select tag
function initSelect()
{
	var year = document.getElementById("Year");
	for (i = (endYear - 120); i < endYear; i++)
	{
		var opt = document.createElement("option");
		opt.value = i;
		opt.text = i;
		if (i == (endYear - 20))
		{
			opt.selected = "selected";
		}
		year.appendChild(opt)
	}

	setDays(endYear - 20, 1);

}

// set Calendar date
function setDays(year, month)
{
	var dd = new Date(year, month, 0);
 	var lastDay = dd.getDate();
 	var days = document.getElementById("Day");
 	days.innerHTML = "";
	for (i = 1; i <= lastDay; i++)
	{
		var opt = document.createElement("option");
		opt.value = i;
		opt.text = i;
		if (i == 1)
		{
			opt.selected = "selected";
		}
		days.appendChild(opt)
	}
}





