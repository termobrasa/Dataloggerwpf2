using System;
using System.Collections.Generic;
using System.Data;
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
        public static string tablename;
        public static bool teste24_Ready_to_save = false;

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
                while (Serial_port_data.t24hready == false) ;
               
                string q1 = "insert into "+ NovoTesteV.nome_tiragens + " (Date,Estado,Valvula,[Temperatura cima],[Temperatura baixo]) values('" + DateTime.Now.ToString() + "', 'on' , '" + dados[3] + "','" + Serial_port_data.Temp_cima24h + "', '" + Serial_port_data.Temp_baixo24h + "')";
                Database.Database.Excute(q1);
                string q2 = "select * from " +  NovoTesteV.nome_tiragens + "";
                
                DataSet ds = Database.Database.FillTable(q2);
                datagrid1.ItemsSource = ds.Tables[0].DefaultView;

            }

        }

        private void timer24hoff_Tick(object sender, EventArgs e)
        {            
            string aux = "val" + dados[3] + "off";            
            MainWindow.serial.Write(aux);
            timer24hoff.Stop();
            while (Serial_port_data.t24hready == false) ;

            string q1 = "insert into " +  NovoTesteV.nome_tiragens  + " (Date,Estado,Valvula,[Temperatura cima],[Temperatura baixo]) values('" + DateTime.Now.ToString() + "', 'off' , '" + dados[3] + "','" + Serial_port_data.Temp_cima24h + "', '" + Serial_port_data.Temp_baixo24h + "')";
            Database.Database.Excute(q1);

            string q2 = "select * from " +  NovoTesteV.nome_tiragens  + "";
            
            DataSet ds = Database.Database.FillTable(q2);
            datagrid1.ItemsSource = ds.Tables[0].DefaultView;

            dados.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.serial.IsOpen == true && NovoTesteV.Teste_a_decorrer==true)
            {
                timer24hon.Start();
               
                string q1 = "CREATE TABLE " + NovoTesteV.nome_tiragens + "(Date varchar(50), [Estado] varchar(50) , [Valvula] varchar(50), [Temperatura cima] float" +
                    ", [Temperatura baixo] float)";
                Database.Database.Excute(q1);
                teste24_Ready_to_save = true;
            }
            
            else
                System.Windows.Forms.MessageBox.Show("-Verifique a se esta ligado \n-Verifique se inicio o teste no menu novo teste, ", "Erro na criaçao de novo teste",
   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        
    }
}
