namespace ScheduleModifierApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.namesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ScheduleDataGrid = new System.Windows.Forms.DataGridView();
            this.ColMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSaturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // namesComboBox
            // 
            this.namesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.namesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.namesComboBox.FormattingEnabled = true;
            this.namesComboBox.Location = new System.Drawing.Point(85, 38);
            this.namesComboBox.Name = "namesComboBox";
            this.namesComboBox.Size = new System.Drawing.Size(390, 28);
            this.namesComboBox.TabIndex = 0;
            this.namesComboBox.SelectedIndexChanged += new System.EventHandler(this.namesComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(584, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // ScheduleDataGrid
            // 
            this.ScheduleDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMonday,
            this.ColTuesday,
            this.ColWednesday,
            this.ColThursday,
            this.ColFriday,
            this.ColSaturday,
            this.ColSunday});
            this.ScheduleDataGrid.Location = new System.Drawing.Point(12, 285);
            this.ScheduleDataGrid.Name = "ScheduleDataGrid";
            this.ScheduleDataGrid.RowHeadersWidth = 51;
            this.ScheduleDataGrid.RowTemplate.Height = 24;
            this.ScheduleDataGrid.Size = new System.Drawing.Size(1188, 253);
            this.ScheduleDataGrid.TabIndex = 2;
            // 
            // ColMonday
            // 
            this.ColMonday.HeaderText = "Monday";
            this.ColMonday.MinimumWidth = 6;
            this.ColMonday.Name = "ColMonday";
            this.ColMonday.Width = 125;
            // 
            // ColTuesday
            // 
            this.ColTuesday.HeaderText = "Tuesday";
            this.ColTuesday.MinimumWidth = 6;
            this.ColTuesday.Name = "ColTuesday";
            this.ColTuesday.Width = 125;
            // 
            // ColWednesday
            // 
            this.ColWednesday.HeaderText = "Wednesday";
            this.ColWednesday.MinimumWidth = 6;
            this.ColWednesday.Name = "ColWednesday";
            this.ColWednesday.Width = 125;
            // 
            // ColThursday
            // 
            this.ColThursday.HeaderText = "Thursday";
            this.ColThursday.MinimumWidth = 6;
            this.ColThursday.Name = "ColThursday";
            this.ColThursday.Width = 125;
            // 
            // ColFriday
            // 
            this.ColFriday.HeaderText = "Friday";
            this.ColFriday.MinimumWidth = 6;
            this.ColFriday.Name = "ColFriday";
            this.ColFriday.Width = 125;
            // 
            // ColSaturday
            // 
            this.ColSaturday.HeaderText = "Saturday";
            this.ColSaturday.MinimumWidth = 6;
            this.ColSaturday.Name = "ColSaturday";
            this.ColSaturday.Width = 125;
            // 
            // ColSunday
            // 
            this.ColSunday.HeaderText = "Sunday";
            this.ColSunday.MinimumWidth = 6;
            this.ColSunday.Name = "ColSunday";
            this.ColSunday.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 535);
            this.Controls.Add(this.ScheduleDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namesComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox namesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ScheduleDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColThursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFriday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSunday;
    }
}

