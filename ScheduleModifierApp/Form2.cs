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
        public Form2(Form1 form1, int row, int col, int employeeId, int day)
        {
            InitializeComponent();
            this.form1 = form1;
            this.row = row;
            this.col = col;
            this.employeeId = employeeId;
            this.day = day;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ModifyingHoursDateLabel.Text = form1.namesComboBox.Text + " " + day.ToString() + " dienos valandu keitimas";
            ModifyingHoursTextBox.Text = form1.ScheduleDataGrid.Rows[row].Cells[col].Value.ToString();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
