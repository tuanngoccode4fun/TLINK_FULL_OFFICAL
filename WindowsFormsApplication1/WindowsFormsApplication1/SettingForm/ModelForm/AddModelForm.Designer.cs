namespace WindowsFormsApplication1.SettingForm.ModelForm
{
    partial class AddModelForm
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
            this.lbl_modelname = new System.Windows.Forms.Label();
            this.txt_modelname = new System.Windows.Forms.TextBox();
            this.lbl_modelcode = new System.Windows.Forms.Label();
            this.txt_modelcode = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_modelname
            // 
            this.lbl_modelname.AutoSize = true;
            this.lbl_modelname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modelname.Location = new System.Drawing.Point(121, 174);
            this.lbl_modelname.Name = "lbl_modelname";
            this.lbl_modelname.Size = new System.Drawing.Size(102, 20);
            this.lbl_modelname.TabIndex = 15;
            this.lbl_modelname.Text = "Model Name:";
            // 
            // txt_modelname
            // 
            this.txt_modelname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_modelname.Location = new System.Drawing.Point(228, 171);
            this.txt_modelname.Name = "txt_modelname";
            this.txt_modelname.Size = new System.Drawing.Size(211, 26);
            this.txt_modelname.TabIndex = 14;
            // 
            // lbl_modelcode
            // 
            this.lbl_modelcode.AutoSize = true;
            this.lbl_modelcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modelcode.Location = new System.Drawing.Point(121, 103);
            this.lbl_modelcode.Name = "lbl_modelcode";
            this.lbl_modelcode.Size = new System.Drawing.Size(98, 20);
            this.lbl_modelcode.TabIndex = 13;
            this.lbl_modelcode.Text = "Model Code:";
            // 
            // txt_modelcode
            // 
            this.txt_modelcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_modelcode.Location = new System.Drawing.Point(228, 100);
            this.txt_modelcode.Name = "txt_modelcode";
            this.txt_modelcode.Size = new System.Drawing.Size(211, 26);
            this.txt_modelcode.TabIndex = 12;
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(267, 235);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(131, 46);
            this.btn_ok.TabIndex = 16;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // AddModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 318);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_modelname);
            this.Controls.Add(this.txt_modelname);
            this.Controls.Add(this.lbl_modelcode);
            this.Controls.Add(this.txt_modelcode);
            this.Name = "AddModelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddLineForm";
            this.Load += new System.EventHandler(this.AddLineForm_Load);
            this.Controls.SetChildIndex(this.txt_modelcode, 0);
            this.Controls.SetChildIndex(this.lbl_modelcode, 0);
            this.Controls.SetChildIndex(this.txt_modelname, 0);
            this.Controls.SetChildIndex(this.lbl_modelname, 0);
            this.Controls.SetChildIndex(this.btn_ok, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_modelname;
        private System.Windows.Forms.TextBox txt_modelname;
        private System.Windows.Forms.Label lbl_modelcode;
        private System.Windows.Forms.TextBox txt_modelcode;
        private System.Windows.Forms.Button btn_ok;
    }
}