using System;
using System.Collections.Generic;
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

/// <summary>
/// Yoonsuk Cho
/// PROG2370 Assignment 1
/// Sep 2016
/// 
/// This program manages the reservation system of air ticket.
/// </summary>
/// 
namespace YChoAssignment1
{

    public partial class MainWindow : Window
    {
        // reservation list 2d array
        private string[,] RESRV_LIST = new string[5,3];
        // waiting list array
        private string[] WAIT_LIST = new string[10];

        public MainWindow()
        {
            InitializeComponent();
            InitValue();
        }

        /// <summary>
        /// Initialize seat reservation list and waiting list 
        /// </summary>
        /// <param name="">No parameter</param>
        /// <returns>No return</returns>
        void InitValue()
        {
            // initialize seat reservation list
            for (int i = 0; i < RESRV_LIST.GetLength(0); i++)
            {
                for (int j = 0; j < RESRV_LIST.GetLength(1); j ++)
                {
                    RESRV_LIST[i, j] = "";
                }
            }
            // initialize waiting list 
            for (int i = 0; i < WAIT_LIST.GetLength(0); i++)
            {
                WAIT_LIST[i] = "";
            }

            // display seat list 
            updateResvList();
        }

        /// <summary>
        /// check whether seat is selected
        /// </summary>
        /// <param name="">no parameter</param>
        /// <returns>bool IsSeatSelected</returns>
        bool IsSeatSelected()
        {
            int row = listBoxRow.SelectedIndex;
            int col = listBoxColumn.SelectedIndex;
            if (row < 0 || col < 0)
            {
                MessageBox.Show("No seat is specified", "Error");
                return false;
            }
            return true;
        }

        /// <summary>
        /// get seat no using its array index
        /// </summary>
        /// <param name="row">integer</param>
        /// <param name="col">integer</param>
        /// <returns>string name</returns>
        string GetSeatName(int row, int col)
        {
            string seatName = (row == 0) ? "A" : (row == 1) ? "B" : (row == 2) ? "C" : (row == 3) ? "D" : "E"; // row
            seatName += col; // column
            return seatName;
        }

        /// <summary>
        /// check if there is a seat available
        /// </summary>
        /// <param name="">no parameter</param>
        /// <returns>bool IsAvailableSeat</returns>
        bool IsAvailableSeat()
        {
            bool isAvailable = false;
            for (int i = 0; i < RESRV_LIST.GetLength(0); i++)
            {
                for (int j = 0; j < RESRV_LIST.GetLength(1); j++)
                {
                    if (RESRV_LIST[i, j] == "") isAvailable = true;
                }
            }
            return isAvailable;
        }

        /// <summary>
        /// check if passenger name is typed
        /// </summary>
        /// <param name="passengerName">string</param>
        /// <returns>bool checkPassengerName</returns>
        bool CheckPassName(string passengerName)
        {
            if (passengerName == "")
            {
                MessageBox.Show("No passenger name", "Error");
                return false;
            }
            return true;
        }

        /// <summary>
        /// book a seat and show its result message
        /// </summary>
        /// <param name="row">int</param>
        /// <param name="column">int</param>
        /// <param name="passengerName">string</param>
        /// <returns>no return</returns>
        void BookSeat(int row, int col, string passengerName)
        {
            if (RESRV_LIST[row, col] == "")
            {
                RESRV_LIST[row, col] = passengerName;
                MessageBox.Show("Booking is completed: " + passengerName + 
                                " [" + GetSeatName(row, col) + "]", "Success");
            }
            else
            {
                MessageBox.Show("Already booked seat is chosen", "Error");
            }

        }

        /// <summary>
        /// add a passenger to a waiting list
        /// </summary>
        /// <param name="passengerName">string</param>
        /// <returns>no return</returns>
        void AddWaitList(string passengerName)
        {
            int waitListLength = WAIT_LIST.GetLength(0);
            for (int i = 0; i < waitListLength; i++)
            {
                if (WAIT_LIST[i] == "")
                {
                    WAIT_LIST[i] = passengerName;
                    MessageBox.Show("Add waiting list is completed", "Success");
                    return;
                }
                if (i == waitListLength - 1)
                {
                    MessageBox.Show("Waiting list is full", "Error");
                }
            }
        }

        /// <summary>
        /// shift array contents to front by 1
        /// </summary>
        /// <param name="strArray">string[]</param>
        /// <returns>string[] shiftedArray</returns>
        string[] ShiftArray(string[] strArray)
        {
            string[] shiftedArray = new string[strArray.Length];
            Array.Copy(strArray, 1, shiftedArray, 0, strArray.Length - 1);
            shiftedArray[strArray.Length - 1] = "";
            return shiftedArray;
        }

        /// <summary>
        /// show all seat list on Reservation box
        /// </summary>
        void updateResvList()
        {
            FlowDocument allListDoc = new FlowDocument();
            Paragraph allListParagraph = new Paragraph();
            for (int i = 0; i < RESRV_LIST.GetLength(0); i++)
            {
                for (int j = 0; j < RESRV_LIST.GetLength(1); j++)
                {
                    allListParagraph.Inlines.Add(new Bold(new Run("[" + GetSeatName(i, j)+ "]" + ": ")));
                    allListParagraph.Inlines.Add(new Run(RESRV_LIST[i, j] + "\n"));
                }
            }
            allListDoc.Blocks.Add(allListParagraph);
            rTxtResvList.Document = allListDoc;
        }

        /// <summary>
        /// show all waiting list on Wait listing box
        /// </summary>
        void updateWaitList()
        {
            FlowDocument waitListDoc = new FlowDocument();
            Paragraph waitListParagraph = new Paragraph();
            for (int i = 0; i < WAIT_LIST.GetLength(0); i++)
            {
                if (WAIT_LIST[i] != "")
                {
                    waitListParagraph.Inlines.Add(new Run(WAIT_LIST[i] + "\n"));
                }
            }
            waitListDoc.Blocks.Add(waitListParagraph);
            rTxtWaitList.Document = waitListDoc;
        }

        /// <summary>
        /// event method when book button is clicked
        /// check validation and then a passenger name will be added to book list or wait list
        /// </summary>
        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            if (!IsSeatSelected()) return;

            string passengerName = txtName.Text.Trim();
            if (!CheckPassName(passengerName)) return;

            // check available seat, then book or add waiting list
            if (IsAvailableSeat())
            {
                BookSeat(listBoxRow.SelectedIndex, listBoxColumn.SelectedIndex, passengerName);
            }
            else
            {
                AddWaitList(passengerName);
            }

        }

        /// <summary>
        /// event method when Show All button is clicked
        /// execute updateResvList method
        /// </summary>
        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            updateResvList();
        }

        /// <summary>
        /// event method when Fill All button is clicked
        /// fill all seats with test name for testing
        /// </summary>
        private void btnFillAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < RESRV_LIST.GetLength(0); i++)
            {
                for (int j = 0; j < RESRV_LIST.GetLength(1); j++)
                {
                    if (RESRV_LIST[i, j] == "")
                    {
                        RESRV_LIST[i, j] = "1stName" + i + " lastName" + j;
                    }
                }
            }
        }

        /// <summary>
        /// event method when Show Waiting List button is clicked
        /// execute updateWaitList method
        /// </summary>
        private void btnShowWaitList_Click(object sender, RoutedEventArgs e)
        {
            updateWaitList();
        }

        /// <summary>
        /// event method when Add Waiting List button is clicked
        /// check input validation and if there is seat available 
        /// ,and then add a passenger to waiting list
        /// </summary>
        private void btnAddWaitList_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckPassName(txtName.Text.Trim())) return;
            // check all seats are occupied
            if (IsAvailableSeat())
            {
                MessageBox.Show("There are seats available", "Error");
                return;
            }
            AddWaitList(txtName.Text.Trim());
        }

        /// <summary>
        /// event method when Cancel button is clicked
        /// check if there is seat selected 
        /// and cancel a specific reserved seat
        /// if there is a passenger on the waiting list, 
        /// the passenger will move to vacant seat of reservatin list
        /// then the waiting list is relocated
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (!IsSeatSelected()) return;
            int row = listBoxRow.SelectedIndex;
            int col = listBoxColumn.SelectedIndex;
            // check selected seat is occupied
            if (RESRV_LIST[row, col] == "")
            {
                MessageBox.Show("Selected seat is not occupied", "Error");
                return;
            }
            RESRV_LIST[row, col] = "";
            if (WAIT_LIST[0] != "")
            {
                RESRV_LIST[row, col] = WAIT_LIST[0];
                WAIT_LIST = ShiftArray(WAIT_LIST);
            }
            MessageBox.Show("Cancelling reservation is completed", "Success");

        }

        /// <summary>
        /// event method when status button is clicked
        /// check if selected seat is seat available 
        /// then it displays 'available' or 'not available'
        /// </summary>
        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            if (!IsSeatSelected())
            {
                txtStatus.Text = "";
                return;
            }

            if (RESRV_LIST[listBoxRow.SelectedIndex, listBoxColumn.SelectedIndex] == "") txtStatus.Text = "Available";
            else txtStatus.Text = "Not Available";

            //if (IsAvailableSeat()) txtStatus.Text = "Available";
            //else txtStatus.Text = "Not Available";
        }

    }

}
