using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalogger.Views;
using System.Drawing;

namespace Datalogger
{
    class Save_excel
    {
        public static void excel()
        {
            string c =  NovoTesteV.path + "\\Testes\\" + NovoTesteV.Nometest + "\\" + NovoTesteV.Nometest + ".xls";
            string q1 = "select * from " +NovoTesteV.Nometest + "";
            string q2 = "select * from " + NovoTesteV.Nometest +"_manual";
            DataTable t1 = Database.Database.exceltable(q1);
            DataTable t2 = Database.Database.exceltable(q2);

            Workbook book = new Workbook();

            Worksheet sheet1 = book.Worksheets[0];
            sheet1.Name = "Teste";
            sheet1.Activate();
            sheet1.InsertDataTable(t1, true, 1, 1);
            sheet1.AllocatedRange.AutoFitColumns();

            Worksheet sheet2 = book.Worksheets[1];
            sheet2.Name = "Dados";
            sheet2.Activate();
            book.Worksheets[2].Remove();
            sheet2.InsertDataTable(t2, true, 1, 1);

            sheet2.Range["K1"].Value = "Dados:";
            sheet2.Range["K3"].Value = "COP:";
            sheet2.Range["K4"].Value = "AQUEC POR HORA:";
            sheet2.Range["K5"].Value = "DURAÇÃO DE AQUEC:";
            sheet2.Range["K6"].Value = "CONSUMO:";
            sheet2.Range["L3"].Value = Relatorio.cop.ToString();
            sheet2.Range["L4"].Value = Relatorio.aque_hora;
            sheet2.Range["L5"].Value =  Relatorio.duracaohora.ToString() +"," +Relatorio.duracaomin.ToString()+"h";
            sheet2.Range["L6"].Value =  Relatorio.Consumo;
            sheet2.AllocatedRange.AutoFitColumns();

            sheet2.Range["k1:l6"].BorderInside(LineStyleType.Thin, Color.Black);
            sheet2.Range["k1:l6"].BorderAround(LineStyleType.Medium, Color.Black);


            sheet2.Range["k1:l2"].Merge();
            sheet2.Range["k1:l2"].Style.VerticalAlignment = VerticalAlignType.Center;
            sheet2.Range["k1:l2"].Style.HorizontalAlignment = HorizontalAlignType.Center;


            book.SaveToFile(c, ExcelVersion.Version97to2003);
            System.Diagnostics.Process.Start(book.FileName);
        }

    }

   
}
