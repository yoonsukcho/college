/**
Document   : kkycfeedbackDAL.js
Created on : Apr 21, 2017

Author     : Kevin Kim, Yoonsuk Cho
PROG3180 Final Projrct
 */


var contacts ={
    kkycinsert: function (options) {

        function txFunction(tx) {

            var sql ="INSERT INTO contacts (" +
                            "name, " +
                            "phone, " +
                            "email, " +
                            "address, " +
                            "city, " +
                            "provCode, " +
                            "comment, " +
                            "reviewDate, " + 
                            "image)" + 
                            " VALUES " +
                            "(?, ?, ?, ?, ?, ?, ?, datetime('now', 'localtime'), ?);";

            function successInsert() {
                console.info("Success: Insert successful");
                alert("New record added");
                $(location).prop('href', "#kkycList");
                clearFields();
            }
            tx.executeSql(sql, options, successInsert, errorHandler);
        }
        db.transaction(txFunction, errorHandler, successTransaction);
    },
    kkycselect: function (options, successSelectOne) {

        function txFunction(tx) {
            var sql = "SELECT * FROM contacts WHERE id=?;";
            tx.executeSql(sql, options, successSelectOne, errorHandler);
        }

        db.transaction(txFunction, errorHandler, successTransaction);
    },
    kkycselectAll: function (successSelectAll) {

        function txFunction(tx) {
            var sql = "SELECT * FROM contacts;";
            var options= [];
            tx.executeSql(sql, options, successSelectAll, errorHandler);
        }

        db.transaction(txFunction, errorHandler, successTransaction);
    },

    kkycupdate: function (options) {

        function txFunction(tx) {
            var sql = "UPDATE contacts SET " +
                            "name = ?, " +
                            "phone = ?, " +
                            "email = ?, " +
                            "address = ?, " +
                            "city = ?, " +
                            "provCode = ?, " +
                            "comment = ?, " +
                            "reviewDate = datetime('now', 'localtime'), " +
                            "image = ?" + 
                            "WHERE id = ?;";

            function successUpdate() {
                console.info("Success: Update successful");
                alert("Record updated successfully");
                $(location).prop('href', "#kkycList");
            }

            tx.executeSql(sql, options, successUpdate, errorHandler);
        }
        db.transaction(txFunction, errorHandler, successTransaction);

    },
    kkycdelete: function (options) {

        function txFunction(tx) {
            var sql = "DELETE FROM contacts WHERE id=?;";

            function successDelete() {
                console.info("Success: Delete successful");
                alert("Record deleted successfully");
            }

            tx.executeSql(sql, options, successDelete, errorHandler);
        }

        db.transaction(txFunction, errorHandler, successTransaction);

    }
};


var province = {
    kkycselectAll: function (successSelectAll) {

        function txFunction(tx) {
            var sql = "SELECT * FROM province;";
            var options = [];
            tx.executeSql(sql, options, successSelectAll, errorHandler);
        }
        db.transaction(txFunction, errorHandler, successTransaction);
    },
    kkycselect: function (options, successSelectProv) {

        function txFunction(tx) {
            var sql = "SELECT * FROM province WHERE code=?;";
            tx.executeSql(sql, options, successSelectProv, errorHandler);

        }

        db.transaction(txFunction, errorHandler, successTransaction);
    }
};


