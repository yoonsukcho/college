<%-- 
    Document   : KKYCBAnner
    Created on : Jan 30, 2017, 9:06:36 AM
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="utf-8"%>
<!doctype html>

<html>
<head>
    <meta charset="utf-8">
    <title>KKYC Computer Programming Club</title>
    <link rel="shortcut icon" href="images/favicon.ico">
    <link rel="stylesheet" href="styles/main.css">
    <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
    <style>
        th, td {
            padding: 5px 9px;
            text-align: left;
        }

    </style>
</head>

<body>

    <header>
        <img src="images/kkyc-icon.png" 
             alt="KKYC Computer Programming Club" width="350">
        <h1>KKYC Computer Programming Club</h1>
        <h2>IT@Conestoga</h2>
    </header>
    <nav id="nav_bar">
        <ul>
            <li><a href="KKYCIndex.jsp">
                    Home</a></li>
            <li><a href="KKYCMemberAdmin?action=addMember">
                    Register</a></li>
            <li><a href="KKYCLoan">
                    eLoan</a></li>                    
            <li><a href="KKYCCart">
                    eCart</a></li>                    
            <li><a href="KKYCAdmin.jsp">
                    Admin</a></li>
        </ul>
    </nav>