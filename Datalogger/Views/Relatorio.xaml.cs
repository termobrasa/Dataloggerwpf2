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
    /// Interaction logic for Relatorio.xaml
    /// </summary>
    public partial class Relatorio : UserControl
    {
        public static int duracaomin;
        public static int duracaohora;
        public double tempi;
        public double tempf;
        public static double aquec_h;
        private bool falta_dados;
        public static double cop;
        public static string Consumo;
        public static string aque_hora;
        public static string duracao;
        public Relatorio()
        {
            InitializeComponent();

        }

        private void atualiza_btn_Click(object sender, RoutedEventArgs e)
        {
            if (NovoTesteV.Teste_a_decorrer == true)
            {
                duracao_aque();
                aquecim_hora();
                cop_fun();                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("-Verifique se iniciou o teste no menu Novoteste", "Atualizar valores",
    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

           


        }

        private void duracao_aque()
        {
            List<string> aux = new List<string>() ;
            string req = " SELECT date FROM " + NovoTesteV.Nometest + "_manual ";
            aux =Database.Database.colmn_to_list(req);
            if (aux.Count > 1)
            {
                DateTime horai = DateTime.Parse(aux[0]);
                DateTime horaf = DateTime.Parse(aux[aux.Count - 1]);

                TimeSpan duration = horaf.Subtract(horai);
                duracaomin = duration.Minutes;
                duracaohora = duration.Hours;
                duracao = (duracaohora.ToString() + "." + duracaomin.ToString()) + "h";
                temp_aque_txt.Text = duracao ;
                falta_dados = false;



            

            }
            else falta_dados = true;
            

           

        }

        private void aquecim_hora()
        {
            
                List<string> aux = new List<string>();
                string req = " SELECT  [Temperatura cima] FROM " + NovoTesteV.Nometest + "_manual ";
                aux = Database.Database.colmn_to_list(req);

            if (aux.Count > 1)
            {
                tempi = Double.Parse(aux[0]);
                tempf = Double.Parse(aux[aux.Count - 1]);
                aquec_h = Math.Round(duracaohora + (duracaomin * 0.017), 2);
                aque_hora = ((tempf - tempi) / aquec_h).ToString() + "C";
                aque_bloc.Text = aque_hora ;
                falta_dados = false;

            }
            else falta_dados = true;
        }

       

        private void cop_fun()
        {

            if (falta_dados == false && string.IsNullOrEmpty(volume_txt.Text) ==false && string.IsNullOrEmpty(Consumo_txt.Text) ==false)
            {
                cop = Math.Round((996 * Single.Parse(volume_txt.Text) * (tempf - tempi)) / (860 * 1000 * Single.Parse(Consumo_txt.Text)), 2);
                
                cop_bloc.Text = cop.ToString();
                Consumo = Consumo_txt.Text + "KWh";
                consumobloc.Text = Consumo;

            }
            else System.Windows.Forms.MessageBox.Show("-Verifique se insira o consumo e o volume\n- Verifique se tem dados sufecientes no menu Dados", "Falta de dados",
  System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

        }

        private void Gravar_excel_Click(object sender, RoutedEventArgs e)
        {
            if (NovoTesteV.Teste_a_decorrer == true)
                Save_excel.excel();
            NovoTesteV.readytosave = true;

//            string q1 = "insert into Lista_Testes (Data,N_Teste,Nome_Teste,[COP],[Aquecimento por hora],[Tempo de aquecimento],[Consumo]) values('" + DateTime.Now.ToString() + "','" + NovoTesteV.N_test + "', '" + NovoTesteV.Nometest + "','" + cop.ToString() + "', '" + aque_hora + "', dfdsf, '" + Consumo + "')";
  //          Database.Database.Excute(q1);


            string q1 = "insert into Lista_Testes (Data,N_Teste,Nome_Teste,[COP],[Aquecimento por hora],[Tempo de aquecimento],[consumo]) values('" + DateTime.Now.ToString() + "','" + NovoTesteV.N_test + "', '" + NovoTesteV.Nometest + "','" + cop.ToString() + "', '" + aque_hora + "', '" + duracao + "', '" + Consumo + "')";
            Database.Database.Excute(q1);
        }
    }
}
