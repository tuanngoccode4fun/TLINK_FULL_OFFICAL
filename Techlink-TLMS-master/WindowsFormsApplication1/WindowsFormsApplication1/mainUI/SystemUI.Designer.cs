namespace WindowsFormsApplication1.mainUI
{
    partial class SystemUI
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
            this.button5 = new System.Windows.Forms.Button();
            this.xuiWidgetPanel1 = new XanderUI.XUIWidgetPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_settingLanguage = new System.Windows.Forms.Button();
            this.btn_ipplc = new System.Windows.Forms.Button();
            this.btn_emailconfig = new System.Windows.Forms.Button();
            this.btn_process = new System.Windows.Forms.Button();
            this.btn_dept = new System.Windows.Forms.Button();
            this.btn_modelline = new System.Windows.Forms.Button();
            this.btn_model = new System.Windows.Forms.Button();
            this.btn_line = new System.Windows.Forms.Button();
            this.xuiWidgetPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(12, 6);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 31);
            this.button5.TabIndex = 14;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // xuiWidgetPanel1
            // 
            this.xuiWidgetPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xuiWidgetPanel1.Controls.Add(this.groupBox1);
            this.xuiWidgetPanel1.ControlsAsWidgets = false;
            this.xuiWidgetPanel1.Location = new System.Drawing.Point(1, 40);
            this.xuiWidgetPanel1.Name = "xuiWidgetPanel1";
            this.xuiWidgetPanel1.Size = new System.Drawing.Size(880, 401);
            this.xuiWidgetPanel1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox1.Controls.Add(this.btn_settingLanguage);
            this.groupBox1.Controls.Add(this.btn_ipplc);
            this.groupBox1.Controls.Add(this.btn_emailconfig);
            this.groupBox1.Controls.Add(this.btn_process);
            this.groupBox1.Controls.Add(this.btn_dept);
            this.groupBox1.Controls.Add(this.btn_modelline);
            this.groupBox1.Controls.Add(this.btn_model);
            this.groupBox1.Controls.Add(this.btn_line);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 397);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_settingLanguage
            // 
            this.btn_settingLanguage.BackColor = System.Drawing.Color.White;
            this.btn_settingLanguage.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_settingLanguage.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_settingLanguage.Image = global::WindowsFormsApplication1.Properties.Resources.authorization;
            this.btn_settingLanguage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_settingLanguage.Location = new System.Drawing.Point(510, 112);
            this.btn_settingLanguage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_settingLanguage.Name = "btn_settingLanguage";
            this.btn_settingLanguage.Size = new System.Drawing.Size(197, 63);
            this.btn_settingLanguage.TabIndex = 20;
            this.btn_settingLanguage.Text = "Setting Language";
            this.btn_settingLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_settingLanguage.UseVisualStyleBackColor = false;
            this.btn_settingLanguage.Click += new System.EventHandler(this.btn_settingLanguage_Click);
            // 
            // btn_ipplc
            // 
            this.btn_ipplc.BackColor = System.Drawing.Color.White;
            this.btn_ipplc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_ipplc.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_ipplc.Location = new System.Drawing.Point(257, 211);
            this.btn_ipplc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ipplc.Name = "btn_ipplc";
            this.btn_ipplc.Size = new System.Drawing.Size(197, 63);
            this.btn_ipplc.TabIndex = 19;
            this.btn_ipplc.Text = "IP PLC Config";
            this.btn_ipplc.UseVisualStyleBackColor = false;
            this.btn_ipplc.Click += new System.EventHandler(this.btn_ipplc_Click);
            // 
            // btn_emailconfig
            // 
            this.btn_emailconfig.BackColor = System.Drawing.Color.White;
            this.btn_emailconfig.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_emailconfig.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_emailconfig.Location = new System.Drawing.Point(257, 112);
            this.btn_emailconfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_emailconfig.Name = "btn_emailconfig";
            this.btn_emailconfig.Size = new System.Drawing.Size(197, 63);
            this.btn_emailconfig.TabIndex = 18;
            this.btn_emailconfig.Text = "Email Config";
            this.btn_emailconfig.UseVisualStyleBackColor = false;
            this.btn_emailconfig.Click += new System.EventHandler(this.btn_emailconfig_Click);
            // 
            // btn_process
            // 
            this.btn_process.BackColor = System.Drawing.Color.White;
            this.btn_process.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_process.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_process.Location = new System.Drawing.Point(34, 108);
            this.btn_process.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(197, 63);
            this.btn_process.TabIndex = 16;
            this.btn_process.Text = "Process Inspect";
            this.btn_process.UseVisualStyleBackColor = false;
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // btn_dept
            // 
            this.btn_dept.BackColor = System.Drawing.Color.White;
            this.btn_dept.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_dept.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_dept.Location = new System.Drawing.Point(34, 207);
            this.btn_dept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_dept.Name = "btn_dept";
            this.btn_dept.Size = new System.Drawing.Size(197, 63);
            this.btn_dept.TabIndex = 15;
            this.btn_dept.Text = "Department";
            this.btn_dept.UseVisualStyleBackColor = false;
            this.btn_dept.Click += new System.EventHandler(this.btn_dept_Click);
            // 
            // btn_modelline
            // 
            this.btn_modelline.BackColor = System.Drawing.Color.White;
            this.btn_modelline.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_modelline.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_modelline.Location = new System.Drawing.Point(510, 18);
            this.btn_modelline.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_modelline.Name = "btn_modelline";
            this.btn_modelline.Size = new System.Drawing.Size(197, 63);
            this.btn_modelline.TabIndex = 14;
            this.btn_modelline.Text = "Model - Line";
            this.btn_modelline.UseVisualStyleBackColor = false;
            this.btn_modelline.Click += new System.EventHandler(this.btn_modelline_Click);
            // 
            // btn_model
            // 
            this.btn_model.BackColor = System.Drawing.Color.White;
            this.btn_model.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_model.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_model.Location = new System.Drawing.Point(257, 18);
            this.btn_model.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_model.Name = "btn_model";
            this.btn_model.Size = new System.Drawing.Size(197, 63);
            this.btn_model.TabIndex = 13;
            this.btn_model.Text = "Model Master";
            this.btn_model.UseVisualStyleBackColor = false;
            this.btn_model.Click += new System.EventHandler(this.btn_model_Click);
            // 
            // btn_line
            // 
            this.btn_line.BackColor = System.Drawing.Color.White;
            this.btn_line.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_line.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_line.Location = new System.Drawing.Point(34, 14);
            this.btn_line.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(197, 63);
            this.btn_line.TabIndex = 12;
            this.btn_line.Text = "Line Master";
            this.btn_line.UseVisualStyleBackColor = false;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // SystemUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.xuiWidgetPanel1);
            this.Controls.Add(this.button5);
            this.Name = "SystemUI";
            this.Text = "SystemUI";
            this.xuiWidgetPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private XanderUI.XUIWidgetPanel xuiWidgetPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ipplc;
        private System.Windows.Forms.Button btn_emailconfig;
        private System.Windows.Forms.Button btn_process;
        private System.Windows.Forms.Button btn_dept;
        private System.Windows.Forms.Button btn_modelline;
        private System.Windows.Forms.Button btn_model;
        private System.Windows.Forms.Button btn_line;
        private System.Windows.Forms.Button btn_settingLanguage;
    }
}