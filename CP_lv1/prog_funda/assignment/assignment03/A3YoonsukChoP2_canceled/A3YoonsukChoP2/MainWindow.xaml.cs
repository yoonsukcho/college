/*
 * Program name: A3YoonsukChoP2 - Lottery Number Generator 
 * 
 * Purpose: assignment 3-2
 *
 * Revision History:
 * created Sept 2015 by Yoonsuk Cho 
 * 
 * */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
            //
        }

        private bool chkInput(out int selNum, out int rngNum)
        {

            selNum = 0;
            rngNum = 0;
            if (!int.TryParse(selTxt.Text, out selNum))
            {
                MessageBox.Show("Please, input a integer in \"the number of selection numbers\".");
                selNum = 0;
                return false;
            }

            if (!int.TryParse(rngTxt.Text, out rngNum))
            {
                MessageBox.Show("Please, input a integer in \"the range of numbers\".");
                selNum = 0;
                return false;
            }
            if (selNum >= rngNum)
            {
                MessageBox.Show("\"The range of numbers\" should be bigger than \"the number of selection numbers\".");
                selNum = 0;
                return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int selNum = 0;
            int rngNum = 0;

            if (!chkInput(out selNum, out rngNum)) return;

            Random rnd = new Random();

            int[] rndNumArr = new int[selNum];
            int[] tmpNumArr = new int[selNum];

            var items = new List<SelectedNumber>();

            for (int i = 0; i < selNum; i++)
            {
                bool isSame = false;

                while (!isSame)
                {
                    rndNumArr[i] = rnd.Next(rngNum) + 1;

                    for (int j = 0; j <= i; j++)
                    {
                        if (i == j)
                        {
                            isSame = true;   // check end - finish loop
                            break;
                        }
                        if (rndNumArr[i] > rndNumArr[j])      // sort - bigger than prev ; do not move
                        {
                            continue;
                        }
                        else if (rndNumArr[i] == rndNumArr[j])     // duplicate check
                        {
                            isSame = true;
                            i--;
                            break;
                        }
                        else if (rndNumArr[i] < rndNumArr[j])      // sort - smaller than prev ; shift 1 space from here
                        {
                            Array.Copy(rndNumArr, 0, tmpNumArr, 0, j);
                            tmpNumArr[j] = rndNumArr[i];
                            Array.Copy(rndNumArr, j, tmpNumArr, j + 1, selNum - j - 1);
                            Array.Copy(tmpNumArr, rndNumArr, selNum);
                            break;
                        }
                    }
                }

            }


            for (int i = 0; i < selNum; i++)
            {
                items.Add(new SelectedNumber(i + 1, rndNumArr[i]));
            }

            resultTable.ItemsSource = items;

        }


    }

    class SelectedNumber
    {
        public int no { get; set; }
        public int number { get; set; }
        public SelectedNumber(int no, int number)
        {
            this.no = no;
            this.number = number;
        }
    }

}