namespace PLC_SIEMENS.Windows.Alarms
{
    partial class ActiveAlarms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveAlarms));
            this.alarmy_grid = new System.Windows.Forms.DataGridView();
            this.Data_wystapienia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alarmy_file = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.alarmy_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // alarmy_grid
            // 
            this.alarmy_grid.AllowUserToAddRows = false;
            this.alarmy_grid.AllowUserToDeleteRows = false;
            this.alarmy_grid.AllowUserToResizeColumns = false;
            this.alarmy_grid.AllowUserToResizeRows = false;
            this.alarmy_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alarmy_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.alarmy_grid.ColumnHeadersHeight = 30;
            this.alarmy_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.alarmy_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data_wystapienia,
            this.alarm_text});
            this.alarmy_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alarmy_grid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.alarmy_grid.Location = new System.Drawing.Point(0, 0);
            this.alarmy_grid.Margin = new System.Windows.Forms.Padding(2);
            this.alarmy_grid.Name = "alarmy_grid";
            this.alarmy_grid.ReadOnly = true;
            this.alarmy_grid.RowHeadersVisible = false;
            this.alarmy_grid.RowHeadersWidth = 51;
            this.alarmy_grid.RowTemplate.Height = 24;
            this.alarmy_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.alarmy_grid.Size = new System.Drawing.Size(849, 470);
            this.alarmy_grid.TabIndex = 0;
            // 
            // Data_wystapienia
            // 
            this.Data_wystapienia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Data_wystapienia.HeaderText = "Data wystąpienia";
            this.Data_wystapienia.MinimumWidth = 6;
            this.Data_wystapienia.Name = "Data_wystapienia";
            this.Data_wystapienia.ReadOnly = true;
            this.Data_wystapienia.Width = 204;
            // 
            // alarm_text
            // 
            this.alarm_text.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.alarm_text.HeaderText = "Tekst alarmu";
            this.alarm_text.MinimumWidth = 6;
            this.alarm_text.Name = "alarm_text";
            this.alarm_text.ReadOnly = true;
            // 
            // Alarmy_file
            // 
            this.Alarmy_file.Filter = "C:\\Users\\krzys\\OneDrive\\Pulpit\\SCADA\\C#_programy\\PLC_SIEMENS\\PLC_SIEMENS\\bin\\Debu" +
    "g | Alarmy";
            // 
            // ActiveAlarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 470);
            this.Controls.Add(this.alarmy_grid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActiveAlarms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarmy aktywne";
            this.Load += new System.EventHandler(this.Alarmy_aktywne_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alarmy_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_wystapienia;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_text;
        private System.Windows.Forms.OpenFileDialog Alarmy_file;
        public System.Windows.Forms.DataGridView alarmy_grid;
    }
}