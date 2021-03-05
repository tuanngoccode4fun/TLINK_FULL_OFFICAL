namespace WindowsFormsApplication1.SettingForm
{
    partial class PermissionForm
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
            this.dgv_permission = new System.Windows.Forms.DataGridView();
            this.btn_update = new System.Windows.Forms.Button();
            this.cmb_permission = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permission)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_permission
            // 
            this.dgv_permission.AllowUserToAddRows = false;
            this.dgv_permission.AllowUserToDeleteRows = false;
            this.dgv_permission.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_permission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_permission.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgv_permission.Location = new System.Drawing.Point(182, 60);
            this.dgv_permission.Name = "dgv_permission";
            this.dgv_permission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_permission.Size = new System.Drawing.Size(450, 528);
            this.dgv_permission.TabIndex = 3;
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(15, 66);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(115, 47);
            this.btn_update.TabIndex = 4;
            this.btn_update.Text = "Update Permission";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // cmb_permission
            // 
            this.cmb_permission.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_permission.FormattingEnabled = true;
            this.cmb_permission.Location = new System.Drawing.Point(12, 135);
            this.cmb_permission.Name = "cmb_permission";
            this.cmb_permission.Size = new System.Drawing.Size(164, 24);
            this.cmb_permission.TabIndex = 5;
            this.cmb_permission.SelectedIndexChanged += new System.EventHandler(this.cmb_permission_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Permission Select:";
            // 
            // PermissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 588);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_permission);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.dgv_permission);
            this.Name = "PermissionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PermissionForm";
            this.Load += new System.EventHandler(this.PermissionForm_Load);
            this.Controls.SetChildIndex(this.dgv_permission, 0);
            this.Controls.SetChildIndex(this.btn_update, 0);
            this.Controls.SetChildIndex(this.cmb_permission, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permission)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_permission;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.ComboBox cmb_permission;
        private System.Windows.Forms.Label label1;
    }
}