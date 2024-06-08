namespace PLC_SIEMENS.Windows
{
    partial class Error_PLC
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
            this.label1 = new System.Windows.Forms.Label();
            this.CloseApp_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brak połączenia z PLC!!!";
            // 
            // CloseApp_button
            // 
            this.CloseApp_button.Location = new System.Drawing.Point(141, 75);
            this.CloseApp_button.Name = "CloseApp_button";
            this.CloseApp_button.Size = new System.Drawing.Size(124, 23);
            this.CloseApp_button.TabIndex = 1;
            this.CloseApp_button.Text = "Zamknij aplikację ";
            this.CloseApp_button.UseVisualStyleBackColor = true;
            this.CloseApp_button.Click += new System.EventHandler(this.CloseApp_button_Click);
            // 
            // Error_PLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 110);
            this.ControlBox = false;
            this.Controls.Add(this.CloseApp_button);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Error_PLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error PLC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Error_PLC_FormClosed);
            this.Load += new System.EventHandler(this.Error_PLC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseApp_button;
    }
}