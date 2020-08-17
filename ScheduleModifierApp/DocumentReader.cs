﻿using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Word = Microsoft.Office.Interop.Word;


namespace ScheduleModifierApp
{
    public class DocumentReader
    {
        public static _Word.Application wordApp = new _Word.Application();
        public static object oMissing = System.Reflection.Missing.Value;
        public static object oVisible = false;
        public static _Word.Document doc;
        public static _Word.Table table1;
        public static _Word.Table table2;
        public void openDoc(object fileName)
        {
            doc = wordApp.Documents.Open(ref fileName, ref oMissing, ref oMissing, ref oMissing,
                                         ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                         ref oMissing, ref oMissing, ref oMissing, ref oVisible);
            table1 = doc.Tables[1];
            table2 = doc.Tables[2];
        }
        

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
            return weekday;
        }

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
