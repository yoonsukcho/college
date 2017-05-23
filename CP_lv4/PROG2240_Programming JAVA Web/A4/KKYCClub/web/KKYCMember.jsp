<%-- 
    Document   : KKYCMember
    Created on : Apr 13, 2017

    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<jsp:include page="/includes/KKYCBanner.jsp" />
<section>
<h1>New Member Registration Form</h1>
<p style="color: red; font-style: italic;">${message}</p>
<form action="KKYCMemberAdmin" method="post">
    <label>Full Names</label>
    <input type="text" name="fullName" id="fullName" 
           style="width: 200px;" value="${member.fullName}" ><br>
    <label>Email</label>
    <input type="email" name="email" id="email" 
           style="width: 300px;" value="${member.emailAddress}" ><br>
    <label>Phone</label>
    <input type="text" name="phone" id="phone" 
           style="width: 100px;" value="${member.phoneNumber}" ><br>        
    <label>IT Program</label>
    <select name="program" id="program" >
        <option value="CAD" selected>CAD</option>
        <option value="CP" ${member.programName == "CP" ? "selected": ""} >CP</option>
        <option value="CPA" ${member.programName == "CPA" ? "selected": ""} >CPA</option>
        <option value="ITID" ${member.programName == "ITID" ? "selected": ""} >ITID</option>
        <option value="ITSS" ${member.programName == "ITSS" ? "selected": ""} >ITSS</option>
        <option value="MSD" ${member.programName == "MSD" ? "selected": ""} >MSD</option>
        <option value="Others" ${member.programName == "Others" ? "selected": ""} >Others</option>
    </select><br>        
    <label>Year Level</label>
    <select name="level" id="level" >
        <option value="1" selected>1</option>
        <option value="2" ${member.yearLevel == "2" ? "selected": ""} >2</option>
        <option value="3" ${member.yearLevel == "3" ? "selected": ""} >3</option>
        <option value="4" ${member.yearLevel == "4" ? "selected": ""} >4</option>
    </select><br>        
    <label>&nbsp;</label>
    <input type="submit" value="Save" id="submit">
    <input type="reset" value="Reset" id="reset">
</form>

</section>

<jsp:include page="/includes/KKYCFooter.jsp" />