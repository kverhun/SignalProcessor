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



namespace SignalProcessor.ViewLogic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private void btnImportTxtChooseFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.FileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "Text|*.txt|All|*.*";
            if (dlg.ShowDialog() == true)
            {
                importTxtFilename.Text = dlg.FileName;
                this.btnImportTxt.IsEnabled = true;           
            }

        }

        private void btnImportTxt_Click(object sender, RoutedEventArgs e)
        {
            ImportTxtFileQuery(sender, e);
        }



        public string GetImportTxtFilename()
        {
            return this.importTxtFilename.Text;
        }
    }
}