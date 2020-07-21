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
        public Form1()
        {
            InitializeComponent();
            DocumentReader docReader = new DocumentReader();
            data = docReader.getDataFromDoc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.namesComboBox.DataSource = data;
            this.namesComboBox.DisplayMember = "NameAndPosition";
        }

        private void namesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label1.Text = data[namesComboBox.SelectedIndex].Hours[2];
        }


    }
}
