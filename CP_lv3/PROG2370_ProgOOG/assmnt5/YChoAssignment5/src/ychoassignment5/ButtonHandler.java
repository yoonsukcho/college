/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ychoassignment5;

import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.util.HashMap;
import javax.swing.*;
import javax.swing.border.*;

/**
 * @author Yoonsuk Cho
 * PROG2370 Assignment 5
 * Dec 2016
 *
 * This program is the button handler program of
 * the Maze Designer.
 * All event handler is implemented in this program.
 * 
 */
public class ButtonHandler implements MouseListener {

/**
 * this would be executed whenever mouse left button is clicked 
 * on all buttons and the panels on the centre panel
 * @param       MouseEvent me
 * @return      void
 */
    @Override
    public void mouseClicked(MouseEvent me) {
        
        // this is for he panels on the centre panel
        if ((me.getSource()instanceof JPanel)) 
        {
            Color currentColor = YChoAssignment5.COLOR_MAP.get(YChoAssignment5.CURRENT_COLOR);
            ((JPanel)me.getSource()).setBackground(currentColor);
            return;
        }
        
        if (!(me.getSource()instanceof JButton)) return;

        JButton thisButton = (JButton)me.getSource();
        // get main frame
        Container container = thisButton.getParent().getParent();
        
        // this is for the function of generate button
        if ("Generate".equals(thisButton.getText()))
        {
            try 
            {
                JPanel panelNorth = (JPanel)thisButton.getParent();
                generateCentrePanel(container, panelNorth);
            }
            catch (Exception e)
            {
                e.printStackTrace();
            }
        }

        // this is for the function of save button
        if ("Save".equals(thisButton.getText()))
        {
            int allCnt = 1;
            JFileChooser dlg = new JFileChooser();
            int r = dlg.showSaveDialog(container);
            if (r == JFileChooser.APPROVE_OPTION) {
                try 
                {
                    FileWriter writer = new FileWriter(dlg.getSelectedFile());
                    Component[] components = container.getComponents();
                    String row_col = "";
                    for (Component comp : components)
                    {
                        if (comp instanceof JPanel && "paneNorth".equals(comp.getName()))
                        {
                            Component[] comps = ((JPanel)comp).getComponents();
                            for (Component com : comps)
                            {
                                if (com instanceof JTextField) 
                                {
                                    if("txtRow".equals(com.getName()) || "txtCol".equals(com.getName())) 
                                    {
                                        int value = Integer.parseInt(((JTextField)com).getText());
                                        allCnt *= value;
                                        row_col += value+"\n";
                                    }
                                }                        
                            }
                        }
                        if (comp instanceof JPanel && "paneCenter".equals(comp.getName()))
                        {
                            Component[] colorPanels = ((JPanel)comp).getComponents();
                            // if rows * cols is different with count of grids in center panel,
                            // it occurs error.
                            if (colorPanels.length != allCnt)
                                throw new Exception();
                            writer.write(row_col);
                            for (Component colorPanel : colorPanels)
                            {
                                writer.write(String.valueOf(getColorInt(colorPanel.getBackground()))+"\n");
                            }
                        }
                    }
                    writer.close();
                    JOptionPane.showMessageDialog(container, "File saved");
                }
                catch (Exception e)
                {
                    //e.printStackTrace();
                    JOptionPane.showMessageDialog(container, "Error in file save");
                }
            
            }
        }

        // this is for the function of load button
        if ("Load".equals(thisButton.getText()))
        {
            JFileChooser dlg = new JFileChooser();
            int r = dlg.showOpenDialog(container);
            if (r == JFileChooser.APPROVE_OPTION) {
                try 
                {
                    FileReader fReader = new FileReader(dlg.getSelectedFile());
                    BufferedReader bReader = new BufferedReader(fReader);
                    JPanel panelNorth = (JPanel)thisButton.getParent();
                    Component[] components = panelNorth.getComponents();
                    int txtRow = Integer.parseInt(bReader.readLine());
                    int txtCol = Integer.parseInt(bReader.readLine());
                    for (Component comp : components) 
                    {
                        if (comp instanceof JTextField) 
                        {
                            if("txtRow".equals(comp.getName())) 
                                ((JTextField) comp).setText(String.valueOf(txtRow));
                            if("txtCol".equals(comp.getName())) 
                                ((JTextField) comp).setText(String.valueOf(txtCol));
                        }
                    }

                    JPanel panelCenter = generateCentrePanel(container, panelNorth);
                    Component[] comps = panelCenter.getComponents();
                    String line = null;
                    int i = 0;
                    while((line=bReader.readLine()) != null)
                    {
                        ((JPanel)comps[i++]).setBackground(YChoAssignment5.COLOR_MAP.get(Integer.parseInt(line)));
                        //System.out.println(line);
                    }
                    bReader.close();
                    fReader.close();
                }
                catch (Exception e)
                {
                    //e.printStackTrace();
                    JOptionPane.showMessageDialog(container, "Error in file load");

                }

            }
        }

        // from this line, the function of buttons in the left panel
        // specify the current color
        if ("Empty Slot".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 0;
        }
        if ("Red Box".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 1;
        }
        if ("Blue Box".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 2;
        }
        if ("Green Box".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 3;
        }
        if ("Yellow Box".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 4;
        }
        if ("Pink Door".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 5;
        }
        if ("Cyan Door".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 6;
        }
        if ("Magenta Door".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 7;
        }
        if ("White Door".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 8;
        }
        if ("Wall".equals(thisButton.getText()))
        {
            YChoAssignment5.CURRENT_COLOR = 9;
        }
//        System.out.println(thisButton.getText());  
    }

    @Override
    public void mousePressed(MouseEvent me) {
        // do nothing
        return;
    }

    @Override
    public void mouseReleased(MouseEvent me) {
        // do nothing
        return;
    }

    @Override
    public void mouseEntered(MouseEvent me) {
        // do nothing
        return;
    }

    @Override
    public void mouseExited(MouseEvent me) {
        // do nothing
        return;
    }
    
/**
 * get the key from HashMap with value
 * 
 * @param  Color    color
 * @return int      key of color
 */    
    private int getColorInt(Color color)
    {
        int returnValue = 0;
        for (HashMap.Entry<Integer, Color> e : YChoAssignment5.COLOR_MAP.entrySet())
        {
            if (color.equals(e.getValue())) return e.getKey();
        }
        return returnValue;
    }

/**
 * generate centre panel's components with row and column text fields' values
 * 
 * @param       Container main frame
 * @param       JPanel    the upper panel
 * @return      JPanel    the centre panel is completed to make its components
 */    
    private JPanel generateCentrePanel(Container frame, JPanel northPanel)
    {
        int rows = 0;
        int cols = 0;
        JPanel panelCenter = null;
        YChoAssignment5.CURRENT_COLOR = 0;

        // get rows and columns value from text fields
        Component[] components = northPanel.getComponents();
        for (Component comp : components) 
        {
            if (comp instanceof JTextField) 
            {
                if("txtRow".equals(comp.getName())) 
                    rows = Integer.parseInt(((JTextField)comp).getText());
                if("txtCol".equals(comp.getName())) 
                    cols = Integer.parseInt(((JTextField)comp).getText());
            }
        }
        
        // make all components of centre panel
        components = frame.getComponents();
        for (Component comp : components) 
        {
            if (comp instanceof JPanel && "paneCenter".equals(comp.getName())) 
            {
                panelCenter = (JPanel)comp;
                // make it clear
                panelCenter.removeAll();
                panelCenter.updateUI();
                // define its layout
                panelCenter.setLayout(new GridLayout(rows, cols));
                // create and add panels which is composited the maze
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        JPanel jp = new JPanel();
                        jp.setBorder(BorderFactory.createLineBorder(Color.black, 1));
                        jp.setBackground(YChoAssignment5.COLOR_MAP.get(YChoAssignment5.CURRENT_COLOR));
                        jp.addMouseListener(this);
                        panelCenter.add(jp);
                    }
                }
            }
        }
        frame.validate();
        return panelCenter;
    }

}
