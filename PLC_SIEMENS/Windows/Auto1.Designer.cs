namespace PLC_SIEMENS
{
    partial class Auto1
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
            this.label1 = new System.Windows.Forms.Label();
            this.droga01_check = new System.Windows.Forms.CheckBox();
            this.droga02_check = new System.Windows.Forms.CheckBox();
            this.droga03_check = new System.Windows.Forms.CheckBox();
            this.droga04_check = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.zezwolenie_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.cycle_time = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 34);
            this.label2.TabIndex = 11;
            this.label2.Text = "Zasyp Z1-Z3";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 271);
            this.label1.TabIndex = 20;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // droga01_check
            // 
            this.droga01_check.AutoSize = true;
            this.droga01_check.BackColor = System.Drawing.SystemColors.ControlDark;
            this.droga01_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.droga01_check.Location = new System.Drawing.Point(5, 41);
            this.droga01_check.Name = "droga01_check";
            this.droga01_check.Size = new System.Drawing.Size(123, 24);
            this.droga01_check.TabIndex = 21;
            this.droga01_check.Text = "Z Redlera R1";
            this.droga01_check.UseVisualStyleBackColor = false;
            this.droga01_check.CheckedChanged += new System.EventHandler(this.droga01_check_CheckedChanged);
            // 
            // droga02_check
            // 
            this.droga02_check.AutoSize = true;
            this.droga02_check.BackColor = System.Drawing.SystemColors.ControlDark;
            this.droga02_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.droga02_check.Location = new System.Drawing.Point(5, 71);
            this.droga02_check.Name = "droga02_check";
            this.droga02_check.Size = new System.Drawing.Size(123, 24);
            this.droga02_check.TabIndex = 22;
            this.droga02_check.Text = "Z Redlera R3";
            this.droga02_check.UseVisualStyleBackColor = false;
            this.droga02_check.CheckedChanged += new System.EventHandler(this.droga02_check_CheckedChanged);
            // 
            // droga03_check
            // 
            this.droga03_check.AutoSize = true;
            this.droga03_check.BackColor = System.Drawing.SystemColors.ControlDark;
            this.droga03_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.droga03_check.Location = new System.Drawing.Point(5, 101);
            this.droga03_check.Name = "droga03_check";
            this.droga03_check.Size = new System.Drawing.Size(123, 24);
            this.droga03_check.TabIndex = 23;
            this.droga03_check.Text = "Z Redlera R4";
            this.droga03_check.UseVisualStyleBackColor = false;
            this.droga03_check.CheckedChanged += new System.EventHandler(this.droga03_check_CheckedChanged);
            // 
            // droga04_check
            // 
            this.droga04_check.AutoSize = true;
            this.droga04_check.BackColor = System.Drawing.SystemColors.ControlDark;
            this.droga04_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.droga04_check.Location = new System.Drawing.Point(5, 131);
            this.droga04_check.Name = "droga04_check";
            this.droga04_check.Size = new System.Drawing.Size(123, 24);
            this.droga04_check.TabIndex = 24;
            this.droga04_check.Text = "Z Redlera R7";
            this.droga04_check.UseVisualStyleBackColor = false;
            this.droga04_check.CheckedChanged += new System.EventHandler(this.droga04_check_CheckedChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(0, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 36);
            this.label3.TabIndex = 30;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zezwolenie_label
            // 
            this.zezwolenie_label.AutoSize = true;
            this.zezwolenie_label.BackColor = System.Drawing.SystemColors.ControlDark;
            this.zezwolenie_label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zezwolenie_label.ForeColor = System.Drawing.Color.Red;
            this.zezwolenie_label.Location = new System.Drawing.Point(76, 312);
            this.zezwolenie_label.Name = "zezwolenie_label";
            this.zezwolenie_label.Size = new System.Drawing.Size(179, 23);
            this.zezwolenie_label.TabIndex = 31;
            this.zezwolenie_label.Text = "NIE ZEZWOLONO";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(0, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(347, 68);
            this.label5.TabIndex = 32;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.start_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.start_button.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start_button.Location = new System.Drawing.Point(47, 348);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(105, 55);
            this.start_button.TabIndex = 33;
            this.start_button.Text = "START";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.BackColor = System.Drawing.Color.Red;
            this.stop_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stop_button.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stop_button.Location = new System.Drawing.Point(192, 348);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(105, 55);
            this.stop_button.TabIndex = 34;
            this.stop_button.Text = "STOP";
            this.stop_button.UseVisualStyleBackColor = false;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // cycle_time
            // 
            this.cycle_time.Enabled = true;
            this.cycle_time.Interval = 1000;
            this.cycle_time.Tick += new System.EventHandler(this.cycle_time_Tick);
            // 
            // Auto1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 410);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.zezwolenie_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.droga04_check);
            this.Controls.Add(this.droga03_check);
            this.Controls.Add(this.droga02_check);
            this.Controls.Add(this.droga01_check);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Auto1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AUTO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox droga01_check;
        private System.Windows.Forms.CheckBox droga02_check;
        private System.Windows.Forms.CheckBox droga03_check;
        private System.Windows.Forms.CheckBox droga04_check;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label zezwolenie_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Timer cycle_time;
    }
}