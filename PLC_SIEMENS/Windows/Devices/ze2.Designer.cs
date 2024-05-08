namespace PLC_SIEMENS
{
    partial class ze2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ze2));
            this.label2 = new System.Windows.Forms.Label();
            this.stan_label = new System.Windows.Forms.Label();
            this.open_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.cycle_stany = new System.Windows.Forms.Timer(this.components);
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
            this.label2.Text = "Zasuwa ze2";
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
            this.close_button.Location = new System.Drawing.Point(120, 41);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(105, 55);
            this.close_button.TabIndex = 5;
            this.close_button.Text = "ZAMKNIJ";
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // cycle_stany
            // 
            this.cycle_stany.Enabled = true;
            this.cycle_stany.Interval = 300;
            this.cycle_stany.Tick += new System.EventHandler(this.cycle_Tick);
            // 
            // ze2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 128);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.open_button);
            this.Controls.Add(this.stan_label);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ze2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zasuwa ze2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button open_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Timer cycle_stany;
        public System.Windows.Forms.Label stan_label;
    }
}