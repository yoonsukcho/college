<%-- 
    Document   : KKYCRegister
    Created on : Jan 30, 2017, 1:29:25 PM

    Author     : Kevin Kim, Yoonsuk Cho
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<jsp:include page="/includes/KKYCBanner.jsp" />
<section>
<h1>New Member Registration Form</h1>

<form action="KKYCDisplayMember.jsp" method="post">
    <label>Full Names</label>
    <input type="text" name="fullName" id="fullName" 
           style="width: 200px;" required><br>
    <label>Email</label>
    <input type="email" name="email" id="email" 
           style="width: 300px;" required><br>
    <label>Phone</label>
    <input type="text" name="phone" id="phone" 
           style="width: 100px;" ><br>        
    <label>IT Program</label>
    <select name="program" id="program" >
        <option value="CAD" selected>CAD</option>
        <option value="CP">CP</option>
        <option value="CPA">CPA</option>
        <option value="ITID">ITID</option>
        <option value="ITSS">ITSS</option>
        <option value="MSD">MSD</option>
        <option value="Others">Others</option>
    </select><br>        
    <label>Year Level</label>
    <select name="level" id="level" >
        <option value="1" selected>1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="4">4</option>
    </select><br>        
    <label>&nbsp;</label>
    <input type="submit" value="Register Now!" id="submit">
    <input type="reset" value="Reset" id="reset">
</form>

</section>

<jsp:include page="/includes/KKYCFooter.jsp" />