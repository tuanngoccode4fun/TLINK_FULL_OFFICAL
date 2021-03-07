namespace WindowsFormsApplication1.ERPShowOrder.ERP_KPI.ERPPKI_Data.ERPPlanForm
{
    partial class DailyTagetForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_dept = new System.Windows.Forms.Label();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.txt_tagetNG = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.txt_tagetoutput = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.lbl_tagetng = new System.Windows.Forms.Label();
            this.lbl_tagetoutput = new System.Windows.Forms.Label();
            this.lbl_productioncode = new System.Windows.Forms.Label();
            this.dtp_dateplaning = new System.Windows.Forms.DateTimePicker();
            this.lbl_dateofplaning = new System.Windows.Forms.Label();
            this.cmb_productioncode = new System.Windows.Forms.ComboBox();
            this.btn_app = new System.Windows.Forms.Button();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.btn_app_m = new System.Windows.Forms.TabControl();
            this.tap_daily = new System.Windows.Forms.TabPage();
            this.tap_monthly = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_dept_m = new System.Windows.Forms.Label();
            this.cmb_dept_m = new System.Windows.Forms.ComboBox();
            this.txt_tagetNG_m = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.txt_tagetoutput_m = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lbl_tagetng_m = new System.Windows.Forms.Label();
            this.lbl_tagetoutput_m = new System.Windows.Forms.Label();
            this.lbl_productioncode_m = new System.Windows.Forms.Label();
            this.dtp_dateplaning_m = new System.Windows.Forms.DateTimePicker();
            this.lbl_dateofplaning_m = new System.Windows.Forms.Label();
            this.cmb_productioncode_m = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.btn_app_m.SuspendLayout();
            this.tap_daily.SuspendLayout();
            this.tap_monthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbl_Type);
            this.groupBox1.Controls.Add(this.cmb_type);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Controls.Add(this.lbl_dept);
            this.groupBox1.Controls.Add(this.cmb_dept);
            this.groupBox1.Controls.Add(this.txt_tagetNG);
            this.groupBox1.Controls.Add(this.txt_tagetoutput);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_edit);
            this.groupBox1.Controls.Add(this.lbl_tagetng);
            this.groupBox1.Controls.Add(this.lbl_tagetoutput);
            this.groupBox1.Controls.Add(this.lbl_productioncode);
            this.groupBox1.Controls.Add(this.dtp_dateplaning);
            this.groupBox1.Controls.Add(this.lbl_dateofplaning);
            this.groupBox1.Controls.Add(this.cmb_productioncode);
            this.groupBox1.Controls.Add(this.btn_app);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1214, 82);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(1103, 25);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(108, 41);
            this.btn_search.TabIndex = 17;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_dept
            // 
            this.lbl_dept.AutoSize = true;
            this.lbl_dept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dept.Location = new System.Drawing.Point(6, 19);
            this.lbl_dept.Name = "lbl_dept";
            this.lbl_dept.Size = new System.Drawing.Size(56, 13);
            this.lbl_dept.TabIndex = 16;
            this.lbl_dept.Text = "Your dept:";
            // 
            // cmb_dept
            // 
            this.cmb_dept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(6, 36);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(82, 21);
            this.cmb_dept.TabIndex = 15;
            this.cmb_dept.SelectedIndexChanged += new System.EventHandler(this.cmb_dept_SelectedIndexChanged);
            // 
            // txt_tagetNG
            // 
            this.txt_tagetNG.ControlId = null;
            this.txt_tagetNG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tagetNG.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.txt_tagetNG.Location = new System.Drawing.Point(607, 38);
            this.txt_tagetNG.Name = "txt_tagetNG";
            this.txt_tagetNG.Size = new System.Drawing.Size(97, 21);
            this.txt_tagetNG.TabIndex = 14;
            // 
            // txt_tagetoutput
            // 
            this.txt_tagetoutput.ControlId = null;
            this.txt_tagetoutput.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tagetoutput.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.txt_tagetoutput.Location = new System.Drawing.Point(496, 37);
            this.txt_tagetoutput.Name = "txt_tagetoutput";
            this.txt_tagetoutput.Size = new System.Drawing.Size(97, 21);
            this.txt_tagetoutput.TabIndex = 13;
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(973, 25);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(108, 41);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "Detele Row";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(845, 25);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(108, 41);
            this.btn_edit.TabIndex = 9;
            this.btn_edit.Text = "Edit  Target";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // lbl_tagetng
            // 
            this.lbl_tagetng.AutoSize = true;
            this.lbl_tagetng.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tagetng.Location = new System.Drawing.Point(604, 18);
            this.lbl_tagetng.Name = "lbl_tagetng";
            this.lbl_tagetng.Size = new System.Drawing.Size(90, 13);
            this.lbl_tagetng.TabIndex = 8;
            this.lbl_tagetng.Text = "Target Not Good:";
            // 
            // lbl_tagetoutput
            // 
            this.lbl_tagetoutput.AutoSize = true;
            this.lbl_tagetoutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tagetoutput.Location = new System.Drawing.Point(493, 17);
            this.lbl_tagetoutput.Name = "lbl_tagetoutput";
            this.lbl_tagetoutput.Size = new System.Drawing.Size(76, 13);
            this.lbl_tagetoutput.TabIndex = 6;
            this.lbl_tagetoutput.Text = "Target Output:";
            // 
            // lbl_productioncode
            // 
            this.lbl_productioncode.AutoSize = true;
            this.lbl_productioncode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_productioncode.Location = new System.Drawing.Point(226, 18);
            this.lbl_productioncode.Name = "lbl_productioncode";
            this.lbl_productioncode.Size = new System.Drawing.Size(89, 13);
            this.lbl_productioncode.TabIndex = 5;
            this.lbl_productioncode.Text = "Production Code:";
            // 
            // dtp_dateplaning
            // 
            this.dtp_dateplaning.CustomFormat = "yyyy-MM-dd";
            this.dtp_dateplaning.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_dateplaning.Location = new System.Drawing.Point(105, 37);
            this.dtp_dateplaning.Name = "dtp_dateplaning";
            this.dtp_dateplaning.Size = new System.Drawing.Size(100, 20);
            this.dtp_dateplaning.TabIndex = 4;
            // 
            // lbl_dateofplaning
            // 
            this.lbl_dateofplaning.AutoSize = true;
            this.lbl_dateofplaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dateofplaning.Location = new System.Drawing.Point(104, 20);
            this.lbl_dateofplaning.Name = "lbl_dateofplaning";
            this.lbl_dateofplaning.Size = new System.Drawing.Size(86, 13);
            this.lbl_dateofplaning.TabIndex = 3;
            this.lbl_dateofplaning.Text = "Date of Planning";
            // 
            // cmb_productioncode
            // 
            this.cmb_productioncode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_productioncode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_productioncode.FormattingEnabled = true;
            this.cmb_productioncode.Location = new System.Drawing.Point(227, 35);
            this.cmb_productioncode.Name = "cmb_productioncode";
            this.cmb_productioncode.Size = new System.Drawing.Size(150, 21);
            this.cmb_productioncode.TabIndex = 2;
            // 
            // btn_app
            // 
            this.btn_app.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_app.Location = new System.Drawing.Point(719, 24);
            this.btn_app.Name = "btn_app";
            this.btn_app.Size = new System.Drawing.Size(108, 41);
            this.btn_app.TabIndex = 0;
            this.btn_app.Text = "Add New Target";
            this.btn_app.UseVisualStyleBackColor = true;
            this.btn_app.Click += new System.EventHandler(this.btn_app_Click);
            // 
            // dgv_show
            // 
            this.dgv_show.AllowDrop = true;
            this.dgv_show.AllowUserToAddRows = false;
            this.dgv_show.AllowUserToDeleteRows = false;
            this.dgv_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_show.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Location = new System.Drawing.Point(3, 91);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_show.Size = new System.Drawing.Size(1214, 317);
            this.dgv_show.TabIndex = 4;
            this.dgv_show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_show_CellClick);
            // 
            // btn_app_m
            // 
            this.btn_app_m.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_app_m.Controls.Add(this.tap_daily);
            this.btn_app_m.Controls.Add(this.tap_monthly);
            this.btn_app_m.Location = new System.Drawing.Point(0, 66);
            this.btn_app_m.Name = "btn_app_m";
            this.btn_app_m.SelectedIndex = 0;
            this.btn_app_m.Size = new System.Drawing.Size(1228, 437);
            this.btn_app_m.TabIndex = 5;
            this.btn_app_m.Tag = "";
            // 
            // tap_daily
            // 
            this.tap_daily.Controls.Add(this.dgv_show);
            this.tap_daily.Controls.Add(this.groupBox1);
            this.tap_daily.Location = new System.Drawing.Point(4, 22);
            this.tap_daily.Name = "tap_daily";
            this.tap_daily.Padding = new System.Windows.Forms.Padding(3);
            this.tap_daily.Size = new System.Drawing.Size(1220, 411);
            this.tap_daily.TabIndex = 0;
            this.tap_daily.Text = "Daily";
            this.tap_daily.UseVisualStyleBackColor = true;
            // 
            // tap_monthly
            // 
            this.tap_monthly.Controls.Add(this.dataGridView1);
            this.tap_monthly.Controls.Add(this.groupBox2);
            this.tap_monthly.Location = new System.Drawing.Point(4, 22);
            this.tap_monthly.Name = "tap_monthly";
            this.tap_monthly.Padding = new System.Windows.Forms.Padding(3);
            this.tap_monthly.Size = new System.Drawing.Size(1220, 411);
            this.tap_monthly.TabIndex = 1;
            this.tap_monthly.Text = "Mothly";
            this.tap_monthly.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1214, 317);
            this.dataGridView1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lbl_dept_m);
            this.groupBox2.Controls.Add(this.cmb_dept_m);
            this.groupBox2.Controls.Add(this.txt_tagetNG_m);
            this.groupBox2.Controls.Add(this.txt_tagetoutput_m);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.lbl_tagetng_m);
            this.groupBox2.Controls.Add(this.lbl_tagetoutput_m);
            this.groupBox2.Controls.Add(this.lbl_productioncode_m);
            this.groupBox2.Controls.Add(this.dtp_dateplaning_m);
            this.groupBox2.Controls.Add(this.lbl_dateofplaning_m);
            this.groupBox2.Controls.Add(this.cmb_productioncode_m);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1214, 82);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1068, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 41);
            this.button1.TabIndex = 17;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbl_dept_m
            // 
            this.lbl_dept_m.AutoSize = true;
            this.lbl_dept_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dept_m.Location = new System.Drawing.Point(6, 19);
            this.lbl_dept_m.Name = "lbl_dept_m";
            this.lbl_dept_m.Size = new System.Drawing.Size(56, 13);
            this.lbl_dept_m.TabIndex = 16;
            this.lbl_dept_m.Text = "Your dept:";
            // 
            // cmb_dept_m
            // 
            this.cmb_dept_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_dept_m.FormattingEnabled = true;
            this.cmb_dept_m.Location = new System.Drawing.Point(6, 36);
            this.cmb_dept_m.Name = "cmb_dept_m";
            this.cmb_dept_m.Size = new System.Drawing.Size(82, 21);
            this.cmb_dept_m.TabIndex = 15;
            // 
            // txt_tagetNG_m
            // 
            this.txt_tagetNG_m.ControlId = null;
            this.txt_tagetNG_m.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tagetNG_m.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.txt_tagetNG_m.Location = new System.Drawing.Point(532, 40);
            this.txt_tagetNG_m.Name = "txt_tagetNG_m";
            this.txt_tagetNG_m.Size = new System.Drawing.Size(97, 21);
            this.txt_tagetNG_m.TabIndex = 14;
            // 
            // txt_tagetoutput_m
            // 
            this.txt_tagetoutput_m.ControlId = null;
            this.txt_tagetoutput_m.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tagetoutput_m.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.txt_tagetoutput_m.Location = new System.Drawing.Point(408, 39);
            this.txt_tagetoutput_m.Name = "txt_tagetoutput_m";
            this.txt_tagetoutput_m.Size = new System.Drawing.Size(97, 21);
            this.txt_tagetoutput_m.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(937, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 41);
            this.button2.TabIndex = 10;
            this.button2.Text = "Detele Row";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(807, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 41);
            this.button3.TabIndex = 9;
            this.button3.Text = "Edit  Target";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lbl_tagetng_m
            // 
            this.lbl_tagetng_m.AutoSize = true;
            this.lbl_tagetng_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tagetng_m.Location = new System.Drawing.Point(529, 20);
            this.lbl_tagetng_m.Name = "lbl_tagetng_m";
            this.lbl_tagetng_m.Size = new System.Drawing.Size(90, 13);
            this.lbl_tagetng_m.TabIndex = 8;
            this.lbl_tagetng_m.Text = "Target Not Good:";
            // 
            // lbl_tagetoutput_m
            // 
            this.lbl_tagetoutput_m.AutoSize = true;
            this.lbl_tagetoutput_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tagetoutput_m.Location = new System.Drawing.Point(410, 19);
            this.lbl_tagetoutput_m.Name = "lbl_tagetoutput_m";
            this.lbl_tagetoutput_m.Size = new System.Drawing.Size(76, 13);
            this.lbl_tagetoutput_m.TabIndex = 6;
            this.lbl_tagetoutput_m.Text = "Target Output:";
            // 
            // lbl_productioncode_m
            // 
            this.lbl_productioncode_m.AutoSize = true;
            this.lbl_productioncode_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_productioncode_m.Location = new System.Drawing.Point(238, 19);
            this.lbl_productioncode_m.Name = "lbl_productioncode_m";
            this.lbl_productioncode_m.Size = new System.Drawing.Size(89, 13);
            this.lbl_productioncode_m.TabIndex = 5;
            this.lbl_productioncode_m.Text = "Production Code:";
            // 
            // dtp_dateplaning_m
            // 
            this.dtp_dateplaning_m.CustomFormat = "yyyy-MM-dd";
            this.dtp_dateplaning_m.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_dateplaning_m.Location = new System.Drawing.Point(111, 36);
            this.dtp_dateplaning_m.Name = "dtp_dateplaning_m";
            this.dtp_dateplaning_m.Size = new System.Drawing.Size(100, 20);
            this.dtp_dateplaning_m.TabIndex = 4;
            // 
            // lbl_dateofplaning_m
            // 
            this.lbl_dateofplaning_m.AutoSize = true;
            this.lbl_dateofplaning_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dateofplaning_m.Location = new System.Drawing.Point(110, 19);
            this.lbl_dateofplaning_m.Name = "lbl_dateofplaning_m";
            this.lbl_dateofplaning_m.Size = new System.Drawing.Size(86, 13);
            this.lbl_dateofplaning_m.TabIndex = 3;
            this.lbl_dateofplaning_m.Text = "Date of Planning";
            // 
            // cmb_productioncode_m
            // 
            this.cmb_productioncode_m.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_productioncode_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_productioncode_m.FormattingEnabled = true;
            this.cmb_productioncode_m.Location = new System.Drawing.Point(239, 36);
            this.cmb_productioncode_m.Name = "cmb_productioncode_m";
            this.cmb_productioncode_m.Size = new System.Drawing.Size(150, 21);
            this.cmb_productioncode_m.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(675, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 41);
            this.button4.TabIndex = 0;
            this.button4.Text = "Add New Target";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Type.Location = new System.Drawing.Point(395, 18);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(72, 13);
            this.lbl_Type.TabIndex = 19;
            this.lbl_Type.Text = "Type Update:";
            // 
            // cmb_type
            // 
            this.cmb_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Items.AddRange(new object[] {
            "Daily",
            "Monthly"});
            this.cmb_type.Location = new System.Drawing.Point(395, 35);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(82, 21);
            this.cmb_type.TabIndex = 18;
            // 
            // DailyTagetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 500);
            this.Controls.Add(this.btn_app_m);
            this.Name = "DailyTagetForm";
            this.Text = "DailyTagetForm";
            this.Load += new System.EventHandler(this.DailyTagetForm_Load);
            this.Controls.SetChildIndex(this.btn_app_m, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.btn_app_m.ResumeLayout(false);
            this.tap_daily.ResumeLayout(false);
            this.tap_monthly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.TabControl btn_app_m;
        private System.Windows.Forms.TabPage tap_daily;
        private System.Windows.Forms.TabPage tap_monthly;
        private Com.Nidec.Mes.Framework.TextBoxCommon txt_tagetNG;
        private Com.Nidec.Mes.Framework.TextBoxCommon txt_tagetoutput;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Label lbl_tagetng;
        private System.Windows.Forms.Label lbl_tagetoutput;
        private System.Windows.Forms.Label lbl_productioncode;
        private System.Windows.Forms.DateTimePicker dtp_dateplaning;
        private System.Windows.Forms.Label lbl_dateofplaning;
        private System.Windows.Forms.ComboBox cmb_productioncode;
        private System.Windows.Forms.Button btn_app;
        private System.Windows.Forms.Label lbl_dept;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_dept_m;
        private System.Windows.Forms.ComboBox cmb_dept_m;
        private Com.Nidec.Mes.Framework.TextBoxCommon txt_tagetNG_m;
        private Com.Nidec.Mes.Framework.TextBoxCommon txt_tagetoutput_m;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbl_tagetng_m;
        private System.Windows.Forms.Label lbl_tagetoutput_m;
        private System.Windows.Forms.Label lbl_productioncode_m;
        private System.Windows.Forms.DateTimePicker dtp_dateplaning_m;
        private System.Windows.Forms.Label lbl_dateofplaning_m;
        private System.Windows.Forms.ComboBox cmb_productioncode_m;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.ComboBox cmb_type;
    }
}