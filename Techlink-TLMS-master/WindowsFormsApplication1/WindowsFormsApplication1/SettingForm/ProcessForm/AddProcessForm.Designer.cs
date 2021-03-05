namespace WindowsFormsApplication1.SettingForm.ProcessForm
{
    partial class AddProcessForm
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
            this.cmb_modelcode = new System.Windows.Forms.ComboBox();
            this.lbl_modelcode = new System.Windows.Forms.Label();
            this.lbl_processcode = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_processname = new System.Windows.Forms.TextBox();
            this.cmb_itemcode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_itemname = new System.Windows.Forms.TextBox();
            this.cmb_processcode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmb_modelcode
            // 
            this.cmb_modelcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_modelcode.FormattingEnabled = true;
            this.cmb_modelcode.Location = new System.Drawing.Point(220, 81);
            this.cmb_modelcode.Name = "cmb_modelcode";
            this.cmb_modelcode.Size = new System.Drawing.Size(231, 28);
            this.cmb_modelcode.TabIndex = 23;
            this.cmb_modelcode.SelectedIndexChanged += new System.EventHandler(this.cmb_modelcode_SelectedIndexChanged);
            // 
            // lbl_modelcode
            // 
            this.lbl_modelcode.AutoSize = true;
            this.lbl_modelcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modelcode.Location = new System.Drawing.Point(116, 84);
            this.lbl_modelcode.Name = "lbl_modelcode";
            this.lbl_modelcode.Size = new System.Drawing.Size(98, 20);
            this.lbl_modelcode.TabIndex = 22;
            this.lbl_modelcode.Text = "Model Code:";
            // 
            // lbl_processcode
            // 
            this.lbl_processcode.AutoSize = true;
            this.lbl_processcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_processcode.Location = new System.Drawing.Point(98, 136);
            this.lbl_processcode.Name = "lbl_processcode";
            this.lbl_processcode.Size = new System.Drawing.Size(116, 20);
            this.lbl_processcode.TabIndex = 21;
            this.lbl_processcode.Text = " Process Code:";
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(271, 360);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(131, 46);
            this.btn_ok.TabIndex = 24;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = " Process Name:";
            // 
            // txt_processname
            // 
            this.txt_processname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_processname.Location = new System.Drawing.Point(220, 188);
            this.txt_processname.Name = "txt_processname";
            this.txt_processname.Size = new System.Drawing.Size(231, 26);
            this.txt_processname.TabIndex = 25;
            // 
            // cmb_itemcode
            // 
            this.cmb_itemcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_itemcode.FormattingEnabled = true;
            this.cmb_itemcode.Location = new System.Drawing.Point(220, 240);
            this.cmb_itemcode.Name = "cmb_itemcode";
            this.cmb_itemcode.Size = new System.Drawing.Size(231, 28);
            this.cmb_itemcode.TabIndex = 28;
            this.cmb_itemcode.SelectedIndexChanged += new System.EventHandler(this.cmb_itemcode_SelectedIndexChanged);
          
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Item Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Item Name:";
            // 
            // txt_itemname
            // 
            this.txt_itemname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_itemname.Location = new System.Drawing.Point(220, 295);
            this.txt_itemname.Name = "txt_itemname";
            this.txt_itemname.Size = new System.Drawing.Size(231, 26);
            this.txt_itemname.TabIndex = 29;
            // 
            // cmb_processcode
            // 
            this.cmb_processcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_processcode.FormattingEnabled = true;
            this.cmb_processcode.Location = new System.Drawing.Point(220, 136);
            this.cmb_processcode.Name = "cmb_processcode";
            this.cmb_processcode.Size = new System.Drawing.Size(231, 28);
            this.cmb_processcode.TabIndex = 31;
            this.cmb_processcode.SelectedIndexChanged += new System.EventHandler(this.cmb_processcode_SelectedIndexChanged);
            // 
            // AddProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 421);
            this.Controls.Add(this.cmb_processcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_itemname);
            this.Controls.Add(this.cmb_itemcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_processname);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.cmb_modelcode);
            this.Controls.Add(this.lbl_modelcode);
            this.Controls.Add(this.lbl_processcode);
            this.Name = "AddProcessForm";
            this.Text = "AddProcessForm";
            this.Load += new System.EventHandler(this.AddProcessForm_Load_2);
            this.Controls.SetChildIndex(this.lbl_processcode, 0);
            this.Controls.SetChildIndex(this.lbl_modelcode, 0);
            this.Controls.SetChildIndex(this.cmb_modelcode, 0);
            this.Controls.SetChildIndex(this.btn_ok, 0);
            this.Controls.SetChildIndex(this.txt_processname, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmb_itemcode, 0);
            this.Controls.SetChildIndex(this.txt_itemname, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmb_processcode, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_modelcode;
        private System.Windows.Forms.Label lbl_modelcode;
        private System.Windows.Forms.Label lbl_processcode;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_processname;
        private System.Windows.Forms.ComboBox cmb_itemcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_itemname;
        private System.Windows.Forms.ComboBox cmb_processcode;
    }
}