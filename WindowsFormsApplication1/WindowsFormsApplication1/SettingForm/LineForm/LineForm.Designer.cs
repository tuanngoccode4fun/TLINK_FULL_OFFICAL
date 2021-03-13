namespace WindowsFormsApplication1.SettingForm.LineForm
{
    partial class LineForm
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
            this.txt_linecode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_linecode = new System.Windows.Forms.Label();
            this.lbl_linename = new System.Windows.Forms.Label();
            this.txt_linename = new System.Windows.Forms.TextBox();
            this.dgv_line = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_line)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_linecode
            // 
            this.txt_linecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_linecode.Location = new System.Drawing.Point(107, 89);
            this.txt_linecode.Name = "txt_linecode";
            this.txt_linecode.Size = new System.Drawing.Size(144, 26);
            this.txt_linecode.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_add);
            this.groupBox1.Controls.Add(this.btn_edit);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Location = new System.Drawing.Point(363, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 121);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process";
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(245, 70);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(131, 36);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(30, 70);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(131, 36);
            this.btn_add.TabIndex = 9;
            this.btn_add.Text = "Add New";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(245, 13);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(131, 36);
            this.btn_edit.TabIndex = 8;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(30, 13);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(131, 36);
            this.btn_search.TabIndex = 7;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_linecode
            // 
            this.lbl_linecode.AutoSize = true;
            this.lbl_linecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_linecode.Location = new System.Drawing.Point(12, 92);
            this.lbl_linecode.Name = "lbl_linecode";
            this.lbl_linecode.Size = new System.Drawing.Size(85, 20);
            this.lbl_linecode.TabIndex = 5;
            this.lbl_linecode.Text = "Line Code:";
            // 
            // lbl_linename
            // 
            this.lbl_linename.AutoSize = true;
            this.lbl_linename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_linename.Location = new System.Drawing.Point(12, 144);
            this.lbl_linename.Name = "lbl_linename";
            this.lbl_linename.Size = new System.Drawing.Size(89, 20);
            this.lbl_linename.TabIndex = 11;
            this.lbl_linename.Text = "Line Name:";
            // 
            // txt_linename
            // 
            this.txt_linename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_linename.Location = new System.Drawing.Point(107, 141);
            this.txt_linename.Name = "txt_linename";
            this.txt_linename.Size = new System.Drawing.Size(144, 26);
            this.txt_linename.TabIndex = 10;
            // 
            // dgv_line
            // 
            this.dgv_line.AllowUserToAddRows = false;
            this.dgv_line.AllowUserToDeleteRows = false;
            this.dgv_line.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_line.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_line.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_line.Location = new System.Drawing.Point(0, 216);
            this.dgv_line.Name = "dgv_line";
            this.dgv_line.ReadOnly = true;
            this.dgv_line.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_line.Size = new System.Drawing.Size(797, 354);
            this.dgv_line.TabIndex = 12;
            this.dgv_line.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_line_CellClick);
            // 
            // LineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 570);
            this.Controls.Add(this.dgv_line);
            this.Controls.Add(this.lbl_linename);
            this.Controls.Add(this.txt_linename);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_linecode);
            this.Controls.Add(this.txt_linecode);
            this.Name = "LineForm";
            this.Text = "LineForm";
            this.Load += new System.EventHandler(this.LineForm_Load);
            this.Controls.SetChildIndex(this.txt_linecode, 0);
            this.Controls.SetChildIndex(this.lbl_linecode, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txt_linename, 0);
            this.Controls.SetChildIndex(this.lbl_linename, 0);
            this.Controls.SetChildIndex(this.dgv_line, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_line)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_linecode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_linecode;
        private System.Windows.Forms.Label lbl_linename;
        private System.Windows.Forms.TextBox txt_linename;
        private System.Windows.Forms.DataGridView dgv_line;
    }
}