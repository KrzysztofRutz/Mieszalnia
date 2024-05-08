namespace PLC_SIEMENS
{
    partial class ElectricalDiagram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElectricalDiagram));
            this.schematPDF = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.schematPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // schematPDF
            // 
            this.schematPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schematPDF.Enabled = true;
            this.schematPDF.Location = new System.Drawing.Point(0, 0);
            this.schematPDF.Name = "schematPDF";
            this.schematPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("schematPDF.OcxState")));
            this.schematPDF.Size = new System.Drawing.Size(1904, 1041);
            this.schematPDF.TabIndex = 0;
            // 
            // ElectricalDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.schematPDF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ElectricalDiagram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schemat elektryczny";
            this.Load += new System.EventHandler(this.Schemat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schematPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF schematPDF;
    }
}