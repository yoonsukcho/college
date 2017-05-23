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

namespace assgnment01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Center_Text();
        }

        private void Center_Text()
        {
            //Graphics g = this.CreateGraphics();
            //Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            //Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            //String tmp = " ";
            //Double tmpWidth = 0;
            //while ((tmpWidth + widthOfASpace) < startingPoint)
            //{
            //    tmp += " ";
            //    tmpWidth += widthOfASpace;
            //}
            //this.Text = tmp + this.Text.Trim();
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "Yoonsuk Cho";
        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "Ycho5551@conestogac.on.ca";
        }

        private void btnProgram_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "Computer Programmer - 1009";
        }

        private void btnSkillLevel_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "High";
        }
    }
}
