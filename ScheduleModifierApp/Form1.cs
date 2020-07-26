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
        public int startingCol;
        public Form1()
        {
            InitializeComponent();
            DocumentReader docReader = new DocumentReader();
            startingCol = docReader.firstWeekDayOfMonth();
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
            int day = startingCol;
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
                if (day == employeeHours.Count + startingCol)
                {
                    ScheduleDataGrid.Rows.Add(gridRow);
                }
            }
        }

        private void ScheduleDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ScheduleDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var employeeId = namesComboBox.SelectedIndex;
                var day = getDayOfMonth(e.RowIndex, e.ColumnIndex, startingCol);
                var value = ScheduleDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var col = e.ColumnIndex;
                var row = e.RowIndex;
                MessageBox.Show(  "EmployeeId: " + employeeId + Environment.NewLine
                                + "Day: " + day + Environment.NewLine
                                + "Cell Value: " + value + Environment.NewLine
                                + "Cell column: " + col + Environment.NewLine
                                + "Cell row: " + row);
            }
            
        }

        private int getDayOfMonth(int row, int col, int startCol)
        {
            int day = col - startCol;
            if (row == 0)
            {
                day = day + 1;
            }
            else if (row == 1)
            {
                day = day + 8;
            }
            else if (row == 2)
            {
                day = day + 15;
            }
            else if (row == 3)
            {
                day = day + 22;
            }
            else if (row == 4)
            {
                day = day + 29;
            }
            else if (row == 5)
            {
                day = day + 36;
            }
            return day;
        }
    }
}
