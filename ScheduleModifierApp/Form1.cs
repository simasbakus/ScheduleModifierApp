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
        public string testFile = @"C:\Users\simas\OneDrive\Documents\Grafikas_Rugsejo_Test.docx";
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
        }

        #region ***************************** EVENT TRIGGERS *******************************************
        private void namesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataGrid(namesComboBox.SelectedIndex);
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
            if (ScheduleDataGrid[e.ColumnIndex, e.RowIndex].Value != null)
            {
                var value = ScheduleDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                value = value.Substring(value.IndexOf(Environment.NewLine) + 2);
                var col = e.ColumnIndex;
                var row = e.RowIndex;
                int day = getDayOfMonth(row, col, startingCol);
                Form2 form2 = new Form2(this, row, col, day, value);
                form2.ShowDialog();
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
            undoChanges(namesComboBox.SelectedIndex);
        }

        private void ScheduleDataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /*****************************************************************************
             Draws a blue ractangle inside the borders of a selected cell
             *******************************************************************************/

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (ScheduleDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using (Pen p = new Pen(Color.Blue, 1))
                    {
                        Rectangle rect = e.CellBounds;
                        rect.Width -= 2;
                        rect.Height -= 2;
                        e.Graphics.DrawRectangle(p, rect);
                    }
                    e.Handled = true;
                }
            }
        }
        //TODO draw blue rectangle in cell when cell entered, get rid of cellPainting event

        private void ScheduleDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            /**********************************************************************************
             Matches the selected cell background color with the default cell background color
             **********************************************************************************/

            ScheduleDataGrid[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = ScheduleDataGrid[e.ColumnIndex, e.RowIndex].Style.BackColor;
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
        public void fillDataGrid(int employeeId)
        {
            ScheduleDataGrid.Rows.Clear();
            ScheduleDataGrid.Rows.Add();
            int column = startingCol;
            int daysToSubtract = 0;
            foreach (var item in data[employeeId].Hours)
            {
                /**************************************************************************
                if column is the first column in dataGridView (except row 0) a new row is added,
                then value is added to the cell
                **************************************************************************/
                if ((column % 7) == 0 && column != 0)
                {
                    ScheduleDataGrid.Rows.Add();
                    daysToSubtract = daysToSubtract + 7;
                }
                ScheduleDataGrid[column - daysToSubtract, ScheduleDataGrid.RowCount - 1].Value = (column - startingCol + 1) + Environment.NewLine + item;
                column++;
            }

            updateDataGridViewFromModifiedList(employeeId);

            UndoAllBtn.Enabled = modifiedData.Any(item => item.EmployeeId == employeeId);
            SaveBtn.Enabled = modifiedData.Any();
        }

        /// <summary>
        /// Gets the date of a specific cell in form of day
        /// </summary>
        /// <param name="row">DataGridView cell row</param>
        /// <param name="col">DataGridView cell column</param>
        /// <param name="startCol">Starting cell column of the DataGridView from where it is filled</param>
        /// <returns></returns>
        public int getDayOfMonth(int row, int col, int startCol)
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
                ScheduleDataGrid[item.Col, item.Row].Value = item.Day + Environment.NewLine + item.Value;
                ScheduleDataGrid[item.Col, item.Row].Style.BackColor = Color.LightGreen;
            }
        }

        /// <summary>
        /// Deletes all list items from modifiedData list with matching employeeId
        /// </summary>
        /// <param name="employeeId">Identifier which items need to be deleted</param>
        public void undoChanges(int employeeId)
        {
            modifiedData.RemoveAll(items => items.EmployeeId == employeeId);
            fillDataGrid(namesComboBox.SelectedIndex);
        }

        /// <summary>
        /// Deletes all list items from modifiedData list with matching employeeId and row
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="row"></param>
        public void undoChanges(int employeeId, int row)
        {
            modifiedData.RemoveAll(item => item.EmployeeId == employeeId && item.Row == row);
            fillDataGrid(namesComboBox.SelectedIndex);
        }

        /// <summary>
        /// Deletes single list item from modifiedData list with matching employeeId, col and row
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void undoChanges(int employeeId, int row, int col)
        {
            modifiedData.RemoveAll(item => item.EmployeeId == employeeId && item.Row == row && item.Col == col);
            fillDataGrid(namesComboBox.SelectedIndex);
        }

        /// <summary>
        /// Adds changes to modified list for a whole week
        /// </summary>
        /// <param name="value"></param>
        /// <param name="employeeId"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        public void applyChanges(string value, int employeeId, int row)
        {
            /*********************************************************************************
            Adds new list item to modified list if theres none with the same employeeId and day
            Changes the value of the list item if one exists with the same employeeId and day
            Deletes the list item if the value passed is the same as the initial value 
            *********************************************************************************/
            for (int col = 0; col < 7; col++)
            {
                if (ScheduleDataGrid[col,row].Value != null)
                {
                    int day = getDayOfMonth(row, col, startingCol);

                    if (!modifiedData.Any(item => item.EmployeeId == employeeId && item.Day == day)
                        && data[employeeId].Hours[day - 1] != value)
                    {
                        modifiedData.Add(new ModifiedData() { EmployeeId = employeeId, Day = day, Value = value, Col = col, Row = row });
                    }
                    else if (modifiedData.Any(item => item.EmployeeId == employeeId && item.Day == day)
                             && data[employeeId].Hours[day - 1] != value)
                    {
                        modifiedData.Find(item => item.EmployeeId == employeeId && item.Day == day).Value = value;
                    }
                    else if (data[employeeId].Hours[day - 1] == value)
                    {
                        undoChanges(employeeId, row, col);
                    }
                }
            }
        }

        /// <summary>
        /// Adds changes to modified list for a single day
        /// </summary>
        /// <param name="value"></param>
        /// <param name="employeeId"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void applyChanges(string value, int employeeId, int row, int col, int day)
        {
            /*********************************************************************************
            Adds new list item to modified list if theres none with the same employeeId and day
            Changes the value of the list item if one exists with the same employeeId and day
            Deletes the list item if the value passed is the same as the initial value 
            *********************************************************************************/
            if (   !modifiedData.Any(item => item.EmployeeId == employeeId && item.Day == day)
                && data[employeeId].Hours[day - 1] != value)
            {
                modifiedData.Add(new ModifiedData() { EmployeeId = employeeId, Day = day, Value = value, Col = col, Row = row });
            }
            else if (   modifiedData.Any(item => item.EmployeeId == employeeId && item.Day == day)
                     && data[employeeId].Hours[day - 1] != value)
            {
                modifiedData.Find(item => item.EmployeeId == employeeId && item.Day == day).Value = value;
            }
            else if (data[employeeId].Hours[day - 1] == value)
            {
                undoChanges(employeeId, row, col);
            }
        }

        //TODO Vacation form
        //TODO form1 resizeability
        #endregion

    }
}
