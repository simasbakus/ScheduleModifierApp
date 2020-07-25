using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Word = Microsoft.Office.Interop.Word;

namespace ScheduleModifierApp
{
    public partial class Form1 : Form
    {
        public List<Employee> data;
        public int weekDay;
        public Form1()
        {
            InitializeComponent();
            DocumentReader docReader = new DocumentReader();
            weekDay = docReader.firstWeekDayOfMonth();
            data = docReader.getDataFromDoc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.namesComboBox.DataSource = data;
            this.namesComboBox.DisplayMember = "NameAndPosition";
        }

        private void namesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataGrid(namesComboBox.SelectedIndex);
        }

        private void fillDataGrid(int employeeId)
        {
            int day = weekDay;
            ScheduleDataGrid.Rows.Clear();
            List<string> employeeHours = data[employeeId].Hours;
            DataGridViewRow gridRow = new DataGridViewRow();
            ScheduleDataGrid.Rows.Add();
            foreach (var item in employeeHours)
            {
                if (day < 7)
                {
                    ScheduleDataGrid.Rows[0].Cells[day].Value = item;
                }
                else if (day == 7)
                {
                    gridRow = (DataGridViewRow)ScheduleDataGrid.Rows[0].Clone();
                    gridRow.Cells[day - 7].Value = item;
                }
                else if (day > 7 && day < 14)
                {
                    gridRow.Cells[day - 7].Value = item;
                }
                else if (day == 14)
                {
                    ScheduleDataGrid.Rows.Add(gridRow);
                    gridRow = (DataGridViewRow)ScheduleDataGrid.Rows[1].Clone();
                    gridRow.Cells[day - 14].Value = item;
                }
                else if (day > 14 && day < 21)
                {
                    gridRow.Cells[day - 14].Value = item;
                }
                else if (day == 21)
                {
                    ScheduleDataGrid.Rows.Add(gridRow);
                    gridRow = (DataGridViewRow)ScheduleDataGrid.Rows[2].Clone();
                    gridRow.Cells[day - 21].Value = item;
                }
                else if (day > 21 && day < 28)
                {
                    gridRow.Cells[day - 21].Value = item;
                }
                else if (day == 28)
                {
                    ScheduleDataGrid.Rows.Add(gridRow);
                    gridRow = (DataGridViewRow)ScheduleDataGrid.Rows[3].Clone();
                    gridRow.Cells[day - 28].Value = item;
                }
                else if (day > 28 && day < 35)
                {
                    gridRow.Cells[day - 28].Value = item;
                }
                else if (day == 35)
                {
                    ScheduleDataGrid.Rows.Add(gridRow);
                    gridRow = (DataGridViewRow)ScheduleDataGrid.Rows[4].Clone();
                    gridRow.Cells[day - 35].Value = item;
                }
                else if (day > 35 && day < 42)
                {
                    gridRow.Cells[day - 35].Value = item;
                }
                day++;
                if (day == employeeHours.Count + 5)
                {
                    ScheduleDataGrid.Rows.Add(gridRow);
                }
            }
        }


    }
}
