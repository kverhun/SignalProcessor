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
        private void btnExportTxtChooseFile_Click(object sender, RoutedEventArgs e)
        {
            //Microsoft.Win32.FileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
            //dlg.Filter = "Text|*.txt|All|*.*";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //importTxtFilename.Text = dlg
                exportTxtFoldername.Text = dlg.SelectedPath;
                this.btnExportTxt.IsEnabled = true;
            }

        }

        private void btnExportTxt_Click(object sender, RoutedEventArgs e)
        {
            ExportTxtFileQuery(sender, e);
        }



        public string GetExportTxtFilename()
        {
            if (this.txtTxtExportFileName.Text == "")
                this.txtTxtExportFileName.Text = this.lblCurrentlyChosen.Content + ".txt";

            return this.exportTxtFoldername.Text + "\\" + this.lblCurrentlyChosen.Content + ".txt";
        }


        public event EventHandler<EventArgs> ExportTxtFileQuery;
    }
}