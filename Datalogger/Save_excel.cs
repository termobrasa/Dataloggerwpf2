using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalogger.Views;

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

            Worksheet sheet2 = book.Worksheets[1];
            sheet2.Name = "Dados";
            sheet2.Activate();
            book.Worksheets[2].Remove();
            sheet2.InsertDataTable(t2, true, 1, 1);



            book.SaveToFile(c, ExcelVersion.Version97to2003);
            System.Diagnostics.Process.Start(book.FileName);
        }

    }

   
}
