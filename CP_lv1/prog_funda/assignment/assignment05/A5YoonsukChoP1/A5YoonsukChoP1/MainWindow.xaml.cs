/*
 * Program name: A5YoonsukChoP1 - Seat reservation application
 * 
 * Purpose: assignment 5-1
 *
 * Revision History:
 * created Sept 2015 by Yoonsuk Cho 
 * 
 * */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace A5YoonsukChoP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // ticket selling repository variables
        Dictionary<string, string> seatSold = new Dictionary<string, string>();

        // seat names: if you want more seat, add UI and append here
        string[] seatNameArr = new string[] { "1A", "2A", "3A", "4A",
                                              "1B", "2B", "3B", "4B", 
                                              "1C", "2C", "3C", "4C",
                                              "1D", "2D", "3D", "4D" };

        // transaction kinds: 1= add, 2= remove
        int exeType = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitComponent();
        }

        private void InitComponent()
        {
            seatCombo.Items.Add("-select-");

            foreach (string seatName in seatNameArr)
            {
                seatSold.Add(seatName, "");
                Button tempBtn = (Button)this.FindName("_" + seatName + "Btn");
                tempBtn.Background = Brushes.LightGray;
                tempBtn.Click += seatBtn_Click;
                tempBtn.IsEnabled = false;
                tempBtn.SetValue(ToolTipService.ShowOnDisabledProperty, true); 
            }
            givenTxt.LostFocus += txt_LostFocus;
            surTxt.LostFocus += txt_LostFocus;

            // TEST CODE START!!
            //seatSold["1A"] = "AAA^AA";
            //seatSold["2A"] = "AAA^AA";
            //seatSold["3A"] = "AAA^AA";
            //seatSold["4A"] = "AAA^AA";
            //seatSold["1B"] = "BBB^BB";
            //seatSold["2B"] = "BBB^BB";
            //seatSold["3B"] = "AAA^AA";
            //seatSold["4B"] = "BBB^BB";
            //seatSold["1C"] = "AAA^AA";
            //seatSold["2C"] = "AAA^AA";
            //seatSold["3C"] = "AAA^AA";
            //seatSold["4C"] = "AAA^AA";
            //seatSold["1D"] = "BBB^BB";
            //seatSold["2D"] = "BBB^BB";
            //seatSold["3D"] = "BBB^BB";
            // TEST CODE END!!

            initStatus();
        }

        private void initStatus()
        {
            givenTxt.Text = "";
            surTxt.Text = "";

            addBtn.IsEnabled = true;
            removeBtn.IsEnabled = true;
            findBtn.IsEnabled = false;
            givenTxt.IsEnabled = false;
            surTxt.IsEnabled = false;
            seatCombo.IsEnabled = false;
            exeBtn.IsEnabled = false;
            cancelBtn.IsEnabled = false;
            selHidTxt.Text = "";
            seatCombo.SelectedIndex = 0;

            if (checkSeat() == seatNameArr.Length)
            {
                MessageBox.Show("No seat is available more!");
                addBtn.IsEnabled = false;
            }
            foreach (string seatName in seatNameArr)
            {
                Button tempBtn = (Button)this.FindName("_" + seatName + "Btn"); 
                tempBtn.IsEnabled = false;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            addStatus();
            checkSeat();
            exeType = 1;
        }

        private void addStatus()
        {
            addBtn.IsEnabled = false;
            removeBtn.IsEnabled = false;
            findBtn.IsEnabled = false;
            givenTxt.IsEnabled = true;
            surTxt.IsEnabled = true;
            seatCombo.IsEnabled = false;
            exeBtn.IsEnabled = true;
            cancelBtn.IsEnabled = true;
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            removeStatus();
            exeType = 2;
            seatCombo.Items.Clear();
            seatCombo.Items.Add("-select-");
            foreach (string key in seatSold.Keys)
            {
                if (seatSold[key] != "")
                {
                    seatCombo.Items.Add(key);
                }
            }
            seatCombo.SelectedIndex = 0;
        }

        private void removeStatus()
        {
            if (checkSeat() == 0)
            {
                MessageBox.Show("There is no seat to remove!");
                initStatus();
                return;
            } 
            addBtn.IsEnabled = false;
            removeBtn.IsEnabled = false;
            findBtn.IsEnabled = true;
            givenTxt.IsEnabled = true;
            surTxt.IsEnabled = true;
            seatCombo.IsEnabled = true;
            exeBtn.IsEnabled = false;
            cancelBtn.IsEnabled = true;
            foreach (string seatName in seatNameArr)
            {
                Button tempBtn = (Button)this.FindName("_" + seatName + "Btn");
                tempBtn.IsEnabled = false;
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            initStatus();
        }

        private int checkSeat()
        {
            // add check
            int findCount = 0;
            foreach (string key in seatSold.Keys)
            {
                Button tempBtn = (Button)this.FindName("_" + key + "Btn");
                if (seatSold[key] != "")
                {
                    tempBtn.Content = "Oc";
                    tempBtn.IsEnabled = false;
                    findCount++;
                    tempBtn.ToolTip = seatSold[key].Split('^')[0] + " " + seatSold[key].Split('^')[1];
                }
                else
                {
                    tempBtn.Content = "Va";
                    tempBtn.IsEnabled = true;
                    tempBtn.ToolTip = null;
                }

                if (tempBtn.Background == Brushes.Ivory)
                {
                    tempBtn.Background = Brushes.LightGray;
                }
            }

            return findCount;
        }

        private int checkSeat(int searchType, string findKey)
        {
            Button tempBtn = null;
            int findCount = 0;
            // remove check
            //   search by name: 1
            //   search by seat no: 2
            if (searchType == 1)
            {
                foreach (string key in seatSold.Keys)
                {
                    tempBtn = (Button)this.FindName("_" + key + "Btn");
                    if (seatSold[key] != "")
                    {
                        tempBtn.Content = "Oc";
                        if (seatSold[key].Equals(findKey, StringComparison.CurrentCultureIgnoreCase))
                        {
                            tempBtn.IsEnabled = true;
                            findCount++;
                        }
                        else
                        {
                            tempBtn.IsEnabled = false;
                        }
                    }
                    else
                    {
                        tempBtn.IsEnabled = false;
                        tempBtn.Content = "Va";
                    }
                    if (tempBtn != null && tempBtn.Background == Brushes.Ivory)
                    {
                        tempBtn.Background = Brushes.LightGray;
                    }
                }
                if (findCount == 0)
                {
                    MessageBox.Show("There is no reservation with name '" +
                                    findKey.Split('^')[0] + " " + findKey.Split('^')[1] + "'");
                    givenTxt.Text = "";
                    surTxt.Text = "";
                    return findCount;
                }
            }
            else
            {
                tempBtn = (Button)this.FindName("_" + findKey + "Btn");
                if (tempBtn != null)
                {
                    tempBtn.IsEnabled = true;
                    if (tempBtn.Background == Brushes.Ivory)
                    {
                        tempBtn.Background = Brushes.LightGray;
                    }
                    findCount++;
                }
            }
            return findCount;
        }

        private void findBtn_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccess = true;

            string nameTxt = givenTxt.Text + "^" + surTxt.Text;

            if (seatCombo.SelectedIndex == 0 && (nameTxt == "^"))
            {
                MessageBox.Show("Please input full name or seat number!");
                return;
            }

            if (seatCombo.SelectedIndex != 0 && (nameTxt != "^"))
            {
                MessageBox.Show("Please input just one between full name or seat number!");
                return;
            }

            if (seatCombo.SelectedIndex == 0)
            {
                if (!IsValidName()) return;
                isSuccess = (checkSeat(1, nameTxt) > 0);
            }
            else
            {
                string selectedText = seatCombo.SelectedItem.ToString();
                foreach (string seatName in seatNameArr)
                {
                    Button tempBtn = (Button)this.FindName("_" + seatName + "Btn");
                    tempBtn.IsEnabled = false;
                }
                isSuccess = (checkSeat(2, selectedText) > 0);
                if (isSuccess)
                {
                    selHidTxt.Text = selectedText;
                    Button tempBtn = (Button)(this.FindName("_" + selectedText + "Btn"));
                    tempBtn.Content = "Se";
                    tempBtn.Background = Brushes.Ivory;
                }
            }
            if (isSuccess)
            {
                givenTxt.IsEnabled = false;
                surTxt.IsEnabled = false;
                seatCombo.IsEnabled = false;
                exeBtn.IsEnabled = true;
                cancelBtn.IsEnabled = true;
            }
        }

        private void exeBtn_Click(object sender, RoutedEventArgs e)
        {
            // exeType
            // Add : 1
            // Remove : 2
            selHidTxt.Text = selHidTxt.Text.Trim();
            if (exeType == 1)
            {
                if (!IsValidName()) return;
                string[] selSeats = selHidTxt.Text.Trim().Split();
                if (selSeats[0] == "")
                {
                    MessageBox.Show("Please, select a seat.");
                    return;
                }

                MessageBoxResult mesRslt = MessageBox.Show("Confirm add!!\n" + "Name: " +
                                                            givenTxt.Text + " " + surTxt.Text +
                                                             "\nSeat No.: " + selHidTxt.Text,
                                                             "Confirm", MessageBoxButton.YesNo);
                if (mesRslt == MessageBoxResult.Yes)
                {
                    foreach(string sleSeat in selSeats)
                    {
                        seatSold[sleSeat] = givenTxt.Text + "^" + surTxt.Text;
                    }
                    MessageBox.Show("Add is completed successfully!");
                }
                else
                {
                    MessageBox.Show("Add is cancelled!");
                }
            }
            else if (exeType == 2)
            {
                string[] selSeats = selHidTxt.Text.Trim().Split();
                if (selSeats[0] == "")
                {
                    MessageBox.Show("Please, select a seat.");
                    return;
                }

                string givenNm = seatSold[selSeats[0]].Split('^')[0];
                string surNm = seatSold[selSeats[0]].Split('^')[1];
                MessageBoxResult mesRslt = MessageBox.Show("Confirm remove!!\n" + "Name: " +
                                                            givenNm + " " + surNm +
                                                             "\nSeat No.: " + selHidTxt.Text,
                                                             "Confirm", MessageBoxButton.YesNo);
                if (mesRslt == MessageBoxResult.Yes)
                {
                    foreach (string sleSeat in selSeats)
                    {
                        seatSold[sleSeat] = "";
                    }
                    MessageBox.Show("Remove is completed successfully!");
                }
                else
                {
                    MessageBox.Show("Remove is cancelled!");
                }
                checkSeat();
            }
            else
            {
                MessageBox.Show("Cannot reach here!!");
            }

            exeType = 0;   // init value
            initStatus();
        }

        private void seatBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clickBtn = (Button)sender;
            string btnName = clickBtn.Name;
            // exeType
            // Add : 1
            // Remove : 2
            if (exeType == 1)
            {
                if (clickBtn.Content.ToString() == "Se")
                {
                    clickBtn.Background = Brushes.LightGray;
                    clickBtn.Content = "Va";
                    selHidTxt.Text = selHidTxt.Text.Replace(btnName.Substring(1, 2), "");
                    selHidTxt.Text = selHidTxt.Text.Replace("  ", " ");
                }
                else
                {
                    clickBtn.Background = Brushes.Ivory;
                    clickBtn.Content = "Se";
                    selHidTxt.Text += " " + btnName.Substring(1, 2);
                }
            }
            else
            {
                if (clickBtn.Content.ToString() == "Se")
                {
                    clickBtn.Background = Brushes.LightGray;
                    clickBtn.Content = "Oc";
                    selHidTxt.Text = selHidTxt.Text.Replace(btnName.Substring(1, 2), "");
                    selHidTxt.Text = selHidTxt.Text.Replace("  ", " ");
                }
                else
                {
                    clickBtn.Background = Brushes.Ivory;
                    clickBtn.Content = "Se";
                    selHidTxt.Text += " " + btnName.Substring(1, 2);
                }
                
            }
        }

        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            string boxName = box.Name;
            box.Text = box.Text.Trim().ToUpper();
        }

        private bool IsValidName()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("givenTxt", "Given Name");
            fields.Add("surTxt", "Surname");

            Regex pattrn = new Regex(@"^[a-zA-Z' .,]*$");

            foreach (string fieldName in fields.Keys)
            {
                TextBox textBox = (TextBox)this.FindName(fieldName);
                string textBoxTxt = textBox.Text;
                if (!pattrn.IsMatch(textBoxTxt))
                {
                    MessageBox.Show(fields[fieldName] + 
                                    " cannot contain numbers or special characters.");
                    textBox.Focus();
                    textBox.SelectAll();
                    return false;
                }
                if (textBoxTxt.Length < 2)
                {
                    MessageBox.Show(fields[fieldName] + " should be least 2 characters.");
                    textBox.Focus();
                    textBox.SelectAll();
                    return false;
                }
            }
            return true;
        }

    }

}