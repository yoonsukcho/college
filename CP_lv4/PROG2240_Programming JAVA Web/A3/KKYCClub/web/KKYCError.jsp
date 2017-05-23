<%-- 
    Document   : KKYCError
    Created on : Jan 30, 2017, 9:06:36 AM
    Changed    : Feb. 21, 2017
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.util.*" %> 

<!DOCTYPE html>
<jsp:include page="includes/KKYCBanner.jsp" />

<!-- start the middle column -->

<section>

    <h1>Java Error</h1>
    <p>Sorry, Java has thrown an exception.</p>
    <p>To continue, click the Back button.</p>

    <h2>Details</h2>
    <p>Type: ${pageContext.exception["class"]}</p>
    <p>Message: ${pageContext.exception.message}</p>

</section>

<!-- end the middle column -->

<jsp:include page="includes/KKYCFooter.jsp" />