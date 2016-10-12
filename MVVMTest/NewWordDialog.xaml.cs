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

namespace Fiszka
{
    /// <summary>
    /// Interaction logic for NewUserDialog.xaml
    /// </summary>
    public partial class NewWordDialog : Window
    {
        public NewWordDialog()
        {
            InitializeComponent();
        }
        
        public string OriginWord
        {
            get { return OriginWordTextBox.Text; }
            set { OriginWordTextBox.Text = value; }
        }

        public string Translation
        {
            get { return TranslationTextBox.Text; }
            set { TranslationTextBox.Text = value; }
        }


        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
