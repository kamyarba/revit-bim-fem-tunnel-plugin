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
using System.Windows.Shapes;

namespace TurUpAILinesegmentation
{
    /// <summary>
    /// Interaction logic for frmSegmentnumber.xaml
    /// </summary>
    public partial class frmSegmentnumber : Window
    {
        public string nPoints { get; private set; }
        public string vProgression { get; private set; }

        public frmSegmentnumber()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            nPoints = txtnPoint.Text;
            vProgression = txtProgress.Text;
            this.DialogResult = true;
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
