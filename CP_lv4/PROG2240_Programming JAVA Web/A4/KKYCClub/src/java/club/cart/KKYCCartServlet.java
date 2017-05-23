/**
 * Document   : KKYCCartServlet
 * Created on : Mar 21, 2017, 9:06:36 AM
 * Author     : Kevin Kim, Yoonsuk Cho
 */
package club.cart;

import club.business.Book;
import club.business.ECart;
import club.business.ELoan;
import java.io.IOException;
import java.util.ArrayList;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class KKYCCartServlet extends HttpServlet {

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
        
        ServletContext sc = this.getServletContext();
        ArrayList<Book> loanitems = (ArrayList<Book>) sc.getAttribute("loanitems");
        HttpSession session = request.getSession();
        ECart cart = (ECart) session.getAttribute("cart");
        if (cart == null) cart = new ECart();
        
        String action = request.getParameter("action");

        if ("reserve".equals(action)) {
            String code = request.getParameter("code");
            Book book = ELoan.findItem(loanitems, code);
            if (book != null && book.getQuantity() > 0) {
                cart.addItem(book);
                ELoan.subtractFromQOH(loanitems, code, 1);
            }
        }

        session.setAttribute("cart", cart);

        // forward the response url
        sc.getRequestDispatcher("/KKYCECart.jsp").forward(request, response);
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
