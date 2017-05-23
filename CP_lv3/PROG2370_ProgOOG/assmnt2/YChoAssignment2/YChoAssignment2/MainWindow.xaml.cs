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

/// <summary>
/// Yoonsuk Cho
/// PROG2370 Assignment 2
/// Sep 2016
/// 
/// This program is the game is known as 'Tic Tac Toc'.
/// </summary>
/// 
namespace YChoAssignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // order and sequential no of player
        int ORDER;
        // occupied places of each(x and o) players
        ArrayList X_PLACES, O_PLACES;
        // size of game board
        readonly int GAME_SIZE = 3 * 3;
        // all occupied cases of winning
        readonly string[,] WINNING_ARR = { { "1", "2", "3" }, { "1", "4", "7" }, 
                                           { "1", "5", "9" }, { "2", "5", "8" },
                                           { "3", "5", "7" }, { "3", "6", "9" }, 
                                           { "4", "5", "6" }, { "7", "8", "9" } };
        // images when gmae is played (X, O, blank)
        readonly string X_IMG = "Resources/x_img_t.png";
        readonly string O_IMG = "Resources/o_img_t.png";
        readonly string B_IMG = "Resources/b_img_t.png";

        public MainWindow()
        {
            InitializeComponent();

            StartNewGame();
            // adds an click event to all rectangles
            for (int i = 1; i <= GAME_SIZE; i++)
            {
                Rectangle tempRect = (Rectangle)this.FindName("rect" + i);
                tempRect.MouseLeftButtonDown += rectangle_Click;
            }

        }
        /// <summary>
        /// initialize variables and rectangle images
        /// </summary>
        private void StartNewGame()
        {
            ORDER = 0;
            X_PLACES = new ArrayList();
            O_PLACES = new ArrayList();
            for (int i = 1; i <= GAME_SIZE; i++)
            {
                Rectangle tempRect = (Rectangle)this.FindName("rect" + i);

                tempRect.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(B_IMG, UriKind.Relative))
                };
            }
        }
        /// <summary>
        /// check the occupation of selected button
        /// </summary>
        /// <param name="btnNo">selected button's name</param>
        /// <returns>boolean if it is occuped</returns>
        bool CheckOccupied(string btnNo)
        {
            bool isOccupied = false;
            // check all X's occupation
            foreach (string no in X_PLACES)
            {
                if (btnNo == no) isOccupied = true;
            }
            // check all O's occupation
            foreach (string no in O_PLACES)
            {
                if (btnNo == no) isOccupied = true;
            }
            return isOccupied;
        }
        /// <summary>
        /// check whether it wins
        /// </summary>
        /// <param name="occupied">occupation of X or O</param>
        /// <returns>boolean if it wins</returns>
        bool CheckWinOrLose(ArrayList occupied)
        {
            bool isWinner = false;
            // check while looping of all winning cases
            for (int i = 0; i < WINNING_ARR.GetLength(0); i++)
            {
                // whenver check a new case, initialize the match count
                int matchTimes = 0;
                // check the position of current player's occupation
                foreach (string eachNo in occupied)
                {
                    // check the each number of a winning case
                    for (int j = 0; j < WINNING_ARR.GetLength(1); j++)
                    {
                        if (WINNING_ARR[i, j] == eachNo)
                        {
                            matchTimes++;
                            break;
                        }
                    }
                }
                // if 3 among all selected numbers match with any winning case, 
                // stop checking and it makes the conclusion of this match
                if (matchTimes == 3) return true;
            }
            return isWinner;
        }
        /// <summary>
        /// the click event of all rectangle
        /// </summary>
        /// <param name="sender">the rectangle which is clicked</param>
        /// <param name="e">the clicked information event</param>
        private void rectangle_Click(object sender, RoutedEventArgs e)
        {
            Rectangle clickRect = (Rectangle)sender;
            ArrayList occupied;
            string imgName = "";
            string btnNameNo = clickRect.Name.Substring(4);
            // make decision of who's turn
            if (ORDER % 2 == 0)
            {
                imgName = X_IMG;
                occupied = X_PLACES;
            }
            else
            {
                imgName = O_IMG;
                occupied = O_PLACES;
            }
            // if it is a place which is alreadu occupied, nothing happens
            if (CheckOccupied(btnNameNo))
            {
                MessageBox.Show("Already Occupied!");
                return;
            }

            occupied.Add(btnNameNo);
            occupied.Sort();

            // change the image of selected places
            clickRect.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(imgName, UriKind.Relative))
            };
            ORDER++;

            // from order of 5, check the winner
            if (ORDER > 4)
            {
                // check the win or lose
                if (CheckWinOrLose(occupied))
                {
                    if (imgName == X_IMG)
                    {
                        MessageBox.Show("X is win");
                        AskPlayAgain();
                    }
                    else
                    {
                        MessageBox.Show("O is win");
                        AskPlayAgain();
                    }
                }
                else
                {
                    // although it reached last order, if there is no winner, 
                    // this game ends in a draw
                    if (ORDER == 9)
                    {
                        MessageBox.Show("This game ends in a draw.");
                        AskPlayAgain();
                    }

                }
            }

        }
        /// <summary>
        /// ask play more, and play more or finish a program
        /// </summary>
        private void AskPlayAgain()
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Play again?", 
                                                        "Tic Tac Toc", 
                                                        MessageBoxButton.YesNo))
                StartNewGame();
            else
                this.Close();
        }

    }
}
