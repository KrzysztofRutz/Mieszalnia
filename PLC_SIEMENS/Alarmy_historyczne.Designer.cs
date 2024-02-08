namespace PLC_SIEMENS
{
    partial class Alarmy_historyczne
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
            this.alarmyhis_grid = new System.Windows.Forms.DataGridView();
            this.Data_wystapienia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.alarmyhis_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // alarmyhis_grid
            // 
            this.alarmyhis_grid.AllowUserToAddRows = false;
            this.alarmyhis_grid.AllowUserToDeleteRows = false;
            this.alarmyhis_grid.AllowUserToResizeColumns = false;
            this.alarmyhis_grid.AllowUserToResizeRows = false;
            this.alarmyhis_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alarmyhis_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.alarmyhis_grid.ColumnHeadersHeight = 30;
            this.alarmyhis_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.alarmyhis_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data_wystapienia,
            this.alarm_text});
            this.alarmyhis_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alarmyhis_grid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.alarmyhis_grid.Location = new System.Drawing.Point(0, 0);
            this.alarmyhis_grid.Margin = new System.Windows.Forms.Padding(2);
            this.alarmyhis_grid.Name = "alarmyhis_grid";
            this.alarmyhis_grid.ReadOnly = true;
            this.alarmyhis_grid.RowHeadersVisible = false;
            this.alarmyhis_grid.RowHeadersWidth = 51;
            this.alarmyhis_grid.RowTemplate.Height = 24;
            this.alarmyhis_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.alarmyhis_grid.Size = new System.Drawing.Size(842, 500);
            this.alarmyhis_grid.TabIndex = 1;
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
            // Alarmy_historyczne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 500);
            this.Controls.Add(this.alarmyhis_grid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Alarmy_historyczne";
            this.Text = "Alarmy historyczne";
            this.Load += new System.EventHandler(this.Alarmy_historyczne_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alarmyhis_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView alarmyhis_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_wystapienia;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_text;
    }
}