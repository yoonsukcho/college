/**
Document   : kkycdatabase.js
Created on : Apr 21, 2017

Author     : Kevin Kim, Yoonsuk Cho
PROG3180 Final Projrct
 */

var db;

function errorHandler(tx, error) {
    console.error("SQL error: " + tx + " (" + error.code + ") -- " + error.message);
}

function successTransaction(){
    console.info("Success: Transaction is successful");
}

var DB ={
    kkycCreateDatabase: function(){
        var shortName = "FeedbackDB";
        var version = "1.0";
        var displayName = "DB for FeedbackDB app";
        var dbSize = 2 * 1024 * 1024;

        console.info("Creating Database ....");
        db = openDatabase(shortName, version, displayName, dbSize, dbCreateSuccess);

        function dbCreateSuccess(){
            console.info("Success: Database creation successful");
        }
    },
    kkycCreateTables: function () {
        function txFunction(tx){
            var options = [];

            var sql = "DROP TABLE IF EXISTS province;";
            console.info("Droping table: province");
            tx.executeSql(sql, options, successCreate, errorHandler);

            sql = "CREATE TABLE IF NOT EXISTS province(" +
                "code CHAR(2) NOT NULL PRIMARY KEY," +
                "name VARCHAR(20) NOT NULL);";
            console.info("Creating table: province");
            tx.executeSql(sql, options, successCreate, errorHandler);

            var codes = ["AB", "BC", "MB", "NB", "NL", "NS", "NT", 
                         "NU", "ON", "PE", "QC", "SK", "YT" ];
            var names = ["Alberta", 
                         "British Columbia", 
                         "Manitoba", 
                         "New Brunswick", 
                         "Newfoundland and Labrador", 
                         "Nova Scotia", 
                         "Northwest Territories", 
                         "Nunavut", 
                         "Ontario", 
                         "Prince Edward Island", 
                         "Quebec", 
                         "Saskatchewan", 
                         "Yukon" ];

            for (var i in codes)
            {
                sql = "INSERT INTO province (code, name) VALUES ('" +
                    codes[i] + "', '" + names[i] + "');";
                tx.executeSql(sql, options, successCreate, errorHandler);
            }

            sql = "CREATE TABLE IF NOT EXISTS contacts(" +
                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "name VARCHAR(30) NOT NULL," +
                "phone VARCHAR(15)," +
                "email VARCHAR(50)," +
                "address VARCHAR(50)," +
                "city VARCHAR(30)," +
                "provCode CHAR(2)," +
                "comment TEXT," +
                "reviewDate DATE," +
                "image VARCHAR(30)," +
                "FOREIGN KEY(provCode) REFERENCES province(code));";
            console.info("Creating table: contacts");
            tx.executeSql(sql, options, successCreate, errorHandler);

            function successCreate(){
                console.info("Success: table created successfully");
            }

        }

        db.transaction(txFunction, errorHandler, successTransaction);
    },
    kkycDropTables: function () {

        function txFunction(tx) {
            var options = [];
            console.info("Dropping table: province");
            var sql = "DROP TABLE IF EXISTS province;";
            tx.executeSql(sql, options, successDropType, errorHandler);

            console.info("Dropping table: contacts");
            sql = "DROP TABLE IF EXISTS contacts;";
            tx.executeSql(sql, options, successDropReview, errorHandler);

            function successDropType() {
                console.info("Success: dropping table province successful");
            }

            function successDropReview() {
                console.info("Success: dropping table contacts successful");
                alert("Database cleared");
            }
        }

        db.transaction(txFunction, errorHandler, successTransaction);
    }
};







