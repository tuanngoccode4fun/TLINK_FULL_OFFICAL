namespace WindowsFormsApplication1.mainUI
{
    partial class UserSettingUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_permission = new System.Windows.Forms.Button();
            this.btn_changepass = new System.Windows.Forms.Button();
            this.btn_registeruser = new System.Windows.Forms.Button();
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
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 31);
            this.button5.TabIndex = 16;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox1.Controls.Add(this.btn_permission);
            this.groupBox1.Controls.Add(this.btn_changepass);
            this.groupBox1.Controls.Add(this.btn_registeruser);
            this.groupBox1.Location = new System.Drawing.Point(6, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 407);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // btn_permission
            // 
            this.btn_permission.BackColor = System.Drawing.Color.White;
            this.btn_permission.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_permission.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_permission.Image = global::WindowsFormsApplication1.Properties.Resources.authorization;
            this.btn_permission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_permission.Location = new System.Drawing.Point(471, 22);
            this.btn_permission.Margin = new System.Windows.Forms.Padding(4);
            this.btn_permission.Name = "btn_permission";
            this.btn_permission.Size = new System.Drawing.Size(190, 63);
            this.btn_permission.TabIndex = 6;
            this.btn_permission.Text = "User Permission";
            this.btn_permission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_permission.UseVisualStyleBackColor = false;
            this.btn_permission.Click += new System.EventHandler(this.btn_permission_Click);
            // 
            // btn_changepass
            // 
            this.btn_changepass.BackColor = System.Drawing.Color.White;
            this.btn_changepass.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_changepass.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_changepass.Image = global::WindowsFormsApplication1.Properties.Resources.password_24;
            this.btn_changepass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_changepass.Location = new System.Drawing.Point(234, 22);
            this.btn_changepass.Margin = new System.Windows.Forms.Padding(4);
            this.btn_changepass.Name = "btn_changepass";
            this.btn_changepass.Size = new System.Drawing.Size(197, 63);
            this.btn_changepass.TabIndex = 5;
            this.btn_changepass.Text = "Change Password";
            this.btn_changepass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_changepass.UseVisualStyleBackColor = false;
            this.btn_changepass.Click += new System.EventHandler(this.btn_changepass_Click);
            // 
            // btn_registeruser
            // 
            this.btn_registeruser.BackColor = System.Drawing.Color.White;
            this.btn_registeruser.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_registeruser.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_registeruser.Image = global::WindowsFormsApplication1.Properties.Resources.log_in;
            this.btn_registeruser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_registeruser.Location = new System.Drawing.Point(7, 22);
            this.btn_registeruser.Margin = new System.Windows.Forms.Padding(4);
            this.btn_registeruser.Name = "btn_registeruser";
            this.btn_registeruser.Size = new System.Drawing.Size(191, 63);
            this.btn_registeruser.TabIndex = 4;
            this.btn_registeruser.Text = "Register User";
            this.btn_registeruser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_registeruser.UseVisualStyleBackColor = false;
            this.btn_registeruser.Click += new System.EventHandler(this.btn_registeruser_Click);
            // 
            // UserSettingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserSettingUI";
            this.Text = "UserSettingUI";
            this.Load += new System.EventHandler(this.UserSettingUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_permission;
        private System.Windows.Forms.Button btn_changepass;
        private System.Windows.Forms.Button btn_registeruser;
    }
}