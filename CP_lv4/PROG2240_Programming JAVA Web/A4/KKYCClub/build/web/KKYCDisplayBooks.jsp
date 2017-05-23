<%-- 
    Document   : KKYCDisplayBooks
    Created on : Apr 13, 2017
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<jsp:include page="/includes/KKYCBanner.jsp" />
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<section>
    <h1>Display Books</h1>
    <table>
        <tr>
            <th>Code</th>
            <th>Description</th>
            <th>Quantity</th>
        </tr>
        <c:forEach var="book" items="${books}">
            <tr>
                <td>${book.code}</td>
                <td>${book.description}</td>
                <td>${book.quantity}</td>
            </tr>
        </c:forEach>
    </table>
    <form action="KKYCAddBook.jsp">
        <input type="submit" value="Add Book" id="submit">
    </form>

</section>

<jsp:include page="/includes/KKYCFooter.jsp" />