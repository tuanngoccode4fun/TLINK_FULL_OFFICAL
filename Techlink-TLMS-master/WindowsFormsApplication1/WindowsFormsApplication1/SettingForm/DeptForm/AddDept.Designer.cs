namespace WindowsFormsApplication1.SettingForm.DeptForm
{
    partial class AddDept
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.lbl_deptlname = new System.Windows.Forms.Label();
            this.txt_deptname = new System.Windows.Forms.TextBox();
            this.lbl_deptcode = new System.Windows.Forms.Label();
            this.txt_deptcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(251, 217);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(131, 46);
            this.btn_ok.TabIndex = 21;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lbl_deptlname
            // 
            this.lbl_deptlname.AutoSize = true;
            this.lbl_deptlname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_deptlname.Location = new System.Drawing.Point(105, 156);
            this.lbl_deptlname.Name = "lbl_deptlname";
            this.lbl_deptlname.Size = new System.Drawing.Size(94, 20);
            this.lbl_deptlname.TabIndex = 20;
            this.lbl_deptlname.Text = "Dept Name:";
            // 
            // txt_deptname
            // 
            this.txt_deptname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_deptname.Location = new System.Drawing.Point(212, 153);
            this.txt_deptname.Name = "txt_deptname";
            this.txt_deptname.Size = new System.Drawing.Size(211, 26);
            this.txt_deptname.TabIndex = 19;
            // 
            // lbl_deptcode
            // 
            this.lbl_deptcode.AutoSize = true;
            this.lbl_deptcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_deptcode.Location = new System.Drawing.Point(105, 85);
            this.lbl_deptcode.Name = "lbl_deptcode";
            this.lbl_deptcode.Size = new System.Drawing.Size(90, 20);
            this.lbl_deptcode.TabIndex = 18;
            this.lbl_deptcode.Text = "Dept Code:";
            // 
            // txt_deptcode
            // 
            this.txt_deptcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_deptcode.Location = new System.Drawing.Point(212, 82);
            this.txt_deptcode.Name = "txt_deptcode";
            this.txt_deptcode.Size = new System.Drawing.Size(211, 26);
            this.txt_deptcode.TabIndex = 17;
            // 
            // AddDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 289);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_deptlname);
            this.Controls.Add(this.txt_deptname);
            this.Controls.Add(this.lbl_deptcode);
            this.Controls.Add(this.txt_deptcode);
            this.Name = "AddDept";
            this.Text = "AddDept";
            this.Load += new System.EventHandler(this.AddDept_Load);
            this.Controls.SetChildIndex(this.txt_deptcode, 0);
            this.Controls.SetChildIndex(this.lbl_deptcode, 0);
            this.Controls.SetChildIndex(this.txt_deptname, 0);
            this.Controls.SetChildIndex(this.lbl_deptlname, 0);
            this.Controls.SetChildIndex(this.btn_ok, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lbl_deptlname;
        private System.Windows.Forms.TextBox txt_deptname;
        private System.Windows.Forms.Label lbl_deptcode;
        private System.Windows.Forms.TextBox txt_deptcode;
    }
}