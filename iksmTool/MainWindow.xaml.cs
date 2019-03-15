using System;
using System.Collections.Generic;
using System.Windows;
using Project.IO;


namespace iksmTool
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(Object sender, RoutedEventArgs e)
        {

        }

        private void ListViewButton_Click(Object sender, RoutedEventArgs e)
        {

        }

        private void SettingButton_Click(Object sender, RoutedEventArgs e)
        {
            this.MainFrame.Navigate(new ConfigPage());
        }
    }
}