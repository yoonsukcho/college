/**
 * Assignment2 ycutil.js
 *
 * #7135551 Yoonsuk Cho
 * Created on : Mar 06, 2017, 9:06:36 AM
 * PROG3180 Assignment 02
 */

// Calculate sum of rates
function sumRate(name) {
    var i = 0;
    var sumRate = 0;
    var className = ".ycSumSrc" + name;
    var targetId = "#ycOvrRate" + name;
    $(className).each(function(){
        i++;
        console.log('* val[' + i + ']: ' + $(this).val() + ' id: ' + $(this).attr('id'))
        sumRate += parseInt($(this).val()) || 0;
    });
    console.log('===== sumRate: ' + sumRate)
    sumRate = sumRate / 15 * 100
    $(targetId).val(sumRate + '%');
}

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
    var form = $("#ycAddForm");
    form.validate({
        rules: {
            ycBizName: {
                required: true,
                rangelength: [2, 20]
            },
            ycRevEmail: {
                required: true,
                checkemail:true
            },
            ycRevDate: {
                required: true
            },
            ycFoodQuality: {
                rateCheck: true
            },
            ycService: {
                rateCheck: true
            },
            ycValue: {
                rateCheck: true
            }

        },
        messages: {
            ycBizName: {
                required: "You must enter Business name",
                rangelength: "Business name must be 2-20 characters long"
            },
            ycRevEmail: {
                required: "You must enter the Reviewer email",
                checkemail: "Please enter a valid email address"
            },
            ycRevDate: {
                required: "Review date is required"
            },
            ycFoodQuality: {
                rateCheck: "Value must be 0-5"
            },
            ycService: {
                rateCheck: "Value must be 0-5"
            },
            ycValue: {
                rateCheck: "Value must be 0-5"
            }

        }
    });

    return form.valid();
}


// check validation of add form
function doValidate_EditForm() {
    var form = $("#ycEditForm");
    form.validate({
        rules: {
            ycBizNameEdit: {
                required: true,
                rangelength: [2, 20]
            },
            ycRevEmailEdit: {
                required: true,
                checkemail:true
            },
            ycRevDateEdit: {
                required: true
            },
            ycFoodQualityEdit: {
                rateEditCheck: true
            },
            ycServiceEdit: {
                rateEditCheck: true
            },
            ycValueEdit: {
                rateEditCheck: true
            }

        },
        messages: {
            ycBizNameEdit: {
                required: "You must enter Business name",
                rangelength: "Business name must be 2-20 characters long"
            },
            ycRevEmailEdit: {
                required: "You must enter the Reviewer email",
                checkemail: "Please enter a valid email address"
            },
            ycRevDateEdit: {
                required: "Review date is required"
            },
            ycFoodQualityEdit: {
                rateEditCheck: "Value must be 0-5"
            },
            ycServiceEdit: {
                rateEditCheck: "Value must be 0-5"
            },
            ycValueEdit: {
                rateEditCheck: "Value must be 0-5"
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

// check range of rate value
function checkRateValue(value, checkBoxName) {
    if ($(checkBoxName).prop('checked') == true && (value >= 0 && value <= 5)) {
        return true;
    }
    return false;
}

// validation of rate in add check for jquery validate rules method
jQuery.validator.addMethod("rateCheck",
    function (value, element) {
        if (value == '' || isNaN(value)) $(element).val('0');
        return checkRateValue(value, '#ycDoAddRate');
    },
    "Value must be 0-5");

// validation of rate in modify check for jquery validate rules method
jQuery.validator.addMethod("rateEditCheck",
    function (value, element) {
        if (value == '' || isNaN(value)) $(element).val('0');
        return checkRateValue(value, '#ycDoAddRateEdit');
    },
    "Value must be 0-5");

// email validation check for jquery validate rules method
jQuery.validator.addMethod("checkemail",
    function (value, element) {
        var regex = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
        return regex.test(value);

    }, "Valid an email address is required");



