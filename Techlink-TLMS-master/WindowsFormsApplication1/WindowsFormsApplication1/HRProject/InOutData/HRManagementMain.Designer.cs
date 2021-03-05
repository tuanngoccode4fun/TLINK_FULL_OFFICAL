namespace WindowsFormsApplication1.HRProject.InOutData
{
    partial class HRManagementMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDSNhanVien = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_EmloyeeData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_InoutData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_deptDecribe = new System.Windows.Forms.Label();
            this.txt_employeeCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpk_to = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpk_from = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_department = new System.Windows.Forms.ComboBox();
            this.btn_updatePage2 = new System.Windows.Forms.Button();
            this.btn_SearchPage2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageDSNhanVien.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_EmloyeeData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_InoutData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageDSNhanVien);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 110);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1302, 606);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPageDSNhanVien
            // 
            this.tabPageDSNhanVien.Controls.Add(this.tableLayoutPanel1);
            this.tabPageDSNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageDSNhanVien.Location = new System.Drawing.Point(4, 31);
            this.tabPageDSNhanVien.Name = "tabPageDSNhanVien";
            this.tabPageDSNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDSNhanVien.Size = new System.Drawing.Size(1294, 571);
            this.tabPageDSNhanVien.TabIndex = 0;
            this.tabPageDSNhanVien.Text = "Employee List";
            this.tabPageDSNhanVien.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dtgv_EmloyeeData, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1287, 564);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtgv_EmloyeeData
            // 
            this.dtgv_EmloyeeData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_EmloyeeData.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_EmloyeeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_EmloyeeData.Location = new System.Drawing.Point(3, 103);
            this.dtgv_EmloyeeData.Name = "dtgv_EmloyeeData";
            this.dtgv_EmloyeeData.ReadOnly = true;
            this.dtgv_EmloyeeData.RowHeadersWidth = 51;
            this.dtgv_EmloyeeData.RowTemplate.Height = 24;
            this.dtgv_EmloyeeData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_EmloyeeData.Size = new System.Drawing.Size(1023, 458);
            this.dtgv_EmloyeeData.TabIndex = 0;
            this.dtgv_EmloyeeData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtgv_EmloyeeData_CellContentClick);
            this.dtgv_EmloyeeData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dtgv_EmloyeeData_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_Update);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1023, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.BackColor = System.Drawing.Color.White;
            this.btn_Update.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Update.Image = global::WindowsFormsApplication1.Properties.Resources.refresh;
            this.btn_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Update.Location = new System.Drawing.Point(709, 28);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(124, 60);
            this.btn_Update.TabIndex = 2;
            this.btn_Update.Text = "Update";
            this.btn_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.BackColor = System.Drawing.Color.White;
            this.btn_Search.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Search.Image = global::WindowsFormsApplication1.Properties.Resources.search;
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search.Location = new System.Drawing.Point(865, 28);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(138, 60);
            this.btn_Search.TabIndex = 1;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1294, 571);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "In-Out Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dtgv_InoutData, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(-4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1295, 567);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dtgv_InoutData
            // 
            this.dtgv_InoutData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_InoutData.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_InoutData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_InoutData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_InoutData.Location = new System.Drawing.Point(3, 123);
            this.dtgv_InoutData.Name = "dtgv_InoutData";
            this.dtgv_InoutData.ReadOnly = true;
            this.dtgv_InoutData.RowHeadersWidth = 51;
            this.dtgv_InoutData.RowTemplate.Height = 24;
            this.dtgv_InoutData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_InoutData.Size = new System.Drawing.Size(1289, 441);
            this.dtgv_InoutData.TabIndex = 1;
            this.dtgv_InoutData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dtgv_InoutData_DataBindingComplete);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lb_deptDecribe);
            this.groupBox2.Controls.Add(this.txt_employeeCode);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpk_to);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpk_from);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cb_department);
            this.groupBox2.Controls.Add(this.btn_updatePage2);
            this.groupBox2.Controls.Add(this.btn_SearchPage2);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1289, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // lb_deptDecribe
            // 
            this.lb_deptDecribe.AutoSize = true;
            this.lb_deptDecribe.Location = new System.Drawing.Point(318, 30);
            this.lb_deptDecribe.Name = "lb_deptDecribe";
            this.lb_deptDecribe.Size = new System.Drawing.Size(0, 22);
            this.lb_deptDecribe.TabIndex = 13;
            // 
            // txt_employeeCode
            // 
            this.txt_employeeCode.Location = new System.Drawing.Point(149, 69);
            this.txt_employeeCode.Name = "txt_employeeCode";
            this.txt_employeeCode.Size = new System.Drawing.Size(153, 30);
            this.txt_employeeCode.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Employee Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(768, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "To";
            // 
            // dtpk_to
            // 
            this.dtpk_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_to.Location = new System.Drawing.Point(772, 69);
            this.dtpk_to.Name = "dtpk_to";
            this.dtpk_to.Size = new System.Drawing.Size(159, 30);
            this.dtpk_to.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(580, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "From";
            // 
            // dtpk_from
            // 
            this.dtpk_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_from.Location = new System.Drawing.Point(584, 69);
            this.dtpk_from.Name = "dtpk_from";
            this.dtpk_from.Size = new System.Drawing.Size(159, 30);
            this.dtpk_from.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Department";
            // 
            // cb_department
            // 
            this.cb_department.FormattingEnabled = true;
            this.cb_department.Location = new System.Drawing.Point(143, 22);
            this.cb_department.Name = "cb_department";
            this.cb_department.Size = new System.Drawing.Size(159, 30);
            this.cb_department.TabIndex = 5;
            this.cb_department.SelectedIndexChanged += new System.EventHandler(this.Cb_department_SelectedIndexChanged);
            // 
            // btn_updatePage2
            // 
            this.btn_updatePage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updatePage2.BackColor = System.Drawing.Color.White;
            this.btn_updatePage2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updatePage2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_updatePage2.Image = global::WindowsFormsApplication1.Properties.Resources.refresh;
            this.btn_updatePage2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_updatePage2.Location = new System.Drawing.Point(989, 39);
            this.btn_updatePage2.Name = "btn_updatePage2";
            this.btn_updatePage2.Size = new System.Drawing.Size(124, 60);
            this.btn_updatePage2.TabIndex = 4;
            this.btn_updatePage2.Text = "Update";
            this.btn_updatePage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_updatePage2.UseVisualStyleBackColor = false;
            // 
            // btn_SearchPage2
            // 
            this.btn_SearchPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SearchPage2.BackColor = System.Drawing.Color.White;
            this.btn_SearchPage2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SearchPage2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_SearchPage2.Image = global::WindowsFormsApplication1.Properties.Resources.search;
            this.btn_SearchPage2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SearchPage2.Location = new System.Drawing.Point(1145, 39);
            this.btn_SearchPage2.Name = "btn_SearchPage2";
            this.btn_SearchPage2.Size = new System.Drawing.Size(138, 60);
            this.btn_SearchPage2.TabIndex = 3;
            this.btn_SearchPage2.Text = "Search";
            this.btn_SearchPage2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SearchPage2.UseVisualStyleBackColor = false;
            this.btn_SearchPage2.Click += new System.EventHandler(this.Btn_SearchPage2_Click);
            // 
            // HRManagementMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 734);
            this.Controls.Add(this.tabControl1);
            this.Name = "HRManagementMain";
            this.Text = "HRManagementMain";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDSNhanVien.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_EmloyeeData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_InoutData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDSNhanVien;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dtgv_EmloyeeData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dtgv_InoutData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_employeeCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpk_to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpk_from;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_department;
        private System.Windows.Forms.Button btn_updatePage2;
        private System.Windows.Forms.Button btn_SearchPage2;
        private System.Windows.Forms.Label lb_deptDecribe;
    }
}