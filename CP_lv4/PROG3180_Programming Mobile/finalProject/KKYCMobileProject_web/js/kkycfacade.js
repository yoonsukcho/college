/**
Document   : kkycfacade.js
Created on : Apr 21, 2017

Author     : Kevin Kim, Yoonsuk Cho
PROG3180 Final Projrct
 */


function kkycupdateProvinceDropdown() {
    function successSelectAll(tx, results) {
        var htmlCode = "";
        $("#kkycProv option").remove();
        $("#kkycProvM option").remove();
        //$("#kkycProvD option").remove();

        for (var i = 0; i < results.rows.length; i++) {
            var row = results.rows[i];
            var sel = "";
            if (row['code'] == "ON") {
                sel = "selected";
            }
            $("#kkycProv").append("<option value='" + row['code'] +
                "' " + sel + ">" + row['name'] + "</option>");
            $("#kkycProvM").append("<option value='" + row['code'] +
                "' " + sel + ">" + row['name'] + "</option>");
            //$("#kkycProvD").append("<option value='" + row['code'] +
            //    "' " + sel + ">" + row['name'] + "</option>");
            //console.info("rowid: " + row['rowid'] + ", code: " + row['code'] + ", name: " + row['name']);
        }

    }
    province.kkycselectAll(successSelectAll);
}

function kkycaddContact() {

    var name = $("#kkycName").val();
    var phone = $("#kkycPhone").val();
    var email = $("#kkycEmail").val();
    var address = $("#kkycAddress").val();
    var city = $("#kkycCity").val();
    var prov = $("#kkycProv").val();
    var cmt = $("#kkycCmt").val();
    var imgUrl = $("#kkycImageURI").val();

    //insert the data to a table
    var options = [name, phone, email, address, city, prov, cmt, imgUrl];
    contacts.kkycinsert(options);
}

function kkycgetContacts() {

    function successSelectAll(tx, results) {
        var htmlCode = "";
        for (var i = 0; i < results.rows.length; i++) {
            var row = results.rows[i];
            var imgPath = row['image'];
            if (imgPath == null || imgPath == "")
                imgPath = "img/unknown.png";
            console.info("imgPath: " + imgPath);
            htmlCode += "<li data-icon='true'>" +
                        "<a data-row-id='" + row['id'] +
                        "'class='ui-btn ui-btn-icon-right ui-icon-carat-r'>" +
                        "<img src=" + imgPath + " style='width: 80px height: 80px; margin-top: 10px; margin-left: 10px;'>" + 
                        "<h1>Name: " + row['name'] + "</h1>" +
                        "<p><b>phone: " + row['phone'] + "</b></p>" +
                        "<p><b>email: " + row['email'] + "</b></p>";
            htmlCode += "</a></li>" ;
        }
        var lv = $("#kkycContactList");
        lv = lv.html(htmlCode);
        lv.listview("refresh");

        $("#kkycContactList a").on("click", clickHandler);

        function clickHandler() {
            localStorage.setItem("id", $(this).attr("data-row-id"));
            $(location).prop('href', "#kkycDetail");
        }

    }

    contacts.kkycselectAll(successSelectAll);
}

function kkycshowCurrentContact() {
    var id = localStorage.getItem("id");
    var options = [id];

    function successSelectOne(tx, results) {
        var row = results.rows[0];

        $("#kkycNameD").html(row['name']);
        $("#kkycPhoneD").html(row['phone']);
        
        $("#kkycphoneLink").prop('href', "tel:" + row['phone']);  
        
        $("#kkycEmailD").html(row['email']);
        $("#kkycAddressD").html(row['address']);
        $("#kkycCityD").html(row['city']);
        var provName = "";
        
        function successSelectProv(tx, result) {
            var row1 = result.rows[0];
            provName = row1['name'];
            $("#kkycProvD").html(provName);
            console.info("provName: " + provName);
        }
        var imgPath = row['image'];
        if (imgPath == null || imgPath == "")
            imgPath = "img/unknown.png";
        province.kkycselect([row['provCode']], successSelectProv);
        $("#kkycCmtD").val(row['comment']);
        $("#kkycImgD").prop('src', imgPath);  

    }

    contacts.kkycselect(options, successSelectOne);
}


function kkycshowCurrentContactForModify() {
    var id = localStorage.getItem("id");
    var options = [id];

    function successSelectOne(tx, results) {
        var row = results.rows[0];
        
        $("#kkycNameM").val(row['name']);
        $("#kkycPhoneM").val(row['phone']);
        $("#kkycEmailM").val(row['email']);
        $("#kkycAddressM").val(row['address']);
        $("#kkycCityM").val(row['city']);
        $("#kkycProvM").val(row['provCode']).change();
        $("#kkycCmtM").val(row['comment']);        
        $("#kkycImgM").prop('src', row['image']);   
        $("#kkycImageURIM").val(row['image']);

    }

    contacts.kkycselect(options, successSelectOne);
}

function kkycupdateContacts() {
    var id = localStorage.getItem("id");

    var name = $("#kkycNameM").val();
    var phone = $("#kkycPhoneM").val();
    var email = $("#kkycEmailM").val();
    var address = $("#kkycAddressM").val();
    var city = $("#kkycCityM").val();
    var prov = $("#kkycProvM").val();
    var cmt = $("#kkycCmtM").val();
    var imgUrl = $("#kkycImageURIM").val();


    //insert the data to a table
    var options = [name, phone, email, address, city, prov, cmt, imgUrl, id];
    contacts.kkycupdate(options);

}


function kkycdeleteContacts() {
    var id = localStorage.getItem("id");
    var options = [id];
    contacts.kkycdelete(options);
    $(location).prop('href', "#kkycList");
}

function kkycclearDatabase() {
    try{
        if (db) {
            console.info("Dropping tables ...")
            DB.kkycDropTables();
        }
    } catch(e){
        console.error("Error: (Fatal) Error in DropTables, can not proceed");
    }
}


