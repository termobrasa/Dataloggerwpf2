using OxyPlot;
using OxyPlot.Axes;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Datalogger.Views
{
    /// <summary>
    /// Interaction logic for GraficoV.xaml
    /// </summary>
    public partial class GraficoV : UserControl
    {
        public static List<string> lastrow = new List<string>();
        public IList<DataPoint> Points1 { get; private set; }
        public IList<DataPoint> Points2 { get; private set; }
        public IList<DataPoint> Points3 { get; private set; }
        public IList<DataPoint> Points4 { get; private set; }
        public IList<DataPoint> Points5 { get; private set; }
        public IList<DataPoint> Points6 { get; private set; }
        public IList<DataPoint> Points7 { get; private set; }
        public IList<DataPoint> Points8 { get; private set; }
        public IList<DataPoint> Points9 { get; private set; }
        public IList<DataPoint> Points10 { get; private set; }
        public IList<DataPoint> Points11 { get; private set; }
        public IList<DataPoint> Points12 { get; private set; }
        public IList<DataPoint> Points13 { get; private set; }
        public IList<DataPoint> Points14 { get; private set; }
        public IList<DataPoint> Points15 { get; private set; }
        public IList<DataPoint> Points16 { get; private set; }


        public GraficoV()
        {
            InitializeComponent();
            Title = NovoTesteV.Nometest;         

            NovoTesteV.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            Points1 = new List<DataPoint> { };
            Points2 = new List<DataPoint> { };
            Points3 = new List<DataPoint> { };
            Points4 = new List<DataPoint> { };
            Points5 = new List<DataPoint> { };
            Points6 = new List<DataPoint> { };
            Points7 = new List<DataPoint> { };
            Points8 = new List<DataPoint> { };
            Points9 = new List<DataPoint> { };
            Points10 = new List<DataPoint> { };
            Points11 = new List<DataPoint> { };
            Points12 = new List<DataPoint> { };
            Points13 = new List<DataPoint> { };
            Points14 = new List<DataPoint> { };
            Points15 = new List<DataPoint> { };
            Points16 = new List<DataPoint> { };
            oxyPlot.LegendPlacement = LegendPlacement.Outside;
            oxyPlot.LegendPosition = LegendPosition.BottomLeft;
            oxyPlot.LegendOrientation = LegendOrientation.Horizontal;

            DataContext = this;
        }

        public string Title { get; private set; }



        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string req = "SELECT TOP 1 * FROM " + NovoTesteV.Nometest + " ORDER BY Date DESC";
            Database.Database.chart_update(req);
            if (lastrow.Any() == true)
            {

               Points1.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[1])));
                Points2.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[2])));
                Points3.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[3])));
                Points4.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[4])));
                Points5.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[5])));
                Points6.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[6])));
                Points7.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[7])));
                Points8.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[8])));
                Points9.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[9])));
                Points10.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[10])));
                Points11.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[11])));
                Points12.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[12])));
                Points13.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[13])));
                Points14.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[14])));
                Points15.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[15])));
                Points16.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Parse(lastrow[0])), Double.Parse(lastrow[16])));

                oxyPlot.InvalidatePlot(true);
                lastrow.Clear();
                if (NovoTesteV.readytosave == true) Saveimg();
            }
        }

        private void CheckBox1(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch1.IsChecked == true)
            {
                ln1.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln1.Visibility = System.Windows.Visibility.Hidden;
            }
        }


        private void CheckBox2(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch2.IsChecked == true)
            {
                ln2.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln2.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox3(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch3.IsChecked == true)
            {
                ln3.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln3.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox4(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch4.IsChecked == true)
            {
                ln4.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln4.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox5(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch5.IsChecked == true)
            {
                ln5.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln5.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox6(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch6.IsChecked == true)
            {
                ln6.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln6.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox7(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch7.IsChecked == true)
            {
                ln7.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln7.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox8(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch8.IsChecked == true)
            {
                ln8.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln8.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox9(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch9.IsChecked == true)
            {
                ln9.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln9.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox10(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch10.IsChecked == true)
            {
                ln10.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln10.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox11(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch11.IsChecked == true)
            {
                ln11.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln11.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox12(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch12.IsChecked == true)
            {
                ln12.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln12.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox13(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch13.IsChecked == true)
            {
                ln13.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln13.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void CheckBox14(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch14.IsChecked == true)
            {
                ln14.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln14.Visibility = System.Windows.Visibility.Hidden;
            }

        }
        private void CheckBox15(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch15.IsChecked == true)
            {
                ln15.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln15.Visibility = System.Windows.Visibility.Hidden;
            }

        }
        private void CheckBox16(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ch16.IsChecked == true)
            {
                ln16.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ln16.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void Saveimg()
        {
            string dir = NovoTesteV.path + "\\Testes\\" + NovoTesteV.Nometest;
            Directory.CreateDirectory(dir+ "\\imagens");

            
            ln3.Visibility = System.Windows.Visibility.Hidden;
            ln4.Visibility = System.Windows.Visibility.Hidden;
            ln5.Visibility = System.Windows.Visibility.Hidden;
            ln6.Visibility = System.Windows.Visibility.Hidden;
            ln7.Visibility = System.Windows.Visibility.Hidden;
            ln8.Visibility = System.Windows.Visibility.Hidden;
            ln9.Visibility = System.Windows.Visibility.Hidden;
            ln10.Visibility = System.Windows.Visibility.Hidden;
            ln11.Visibility = System.Windows.Visibility.Hidden;
            ln12.Visibility = System.Windows.Visibility.Hidden;
            ln13.Visibility = System.Windows.Visibility.Hidden;
            ln14.Visibility = System.Windows.Visibility.Hidden;
            ln15.Visibility = System.Windows.Visibility.Hidden;
            ln16.Visibility = System.Windows.Visibility.Hidden;
            ln1.Visibility = System.Windows.Visibility.Visible;
            ln2.Visibility = System.Windows.Visibility.Visible;

            oxyPlot.SaveBitmap(dir + "\\imagens\\Temperatura da Água.bmp", 960, 540, OxyColor.FromRgb(255, 255, 255));
            ln1.Visibility = System.Windows.Visibility.Hidden;
            ln2.Visibility = System.Windows.Visibility.Hidden;
            ln3.Visibility = System.Windows.Visibility.Visible;
            ln4.Visibility = System.Windows.Visibility.Visible;
            oxyPlot.SaveBitmap(dir + "\\imagens\\Temperatura Permutador.bmp", 960, 540, OxyColor.FromRgb(255, 255, 255));
            ln3.Visibility = System.Windows.Visibility.Hidden;
            ln4.Visibility = System.Windows.Visibility.Hidden;
            ln5.Visibility = System.Windows.Visibility.Visible;
            ln6.Visibility = System.Windows.Visibility.Visible;
            oxyPlot.SaveBitmap(dir + "\\imagens\\Temperatura Valvula.bmp", 960, 540, OxyColor.FromRgb(255, 255, 255));
            ln5.Visibility = System.Windows.Visibility.Hidden;
            ln6.Visibility = System.Windows.Visibility.Hidden;
            ln7.Visibility = System.Windows.Visibility.Visible;            
            oxyPlot.SaveBitmap(dir + "\\imagens\\Temperatura compressor.bmp", 960, 540, OxyColor.FromRgb(255, 255, 255));
            ln7.Visibility = System.Windows.Visibility.Hidden;
            ln8.Visibility = System.Windows.Visibility.Visible;
            ln9.Visibility = System.Windows.Visibility.Visible;
            oxyPlot.SaveBitmap(dir + "\\imagens\\Temperatura Ar.bmp", 960, 540, OxyColor.FromRgb(255, 255, 255));
            MessageBox.Show("Guardado com sucesso");
            NovoTesteV.readytosave = false;

        }
    }
}


