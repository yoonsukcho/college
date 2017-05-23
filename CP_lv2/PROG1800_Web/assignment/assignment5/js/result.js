// PROG1800 Sec2 , Assignment 5, 14 April 2016. Yoonsuk Cho #7135551
// javascript file of all result of php 
// function event setting

// call when loading this file
$(function(){
	$('input[type=button]').on('click', function (e) {
		$("div").each(function(){
			$(location).attr("href","index.php");
		});
	});

});
