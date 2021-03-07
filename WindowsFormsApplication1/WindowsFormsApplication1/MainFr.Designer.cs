


namespace WindowsFormsApplication1

{

    partial class MainFr

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
            this.tpc_main = new System.Windows.Forms.TabControl();
            this.tap_setting = new System.Windows.Forms.TabPage();
            this.btn_settingLanguage = new System.Windows.Forms.Button();
            this.btn_permission = new System.Windows.Forms.Button();
            this.btn_changepass = new System.Windows.Forms.Button();
            this.btn_registeruser = new System.Windows.Forms.Button();
            this.tap_local = new System.Windows.Forms.TabPage();
            this.btn_ipplc = new System.Windows.Forms.Button();
            this.btn_emailconfig = new System.Windows.Forms.Button();
            this.btn_order_pdc = new System.Windows.Forms.Button();
            this.btn_process = new System.Windows.Forms.Button();
            this.btn_dept = new System.Windows.Forms.Button();
            this.btn_modelline = new System.Windows.Forms.Button();
            this.btn_model = new System.Windows.Forms.Button();
            this.btn_line = new System.Windows.Forms.Button();
            this.tap_function = new System.Windows.Forms.TabPage();
            this.btn_TypingInfor = new System.Windows.Forms.Button();
            this.btn_Oven = new System.Windows.Forms.Button();
            this.btn_FinishedGoods = new System.Windows.Forms.Button();
            this.btn_SeasonalEmp = new System.Windows.Forms.Button();
            this.btn_backlogReport = new System.Windows.Forms.Button();
            this.btn_Reliability = new System.Windows.Forms.Button();
            this.btn_Manpower = new System.Windows.Forms.Button();
            this.btn_MQCReview = new System.Windows.Forms.Button();
            this.btn_wms = new System.Windows.Forms.Button();
            this.btn_Planning = new System.Windows.Forms.Button();
            this.btn_warehousealarm = new System.Windows.Forms.Button();
            this.btn_CheckMaterial = new System.Windows.Forms.Button();
            this.btn_MQC = new System.Windows.Forms.Button();
            this.btn_production = new System.Windows.Forms.Button();
            this.btn_shipping = new System.Windows.Forms.Button();
            this.btn_pqmshow = new System.Windows.Forms.Button();
            this.tpc_main.SuspendLayout();
            this.tap_setting.SuspendLayout();
            this.tap_local.SuspendLayout();
            this.tap_function.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpc_main
            // 
            this.tpc_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpc_main.Controls.Add(this.tap_setting);
            this.tpc_main.Controls.Add(this.tap_local);
            this.tpc_main.Controls.Add(this.tap_function);
            this.tpc_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpc_main.Location = new System.Drawing.Point(6, 96);
            this.tpc_main.Margin = new System.Windows.Forms.Padding(4);
            this.tpc_main.Name = "tpc_main";
            this.tpc_main.SelectedIndex = 0;
            this.tpc_main.Size = new System.Drawing.Size(999, 542);
            this.tpc_main.TabIndex = 2;
            // 
            // tap_setting
            // 
            this.tap_setting.BackColor = System.Drawing.Color.White;
            this.tap_setting.Controls.Add(this.btn_settingLanguage);
            this.tap_setting.Controls.Add(this.btn_permission);
            this.tap_setting.Controls.Add(this.btn_changepass);
            this.tap_setting.Controls.Add(this.btn_registeruser);
            this.tap_setting.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.tap_setting.Location = new System.Drawing.Point(4, 29);
            this.tap_setting.Margin = new System.Windows.Forms.Padding(4);
            this.tap_setting.Name = "tap_setting";
            this.tap_setting.Padding = new System.Windows.Forms.Padding(4);
            this.tap_setting.Size = new System.Drawing.Size(991, 509);
            this.tap_setting.TabIndex = 0;
            this.tap_setting.Text = "Setting";
            // 
            // btn_settingLanguage
            // 
            this.btn_settingLanguage.BackColor = System.Drawing.Color.White;
            this.btn_settingLanguage.Enabled = false;
            this.btn_settingLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_settingLanguage.Image = global::WindowsFormsApplication1.Properties.Resources.authorization;
            this.btn_settingLanguage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_settingLanguage.Location = new System.Drawing.Point(42, 147);
            this.btn_settingLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.btn_settingLanguage.Name = "btn_settingLanguage";
            this.btn_settingLanguage.Size = new System.Drawing.Size(191, 63);
            this.btn_settingLanguage.TabIndex = 3;
            this.btn_settingLanguage.Text = "Setting Language";
            this.btn_settingLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_settingLanguage.UseVisualStyleBackColor = false;
            this.btn_settingLanguage.Click += new System.EventHandler(this.Btn_settingLanguage_Click);
            // 
            // btn_permission
            // 
            this.btn_permission.BackColor = System.Drawing.Color.White;
            this.btn_permission.Enabled = false;
            this.btn_permission.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_permission.Image = global::WindowsFormsApplication1.Properties.Resources.authorization;
            this.btn_permission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_permission.Location = new System.Drawing.Point(532, 35);
            this.btn_permission.Margin = new System.Windows.Forms.Padding(4);
            this.btn_permission.Name = "btn_permission";
            this.btn_permission.Size = new System.Drawing.Size(190, 63);
            this.btn_permission.TabIndex = 2;
            this.btn_permission.Text = "User Permission";
            this.btn_permission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_permission.UseVisualStyleBackColor = false;
            this.btn_permission.Click += new System.EventHandler(this.btn_permission_Click);
            // 
            // btn_changepass
            // 
            this.btn_changepass.BackColor = System.Drawing.Color.White;
            this.btn_changepass.Enabled = false;
            this.btn_changepass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_changepass.Image = global::WindowsFormsApplication1.Properties.Resources.password_24;
            this.btn_changepass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_changepass.Location = new System.Drawing.Point(280, 35);
            this.btn_changepass.Margin = new System.Windows.Forms.Padding(4);
            this.btn_changepass.Name = "btn_changepass";
            this.btn_changepass.Size = new System.Drawing.Size(197, 63);
            this.btn_changepass.TabIndex = 1;
            this.btn_changepass.Text = "Change Password";
            this.btn_changepass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_changepass.UseVisualStyleBackColor = false;
            this.btn_changepass.Click += new System.EventHandler(this.btn_changepass_Click);
            // 
            // btn_registeruser
            // 
            this.btn_registeruser.BackColor = System.Drawing.Color.White;
            this.btn_registeruser.Enabled = false;
            this.btn_registeruser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_registeruser.Image = global::WindowsFormsApplication1.Properties.Resources.log_in;
            this.btn_registeruser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_registeruser.Location = new System.Drawing.Point(42, 35);
            this.btn_registeruser.Margin = new System.Windows.Forms.Padding(4);
            this.btn_registeruser.Name = "btn_registeruser";
            this.btn_registeruser.Size = new System.Drawing.Size(191, 63);
            this.btn_registeruser.TabIndex = 0;
            this.btn_registeruser.Text = "Register User";
            this.btn_registeruser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_registeruser.UseVisualStyleBackColor = false;
            this.btn_registeruser.Click += new System.EventHandler(this.btn_registeruser_Click);
            // 
            // tap_local
            // 
            this.tap_local.BackColor = System.Drawing.Color.White;
            this.tap_local.Controls.Add(this.btn_ipplc);
            this.tap_local.Controls.Add(this.btn_emailconfig);
            this.tap_local.Controls.Add(this.btn_order_pdc);
            this.tap_local.Controls.Add(this.btn_process);
            this.tap_local.Controls.Add(this.btn_dept);
            this.tap_local.Controls.Add(this.btn_modelline);
            this.tap_local.Controls.Add(this.btn_model);
            this.tap_local.Controls.Add(this.btn_line);
            this.tap_local.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.tap_local.Location = new System.Drawing.Point(4, 29);
            this.tap_local.Margin = new System.Windows.Forms.Padding(4);
            this.tap_local.Name = "tap_local";
            this.tap_local.Padding = new System.Windows.Forms.Padding(4);
            this.tap_local.Size = new System.Drawing.Size(991, 509);
            this.tap_local.TabIndex = 1;
            this.tap_local.Text = "Local";
            // 
            // btn_ipplc
            // 
            this.btn_ipplc.BackColor = System.Drawing.Color.White;
            this.btn_ipplc.Enabled = false;
            this.btn_ipplc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ipplc.Location = new System.Drawing.Point(300, 213);
            this.btn_ipplc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ipplc.Name = "btn_ipplc";
            this.btn_ipplc.Size = new System.Drawing.Size(197, 63);
            this.btn_ipplc.TabIndex = 11;
            this.btn_ipplc.Text = "IP PLC Config";
            this.btn_ipplc.UseVisualStyleBackColor = false;
            this.btn_ipplc.Click += new System.EventHandler(this.btn_ipplc_Click);
            // 
            // btn_emailconfig
            // 
            this.btn_emailconfig.BackColor = System.Drawing.Color.White;
            this.btn_emailconfig.Enabled = false;
            this.btn_emailconfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_emailconfig.Location = new System.Drawing.Point(300, 114);
            this.btn_emailconfig.Margin = new System.Windows.Forms.Padding(4);
            this.btn_emailconfig.Name = "btn_emailconfig";
            this.btn_emailconfig.Size = new System.Drawing.Size(197, 63);
            this.btn_emailconfig.TabIndex = 10;
            this.btn_emailconfig.Text = "Email Config";
            this.btn_emailconfig.UseVisualStyleBackColor = false;
            this.btn_emailconfig.Click += new System.EventHandler(this.Btn_emailconfig_Click);
            // 
            // btn_order_pdc
            // 
            this.btn_order_pdc.BackColor = System.Drawing.Color.White;
            this.btn_order_pdc.Enabled = false;
            this.btn_order_pdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_order_pdc.Location = new System.Drawing.Point(27, 319);
            this.btn_order_pdc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_order_pdc.Name = "btn_order_pdc";
            this.btn_order_pdc.Size = new System.Drawing.Size(197, 63);
            this.btn_order_pdc.TabIndex = 9;
            this.btn_order_pdc.Text = "Order-PDC";
            this.btn_order_pdc.UseVisualStyleBackColor = false;
            
            // 
            // btn_process
            // 
            this.btn_process.BackColor = System.Drawing.Color.White;
            this.btn_process.Enabled = false;
            this.btn_process.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_process.Location = new System.Drawing.Point(27, 114);
            this.btn_process.Margin = new System.Windows.Forms.Padding(4);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(197, 63);
            this.btn_process.TabIndex = 8;
            this.btn_process.Text = "Process Inspect";
            this.btn_process.UseVisualStyleBackColor = false;
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // btn_dept
            // 
            this.btn_dept.BackColor = System.Drawing.Color.White;
            this.btn_dept.Enabled = false;
            this.btn_dept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dept.Location = new System.Drawing.Point(27, 213);
            this.btn_dept.Margin = new System.Windows.Forms.Padding(4);
            this.btn_dept.Name = "btn_dept";
            this.btn_dept.Size = new System.Drawing.Size(197, 63);
            this.btn_dept.TabIndex = 7;
            this.btn_dept.Text = "Department";
            this.btn_dept.UseVisualStyleBackColor = false;
            this.btn_dept.Click += new System.EventHandler(this.btn_dept_Click_1);
            // 
            // btn_modelline
            // 
            this.btn_modelline.BackColor = System.Drawing.Color.White;
            this.btn_modelline.Enabled = false;
            this.btn_modelline.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modelline.Location = new System.Drawing.Point(553, 20);
            this.btn_modelline.Margin = new System.Windows.Forms.Padding(4);
            this.btn_modelline.Name = "btn_modelline";
            this.btn_modelline.Size = new System.Drawing.Size(197, 63);
            this.btn_modelline.TabIndex = 6;
            this.btn_modelline.Text = "Model - Line";
            this.btn_modelline.UseVisualStyleBackColor = false;
            this.btn_modelline.Click += new System.EventHandler(this.btn_modelline_Click);
            // 
            // btn_model
            // 
            this.btn_model.BackColor = System.Drawing.Color.White;
            this.btn_model.Enabled = false;
            this.btn_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_model.Location = new System.Drawing.Point(300, 20);
            this.btn_model.Margin = new System.Windows.Forms.Padding(4);
            this.btn_model.Name = "btn_model";
            this.btn_model.Size = new System.Drawing.Size(197, 63);
            this.btn_model.TabIndex = 5;
            this.btn_model.Text = "Model Master";
            this.btn_model.UseVisualStyleBackColor = false;
            this.btn_model.Click += new System.EventHandler(this.btn_modelmaster_Click);
            // 
            // btn_line
            // 
            this.btn_line.BackColor = System.Drawing.Color.White;
            this.btn_line.Enabled = false;
            this.btn_line.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_line.Location = new System.Drawing.Point(27, 20);
            this.btn_line.Margin = new System.Windows.Forms.Padding(4);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(197, 63);
            this.btn_line.TabIndex = 4;
            this.btn_line.Text = "Line Master";
            this.btn_line.UseVisualStyleBackColor = false;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // tap_function
            // 
            this.tap_function.Controls.Add(this.btn_TypingInfor);
            this.tap_function.Controls.Add(this.btn_Oven);
            this.tap_function.Controls.Add(this.btn_FinishedGoods);
            this.tap_function.Controls.Add(this.btn_SeasonalEmp);
            this.tap_function.Controls.Add(this.btn_backlogReport);
            this.tap_function.Controls.Add(this.btn_Reliability);
            this.tap_function.Controls.Add(this.btn_Manpower);
            this.tap_function.Controls.Add(this.btn_MQCReview);
            this.tap_function.Controls.Add(this.btn_wms);
            this.tap_function.Controls.Add(this.btn_Planning);
            this.tap_function.Controls.Add(this.btn_warehousealarm);
            this.tap_function.Controls.Add(this.btn_CheckMaterial);
            this.tap_function.Controls.Add(this.btn_MQC);
            this.tap_function.Controls.Add(this.btn_production);
            this.tap_function.Controls.Add(this.btn_shipping);
            this.tap_function.Controls.Add(this.btn_pqmshow);
            this.tap_function.Location = new System.Drawing.Point(4, 29);
            this.tap_function.Margin = new System.Windows.Forms.Padding(4);
            this.tap_function.Name = "tap_function";
            this.tap_function.Size = new System.Drawing.Size(991, 509);
            this.tap_function.TabIndex = 2;
            this.tap_function.Text = "Function";
            this.tap_function.UseVisualStyleBackColor = true;
            // 
            // btn_TypingInfor
            // 
            this.btn_TypingInfor.BackColor = System.Drawing.Color.White;
            this.btn_TypingInfor.Enabled = false;
            this.btn_TypingInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TypingInfor.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_TypingInfor.Image = global::WindowsFormsApplication1.Properties.Resources.materialAlarm_64;
            this.btn_TypingInfor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TypingInfor.Location = new System.Drawing.Point(5, 221);
            this.btn_TypingInfor.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TypingInfor.Name = "btn_TypingInfor";
            this.btn_TypingInfor.Size = new System.Drawing.Size(214, 72);
            this.btn_TypingInfor.TabIndex = 23;
            this.btn_TypingInfor.Text = "Product Information";
            this.btn_TypingInfor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TypingInfor.UseVisualStyleBackColor = false;
            this.btn_TypingInfor.Click += new System.EventHandler(this.btn_TypingInfor_Click);
            // 
            // btn_Oven
            // 
            this.btn_Oven.BackColor = System.Drawing.Color.White;
            this.btn_Oven.Enabled = false;
            this.btn_Oven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Oven.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Oven.Image = global::WindowsFormsApplication1.Properties.Resources.oven_64;
            this.btn_Oven.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Oven.Location = new System.Drawing.Point(469, 30);
            this.btn_Oven.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Oven.Name = "btn_Oven";
            this.btn_Oven.Size = new System.Drawing.Size(223, 72);
            this.btn_Oven.TabIndex = 22;
            this.btn_Oven.Text = "OVEN";
            this.btn_Oven.UseVisualStyleBackColor = false;
            this.btn_Oven.Click += new System.EventHandler(this.btn_Oven_Click);
            // 
            // btn_FinishedGoods
            // 
            this.btn_FinishedGoods.BackColor = System.Drawing.Color.White;
            this.btn_FinishedGoods.Enabled = false;
            this.btn_FinishedGoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FinishedGoods.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_FinishedGoods.Image = global::WindowsFormsApplication1.Properties.Resources.finishedGoods_64;
            this.btn_FinishedGoods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FinishedGoods.Location = new System.Drawing.Point(5, 125);
            this.btn_FinishedGoods.Margin = new System.Windows.Forms.Padding(4);
            this.btn_FinishedGoods.Name = "btn_FinishedGoods";
            this.btn_FinishedGoods.Size = new System.Drawing.Size(225, 72);
            this.btn_FinishedGoods.TabIndex = 21;
            this.btn_FinishedGoods.Text = "Finished Goods";
            this.btn_FinishedGoods.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FinishedGoods.UseVisualStyleBackColor = false;
            this.btn_FinishedGoods.Click += new System.EventHandler(this.btn_FinishedGoods_Click);
            // 
            // btn_SeasonalEmp
            // 
            this.btn_SeasonalEmp.BackColor = System.Drawing.Color.White;
            this.btn_SeasonalEmp.Enabled = false;
            this.btn_SeasonalEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SeasonalEmp.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_SeasonalEmp.Image = global::WindowsFormsApplication1.Properties.Resources.check_material_64;
            this.btn_SeasonalEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SeasonalEmp.Location = new System.Drawing.Point(230, 221);
            this.btn_SeasonalEmp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SeasonalEmp.Name = "btn_SeasonalEmp";
            this.btn_SeasonalEmp.Size = new System.Drawing.Size(223, 72);
            this.btn_SeasonalEmp.TabIndex = 20;
            this.btn_SeasonalEmp.Text = "Seasonal Employee";
            this.btn_SeasonalEmp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SeasonalEmp.UseVisualStyleBackColor = false;
            this.btn_SeasonalEmp.Click += new System.EventHandler(this.btn_SeasonalEmp_Click);
            // 
            // btn_backlogReport
            // 
            this.btn_backlogReport.BackColor = System.Drawing.Color.White;
            this.btn_backlogReport.Enabled = false;
            this.btn_backlogReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backlogReport.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_backlogReport.Image = global::WindowsFormsApplication1.Properties.Resources.Backlog;
            this.btn_backlogReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_backlogReport.Location = new System.Drawing.Point(469, 125);
            this.btn_backlogReport.Margin = new System.Windows.Forms.Padding(4);
            this.btn_backlogReport.Name = "btn_backlogReport";
            this.btn_backlogReport.Size = new System.Drawing.Size(247, 72);
            this.btn_backlogReport.TabIndex = 19;
            this.btn_backlogReport.Text = "Back-log Report";
            this.btn_backlogReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_backlogReport.UseVisualStyleBackColor = false;
            this.btn_backlogReport.Click += new System.EventHandler(this.Btn_backlogReport_Click);
            // 
            // btn_Reliability
            // 
            this.btn_Reliability.BackColor = System.Drawing.Color.White;
            this.btn_Reliability.Enabled = false;
            this.btn_Reliability.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reliability.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Reliability.Image = global::WindowsFormsApplication1.Properties.Resources.Reliability1;
            this.btn_Reliability.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reliability.Location = new System.Drawing.Point(238, 125);
            this.btn_Reliability.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Reliability.Name = "btn_Reliability";
            this.btn_Reliability.Size = new System.Drawing.Size(223, 72);
            this.btn_Reliability.TabIndex = 18;
            this.btn_Reliability.Text = "Reliability Report";
            this.btn_Reliability.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Reliability.UseVisualStyleBackColor = false;
            this.btn_Reliability.Click += new System.EventHandler(this.Reliability_Click_1);
            // 
            // btn_Manpower
            // 
            this.btn_Manpower.BackColor = System.Drawing.Color.White;
            this.btn_Manpower.Enabled = false;
            this.btn_Manpower.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Manpower.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Manpower.Image = global::WindowsFormsApplication1.Properties.Resources.Manpower;
            this.btn_Manpower.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Manpower.Location = new System.Drawing.Point(469, 221);
            this.btn_Manpower.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Manpower.Name = "btn_Manpower";
            this.btn_Manpower.Size = new System.Drawing.Size(223, 72);
            this.btn_Manpower.TabIndex = 17;
            this.btn_Manpower.Text = "Manpower Control";
            this.btn_Manpower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Manpower.UseVisualStyleBackColor = false;
            this.btn_Manpower.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btn_MQCReview
            // 
            this.btn_MQCReview.BackColor = System.Drawing.Color.White;
            this.btn_MQCReview.Enabled = false;
            this.btn_MQCReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MQCReview.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_MQCReview.Image = global::WindowsFormsApplication1.Properties.Resources.Analysis_64;
            this.btn_MQCReview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MQCReview.Location = new System.Drawing.Point(236, 33);
            this.btn_MQCReview.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MQCReview.Name = "btn_MQCReview";
            this.btn_MQCReview.Size = new System.Drawing.Size(223, 72);
            this.btn_MQCReview.TabIndex = 16;
            this.btn_MQCReview.Text = "MQC Report";
            this.btn_MQCReview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_MQCReview.UseVisualStyleBackColor = false;
            this.btn_MQCReview.Click += new System.EventHandler(this.Btn_MQCReview_Click_1);
            // 
            // btn_wms
            // 
            this.btn_wms.BackColor = System.Drawing.Color.White;
            this.btn_wms.Enabled = false;
            this.btn_wms.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_wms.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_wms.Image = global::WindowsFormsApplication1.Properties.Resources.warehouse_64;
            this.btn_wms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_wms.Location = new System.Drawing.Point(724, 30);
            this.btn_wms.Margin = new System.Windows.Forms.Padding(4);
            this.btn_wms.Name = "btn_wms";
            this.btn_wms.Size = new System.Drawing.Size(225, 72);
            this.btn_wms.TabIndex = 15;
            this.btn_wms.Text = "Warehouse";
            this.btn_wms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_wms.UseVisualStyleBackColor = false;
            this.btn_wms.Click += new System.EventHandler(this.Btn_wms_Click);
            // 
            // btn_Planning
            // 
            this.btn_Planning.BackColor = System.Drawing.Color.White;
            this.btn_Planning.Enabled = false;
            this.btn_Planning.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Planning.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Planning.Image = global::WindowsFormsApplication1.Properties.Resources.ProductionPlan;
            this.btn_Planning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Planning.Location = new System.Drawing.Point(724, 128);
            this.btn_Planning.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Planning.Name = "btn_Planning";
            this.btn_Planning.Size = new System.Drawing.Size(249, 69);
            this.btn_Planning.TabIndex = 14;
            this.btn_Planning.Text = "Production Planning";
            this.btn_Planning.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Planning.UseVisualStyleBackColor = false;
            this.btn_Planning.Click += new System.EventHandler(this.Btn_Planning_Click);
            // 
            // btn_warehousealarm
            // 
            this.btn_warehousealarm.BackColor = System.Drawing.Color.White;
            this.btn_warehousealarm.Enabled = false;
            this.btn_warehousealarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_warehousealarm.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_warehousealarm.Image = global::WindowsFormsApplication1.Properties.Resources.materialAlarm_64;
            this.btn_warehousealarm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_warehousealarm.Location = new System.Drawing.Point(236, 346);
            this.btn_warehousealarm.Margin = new System.Windows.Forms.Padding(4);
            this.btn_warehousealarm.Name = "btn_warehousealarm";
            this.btn_warehousealarm.Size = new System.Drawing.Size(214, 72);
            this.btn_warehousealarm.TabIndex = 13;
            this.btn_warehousealarm.Text = "Warehouse Alarm";
            this.btn_warehousealarm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_warehousealarm.UseVisualStyleBackColor = false;
            this.btn_warehousealarm.Visible = false;
            this.btn_warehousealarm.Click += new System.EventHandler(this.btn_warehousealarm_Click);
            // 
            // btn_CheckMaterial
            // 
            this.btn_CheckMaterial.BackColor = System.Drawing.Color.White;
            this.btn_CheckMaterial.Enabled = false;
            this.btn_CheckMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CheckMaterial.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_CheckMaterial.Image = global::WindowsFormsApplication1.Properties.Resources.check_material_64;
            this.btn_CheckMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CheckMaterial.Location = new System.Drawing.Point(5, 346);
            this.btn_CheckMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CheckMaterial.Name = "btn_CheckMaterial";
            this.btn_CheckMaterial.Size = new System.Drawing.Size(223, 72);
            this.btn_CheckMaterial.TabIndex = 12;
            this.btn_CheckMaterial.Text = "Material Checking";
            this.btn_CheckMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CheckMaterial.UseVisualStyleBackColor = false;
            this.btn_CheckMaterial.Visible = false;
            this.btn_CheckMaterial.Click += new System.EventHandler(this.btn_CheckMaterial_Click);
            // 
            // btn_MQC
            // 
            this.btn_MQC.BackColor = System.Drawing.Color.White;
            this.btn_MQC.Enabled = false;
            this.btn_MQC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MQC.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_MQC.Image = global::WindowsFormsApplication1.Properties.Resources.MQC_64;
            this.btn_MQC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MQC.Location = new System.Drawing.Point(5, 33);
            this.btn_MQC.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MQC.Name = "btn_MQC";
            this.btn_MQC.Size = new System.Drawing.Size(223, 72);
            this.btn_MQC.TabIndex = 10;
            this.btn_MQC.Text = "MQC";
            this.btn_MQC.UseVisualStyleBackColor = false;
            this.btn_MQC.Click += new System.EventHandler(this.Btn_MQC_Click);
            // 
            // btn_production
            // 
            this.btn_production.BackColor = System.Drawing.Color.White;
            this.btn_production.Enabled = false;
            this.btn_production.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_production.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_production.Location = new System.Drawing.Point(210, 442);
            this.btn_production.Margin = new System.Windows.Forms.Padding(4);
            this.btn_production.Name = "btn_production";
            this.btn_production.Size = new System.Drawing.Size(197, 63);
            this.btn_production.TabIndex = 9;
            this.btn_production.Text = "Production Report";
            this.btn_production.UseVisualStyleBackColor = false;
            this.btn_production.Visible = false;
            this.btn_production.Click += new System.EventHandler(this.Btn_production_Click);
            // 
            // btn_shipping
            // 
            this.btn_shipping.BackColor = System.Drawing.Color.White;
            this.btn_shipping.Enabled = false;
            this.btn_shipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_shipping.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_shipping.Location = new System.Drawing.Point(415, 442);
            this.btn_shipping.Margin = new System.Windows.Forms.Padding(4);
            this.btn_shipping.Name = "btn_shipping";
            this.btn_shipping.Size = new System.Drawing.Size(197, 63);
            this.btn_shipping.TabIndex = 6;
            this.btn_shipping.Text = "Shipping Report";
            this.btn_shipping.UseVisualStyleBackColor = false;
            this.btn_shipping.Visible = false;
            this.btn_shipping.Click += new System.EventHandler(this.Btn_OrderReport_Click);
            // 
            // btn_pqmshow
            // 
            this.btn_pqmshow.BackColor = System.Drawing.Color.White;
            this.btn_pqmshow.Enabled = false;
            this.btn_pqmshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pqmshow.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_pqmshow.Location = new System.Drawing.Point(5, 442);
            this.btn_pqmshow.Margin = new System.Windows.Forms.Padding(4);
            this.btn_pqmshow.Name = "btn_pqmshow";
            this.btn_pqmshow.Size = new System.Drawing.Size(197, 63);
            this.btn_pqmshow.TabIndex = 5;
            this.btn_pqmshow.Text = "PQM Data";
            this.btn_pqmshow.UseVisualStyleBackColor = false;
            this.btn_pqmshow.Visible = false;
            this.btn_pqmshow.Click += new System.EventHandler(this.btn_pqmshow_Click);
            // 
            // MainFr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 646);
            this.Controls.Add(this.tpc_main);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFr";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.MainFr_Load);
            this.Controls.SetChildIndex(this.tpc_main, 0);
            this.tpc_main.ResumeLayout(false);
            this.tap_setting.ResumeLayout(false);
            this.tap_local.ResumeLayout(false);
            this.tap_function.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion



        private System.Windows.Forms.TabControl tpc_main;

        private System.Windows.Forms.TabPage tap_setting;

        private System.Windows.Forms.TabPage tap_local;

        private System.Windows.Forms.Button btn_registeruser;

        private System.Windows.Forms.Button btn_changepass;

        private System.Windows.Forms.Button btn_permission;

        private System.Windows.Forms.Button btn_line;

        private System.Windows.Forms.Button btn_model;

        private System.Windows.Forms.Button btn_modelline;

        private System.Windows.Forms.Button btn_dept;

        private System.Windows.Forms.TabPage tap_function;

        private System.Windows.Forms.Button btn_pqmshow;

        private System.Windows.Forms.Button btn_process;

        private System.Windows.Forms.Button btn_shipping;

        private System.Windows.Forms.Button btn_order_pdc;

        private System.Windows.Forms.Button btn_emailconfig;

        private System.Windows.Forms.Button btn_production;

        private System.Windows.Forms.Button btn_MQC;

        private System.Windows.Forms.Button btn_CheckMaterial;

        private System.Windows.Forms.Button btn_warehousealarm;

        private System.Windows.Forms.Button btn_ipplc;

        private System.Windows.Forms.Button btn_Planning;

        private System.Windows.Forms.Button btn_wms;

        private System.Windows.Forms.Button btn_settingLanguage;
        private System.Windows.Forms.Button btn_MQCReview;
        private System.Windows.Forms.Button btn_Manpower;
        private System.Windows.Forms.Button btn_backlogReport;
        private System.Windows.Forms.Button btn_Reliability;
        private System.Windows.Forms.Button btn_SeasonalEmp;
        private System.Windows.Forms.Button btn_FinishedGoods;
        private System.Windows.Forms.Button btn_Oven;
        private System.Windows.Forms.Button btn_TypingInfor;
    }

}


