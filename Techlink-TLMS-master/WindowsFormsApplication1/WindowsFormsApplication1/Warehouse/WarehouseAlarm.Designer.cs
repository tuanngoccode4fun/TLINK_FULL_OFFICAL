namespace WindowsFormsApplication1.Warehouse
{
    partial class WarehouseAlarm
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
            this.grb_hearder = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_nation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_warehouseno = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_materialcode = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.txt_materialname = new System.Windows.Forms.TextBox();
            this.grb_hearder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_hearder
            // 
            this.grb_hearder.Controls.Add(this.txt_materialname);
            this.grb_hearder.Controls.Add(this.label4);
            this.grb_hearder.Controls.Add(this.label3);
            this.grb_hearder.Controls.Add(this.cmb_nation);
            this.grb_hearder.Controls.Add(this.label5);
            this.grb_hearder.Controls.Add(this.cmb_status);
            this.grb_hearder.Controls.Add(this.label2);
            this.grb_hearder.Controls.Add(this.cmb_warehouseno);
            this.grb_hearder.Controls.Add(this.btn_save);
            this.grb_hearder.Controls.Add(this.txt_materialcode);
            this.grb_hearder.Controls.Add(this.btn_search);
            this.grb_hearder.Controls.Add(this.label1);
            this.grb_hearder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grb_hearder.Location = new System.Drawing.Point(0, 60);
            this.grb_hearder.Name = "grb_hearder";
            this.grb_hearder.Size = new System.Drawing.Size(1348, 163);
            this.grb_hearder.TabIndex = 4;
            this.grb_hearder.TabStop = false;
            this.grb_hearder.Text = "Header";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(747, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 50;
            this.label4.Text = "Product Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(400, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 46;
            this.label3.Text = "Nation:";
            // 
            // cmb_nation
            // 
            this.cmb_nation.FormattingEnabled = true;
            this.cmb_nation.Items.AddRange(new object[] {
            "Not Enough",
            "High",
            "OK"});
            this.cmb_nation.Location = new System.Drawing.Point(482, 99);
            this.cmb_nation.Name = "cmb_nation";
            this.cmb_nation.Size = new System.Drawing.Size(211, 28);
            this.cmb_nation.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(400, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 44;
            this.label5.Text = "Status:";
            // 
            // cmb_status
            // 
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Items.AddRange(new object[] {
            "Not Enough",
            "High",
            "OK"});
            this.cmb_status.Location = new System.Drawing.Point(482, 39);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(211, 28);
            this.cmb_status.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "Warehouse No";
            // 
            // cmb_warehouseno
            // 
            this.cmb_warehouseno.FormattingEnabled = true;
            this.cmb_warehouseno.Location = new System.Drawing.Point(160, 36);
            this.cmb_warehouseno.Name = "cmb_warehouseno";
            this.cmb_warehouseno.Size = new System.Drawing.Size(173, 28);
            this.cmb_warehouseno.TabIndex = 41;
            this.cmb_warehouseno.SelectedIndexChanged += new System.EventHandler(this.cmb_warehouseno_SelectedIndexChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(1181, 92);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 41);
            this.btn_save.TabIndex = 40;
            this.btn_save.Text = "Export Excel";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_materialcode
            // 
            this.txt_materialcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_materialcode.Location = new System.Drawing.Point(894, 35);
            this.txt_materialcode.Name = "txt_materialcode";
            this.txt_materialcode.Size = new System.Drawing.Size(238, 30);
            this.txt_materialcode.TabIndex = 37;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(1181, 35);
            this.btn_search.Margin = new System.Windows.Forms.Padding(5);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(148, 42);
            this.btn_search.TabIndex = 32;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(749, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Material Code:";
            // 
            // dgv_show
            // 
            this.dgv_show.AllowDrop = true;
            this.dgv_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Location = new System.Drawing.Point(5, 248);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.RowHeadersWidth = 62;
            this.dgv_show.RowTemplate.Height = 28;
            this.dgv_show.Size = new System.Drawing.Size(1331, 369);
            this.dgv_show.TabIndex = 5;
            // 
            // txt_materialname
            // 
            this.txt_materialname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_materialname.Location = new System.Drawing.Point(894, 99);
            this.txt_materialname.Name = "txt_materialname";
            this.txt_materialname.Size = new System.Drawing.Size(238, 30);
            this.txt_materialname.TabIndex = 51;
            // 
            // WarehouseAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 629);
            this.Controls.Add(this.dgv_show);
            this.Controls.Add(this.grb_hearder);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "WarehouseAlarm";
            this.Text = "WarehouseAlarm";
            this.Load += new System.EventHandler(this.WarehouseAlarm_Load);
            this.Controls.SetChildIndex(this.grb_hearder, 0);
            this.Controls.SetChildIndex(this.dgv_show, 0);
            this.grb_hearder.ResumeLayout(false);
            this.grb_hearder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_hearder;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_materialcode;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_warehouseno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_nation;
        private System.Windows.Forms.TextBox txt_materialname;
    }
}