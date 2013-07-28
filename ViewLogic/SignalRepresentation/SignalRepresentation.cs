﻿using System;
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

using SignalProcessor.PresenterLogic;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Integration;

namespace SignalProcessor.ViewLogic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {


        private void PropertyPanelUpdate(StackPanel panel)
        {
            ControlGrid.Children.Clear();
            ControlGrid.Children.Add(panel);
        }

        private void SignalLayoutUpdate(StackPanel panel)
        {
            panelChart.Children.Clear();
            panelChart.Children.Add(panel);
        }


        
        /// <summary>
        /// methods for getting ready panels based on Args types
        /// </summary>
        /// <param name="args"></param>


        public void SignalLayout(SignalPanelArgs args)
        {

            panelChart.Children.Clear();
            lblCurrentlyChosen.Content = args.Name;
            for (int i = 0; i < args.ChartCount; ++i)
            {
                WindowsFormsHost host = new WindowsFormsHost();
                host.Child = args.GetChart(i);
                this.panelChart.Children.Add(host);
                //this.panelChart.Children.Add(args.GetChart(i));
            }


        }

        public void PropertiesLayout(PropertyPanelArgs args)
        {
            this.PropertyPanelUpdate(GetPropertiesPanel(args));
        }

        private void btnPropertiesCount_Click(object sender, EventArgs e)
        {
            CountPropertiesQuery(sender, e);
        }

        public event EventHandler<EventArgs> CountPropertiesQuery;






        ///
        /// Methods for getting panel with data and controls
        ///

        private StackPanel GetPropertiesPanel(PropertyPanelArgs args)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Margin = new Thickness(5);

            Label lblName = new Label();
            lblName.FontSize = 16;
            lblName.FontWeight = FontWeights.Bold;
            lblName.Content = args.Name + " properties:";
            panel.Children.Add(lblName);

            if (args.Properties == null)
            {
                Button btn = new Button();
                btn.Click += btnPropertiesCount_Click;
                btn.Content = "Count properties";
                btn.Style = App.Current.FindResource("PanelButtonStyle") as Style;
                btn.Width = 170;
                btn.Height = 30;
                panel.Children.Add(btn);
            }
            else
            {
                Label lblPoints = new Label();
                lblPoints.Content = "Points: " + args.Properties.Points.ToString();
                panel.Children.Add(lblPoints);

                Label lblDuration = new Label(); ;
                lblDuration.Content = "Duration: " + args.Properties.Duration.ToString();
                panel.Children.Add(lblDuration);

                Label lblAverage = new Label();
                lblAverage.Content = "Average: " + args.Properties.Average.ToString();
                panel.Children.Add(lblAverage);

                Label lblVariance = new Label();
                lblVariance.Content = "Variance: " + args.Properties.Variance.ToString();
                panel.Children.Add(lblVariance);


                
                // else to be added

            }

            WrapPanel waveletPanel = new WrapPanel();
            waveletPanel.Orientation = Orientation.Vertical;
            waveletPanel.Margin = new Thickness(3);
            waveletPanel.Background = Brushes.Gainsboro;
            DockPanel.SetDock(waveletPanel, Dock.Top);

            DockPanel dockPanel = new DockPanel();
            dockPanel.Children.Add(waveletPanel);

            ScrollViewer scv = new ScrollViewer();
            scv.Content = dockPanel;
            Binding scvHeightBinding = new Binding();
            scvHeightBinding.Source = App.Current.MainWindow;
            scvHeightBinding.Path = new PropertyPath("Height");
            scvHeightBinding.Converter = new HeightConverter();
            scv.SetBinding(HeightProperty, scvHeightBinding);

            Label lblHeader = new Label();
            lblHeader.Content = "Wavelet tranform";
            lblHeader.FontWeight = FontWeights.Black;
            waveletPanel.Children.Add(lblHeader);

            for (int i = 0; i < args.WaveletLevels; ++i)
            {
                Label lbl = new Label();
                lbl.Content = "Level " + (i + 1).ToString();
                waveletPanel.Children.Add(lbl);
                StackPanel localPanel = new StackPanel();
                localPanel.Orientation = Orientation.Horizontal;
                if (args.WaveletCounted[i] == true)
                {
                    Button btnShow = new Button();
                    btnShow.Click += btnWavletShowClick;
                    btnShow.Name = "btnWaveletShow_" + (i + 1).ToString();
                    if (args.WaveletShown[i] == false)
                        btnShow.Content = "Show";
                    else
                        btnShow.Content = "Hide";
                    btnShow.Style = App.Current.FindResource("PanelButtonStyle") as Style;
                    btnShow.Width = 100;
                    btnShow.Height = 20;
                    localPanel.Children.Add(btnShow);

                    Button btnOpen = new Button();
                    btnOpen.Click += btnWavletOpenClick;
                    btnOpen.Name = "btnWaveletShow_" + (i + 1).ToString();
                    btnOpen.Content = "Open";
                    btnOpen.Style = App.Current.FindResource("PanelButtonStyle") as Style;
                    btnOpen.Width = 100;
                    btnOpen.Height = 20;
                    localPanel.Children.Add(btnOpen);
                }
                else
                {
                    Button btn = new Button();
                    btn.Click += btnWaveletCount_Click;
                    btn.Name = "btnWaveletCount_" + (i + 1).ToString();
                    btn.Content = "Count";
                    btn.Style = App.Current.FindResource("PanelButtonStyle") as Style;
                    btn.Width = 100;
                    btn.Height = 20;
                    localPanel.Children.Add(btn);
                }
                waveletPanel.Children.Add(localPanel);

            }
            //panel.Children.Add(waveletBasePanel);
            panel.Children.Add(scv);

            return panel;
        }


        private void btnWaveletCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string btnName = (sender as Button).Name;
                string lvlStr = btnName.Remove(0, btnName.IndexOf('_') + 1);
                CountWaveletQuery(lvlStr, e);
            }
            catch
            {
                return;
            }
        }

        private void btnWavletShowClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                string btnName = btn.Name;
                string lvlStr = btnName.Remove(0, btnName.IndexOf('_') + 1);

                SwitchWaveletStateQuery(lvlStr, e);
            }
            catch
            {
                return;
            }
        }

        private void btnWavletOpenClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string btnName = (sender as Button).Name;
                string lvlStr = btnName.Remove(0, btnName.IndexOf('_') + 1);
                OpenWaveletQuery(lvlStr, e);
            }
            catch
            {
                return;
            }
        }


        public event EventHandler<EventArgs> CountWaveletQuery;

        public event EventHandler<EventArgs> SwitchWaveletStateQuery;

        public event EventHandler<EventArgs> OpenWaveletQuery;
    }
}