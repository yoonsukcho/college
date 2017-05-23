<!-- PROG1800 Sec2 , Assignment 5, 14 April 2016. Yoonsuk Cho #7135551 -->
<!-- PHP and Access DB connection  -->
<!-- ajax result of vendor information  -->
<?php
	$vendorNo = $_POST["vendorNo"];

	$dbName = realpath("as4.mdb");
	//echo $dbName;
	//phpinfo();
	
	if (!file_exists($dbName)) {
		die("Could not find database file.");
	}
	$db = odbc_connect("Driver={Microsoft Access Driver (*.mdb)}; Dbq=$dbName;", "", "");
	$qryVndStr = "select format(vendorNo, '0') as [Vendor No], vendorName as [Vendor Name], ".
			  "address1 as [Address], City, provState as [Prov/Stat], ".
			  "postalZip as [Postal/Zip], Country, Phone, ".
			  "IIF(ISNULL(FAX), '', FAX) as [Fax No] from vendor where vendorNo=".$vendorNo;

	$result=odbc_exec($db, $qryVndStr);
	echo '<br>';
	echo '<br><b>Vendor Detail</b><br>';
	echo '<div class="firstTable">';
	odbc_result_all ($result);
	echo '</div>';
	$qryPrtStr = "select partID as [Part ID], format(vendorNo,'0') as [Vendor No], ".
			  "Description, format(onHand, '0') as [on Hand], format(onOrder, '0') as [on Order], ".
			  "format(Cost, '$#,##0.00') as [Expense], format(listPrice, '$#,##0.00') as [List Price] ".
			  "from part where vendorNo=".$vendorNo;
	
	$result=odbc_exec($db, $qryPrtStr);
	echo '<br><b>Parts List</b><br>';
	echo '<div class="secondTable">';
	odbc_result_all ($result);
	echo '</div>';
	echo '<br>';
	
	odbc_free_result( $result );  
	odbc_close( $db );
?>
