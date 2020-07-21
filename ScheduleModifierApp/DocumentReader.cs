using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Word = Microsoft.Office.Interop.Word;


namespace ScheduleModifierApp
{
    public class DocumentReader
    {
        public static _Word.Application wordApp = new _Word.Application();
        public static object oMissing = System.Reflection.Missing.Value;
        public static object oVisible = false;
        public static object fileName = @"C:\Users\simas\OneDrive\Documents\Grafikas_Rugpjucio_Test.docx";
        public static _Word.Document doc = wordApp.Documents.Open(ref fileName, ref oMissing, ref oMissing, ref oMissing,
                                                                  ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                                  ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        public static _Word.Table table1 = doc.Tables[1];
        public static _Word.Table table2 = doc.Tables[2];

        public List<Employee> getDataFromDoc()
        {
            var dataList = new List<Employee>();
            var employeesList = getEmployeesList();
            var i = 0;
            foreach (var name in employeesList)
            {
                var employeeSchedule = getEmployeeSchedule(i);
                dataList.Add(new Employee() { NameAndPosition = name, Hours = employeeSchedule });
                i++;
            }
            doc.Close(_Word.WdSaveOptions.wdDoNotSaveChanges);
            return dataList;
        }
        public List<string> getEmployeesList()
        {
            var employeesList = new List<string>();
            string name;
            string position;
            for (int i = 2; i < table1.Rows.Count + 1; i++)
            {
                name = table1.Cell(i, 2).Range.Text;
                position = table1.Cell(i, 3).Range.Text;
                employeesList.Add(name.Remove(name.Length - 2) + "   " + position.Remove(position.Length - 2));
            }
            return employeesList;
        }

        public List<string> getEmployeeSchedule(int employeeId)
        {
            var employeeSchedule = new List<string>();
            //gets a string type value of the day from the last column in table2//
            var lastDay = (table2.Cell(1, table2.Columns.Count).Range.Text).Substring(0,2);
            //------------------------------------------------------------------//
            string hours;
            for (int i = 0; i < int.Parse(lastDay); i++)
            {
                if (i < 16)
                {
                    hours = table1.Cell(employeeId + 2, i + 5).Range.Text;
                }
                else
                {
                    hours = table2.Cell(employeeId + 2, i - 11).Range.Text;
                }
                employeeSchedule.Add(hours.Remove(hours.Length - 2));
            }
            return employeeSchedule;
        }
    }
}
