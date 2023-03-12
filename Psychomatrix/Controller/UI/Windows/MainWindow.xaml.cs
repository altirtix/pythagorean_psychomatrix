using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Psychomatrix.Controller.UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static double[] dataX;
        public static double[] dataY;
        public static DataTable dt;

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        public static DataTable ListToDataTable(List<List<String>> values)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < values.Count; i++)
            {
                dt.Columns.Add(Convert.ToString(i + 1));
            }

            for (var i = 0; i < values[0].Count; ++i)
            {
                DataRow row = dt.NewRow();
                for (var j = 0; j < values.Count; ++j)
                {
                    row[j] = values[j][i];
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static List<double[]> ListToArray(DataTable dt)
        {
            List<double[]> result = new List<double[]>();
            for (int i = 0; i < 13; i++)
            {
                string[] tempS = string.Join(",", dt.Rows[i].ItemArray).Split(',').ToArray();
                double[] tempD = Array.ConvertAll(tempS, Double.Parse);
                result.Add(tempD);
            }
            return result;
        }

        private void CalculateDay(object sender, RoutedEventArgs e)
        {
            try
            {
                Psychomatrix.Model.Psychomatrix Psychomatrix = new Psychomatrix.Model.Psychomatrix(Convert.ToDateTime(DateDatePicker.SelectedDate));
                Psychomatrix.Calculate();

                LogTextBox.Text = Psychomatrix.ToString();

                List<TextBox> textBoxes1 = new List<TextBox> { TextBox0,
                    TextBox1, TextBox2, TextBox3,
                    TextBox4,TextBox5, TextBox6,
                    TextBox7, TextBox8, TextBox9,
                    TextBox10,TextBox11,TextBox12};
                List<TextBox> textBoxes2 = new List<TextBox> {
                    TextBox0S, TextBox1S, TextBox2S, TextBox3S };

                foreach (TextBox tb in textBoxes1)
                {
                    tb.Text = String.Empty;
                    tb.Background = Brushes.White;
                }

                foreach (TextBox tb in textBoxes2)
                {
                    tb.Text = String.Empty;
                    tb.Background = Brushes.White;
                }

                for (int i = 0; i < 13; i++)
                {
                    string firstPart = String.Empty;
                    string secondPart = String.Empty;

                    if (Psychomatrix.GetMatrix(Psychomatrix.GetFirstList())[i] != String.Empty)
                    {
                        firstPart = Psychomatrix.GetMatrix(Psychomatrix.GetFirstList())[i];
                    }
                    else
                    {
                        firstPart = "-";
                    }

                    if (Psychomatrix.GetMatrix(Psychomatrix.GetSecondList())[i] != String.Empty)
                    {
                        secondPart = "(" + Psychomatrix.GetMatrix(Psychomatrix.GetSecondList())[i] + ")";
                    }
                    else
                    {
                        secondPart = String.Empty;
                    }

                    textBoxes1[i].Text = firstPart + secondPart;
                }

                for (int i = 0; i < 4; i++)
                {
                    string firstPart = String.Empty;
                    string secondPart = String.Empty;

                    firstPart = Psychomatrix.GetSumMatrix(Psychomatrix.GetMatrix(Psychomatrix.GetFirstList()))[i];
                    secondPart = "(" + Psychomatrix.GetSumMatrix(Psychomatrix.GetMatrix(Psychomatrix.GetSecondList()))[i] + ")";

                    textBoxes2[i].Text = firstPart + secondPart;
                }

                for (int i = 1; i < 13; i++)
                {
                    if (Psychomatrix.GetColor(Psychomatrix.GetMatrix(Psychomatrix.GetFirstList()))[i] == "Green")
                    {
                        textBoxes1[i].Background = Brushes.Green;
                    }
                    else if (Psychomatrix.GetColor(Psychomatrix.GetMatrix(Psychomatrix.GetFirstList()))[i] == "Red")
                    {
                        textBoxes1[i].Background = Brushes.Red;
                    }
                    else if (Psychomatrix.GetColor(Psychomatrix.GetMatrix(Psychomatrix.GetFirstList()))[i] == "Yellow")
                    {
                        textBoxes1[i].Background = Brushes.Yellow;
                    }
                }

                foreach (string str in Psychomatrix.GetDesc(Psychomatrix.GetMatrix(Psychomatrix.GetFirstList())))
                {
                    DescTextBox.Text += str;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong!" + "\r\n" + ex.ToString(),
                    "Message");
            }
        }

        private void CalculateMonth(object sender, RoutedEventArgs e)
        {
            try
            {
                dataX = null;
                dataY = null;
                dt = null;

                WpfPlot.plt.Clear();

                DateTime date = Convert.ToDateTime(MonthDatePicker.SelectedDate);
                List<List<String>> values = new List<List<String>>();

                for (int i = 1; i <= DateTime.DaysInMonth(date.Year, date.Month); i++)
                {
                    Psychomatrix.Model.Psychomatrix Psychomatrix = new Psychomatrix.Model.Psychomatrix(Convert.ToDateTime($"{date.Month}/{i}/{ date.Year }"));
                    Psychomatrix.Calculate();
                    values.Add(Psychomatrix.GetSumCellMatrix(Psychomatrix.GetMatrix(Psychomatrix.GetFirstList())));
                }

                dt = ListToDataTable(values);
                MonthDataGrid.ItemsSource = dt.DefaultView;
                MonthDataGrid.RowHeaderWidth = 20;

                dataX = new double[DateTime.DaysInMonth(date.Year, date.Month)];
                dataY = new double[13];

                int index = 1;
                for (int i = 0; i < DateTime.DaysInMonth(date.Year, date.Month); i++)
                {
                    dataX[i] = index++;
                }

                for (int i = 0; i < 13; i++)
                {
                    dataY[i] = i;
                }

                WpfPlot.plt.Title("Dynamics of parameter changes");
                WpfPlot.plt.YLabel("Numbers");
                WpfPlot.plt.XLabel("Days");

                Random rand = new Random(0);
                int pointCount = DateTime.DaysInMonth(date.Year, date.Month);
                int lineCount = 13;
                int label = 0;

                for (int i = 0; i < lineCount; i++)
                    WpfPlot.plt.PlotSignal(ListToArray(dt)[i], label: Convert.ToString(label++));

                WpfPlot.plt.Legend();

                WpfPlot.Render();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong!" + "\r\n" + ex.ToString(),
                    "Message");
            }
        }

        private void ChangeGraphic(object sender, RoutedEventArgs e)
        {
            try
            {
                WpfPlot.plt.Clear();

                int label = Convert.ToInt16(ParamComboBox.SelectedIndex);

                WpfPlot.plt.PlotSignal(ListToArray(dt)[ParamComboBox.SelectedIndex], label: Convert.ToString(label+1));

                WpfPlot.plt.Legend();

                WpfPlot.Render();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong!" + "\r\n" + ex.ToString(),
                    "Message");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            DateMenuItem.Header = Controller.UI.Navbar.Info.GetDate();
            OSMenuItem.Header = Controller.UI.Navbar.Info.GetOS();
            LocationMenuItem.Header = Controller.UI.Navbar.Info.GetLocation();
            WANIPMenuItem.Header = Controller.UI.Navbar.Info.GetWANIP();
            LANIPMenuItem.Header = Controller.UI.Navbar.Info.GetLANIP();

            for (int i = 1; i < 13; i++)
            {
                ParamComboBox.Items.Add(i);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeMenuItem.Header = Controller.UI.Navbar.Info.GetTime();
            StopwatchMenuItem.Header = Controller.UI.Navbar.Info.GetStopwatch();
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Controller.UI.Navbar.File.OpenFile())
            {
                StreamReader sr = new StreamReader(Controller.UI.Navbar.File.FilePath);
                string line = sr.ReadLine();
                DateDatePicker.Text = line;
                sr.Close();
            }
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Controller.UI.Navbar.File.SaveFile()) 
            {
                StreamWriter sw = new StreamWriter(Controller.UI.Navbar.File.FilePath);
                sw.WriteLine(DateDatePicker.Text);
                sw.Close();
            }
        }

        private void UnblockMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Controller.UI.Navbar.Edit.Unblock(this);
        }

        private void BlockMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Controller.UI.Navbar.Edit.Block(this);
        }

        private void ClearMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Controller.UI.Navbar.Edit.Clear(this);
        }

        private void RestartMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Controller.UI.Navbar.Tools.Restart();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Controller.UI.Navbar.Tools.Exit();
        }

        private void AuthorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, Controller.UI.Navbar.Help.Author(), "Message");
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, Controller.UI.Navbar.Help.About(), "Message");
        }
    }
}
