<%-- 
    Document   : KKYCECart
    Created on : Mar 21, 2017, 12:50:44 PM
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<jsp:include page="/includes/KKYCBanner.jsp" />
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<section>
    <c:set var="total" value="${0}" scope="page" />
    <h3 style="width: 330px; text-align: center;">Your Loan Cart</h3>
    <table id="ecart">
        <tr>
            <th style="width: 30px; " >Code</th>
            <th style="width: 220px; ">Description</th>
            <th style="width: 80px; text-align: right;">Quantity</th>
        </tr>
        <c:forEach var="book" items="${sessionScope.cart.items}" >
            <tr>
                <td>${pageScope.book.code}</td>
                <td>${pageScope.book.description}</td>
                <td style="text-align: right;">${pageScope.book.quantity}</td>
                <c:set var="total" value="${pageScope.total + pageScope.book.quantity}" />
            </tr>
        </c:forEach>
        <tr>
            <td></td>
            <td style="text-align: right;"><br><br>Total: &nbsp;&nbsp;&nbsp;</td>
            <td style="text-align: right;"><br><br>${pageScope.total}</td>
        </tr>
    </table>
    <br><br>
    <a href="KKYCClearCart">Clear the cart</a><br><br>
    <a href="KKYCELoan.jsp">Return to eLoan</a>

</section>

<jsp:include page="/includes/KKYCFooter.jsp" />