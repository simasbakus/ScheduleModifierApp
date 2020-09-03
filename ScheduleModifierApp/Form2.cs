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
            if (form1.WeekCheckBox.Checked)
            {
                ModifyingHoursDateLabel.Text =   form1.namesComboBox.Text + Environment.NewLine
                                               + month + " men. " + (this.row + 1).ToString() + " savaites darbo valandos";
            }
            else
            {
                ModifyingHoursDateLabel.Text =   form1.namesComboBox.Text + Environment.NewLine
                                               + month + " men. " + day.ToString() + " dienos darbo valandos";
                ModifyingHoursTextBox.Text   = value;
            }
        }

        #region ********************************** EVENT TRIGGERS *****************************************
        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (form1.WeekCheckBox.Checked)
            {
                form1.applyChanges(ModifyingHoursTextBox.Text, this.employeeId, this.row);
            }
            else
            {
                form1.applyChanges(ModifyingHoursTextBox.Text, this.employeeId, this.row, this.col, this.day);
            }
            

            exitWithoutMessage();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If form2 is closed not from OkBtn_Click event - warning message is shown
            if (exitWithX && ModifyingHoursTextBox.Text != value && !form1.WeekCheckBox.Checked)
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
            form1.fillDataGrid(this.employeeId);
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            if (form1.WeekCheckBox.Checked)
            {
                form1.undoChanges(this.employeeId, this.row);
            }
            else
            {
                form1.undoChanges(this.employeeId, this.row, this.col);
            }
            exitWithoutMessage();
        }
        #endregion

        #region ************************************ METHODS ******************************************

        /// <summary>
        /// Closes form2 without warning message
        /// </summary>
        public void exitWithoutMessage()
        {
            exitWithX = false;
            this.Close();
        }

        //TODO applyBtn enabled only if fill in has some value
        //Issue when fill in is empty and apply is pressed when changing whole week values
        #endregion
    }
}
