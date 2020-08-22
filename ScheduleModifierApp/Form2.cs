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

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (   value != ModifyingHoursTextBox.Text
                && form1.modifiedData.Find(item => item.EmployeeId == this.employeeId && item.Day == this.day) == null
                && form1.data[this.employeeId].Hours[this.day - 1] != ModifyingHoursTextBox.Text)
            {
                //adds an item to modified list
                form1.modifiedData.Add(new ModifiedData() { EmployeeId = employeeId, Day = day, Value = ModifyingHoursTextBox.Text, Col = col, Row = row });

                //updates new value in form1 dataGridView//

                form1.ScheduleDataGrid.Rows[row].Cells[col].Value = ModifyingHoursTextBox.Text;
            }
            else if (   form1.modifiedData.Find(item => item.EmployeeId == this.employeeId && item.Day == this.day) != null
                     && form1.data[this.employeeId].Hours[this.day - 1] != ModifyingHoursTextBox.Text)
            {
                //Value of specific employee and specific day is changed in modified list if it has already been changed before 
                //but is NOT!! being changed to the initiial value from the document
                form1.modifiedData.Find(item => item.EmployeeId == this.employeeId && item.Day == this.day).Value = ModifyingHoursTextBox.Text;

                //updates new value in form1 dataGridView//

                form1.ScheduleDataGrid.Rows[row].Cells[col].Value = ModifyingHoursTextBox.Text;
            }
            else if (form1.data[this.employeeId].Hours[this.day - 1] == ModifyingHoursTextBox.Text)
            {
                //item from modified list is deleted if value is changed back tto initial value of the document
                undoChanges();
            }

            //sets the boolean exitWithX to false to close the window immediatly//

            exitWithX = false;
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitWithX)
            {
                //if boolean exitWithX is true shows a message before closing//

                if (MessageBox.Show("Do You really want to cancel editing day " + day + "? Latest change will not be saved!", 
                                    "Exit without saving?", 
                                    MessageBoxButtons.YesNo,  
                                    MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            undoChanges();

            exitWithX = false;
            this.Close();
        }

        private void undoChanges()
        {
            form1.modifiedData.RemoveAll(item => item.EmployeeId == this.employeeId && item.Day == this.day);

            form1.ScheduleDataGrid.Rows[row].Cells[col].Value = form1.data[this.employeeId].Hours[this.day - 1];
        }
    }
}
