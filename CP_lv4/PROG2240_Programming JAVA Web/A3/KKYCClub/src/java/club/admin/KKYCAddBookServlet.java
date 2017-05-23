/**
 * Document   : KKYCAddBookServlet
 * Created on : Feb 24, 2017, 12:50:44 PM
 * author     : Kevin Kim, Yoonsuk Cho
 */
package club.admin;

import club.business.Book;
import club.data.BookIO;
import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;


public class KKYCAddBookServlet extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, 
                                  HttpServletResponse response)
            throws ServletException, IOException {

        String url = "/KKYCAddBook.jsp";
        
        // get parameters from the request 
        String code = request.getParameter("code");
        String description = request.getParameter("description");
        String quantity = request.getParameter("quantity");
        
        // validate the parameters
        String message = "";
        
        if (code == null || code.isEmpty()) {
            message += "Book code is required.<br>";
        }
        
        if (description == null || description.length() < 2) {
            message += "Description must have at least 2 characters.<br>";
        }
        
        if (quantity == null || quantity.isEmpty() || 
            Integer.parseInt(quantity) <= 0) {
            message += "Quantity must be a positive number.<br>";
        }

        // store data in Book object 
        Book book;
        
        // when all input data are valid
        if (message.isEmpty()) {
            url = "/KKYCDisplayBooks";
            book = new Book(code, description, Integer.parseInt(quantity));
            BookIO.insert(book, 
                          getServletContext().getRealPath("/WEB-INF/books.txt"));
        } else {
        // when any of input data is invalid
            book = new Book(code, description, 0);
            request.setAttribute("message", message); 
        }
        
        request.setAttribute("book", book);
        request.setAttribute("quantity", quantity);
        
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
