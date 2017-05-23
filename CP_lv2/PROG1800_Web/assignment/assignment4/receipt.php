<!DOCTYPE html>

<!-- PROG1800 Sec2 , Assignment 4, 10 March 2016. Yoonsuk Cho #7135551 -->
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta charset="utf-8" />
	<title>Assignment 04 - Receipt</title>
	<script src="http://code.jquery.com/jquery-1.10.2.js"></script>
	<script src="http://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
	<link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' rel='stylesheet' type='text/css'>
<!--
	<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
	<link rel="stylesheet" href="http://jqueryui.com/resources/demos/style.css">
-->
	<link rel="stylesheet" href="css/main.css">
	<?php
		# get item option
		# argument options value
		function getOption($str)
		{
			return substr($str, strpos($str, "option") + 8);
		}
		
		# get tax rate of province
		# argument province code
		function getTaxRate($prv)
		{
				if ($prv =="AB") 
				{
					return 0.05;
				}
				else if ($prv =="BC") 
				{
					return 0.12;
				}
				else if ($prv =="MB") 
				{
					return 0.13;
				}
				else if ($prv =="NB") 
				{
					return 0.13;
				}
				else if ($prv =="NL") 
				{
					return 0.13;
				}
				else if ($prv =="NS") 
				{
					return 0.15;
				}
				else if ($prv =="NT") 
				{
					return 0.05;
				}
				else if ($prv =="NU") 
				{
					return 0.05;
				}
				else if ($prv =="ON") 
				{
					return 0.13;
				}
				else if ($prv =="PE") 
				{
					return 0.14;
				}
				else if ($prv =="QC") 
				{
					return 0.14975;
				}
				else if ($prv =="SK") 
				{
					return 0.10;
				} 
				else if ($prv =="YT") 
				{
					return 0.05;
				}			
		}
		
		# get delivery fee
		# argument product cost
		function getDelivery($amt)
		{
			if ($amt > 0 && $amt <= 25)
			{
				return 3;
			}
			else if ($amt > 25 && $amt <= 50)
			{
				return 4;
			} 
			else if ($amt > 50 && $amt <= 75)
			{
				return 5;
			} 
			else if ($amt > 75)
			{
				return 6;
			}
			return 0;			
		}
		
		# get shipping period
		# argument product cost
		function getShipPrd($amt)
		{
			if ($amt > 0 && $amt <= 50)
			{
				return 1;
			} 
			else if ($amt > 50 && $amt <= 75)
			{
				return 3;
			} 
			else if ($amt > 75)
			{
				return 4;
			}
			return 1;			
		}
		
		# get error message
		# argument field_value, field_name
		function checkManField($field, $name)
		{
			if (empty($field))
			{
				return $name." field is empty.";
			}
			else
			{
				return "";
			}
		}
		
		# get error message
		# argument postalCode
		function validatePostal($postalCode)
		{
			$regStr = "/^([a-ceghj-npr-tv-z]){1}[0-9]{1}[a-ceghj-npr-tv-z]{1}[0-9]{1}[a-ceghj-npr-tv-z]{1}[0-9]{1}$/i";
			if(preg_match($regStr ,$postalCode))
				return "";
			else
				return "Invalid Postal Code";
		}
		
	?>
	

</head>

<body>
	<div id="all_frame">
		<?php 
		# member variables
		$cnt = $_POST["itemCount"];
		$itemStr = array($cnt);	
		$total = 0;

		$hasError = false;
		$errCnt = 9;
		$eMsg = array($errCnt);

		$eMsg[1] = checkManField($_POST["fname"], "First Name");
		$eMsg[2] = checkManField($_POST["lname"], "Last Name");
		$eMsg[3] = checkManField($_POST["email"], "Email");
		$eMsg[4] = checkManField($_POST["street"], "Street");
		$eMsg[5] = checkManField($_POST["city"], "City");
		$eMsg[6] = checkManField($_POST["province"], "Province");
		$email = $_POST["email"];
		if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
		  $eMsg[7] = "Invalid email format"; 
		}
		$eMsg[8] = checkManField($_POST["postal"], "Postal Code");
		$eMsg[9] = validatePostal($_POST["postal"]);

		$errorRow = 0;
		for ($i = 1; $i <= $errCnt; $i++ )
		{
			if (!empty($eMsg[$i]))
			{
				$hasError = true;
				$errorRow = $errorRow + 1;
			}
		}

		if ($hasError)
		{
		?>	
			<table id="shipTo">
				<tr>
					<td rowspan="<?php $errorRow?>" id="shipTitle" style="width: 33%;"><b>Error has occured!:<b>
					</td>
					<td>&nbsp;
					</td>
				</tr>
		<?php 
		for ($i = 1; $i <= $errCnt; $i++ )
		{
			if (!empty($eMsg[$i]))
			{
				echo "<tr><td>$eMsg[$i]</td></tr>";
			}
		}
		?>	
				
			</table><br><br>			
		<?php 	
		}
		else
		{
		
		?>

			<table id="shipTo">
				<tr>
					<td rowspan="5" id="shipTitle"><b>Shipping To:<b>
					</td>
					<td><?php echo $_POST["fname"]." ".$_POST["lname"]; ?>
					</td>
				</tr>
				<tr>
					<td><?php echo $_POST["street"] ?>
					</td>
				</tr>
				<tr>
					<td><?php echo $_POST["city"].", ".$_POST["province"]; ?>
					</td>
				</tr>
				<tr>
					<td><?php echo substr($_POST["postal"], 0, 3)." ".substr($_POST["postal"], 3) ; ?>
					</td>
				</tr>
				<!--<tr>
					<td><?php echo $_POST["email"] ?>
					</td>
				</tr>-->
			</table><br><br>
			<table id="orderInfo">
				<tr>
					<td colspan="2" id="orderInfoTitle">Order information:
					</td>
				</tr>
				<tr>
					<td colspan="2" id="orderInfoMsg">Your Order is Processed, Please verify the information
					</td>
				</tr>
				<?php
				for ($i = 1; $i <= $cnt; $i++ )
				{
					$price = $_POST["item_price_".$i];
					$cnts = $_POST["item_quantity_".$i];
					$amt = $price * $cnts;
					$total = $total + $amt;
					$itemStr[$i] = $_POST["item_quantity_".$i];
					$itemStr[$i] = $itemStr[$i]." ".$_POST["item_name_".$i];
					$itemStr[$i] = $itemStr[$i]."(".getOption($_POST["item_options_".$i]).")";
					$itemStr[$i] = $itemStr[$i]." at $".$_POST["item_price_".$i];
					$itemStr[$i] = $itemStr[$i]." each extends cost "."$"." $amt"."<br>";
					echo "<tr><td class='eachItem' colspan='2' >$itemStr[$i]</td></tr>";
				}
				?>
				<tr>
					<td colspan="2" class="orderSummary">
					<?php
					$taxAmt = number_format(getTaxRate($_POST["province"]) * $total, 2);
					echo "Tax = "."$"."$taxAmt";
					?>
					</td>
				</tr>
				<tr>
					<td colspan="2" class="orderSummary">
					<?php
					$delvr = number_format(getDelivery($total), 2);
					echo "Delivery = "."$"."$delvr";
					?>
					</td>
				</tr>
				<tr>
					<td colspan="2" class="orderSummary">
					<?php
					$Grdtotal = number_format($total + $taxAmt + $delvr, 2);
					echo "Total order is: "."$"."$Grdtotal";
					?>
					</td>
				</tr>
				<tr>
				<?php
					$shipPrd = getShipPrd($total);
					$shipDate = date('jS \of F Y ', time() + ($shipPrd * 24 * 60 * 60));
				?>
					<td colspan="2" class="orderSummary">Estimated Delivery Date is: <?php echo "$shipDate";  ?>
					</td>
				</tr>
			</table>
		<?php
		}
		?>
	<div id="back" class="btns"><a href="javascript:;" >Go Back</a></div>
	</div>
	<script src="js/receipt.js"></script>
</body>
</html>