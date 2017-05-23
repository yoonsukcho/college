<%-- 
    Document   : KKYCConfirmMemberDelete
    Created on : Jan 30, 2017, 2:02:57 PM
    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<jsp:include page="/includes/KKYCBanner.jsp" />
<section>
    <h2>Do you want to delete this member?</h2>

    <p>Here is the information you entered:</p>

    <label>Full Names: </label> ${member.fullName} <br>
    <label>Email: </label> ${member.emailAddress} <br>
    <label>Phone: </label> ${member.phoneNumber} <br>
    <label>IT Program: </label> ${member.programName} <br>
    <label>Year Level: </label> ${member.yearLevel} <br>

    <form action="KKYCMemberAdmin" method="get" style="float:left;">
        <input type="submit" value="Delete" id="delete" >
        <input type="hidden" name="action" value="deleteMember" >
        <input type="hidden" name="email" value="${member.emailAddress}" >
    </form>
    <form action="KKYCMemberAdmin" method="get" style="float:left;">
        <input type="hidden" name="action" value="displayMembers" >
        <input type="submit" value="Cancel" id="cancel" >
    </form>
</section>

<jsp:include page="/includes/KKYCFooter.jsp" />