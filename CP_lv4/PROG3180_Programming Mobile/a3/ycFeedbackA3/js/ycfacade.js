/**
 * Assignment3 ycfacade.js
 *
 * #7135551 Yoonsuk Cho
 * Created on : Mar 27, 2017, 10:53:12 AM
 *
 * PROG3180 Assignment 03
 */


function ycupdateTypesDropdown() {
    function successSelectAll(tx, results) {
        var htmlCode = "";
        $("#ycType option").remove();
        $("#ycTypeEdit option").remove();

        for (var i = 0; i < results.rows.length; i++) {
            var row = results.rows[i];
            var sel = "";
            if (row['name'] == "Others") {
                sel = "selected";
            }
            $("#ycType").append("<option value='" + row['id'] +
                "' " + sel + ">" + row['name'] + "</option>");
            $("#ycTypeEdit").append("<option value='" + row['id'] +
                "' " + sel + ">" + row['name'] + "</option>");
            //console.info("id: " + row['id'] + " name: " + row['name']);
        }

    }
    type.ycselectAll(successSelectAll);
}

function ycaddFeedback() {

    var businessName = $("#ycBizName").val();
    var typeId = $("#ycType").val();
    var reviewerEmail = $("#ycRevEmail").val();
    var reviewerComments = $("#ycRevCmt").val();
    var reviewDate = $("#ycRevDate").val();
    var hasRating = $("#ycDoAddRate").prop("checked");
    var rating1 = null;
    var rating2 = null;
    var rating3 = null;
    if (hasRating) {
        rating1 = $("#ycFoodQuality").val();
        rating2 = $("#ycService").val();
        rating3 = $("#ycValue").val();
    }

    //insert the data to a table
    var options = [businessName, typeId, reviewerEmail,
                   reviewerComments, reviewDate, hasRating,
                   rating1, rating2, rating3];
    review.ycinsert(options);
}

function ycgetReviews() {

    function successSelectAll(tx, results) {
        var htmlCode = "";
        for (var i = 0; i < results.rows.length; i++) {
            var row = results.rows[i];
            var hasRate = row['hasRating'];
            htmlCode += "<li data-icon='true'>" +
                        "<a data-row-id='" + row['id'] +
                        "'class='ui-btn ui-btn-icon-right ui-icon-carat-r'>" +
                        "<h1>Business Name: " + row['businessName'] + "</h1>" +
                        "<p>Reviewer Email: " + row['reviewerEmail'] + "</p>" +
                        "<p>Comments: " + row['reviewerComments'] + "</p>";
            if (hasRate == 'true') {
                var rate = ( row['rating1'] + row['rating2'] + row['rating3'] ) / 15 * 100;
                htmlCode += "<p>Overall Rating: " + Math.round(rate * 100) / 100 + "% </p>";
            }
            htmlCode += "</a></li>" ;
        }
        var lv = $("#ycFeedbackList");
        lv = lv.html(htmlCode);
        lv.listview("refresh");

        $("#ycFeedbackList a").on("click", clickHandler);

        function clickHandler() {
            localStorage.setItem("id", $(this).attr("data-row-id"));
            $(location).prop('href', "#ycEditFeedbackPage");
        }

    }

    review.ycselectAll(successSelectAll);
}

function ycshowCurrentReview() {
    var id = localStorage.getItem("id");
    var options = [id];

    function successSelectOne(tx, results) {
        var row = results.rows[0];

        $("#ycBizNameEdit").val(row['businessName']);
        $("#ycTypeEdit").val(row['typeId']).change();
        $("#ycRevEmailEdit").val(row['reviewerEmail']);
        $("#ycRevCmtEdit").val(row['reviewerComments']);
        $("#ycRevDateEdit").val(row['reviewDate']);
        if (row['hasRating'] == 'true') {
            $("#ycDoAddRateEdit").prop('checked', true).checkboxradio('refresh');
            $("#ycFoodQualityEdit").val(row['rating1']);
            $("#ycServiceEdit").val(row['rating2']);
            $("#ycValueEdit").val(row['rating3']);
            sumRate('Edit');
        } else {
            $("#ycDoAddRateEdit").prop('checked', false).checkboxradio('refresh');
            $("#ycFoodQualityEdit").val(0);
            $("#ycServiceEdit").val(0);
            $("#ycValueEdit").val(0);
        }
        showHideDiv('Edit');

    }

    review.ycselect(options, successSelectOne);
}

function ycupdateFeedback() {
    var id = localStorage.getItem("id");
    var businessName = $("#ycBizNameEdit").val();
    var typeId = $("#ycTypeEdit").val();
    var reviewerEmail = $("#ycRevEmailEdit").val();
    var reviewerComments = $("#ycRevCmtEdit").val();
    var reviewDate = $("#ycRevDateEdit").val();
    var hasRating = $("#ycDoAddRateEdit").prop("checked");
    var rating1 = null;
    var rating2 = null;
    var rating3 = null;
    if (hasRating) {
        rating1 = $("#ycFoodQualityEdit").val();
        rating2 = $("#ycServiceEdit").val();
        rating3 = $("#ycValueEdit").val();
    }

    //update the data to a table
    var options = [businessName, typeId, reviewerEmail,
        reviewerComments, reviewDate, hasRating,
        rating1, rating2, rating3, id];
    review.ycupdate(options);

    $(location).prop('href', "#ycViewFeedbackPage");
}


function ycdeleteFeedback() {
    var id = localStorage.getItem("id");
    var options = [id];
    review.ycdelete(options);
    $(location).prop('href', "#ycViewFeedbackPage");

}

function ycclearDatabase() {
    try{
        if (db) {
            console.info("Dropping tables ...")
            DB.ycDropTables();
        }
    } catch(e){
        console.error("Error: (Fatal) Error in DropTables, can not proceed");
    }
}


