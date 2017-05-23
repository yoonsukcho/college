<%-- 
    Document   : KKYCDisplayMembers
    Created on : Apr 13, 2017
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<jsp:include page="/includes/KKYCBanner.jsp" />
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<section>
    <h1>List of Members</h1>
    <table>
        <tr>
            <th>Email</th>
            <th>Program</th>
            <th>Year</th>
        </tr>
        <c:forEach var="member" items="${members}">
            <tr>
                <td>${member.emailAddress}</td>
                <td>${member.programName}</td>
                <td>${member.yearLevel}</td>
                <td><a href="KKYCMemberAdmin?action=displayMember&email=${member.emailAddress}">Update</a></td>
                <td><a href="KKYCMemberAdmin?action=confirmDeleteMember&email=${member.emailAddress}">Delete</a></td>
            </tr>
        </c:forEach>
    </table>    
    
    <form action="KKYCMemberAdmin">
        <input type="submit" value="Add Member" id="submit">
        <input type="hidden" name="action" value="addMember">
    </form>

</section>

<jsp:include page="/includes/KKYCFooter.jsp" />