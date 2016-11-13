namespace Whatsapp_analyser
{
    partial class SelectFileToAnalyse
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.VisualChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnMessagePersonRate = new System.Windows.Forms.Button();
            this.BtnMessagePerHour = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LblFirstMessage = new System.Windows.Forms.Label();
            this.btnMessagePerDay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VisualChart)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.Location = new System.Drawing.Point(29, 25);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenFile.TabIndex = 0;
            this.BtnOpenFile.Text = "Select file";
            this.BtnOpenFile.UseVisualStyleBackColor = true;
            this.BtnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a file to analyse:";
            // 
            // VisualChart
            // 
            chartArea1.Name = "ChartArea1";
            this.VisualChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.VisualChart.Legends.Add(legend1);
            this.VisualChart.Location = new System.Drawing.Point(147, 25);
            this.VisualChart.Name = "VisualChart";
            this.VisualChart.Size = new System.Drawing.Size(934, 382);
            this.VisualChart.TabIndex = 2;
            // 
            // BtnMessagePersonRate
            // 
            this.BtnMessagePersonRate.Location = new System.Drawing.Point(145, 414);
            this.BtnMessagePersonRate.Name = "BtnMessagePersonRate";
            this.BtnMessagePersonRate.Size = new System.Drawing.Size(114, 23);
            this.BtnMessagePersonRate.TabIndex = 3;
            this.BtnMessagePersonRate.Text = "Message per person";
            this.BtnMessagePersonRate.UseVisualStyleBackColor = true;
            this.BtnMessagePersonRate.Click += new System.EventHandler(this.BtnMessagePersonRate_Click);
            // 
            // BtnMessagePerHour
            // 
            this.BtnMessagePerHour.Location = new System.Drawing.Point(284, 413);
            this.BtnMessagePerHour.Name = "BtnMessagePerHour";
            this.BtnMessagePerHour.Size = new System.Drawing.Size(100, 23);
            this.BtnMessagePerHour.TabIndex = 4;
            this.BtnMessagePerHour.Text = "Message per hour";
            this.BtnMessagePerHour.UseVisualStyleBackColor = true;
            this.BtnMessagePerHour.Click += new System.EventHandler(this.BtnMessagePerHour_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "First message:";
            // 
            // LblFirstMessage
            // 
            this.LblFirstMessage.AutoSize = true;
            this.LblFirstMessage.Location = new System.Drawing.Point(32, 72);
            this.LblFirstMessage.Name = "LblFirstMessage";
            this.LblFirstMessage.Size = new System.Drawing.Size(0, 13);
            this.LblFirstMessage.TabIndex = 6;
            // 
            // btnMessagePerDay
            // 
            this.btnMessagePerDay.Location = new System.Drawing.Point(403, 413);
            this.btnMessagePerDay.Name = "btnMessagePerDay";
            this.btnMessagePerDay.Size = new System.Drawing.Size(100, 23);
            this.btnMessagePerDay.TabIndex = 7;
            this.btnMessagePerDay.Text = "Message per day";
            this.btnMessagePerDay.UseVisualStyleBackColor = true;
            this.btnMessagePerDay.Click += new System.EventHandler(this.btnMessagePerDay_Click);
            // 
            // SelectFileToAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 448);
            this.Controls.Add(this.btnMessagePerDay);
            this.Controls.Add(this.LblFirstMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnMessagePerHour);
            this.Controls.Add(this.BtnMessagePersonRate);
            this.Controls.Add(this.VisualChart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnOpenFile);
            this.Name = "SelectFileToAnalyse";
            this.Text = "SelectFileToAnalyse";
            ((System.ComponentModel.ISupportInitialize)(this.VisualChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart VisualChart;
        private System.Windows.Forms.Button BtnMessagePersonRate;
        private System.Windows.Forms.Button BtnMessagePerHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblFirstMessage;
        private System.Windows.Forms.Button btnMessagePerDay;
    }
}

