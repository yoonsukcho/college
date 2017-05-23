<!DOCTYPE html>

<!-- PROG1800 Sec2 , Assignment 5, 14 April 2016. Yoonsuk Cho #7135551 -->
<!-- PHP and Access DB connection  -->
<!-- test on the class  -->
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta charset="utf-8" />
		<title>Test</title>
		<script src="http://code.jquery.com/jquery-1.10.2.js"></script>
		<script src="http://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
		<script src="js/index.js"></script>
		<link rel='stylesheet' type='text/css' href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' >
		<link rel="stylesheet" href="css/main.css">
		<script type="text/javascript">
			answer = 10;
			document.write("The answer is: " + answer);
		</script>
<?php
	$answer = 10;
		?>
	</head>
	<body>
<?php
		echo "<br><br><br>";
		print "The answer is: .$answer";
		echo "<br>";
		echo 'The answer is: .$answer';
		echo "<br>";
		echo "<br>";

$list = array('Reading','Writing','Arithmetic','Spelling');		
print "$list[3], $list[2], $list[1], $list[0]";
echo "<br>";
sort($list);
foreach ($list as $item)
{
	print " $item, ";
	//print " $list, ";
}
		echo "<br>";

$testArray = array("a"=>"AA", "b"=>"BB");
foreach ( $testArray as $prtKey=>$prtValue) {
	echo '$prtKey: '.$prtKey.' => '.'$prtValue: '.$prtValue;
	echo "<br>";
}
	echo "<br>";
	echo "<br>";
echo '$prtArray["a"]: '.$testArray['a'].', ';		
		echo "<br>";
echo '$prtArray["b"]: '.$testArray['b'].', ';		

$fName = realpath("as4.mdb");
echo "<br>";
echo $fName;

$db = new COM("ADODB.Connection");
$db -> Open("Provider=Microsoft.Jet.OLEDB.4.0; DataSource=$fName");
$rs = $db->Execute("select * from vendor");
//echo $rs;
echo $rs->RecordCount()

?>
	
	</body>
</html>