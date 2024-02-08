namespace PLC_SIEMENS
{
    partial class Zezwolenie_na_lok
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
            this.zezwolono_button = new System.Windows.Forms.Button();
            this.nie_zezwolono_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zezwolenie na sterowanie lokalne";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zezwolono_button
            // 
            this.zezwolono_button.BackColor = System.Drawing.SystemColors.Highlight;
            this.zezwolono_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zezwolono_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zezwolono_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zezwolono_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.zezwolono_button.Location = new System.Drawing.Point(12, 34);
            this.zezwolono_button.Name = "zezwolono_button";
            this.zezwolono_button.Size = new System.Drawing.Size(108, 52);
            this.zezwolono_button.TabIndex = 1;
            this.zezwolono_button.Text = "Zezwolono";
            this.zezwolono_button.UseVisualStyleBackColor = false;
            this.zezwolono_button.Click += new System.EventHandler(this.zezwolono_button_Click);
            // 
            // nie_zezwolono_button
            // 
            this.nie_zezwolono_button.BackColor = System.Drawing.SystemColors.Highlight;
            this.nie_zezwolono_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nie_zezwolono_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nie_zezwolono_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nie_zezwolono_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nie_zezwolono_button.Location = new System.Drawing.Point(150, 34);
            this.nie_zezwolono_button.Name = "nie_zezwolono_button";
            this.nie_zezwolono_button.Size = new System.Drawing.Size(108, 52);
            this.nie_zezwolono_button.TabIndex = 2;
            this.nie_zezwolono_button.Text = "Nie zezwolono";
            this.nie_zezwolono_button.UseVisualStyleBackColor = false;
            this.nie_zezwolono_button.Click += new System.EventHandler(this.nie_zezwolono_button_Click);
            // 
            // Zezwolenie_na_lok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(270, 93);
            this.Controls.Add(this.nie_zezwolono_button);
            this.Controls.Add(this.zezwolono_button);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Zezwolenie_na_lok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zezwolenie na sterowanie lokalne";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button zezwolono_button;
        private System.Windows.Forms.Button nie_zezwolono_button;
    }
}