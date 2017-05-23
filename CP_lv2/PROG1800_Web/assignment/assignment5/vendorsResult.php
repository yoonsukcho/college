<!DOCTYPE html>

<!-- PROG1800 Sec2 , Assignment 5, 14 April 2016. Yoonsuk Cho #7135551 -->
<!-- PHP and Access DB connection  -->
<!-- result of adding vendor table  -->
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta charset="utf-8" />
		<title>Assignment 05 - DB connect</title>
		<script src="http://code.jquery.com/jquery-1.10.2.js"></script>
		<script src="http://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
		<script src="js/result.js"></script>
		<link rel='stylesheet' type='text/css' href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' >
		<link rel="stylesheet" href="css/main.css">
		<?php
			# get error message
			# argument field_value, field_name
			function checkManField($field, $name)
			{
				if (empty($field))
				{
					return $name." field is empty."."<br>";
				}
				else
				{
					return "";
				}
			}
			
			# get error message
			# argument field_value, field_name
			function checkRegExp($field, $name, $regEx)
			{
				$returnMsg = "";
				if (preg_match($regEx, $field))
				{
					$returnMsg = "";
				}
				else
				{
					if ($regEx === '/^[0-9]+$/')  # number only '/^[0-9]+$/'
					{
						$returnMsg = $name." field should consist of all digits."."<br>";
					}
					else if ($regEx === '/^[-@.#&+\w\s]*$/') # alphanumeric only '/^[-@.#&+\w\s]*$/'
					{
						$returnMsg = $name." field should consist of all letters or digits."."<br>";
					}
					else if ($regEx === '/^[a-zA-Z .]+$/')  # alphabet only '/^[a-zA-Z .]+$/'
					{
						$returnMsg = $name." field should consist of all letters."."<br>";
					}
					else if ($regEx === '/^[ABCEGHJKLMNPRSTVXY]\d[A-Z]\d[A-Z]\d$/')  # postal '/^[ABCEGHJKLMNPRSTVXY]\d[A-Z]\d[A-Z]\d$/'
					{
						$returnMsg = "Postal Code field is wrong format. ex) N1N2N3"."<br>";
					}
					else if ($regEx === '/^[0-9]{5}/')  # ZIP '/^[0-9]{5}/'
					{
						$returnMsg = "ZIP code should consist to 5 digits."."<br>";
					}
					
				}
				return $returnMsg;				
			}
					
		?>
	</head>
	<body>
		<div id="allDv"><br><br>
			
			<div class="resultDiv" id="partsDiv">
				Result of Add Vendors  <br>
		
			<div class="btnHomeDiv" >
				<input type="button" name="btnBack" id="btnBack" value="Go Home"/>
			</div>

			<?php
				$dbName = realpath("as4.mdb");
				
				if (!file_exists($dbName)) {
					die("Could not find database file.");
				}
				$db = odbc_connect("Driver={Microsoft Access Driver (*.mdb)}; Dbq=$dbName;", "", "");

				$qryStr = "select max(vendorNo) as maxNumber from vendor;";
				$result = odbc_exec($db, $qryStr);
				echo '<br>';
				$maxNum = odbc_result($result, "maxNumber");
				$maxNum = $maxNum + 1;
				odbc_free_result( $result );  
				odbc_close( $db );  

				$qryFieldName = "vendorNo, ";
				$qryFieldVal = $maxNum.", ";
				$fieldValStr = "";     // for input check
				
				foreach($_POST as $key => $value)
				{
				    if (strpos($key, "submit") !== 0) 
				    {
						if (!empty($value)) 
						{
							$qryFieldName = $qryFieldName.$key.", ";
							if ($key !== "vendorNo") 
							{
								$qryFieldVal = $qryFieldVal."'".$value."', ";
							}
							else 
							{
								$qryFieldVal = $qryFieldVal.$value.", ";
							}
							$fieldValStr = $fieldValStr.$value."|";
						}
				    }
				}
				$qryFieldName = trim($qryFieldName);
				$qryFieldVal = trim($qryFieldVal);
				$fieldValStr = trim($fieldValStr);
				$qryFieldName = substr($qryFieldName, 0, strlen($qryFieldName) - 1);
				$qryFieldVal = substr($qryFieldVal, 0, strlen($qryFieldVal) - 1);
				$fieldValStr = substr($fieldValStr, 0, strlen($fieldValStr) - 1);

				// input check ,mandatory, numeric, alphanumeric
				$fieldVals = explode ( "|" , $fieldValStr);
				$fieldNames = array("Vendor Name", "Address", "City", "prov./State", 
									"postal/Zip", "Country", "Phone", "FAX");
				// 0: vendorName(A), 1: address1(AN), 2: city(A), 3: provState(A), 
				// 4: postalZip(Post), 5: country(A), 6: phone(N), 7: fax(N) 
				$errMsg = "";
				$regPtrn = '';
				for ($i = 0; $i < count($fieldVals); $i++)
				{
					if ($i !== 7)
					{
						$errMsg = $errMsg.checkManField($fieldVals[$i], $fieldNames[$i]);
					}
					if ($i === 2  || $i === 3 || $i === 5)
					{
						$regPtrn = '/^[a-zA-Z .]+$/';
					}
					else if ($i === 6 || $i === 7)
					{
						$regPtrn = '/^[0-9]+$/';
					}
					else if ($i === 0 || $i === 1)
					{
						$regPtrn = '/^[-@.#&+\w\s]*$/';
					}
					else if ($i === 4)
					{
						if ($fieldVals[5] === "Canada")
						{
							$regPtrn = '/^[ABCEGHJKLMNPRSTVXY]\d[A-Z]\d[A-Z]\d$/';
						}
						else
						{
							$regPtrn = '/^[0-9]{5}/';
						}
					}
					$errMsg = $errMsg.checkRegExp($fieldVals[$i], $fieldNames[$i], $regPtrn);
				}
				
				if ($errMsg === "")
				{				
					$qryStr = "INSERT INTO vendor (".$qryFieldName.") VALUES (".$qryFieldVal.");" ;
					//echo $qryStr.'<br>'.'<br>';
					$result = odbc_exec($db, $qryStr);
					//echo $result.'<br>';

					odbc_free_result( $result );  
					odbc_close( $db );
					
					echo "<h2>Add vendor Information was successful.</h2><br>";
					echo "<b>Vendor Number: </b>".$maxNum."<br>";
					for ($i = 0; $i < count($fieldVals); $i++)
					{
						echo "<b>".$fieldNames[$i].": </b>".$fieldVals[$i]."<br>";
					}
				}
				else
				{
					echo "<h3>"."Error has occured"."</h3>";
					echo $errMsg;
				}
				
			?>
			</div>
		</div>
	</body>
</html>