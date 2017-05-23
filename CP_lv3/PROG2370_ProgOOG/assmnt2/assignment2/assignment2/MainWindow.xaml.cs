using System;
using System.Collections;
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

namespace assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int ORDER;
        ArrayList firstOccupied, secondOccupied;

        //string[][] winningArr = { "00", "01", "02", "10", "11", "12", "20", "21", "22" };
        const string X_IMG = "Resources/x_img_t.png";
        const string O_IMG = "Resources/o_img_t.png";
        const string B_IMG = "Resources/b_img_t.png";

        public MainWindow()
        {
            InitializeComponent();
            ReadyForNewGame();
            for (int i = 1; i < 10; i++)
            {
                Rectangle tempRect = (Rectangle)this.FindName("rect" + i);
                tempRect.MouseLeftButtonDown += rectangle_Click;
            }
        }
        
        private void ReadyForNewGame()
        {
            ORDER = 0;
            firstOccupied = new ArrayList();
            secondOccupied = new ArrayList();
            for (int i = 1; i < 10; i++)
            {
                Rectangle tempRect = (Rectangle)this.FindName("rect" + i);
                tempRect.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(B_IMG, UriKind.Relative))
                };
            }
        }

        bool CheckOccupied(string btnNo)
        {
            bool isOccupied = false;
            foreach (string no in firstOccupied)
            {
                if (btnNo == no) isOccupied = true;
            }
            foreach (string no in secondOccupied)
            {
                if (btnNo == no) isOccupied = true;
            }
            return isOccupied;
        }

        bool CheckWinOrLose(string btnNo)
        {
            bool isOccupied = false;
            foreach (string no in firstOccupied)
            {
                if (btnNo == no) isOccupied = true;
            }
            foreach (string no in secondOccupied)
            {
                if (btnNo == no) isOccupied = true;
            }
            return isOccupied;
        }

        private void rectangle_Click(object sender, RoutedEventArgs e)
        {
            Rectangle clickRect = (Rectangle)sender;
            string btnNameNo = clickRect.Name.Substring(4);

            // if selected places, nothing happens
            if (CheckOccupied(btnNameNo)) return;

            string imgName = "";
            if (ORDER % 2 == 0)
            {
                imgName = X_IMG;
                firstOccupied.Add(btnNameNo);
            }
            else
            {
                imgName = O_IMG;
                secondOccupied.Add(btnNameNo);
            }
            clickRect.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(imgName, UriKind.Relative))
            };
            ORDER++;

            if (ORDER > 4)
            {
                // check the win or lose
                //CheckWinOrLose();
            }

        }


    }



}
