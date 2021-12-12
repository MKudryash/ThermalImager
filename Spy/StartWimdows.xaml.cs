using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Spy
{
    /// <summary>
    /// Логика взаимодействия для StartWimdows.xaml
    /// </summary>
    public partial class StartWimdows : Window
    {
       public static int row;
        public static int column;
        public static DateTime Doo;
        public static DateTime Ot;
        public static DateTime Search;
        public StartWimdows()
        {
            InitializeComponent();
           
        }


        private void OpenTeplo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                column = Convert.ToInt32(txtColumn.Text);
                row = Convert.ToInt32(txtRow.Text);
                 Ot = Convert.ToDateTime(txttOt.Text);
                 Doo  = Convert.ToDateTime(txtDo.Text);
                Search = DateSearch.SelectedDate.Value;
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            catch { }
        }
    }
}
