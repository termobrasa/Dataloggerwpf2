using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using MahApps.Metro.Controls.Dialogs;


namespace Datalogger.Views
{
    /// <summary>
    /// Interaction logic for TestesV.xaml
    /// </summary>
    public partial class TestesV : UserControl
    {
        public static DataTable dt;

        public TestesV()
        {
            InitializeComponent();
                      
        }

        
        private void inserir_Click(object sender, RoutedEventArgs e)
        {

            if (NovoTesteV.Teste_a_decorrer==true && string.IsNullOrEmpty(temp_ent.Text)==false)
            {
                n_teste_txt.Text = NovoTesteV.N_test;
                nome_teste_txt.Text = NovoTesteV.Nometest;
                
                string q1 = "insert into " + NovoTesteV.nome_manual + " (Date,[Temperatura cima],[Temperatura baixo],[Temperatura amb],[Pressao baixa],[Pressao alta],Consumo,observacoes) values('" + DateTime.Now.ToString() + "','" + temp_ent.Text + "','" + Temp_sai.Text + "'" +
                    ",'" + temp_amb.Text + "','" + p_bai.Text + "','" + p_alta.Text + "','" + consumo.Text + "','" + obs.Text + "')";
                string q2 = "select * from " + NovoTesteV.nome_manual + "";
                Database.Database.Excute(q1);
                DataSet ds = Database.Database.FillTable(q2);
                Datagrid1.ItemsSource = ds.Tables[0].DefaultView;

                temp_ent.Text = null;
                Temp_sai.Text = null;
                temp_amb .Text = null;
                p_alta.Text = null;
                p_bai.Text = null;
                consumo.Text = null;
                obs.Text = null;




            }
            else
            {
                
                System.Windows.Forms.MessageBox.Show("-Verifique se iniciou o teste no menu Novo teste\n-Verifique se introduziu a temperatura de entrada de água", "Inserir dados",
    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
           

        }

       

        private void interios_txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
