namespace WindowsFormsApplication1.ERPShowOrder
{
    partial class ERPMaterialShow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ExportExcel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_MOCTA_TA001 = new System.Windows.Forms.ComboBox();
            this.cmb_MOCTA_TA002 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_COPTC_TC002 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_COPTC_TC001 = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.dtgv_material = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_material)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ExportExcel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_MOCTA_TA001);
            this.groupBox1.Controls.Add(this.cmb_MOCTA_TA002);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_COPTC_TC002);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Controls.Add(this.dtp_to);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_COPTC_TC001);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 78);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1204, 141);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processing";
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.Location = new System.Drawing.Point(994, 77);
            this.btn_ExportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Size = new System.Drawing.Size(147, 46);
            this.btn_ExportExcel.TabIndex = 31;
            this.btn_ExportExcel.Text = "To Excel";
            this.btn_ExportExcel.UseVisualStyleBackColor = true;
            this.btn_ExportExcel.Click += new System.EventHandler(this.Btn_ExportExcel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Production order";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Production No";
            // 
            // cmb_MOCTA_TA001
            // 
            this.cmb_MOCTA_TA001.FormattingEnabled = true;
            this.cmb_MOCTA_TA001.Location = new System.Drawing.Point(64, 98);
            this.cmb_MOCTA_TA001.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_MOCTA_TA001.Name = "cmb_MOCTA_TA001";
            this.cmb_MOCTA_TA001.Size = new System.Drawing.Size(154, 25);
            this.cmb_MOCTA_TA001.TabIndex = 28;
            this.cmb_MOCTA_TA001.SelectedIndexChanged += new System.EventHandler(this.cmb_MOCTA_TA001_SelectedIndexChanged);
            // 
            // cmb_MOCTA_TA002
            // 
            this.cmb_MOCTA_TA002.FormattingEnabled = true;
            this.cmb_MOCTA_TA002.Location = new System.Drawing.Point(275, 99);
            this.cmb_MOCTA_TA002.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_MOCTA_TA002.Name = "cmb_MOCTA_TA002";
            this.cmb_MOCTA_TA002.Size = new System.Drawing.Size(154, 25);
            this.cmb_MOCTA_TA002.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Order No:";
            // 
            // cmb_COPTC_TC002
            // 
            this.cmb_COPTC_TC002.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_COPTC_TC002.FormattingEnabled = true;
            this.cmb_COPTC_TC002.Location = new System.Drawing.Point(275, 37);
            this.cmb_COPTC_TC002.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_COPTC_TC002.MaxLength = 8;
            this.cmb_COPTC_TC002.Name = "cmb_COPTC_TC002";
            this.cmb_COPTC_TC002.Size = new System.Drawing.Size(154, 25);
            this.cmb_COPTC_TC002.TabIndex = 25;
            this.cmb_COPTC_TC002.SelectedIndexChanged += new System.EventHandler(this.cmb_COPTC_TC002_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(451, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Date Time From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(683, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Date Time To:";
            // 
            // dtp_from
            // 
            this.dtp_from.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.CustomFormat = "yyyy-MM-dd";
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(455, 42);
            this.dtp_from.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(196, 23);
            this.dtp_from.TabIndex = 22;
            // 
            // dtp_to
            // 
            this.dtp_to.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.CustomFormat = "yyyy-MM-dd";
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(687, 42);
            this.dtp_to.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(196, 23);
            this.dtp_to.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order Code:";
            // 
            // cmb_COPTC_TC001
            // 
            this.cmb_COPTC_TC001.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_COPTC_TC001.FormattingEnabled = true;
            this.cmb_COPTC_TC001.Location = new System.Drawing.Point(66, 37);
            this.cmb_COPTC_TC001.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_COPTC_TC001.Name = "cmb_COPTC_TC001";
            this.cmb_COPTC_TC001.Size = new System.Drawing.Size(154, 25);
            this.cmb_COPTC_TC001.TabIndex = 1;
            this.cmb_COPTC_TC001.SelectedIndexChanged += new System.EventHandler(this.cmd_COPTC_TC001_SelectedIndexChanged);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(994, 16);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(147, 49);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dtgv_material
            // 
            this.dtgv_material.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_material.Location = new System.Drawing.Point(0, 227);
            this.dtgv_material.Margin = new System.Windows.Forms.Padding(4);
            this.dtgv_material.Name = "dtgv_material";
            this.dtgv_material.RowHeadersWidth = 51;
            this.dtgv_material.Size = new System.Drawing.Size(1366, 515);
            this.dtgv_material.TabIndex = 6;
            // 
            // ERPMaterialShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 742);
            this.Controls.Add(this.dtgv_material);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ERPMaterialShow";
            this.Text = "ERPMaterialShow";
            this.Load += new System.EventHandler(this.ERPMaterialShow_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dtgv_material, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_material)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_COPTC_TC002;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_COPTC_TC001;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView dtgv_material;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_MOCTA_TA001;
        private System.Windows.Forms.ComboBox cmb_MOCTA_TA002;
        private System.Windows.Forms.Button btn_ExportExcel;
    }
}