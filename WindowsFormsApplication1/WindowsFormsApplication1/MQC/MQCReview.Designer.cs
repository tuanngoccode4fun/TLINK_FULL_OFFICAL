namespace WindowsFormsApplication1.MQC
{
    partial class MQCReview
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_data = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ProductionLine = new LiveCharts.WinForms.CartesianChart();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.tpk_to = new System.Windows.Forms.DateTimePicker();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.tpk_from = new System.Windows.Forms.DateTimePicker();
            this.btn_ExportExcel = new System.Windows.Forms.Button();
            this.rd_Year = new System.Windows.Forms.RadioButton();
            this.rd_Month = new System.Windows.Forms.RadioButton();
            this.rd_Week = new System.Windows.Forms.RadioButton();
            this.rd_date = new System.Windows.Forms.RadioButton();
            this.dtpk_ToDate = new System.Windows.Forms.DateTimePicker();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtpk_fromDate = new System.Windows.Forms.DateTimePicker();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_data)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 107);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1308, 662);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dtgv_data, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 203);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1302, 456);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dtgv_data
            // 
            this.dtgv_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_data.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.dtgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_data.Location = new System.Drawing.Point(3, 276);
            this.dtgv_data.Name = "dtgv_data";
            this.dtgv_data.ReadOnly = true;
            this.dtgv_data.RowHeadersWidth = 51;
            this.dtgv_data.RowTemplate.Height = 24;
            this.dtgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_data.Size = new System.Drawing.Size(1296, 177);
            this.dtgv_data.TabIndex = 0;
            this.dtgv_data.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dtgv_data_DataBindingComplete);
            this.dtgv_data.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Dtgv_data_MouseClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.ProductionLine, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1296, 267);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // ProductionLine
            // 
            this.ProductionLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductionLine.Location = new System.Drawing.Point(3, 3);
            this.ProductionLine.Name = "ProductionLine";
            this.ProductionLine.Size = new System.Drawing.Size(1290, 261);
            this.ProductionLine.TabIndex = 1;
            this.ProductionLine.Text = "carChartProdction";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1302, 194);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.tpk_to);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.tpk_from);
            this.groupBox1.Controls.Add(this.btn_ExportExcel);
            this.groupBox1.Controls.Add(this.rd_Year);
            this.groupBox1.Controls.Add(this.rd_Month);
            this.groupBox1.Controls.Add(this.rd_Week);
            this.groupBox1.Controls.Add(this.rd_date);
            this.groupBox1.Controls.Add(this.dtpk_ToDate);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.dtpk_fromDate);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1296, 188);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(230, 98);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(58, 20);
            this.metroLabel4.TabIndex = 16;
            this.metroLabel4.Text = "To Time";
            // 
            // tpk_to
            // 
            this.tpk_to.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpk_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tpk_to.Location = new System.Drawing.Point(230, 138);
            this.tpk_to.Name = "tpk_to";
            this.tpk_to.Size = new System.Drawing.Size(147, 34);
            this.tpk_to.TabIndex = 15;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(26, 98);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(76, 20);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "From Time";
            // 
            // tpk_from
            // 
            this.tpk_from.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpk_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tpk_from.Location = new System.Drawing.Point(28, 138);
            this.tpk_from.Name = "tpk_from";
            this.tpk_from.Size = new System.Drawing.Size(147, 34);
            this.tpk_from.TabIndex = 13;
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportExcel.BackColor = System.Drawing.Color.White;
            this.btn_ExportExcel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_ExportExcel.Image = global::WindowsFormsApplication1.Properties.Resources.Excel_32;
            this.btn_ExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ExportExcel.Location = new System.Drawing.Point(943, 56);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Size = new System.Drawing.Size(178, 59);
            this.btn_ExportExcel.TabIndex = 12;
            this.btn_ExportExcel.Text = "MQC Export";
            this.btn_ExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ExportExcel.UseVisualStyleBackColor = false;
            this.btn_ExportExcel.Click += new System.EventHandler(this.Btn_ExportExcel_Click);
            // 
            // rd_Year
            // 
            this.rd_Year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rd_Year.AutoSize = true;
            this.rd_Year.Location = new System.Drawing.Point(721, 91);
            this.rd_Year.Name = "rd_Year";
            this.rd_Year.Size = new System.Drawing.Size(171, 27);
            this.rd_Year.TabIndex = 11;
            this.rd_Year.Text = "Horizontal: Year";
            this.rd_Year.UseVisualStyleBackColor = true;
            // 
            // rd_Month
            // 
            this.rd_Month.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rd_Month.AutoSize = true;
            this.rd_Month.Location = new System.Drawing.Point(721, 58);
            this.rd_Month.Name = "rd_Month";
            this.rd_Month.Size = new System.Drawing.Size(188, 27);
            this.rd_Month.TabIndex = 10;
            this.rd_Month.Text = "Horizontal: Month";
            this.rd_Month.UseVisualStyleBackColor = true;
            // 
            // rd_Week
            // 
            this.rd_Week.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rd_Week.AutoSize = true;
            this.rd_Week.Location = new System.Drawing.Point(479, 91);
            this.rd_Week.Name = "rd_Week";
            this.rd_Week.Size = new System.Drawing.Size(182, 27);
            this.rd_Week.TabIndex = 9;
            this.rd_Week.Text = "Horizontal: Week";
            this.rd_Week.UseVisualStyleBackColor = true;
            // 
            // rd_date
            // 
            this.rd_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rd_date.AutoSize = true;
            this.rd_date.Checked = true;
            this.rd_date.Location = new System.Drawing.Point(479, 57);
            this.rd_date.Name = "rd_date";
            this.rd_date.Size = new System.Drawing.Size(174, 27);
            this.rd_date.TabIndex = 8;
            this.rd_date.TabStop = true;
            this.rd_date.Text = "Horizontal: Date";
            this.rd_date.UseVisualStyleBackColor = true;
            // 
            // dtpk_ToDate
            // 
            this.dtpk_ToDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_ToDate.Location = new System.Drawing.Point(230, 55);
            this.dtpk_ToDate.Name = "dtpk_ToDate";
            this.dtpk_ToDate.Size = new System.Drawing.Size(147, 34);
            this.dtpk_ToDate.TabIndex = 7;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(230, 20);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(56, 20);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "To Date";
            // 
            // dtpk_fromDate
            // 
            this.dtpk_fromDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_fromDate.Location = new System.Drawing.Point(28, 54);
            this.dtpk_fromDate.Name = "dtpk_fromDate";
            this.dtpk_fromDate.Size = new System.Drawing.Size(147, 34);
            this.dtpk_fromDate.TabIndex = 5;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(28, 20);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 20);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "From Date";
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.BackColor = System.Drawing.Color.White;
            this.btn_Search.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Search.Image = global::WindowsFormsApplication1.Properties.Resources.search;
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search.Location = new System.Drawing.Point(1127, 56);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(163, 59);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbl_Header);
            this.panel1.Location = new System.Drawing.Point(500, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 64);
            this.panel1.TabIndex = 8;
            // 
            // lbl_Header
            // 
            this.lbl_Header.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.Green;
            this.lbl_Header.Location = new System.Drawing.Point(24, 5);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(168, 46);
            this.lbl_Header.TabIndex = 0;
            this.lbl_Header.Text = "Header:";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MQCReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 776);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MQCReview";
            this.Text = "MQCReview";
            this.Load += new System.EventHandler(this.MQCReview_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_data)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dtgv_data;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private LiveCharts.WinForms.CartesianChart ProductionLine;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpk_ToDate;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.DateTimePicker dtpk_fromDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.RadioButton rd_Year;
        private System.Windows.Forms.RadioButton rd_Month;
        private System.Windows.Forms.RadioButton rd_Week;
        private System.Windows.Forms.RadioButton rd_date;
        private System.Windows.Forms.Button btn_ExportExcel;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.DateTimePicker tpk_to;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DateTimePicker tpk_from;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}