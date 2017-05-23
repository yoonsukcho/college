using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Yoonsuk Cho
/// PROG2370 Assignment 3
/// Oct 2016
/// 
/// This program is the button class of the game is known as 'n-puzzle game', 
/// and this extends System.Windows.Forms.Button class.
/// </summary>
/// 
namespace YChoAssignment3
{
    class PuzBtn : Button
    {

        private int H_POS = 0;             // horizontal position of grid
        private int V_POS = 0;             // vetical position of grid
        private readonly int H_SIZE = 45;  // horizontal size of button
        private readonly int V_SIZE = 45;  // vetical size of button
        private readonly int BTN_GAP = 1;  // gap between of buttons
        private readonly int MOVE_SMOOTH = 5;  // number of smooth move
        /// <summary>
        /// default constructor
        /// </summary>
        public PuzBtn()
        {
            this.Width = H_SIZE;
            this.Height = V_SIZE;
        }
        /// <summary>
        /// move this button to destination visually
        /// </summary>
        /// <param name="h_pos">X position of Location</param>
        /// <param name="v_pos">Y position of Location</param>
        public void MovePosition(int h_pos, int v_pos)
        {
            int h_gap = h_pos - H_POS;
            int v_gap = v_pos - V_POS;
            int divide = H_SIZE / MOVE_SMOOTH;
            for (int i = 0; i < divide; i++)
            {
                Location = new Point(Left + (MOVE_SMOOTH * h_gap), Top + (MOVE_SMOOTH * v_gap));
                Thread.Sleep(5);
            }
            Location = new Point(Location.X + (BTN_GAP * h_gap), Location.Y + (BTN_GAP * v_gap));
            H_POS = h_pos;
            V_POS = v_pos;
        }

        /// <summary>
        /// set grid position of this button
        /// </summary>
        /// <param name="h_pos">horizontal grid position</param>
        /// <param name="v_pos">vertical grid position</param>
        public void SetGridPosition(int h_pos, int v_pos)
        {
            Location = new Point(h_pos * (H_SIZE + BTN_GAP), v_pos * (V_SIZE + BTN_GAP));
            H_POS = h_pos;
            V_POS = v_pos;
        }
        /// <summary>
        /// get grid position of this button
        /// </summary>
        /// <returns>x position and y position</returns>
        public int[] GetGridPosition()
        {
            return new int[2]{ H_POS, V_POS };
        }

    }
}
