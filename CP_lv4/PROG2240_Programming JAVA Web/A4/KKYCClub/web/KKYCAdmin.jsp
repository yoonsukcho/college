<%-- 
    Document   : KKYCAdmin
    Created on : Jan 30, 2017, 9:06:36 AM
    Changed    : Feb. 21, 2017
    Changed    : Apr. 13, 2017
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.util.*" %> 
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<!DOCTYPE html>
<jsp:include page="includes/KKYCBanner.jsp" />

<c:url var="url" value="KKYCMemberAdmin?action=displayMembers"/>
<!-- start the middle column -->

<section>
    <h2>Admin : Data Maintenance</h2><br>

    <a href="KKYCDisplayBooks">Maintain Books</a><br>
    <a href="${url}">Display Members</a>

</section>

<!-- end the middle column -->

<jsp:include page="includes/KKYCFooter.jsp" />