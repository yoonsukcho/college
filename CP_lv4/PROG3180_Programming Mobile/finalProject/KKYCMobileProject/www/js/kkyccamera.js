/**
Document   : kkyccamera.js
Created on : Apr 21, 2017

Author     : Kevin Kim, Yoonsuk Cho
PROG3180 Final Projrct
 */


function capturePhoto() {
    var options = {
        quality: 50,
        destinationType: Camera.DestinationType.FILE_URI, 
		saveToPhotoAlbum: true,
        sourceType: Camera.PictureSourceType.CAMERA
    };

    function onSuccess(imageURI) {
        var image = $("#kkycImg");
        image.prop("src", imageURI);
        $("#kkycImageURI").val(imageURI);
    }

    function onFail(message) {
        alert("Fail because: " + message);
    }

    navigator.camera.getPicture(onSuccess, onFail, options);
}

function capturePhotoEdit() {
    var options = {
        quality: 50,
        destinationType: Camera.DestinationType.FILE_URI, 
		saveToPhotoAlbum: true,
        sourceType: Camera.PictureSourceType.CAMERA
    };

    function onSuccess(imageURI) {
        var image = $("#kkycImgM");
        image.prop("src", imageURI);
        $("#kkycImageURIM").val(imageURI);
    }

    function onFail(message) {
        alert("Fail because: " + message);
    }

    navigator.camera.getPicture(onSuccess, onFail, options);
}


