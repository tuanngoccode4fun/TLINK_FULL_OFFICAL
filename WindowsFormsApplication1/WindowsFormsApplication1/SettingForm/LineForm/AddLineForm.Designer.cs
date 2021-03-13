namespace WindowsFormsApplication1.SettingForm.LineForm
{
    partial class AddLineForm
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
            this.lbl_linename = new System.Windows.Forms.Label();
            this.txt_linename = new System.Windows.Forms.TextBox();
            this.lbl_linecode = new System.Windows.Forms.Label();
            this.txt_linecode = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_linename
            // 
            this.lbl_linename.AutoSize = true;
            this.lbl_linename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_linename.Location = new System.Drawing.Point(119, 174);
            this.lbl_linename.Name = "lbl_linename";
            this.lbl_linename.Size = new System.Drawing.Size(89, 20);
            this.lbl_linename.TabIndex = 15;
            this.lbl_linename.Text = "Line Name:";
            // 
            // txt_linename
            // 
            this.txt_linename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_linename.Location = new System.Drawing.Point(228, 171);
            this.txt_linename.Name = "txt_linename";
            this.txt_linename.Size = new System.Drawing.Size(211, 26);
            this.txt_linename.TabIndex = 14;
            // 
            // lbl_linecode
            // 
            this.lbl_linecode.AutoSize = true;
            this.lbl_linecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_linecode.Location = new System.Drawing.Point(119, 103);
            this.lbl_linecode.Name = "lbl_linecode";
            this.lbl_linecode.Size = new System.Drawing.Size(85, 20);
            this.lbl_linecode.TabIndex = 13;
            this.lbl_linecode.Text = "Line Code:";
            // 
            // txt_linecode
            // 
            this.txt_linecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_linecode.Location = new System.Drawing.Point(228, 100);
            this.txt_linecode.Name = "txt_linecode";
            this.txt_linecode.Size = new System.Drawing.Size(211, 26);
            this.txt_linecode.TabIndex = 12;
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
            // AddLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 318);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_linename);
            this.Controls.Add(this.txt_linename);
            this.Controls.Add(this.lbl_linecode);
            this.Controls.Add(this.txt_linecode);
            this.Name = "AddLineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddLineForm";
            this.Load += new System.EventHandler(this.AddLineForm_Load);
            this.Controls.SetChildIndex(this.txt_linecode, 0);
            this.Controls.SetChildIndex(this.lbl_linecode, 0);
            this.Controls.SetChildIndex(this.txt_linename, 0);
            this.Controls.SetChildIndex(this.lbl_linename, 0);
            this.Controls.SetChildIndex(this.btn_ok, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_linename;
        private System.Windows.Forms.TextBox txt_linename;
        private System.Windows.Forms.Label lbl_linecode;
        private System.Windows.Forms.TextBox txt_linecode;
        private System.Windows.Forms.Button btn_ok;
    }
}