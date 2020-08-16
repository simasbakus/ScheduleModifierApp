namespace ScheduleModifierApp
{
    partial class Form2
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
            this.ModifyingHoursDateLabel = new System.Windows.Forms.Label();
            this.ModifyingHoursTextBox = new System.Windows.Forms.TextBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ModifyingHoursDateLabel
            // 
            this.ModifyingHoursDateLabel.AutoSize = true;
            this.ModifyingHoursDateLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ModifyingHoursDateLabel.Location = new System.Drawing.Point(51, 55);
            this.ModifyingHoursDateLabel.Name = "ModifyingHoursDateLabel";
            this.ModifyingHoursDateLabel.Size = new System.Drawing.Size(60, 22);
            this.ModifyingHoursDateLabel.TabIndex = 0;
            this.ModifyingHoursDateLabel.Text = "label1";
            // 
            // ModifyingHoursTextBox
            // 
            this.ModifyingHoursTextBox.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ModifyingHoursTextBox.Location = new System.Drawing.Point(55, 159);
            this.ModifyingHoursTextBox.Name = "ModifyingHoursTextBox";
            this.ModifyingHoursTextBox.Size = new System.Drawing.Size(335, 28);
            this.ModifyingHoursTextBox.TabIndex = 1;
            // 
            // OkBtn
            // 
            this.OkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.OkBtn.Location = new System.Drawing.Point(479, 256);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(109, 34);
            this.OkBtn.TabIndex = 2;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 321);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.ModifyingHoursTextBox);
            this.Controls.Add(this.ModifyingHoursDateLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ModifyingHoursDateLabel;
        private System.Windows.Forms.TextBox ModifyingHoursTextBox;
        private System.Windows.Forms.Button OkBtn;
    }
}