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
            fillDataGrid(namesComboBox.SelectedIndex);
        }

        private void fillDataGrid(int employeeId)
        {
            int day = 5;
            int week = 0;
            foreach (var item in data[employeeId].Hours)
            {
                if ((day == 7) || (day == 14) || (day == 21) || (day == 28) || (day == 35))
                {
                    ScheduleDataGrid.Rows.Add();
                    week++;
                };
                if (week == 0)
                {
                    ScheduleDataGrid.Rows[week].Cells[day].Value = item;
                }
                if (week == 1)
                {
                    ScheduleDataGrid.Rows[week].Cells[day - 7].Value = item;
                }
                else if (week == 2)
                {
                    ScheduleDataGrid.Rows[week].Cells[day - 14].Value = item;
                }
                else if (week == 3)
                {
                    ScheduleDataGrid.Rows[week].Cells[day - 21].Value = item;
                }
                else if (week == 4)
                {
                    ScheduleDataGrid.Rows[week].Cells[day - 28].Value = item;
                };
                day++;
                
            }
        }
    }
}
