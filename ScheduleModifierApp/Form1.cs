using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public string month;
        public List<ModifiedData> modifiedData = new List<ModifiedData>();
        DocumentHandler docHandler = new DocumentHandler();
        public string testFile = @"C:\Users\simas\OneDrive\Documents\Grafikas_Rugpjucio_Test.docx";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*****************************************************************************
             Data of each employee from document is fetched and returned as List<Employee>
             ****************************************************************************/

            docHandler.openDoc(testFile);
            startingCol = docHandler.firstWeekDayOfMonth();
            month = docHandler.getMonth();
            data = docHandler.getDataFromDoc();
            docHandler.closeDoc(false);

            MonthLabel.Text = month + " men.";

            //Fills combobox with data//
            this.namesComboBox.DataSource = data;
            this.namesComboBox.DisplayMember = "NameAndPosition";

            this.Activate();
        }

        #region ***************************** EVENT TRIGGERS *******************************************
        private void namesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataGrid(namesComboBox.SelectedIndex);
            UndoAllBtn.Enabled = modifiedData.Any(item => item.EmployeeId == namesComboBox.SelectedIndex);
        }

        private void ScheduleDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /********************************************************************************
             A form2 is called when double clicked on cell with value, passing in parameters:
                employeeID from comboBox
                day value of the selected cell
                value of the selected cell
                column of the selected cell
                row of the selected cell
             ********************************************************************************/

            if (ScheduleDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var employeeId = namesComboBox.SelectedIndex;
                var day = getDayOfMonth(e.RowIndex, e.ColumnIndex, startingCol);
                var value = ScheduleDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var col = e.ColumnIndex;
                var row = e.RowIndex;
                Form2 form2 = new Form2(this, row, col, employeeId, day, value);
                form2.Show();

                //TEsting of drawing on cell

                /*Graphics g = ScheduleDataGrid.CreateGraphics();
                Font drawFont = new Font("Arial", 8);
                SolidBrush drawBrush = new SolidBrush(Color.Red);
                CreateGraphics().DrawString("1", drawFont, drawBrush, ScheduleDataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Right, ScheduleDataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Top);
                MessageBox.Show(ScheduleDataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Top.ToString());*/
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            /********************************************************************************
             All made changes are saved to the word document
             ********************************************************************************/

            docHandler.openDoc(testFile);
            docHandler.saveToDoc(modifiedData);
            docHandler.closeDoc(true);
            modifiedData.Clear();
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If form is being closed while there are items in modifiedData list - warning message is shown
            if (modifiedData.Any())
            {
                if (MessageBox.Show("There are unsaved changes. Do You really want to exit without saving?",
                                    "Exit without saving?",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void UndoAllBtn_Click(object sender, EventArgs e)
        {
            UndoAllChanges(namesComboBox.SelectedIndex);
        }

        //HACK for testing purposes only
        private void TestListBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("List count: " + modifiedData.Count());
            if (modifiedData.Any())
            {
                MessageBox.Show("Employee Id: " + modifiedData.Last().EmployeeId + Environment.NewLine
                                + "Day: " + modifiedData.Last().Day + Environment.NewLine
                                + "Value: " + modifiedData.Last().Value + Environment.NewLine
                                + "Column: " + modifiedData.Last().Col + Environment.NewLine
                                + "Row: " + modifiedData.Last().Row + Environment.NewLine
                                + "List ID: " + modifiedData.IndexOf(modifiedData.Last()) + Environment.NewLine);
            }
        }
        #endregion

        #region *********************************** METHODS ***********************************
        /// <summary>
        /// Fills values of selected employee to DataGridView
        /// </summary>
        /// <param name="employeeId">Id of an employee selected from ComboBox</param>
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

            //Updates DataGridView from ModifiedData list//
            updateDataGridViewFromModifiedList(employeeId);
        }

        /// <summary>
        /// Gets the date of a specific cell in form of day
        /// </summary>
        /// <param name="row">DataGridView cell row</param>
        /// <param name="col">DataGridView cell column</param>
        /// <param name="startCol">Starting cell column of the DataGridView from where it is filled</param>
        /// <returns></returns>
        private int getDayOfMonth(int row, int col, int startCol)
        {
            int day = col - startCol;
            switch (row)
            {
                case 0:
                    day = day + 1;
                    break;
                case 1:
                    day = day + 8;
                    break;
                case 2:
                    day = day + 15;
                    break;
                case 3:
                    day = day + 22;
                    break;
                case 4:
                    day = day + 29;
                    break;
                case 5:
                    day = day + 36;
                    break;
            }
            return day;
        }
        
        /// <summary>
        /// Inserts values in DataGridView from list of modifiedData
        /// </summary>
        /// <param name="employeeId">Employee which values are inserted</param>
        private void updateDataGridViewFromModifiedList(int employeeId)
        {
            foreach (var item in modifiedData.FindAll(items => items.EmployeeId == employeeId))
            {
                ScheduleDataGrid.Rows[item.Row].Cells[item.Col].Value = item.Value;
                ScheduleDataGrid.Rows[item.Row].Cells[item.Col].Style.BackColor = Color.LightGreen;
            }
        }

        /// <summary>
        /// Deletes all list items from modifiedData list with matching employeeId
        /// </summary>
        /// <param name="employeeId">Identifier which items need to be deleted</param>
        public void UndoAllChanges(int employeeId)
        {
            modifiedData.RemoveAll(items => items.EmployeeId == namesComboBox.SelectedIndex);
            fillDataGrid(namesComboBox.SelectedIndex);
            UndoAllBtn.Enabled = false;
            SaveBtn.Enabled = modifiedData.Any();
        }
        #endregion
    }
}
