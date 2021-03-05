namespace WindowsFormsApplication1.SettingForm.Line_ModelForm
{
    partial class ModelLine
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_modelcode = new System.Windows.Forms.ComboBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.dgv_modeline = new System.Windows.Forms.DataGridView();
            this.tv_line = new System.Windows.Forms.TreeView();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modeline)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Model Code:";
            // 
            // cmb_modelcode
            // 
            this.cmb_modelcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_modelcode.FormattingEnabled = true;
            this.cmb_modelcode.Location = new System.Drawing.Point(300, 160);
            this.cmb_modelcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_modelcode.Name = "cmb_modelcode";
            this.cmb_modelcode.Size = new System.Drawing.Size(166, 28);
            this.cmb_modelcode.TabIndex = 9;
            this.cmb_modelcode.SelectedIndexChanged += new System.EventHandler(this.cmb_modelcode_SelectedIndexChanged);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(300, 356);
            this.btn_update.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(172, 61);
            this.btn_update.TabIndex = 8;
            this.btn_update.Text = "Update Model-Line <==";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // dgv_modeline
            // 
            this.dgv_modeline.AllowUserToAddRows = false;
            this.dgv_modeline.AllowUserToDeleteRows = false;
            this.dgv_modeline.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_modeline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_modeline.Location = new System.Drawing.Point(510, 99);
            this.dgv_modeline.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_modeline.Name = "dgv_modeline";
            this.dgv_modeline.RowHeadersWidth = 51;
            this.dgv_modeline.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_modeline.Size = new System.Drawing.Size(312, 581);
            this.dgv_modeline.TabIndex = 7;
            // 
            // tv_line
            // 
            this.tv_line.CheckBoxes = true;
            this.tv_line.Location = new System.Drawing.Point(10, 99);
            this.tv_line.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tv_line.Name = "tv_line";
            this.tv_line.Size = new System.Drawing.Size(282, 579);
            this.tv_line.TabIndex = 11;
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(300, 265);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(172, 61);
            this.btn_add.TabIndex = 12;
            this.btn_add.Text = "New Model-Line ==>";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // ModelLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 680);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.tv_line);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_modelcode);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.dgv_modeline);
            this.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Name = "ModelLine";
            this.Padding = new System.Windows.Forms.Padding(5, 78, 5, 5);
            this.Text = "ModelLine";
            this.Load += new System.EventHandler(this.ModelLine_Load);
            this.Controls.SetChildIndex(this.dgv_modeline, 0);
            this.Controls.SetChildIndex(this.btn_update, 0);
            this.Controls.SetChildIndex(this.cmb_modelcode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tv_line, 0);
            this.Controls.SetChildIndex(this.btn_add, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_modelcode;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.DataGridView dgv_modeline;
        private System.Windows.Forms.TreeView tv_line;
        private System.Windows.Forms.Button btn_add;
    }
}