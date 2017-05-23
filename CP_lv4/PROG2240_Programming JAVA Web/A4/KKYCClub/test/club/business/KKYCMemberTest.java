/**
 * Document   : KKYCMemberTest
 * Created on : Apr 1, 2017
 * Author     : Kevin Kim, Yoonsuk Cho
 */
package club.business;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

public class KKYCMemberTest {
   
    public KKYCMemberTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of getFullName method, of class Member.
     */
    @Test
    public void testGetFullName() {
        System.out.println("getFullName");
        Member instance = new Member();
        String expResult = "";
        String result = instance.getFullName();
        assertEquals(expResult, result);
    }

    /**
     * Test of getEmailAddress method, of class Member.
     */
    @Test
    public void testGetEmailAddress() {
        System.out.println("getEmailAddress");
        Member instance = new Member();
        String expResult = "";
        String result = instance.getEmailAddress();
        assertEquals(expResult, result);

    }

    /**
     * Test of getPhoneNumber method, of class Member.
     */
    @Test
    public void testGetPhoneNumber() {
        System.out.println("getPhoneNumber");
        Member instance = new Member();
        String expResult = "";
        String result = instance.getPhoneNumber();
        assertEquals(expResult, result);
    }

    /**
     * Test of getProgramName method, of class Member.
     */
    @Test
    public void testGetProgramName() {
        System.out.println("getProgramName");
        Member instance = new Member();
        String expResult = "";
        String result = instance.getProgramName();
        assertEquals(expResult, result);
    }

    /**
     * Test of getYearLevel method, of class Member.
     */
    @Test
    public void testGetYearLevel() {
        System.out.println("getYearLevel");
        Member instance = new Member();
        int expResult = 0;
        int result = instance.getYearLevel();
        assertEquals(expResult, result);
    }


    /**
     * Test of isValid method, of class Member.
     */
    @Test
    public void testValidPositive() {
        System.out.println("testValidPositive");
        boolean expResult = true;
        Member instance = new Member("Jason Bourne", "email@email.com");
        boolean result = instance.isValid();
        assertEquals(expResult, result);
    }
    
    /**
     * Test of isValid method, of class Member.
     */
    @Test
    public void testValidNegative() {
        System.out.println("testValidNegative");
        boolean expResult = false;
        Member instance = new Member();
        boolean result = instance.isValid();
        assertEquals(expResult, result);
    }

    
}
