/**
 * Assignment3 ycglobal.js
 *
 * #7135551 Yoonsuk Cho
 * Created on : Mar 06, 2017, 9:06:36 AM
 * Revised on : Mar 27, 2017
 * PROG3180 Assignment 03
 */

// btn save click event
function btnYcBtnSave_click() {
    if (doValidate_AddForm()) {
        console.info("Add Form is valid");
        ycaddFeedback();
    } else {
        console.info("Add Form is not valid");
    }

}

// btn save on edit page click event
function btnYcBtnUpdate_click() {
    if (doValidate_EditForm()) {
        console.info("Edit Form is valid");
        ycupdateFeedback();
    } else {
        console.info("Edit Form is not valid");
    }
}

// btn setting save click event
function ycBtnSettingSave_click() {
    if (doValidate_SettingForm()) {
        localStorage.setItem("DefaultEmail", $('#ycDefaultEmail').val());
        alert("Default reviewer email saved.");
    }
    
}

// init event of input elements which are related with rate
function initRateInput(name) {
    var sumArr = $('.ycSumSrc' + name);
    sumArr.each(function(){
        $(this).val(0);
    });
    sumArr.on('keyup', function() {
        sumRate(name);
    });    
}

function ycAddFeedbackPage_Show() {
    // var defaultEmail = localStorage.getItem("DefaultEmail");
    // if (defaultEmail == null || defaultEmail == undefined)
    // {
    //     localStorage.setItem("DefaultEmail", $('#ycDefaultEmail').val());
    // }
    defaultEmail = localStorage.getItem("DefaultEmail");
    $("#ycRevEmail").val(defaultEmail);
}

function btnycBtnDelete_click() {
    ycdeleteFeedback();
}

function btnycBtnClearDB_click() {
    if (confirm("Really want to clear database?")) {
        ycclearDatabase();
    }
}

// init all events
function init() {

    $('#ycDoAddRate').on('click', function() {
        showHideDiv('');
    });

    $('#ycDoAddRateEdit').on('click', function() {
        showHideDiv('Edit');
    });

    initRateInput('');
    initRateInput('Edit');

    $("#ycBtnSave").on("click", btnYcBtnSave_click);
    $("#ycBtnUpdate").on("click", btnYcBtnUpdate_click);
    $('#ycBtnDelete').on('click', btnycBtnDelete_click);

    $('#ycBtnSettingSave').on('click', ycBtnSettingSave_click);
    $('#ycBtnClearDB').on('click', btnycBtnClearDB_click);

    $('#ycAddFeedbackPage').on('pageshow', ycAddFeedbackPage_Show);
    $('#ycViewFeedbackPage').on('pageshow', ycgetReviews);
    $('#ycEditFeedbackPage').on('pageshow', ycshowCurrentReview);

    ycupdateTypesDropdown();

}

function initDB() {
    console.info("Creating database...");
    try{
        DB.ycCreateDatabase();
        if (db) {
            console.info("Creating tables ...")
            DB.ycCreateTables();
        }
    } catch(e){
        console.error("Error: (Fatal) Error in initDB, can not proceed");
    }
}

$(document).ready(function () {
    initDB();
    init();
});




