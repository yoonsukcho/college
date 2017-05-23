/*
 * Program name: A2YoonsukChoP1 - Tuition Computation App
 * 
 * Purpose: assignment 2-1
 *
 * Revision History:
 * created Sept 2015 by Yoonsuk Cho 
 * 
 * */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A2YoonsukChoP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initCompValue();
        }


        private void initCompValue()
        {
            monthCombo.Items.Add("January");
            monthCombo.Items.Add("February");
            monthCombo.Items.Add("March");
            monthCombo.Items.Add("April");
            monthCombo.Items.Add("May");
            monthCombo.Items.Add("June");
            monthCombo.Items.Add("July");
            monthCombo.Items.Add("August");
            monthCombo.Items.Add("September");
            monthCombo.Items.Add("October");
            monthCombo.Items.Add("November");
            monthCombo.Items.Add("December");
            monthCombo.SelectedIndex = 0;
        }

        private void calcBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkValue())
            {
                double sumStep1 = sumStep1Amt();      // STEP 1: nationality + age
                double sumStep2 = sumStep2Amt();      // STEP 2: semester 
                totalAmtTxt.Text = (sumStep1 + sumStep2).ToString("C");
            }
        }

        private void clearTotalAmt()
        {
            totalAmtTxt.Text = "0.0";
        }

        private bool checkValue()
        {
            int age = 0;
            bool retValue = true;
            if ("".Equals(ageTxt.Text))
            {
                MessageBox.Show("Please, input age.");
                retValue = false;
            }
            else if (!canParse(ageTxt.Text, out age))
            {
                MessageBox.Show("Please, input age with integer value.");
                retValue = false;
            }
            return retValue;
        }

        private bool canParse(string str, out int num)
        {
            bool success = true;
            num = 0;
            try
            {
                num = int.Parse(str);
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }

        private double sumStep1Amt()
        {
            double natAmt = 0.0d;
            double ageAmt = 0.0d;

            if (caRadio.IsChecked == true)   // nationality == Canadian
            {
                natAmt = 0.0d;
            }
            else   // nationality == international
            {
                natAmt = 100.0d;
            }

            int age = int.Parse(ageTxt.Text);

            if (age <= 18)
            {
                ageAmt = 300.0d;
            }
            else if (age >= 19 && age <= 49)
            {
                ageAmt = 500.0d;
            }
            else   // age > 50
            {
                ageAmt = 400.0d;
            }

            return (ageAmt + natAmt) * 1.13;

        }

        private double sumStep2Amt()
        {
            double monthAmt = 0.0d;

            string monthVal = monthCombo.Text;
            switch (monthVal)
            {
                case "January":
                case "February":
                case "March":
                case "April":
                    monthAmt = 220.0d;           // winter month
                    break;
                case "May":
                case "June":
                case "July":
                case "August":
                    monthAmt = 150.0d;           // summer month
                    break;
                case "September":
                case "October":
                case "November":
                case "December":
                    monthAmt = 250.0d;           // fall month
                    break;
                default:
                    monthAmt = 0.0d;
                    MessageBox.Show("Please, select the month registered.");
                    return 0.0d;
            }
            return monthAmt * 1.13;
        }

        private void caRadio_Checked(object sender, RoutedEventArgs e)
        {
            clearTotalAmt();
        }

        private void ageTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearTotalAmt();
        }

        private void monthCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clearTotalAmt();
        }


    }
}
