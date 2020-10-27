using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Word = Microsoft.Office.Interop.Word;


namespace ScheduleModifierApp
{
    public class DocumentHandler
    {
        public static _Word.Application wordApp;
        public static object oMissing = System.Reflection.Missing.Value;
        public static object oVisible = false;
        public static _Word.Document doc;
        public static _Word.Table table1;
        public static _Word.Table table2;

        /// <summary>
        /// Opens word document
        /// </summary>
        /// <param name="fileName">File path of a selected word document</param>
        public void openDoc(object fileName)
        {
            wordApp = new _Word.Application();
            doc = wordApp.Documents.Open(ref fileName, ref oMissing, ref oMissing, ref oMissing,
                                         ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                         ref oMissing, ref oMissing, ref oMissing, ref oVisible);
            table1 = doc.Tables[1];
            table2 = doc.Tables[2];
        }
        
        /// <summary>
        /// Gets all data from the word document
        /// </summary>
        /// <returns>A list of all employees and their working hours</returns>
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
            return dataList;
        }

        /// <summary>
        /// Gets a list of employees from word document
        /// </summary>
        /// <returns>A list of employees</returns>
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

        /// <summary>
        /// Gets a list of selected employee working hours 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>A list of working hours</returns>
        public List<string> getEmployeeSchedule(int employeeId)
        {
            var employeeSchedule = new List<string>();
            var lastDay = (table2.Cell(1, table2.Columns.Count).Range.Text).Substring(0,2);
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

        /// <summary>
        /// Applies the changes from modifiedData list to the word doucument
        /// </summary>
        /// <param name="modifiedData">List of changes</param>
        public void saveToDoc(List<ModifiedData> modifiedData)
        {
            foreach (var item in modifiedData)
            {
                if (item.Day < 17)
                {
                    table1.Cell(item.EmployeeId + 2, item.Day + 4).Range.Text = item.Value;
                }
                else
                {
                    table2.Cell(item.EmployeeId + 2, item.Day - 12).Range.Text = item.Value;
                }
            }
        }

        /// <summary>
        /// Closes word document
        /// </summary>
        /// <param name="save">Saves the document when set to true</param>
        public void closeDoc(bool save)
        {
            if (save)
            {
                doc.Close(_Word.WdSaveOptions.wdSaveChanges);
            }
            else
            {
                doc.Close(_Word.WdSaveOptions.wdDoNotSaveChanges);
            }
            wordApp.Quit();
        }

        /// <summary>
        /// Gets the weekday with which the month starts
        /// </summary>
        /// <returns>Zero based weekday starting from Monday</returns>
        public int firstWeekDayOfMonth()
        {
            _Word.Paragraph paragraph2 = doc.Paragraphs[2];
            _Word.Paragraph paragraph3 = doc.Paragraphs[3];
            string text2 = paragraph2.Range.Text;
            string text3 = paragraph3.Range.Text;
            int month = int.Parse(text2.Substring(23, 2));
            int year = int.Parse(text3.Substring(4, 4));
            DateTime date = new DateTime(year, month, 1);
            int weekday = (int)date.DayOfWeek - 1;
            // temporary fix for when the month starts with sunday
            if (weekday < 0)
            {
                weekday = 6;
            }
            return weekday;
        }

        /// <summary>
        /// Gets month's name from word document
        /// </summary>
        /// <returns>Name of the month</returns>
        public string getMonth()
        {
            _Word.Paragraph paragraph3 = doc.Paragraphs[3];
            string text3 = paragraph3.Range.Text;
            text3 = text3.Substring(11);
            string month = text3.Remove(text3.Length - 6);
            return month;
        }
    }
}
