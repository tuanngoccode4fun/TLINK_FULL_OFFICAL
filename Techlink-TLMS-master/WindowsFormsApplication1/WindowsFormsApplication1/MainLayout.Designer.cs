namespace WindowsFormsApplication1
{
    partial class MainLayout
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
            this.btn_HRManagement = new XanderUI.XUIButton();
            this.btn_productionManagement = new XanderUI.XUIButton();
            this.btn_SystemConfig = new XanderUI.XUIButton();
            this.btn_userSetting = new XanderUI.XUIButton();
            this.xuiWidgetPanel1 = new XanderUI.XUIWidgetPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.xuiWidgetPanel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 90);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 699);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_HRManagement, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_productionManagement, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_SystemConfig, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_userSetting, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1002, 194);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_HRManagement
            // 
            this.btn_HRManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_HRManagement.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_HRManagement.ButtonImage = global::WindowsFormsApplication1.Properties.Resources.HR_management_64;
            this.btn_HRManagement.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btn_HRManagement.ButtonText = "HR MANAGEMENT";
            this.btn_HRManagement.ClickBackColor = System.Drawing.Color.ForestGreen;
            this.btn_HRManagement.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_HRManagement.CornerRadius = 5;
            this.btn_HRManagement.Enabled = false;
            this.btn_HRManagement.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HRManagement.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_HRManagement.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_HRManagement.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_HRManagement.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btn_HRManagement.Location = new System.Drawing.Point(504, 100);
            this.btn_HRManagement.Name = "btn_HRManagement";
            this.btn_HRManagement.Size = new System.Drawing.Size(495, 91);
            this.btn_HRManagement.TabIndex = 3;
            this.btn_HRManagement.TextColor = System.Drawing.Color.DodgerBlue;
            this.btn_HRManagement.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_HRManagement.Click += new System.EventHandler(this.xuiButton4_Click);
            // 
            // btn_productionManagement
            // 
            this.btn_productionManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_productionManagement.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_productionManagement.ButtonImage = global::WindowsFormsApplication1.Properties.Resources.Production;
            this.btn_productionManagement.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btn_productionManagement.ButtonText = "PRODUCTION MANAGEMENT";
            this.btn_productionManagement.ClickBackColor = System.Drawing.Color.ForestGreen;
            this.btn_productionManagement.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_productionManagement.CornerRadius = 5;
            this.btn_productionManagement.Enabled = false;
            this.btn_productionManagement.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_productionManagement.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_productionManagement.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_productionManagement.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_productionManagement.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btn_productionManagement.Location = new System.Drawing.Point(3, 100);
            this.btn_productionManagement.Name = "btn_productionManagement";
            this.btn_productionManagement.Size = new System.Drawing.Size(495, 91);
            this.btn_productionManagement.TabIndex = 2;
            this.btn_productionManagement.TextColor = System.Drawing.Color.DodgerBlue;
            this.btn_productionManagement.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_productionManagement.Click += new System.EventHandler(this.xuiButton3_Click);
            // 
            // btn_SystemConfig
            // 
            this.btn_SystemConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SystemConfig.BackgroundColor = System.Drawing.Color.White;
            this.btn_SystemConfig.ButtonImage = global::WindowsFormsApplication1.Properties.Resources.systemConfigure_64;
            this.btn_SystemConfig.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btn_SystemConfig.ButtonText = "SYSTEM CONFIGURE";
            this.btn_SystemConfig.ClickBackColor = System.Drawing.Color.ForestGreen;
            this.btn_SystemConfig.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_SystemConfig.CornerRadius = 5;
            this.btn_SystemConfig.Enabled = false;
            this.btn_SystemConfig.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SystemConfig.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_SystemConfig.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_SystemConfig.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_SystemConfig.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btn_SystemConfig.Location = new System.Drawing.Point(3, 3);
            this.btn_SystemConfig.Name = "btn_SystemConfig";
            this.btn_SystemConfig.Size = new System.Drawing.Size(495, 91);
            this.btn_SystemConfig.TabIndex = 1;
            this.btn_SystemConfig.TextColor = System.Drawing.Color.DodgerBlue;
            this.btn_SystemConfig.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_SystemConfig.Click += new System.EventHandler(this.xuiButton2_Click);
            // 
            // btn_userSetting
            // 
            this.btn_userSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_userSetting.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_userSetting.ButtonImage = global::WindowsFormsApplication1.Properties.Resources.Login;
            this.btn_userSetting.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btn_userSetting.ButtonText = "USER SETTING";
            this.btn_userSetting.ClickBackColor = System.Drawing.Color.ForestGreen;
            this.btn_userSetting.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_userSetting.CornerRadius = 5;
            this.btn_userSetting.Enabled = false;
            this.btn_userSetting.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_userSetting.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_userSetting.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_userSetting.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_userSetting.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btn_userSetting.Location = new System.Drawing.Point(504, 3);
            this.btn_userSetting.Name = "btn_userSetting";
            this.btn_userSetting.Size = new System.Drawing.Size(495, 91);
            this.btn_userSetting.TabIndex = 0;
            this.btn_userSetting.TextColor = System.Drawing.Color.DodgerBlue;
            this.btn_userSetting.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_userSetting.Click += new System.EventHandler(this.xuiButton1_Click);
            // 
            // xuiWidgetPanel1
            // 
            this.xuiWidgetPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xuiWidgetPanel1.ControlsAsWidgets = false;
            this.xuiWidgetPanel1.Location = new System.Drawing.Point(3, 203);
            this.xuiWidgetPanel1.Name = "xuiWidgetPanel1";
            this.xuiWidgetPanel1.Size = new System.Drawing.Size(1002, 493);
            this.xuiWidgetPanel1.TabIndex = 1;
            // 
            // MainLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 796);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1022, 721);
            this.Name = "MainLayout";
            this.Text = "MainLayout";
            this.Load += new System.EventHandler(this.MainLayout_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private XanderUI.XUIButton btn_HRManagement;
        private XanderUI.XUIButton btn_productionManagement;
        private XanderUI.XUIButton btn_SystemConfig;
        private XanderUI.XUIButton btn_userSetting;
        private XanderUI.XUIWidgetPanel xuiWidgetPanel1;
    }
}