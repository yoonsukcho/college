/**
Document   : kkycglobal.js
Created on : Apr 21, 2017

Author     : Kevin Kim, Yoonsuk Cho
PROG3180 Final Projrct
 */

// btn save click event
function btnkkycBtnSave_click() {
    if (doValidate_AddForm()) {
        console.info("Add Form is valid");
        kkycaddContact();
    } else {
        console.info("Add Form is not valid");
    }

}

// btn modify click event
function btnkkycBtnModify_click() {
    $(location).prop('href', "#kkycModify");
    kkycshowCurrentContactForModify();
}

// btn save on edit page click event
function btnkkycBtnSaveM_click() {
    if (doValidate_EditForm()) {
        console.info("Edit Form is valid");
        kkycupdateContacts();
    } else {
        console.info("Edit Form is not valid");
    }
}

function btnkkycBtnDelete_click() {
    kkycdeleteContacts();
}

function btnkkycBtnCancelM_click() {
    clearFields();
    $(location).prop('href', "#kkycList");
}


// init all events
function init() {

    $(document).on("deviceready", document_deviceready);

    $("#kkycBtnSave").on("click", btnkkycBtnSave_click);
    $("#kkycBtnSaveM").on("click", btnkkycBtnSaveM_click);
    $('#kkycBtnDelete').on('click', btnkkycBtnDelete_click);
    $('#kkycBtnModify').on('click', btnkkycBtnModify_click);
    $('#kkycBtnCancelM').on('click', btnkkycBtnCancelM_click);

    $('#kkycList').on('pageshow', kkycgetContacts);
    $("#kkycDetail").on("pageshow",kkycshowCurrentContact);

    kkycupdateProvinceDropdown();
    kkycgetContacts();
    
    
    $('#kkycImg').on('click', ImgCapturePhoto_click);
    $('#kkycImgM').on('click', ImgCapturePhotoEdit_click);

}

function document_deviceready() {
    console.info("Device is ready");
    cameraReady = true;
    $("#kkycImg").text("Camera is ready, take a picture");
}

function initDB() {
    console.info("Creating database...");
    try{
        DB.kkycCreateDatabase();
        if (db) {
            console.info("Creating tables ...")
            DB.kkycCreateTables();
        }
    } catch(e){
        console.error("Error: (Fatal) Error in initDB, can not proceed");
    }
}

var cameraReady = false;

$(document).ready(function () {
    initDB();
    init();
});

function ImgCapturePhoto_click() {
    if (cameraReady) {
        capturePhoto();
    } else {
        alert("Camera is not ready");
    }
}


function ImgCapturePhotoEdit_click() {
    if (cameraReady) {
        capturePhotoEdit();
    } else {
        alert("Camera is not ready");
    }
}



