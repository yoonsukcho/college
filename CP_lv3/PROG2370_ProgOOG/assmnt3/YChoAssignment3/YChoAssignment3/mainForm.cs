using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Yoonsuk Cho
/// PROG2370 Assignment 3
/// Oct 2016
/// 
/// This program is the main program of 
/// the game is known as 'n-puzzle game'.
/// </summary>
/// 
namespace YChoAssignment3
{
    /// <summary>
    /// mainForm control program
    /// </summary>
    public partial class mainForm : Form
    {
        // horizontal size of puzzle
        private int H_SIZE = 0;
        // vertical size of puzzle
        private int V_SIZE = 0;
        // width of puzzle button
        private readonly int BTN_WIDTH = 45;
        // height of puzzle button
        private readonly int BTN_HEIGHT = 45;
        // gap size of puzzle buttons
        private readonly int BTN_GAP = 1;
        // solving puzzle button position		
        private string SOLUTION = "";
        // current puzzle button position
        private string CUR_POS = "";
        // count of moving puzzle button
        private int tryCount = 0;
        // main delimiter of saving file
        private readonly char MAIN_DEL = ':';
        // delimiter of puzzle buttons		
        private readonly char PZL_DEL = ';';
        // X and Y value delimiter of each puzzle button
        private readonly char XY_DEL = ',';

        /// <summary>
        /// default constructor
        /// </summary>
        public mainForm()
        {
            InitializeComponent();

            H_SIZE = Int32.Parse(txtRows.Text); // initial value = 4
            V_SIZE = Int32.Parse(txtCols.Text); // initial value = 4
            InitForm();                         // initialize the form given size
            ShufflePuzzle();                    // shuffle the puzzle buttons
        }

        /// <summary>
        /// initialize form size by row count and column count
        /// </summary>
        public void InitForm()
        {
            // clear the panel including the all puzzle buttons
            panMain.Controls.Clear();
            // initialize the trying count
            tryCount = 0;
            // resize the width of this game window
            this.Width = H_SIZE * (BTN_WIDTH + BTN_GAP) + 110;
            // minimum value of width is 300			
            this.Width = this.Width < 300 ? 300 : this.Width;
            // resize the height of this game window
            this.Height = V_SIZE * (BTN_HEIGHT + BTN_GAP) + 200;
            // minimum value of width is 300
            this.Height = this.Height < 300 ? 300 : this.Height;
            // resize the panel which is including all puzzle buttons
            panMain.Width = this.Width - 60;
            panMain.Height = this.Height - 120;
            // generating the puzzle buttons with given size
            GenGame();
        }
        /// <summary>
        /// find empty places(button) in main panel
        /// </summary>
        /// <returns>PuzBtn empty button</returns>
        private PuzBtn FindEmptyBtn()
        {
            PuzBtn returnBtn = null;
            foreach (PuzBtn item in panMain.Controls.OfType<PuzBtn>())
            {
                if (item.Visible == false)
                {
                    returnBtn = item;
                    break;
                }
            }
            return returnBtn;
        }
        /// <summary>
        /// find the specific button with x and y position
        /// </summary>
        /// <param name="pos">x position, y position</param>
        /// <returns>PuzBtn specifc button</returns>
        private PuzBtn FindSpecBtn(int[] pos)
        {
            PuzBtn returnBtn = null;
            foreach (PuzBtn item in panMain.Controls.OfType<PuzBtn>())
            {
                int[] tmpPos = item.GetGridPosition();
                if (pos[0] == tmpPos[0] && pos[1] == tmpPos[1])
                {
                    returnBtn = item;
                    break;
                }
            }
            return returnBtn;
        }

        /// <summary>
        /// generating the puzzle buttons with given size
        /// and, make the solving position of this size puzzle
        /// </summary>
        private void GenGame()
        {
            SOLUTION = "";

            for (int j = 0; j < V_SIZE; j++)
            {
                for (int i = 0; i < H_SIZE; ++i)
                {
                    PuzBtn btn = new PuzBtn();
                    btn.SetGridPosition(i, j);
                    // make the solving text
                    SOLUTION += i.ToString() + XY_DEL +
                                   j.ToString() + PZL_DEL;
                    // set the puzzle button text
                    btn.Text = (j * H_SIZE + i + 1).ToString();
                    // add the puzzle button's click event
                    btn.Click += puzBtn_Click;
                    // add the button to panel
                    panMain.Controls.Add(btn);
                    // empty slot is a same button but its visible is 'false'
                    if (i == H_SIZE - 1 && j == V_SIZE - 1)
                    {
                        btn.Visible = false;
                    }
                }
            }
            // remove last ";" for split
            if (SOLUTION.EndsWith(PZL_DEL.ToString()))
                SOLUTION = SOLUTION.Substring(0, SOLUTION.Length - 1);
        }
        /// <summary>
        /// rearrange the puzzle buttons 
        /// with the loading file's position
        /// </summary>
        /// <param name="position">puzzle position information</param>
        private void LoadPuzBtn(string position)
        {
            string[] btnPositions = position.Split(PZL_DEL);
            int i = 0;
            // set all puzzle button move to loading position value
            foreach (PuzBtn item in panMain.Controls.OfType<PuzBtn>())
            {
                string[] xyPosition = btnPositions[i].Split(XY_DEL);
                int xPos = Int32.Parse(xyPosition[0]);
                int yPos = Int32.Parse(xyPosition[1]);
                item.SetGridPosition(xPos, yPos);
                i++;
            }
        }
        /// <summary>
        /// shuffle all puzzle buttons counting 20~30 times of its size(x * y)
        /// this shuffle starts from initial position 
        /// to its random directions by 1 step
        /// </summary>
        private void ShufflePuzzle()
        {
            Random rnd = new Random();
            // get the suffle counts randomly, 
            // the counts would be 20~30 times of its size
            int shflTimes = rnd.Next(H_SIZE * V_SIZE * 20, H_SIZE * V_SIZE * 30);
            for (int i = 0; i < shflTimes; i++)
            {
                PuzBtn emptyBtn = FindEmptyBtn();
                int[] empPos = emptyBtn.GetGridPosition();
                int[] rplPos = { empPos[0], empPos[1] };
                // creates a number between 0: horizontal and 1:vertical
                int dir = rnd.Next(0, 2);
                // creates a number between -1 and 1  
                int pos = rnd.Next(-1, 2);
                // horizontal direction
                if (dir == 0)
                {
                    // when empty solt is located at the first column, 
                    // move to right
                    if (empPos[0] == 0) rplPos[0] = empPos[0] + 1;
                    // when empty solt is located at the first column, 
                    // move to left
                    else if (empPos[0] == H_SIZE - 1) rplPos[0] = empPos[0] - 1;
                    // when empty solt is not located at the first and last,
                    // move to the direction same to 'pos'
                    else rplPos[0] = empPos[0] + pos;
                }
                else                         // vertical direction
                {
                    // when empty solt is located at the first row, 
                    // move to down
                    if (empPos[1] == 0) rplPos[1] = empPos[1] + 1;
                    // when empty solt is located at the last row, 
                    // move to up
                    else if (empPos[1] == V_SIZE - 1) rplPos[1] = empPos[1] - 1;
                    // when empty solt is not located at the first and last, 
                    // move to the direction same to 'pos'
                    else rplPos[1] = empPos[1] + pos;
                }
                PuzBtn selBtn = FindSpecBtn(rplPos);
                // switch their positions
                emptyBtn.SetGridPosition(rplPos[0], rplPos[1]);
                selBtn.SetGridPosition(empPos[0], empPos[1]);
            }

            // for current position string value
            CheckResult();

        }
        /// <summary>
        /// puzzle button's click event
        /// if any direction is empty beside the button, 
        /// it would go to the direction by 1 step
        /// </summary>
        /// <param name="sender">the puzzle button</param>
        /// <param name="e">buttons event arguments</param>
        private void puzBtn_Click(object sender, EventArgs e)
        {
            // if currently is resolved, nothing is happened.
            if (SOLUTION == CUR_POS) return;
            // add 1 on the solving counts
            // empty solt's position
            PuzBtn emptyBtn = FindEmptyBtn();
            int[] emptyPos = emptyBtn.GetGridPosition();
            // this button's position
            int[] myPos = ((PuzBtn)sender).GetGridPosition();
            if ((Math.Abs(myPos[0] - emptyPos[0]) == 1 &&
                 myPos[1] - emptyPos[1] == 0) ||
                (myPos[0] - emptyPos[0] == 0 &&
                 Math.Abs(myPos[1] - emptyPos[1]) == 1))
            {
                // switch their positions
                emptyBtn.SetGridPosition(myPos[0], myPos[1]);
                ((PuzBtn)sender).MovePosition(emptyPos[0], emptyPos[1]);
                // add the try count after move
                tryCount++;
                // checking whether it is solved
                CheckResult();
            }
        }
        /// <summary>
        /// compare solving order and current order
        /// if these are same, show the current trying count
        /// </summary>
        private void CheckResult()
        {
            CUR_POS = "";
            // make a current position string
            foreach (PuzBtn ctrl in panMain.Controls.OfType<PuzBtn>())
            {
                int[] pos = ctrl.GetGridPosition();
                CUR_POS += pos[0].ToString() + XY_DEL +
                                 pos[1].ToString() + PZL_DEL;
            }
            // remove last delimiter
            if (CUR_POS.EndsWith(PZL_DEL.ToString()))
                CUR_POS = CUR_POS.Substring(0, CUR_POS.Length - 1);
            // if it is solved, show message & count, then restart the game
            if (SOLUTION == CUR_POS)
            {
                if (tryCount > 0)
                {
                    MessageBox.Show("SOLVED!!: " + tryCount + " times.");
                }
                InitForm();
                ShufflePuzzle();
            }
        }
        /// <summary>
        /// check the input value of row and column number
        /// </summary>
        /// <returns>boolean value of if it is available</returns>
        private bool CheckInputValue()
        {
            bool returnValue = true;
            // check the input values are numeric
            try
            {
                H_SIZE = Int32.Parse(txtRows.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Only number is allowed in Rows textbox.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRows.SelectAll();
                return false;
            }
            try
            {
                V_SIZE = Int32.Parse(txtCols.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Only number is allowed in Columns textbox",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCols.SelectAll();
                return false;
            }
            // if the size is bigger than the ability of machine, it cracks.
            if (H_SIZE < 2 || H_SIZE > 25)
            {
                MessageBox.Show("Row size should be between 2 and 25.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRows.SelectAll();
                return false;
            }
            if (V_SIZE < 2 || V_SIZE > 25)
            {
                MessageBox.Show("Column size should be between 2 and 25.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRows.SelectAll();
                return false;
            }
            return returnValue;
        }
        /// <summary>
        /// click event of generate button
        /// after check input value and execute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGen_Click(object sender, EventArgs e)
        {
            // before initialize the game, check the input value
            if (!CheckInputValue()) return;
            // initialize the game
            InitForm();
            // shuffle the puzzle buttons
            ShufflePuzzle();
        }
        /// <summary>
        /// click event of saving button
        /// default directory is c:\
        /// and default extension is txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // before save the game, check the input value
            // because it contains of game size information
            if (H_SIZE != Int32.Parse(txtRows.Text)) txtRows.Text = H_SIZE.ToString();
            if (V_SIZE != Int32.Parse(txtCols.Text)) txtCols.Text = V_SIZE.ToString();
            if (!CheckInputValue()) return;

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            // default directory is c:\
            saveDialog.InitialDirectory = @"C:\";
            saveDialog.RestoreDirectory = true;
            saveDialog.Title = "Save an current position file";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveDialog.OpenFile());
                // data file is consist with 3 parts using delimiter MAIN_DEL = ':'.
                // width:height:positionStrings
                writer.WriteLine(H_SIZE.ToString() + MAIN_DEL +
                                 V_SIZE.ToString() + MAIN_DEL +
                                 CUR_POS);
                writer.Close();
            }
        }
        /// <summary>
        /// click event of loading button
        /// default directory is c:\
        /// and default extension is txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Open current position file";
            openDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openDialog.FilterIndex = 1;
            // default directory is c:\
            openDialog.InitialDirectory = @"C:\";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openDialog.FileName);
                string line = reader.ReadLine();
                string[] readValue = line.Split(MAIN_DEL);
                // data file is consist with 3 parts using delimiter MAIN_DEL = ':'.
                // width:height:positionStrings
                H_SIZE = Int32.Parse(readValue[0]);
                txtRows.Text = readValue[0];
                V_SIZE = Int32.Parse(readValue[1]);
                txtCols.Text = readValue[1];
                InitForm();
                LoadPuzBtn(readValue[2]);
            }
        }

    }
}
