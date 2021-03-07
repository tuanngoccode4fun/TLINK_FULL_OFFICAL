namespace WindowsFormsApplication1.SettingForm.IPPLC
{
    partial class IPPLC
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
            this.dgv_ip = new System.Windows.Forms.DataGridView();
            this.lbl_linename = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_linecode = new System.Windows.Forms.Label();
            this.cmb_ip = new System.Windows.Forms.ComboBox();
            this.cmb_process = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ip)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_ip
            // 
            this.dgv_ip.AllowUserToAddRows = false;
            this.dgv_ip.AllowUserToDeleteRows = false;
            this.dgv_ip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_ip.Location = new System.Drawing.Point(3, 179);
            this.dgv_ip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_ip.Name = "dgv_ip";
            this.dgv_ip.ReadOnly = true;
            this.dgv_ip.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_ip.Size = new System.Drawing.Size(1023, 373);
            this.dgv_ip.TabIndex = 18;
            this.dgv_ip.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ip_CellDoubleClick);
            // 
            // lbl_linename
            // 
            this.lbl_linename.AutoSize = true;
            this.lbl_linename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_linename.Location = new System.Drawing.Point(21, 94);
            this.lbl_linename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_linename.Name = "lbl_linename";
            this.lbl_linename.Size = new System.Drawing.Size(89, 25);
            this.lbl_linename.TabIndex = 17;
            this.lbl_linename.Text = "Process:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_add);
            this.groupBox1.Controls.Add(this.btn_edit);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Location = new System.Drawing.Point(421, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(508, 116);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process";
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(315, 72);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(153, 35);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(38, 68);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(153, 35);
            this.btn_add.TabIndex = 9;
            this.btn_add.Text = "Add New";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(315, 17);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(153, 35);
            this.btn_edit.TabIndex = 8;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(38, 17);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(153, 35);
            this.btn_search.TabIndex = 7;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_linecode
            // 
            this.lbl_linecode.AutoSize = true;
            this.lbl_linecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_linecode.Location = new System.Drawing.Point(75, 138);
            this.lbl_linecode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_linecode.Name = "lbl_linecode";
            this.lbl_linecode.Size = new System.Drawing.Size(36, 25);
            this.lbl_linecode.TabIndex = 14;
            this.lbl_linecode.Text = "IP:";
            // 
            // cmb_ip
            // 
            this.cmb_ip.FormattingEnabled = true;
            this.cmb_ip.Location = new System.Drawing.Point(115, 141);
            this.cmb_ip.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_ip.Name = "cmb_ip";
            this.cmb_ip.Size = new System.Drawing.Size(175, 25);
            this.cmb_ip.TabIndex = 19;
            // 
            // cmb_process
            // 
            this.cmb_process.FormattingEnabled = true;
            this.cmb_process.Location = new System.Drawing.Point(115, 94);
            this.cmb_process.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_process.Name = "cmb_process";
            this.cmb_process.Size = new System.Drawing.Size(175, 25);
            this.cmb_process.TabIndex = 20;
            this.cmb_process.SelectedIndexChanged += new System.EventHandler(this.cmb_process_SelectedIndexChanged);
            // 
            // IPPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 555);
            this.Controls.Add(this.cmb_process);
            this.Controls.Add(this.cmb_ip);
            this.Controls.Add(this.dgv_ip);
            this.Controls.Add(this.lbl_linename);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_linecode);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Name = "IPPLC";
            this.Padding = new System.Windows.Forms.Padding(3, 51, 3, 3);
            this.Text = "IPPLC";
            this.Load += new System.EventHandler(this.IPPLC_Load);
            this.Controls.SetChildIndex(this.lbl_linecode, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbl_linename, 0);
            this.Controls.SetChildIndex(this.dgv_ip, 0);
            this.Controls.SetChildIndex(this.cmb_ip, 0);
            this.Controls.SetChildIndex(this.cmb_process, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ip)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ip;
        private System.Windows.Forms.Label lbl_linename;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_linecode;
        private System.Windows.Forms.ComboBox cmb_ip;
        private System.Windows.Forms.ComboBox cmb_process;
    }
}