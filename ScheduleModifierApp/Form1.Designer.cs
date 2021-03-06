﻿namespace ScheduleModifierApp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.namesComboBox = new System.Windows.Forms.ComboBox();
            this.ScheduleDataGrid = new System.Windows.Forms.DataGridView();
            this.ColMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSatuday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthLabel = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.UndoAllBtn = new System.Windows.Forms.Button();
            this.WeekCheckBox = new System.Windows.Forms.CheckBox();
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
            this.ScheduleDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ScheduleDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.ScheduleDataGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScheduleDataGrid_CellEnter);
            this.ScheduleDataGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.ScheduleDataGrid_CellPainting);
            // 
            // ColMonday
            // 
            this.ColMonday.HeaderText = "Pirmadienis";
            this.ColMonday.MinimumWidth = 6;
            this.ColMonday.Name = "ColMonday";
            this.ColMonday.ReadOnly = true;
            this.ColMonday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColMonday.Width = 125;
            // 
            // ColTuesday
            // 
            this.ColTuesday.HeaderText = "Antradienis";
            this.ColTuesday.MinimumWidth = 6;
            this.ColTuesday.Name = "ColTuesday";
            this.ColTuesday.ReadOnly = true;
            this.ColTuesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColTuesday.Width = 125;
            // 
            // ColWednesday
            // 
            this.ColWednesday.HeaderText = "Treciadienis";
            this.ColWednesday.MinimumWidth = 6;
            this.ColWednesday.Name = "ColWednesday";
            this.ColWednesday.ReadOnly = true;
            this.ColWednesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWednesday.Width = 125;
            // 
            // ColThursday
            // 
            this.ColThursday.HeaderText = "Ketvirtadienis";
            this.ColThursday.MinimumWidth = 6;
            this.ColThursday.Name = "ColThursday";
            this.ColThursday.ReadOnly = true;
            this.ColThursday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColThursday.Width = 125;
            // 
            // ColFriday
            // 
            this.ColFriday.HeaderText = "Penktadienis";
            this.ColFriday.MinimumWidth = 6;
            this.ColFriday.Name = "ColFriday";
            this.ColFriday.ReadOnly = true;
            this.ColFriday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColFriday.Width = 125;
            // 
            // ColSatuday
            // 
            this.ColSatuday.HeaderText = "Sestadienis";
            this.ColSatuday.MinimumWidth = 6;
            this.ColSatuday.Name = "ColSatuday";
            this.ColSatuday.ReadOnly = true;
            this.ColSatuday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSatuday.Width = 125;
            // 
            // ColSunday
            // 
            this.ColSunday.HeaderText = "Sekmadienis";
            this.ColSunday.MinimumWidth = 6;
            this.ColSunday.Name = "ColSunday";
            this.ColSunday.ReadOnly = true;
            this.ColSunday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSunday.Width = 125;
            // 
            // MonthLabel
            // 
            this.MonthLabel.AutoSize = true;
            this.MonthLabel.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.MonthLabel.Location = new System.Drawing.Point(12, 163);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Size = new System.Drawing.Size(77, 29);
            this.MonthLabel.TabIndex = 4;
            this.MonthLabel.Text = "label1";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.SaveBtn.Location = new System.Drawing.Point(1006, 465);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(177, 49);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save Changes";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // UndoAllBtn
            // 
            this.UndoAllBtn.Enabled = false;
            this.UndoAllBtn.Location = new System.Drawing.Point(978, 160);
            this.UndoAllBtn.Name = "UndoAllBtn";
            this.UndoAllBtn.Size = new System.Drawing.Size(222, 29);
            this.UndoAllBtn.TabIndex = 6;
            this.UndoAllBtn.Text = "Undo all employee changes";
            this.UndoAllBtn.UseVisualStyleBackColor = true;
            this.UndoAllBtn.Click += new System.EventHandler(this.UndoAllBtn_Click);
            // 
            // WeekCheckBox
            // 
            this.WeekCheckBox.AutoSize = true;
            this.WeekCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.WeekCheckBox.Location = new System.Drawing.Point(818, 160);
            this.WeekCheckBox.Name = "WeekCheckBox";
            this.WeekCheckBox.Size = new System.Drawing.Size(123, 24);
            this.WeekCheckBox.TabIndex = 7;
            this.WeekCheckBox.Text = "Modify week";
            this.WeekCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 535);
            this.Controls.Add(this.WeekCheckBox);
            this.Controls.Add(this.UndoAllBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.MonthLabel);
            this.Controls.Add(this.ScheduleDataGrid);
            this.Controls.Add(this.namesComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox namesComboBox;
        public System.Windows.Forms.DataGridView ScheduleDataGrid;
        private System.Windows.Forms.Label MonthLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColThursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFriday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSatuday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSunday;
        public System.Windows.Forms.Button SaveBtn;
        public System.Windows.Forms.Button UndoAllBtn;
        public System.Windows.Forms.CheckBox WeekCheckBox;
    }
}

