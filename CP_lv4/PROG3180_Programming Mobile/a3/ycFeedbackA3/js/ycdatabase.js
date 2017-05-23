/**
 * Assignment3 ycdatabase.js
 *
 * #7135551 Yoonsuk Cho
 * Created on : Mar 06, 2017, 9:06:36 AM
 * Revised on : Mar 27, 2017
 * PROG3180 Assignment 03
 */

var db;

function errorHandler(tx, error) {
    console.error("SQL error: " + tx + " (" + error.code + ") -- " + error.message);
}

function successTransaction(){
    console.info("Success: Transaction is successful");
}

var DB ={
    ycCreateDatabase: function(){
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
    ycCreateTables: function () {
        function txFunction(tx){
            var options = [];

            var sql = "DROP TABLE IF EXISTS type;";
            console.info("Droping table: type");
            tx.executeSql(sql, options, successCreate, errorHandler);

            sql = "CREATE TABLE IF NOT EXISTS type(" +
                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "name VARCHAR(20) NOT NULL);";
            console.info("Creating table: type");
            tx.executeSql(sql, options, successCreate, errorHandler);

            var names = ["Canadian", "Asian", "Others"];

            for (var i in names)
            {
                sql = "INSERT INTO type (name) VALUES ('" +
                    names[i] + "');";
                tx.executeSql(sql, options, successCreate, errorHandler);
            }

            sql = "CREATE TABLE IF NOT EXISTS review(" +
                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "businessName VARCHAR(30) NOT NULL," +
                "typeId INTEGER NOT NULL," +
                "reviewerEmail VARCHAR(30)," +
                "reviewerComments TEXT," +
                "reviewDate DATE," +
                "hasRating VARCHAR(1)," +
                "rating1 INTEGER," +
                "rating2 INTEGER," +
                "rating3 INTEGER," +
                "FOREIGN KEY(typeId) REFERENCES type(id));";
            console.info("Creating table: review");
            tx.executeSql(sql, options, successCreate, errorHandler);

            function successCreate(){
                console.info("Success: table created successfully");
            }

        }

        db.transaction(txFunction, errorHandler, successTransaction);
    },
    ycDropTables: function () {

        function txFunction(tx) {
            var options = [];
            console.info("Dropping table: type");
            var sql = "DROP TABLE IF EXISTS type;";
            tx.executeSql(sql, options, successDropType, errorHandler);

            console.info("Dropping table: review");
            sql = "DROP TABLE IF EXISTS review;";
            tx.executeSql(sql, options, successDropReview, errorHandler);

            function successDropType() {
                console.info("Success: dropping table type successful");
            }

            function successDropReview() {
                console.info("Success: dropping table review successful");
                alert("Database cleared");
            }
        }

        db.transaction(txFunction, errorHandler, successTransaction);
    }
};







