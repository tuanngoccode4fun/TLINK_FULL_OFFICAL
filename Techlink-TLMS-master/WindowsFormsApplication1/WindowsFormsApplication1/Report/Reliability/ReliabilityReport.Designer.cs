namespace WindowsFormsApplication1.Report.Reliability
{
    partial class ReliabilityReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_periodtime = new System.Windows.Forms.RadioButton();
            this.radio_Year = new System.Windows.Forms.RadioButton();
            this.radio_thisMonth = new System.Windows.Forms.RadioButton();
            this.radio_Week = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpk_To = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpk_From = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_ExportExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1256, 518);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.4F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.6F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1250, 134);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radio_periodtime);
            this.groupBox1.Controls.Add(this.radio_Year);
            this.groupBox1.Controls.Add(this.radio_thisMonth);
            this.groupBox1.Controls.Add(this.radio_Week);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpk_To);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpk_From);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Period Time";
            // 
            // radio_periodtime
            // 
            this.radio_periodtime.AutoSize = true;
            this.radio_periodtime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_periodtime.Location = new System.Drawing.Point(707, 73);
            this.radio_periodtime.Name = "radio_periodtime";
            this.radio_periodtime.Size = new System.Drawing.Size(142, 26);
            this.radio_periodtime.TabIndex = 7;
            this.radio_periodtime.TabStop = true;
            this.radio_periodtime.Text = "Flexible Time";
            this.radio_periodtime.UseVisualStyleBackColor = true;
            this.radio_periodtime.CheckedChanged += new System.EventHandler(this.Radio_periodtime_CheckedChanged);
            // 
            // radio_Year
            // 
            this.radio_Year.AutoSize = true;
            this.radio_Year.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Year.Location = new System.Drawing.Point(707, 42);
            this.radio_Year.Name = "radio_Year";
            this.radio_Year.Size = new System.Drawing.Size(127, 26);
            this.radio_Year.TabIndex = 6;
            this.radio_Year.TabStop = true;
            this.radio_Year.Text = "In This Year";
            this.radio_Year.UseVisualStyleBackColor = true;
            this.radio_Year.CheckedChanged += new System.EventHandler(this.Radio_Year_CheckedChanged);
            // 
            // radio_thisMonth
            // 
            this.radio_thisMonth.AutoSize = true;
            this.radio_thisMonth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_thisMonth.Location = new System.Drawing.Point(398, 73);
            this.radio_thisMonth.Name = "radio_thisMonth";
            this.radio_thisMonth.Size = new System.Drawing.Size(141, 26);
            this.radio_thisMonth.TabIndex = 5;
            this.radio_thisMonth.TabStop = true;
            this.radio_thisMonth.Text = "In This Month";
            this.radio_thisMonth.UseVisualStyleBackColor = true;
            this.radio_thisMonth.CheckedChanged += new System.EventHandler(this.Radio_thisMonth_CheckedChanged);
            // 
            // radio_Week
            // 
            this.radio_Week.AutoSize = true;
            this.radio_Week.Checked = true;
            this.radio_Week.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Week.Location = new System.Drawing.Point(398, 42);
            this.radio_Week.Name = "radio_Week";
            this.radio_Week.Size = new System.Drawing.Size(134, 26);
            this.radio_Week.TabIndex = 4;
            this.radio_Week.TabStop = true;
            this.radio_Week.Text = "In This Week";
            this.radio_Week.UseVisualStyleBackColor = true;
            this.radio_Week.CheckedChanged += new System.EventHandler(this.Radio_Week_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // dtpk_To
            // 
            this.dtpk_To.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_To.Location = new System.Drawing.Point(105, 75);
            this.dtpk_To.Name = "dtpk_To";
            this.dtpk_To.Size = new System.Drawing.Size(169, 30);
            this.dtpk_To.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // dtpk_From
            // 
            this.dtpk_From.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_From.Location = new System.Drawing.Point(105, 42);
            this.dtpk_From.Name = "dtpk_From";
            this.dtpk_From.Size = new System.Drawing.Size(169, 30);
            this.dtpk_From.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btn_ExportExcel);
            this.groupBox2.Location = new System.Drawing.Point(958, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 128);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.button1.Image = global::WindowsFormsApplication1.Properties.Resources.chart_search_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(13, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 63);
            this.button1.TabIndex = 4;
            this.button1.Text = "Draw Chart";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportExcel.BackColor = System.Drawing.Color.White;
            this.btn_ExportExcel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_ExportExcel.Image = global::WindowsFormsApplication1.Properties.Resources.Excel_32;
            this.btn_ExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ExportExcel.Location = new System.Drawing.Point(151, 36);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Size = new System.Drawing.Size(132, 63);
            this.btn_ExportExcel.TabIndex = 3;
            this.btn_ExportExcel.Text = "Export Excel";
            this.btn_ExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ExportExcel.UseVisualStyleBackColor = false;
            this.btn_ExportExcel.Click += new System.EventHandler(this.Btn_ExportExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbl_Header);
            this.panel1.Location = new System.Drawing.Point(447, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 68);
            this.panel1.TabIndex = 5;
            // 
            // lbl_Header
            // 
            this.lbl_Header.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.Green;
            this.lbl_Header.Location = new System.Drawing.Point(11, 12);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(168, 46);
            this.lbl_Header.TabIndex = 0;
            this.lbl_Header.Text = "Header:";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReliabilityReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 640);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReliabilityReport";
            this.Text = "ReliabilityReport";
            this.Load += new System.EventHandler(this.ReliabilityReport_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_periodtime;
        private System.Windows.Forms.RadioButton radio_Year;
        private System.Windows.Forms.RadioButton radio_thisMonth;
        private System.Windows.Forms.RadioButton radio_Week;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpk_To;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpk_From;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_ExportExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Header;
    }
}