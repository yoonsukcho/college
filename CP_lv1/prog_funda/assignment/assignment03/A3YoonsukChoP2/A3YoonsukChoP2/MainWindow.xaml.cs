/*
 * Program name: A3YoonsukChoP2 - Calculator with operator button
 * 
 * Purpose: assignment 3-2
 *
 * Revision History:
 * created Sept 2015 by Yoonsuk Cho 
 * 
 * */

using System;
using System.Windows;
using System.Windows.Controls;

namespace A3YoonsukChoP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void checkInput(int oper)
        {
            string explMsg = "";
            decimal firstDec = 0m;
            decimal secondDec = 0m;

            try
            {
                explMsg = "The first input";
                firstDec = decimal.Parse(firstTxt.Text);
                explMsg = "The second input";
                secondDec = decimal.Parse(secondTxt.Text);
            }
            catch (ArgumentNullException ane)   //s is null.
            {
                explMsg = explMsg + " is null.";
                explTxt.Text = explMsg;
                return;
            }
            catch (FormatException fe)     //s is not in the correct format.
            {
                explMsg = explMsg + " is not in the correct format.";
                explTxt.Text = explMsg;
                return;
            }
            catch (OverflowException oe)    //s represents a number less than MinValue or greater than MaxValue.
            {
                explMsg = explMsg + " represents a number less than minumum value or greater than maximum value.";
                explTxt.Text = explMsg;
                return;
            }
            catch (Exception e)
            {
                explMsg = e.ToString();
                explTxt.Text = explMsg;
                return;
            }

            calcNumbers(firstDec, secondDec, oper);
        }

        private void calcNumbers(decimal firstDec, decimal secondDec, int oper)
        {

            string explMsg = "";
            try
            {
                switch (oper)
                { 
                    case 1:
                        rsltTxt.Text = (firstDec + secondDec).ToString();
                        break;
                    case 2:
                        rsltTxt.Text = (firstDec - secondDec).ToString();
                        break;
                    case 3:
                        rsltTxt.Text = (firstDec * secondDec).ToString();
                        break;
                    case 4:
                        rsltTxt.Text = (firstDec / secondDec).ToString();
                        break;
                    default:
                        break;
                }
                explMsg = "Solved!";

            }
            catch (DivideByZeroException dze)
            {
                explMsg = "Attempted to divide by zero.";
            }
            catch (Exception e)
            {
                explMsg = e.ToString();
            }
            finally
            {
                explTxt.Text = explMsg;
            }

        }

        private void plusBtn_Click(object sender, RoutedEventArgs e)
        {
            checkInput(1);
        }

        private void minusBtn_Click(object sender, RoutedEventArgs e)
        {
            checkInput(2);
        }

        private void multiBtn_Click(object sender, RoutedEventArgs e)
        {
            checkInput(3);
        }

        private void divideBtn_Click(object sender, RoutedEventArgs e)
        {
            checkInput(4);
        }

        private void firstTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            rsltTxt.Clear();
            explTxt.Clear();
        }

        private void secondTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            rsltTxt.Clear();
            explTxt.Clear();
        }

    }
}
