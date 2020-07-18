using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Word = Microsoft.Office.Interop.Word;


namespace ScheduleModifierApp
{
    class DocumentReader
    {
        public static _Word.Application wordApp = new _Word.Application();
        public static object oMissing = System.Reflection.Missing.Value;
        public static object oVisible = false;
        public static object fileName = @"C:\Users\simas\OneDrive\Documents\Grafikas_Rugpjucio.docx";
        public static _Word.Document doc = wordApp.Documents.Open(ref fileName, ref oMissing, ref oMissing, ref oMissing,
                                                                  ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                                  ref oMissing, ref oMissing, ref oMissing, ref oVisible);
        public List<string> getEmployeeList()
        {
            _Word.Table table1 = doc.Tables[1];
            var employeesList = new List<string>();
            for (int i = 2; i < table1.Rows.Count + 1; i++)
            {
                employeesList.Add(table1.Cell(i, 2).Range.Text + " " + table1.Cell(i, 3).Range.Text);
            }
            return employeesList;
        }
    }
}
