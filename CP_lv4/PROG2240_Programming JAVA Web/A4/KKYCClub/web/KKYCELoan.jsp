<%-- 
    Document   : KKYCECart
    Created on : Mar 21, 2017, 12:50:44 PM
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<jsp:include page="/includes/KKYCBanner.jsp" />
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<section>
    <table>
        <tr>
            <th>Code</th>
            <th>Description</th>
            <th style="width: 60px; text-align: right;">QOH</th>
            <th>Action</th>
        </tr>
        <c:forEach var="book" items="${applicationScope.loanitems}">
            <tr>
                <td>${pageScope.book.code}</td>
                <td>${pageScope.book.description}</td>
                <td style="width: 60px; text-align: right;">${pageScope.book.quantity}</td>
                <td>
                    <c:if test="${pageScope.book.quantity > 0}">
                    <a href="KKYCCart?action=reserve&code=${pageScope.book.code}">Reserve</a>
                    </c:if>
                    <c:if test="${pageScope.book.quantity <= 0}">
                    N/A
                    </c:if>    
                </td>                
            </tr>
        </c:forEach>
    </table>

</section>

<jsp:include page="/includes/KKYCFooter.jsp" />