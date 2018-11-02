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

namespace Datalogger.Views
{
    /// <summary>
    /// Interaction logic for Teste_24h.xaml
    /// </summary>
    public partial class Teste_24h : UserControl
    {
        List<string> dados = new List<string>();
        public static System.Windows.Threading.DispatcherTimer timer24hon = new System.Windows.Threading.DispatcherTimer();
        public static System.Windows.Threading.DispatcherTimer timer24hoff = new System.Windows.Threading.DispatcherTimer();
        public int i = 0;


        public Teste_24h()
        {
            InitializeComponent();
            timer24hon.Tick += new EventHandler(timer24hon_Tick);
            timer24hoff.Tick += new EventHandler(timer24hoff_Tick);

        }
       

        private void timer24hon_Tick(object sender, EventArgs e)
        {
            i++;
            string req = "select * from CicloM WHERE ID = "+i+""; 
            dados = Database.Database.teste24(req);
            timer24hon.Interval = new TimeSpan(0, 0, int.Parse(dados[1]));

            if (int.Parse(dados[2]) != 0)
            {
                timer24hoff.Interval = new TimeSpan(0, 0, int.Parse(dados[2]));                
                string aux = "val" + dados[3] + "on";               
                MainWindow.serial.Write(aux);
                timer24hoff.Start();
                var data = new Test { Date = DateTime.Now.ToString(), Estado = "on" , Valvula=dados[3] };
                datagrid1.Items.Add(data);
            }

        }

        private void timer24hoff_Tick(object sender, EventArgs e)
        {            
            string aux = "val" + dados[3] + "off";            
            MainWindow.serial.Write(aux);
            timer24hoff.Stop();


            var data = new Test { Date = DateTime.Now.ToString(), Estado = "off" , Valvula = dados[3] };
            datagrid1.Items.Add(data);

            dados.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            timer24hon.Start();
        }

        public class Test
        {
            public string Date { get; set; }
            public string Valvula { get; set; }
            public string Estado { get; set; }
        }
    }
}
