using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Interaction logic for Teste24hV.xaml
    /// </summary>
    public partial class Teste24hV : UserControl
    {
        public Teste24hV()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            string q2 = "select * from  lista_Testes";
            DataSet ds = Database.Database.FillTable(q2);
            datagrid1.ItemsSource = ds.Tables[0].DefaultView;



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DataGridCellInfo cellInfo = datagrid1.SelectedCells[3];
            DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
            FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
            BindingOperations.SetBinding(element, TagProperty, column.Binding);
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = NovoTesteV.path + "\\Testes\\" + element.Tag.ToString();
            process.Start();


        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Comparacao_testes win2 = new Comparacao_testes();
            win2.Show();


        }
    }
}