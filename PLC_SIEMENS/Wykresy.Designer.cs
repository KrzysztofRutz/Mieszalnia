namespace PLC_SIEMENS
{
    partial class Wykresy
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.amper_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cycle_chart = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.amper_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // amper_chart
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.Name = "ChartArea1";
            this.amper_chart.ChartAreas.Add(chartArea1);
            this.amper_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.amper_chart.Legends.Add(legend1);
            this.amper_chart.Location = new System.Drawing.Point(0, 0);
            this.amper_chart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.amper_chart.Name = "amper_chart";
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.IndianRed;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Lime;
            series1.Name = "P1";
            this.amper_chart.Series.Add(series1);
            this.amper_chart.Size = new System.Drawing.Size(1067, 554);
            this.amper_chart.TabIndex = 0;
            this.amper_chart.Text = "chart1";
            title1.BackColor = System.Drawing.Color.Silver;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            title1.Name = "Wykres prądu";
            title1.Text = "Wykres prądu ";
            this.amper_chart.Titles.Add(title1);
            // 
            // cycle_chart
            // 
            this.cycle_chart.Enabled = true;
            this.cycle_chart.Interval = 60000;
            this.cycle_chart.Tick += new System.EventHandler(this.cycle_chart_Tick);
            // 
            // Wykresy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.amper_chart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Wykresy";
            this.Text = "Wykresy";
            this.Load += new System.EventHandler(this.Wykresy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amper_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart amper_chart;
        private System.Windows.Forms.Timer cycle_chart;
    }
}