/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ychoassignment5;

import java.awt.*;
import java.util.HashMap;
import javax.swing.*;
import javax.swing.border.*;

/**
 * @author Yoonsuk Cho
 * PROG2370 Assignment 5
 * Dec 2016
 *
 * This program is the main program of
 * the Maze Designer.
 * 
 */
public class YChoAssignment5 extends JFrame {
    
    // current selected button color
    static int CURRENT_COLOR = 0;
    // color key(int) and color value (Color) 
    static HashMap<Integer, Color> COLOR_MAP = new HashMap<>();
    
    private JPanel paneNorth, paneWest, paneCenter;
    
    private JButton btnGen, btnSave, btnLoad, 
                    btnEmpty, btnRed, btnBlue, btnGreen, 
                    btnYellow, btnPink, btnCyan, 
                    btnMagenta, btnWhite, btnWall;
    
    private JTextField txtRow, txtCol;
    
    private JLabel lblRows;
    
    public YChoAssignment5() 
    {
        this.setLayout(new BorderLayout());
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        // initialize hashMap data
        COLOR_MAP.put(0, Color.lightGray);
        COLOR_MAP.put(1, Color.red);
        COLOR_MAP.put(2, Color.blue);
        COLOR_MAP.put(3, Color.green);
        COLOR_MAP.put(4, Color.yellow);
        COLOR_MAP.put(5, Color.pink);
        COLOR_MAP.put(6, Color.cyan);
        COLOR_MAP.put(7, Color.magenta);
        COLOR_MAP.put(8, Color.white);
        COLOR_MAP.put(9, Color.black);
        
        initComponent();
    }
    
/**
 * initialize all component using this program
 * 
 * @param       none
 * @return      void
 */
    private void initComponent()
    {
        // all components using in the upper panel create        
        btnGen = new JButton("Generate");
        btnSave = new JButton("Save");
        btnLoad = new JButton("Load");
        txtRow = new JTextField("5");
        txtRow.setName("txtRow");
        txtCol = new JTextField("5");
        txtCol.setName("txtCol");
        txtRow.setColumns(5);
        txtCol.setColumns(5);
        lblRows = new JLabel("Rows: ");

        // create the upper panel, add its components 
        paneNorth = new JPanel(new FlowLayout(FlowLayout.LEADING));
        paneNorth.setName("paneNorth");
        paneNorth.setBorder(BorderFactory.createEtchedBorder(EtchedBorder.RAISED));
        paneNorth.add(lblRows);
        paneNorth.add(txtRow);
        paneNorth.add(txtCol);
        paneNorth.add(btnGen);
        paneNorth.add(btnSave);
        paneNorth.add(btnLoad);
        
        // all components using in the left panel create     
        btnEmpty = new JButton("Empty Slot");
        btnRed = new JButton("Red Box");
        btnBlue = new JButton("Blue Box");
        btnGreen = new JButton("Green Box");
        btnYellow = new JButton("Yellow Box");
        btnPink = new JButton("Pink Door");
        btnCyan = new JButton("Cyan Door");
        btnMagenta = new JButton("Magenta Door");
        btnWhite = new JButton("White Door");
        btnWall = new JButton("Wall");
        
        // create the left panel, add its components 
        paneWest = new JPanel(new GridLayout(10, 1));
        paneWest.setName("paneWest");
        paneWest.setBorder(BorderFactory.createEtchedBorder(EtchedBorder.RAISED));
        paneWest.add(btnEmpty);
        paneWest.add(btnRed);
        paneWest.add(btnBlue);
        paneWest.add(btnGreen);
        paneWest.add(btnYellow);
        paneWest.add(btnPink);
        paneWest.add(btnCyan);
        paneWest.add(btnMagenta);
        paneWest.add(btnWhite);
        paneWest.add(btnWall);
        
        // create the center panel
        paneCenter = new JPanel();
        paneCenter.setName("paneCenter");
        
        // this handler includes all components' functions
        ButtonHandler bh = new ButtonHandler();

        // add button handler to all buttons in the upper panel
        Component[] components = paneNorth.getComponents();
        for (Component component : components) 
        {
            if (component instanceof JButton) 
            {
                ((JButton)component).addMouseListener(bh);
            }
        }

        // add button handler to all buttons in the left panel
        components = paneWest.getComponents();
        for (Component component : components) 
        {
            if (component instanceof JButton) 
            {
                ((JButton)component).addMouseListener(bh);
            }
        }
        
        // add all panels in the main frame and show it
        this.add(paneNorth, BorderLayout.NORTH);
        this.add(paneCenter, BorderLayout.CENTER);
        this.add(paneWest, BorderLayout.WEST);
        this.setPreferredSize(new Dimension(600, 400));
        this.pack();
        this.setVisible(true);

    }
    
    
    /**
     * main method to start this program
     * 
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here

        YChoAssignment5 ya = new YChoAssignment5();
        
    }
    
    
}
