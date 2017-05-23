/**
Document   : kkycutil.js
Created on : Apr 21, 2017

Author     : Kevin Kim, Yoonsuk Cho
PROG3180 Final Projrct
 */

// Calculate sum of rates
/*function sumRate(name) {
    var i = 0;
    var sumRate = 0;
    var className = ".ycSumSrc" + name;
    var targetId = "#ycOvrRate" + name;
    $(className).each(function(){
        i++;
        sumRate += parseInt($(this).val()) || 0;
    });
    sumRate = sumRate / 15 * 100
    $(targetId).val(sumRate + '%');
}*/

// Show or hide parts depending on check box
function showHideDiv(name) {
    var divName = "#ycRateDiv" + name;
    var chkName = "#ycDoAddRate" + name;
    if ($(chkName).prop('checked') == true) {
        $(divName).show();
    } else {
        $(divName).hide();
    }
}

// check validation of add form
function doValidate_AddForm() {
    var form = $("#kkycAddForm");
    form.validate({
        rules: {
            kkycName: {
                required: true,
                rangelength: [2, 30]
            },
            kkycPhone: {
                phoneUS: true
            },
            kkycEmail: {
                rangelength: [3, 50],
                email: true
            },
            kkycAddress: {
                rangelength: [5, 50]
            },
            kkycCity: {
                rangelength: [2, 30]
            }
        },
        messages: {
            kkycName: {
                required: "You must enter Name",
                rangelength: "Name must be 2-20 characters long"
            },
            kkycPhone: {
                phoneUS: "Please enter a valid phone number"
            },
            kkycEmail: {
                rangelength: "Email must be 3-50 characters long",
                email: "Please enter a valid email"
            },
            kkycAddress: {
                rangelength: "Address must be 5-50 characters long"
            },
            kkycCity: {
                rangelength: "City must be 2-30 characters long"
            }

        }
    });

    return form.valid();
}


// check validation of add form
function doValidate_EditForm() {
    var form = $("#kkycModifyForm");
    form.validate({
        rules: {
            kkycNameM: {
                required: true,
                rangelength: [2, 30]
            },
            kkycPhoneM: {
                phoneUS: true
            },
            kkycEmailM: {
                rangelength: [3, 50],
                email: true
            },
            kkycAddressM: {
                rangelength: [5, 50]
            },
            kkycCityM: {
                rangelength: [2, 30]
            }
        },
        messages: {
            kkycNameM: {
                required: "You must enter Name",
                rangelength: "Name must be 2-20 characters long"
            },
            kkycPhoneM: {
                phoneUS: "Please enter a valid phone number"
            },
            kkycEmailM: {
                rangelength: "Email must be 3-50 characters long",
                email: "Please enter a valid email"
            },
            kkycAddressM: {
                rangelength: "Address must be 3-50 characters long"
            },
            kkycCityM: {
                rangelength: "City must be 2-30 characters long"
            }

        }
    });

    return form.valid();
}

// check validation of setting form
function doValidate_SettingForm() {
    var form = $("#ycSettingForm");
    form.validate({
        rules: {
            ycDefaultEmail: {
                checkemail:true
            }
        },
        messages: {
            ycDefaultEmail: {
                checkemail: "Please enter a valid email address"
            }
        }
    });

    return form.valid();
    
}

function clearFields() {
        $("#kkycName").val("");
        $("#kkycPhone").val("");
        $("#kkycEmail").val("");
        $("#kkycAddress").val("");
        $("#kkycCity").val("");
        $("#kkycProv").val('ON').change();
        $("#kkycCmt").val("");    
        $("#kkycImg").prop('src', "img/unknown.png");   
        $("#kkycImageURI").val("img/unknown.png");   
}

// email validation check for jquery validate rules method
//jQuery.validator.addMethod("checkemail",
//    function (value, element) {
//        var regex = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
//        return regex.test(value);
//
//    }, "Valid an email address is required");



