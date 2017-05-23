<%-- 
    Document   : KKYCAddBook
    Created on : Feb 24, 2017, 8:03:24 AM
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.util.*" %> 

<!DOCTYPE html>
<jsp:include page="includes/KKYCBanner.jsp" />

<!-- start the middle column -->

<section>
    <h1>Add a Book</h1>
    <p style="color: red; font-style: italic;">${message}</p>
    <form action="KKYCAddBook" method="post">
        <label for="code">Code: </label>
        <input type="text" name="code" id="code" 
               style="width: 100px;" value="${book.code}"><br>
        <label for="description">Description: </label>
        <input type="text" name="description" id="description" 
               style="width: 300px;" value="${book.description}"><br>
        <label for="quantity">Quantity: </label>
        <input type="text" name="quantity" id="quantity" 
               style="width: 50px;" value="${quantity}"><br>    
        <label></label>
        <input type="submit" value="Save" id="submit">
        <input type="submit" formmethod="post" 
               formaction="KKYCDisplayBooks" value="Cancel" id="cancel">
    </form>

</section>

<!-- end the middle column -->

<jsp:include page="includes/KKYCFooter.jsp" />