﻿using System;
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
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ModifyingHoursDateLabel.Text = form1.namesComboBox.Text + Environment.NewLine + day.ToString() + " dienos valandu keitimas";
            ModifyingHoursTextBox.Text = value;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            exitWithX = false;
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitWithX)
            {
                if (MessageBox.Show("Do You really want to exit? Latest change will not be saved!", "Exit without saving?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            
            
        }
    }
}
