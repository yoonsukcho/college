<!DOCTYPE html>

<!-- PROG1800 Sec2 , Assignment 5, 14 April 2016. Yoonsuk Cho #7135551 -->
<!-- PHP and Access DB connection  -->
<!-- result of adding part table  -->
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
			function checkNum($field, $name)
			{
				if (is_numeric($field))
				{
					return "";
				}
				else
				{
					return $name." field should be a number."."<br>";
				}
			}
			
			# get error message
			# argument field_value, field_name
			function checkAlphaNum($field, $name)
			{
				if (ctype_alnum($field))
				{
					return "";
				}
				else
				{
					return $name." field should consist of all letters or digits."."<br>";
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
					if ($regEx === '/^[0-9.]+$/')  # number only '/^[0-9\.]+$/'
					{
						$returnMsg = $name." field should consist of all digits."."<br>";
					}
					else if ($regEx === '/^[-@.#&+\w\s]*$/') # alphanumeric only '/^[-@.#&+\w\s]*$/'
					{
						$returnMsg = $name." field should consist of all letters or digits."."<br>";
					}
					else if ($regEx === '/^[a-zA-Z ]+$/')  # alphabet only '/^[a-zA-Z ]+$/'
					{
						$returnMsg = $name." field should consist of all letters."."<br>";
					}
				}
				return $returnMsg;				
			}
								
		?>
	</head>
	<body>
		<div id="allDv"><br><br>

			<div class="resultDiv" id="partsDiv">
				Result of Add Part  <br>
		
			<div class="btnHomeDiv" >
				<input type="button" name="btnBack" id="btnBack" value="Go Home"/>
			</div>
		
			<?php
				$qryFieldName = "";    // for query
				$qryFieldVal = "";     // for query
				$fieldValStr = "";     // for input check
				
				foreach($_POST as $key => $value)
				{
				    if (strpos($key, "submit") !== 0) 
				    {
					    $qryFieldName = $qryFieldName.$key.", ";
					    if ($key === "description") 
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
				$qryFieldName = trim($qryFieldName);
				$qryFieldVal = trim($qryFieldVal);
				$fieldValStr = trim($fieldValStr);
				$qryFieldName = substr($qryFieldName, 0, strlen($qryFieldName) - 1);
				$qryFieldVal = substr($qryFieldVal, 0, strlen($qryFieldVal) - 1);
				$fieldValStr = substr($fieldValStr, 0, strlen($fieldValStr) - 1);
				
				// input check ,mandatory, numeric, alphanumeric
				$fieldVals = explode ( "|" , $fieldValStr);
				$fieldNames = array("Vendor No", "Description", "onHand", "onOrder", "Cost", "List Price");
				// 0: vendorNo(N), 1: description(AN), 2: onHand(N), 3: onOrder(N), 4: cost(N), 5: listPrice(N) 
				$errMsg = "";
				for ($i = 0; $i < count($fieldVals); $i++)
				{
					$errMsg = $errMsg.checkManField($fieldVals[$i], $fieldNames[$i]);
					if ($i === 1)
					{
						$errMsg = $errMsg.checkRegExp($fieldVals[$i], $fieldNames[$i], '/^[-@.#&+\w\s]*$/');
					}
					else
					{
						$errMsg = $errMsg.checkRegExp($fieldVals[$i], $fieldNames[$i], '/^[0-9.]+$/');
					}
				}
				
				if ($errMsg === "")
				{
					$dbName = realpath("as4.mdb");
					//echo preg_match('/^[a-zA-Z ]+$/', "asdasdasda asdasdasd");
					if (!file_exists($dbName)) {
						die("Could not find database file.");
					}
					$db = odbc_connect("Driver={Microsoft Access Driver (*.mdb)}; Dbq=$dbName;", "", "");
					
					$qryStr = "INSERT INTO part (".$qryFieldName.") VALUES (".$qryFieldVal.");" ;
					//echo $qryStr.'<br>'.'<br>';
					$result = odbc_exec($db, $qryStr);
					//echo $result.'<br>';
					
					odbc_free_result( $result );  
					odbc_close( $db );  					
					echo "<h3>Add part Information was successful.</h3><br>";
					for ($i = 0; $i < count($fieldVals); $i++)
					{
						echo "<b>".$fieldNames[$i].": </b>".$fieldVals[$i]."<br>";
					}
				}
				else
				{
					for ($i = 0; $i < count($fieldVals); $i++)
					{
						echo "<b>".$fieldNames[$i].": </b>".$fieldVals[$i]."<br>";
					}
					echo "<h3>"."Error has occured"."</h3>";
					echo $errMsg;
				}

			?>
			</div>
		</div>
	</body>
</html>