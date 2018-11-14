using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Datalogger
{
    class Serial_port_data
    {
        
        public static string Address { get; private set; }
        public static float Temp { get; private set; }
        public static float Tempmax { get; set; }
        public static float Tempmin { get; set; }
        public static float Resol { get; private set; }
        public static int Idsensore { get; private set; }
        public static string Temp_cima24h { get; private set; }
        public static string Temp_baixo24h { get; private set; }

        public static bool t24hready = false;
        public static bool Datacomplete = false;


        public static List<string> tempdataux = new List<string>();
        public static List<string> tempdata = new List<string>();
        

        public static void Serialr()
        {
            MainWindow.serial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {


            string indata = MainWindow.serial.ReadLine(); 
            tempdataux = indata.Split('/').ToList();
            Console.WriteLine(indata);


            if (indata[0] == 'T')
            {

                Address = tempdataux[1];
                Temp = Single.Parse(tempdataux[2], CultureInfo.InvariantCulture);
                Resol = Single.Parse(tempdataux[3], CultureInfo.InvariantCulture);
                Idsensore = int.Parse(tempdataux[4]);   
                               
            }
            if (indata[0] == 'A')
            {

                tempdataux[0] = "1";
                for (int i = 0; i < 17; i++)
                {
                    tempdata.Add("1");
                    tempdata[i] = tempdataux[i];
                                                          
                }
                
                Datacomplete = true;

            }
            if (tempdataux[0] == "t24h")
            {
                
                Temp_cima24h = tempdataux[1];
                Temp_baixo24h = tempdataux[2];
                t24hready = true;
            }



        }
    }
}
