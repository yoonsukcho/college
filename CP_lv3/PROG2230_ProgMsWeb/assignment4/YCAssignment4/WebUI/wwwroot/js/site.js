// Write your Javascript code.

function setProductPicture()
{
    imgName = $('input#productImage').val();
    $(".productPicture").attr("src", "/images/" + imgName);
}

