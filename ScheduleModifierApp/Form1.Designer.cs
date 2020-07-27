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
            this.ScheduleDataGrid = new System.Windows.Forms.DataGridView();
            this.ColMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSatuday = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // ScheduleDataGrid
            // 
            this.ScheduleDataGrid.AllowUserToAddRows = false;
            this.ScheduleDataGrid.AllowUserToDeleteRows = false;
            this.ScheduleDataGrid.AllowUserToResizeColumns = false;
            this.ScheduleDataGrid.AllowUserToResizeRows = false;
            this.ScheduleDataGrid.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.ScheduleDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScheduleDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMonday,
            this.ColTuesday,
            this.ColWednesday,
            this.ColThursday,
            this.ColFriday,
            this.ColSatuday,
            this.ColSunday});
            this.ScheduleDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ScheduleDataGrid.Location = new System.Drawing.Point(12, 210);
            this.ScheduleDataGrid.MultiSelect = false;
            this.ScheduleDataGrid.Name = "ScheduleDataGrid";
            this.ScheduleDataGrid.ReadOnly = true;
            this.ScheduleDataGrid.RowHeadersVisible = false;
            this.ScheduleDataGrid.RowHeadersWidth = 51;
            this.ScheduleDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ScheduleDataGrid.RowTemplate.Height = 24;
            this.ScheduleDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ScheduleDataGrid.Size = new System.Drawing.Size(1171, 240);
            this.ScheduleDataGrid.TabIndex = 2;
            this.ScheduleDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScheduleDataGrid_CellDoubleClick);
            // 
            // ColMonday
            // 
            this.ColMonday.HeaderText = "Monday";
            this.ColMonday.MinimumWidth = 6;
            this.ColMonday.Name = "ColMonday";
            this.ColMonday.ReadOnly = true;
            this.ColMonday.Width = 125;
            // 
            // ColTuesday
            // 
            this.ColTuesday.HeaderText = "Tuesday";
            this.ColTuesday.MinimumWidth = 6;
            this.ColTuesday.Name = "ColTuesday";
            this.ColTuesday.ReadOnly = true;
            this.ColTuesday.Width = 125;
            // 
            // ColWednesday
            // 
            this.ColWednesday.HeaderText = "Wednesday";
            this.ColWednesday.MinimumWidth = 6;
            this.ColWednesday.Name = "ColWednesday";
            this.ColWednesday.ReadOnly = true;
            this.ColWednesday.Width = 125;
            // 
            // ColThursday
            // 
            this.ColThursday.HeaderText = "Thursday";
            this.ColThursday.MinimumWidth = 6;
            this.ColThursday.Name = "ColThursday";
            this.ColThursday.ReadOnly = true;
            this.ColThursday.Width = 125;
            // 
            // ColFriday
            // 
            this.ColFriday.HeaderText = "Friday";
            this.ColFriday.MinimumWidth = 6;
            this.ColFriday.Name = "ColFriday";
            this.ColFriday.ReadOnly = true;
            this.ColFriday.Width = 125;
            // 
            // ColSatuday
            // 
            this.ColSatuday.HeaderText = "Saturday";
            this.ColSatuday.MinimumWidth = 6;
            this.ColSatuday.Name = "ColSatuday";
            this.ColSatuday.ReadOnly = true;
            this.ColSatuday.Width = 125;
            // 
            // ColSunday
            // 
            this.ColSunday.HeaderText = "Sunday";
            this.ColSunday.MinimumWidth = 6;
            this.ColSunday.Name = "ColSunday";
            this.ColSunday.ReadOnly = true;
            this.ColSunday.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 535);
            this.Controls.Add(this.ScheduleDataGrid);
            this.Controls.Add(this.namesComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox namesComboBox;
        public System.Windows.Forms.DataGridView ScheduleDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColThursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFriday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSatuday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSunday;
    }
}

