using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Datalogger.Views;

namespace Datalogger.Database
{
    class Database
    {
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string databaseName = "client.mdf";
        public static SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + databaseName + ";Integrated Security=True");
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static DataTable dt;
        public static DataSet ds;
        public static SqlDataAdapter da;
        public static string[] id = new string[20];
        



        public static void OpenCnx()
        {
            if (cnx.State != ConnectionState.Open)
            {
                cnx.Open();
            }
        }

        public static void CloseCnx()
        {
            if (cnx.State != ConnectionState.Closed)
            {
                cnx.Close();
            }
        }

        public static void Excute(string req)
        {
            cmd = new SqlCommand(req, cnx);
            OpenCnx();
            cmd.ExecuteNonQuery();
            CloseCnx();
        }

        public static DataSet FillTable(string req)
        {
            OpenCnx();
            da = new SqlDataAdapter(req, cnx);
            ds = new DataSet();
            da.Fill(ds);        
            CloseCnx();
            return (ds);
        }
        public static void createtable(string req)
        {
            OpenCnx();
            da = new SqlDataAdapter(req, cnx);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                id[i]=dr["nome"].ToString();
                i++;
            }
            

        }
        public static DataTable exceltable(string req)
        {
            OpenCnx();
            da = new SqlDataAdapter(req, cnx);
            dt = new DataTable();
            da.Fill(dt);
            CloseCnx();
            return (dt);
        }
        public static void chart_update(string req)
        {
            OpenCnx();
            cmd = new SqlCommand(req, cnx);
            dr = cmd.ExecuteReader();
           while (dr.Read())               
                   
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                    GraficoV.lastrow.Add(Convert.ToString(dr.GetValue(i)));                    
                    }

            CloseCnx();
            
        }
        

        public static List<string> colmn_to_list(string req)
        {
            List<string> D_aque_i = new List<string>();

            OpenCnx();
            cmd = new SqlCommand(req, cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())


                D_aque_i.Add(dr.GetValue(0).ToString());
                

            CloseCnx(); ;

            return (D_aque_i);

        }

       






    }
}
