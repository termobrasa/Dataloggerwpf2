using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace Datalogger.Views
{
    /// <summary>
    /// Interaction logic for ListaV.xaml
    /// </summary>
    public partial class ListaV : UserControl
    {
       public static System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();


        public ListaV()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (MainWindow.serial.IsOpen == true)
            {
                MainWindow.serial.Write("T");
                string q1 = "update lista_sensores set Endereço='" + Serial_port_data.Address + "' , Data= '" + DateTime.Now.ToString() + "', Temperatura='" + Serial_port_data.Temp + "' where ID ='" + Serial_port_data.Idsensore + "'";
               
                string q2 = "select * from lista_Sensores";
                Database.Database.Excute(q1);
                DataSet ds = Database.Database.FillTable(q2);
                datagrid1.ItemsSource = ds.Tables[0].DefaultView;
            }


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {


            string query = "select * from lista_sensores";
            DataSet ds = Database.Database.FillTable(query);
            datagrid1.ItemsSource = ds.Tables[0].DefaultView;

        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            string q1 = "insert into lista_sensores (ID,Nome) values('" + int.Parse(Idtxt.Text) + "','" + nametxt.Text + "')";
            string q2 = "select * from Lista_Sensores";
            Database.Database.Excute(q1);
            DataSet ds = Database.Database.FillTable(q2);
            datagrid1.ItemsSource = ds.Tables[0].DefaultView;

        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            string q1 = "update Lista_sensores set Nome='" + nametxt.Text + "' where ID='" + Idtxt.Text + "'";
            string q2 = "select * from lista_Sensores";
            Database.Database.Excute(q1);
            DataSet ds = Database.Database.FillTable(q2);
            datagrid1.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void upd_btn_Click(object sender, RoutedEventArgs e)
        {
            string q1 = "delete Lista_sensores where ID ='" + Idtxt.Text + "'";
            string q2 = "select * from Lista_Sensores";
            Database.Database.Excute(q1);
            DataSet ds = Database.Database.FillTable(q2);
            datagrid1.ItemsSource = ds.Tables[0].DefaultView;
        }
    }
}
