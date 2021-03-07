namespace WindowsFormsApplication1.Planning
{
    partial class PlanningMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_ExportExcel = new System.Windows.Forms.Button();
            this.btn_Configure = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_content = new System.Windows.Forms.DataGridView();
            this.dtgv_header = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMHClients = new System.Windows.Forms.TabPage();
            this.tabPageFFClient = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_ContentPage2 = new System.Windows.Forms.DataGridView();
            this.dtgv_HeaderPage2 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_PrintPage2 = new System.Windows.Forms.Button();
            this.btn_ExportPage2 = new System.Windows.Forms.Button();
            this.btn_SettingPage2 = new System.Windows.Forms.Button();
            this.btn_SearchPage2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpk_ToPage2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpk_FromPage2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_content)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_header)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageMHClients.SuspendLayout();
            this.tabPageFFClient.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ContentPage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_HeaderPage2)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1380, 517);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1374, 114);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btn_print);
            this.groupBox2.Controls.Add(this.btn_ExportExcel);
            this.groupBox2.Controls.Add(this.btn_Configure);
            this.groupBox2.Controls.Add(this.btn_Search);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox2.Location = new System.Drawing.Point(690, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 108);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operation";
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_print.Image = global::WindowsFormsApplication1.Properties.Resources.printer;
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.Location = new System.Drawing.Point(110, 33);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(138, 58);
            this.btn_print.TabIndex = 3;
            this.btn_print.Text = "Print";
            this.btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_print.UseVisualStyleBackColor = false;
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportExcel.BackColor = System.Drawing.Color.White;
            this.btn_ExportExcel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_ExportExcel.Image = global::WindowsFormsApplication1.Properties.Resources.Excel_32;
            this.btn_ExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ExportExcel.Location = new System.Drawing.Point(254, 33);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Size = new System.Drawing.Size(138, 58);
            this.btn_ExportExcel.TabIndex = 2;
            this.btn_ExportExcel.Text = "Export";
            this.btn_ExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ExportExcel.UseVisualStyleBackColor = false;
            this.btn_ExportExcel.Click += new System.EventHandler(this.Btn_ExportExcel_Click);
            // 
            // btn_Configure
            // 
            this.btn_Configure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Configure.BackColor = System.Drawing.Color.White;
            this.btn_Configure.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Configure.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Configure.Image = global::WindowsFormsApplication1.Properties.Resources.setting_32;
            this.btn_Configure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Configure.Location = new System.Drawing.Point(398, 33);
            this.btn_Configure.Name = "btn_Configure";
            this.btn_Configure.Size = new System.Drawing.Size(138, 58);
            this.btn_Configure.TabIndex = 1;
            this.btn_Configure.Text = "Setting";
            this.btn_Configure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Configure.UseVisualStyleBackColor = false;
            this.btn_Configure.Click += new System.EventHandler(this.Btn_Configure_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.BackColor = System.Drawing.Color.White;
            this.btn_Search.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Search.Image = global::WindowsFormsApplication1.Properties.Resources.search;
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search.Location = new System.Drawing.Point(543, 32);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(138, 60);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtp_to);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Select";
            // 
            // dtp_to
            // 
            this.dtp_to.CalendarForeColor = System.Drawing.Color.Green;
            this.dtp_to.CalendarTitleBackColor = System.Drawing.Color.Green;
            this.dtp_to.CalendarTitleForeColor = System.Drawing.Color.Olive;
            this.dtp_to.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(347, 61);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(151, 30);
            this.dtp_to.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(342, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // dtp_from
            // 
            this.dtp_from.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(44, 61);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(151, 30);
            this.dtp_from.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dtgv_content, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dtgv_header, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 123);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1374, 391);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dtgv_content
            // 
            this.dtgv_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_content.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dtgv_content.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgv_content.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_content.Location = new System.Drawing.Point(3, 237);
            this.dtgv_content.Name = "dtgv_content";
            this.dtgv_content.RowHeadersWidth = 51;
            this.dtgv_content.RowTemplate.Height = 24;
            this.dtgv_content.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_content.Size = new System.Drawing.Size(1368, 151);
            this.dtgv_content.TabIndex = 1;
            // 
            // dtgv_header
            // 
            this.dtgv_header.AllowDrop = true;
            this.dtgv_header.AllowUserToOrderColumns = true;
            this.dtgv_header.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_header.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dtgv_header.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgv_header.ColumnHeadersHeight = 29;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_header.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_header.Location = new System.Drawing.Point(3, 3);
            this.dtgv_header.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtgv_header.Name = "dtgv_header";
            this.dtgv_header.ReadOnly = true;
            this.dtgv_header.RowHeadersWidth = 40;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_header.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_header.RowTemplate.Height = 24;
            this.dtgv_header.Size = new System.Drawing.Size(1368, 231);
            this.dtgv_header.TabIndex = 0;
            this.dtgv_header.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtgv_header_CellClick_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbl_Header);
            this.panel1.Location = new System.Drawing.Point(464, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 68);
            this.panel1.TabIndex = 4;
            // 
            // lbl_Header
            // 
            this.lbl_Header.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.Green;
            this.lbl_Header.Location = new System.Drawing.Point(3, 18);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(168, 46);
            this.lbl_Header.TabIndex = 0;
            this.lbl_Header.Text = "Header:";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageMHClients);
            this.tabControl1.Controls.Add(this.tabPageFFClient);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 96);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1400, 564);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPageMHClients
            // 
            this.tabPageMHClients.Controls.Add(this.tableLayoutPanel1);
            this.tabPageMHClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageMHClients.Location = new System.Drawing.Point(4, 34);
            this.tabPageMHClients.Name = "tabPageMHClients";
            this.tabPageMHClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMHClients.Size = new System.Drawing.Size(1392, 526);
            this.tabPageMHClients.TabIndex = 0;
            this.tabPageMHClients.Text = "MH Clients";
            this.tabPageMHClients.UseVisualStyleBackColor = true;
            // 
            // tabPageFFClient
            // 
            this.tabPageFFClient.Controls.Add(this.tableLayoutPanel4);
            this.tabPageFFClient.Location = new System.Drawing.Point(4, 34);
            this.tabPageFFClient.Name = "tabPageFFClient";
            this.tabPageFFClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFFClient.Size = new System.Drawing.Size(1392, 526);
            this.tabPageFFClient.TabIndex = 1;
            this.tabPageFFClient.Text = "FF Clients";
            this.tabPageFFClient.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1, 7);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1385, 516);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.dtgv_ContentPage2, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.dtgv_HeaderPage2, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 128);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1379, 385);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // dtgv_ContentPage2
            // 
            this.dtgv_ContentPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_ContentPage2.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dtgv_ContentPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgv_ContentPage2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ContentPage2.Location = new System.Drawing.Point(3, 234);
            this.dtgv_ContentPage2.Name = "dtgv_ContentPage2";
            this.dtgv_ContentPage2.RowHeadersWidth = 51;
            this.dtgv_ContentPage2.RowTemplate.Height = 24;
            this.dtgv_ContentPage2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_ContentPage2.Size = new System.Drawing.Size(1373, 148);
            this.dtgv_ContentPage2.TabIndex = 1;
            // 
            // dtgv_HeaderPage2
            // 
            this.dtgv_HeaderPage2.AllowDrop = true;
            this.dtgv_HeaderPage2.AllowUserToOrderColumns = true;
            this.dtgv_HeaderPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_HeaderPage2.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dtgv_HeaderPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgv_HeaderPage2.ColumnHeadersHeight = 29;
            this.dtgv_HeaderPage2.Location = new System.Drawing.Point(3, 3);
            this.dtgv_HeaderPage2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtgv_HeaderPage2.Name = "dtgv_HeaderPage2";
            this.dtgv_HeaderPage2.ReadOnly = true;
            this.dtgv_HeaderPage2.RowHeadersWidth = 40;
            this.dtgv_HeaderPage2.RowTemplate.Height = 24;
            this.dtgv_HeaderPage2.Size = new System.Drawing.Size(1373, 228);
            this.dtgv_HeaderPage2.TabIndex = 0;
            this.dtgv_HeaderPage2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtgv_HeaderPage2_CellClick);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1379, 119);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btn_PrintPage2);
            this.groupBox3.Controls.Add(this.btn_ExportPage2);
            this.groupBox3.Controls.Add(this.btn_SettingPage2);
            this.groupBox3.Controls.Add(this.btn_SearchPage2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox3.Location = new System.Drawing.Point(692, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 113);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operation";
            // 
            // btn_PrintPage2
            // 
            this.btn_PrintPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PrintPage2.BackColor = System.Drawing.Color.White;
            this.btn_PrintPage2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_PrintPage2.Image = global::WindowsFormsApplication1.Properties.Resources.printer;
            this.btn_PrintPage2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PrintPage2.Location = new System.Drawing.Point(113, 33);
            this.btn_PrintPage2.Name = "btn_PrintPage2";
            this.btn_PrintPage2.Size = new System.Drawing.Size(138, 58);
            this.btn_PrintPage2.TabIndex = 3;
            this.btn_PrintPage2.Text = "Print";
            this.btn_PrintPage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PrintPage2.UseVisualStyleBackColor = false;
            // 
            // btn_ExportPage2
            // 
            this.btn_ExportPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportPage2.BackColor = System.Drawing.Color.White;
            this.btn_ExportPage2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_ExportPage2.Image = global::WindowsFormsApplication1.Properties.Resources.Excel_32;
            this.btn_ExportPage2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ExportPage2.Location = new System.Drawing.Point(257, 33);
            this.btn_ExportPage2.Name = "btn_ExportPage2";
            this.btn_ExportPage2.Size = new System.Drawing.Size(138, 58);
            this.btn_ExportPage2.TabIndex = 2;
            this.btn_ExportPage2.Text = "Export";
            this.btn_ExportPage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ExportPage2.UseVisualStyleBackColor = false;
            this.btn_ExportPage2.Click += new System.EventHandler(this.Btn_ExportPage2_Click);
            // 
            // btn_SettingPage2
            // 
            this.btn_SettingPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SettingPage2.BackColor = System.Drawing.Color.White;
            this.btn_SettingPage2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SettingPage2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_SettingPage2.Image = global::WindowsFormsApplication1.Properties.Resources.setting_32;
            this.btn_SettingPage2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SettingPage2.Location = new System.Drawing.Point(401, 33);
            this.btn_SettingPage2.Name = "btn_SettingPage2";
            this.btn_SettingPage2.Size = new System.Drawing.Size(138, 58);
            this.btn_SettingPage2.TabIndex = 1;
            this.btn_SettingPage2.Text = "Setting";
            this.btn_SettingPage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SettingPage2.UseVisualStyleBackColor = false;
            this.btn_SettingPage2.Click += new System.EventHandler(this.Btn_SettingPage2_Click);
            // 
            // btn_SearchPage2
            // 
            this.btn_SearchPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SearchPage2.BackColor = System.Drawing.Color.White;
            this.btn_SearchPage2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SearchPage2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_SearchPage2.Image = global::WindowsFormsApplication1.Properties.Resources.search;
            this.btn_SearchPage2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SearchPage2.Location = new System.Drawing.Point(546, 32);
            this.btn_SearchPage2.Name = "btn_SearchPage2";
            this.btn_SearchPage2.Size = new System.Drawing.Size(138, 60);
            this.btn_SearchPage2.TabIndex = 0;
            this.btn_SearchPage2.Text = "Search";
            this.btn_SearchPage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SearchPage2.UseVisualStyleBackColor = false;
            this.btn_SearchPage2.Click += new System.EventHandler(this.Btn_SearchPage2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dtpk_ToPage2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.dtpk_FromPage2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(683, 113);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Date Select";
            // 
            // dtpk_ToPage2
            // 
            this.dtpk_ToPage2.CalendarForeColor = System.Drawing.Color.Green;
            this.dtpk_ToPage2.CalendarTitleBackColor = System.Drawing.Color.Green;
            this.dtpk_ToPage2.CalendarTitleForeColor = System.Drawing.Color.Olive;
            this.dtpk_ToPage2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_ToPage2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_ToPage2.Location = new System.Drawing.Point(347, 61);
            this.dtpk_ToPage2.Name = "dtpk_ToPage2";
            this.dtpk_ToPage2.Size = new System.Drawing.Size(151, 30);
            this.dtpk_ToPage2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(342, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // dtpk_FromPage2
            // 
            this.dtpk_FromPage2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_FromPage2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_FromPage2.Location = new System.Drawing.Point(44, 61);
            this.dtpk_FromPage2.Name = "dtpk_FromPage2";
            this.dtpk_FromPage2.Size = new System.Drawing.Size(151, 30);
            this.dtpk_FromPage2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "From";
            // 
            // PlanningMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 677);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "PlanningMain";
            this.Load += new System.EventHandler(this.PlanningMain_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_content)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_header)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageMHClients.ResumeLayout(false);
            this.tabPageFFClient.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ContentPage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_HeaderPage2)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgv_content;
        private System.Windows.Forms.Button btn_Configure;
        private System.Windows.Forms.DataGridView dtgv_header;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_ExportExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMHClients;
        private System.Windows.Forms.TabPage tabPageFFClient;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.DataGridView dtgv_ContentPage2;
        private System.Windows.Forms.DataGridView dtgv_HeaderPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_PrintPage2;
        private System.Windows.Forms.Button btn_ExportPage2;
        private System.Windows.Forms.Button btn_SettingPage2;
        private System.Windows.Forms.Button btn_SearchPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dtpk_ToPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpk_FromPage2;
        private System.Windows.Forms.Label label4;
    }
}