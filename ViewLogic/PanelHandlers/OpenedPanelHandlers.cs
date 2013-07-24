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

        /// <summary>
        /// creating buttons on Opened panel
        /// </summary>
        /// <param name="items"></param>
        public void OpenedSetItems(List<string> items)
        {
            
            OpenedPanel.Children.Clear();
            StackPanel panel = new StackPanel();
            DockPanel.SetDock(panel, Dock.Top);

            Style btnStyle = App.Current.FindResource("PanelButtonStyle") as Style;
            Style btnRemoveStyle = App.Current.FindResource("RemoveButtonStyle") as Style;
            foreach (string item in items)
            {
                StackPanel localPanel = new StackPanel();
                localPanel.Orientation = Orientation.Horizontal;
                localPanel.Height = 30;
                localPanel.Margin = new Thickness(0);
                Button btn = new Button();
                btn.Name = item;
                btn.Style = App.Current.FindResource("PanelButtonStyle") as Style;
                btn.Height = 20;
                btn.Width = 150;
                btn.Content = item;
                btn.Margin = new Thickness(5);
                btn.Click += btnSignal_Click;
                localPanel.Children.Add(btn);

                Button btnRem = new Button();
                btnRem.Name = item;
                btnRem.Content = "remove";
                btnRem.Style = btnRemoveStyle;
                btnRem.Height = 15;
                btnRem.Width = 45;
                btnRem.Margin = new Thickness(5);
                btnRem.Click += btnRemove_Click;
                localPanel.Children.Add(btnRem);

                panel.Children.Add(localPanel);
            }
            OpenedPanel.Children.Add(panel);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (sender == null) return;
            string name = btn.Name;
            OpenedRemoveQuery(name, e);            
        }

        private void btnSignal_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
                return;
            string name = btn.Name;
            //lblCurrentlyChosen.Content = name;
            OpenedChooseQuery(name, e);
        }






        public event EventHandler<EventArgs> OpenedRemoveQuery;
        public event EventHandler<EventArgs> OpenedChooseQuery;
    }
}