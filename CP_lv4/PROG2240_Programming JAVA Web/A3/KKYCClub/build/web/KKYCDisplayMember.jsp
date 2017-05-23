<%-- 
    Document   : KKYCDisplayMember
    Created on : Jan 30, 2017, 2:02:57 PM
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<jsp:include page="/includes/KKYCBanner.jsp" />
<section>
    <h1>Thanks for joining our club!</h1>

    <p>Here is the information you entered:</p>

    <label>Full Names: </label> ${param.fullName} <br>
    <label>Email: </label> ${param.email} <br>
    <label>Phone: </label> ${param.phone} <br>
    <label>IT Program: </label> ${param.program} <br>
    <label>Year Level: </label> ${param.level} <br>
    <p>To register another member, 
        click on the Back button in your browser or</p>
    <p>the Return button shown below.</p>
    <form action="KKYCRegister.jsp" method="post">
        <input type="submit" value="Return" id="return" >
    </form>

</section>

<jsp:include page="/includes/KKYCFooter.jsp" />