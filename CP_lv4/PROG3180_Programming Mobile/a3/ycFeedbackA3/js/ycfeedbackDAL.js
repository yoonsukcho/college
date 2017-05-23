/**
 * Assignment3 ycfeedbackDAL.js
 *
 * #7135551 Yoonsuk Cho
 * Created on : Mar 06, 2017, 9:06:36 AM
 * Revised on : Mar 27, 2017
 * PROG3180 Assignment 03
 */


var review ={
    ycinsert: function (options) {

        function txFunction(tx) {

            var sql ="INSERT INTO review (" +
                            "businessName, " +
                            "typeId, " +
                            "reviewerEmail, " +
                            "reviewerComments, " +
                            "reviewDate, " +
                            "hasRating, " +
                            "rating1, " +
                            "rating2, " +
                            "rating3) values " +
                            "(?, ?, ?, ?, ?, ?, ?, ?, ?);";

            function successInsert() {
                console.info("Success: Insert successful");
                alert("New record added");
            }
            tx.executeSql(sql, options, successInsert, errorHandler);
        }
        db.transaction(txFunction, errorHandler, successTransaction);
    },
    ycselect: function (options, successSelectOne) {

        function txFunction(tx) {
            var sql = "SELECT * FROM review WHERE id=?;";
            tx.executeSql(sql, options, successSelectOne, errorHandler);
        }

        db.transaction(txFunction, errorHandler, successTransaction);
    },
    ycselectAll: function (successSelectAll) {

        function txFunction(tx) {
            var sql = "SELECT * FROM review;";
            var options= [];
            tx.executeSql(sql, options, successSelectAll, errorHandler);
        }

        db.transaction(txFunction, errorHandler, successTransaction);
    },

    ycupdate: function (options) {

        function txFunction(tx) {
            var sql = "UPDATE review SET " +
                            "businessName = ?, " +
                            "typeId = ?, " +
                            "reviewerEmail = ?, " +
                            "reviewerComments = ?, " +
                            "reviewDate = ?, " +
                            "hasRating = ?, " +
                            "rating1 = ?, " +
                            "rating2 = ?, " +
                            "rating3 = ?" +
                            "WHERE id=?;";

            function successUpdate() {
                console.info("Success: Update successful");
                alert("Record updated successfully");
            }

            tx.executeSql(sql, options, successUpdate, errorHandler);
        }
        db.transaction(txFunction, errorHandler, successTransaction);

    },
    ycdelete: function (options) {

        function txFunction(tx) {
            var sql = "DELETE FROM review WHERE id=?;";

            function successDelete() {
                console.info("Success: Delete successful");
                alert("Record deleted successfully");
            }

            tx.executeSql(sql, options, successDelete, errorHandler);
        }

        db.transaction(txFunction, errorHandler, successTransaction);

    }
};


var type = {
    ycselectAll: function (successSelectAll) {

        function txFunction(tx) {
            var sql = "SELECT * FROM type;";
            var options = [];
            tx.executeSql(sql, options, successSelectAll, errorHandler);
        }
        db.transaction(txFunction, errorHandler, successTransaction);
    }
};


