namespace WindowsFormsApplication1.mainUI
{
    partial class HRManagement
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SeasonalEmp = new System.Windows.Forms.Button();
            this.btn_Manpower = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(12, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 31);
            this.button1.TabIndex = 20;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox1.Controls.Add(this.btn_SeasonalEmp);
            this.groupBox1.Controls.Add(this.btn_Manpower);
            this.groupBox1.Location = new System.Drawing.Point(4, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 397);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // btn_SeasonalEmp
            // 
            this.btn_SeasonalEmp.BackColor = System.Drawing.Color.White;
            this.btn_SeasonalEmp.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_SeasonalEmp.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_SeasonalEmp.Image = global::WindowsFormsApplication1.Properties.Resources.check_material_64;
            this.btn_SeasonalEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SeasonalEmp.Location = new System.Drawing.Point(9, 22);
            this.btn_SeasonalEmp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SeasonalEmp.Name = "btn_SeasonalEmp";
            this.btn_SeasonalEmp.Size = new System.Drawing.Size(223, 72);
            this.btn_SeasonalEmp.TabIndex = 22;
            this.btn_SeasonalEmp.Text = "Seasonal Employee";
            this.btn_SeasonalEmp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SeasonalEmp.UseVisualStyleBackColor = false;
            this.btn_SeasonalEmp.Click += new System.EventHandler(this.btn_SeasonalEmp_Click);
            // 
            // btn_Manpower
            // 
            this.btn_Manpower.BackColor = System.Drawing.Color.White;
            this.btn_Manpower.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_Manpower.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Manpower.Image = global::WindowsFormsApplication1.Properties.Resources.Manpower;
            this.btn_Manpower.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Manpower.Location = new System.Drawing.Point(255, 22);
            this.btn_Manpower.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Manpower.Name = "btn_Manpower";
            this.btn_Manpower.Size = new System.Drawing.Size(223, 72);
            this.btn_Manpower.TabIndex = 21;
            this.btn_Manpower.Text = "Manpower Control";
            this.btn_Manpower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Manpower.UseVisualStyleBackColor = false;
            this.btn_Manpower.Click += new System.EventHandler(this.btn_Manpower_Click);
            // 
            // HRManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "HRManagement";
            this.Text = "HRManagement";
            this.Load += new System.EventHandler(this.HRManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_SeasonalEmp;
        private System.Windows.Forms.Button btn_Manpower;
    }
}