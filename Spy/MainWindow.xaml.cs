using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Spy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int column = StartWimdows.column;
        static int row = StartWimdows.row;

        double[] widthh = new double[column];
        double[] heightt = new double[row];
        struct User
        {
            public int x;
            public int y;
            public DateTime time;
            public DateTime day;
            public override string ToString()
            {
                return x + " " + y + " " + time + " " + day;
            }
        }
        static List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            Avg(StartWimdows.Ot, StartWimdows.Doo);
            razmetka();
            Hooks(StartWimdows.Ot, StartWimdows.Doo);
        }
        int MaxValues = 0;
        public void Avg(DateTime ot, DateTime doo)
        {
            using (StreamReader sr = new StreamReader("D:Doc.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] str = sr.ReadLine().Split(';');

                    users.Add(new User() { x = Convert.ToInt32(str[0]), y = Convert.ToInt32(str[1]), time = Convert.ToDateTime(str[2]), day = Convert.ToDateTime(str[3]) });
                }
            }
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < column; j++)
                {
                    int count = 0;
                    for (int t = 0; t < users.Count; t++)
                    {
                        if (users[t].x < widthh[j] && users[t].y < heightt[i] && users[t].time >= ot && users[t].time <= doo && users[i].day == StartWimdows.Search)
                        {
                            MessageBox.Show("Я зашел Avg");
                            count++;
                            users.RemoveAt(t);
                        }
                    }
                }
            }
        }
        public void Hooks(DateTime ot, DateTime doo)
        {

            using (StreamReader sr = new StreamReader("D:Doc.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] str = sr.ReadLine().Split(';');

                    users.Add(new User() { x = Convert.ToInt32(str[0]), y = Convert.ToInt32(str[1]), time = Convert.ToDateTime(str[2]), day = Convert.ToDateTime(str[3]) });
                }
            }
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < column; j++)
                {
                    int count = 0;
                    for (int t = 0; t < users.Count; t++)
                    {
                        if (users[t].x < widthh[j] && users[t].y < heightt[i] && users[t].time >= ot && users[t].time <= doo && users[i].day == StartWimdows.Search)
                        {
                            MessageBox.Show("Я зашел");
                            count++;
                            users.RemoveAt(t);
                        }

                    }

                    // MessageBox.Show(count.ToString()+"    "+MaxValue.ToString());
                    if (count < (MaxValues / 2))
                    {
                        Rectangle myRect = new System.Windows.Shapes.Rectangle();
                        Teplo.Children.Add(myRect);
                        myRect.Fill = System.Windows.Media.Brushes.Green;
                        Grid.SetColumn(myRect, j);
                        Grid.SetRow(myRect, i);
                    }
                    if (count > (MaxValues / 2))
                    {
                        Rectangle myRect = new System.Windows.Shapes.Rectangle();
                        Teplo.Children.Add(myRect);
                        myRect.Fill = System.Windows.Media.Brushes.Red;
                        Grid.SetColumn(myRect, j);
                        Grid.SetRow(myRect, i);

                    }
                    if (count == (MaxValues / 2))
                    {
                        Rectangle myRect = new System.Windows.Shapes.Rectangle();
                        Teplo.Children.Add(myRect);
                        myRect.Fill = System.Windows.Media.Brushes.Orange;
                        Grid.SetColumn(myRect, j);
                        Grid.SetRow(myRect, i);
                    }

                }
            }

        }
        public void razmetka()
        {
            double width = SystemParameters.PrimaryScreenWidth / column;
            double height = SystemParameters.PrimaryScreenHeight / row;
            for (int i = 0; i < column; i++)
            {
                widthh[i] = width * (i + 1);
            }
            for (int i = 0; i < row; i++)
            {
                heightt[i] = height * (i + 1);
            }
            Teplo.Children.Clear();
            RowDefinition[] rows = new RowDefinition[row];
            ColumnDefinition[] columns = new ColumnDefinition[column];
            for (int i = 0; i < column; i++)
            {
                columns[i] = new ColumnDefinition();
                Teplo.ColumnDefinitions.Add(columns[i]);
                columns[i].Width = new GridLength(width);

            }
            for (int i = 0; i < row; i++)
            {
                rows[i] = new RowDefinition();
                Teplo.RowDefinitions.Add(rows[i]);
                rows[i].Height = new GridLength(height);
            }

        }
    }
}
