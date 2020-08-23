using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleModifierApp
{
    public partial class Form2 : Form
    {
        public Form1 form1 { get; set; }
        public int row { get; }
        public int col { get; }
        public int employeeId { get; }
        public int day { get; }
        public string value { get; }
        public string month { get; }

        private bool exitWithX = true;
        public Form2(Form1 form1, int row, int col, int employeeId, int day, string value)
        {
            /****************************************************************************
             Initializes values passed in from form1
             ****************************************************************************/

            InitializeComponent();
            this.form1 = form1;
            this.row = row;
            this.col = col;
            this.employeeId = employeeId;
            this.day = day;
            this.value = value;
            this.month = form1.month;

            UndoBtn.Enabled = form1.modifiedData.Find(item => item.EmployeeId == this.employeeId && item.Day == this.day) != null;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ModifyingHoursDateLabel.Text =   form1.namesComboBox.Text + Environment.NewLine 
                                           + month + " men. " + day.ToString() + " dienos darbo valandos";
            ModifyingHoursTextBox.Text = value;
        }

        #region ********************************** EVENT TRIGGERS *****************************************
        private void OkBtn_Click(object sender, EventArgs e)
        {
            /****************************************************************************************
             Creates, replaces or deletes modifiedData list item and closes form2
             ****************************************************************************************/

            if (value != ModifyingHoursTextBox.Text
                && !form1.modifiedData.Any(item => item.EmployeeId == this.employeeId && item.Day == this.day)
                && form1.data[this.employeeId].Hours[this.day - 1] != ModifyingHoursTextBox.Text)
            {
                applyChanges(false);
            }
            else if (form1.modifiedData.Any(item => item.EmployeeId == this.employeeId && item.Day == this.day)
                     && form1.data[this.employeeId].Hours[this.day - 1] != ModifyingHoursTextBox.Text)
            {
                applyChanges(true);
            }
            else if (form1.data[this.employeeId].Hours[this.day - 1] == ModifyingHoursTextBox.Text)
            {
                undoChanges();
            }

            exitWithoutMessage();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If form2 is closed not from OkBtn_Click event - warning message is shown
            if (exitWithX && ModifyingHoursTextBox.Text != value)
            {
                if (MessageBox.Show("Do You really want to cancel editing day " + day + "? Latest change will not be saved!", 
                                    "Exit without saving?", 
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

            //Enables buttons in form1 if there are items in modifiedData list
            form1.SaveBtn.Enabled = form1.modifiedData.Any();
            form1.UndoAllBtn.Enabled = form1.modifiedData.Any(item => item.EmployeeId == this.employeeId);
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            undoChanges();
            exitWithoutMessage();
        }
        #endregion

        #region ************************************ METHODS ******************************************

        /// <summary>
        /// Deletes selected cell changes and reverts back to original
        /// </summary>
        private void undoChanges()
        {
            form1.modifiedData.RemoveAll(item => item.EmployeeId == this.employeeId && item.Day == this.day);

            //Applies changes to DataGridView
            form1.ScheduleDataGrid.Rows[row].Cells[col].Value = form1.data[this.employeeId].Hours[this.day - 1];
            form1.ScheduleDataGrid.Rows[row].Cells[col].Style.BackColor = Color.White;
        }

        /// <summary>
        /// Creates or replaces modifiedData list item depending if it exists
        /// </summary>
        /// <param name="changesExist">If set to true: replaces existing modifiedData list item value with new one, else creates new item</param>
        private void applyChanges(bool changesExist)
        {
            if (changesExist)
            {
                form1.modifiedData.Find(item => item.EmployeeId == this.employeeId && item.Day == this.day).Value = ModifyingHoursTextBox.Text;
            }
            else
            {
                form1.modifiedData.Add(new ModifiedData() { EmployeeId = employeeId, Day = day, Value = ModifyingHoursTextBox.Text, Col = col, Row = row });
            }

            //Applies changes to DataGridView
            form1.ScheduleDataGrid.Rows[row].Cells[col].Value = ModifyingHoursTextBox.Text;
            form1.ScheduleDataGrid.Rows[row].Cells[col].Style.BackColor = Color.LightGreen;
        }

        /// <summary>
        /// Closes form2 without warning message
        /// </summary>
        public void exitWithoutMessage()
        {
            exitWithX = false;
            this.Close();
        }
        #endregion
    }
}
