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
        public int duracaomin;
        public int duracaohora;
        public double tempi;
        public double tempf;
        public double aquec_h;
        private bool falta_dados;

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
                cop();                
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

                temp_aque_txt.Text = (duracaohora.ToString() + "," + duracaomin.ToString()) + "h";
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
                string aque_hora = ((tempf - tempi) / aquec_h).ToString();
                aque_bloc.Text = aque_hora + "ºC";
                falta_dados = false;

            }
            else falta_dados = true;
        }

       

        private void cop()
        {

            if (falta_dados == false && string.IsNullOrEmpty(volume_txt.Text) ==false && string.IsNullOrEmpty(Consumo_txt.Text) ==false)
            {
                double cop = Math.Round((996 * Single.Parse(volume_txt.Text) * (tempf - tempi)) / (860 * 1000 * Single.Parse(Consumo_txt.Text)), 2);
                
                cop_bloc.Text = cop.ToString();
                consumobloc.Text = Consumo_txt.Text + "KWh";

            }
            else System.Windows.Forms.MessageBox.Show("-Verifique se insira o consumo e o volume\n- Verifique se tem dados sufecientes no menu Dados", "Falta de dados",
  System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

        }
    }
}
