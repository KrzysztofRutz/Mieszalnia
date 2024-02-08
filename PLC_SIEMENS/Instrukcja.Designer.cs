namespace PLC_SIEMENS
{
    partial class Instrukcja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instrukcja));
            this.InstrukcjaPDF = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.InstrukcjaPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // InstrukcjaPDF
            // 
            this.InstrukcjaPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstrukcjaPDF.Enabled = true;
            this.InstrukcjaPDF.Location = new System.Drawing.Point(0, 0);
            this.InstrukcjaPDF.Name = "InstrukcjaPDF";
            this.InstrukcjaPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("InstrukcjaPDF.OcxState")));
            this.InstrukcjaPDF.Size = new System.Drawing.Size(1904, 1041);
            this.InstrukcjaPDF.TabIndex = 0;
            // 
            // Instrukcja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.InstrukcjaPDF);
            this.Name = "Instrukcja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instrukcja";
            this.Load += new System.EventHandler(this.Instrukcja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InstrukcjaPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF InstrukcjaPDF;
    }
}