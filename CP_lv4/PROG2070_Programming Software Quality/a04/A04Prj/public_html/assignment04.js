//----- PROG2070 – Quality Assurance: Winter 2017 
// Assignment 4, Apr. 4, 2017. Yoonsuk Cho #7135551 ----//

//Basic Member Variable
var endYear = new Date().getFullYear();
var ptrnStr = /^[a-zA-Z0-9#\)\(+=._-\s]{3,50}$/;
var ptrnNum = /^[0-9\.]*$/;
var ptrnSpe = /^[a-zA-Z0-9#\)\(+=._-\s]+$/;
var ptrnPost = /([A-Z]\d){3}/i;
var ptrnEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9])+$/;
var ptrnPhone = /((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}/;
var focusErr = null;
var jdPowerUrl = "";

// move to input page
function moveInput() {
    window.location.href = "input.html";
}

// move to list page
function moveList() {
    window.location.href = "list.html"; 
}

function moveIndex() {
    window.location.href = "index.html"; 
}

// Submit function
function submitForm() 
{
	var retVal = checkValue();
	if (retVal == "")
	{
		var localId = sessionStorage.getItem("lastNum");
        if (localId == "NaN" || localId == NaN ||
            localId == null) {
            localId = '0';
        }
        var id = parseInt(localId);
        id += 1;
    
        sessionStorage.setItem("lastNum", id);
        
        var name = document.getElementById('name').value;
        var address = document.getElementById('address').value;
        var city = document.getElementById('city').value;
        var phoneNumber = document.getElementById('phoneNumber').value;
        var email = document.getElementById('email').value;
        var make = document.getElementById('make').value;
        var model = document.getElementById('model').value;
        var year = document.getElementById('year').value;

        var str = "<tr>";
        str += "<td>" + name + "</td>";
        str += "<td>" + address + "</td>";
        str += "<td>" + city + "</td>";
        str += "<td>" + phoneNumber + "</td>";
        str += "<td>" + email + "</td>";
        str += "<td>" + make + "</td>";
        str += "<td>" +  model + "</td>";
        str += "<td>" + year + "</td>";
        str += "</tr>";
        
        sessionStorage.setItem(id, str);	
        
        var url = "http://www.jdpower.com/cars/";
        url += make + "/";
        url += model + "/";
        url += year + "/";
        jdPowerUrl = url;
        window.open(jdPowerUrl);
        
	}
	else
	{
		alert(retVal);
	}
}

function setUrl() {
    document.getElementById('anotherSite').src = jdPowerUrl;
}

function makeList() {
    var list = "";
    var localId = sessionStorage.getItem("lastNum");
    if (localId == "NaN" || localId == NaN ||
        localId == null) {
        localId = '0';
    }
    var id = parseInt(localId);   
    
    list += "<tr><td>Name</td><td>Address</td><td>City</td>";
    list += "<td>Phone No</td><td>email</td><td>Make</td>";
    list += "<td>Model</td><td>Year</td></tr>";
    for (i = 0; i < id; i++) {
        var key = (i + 1) + "";
        list += sessionStorage.getItem(key);
    }
    console.info(list);
    document.getElementById("listTable").innerHTML = list;
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
		if (eleName == "email")
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
	
	errMsg = chkStr("name", "Seller Name", errMsg, true);
	errMsg = chkStr("address", "Address", errMsg, true);
	errMsg = chkStr("city", "City", errMsg, true);
	errMsg = chkStr("phoneNumber", "Phone Number", errMsg, true);
	errMsg = chkStr("email", "eMail", errMsg, true);
	errMsg = chkStr("make", "Vehicle make", errMsg, true);
	errMsg = chkStr("model", "Vehicle model", errMsg, true);
	errMsg = chkStr("year", "Vehicle year", errMsg, true);
	
	valEle = document.getElementById("phoneNumber");
	if (!ptrnPhone.test(valEle.value)) 
	{
		errMsg = errMsg + "Wrong format error. [Phone Number - ex) 123-456-7890].\n";
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
	makeTrim("PostalCode");
	var valEle = document.getElementById("PostalCode");
	valEle.value = valEle.value.toUpperCase();
}







