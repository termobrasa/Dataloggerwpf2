using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using MahApps.Metro.Controls;
using Datalogger.Views;
using MahApps.Metro.Controls.Dialogs;

namespace Datalogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static SerialPort serial = new SerialPort();
        public MainWindow()
        {
            
            InitializeComponent();
            serial.Handshake = System.IO.Ports.Handshake.None;
            serial.BaudRate = 9600;
            serial.Parity = Parity.None;
            serial.DataBits = 8;
            serial.StopBits = StopBits.One;
            
            content1.Visibility = Visibility.Hidden;
            content2.Visibility = Visibility.Hidden;
            content3.Visibility = Visibility.Visible;
            content4.Visibility = Visibility.Hidden;
            content5.Visibility = Visibility.Hidden;
            content6.Visibility = Visibility.Hidden;
            content7.Visibility = Visibility.Hidden;

            string[] ports = SerialPort.GetPortNames();
            List<string> _items = new List<string>();

            foreach (string port in ports)
            {
                _items.Add(port);
            }

            ComboB.ItemsSource = _items;
        }


        

        private void Novoteste_btn_Click(object sender, RoutedEventArgs e)
        {
            
            content1.Visibility = Visibility.Hidden;
            content2.Visibility = Visibility.Hidden;
            content3.Visibility = Visibility.Visible;
            content4.Visibility = Visibility.Hidden;
            content5.Visibility = Visibility.Hidden;
            content6.Visibility = Visibility.Hidden;
            content7.Visibility = Visibility.Hidden;
            ListaV.dispatcherTimer.Stop();
           
        }

       
        private void Grafico_btn_Click(object sender, RoutedEventArgs e)
        {
          
            content1.Visibility = Visibility.Visible;
            content2.Visibility = Visibility.Hidden;
            content3.Visibility = Visibility.Hidden;
            content4.Visibility = Visibility.Hidden;
            content5.Visibility = Visibility.Hidden;
            content6.Visibility = Visibility.Hidden;
            content7.Visibility = Visibility.Hidden;
            ListaV.dispatcherTimer.Stop();
        }

        private void Lista_btn_Click(object sender, RoutedEventArgs e)
        {
                    
            content1.Visibility = Visibility.Hidden;
            content2.Visibility = Visibility.Hidden;
            content3.Visibility = Visibility.Hidden;
            content4.Visibility = Visibility.Hidden;
            content5.Visibility = Visibility.Visible;
            content6.Visibility = Visibility.Hidden;
            content7.Visibility = Visibility.Hidden;
            ListaV.dispatcherTimer.Start();

        }

        private void Testes_btn_Click(object sender, RoutedEventArgs e)
        {
           

            content1.Visibility = Visibility.Hidden;
            content2.Visibility = Visibility.Hidden;
            content3.Visibility = Visibility.Hidden;
            content4.Visibility = Visibility.Visible;
            content5.Visibility = Visibility.Hidden;
            content6.Visibility = Visibility.Hidden;
            content7.Visibility = Visibility.Hidden;
            ListaV.dispatcherTimer.Stop();
        }

        private void Lista_testes_Click(object sender, RoutedEventArgs e)
        {
            
            content1.Visibility = Visibility.Hidden;
            content2.Visibility = Visibility.Visible;
            content3.Visibility = Visibility.Hidden;
            content4.Visibility = Visibility.Hidden;
            content5.Visibility = Visibility.Hidden;
            content6.Visibility = Visibility.Hidden;
            content7.Visibility = Visibility.Hidden;
            ListaV.dispatcherTimer.Stop();
        }

        private void btndesl_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                    serial.Close();

                if (serial.IsOpen == false)
                {
                    label1.Content = "Desligado";
                    Circle.Fill = new SolidColorBrush(Colors.Red);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Já está desligado");
            }
        }

        private void btnlig_Click(object sender, RoutedEventArgs e)
        {
            if (serial.IsOpen == false && ComboB.SelectedIndex != -1)
            {
                serial.PortName = ComboB.SelectedItem.ToString();
                try
                {
                    Serial_port_data.Serialr();
                    serial.Open();
                    
                    if (serial.IsOpen == true)
                    {
                        Circle.Fill = new SolidColorBrush(Colors.Green);
                        label1.Content = "Ligado";
                    }

                }
                catch
                {
                    MessageBox.Show("Não foi possivel ligar, ou já esta ligado");

                }
            }
            else
            {
                MessageBox.Show("Selecione a porta");
            }
        }

        private void Relatorio_btn_Click(object sender, RoutedEventArgs e)
        {
            content1.Visibility = Visibility.Hidden;
            content2.Visibility = Visibility.Hidden;
            content3.Visibility = Visibility.Hidden;
            content4.Visibility = Visibility.Hidden;
            content5.Visibility = Visibility.Hidden;
            content6.Visibility = Visibility.Visible;
            content7.Visibility = Visibility.Hidden;
            ListaV.dispatcherTimer.Stop();
        }

        private void Teste_24h_btn_Click(object sender, RoutedEventArgs e)
        {
            content7.Visibility = Visibility.Visible;
            content1.Visibility = Visibility.Hidden;
            content2.Visibility = Visibility.Hidden;
            content3.Visibility = Visibility.Hidden;
            content4.Visibility = Visibility.Hidden;
            content5.Visibility = Visibility.Hidden;
            content6.Visibility = Visibility.Hidden;
        }
    }
}
