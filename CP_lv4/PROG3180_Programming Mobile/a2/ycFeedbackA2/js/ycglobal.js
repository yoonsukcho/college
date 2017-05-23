/**
 * Assignment2 ycglobal.js
 *
 * #7135551 Yoonsuk Cho
 * Created on : Mar 06, 2017, 9:06:36 AM
 * PROG3180 Assignment 02
 */

// btn save click event
function btnYcBtnSave_click() {
    if (doValidate_AddForm()) {
        console.info("Add Form is valid");
    }
}

// btn save on edit page click event
function btnYcBtnSaveEdit_click() {
    if (doValidate_EditForm()) {
        console.info("Edit Form is valid");
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
    $("#ycBtnSaveEdit").on("click", btnYcBtnSaveEdit_click);
    $('#ycBtnSettingSave').on('click', ycBtnSettingSave_click);
}

$(document).ready(function () {
    init();
});




