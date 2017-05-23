<!DOCTYPE html>

<!-- PROG1800 Sec2 , Assignment 5, 14 April 2016. Yoonsuk Cho #7135551 -->
<!-- PHP and Access DB connection  -->
<!-- initial of access DB index.php  -->
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta charset="utf-8" />
		<title>Assignment 05 - DB connect</title>
		<script src="http://code.jquery.com/jquery-1.10.2.js"></script>
		<script src="http://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
		<script src="js/index.js"></script>
		<link rel='stylesheet' type='text/css' href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' >
		<link rel="stylesheet" href="css/main.css">
	</head>
<?php
		$dbName = realpath("as4.mdb");
		if (!file_exists($dbName)) {
			die("Could not find database file.");
		}
		$db = odbc_connect("Driver={Microsoft Access Driver (*.mdb)}; Dbq=$dbName;", "", "");
		$qryStr = "select vendorNo, vendorName from vendor;";
		$result = odbc_exec($db, $qryStr);

		$vendorSel = "<select name='vendorNo' id='vendorNo'>";
		$vendorSel2 = "<select name='vendorNo' id='vendorNumber'>";
		while(odbc_fetch_row($result)){
			for($i=1;$i<=odbc_num_fields($result);$i=$i+2){
				$vendorSel = $vendorSel."<option value='".odbc_result($result, "vendorNo")."'>";
				$vendorSel = $vendorSel.odbc_result($result, "vendorName")."</option>"."\n";
				$vendorSel2 = $vendorSel2."<option value='".odbc_result($result, "vendorNo")."'>";
				$vendorSel2 = $vendorSel2.odbc_result($result, "vendorName")."</option>"."\n";
			}
		}
		$vendorSel = $vendorSel."</select>";
		$vendorSel2 = $vendorSel2."</select>";

		odbc_free_result( $result );  
		odbc_close( $db );  		
?>	
	
	<body>
		<div id="allDv">
			<input type="button" name="parts" id="parts" value="PARTS"/>
			<input type="button" name="vendors" id="vendors" value="VENDORS"/>
			<input type="button" name="query" id="query" value="QUERY"/>
			
			<div class="eachDiv" id="partsDiv">
				<form name="partsForm" id="partsForm">
					<span class="label">Vendor Name</span><?php	echo $vendorSel; ?>
					<span class="label">Description</span><input type="text" name="description" id="description" class="char_l"/>
					<span class="label">on Hand</span><input type="text" name="onHand" id="onHand" class="num"/>
					<span class="label">on Order</span><input type="text" name="onOrder" id="onOrder" class="num" />
					<span class="label">Cost</span><input type="text" name="cost" id="cost" class="num" />
					<span class="label">List Price</span><input type="text" name="listPrice" id="listPrice" class="num" />
					<div class="btnDiv" >
						<input type="submit" name="submit1" id="submit1" value="SUBMIT"/>
						<input type="reset" name="reset1" id="reset1" value="RESET"/>
					</div>
				</form>
			</div>

			<div class="eachDiv"  id="vendorsDiv">
				<form name="vendorsForm" id="vendorsForm">
					<span class="label">Vendor Name</span><input type="text" name="vendorName" id="vendorName" class="char_l"/><br>
					<span class="label">Address</span><input type="text" name="address1" id="address1" class="char_l"/><br>
					<span class="label">City</span><input type="text" name="city" id="city" class="char_m"/><br>
					<span class="label">Prov./State</span>
						<select name="provState" id="provState" class="char_l">
							<option value="AB">Alberta, CA</option>
							<option value="BC">British Columbia, CA</option>
							<option value="MB">Manitoba, CA</option>
							<option value="NB">New Brunswick, CA</option>
							<option value="NL">Newfoundland and Labrador, CA</option>
							<option value="NT">Northwest Territories, CA</option>
							<option value="NS">Nova Scotia, CA</option>
							<option value="NU">Nunavut, CA</option>
							<option value="ON">Ontario, CA</option>
							<option value="PE">Prince Edward Island, CA</option>
							<option value="QC">Quebec, CA</option>
							<option value="SK">Saskatchewan, CA</option>
							<option value="YT">Yukon, CA</option>
							<option value="AL">Alabama, US</option>
							<option value="AK">Alaska, US</option>
							<option value="AZ">Arizona, US</option>
							<option value="AR">Arkansas, US</option>
							<option value="CA">California, US</option>
							<option value="CO">Colorado, US</option>
							<option value="CT">Connecticut, US</option>
							<option value="DE">Delaware, US</option>
							<option value="DC">District of Columbia, US</option>
							<option value="FL">Florida, US</option>
							<option value="GA">Georgia, US</option>
							<option value="HI">Hawaii, US</option>
							<option value="ID">Idaho, US</option>
							<option value="IL">Illinois, US</option>
							<option value="IN">Indiana, US</option>
							<option value="IA">Iowa, US</option>
							<option value="KS">Kansas, US</option>
							<option value="KY">Kentucky, US</option>
							<option value="LA">Louisiana, US</option>
							<option value="ME">Maine, US</option>
							<option value="MD">Maryland, US</option>
							<option value="MA">Massachusetts, US</option>
							<option value="MI">Michigan, US</option>
							<option value="MN">Minnesota, US</option>
							<option value="MS">Mississippi, US</option>
							<option value="MO">Missouri, US</option>
							<option value="MT">Montana, US</option>
							<option value="NE">Nebraska, US</option>
							<option value="NV">Nevada, US</option>
							<option value="NH">New Hampshire, US</option>
							<option value="NJ">New Jersey, US</option>
							<option value="NM">New Mexico, US</option>
							<option value="NY">New York, US</option>
							<option value="NC">North Carolina, US</option>
							<option value="ND">North Dakota, US</option>
							<option value="OH">Ohio, US</option>
							<option value="OK">Oklahoma, US</option>
							<option value="OR">Oregon, US</option>
							<option value="PA">Pennsylvania, US</option>
							<option value="RI">Rhode Island, US</option>
							<option value="SC">South Carolina, US</option>
							<option value="SD">South Dakota, US</option>
							<option value="TN">Tennessee, US</option>
							<option value="TX">Texas, US</option>
							<option value="UT">Utah, US</option>
							<option value="VT">Vermont, US</option>
							<option value="VA">Virginia, US</option>
							<option value="WA">Washington, US</option>
							<option value="WV">West Virginia, US</option>
							<option value="WI">Wisconsin, US</option>
							<option value="WY">Wyoming, US</option>					
						</select><!--<input type="text" name="provState" id="provState" class="char_m"/><br>-->
					<span class="label">Postal/Zip</span><input type="text" name="postalZip" id="postalZip" class="char_s"/><br>
					<span class="label">Country</span><input type="text" name="country" id="country" class="char_s" readonly /><br>
					<span class="label">Phone</span><input type="text" name="phone" id="phone" class="char_s"/><br>
					<span class="label">FAX</span><input type="text" name="fax" id="fax" class="char_s"/><br>
					<div class="btnDiv" >
						<input type="submit" name="submit1" id="submit2" value="SUBMIT"/>
						<input type="reset" name="reset1" id="reset2" value="RESET"/>
					</div>
				</form>
			</div>

			<div class="each2Div"  id="queryDiv">
				<form name="queryForm" id="queryForm">
					<span class="label">Vendor Name</span><?php	echo $vendorSel2; ?>
					<div id="ajaxResult"></div>

				</form>
			</div>
			
			<div id="dialog" title="Error Message">

			</div>			
				
		</div>
	</body>
</html>	