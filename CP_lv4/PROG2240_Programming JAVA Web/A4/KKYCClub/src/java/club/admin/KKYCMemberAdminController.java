/**
 * Document   : KKYCMemberAdminController
 * Created on : Apr 1, 2017
 * Author     : Kevin Kim, Yoonsuk Cho
 */
package club.admin;

import club.business.Member;
import club.data.MemberDB;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class KKYCMemberAdminController extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        
        String url = "/KKYCDisplayMembers.jsp";
        String message = "";
        HttpSession session = request.getSession();
        
        String action  = request.getParameter("action");
        if ("displayMembers".equals(action)) {
            ArrayList<Member> members = MemberDB.selectMembers();
            session.setAttribute("members", members);
        } else if ("addMember".equals(action)) {
            session.invalidate();
            url = "/KKYCMember.jsp";
        } else if ("displayMember".equals(action)) {
            String email = (request.getParameter("email")==null)?
                    "":request.getParameter("email");
            Member member = MemberDB.selectMember(email);
            session.setAttribute("member", member);
            url = "/KKYCMember.jsp";
        } else if ("confirmDeleteMember".equals(action)) {
            String email = (request.getParameter("email")==null)?
                    "":request.getParameter("email");
            Member member = MemberDB.selectMember(email);
            session.setAttribute("member", member);
            url = "/KKYCConfirmMemberDelete.jsp";
        } else if ("deleteMember".equals(action)) {
            String email = (request.getParameter("email")==null)?
                    "":request.getParameter("email");
            Member member = MemberDB.selectMember(email);
            MemberDB.delete(member);
            url = "/KKYCMemberAdmin?action=displayMembers";
        } else {
            String fullName = (request.getParameter("fullName")==null)?
                "":request.getParameter("fullName");
            String email = (request.getParameter("email")==null)?
                    "":request.getParameter("email");
            String phoneNumber = (request.getParameter("phone")==null)?
                "":request.getParameter("phone");
            String programName = (request.getParameter("program")==null)?
                "":request.getParameter("program");
            String yearLevelStr = (request.getParameter("level")==null)?
                "":request.getParameter("level");
            int yearLevel = Integer.parseInt(yearLevelStr);

            Member member = MemberDB.selectMember(email);
            if (member == null) member = new Member();

            member.setFullName(fullName);
            member.setEmailAddress(email);
            member.setPhoneNumber(phoneNumber);
            member.setProgramName(programName);
            member.setYearLevel(yearLevel);

            if (member.isValid()) {
                if (MemberDB.emailExists(email)) {
                    MemberDB.update(member);
                } else {
                    MemberDB.insert(member);
                }
                url = "/KKYCMemberAdmin?action=displayMembers";
            } else {
                message = "Member information is not valid." + 
                        " You must enter a valid name and email.";
                url = "/KKYCMember.jsp";
                session.setAttribute("member", member);
            }
        }
        session.setAttribute("message", message);
        
        // forward the response url
        getServletContext().getRequestDispatcher(url).forward(request, response);
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

// </editor-fold>

}
