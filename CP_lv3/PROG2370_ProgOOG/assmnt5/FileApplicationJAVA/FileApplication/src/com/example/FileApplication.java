/*
 * To change this license header, choose License Headers in Project 
Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.example;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextArea;

/**
 *
 * @author sabbir
 */
public class FileApplication extends JFrame{

    private JButton btnSave;
    private JButton btnLoad;
    private JTextArea txtDisplay;
    public FileApplication()
    {
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);
        JPanel topPanel = new JPanel();
        btnSave = new JButton("Save");
        btnLoad = new JButton("Load");
        topPanel.setLayout(new FlowLayout(FlowLayout.CENTER));
        topPanel.add(btnSave);
        topPanel.add(btnLoad);
        this.add(topPanel, BorderLayout.NORTH);
        
        txtDisplay = new JTextArea(20, 20);
        this.add(txtDisplay, BorderLayout.CENTER);
        
        ButtonHandler buttonHandler = new ButtonHandler();
        btnSave.addActionListener(buttonHandler);
        btnLoad.addActionListener(buttonHandler);
        
        this.pack();
        this.setVisible(true);
        
    }
    
    
    
    private void doSave() throws Exception
    {
        JFileChooser dlg = new JFileChooser();
        int r = dlg.showSaveDialog(this);
        if (r == JFileChooser.APPROVE_OPTION) {
            
            FileWriter writer = new FileWriter(dlg.getSelectedFile());
            writer.write(txtDisplay.getText());
            writer.close();
            JOptionPane.showMessageDialog(this, "File saved");
            
        }
    }
    
    private void doLoad() throws Exception
    {
        JFileChooser dlg = new JFileChooser();
        int r = dlg.showOpenDialog(this);
        if (r == JFileChooser.APPROVE_OPTION) {
            FileReader fReader = new FileReader(dlg.getSelectedFile());
            BufferedReader bReader = new BufferedReader(fReader);
            String line = null;
            while((line=bReader.readLine()) != null)
            {
                txtDisplay.append(line + "\n");
            }
            bReader.close();
            fReader.close();
            
        }
    }
    
    private class ButtonHandler implements ActionListener
    {
        @Override
        public void actionPerformed(ActionEvent e) {
            JButton src = (JButton)e.getSource();
            if (src == btnSave) {
                //JOptionPane.showMessageDialog(null, "Save");
                try {
                    doSave();
                } catch (Exception exception) {
                    JOptionPane.showMessageDialog(null, "Error in file save");
                }
            }
            else if (src == btnLoad) {
                try {
                    //JOptionPane.showMessageDialog(null, "Load");
                    doLoad();
                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(null, "Error in file load");
                }
            }
        }
        
    }
    
    
    
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        FileApplication fa = new FileApplication();
    }
    
}
