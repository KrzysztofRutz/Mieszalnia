namespace PLC_SIEMENS
{
    partial class ze1
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.stan_label = new System.Windows.Forms.Label();
            this.open_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.alarm1_label = new System.Windows.Forms.Label();
            this.cycle_stany = new System.Windows.Forms.Timer(this.components);
            this.cycle_alarmy = new System.Windows.Forms.Timer(this.components);
            this.alarm2_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zasuwa ze1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stan_label
            // 
            this.stan_label.BackColor = System.Drawing.SystemColors.ControlDark;
            this.stan_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stan_label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stan_label.Location = new System.Drawing.Point(0, 34);
            this.stan_label.Name = "stan_label";
            this.stan_label.Size = new System.Drawing.Size(232, 94);
            this.stan_label.TabIndex = 2;
            this.stan_label.Text = "----";
            this.stan_label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // open_button
            // 
            this.open_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.open_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.open_button.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.open_button.Location = new System.Drawing.Point(6, 41);
            this.open_button.Name = "open_button";
            this.open_button.Size = new System.Drawing.Size(105, 55);
            this.open_button.TabIndex = 3;
            this.open_button.Text = "OTWÓRZ";
            this.open_button.UseVisualStyleBackColor = false;
            this.open_button.Click += new System.EventHandler(this.open_button_Click);
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.close_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.close_button.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.close_button.Location = new System.Drawing.Point(114, 41);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(105, 55);
            this.close_button.TabIndex = 5;
            this.close_button.Text = "ZAMKNIJ";
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(0, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Obwód";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(0, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Czujnik krańcowy";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // alarm1_label
            // 
            this.alarm1_label.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.alarm1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.alarm1_label.ForeColor = System.Drawing.Color.Blue;
            this.alarm1_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alarm1_label.Location = new System.Drawing.Point(179, 132);
            this.alarm1_label.Name = "alarm1_label";
            this.alarm1_label.Size = new System.Drawing.Size(51, 19);
            this.alarm1_label.TabIndex = 8;
            this.alarm1_label.Text = "OK";
            this.alarm1_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cycle_stany
            // 
            this.cycle_stany.Enabled = true;
            this.cycle_stany.Interval = 1000;
            this.cycle_stany.Tick += new System.EventHandler(this.cycle_Tick);
            // 
            // cycle_alarmy
            // 
            this.cycle_alarmy.Enabled = true;
            this.cycle_alarmy.Interval = 1000;
            this.cycle_alarmy.Tick += new System.EventHandler(this.cycle_alarmy_Tick);
            // 
            // alarm2_label
            // 
            this.alarm2_label.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.alarm2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.alarm2_label.ForeColor = System.Drawing.Color.Blue;
            this.alarm2_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alarm2_label.Location = new System.Drawing.Point(179, 156);
            this.alarm2_label.Name = "alarm2_label";
            this.alarm2_label.Size = new System.Drawing.Size(51, 19);
            this.alarm2_label.TabIndex = 9;
            this.alarm2_label.Text = "OK";
            this.alarm2_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ze1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 176);
            this.Controls.Add(this.alarm2_label);
            this.Controls.Add(this.alarm1_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.open_button);
            this.Controls.Add(this.stan_label);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ze1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zasuwa ze1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button open_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label alarm1_label;
        private System.Windows.Forms.Timer cycle_stany;
        public System.Windows.Forms.Label stan_label;
        private System.Windows.Forms.Timer cycle_alarmy;
        private System.Windows.Forms.Label alarm2_label;
    }
}