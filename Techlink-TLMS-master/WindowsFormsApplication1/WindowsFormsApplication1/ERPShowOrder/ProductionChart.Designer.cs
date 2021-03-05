namespace WindowsFormsApplication1.ERPShowOrder
{
    partial class ProductionChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Production_Planning_Code = new System.Windows.Forms.TextBox();
            this.txt_Production_Planning_No = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chartIONG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.txt_Product_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Product_Code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartIONG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Production_Planning_Code:";
            // 
            // txt_Production_Planning_Code
            // 
            this.txt_Production_Planning_Code.Location = new System.Drawing.Point(13, 89);
            this.txt_Production_Planning_Code.Name = "txt_Production_Planning_Code";
            this.txt_Production_Planning_Code.Size = new System.Drawing.Size(86, 20);
            this.txt_Production_Planning_Code.TabIndex = 4;
            // 
            // txt_Production_Planning_No
            // 
            this.txt_Production_Planning_No.Location = new System.Drawing.Point(184, 89);
            this.txt_Production_Planning_No.Name = "txt_Production_Planning_No";
            this.txt_Production_Planning_No.Size = new System.Drawing.Size(199, 20);
            this.txt_Production_Planning_No.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Production_Planning_No:";
            // 
            // chartIONG
            // 
            this.chartIONG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartIONG.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartIONG.Legends.Add(legend2);
            this.chartIONG.Location = new System.Drawing.Point(0, 115);
            this.chartIONG.Name = "chartIONG";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartIONG.Series.Add(series2);
            this.chartIONG.Size = new System.Drawing.Size(993, 425);
            this.chartIONG.TabIndex = 7;
            this.chartIONG.Text = "chart1";
            title2.Name = "Title1";
            this.chartIONG.Titles.Add(title2);
            // 
            // dgv_show
            // 
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgv_show.Location = new System.Drawing.Point(965, 60);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.Size = new System.Drawing.Size(360, 476);
            this.dgv_show.TabIndex = 8;
            // 
            // txt_Product_Name
            // 
            this.txt_Product_Name.Location = new System.Drawing.Point(625, 89);
            this.txt_Product_Name.Name = "txt_Product_Name";
            this.txt_Product_Name.Size = new System.Drawing.Size(199, 20);
            this.txt_Product_Name.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Product_Name:";
            // 
            // txt_Product_Code
            // 
            this.txt_Product_Code.Location = new System.Drawing.Point(454, 89);
            this.txt_Product_Code.Name = "txt_Product_Code";
            this.txt_Product_Code.Size = new System.Drawing.Size(86, 20);
            this.txt_Product_Code.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Product_Code:";
            // 
            // ProductionChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 536);
            this.Controls.Add(this.txt_Product_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Product_Code);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_show);
            this.Controls.Add(this.chartIONG);
            this.Controls.Add(this.txt_Production_Planning_No);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Production_Planning_Code);
            this.Controls.Add(this.label1);
            this.Name = "ProductionChart";
            this.Text = "ProductionChart";
            this.Load += new System.EventHandler(this.ProductionChart_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txt_Production_Planning_Code, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_Production_Planning_No, 0);
            this.Controls.SetChildIndex(this.chartIONG, 0);
            this.Controls.SetChildIndex(this.dgv_show, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txt_Product_Code, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_Product_Name, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chartIONG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Production_Planning_Code;
        private System.Windows.Forms.TextBox txt_Production_Planning_No;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIONG;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.TextBox txt_Product_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Product_Code;
        private System.Windows.Forms.Label label4;
    }
}