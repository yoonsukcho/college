// Write your Javascript code.

// function getBytes
// This function can get byte array from string variable.

String.prototype.getBytes = function () {
    var bytes = [];
    for (var i = 0; i < this.length; ++i) {
        bytes.push(this.charCodeAt(i));
    }
    return bytes;
};

$(document).ready(function () {
    $("input[id$='Location']").keyup(function () {
        var loc = $("input[id$='Location']").val();
        byteArray = loc.getBytes();
        hash = 0;
        for (i = 0; byteArray.length; i++) {
            if (isNaN(byteArray[i])) {
                break;
            } else {
                hash = hash + byteArray[i];
            }
        }
        $("#locationHashDiv").text("currently: " + hash);
        $("#LocationHash").val(hash);
    });
});
