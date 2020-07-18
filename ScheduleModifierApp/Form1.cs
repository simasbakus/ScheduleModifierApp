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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DocumentReader docReader = new DocumentReader();
            this.namesComboBox.DataSource = docReader.getEmployeeList();
        }

        private void namesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label1.Text = this.namesComboBox.SelectedIndex.ToString();
        }
    }
}
