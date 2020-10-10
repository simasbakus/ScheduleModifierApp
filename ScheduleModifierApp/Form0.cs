using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ScheduleModifierApp
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\simas\OneDrive\Documents\" + FileNameTextBox.Text + ".docx";

            if (File.Exists(path))
            {
                Form1 form1 = new Form1(path);
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Failas Nerastas");
            }
        }
    }
}
