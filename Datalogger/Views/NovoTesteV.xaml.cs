using Spire.Xls;
using System;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;


namespace Datalogger.Views
{
    /// <summary>
    /// Interaction logic for NovoTesteV.xaml
    /// </summary>
    public partial class NovoTesteV : System.Windows.Controls.UserControl
    {
        public static System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string Nometest;
        public static string N_test;
        public static Boolean Teste_a_decorrer = false;
        public static Boolean readytosave = false;
        public static string tap_test_m;
        public static string nomerelatorio;
        public static string nome_manual;
        public static string nome_tiragens;
        public NovoTesteV()
        {
            InitializeComponent();
            Serial_port_data.Datacomplete = false;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            MainWindow.serial.Write("A");
           
                update_table();
                                 

        }

        private void Novoteste_btn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tempo_amos_txt.Text) == false && String.IsNullOrEmpty(novotexte_txt.Text) == false && MainWindow.serial.IsOpen==true)
            {
               
                dispatcherTimer.Interval = new TimeSpan(0, 0, int.Parse(tempo_amos_txt.Text));
                dispatcherTimer.Start();
                
                Nometest = "["+novotexte_txt.Text+"]";
                nome_tiragens = "[" + novotexte_txt.Text + "_tiragens]";
                N_test = N_teste.Text;
                label1.Content = novotexte_txt.Text;

                novotexte_txt.IsEnabled = false;
                N_teste.IsEnabled = false;
                Novoteste_btn.IsEnabled = false;
                Teste_a_decorrer = true;
                //cria tabela para leitura dos sensores todos 
                string q = "SELECT Nome From lista_sensores";
                Database.Database.createtable(q);
                string q1 = "CREATE TABLE [dbo]."+Nometest+" ([Id]  INT IDENTITY (1, 1) NOT NULL, Date varchar(50), [" + Database.Database.id[0] + "] float, [" + Database.Database.id[1] + "] float," +
                     " [" + Database.Database.id[2] + "] float, [" + Database.Database.id[3] + "] float, [" + Database.Database.id[4] + "] float," +
                     " [" + Database.Database.id[5] + "] float, [" + Database.Database.id[6] + "] float, [" + Database.Database.id[7] + "] float, " +
                     " [" + Database.Database.id[8] + "] float, [" + Database.Database.id[9] + "] float, [" + Database.Database.id[10] + "] float, " +
                     " [" + Database.Database.id[11] + "] float,[" + Database.Database.id[12] + "] float, [" + Database.Database.id[13] + "] float," +
                     " [" + Database.Database.id[14] + "] float , Flow float)";

                Database.Database.Excute(q1);
                string q2 = "select * from " + Nometest + "";
                DataSet ds = Database.Database.FillTable(q2);
                datagrid1.ItemsSource = ds.Tables[0].DefaultView;

                // cria tabela para inserir dados mauais
                nome_manual ="["+ novotexte_txt.Text + "_manual]";
                string q3 = "CREATE TABLE " + nome_manual + "(Date varchar(50), [Temperatura cima] float , [Temperatura baixo] float, [Temperatura amb] float" +
                    ", [Pressao baixa] float, [Pressao alta] float, [Consumo] float, [observacoes] varchar(MAX))";
                Database.Database.Excute(q3);
                               
              
                                              
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("-Verifique a se esta ligado \n -verifique se inseriu numero, nome e taxa de amostragem", "Erro na criaçao de novo teste",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            

        }




        private void tempo_amos_txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void novotexte_txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^a-zA-Z0-9_-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
       
        
        public void update_table()
        {
            if (Serial_port_data.Datacomplete == true)
            {

              


                 string q1 = "INSERT into " + Nometest + " (Date,["+ Database.Database.id[0] + "],[" + Database.Database.id[1] + "],[" + Database.Database.id[2] + "],[" + Database.Database.id[3] + "],[" + Database.Database.id[4] + "],[" + Database.Database.id[5] + "]," +
                      "[" + Database.Database.id[6] + "],[" + Database.Database.id[7] + "],[" + Database.Database.id[8] + "],[" + Database.Database.id[9] + "]," +
                      "[" + Database.Database.id[10] + "],[" + Database.Database.id[11] + "],[" + Database.Database.id[12] + "],[" + Database.Database.id[13] + "]," +
                      "[" + Database.Database.id[14] + "],["+ Database.Database.id[15] + "]) " +
                      "values('" + DateTime.Now + "'," + Serial_port_data.tempdata[1] + "," + "" + Serial_port_data.tempdata[2] + "," +
                      "" + Serial_port_data.tempdata[3] + "," + Serial_port_data.tempdata[4] + "," + Serial_port_data.tempdata[5] + "," + "" + Serial_port_data.tempdata[6] + "," +
                      "" + Serial_port_data.tempdata[7] + "," + Serial_port_data.tempdata[8] + "," + Serial_port_data.tempdata[9] + "," + "" + Serial_port_data.tempdata[10] + "," +
                      "" + Serial_port_data.tempdata[11] + "," + Serial_port_data.tempdata[12] + "," + Serial_port_data.tempdata[13] + "," + "" + Serial_port_data.tempdata[14] + "," + Serial_port_data.tempdata[15] + "," + Serial_port_data.tempdata[16] + ")";
                      
               

                string q2 = "select * from " + Nometest + "";
                Database.Database.Excute(q1);
                DataSet ds = Database.Database.FillTable(q2);
                datagrid1.ItemsSource = ds.Tables[0].DefaultView;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(Teste_a_decorrer==true)
            Save_excel.excel();
            readytosave = true;


        }
               

       

        
    }
}
