namespace PLC_SIEMENS
{
    partial class R1
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
            this.alarm2_label = new System.Windows.Forms.Label();
            this.alarm1_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stop_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.stan_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SV_analog_suwak = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SV_analog_textbox = new System.Windows.Forms.TextBox();
            this.alarm3_label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.alarm4_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cycle_stany = new System.Windows.Forms.Timer(this.components);
            this.cycle_alarmy = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SV_analog_suwak)).BeginInit();
            this.SuspendLayout();
            // 
            // alarm2_label
            // 
            this.alarm2_label.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.alarm2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.alarm2_label.ForeColor = System.Drawing.Color.Blue;
            this.alarm2_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alarm2_label.Location = new System.Drawing.Point(179, 235);
            this.alarm2_label.Name = "alarm2_label";
            this.alarm2_label.Size = new System.Drawing.Size(51, 19);
            this.alarm2_label.TabIndex = 17;
            this.alarm2_label.Text = "OK";
            this.alarm2_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // alarm1_label
            // 
            this.alarm1_label.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.alarm1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.alarm1_label.ForeColor = System.Drawing.Color.Blue;
            this.alarm1_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alarm1_label.Location = new System.Drawing.Point(179, 211);
            this.alarm1_label.Name = "alarm1_label";
            this.alarm1_label.Size = new System.Drawing.Size(51, 19);
            this.alarm1_label.TabIndex = 16;
            this.alarm1_label.Text = "OK";
            this.alarm1_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(0, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Czujnik membranowy";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(0, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Obwód";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stop_button
            // 
            this.stop_button.BackColor = System.Drawing.Color.Red;
            this.stop_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stop_button.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stop_button.Location = new System.Drawing.Point(114, 41);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(105, 55);
            this.stop_button.TabIndex = 13;
            this.stop_button.Text = "STOP";
            this.stop_button.UseVisualStyleBackColor = false;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.start_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.start_button.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start_button.Location = new System.Drawing.Point(6, 41);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(105, 55);
            this.start_button.TabIndex = 12;
            this.start_button.Text = "START";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // stan_label
            // 
            this.stan_label.BackColor = System.Drawing.SystemColors.ControlDark;
            this.stan_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stan_label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stan_label.Location = new System.Drawing.Point(0, 34);
            this.stan_label.Name = "stan_label";
            this.stan_label.Size = new System.Drawing.Size(232, 94);
            this.stan_label.TabIndex = 11;
            this.stan_label.Text = "----";
            this.stan_label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 34);
            this.label2.TabIndex = 10;
            this.label2.Text = "Redler R1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SV_analog_suwak
            // 
            this.SV_analog_suwak.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SV_analog_suwak.Location = new System.Drawing.Point(0, 162);
            this.SV_analog_suwak.Maximum = 27648;
            this.SV_analog_suwak.Minimum = 8294;
            this.SV_analog_suwak.Name = "SV_analog_suwak";
            this.SV_analog_suwak.Size = new System.Drawing.Size(232, 45);
            this.SV_analog_suwak.TabIndex = 18;
            this.SV_analog_suwak.Value = 8294;
            this.SV_analog_suwak.ValueChanged += new System.EventHandler(this.SV_analog_ValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 34);
            this.label1.TabIndex = 19;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SV_analog_textbox
            // 
            this.SV_analog_textbox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SV_analog_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SV_analog_textbox.Location = new System.Drawing.Point(61, 130);
            this.SV_analog_textbox.Name = "SV_analog_textbox";
            this.SV_analog_textbox.ReadOnly = true;
            this.SV_analog_textbox.Size = new System.Drawing.Size(100, 29);
            this.SV_analog_textbox.TabIndex = 20;
            this.SV_analog_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // alarm3_label
            // 
            this.alarm3_label.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.alarm3_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.alarm3_label.ForeColor = System.Drawing.Color.Blue;
            this.alarm3_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alarm3_label.Location = new System.Drawing.Point(179, 259);
            this.alarm3_label.Name = "alarm3_label";
            this.alarm3_label.Size = new System.Drawing.Size(51, 19);
            this.alarm3_label.TabIndex = 22;
            this.alarm3_label.Text = "OK";
            this.alarm3_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(0, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "Awaria falownika";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // alarm4_label
            // 
            this.alarm4_label.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.alarm4_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.alarm4_label.ForeColor = System.Drawing.Color.Blue;
            this.alarm4_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alarm4_label.Location = new System.Drawing.Point(179, 283);
            this.alarm4_label.Name = "alarm4_label";
            this.alarm4_label.Size = new System.Drawing.Size(51, 19);
            this.alarm4_label.TabIndex = 24;
            this.alarm4_label.Text = "OK";
            this.alarm4_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(0, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 24);
            this.label8.TabIndex = 23;
            this.label8.Text = "Wyłączony lokalnie";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cycle_stany
            // 
            this.cycle_stany.Enabled = true;
            this.cycle_stany.Interval = 1000;
            this.cycle_stany.Tick += new System.EventHandler(this.cycle_stany_Tick);
            // 
            // cycle_alarmy
            // 
            this.cycle_alarmy.Enabled = true;
            this.cycle_alarmy.Interval = 1000;
            this.cycle_alarmy.Tick += new System.EventHandler(this.cycle_alarmy_Tick_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(6, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "30%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(201, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "100%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(90, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "60%";
            // 
            // R1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 303);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.alarm4_label);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.alarm3_label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SV_analog_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SV_analog_suwak);
            this.Controls.Add(this.alarm2_label);
            this.Controls.Add(this.alarm1_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.stan_label);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "R1";
            this.Text = "Redler R1";
            ((System.ComponentModel.ISupportInitialize)(this.SV_analog_suwak)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label alarm2_label;
        private System.Windows.Forms.Label alarm1_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button start_button;
        public System.Windows.Forms.Label stan_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar SV_analog_suwak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SV_analog_textbox;
        private System.Windows.Forms.Label alarm3_label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label alarm4_label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer cycle_stany;
        private System.Windows.Forms.Timer cycle_alarmy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
    }
}