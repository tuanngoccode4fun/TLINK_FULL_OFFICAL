namespace WindowsFormsApplication1.WMS.View
{
    partial class ImportSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportSummary));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_importSummary = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_ImportDate = new System.Windows.Forms.RadioButton();
            this.rd_labelprintDate = new System.Windows.Forms.RadioButton();
            this.txt_productFillter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_IDFillter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpk_to = new System.Windows.Forms.DateTimePicker();
            this.lbl_to = new System.Windows.Forms.Label();
            this.dtpk_from = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_exportExcel = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_importSummary)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtgv_importSummary, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1247, 525);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dtgv_importSummary
            // 
            this.dtgv_importSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_importSummary.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_importSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_importSummary.Location = new System.Drawing.Point(3, 153);
            this.dtgv_importSummary.Name = "dtgv_importSummary";
            this.dtgv_importSummary.RowHeadersWidth = 51;
            this.dtgv_importSummary.RowTemplate.Height = 24;
            this.dtgv_importSummary.Size = new System.Drawing.Size(1241, 369);
            this.dtgv_importSummary.TabIndex = 1;
            this.dtgv_importSummary.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgv_importSummary_DataBindingComplete);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1241, 144);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rd_ImportDate);
            this.groupBox1.Controls.Add(this.rd_labelprintDate);
            this.groupBox1.Controls.Add(this.txt_productFillter);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_IDFillter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpk_to);
            this.groupBox1.Controls.Add(this.lbl_to);
            this.groupBox1.Controls.Add(this.dtpk_from);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rd_ImportDate
            // 
            this.rd_ImportDate.AutoSize = true;
            this.rd_ImportDate.Checked = true;
            this.rd_ImportDate.Location = new System.Drawing.Point(269, 72);
            this.rd_ImportDate.Name = "rd_ImportDate";
            this.rd_ImportDate.Size = new System.Drawing.Size(141, 23);
            this.rd_ImportDate.TabIndex = 9;
            this.rd_ImportDate.TabStop = true;
            this.rd_ImportDate.Text = "by Import Date";
            this.rd_ImportDate.UseVisualStyleBackColor = true;
            // 
            // rd_labelprintDate
            // 
            this.rd_labelprintDate.AutoSize = true;
            this.rd_labelprintDate.Location = new System.Drawing.Point(269, 24);
            this.rd_labelprintDate.Name = "rd_labelprintDate";
            this.rd_labelprintDate.Size = new System.Drawing.Size(161, 23);
            this.rd_labelprintDate.TabIndex = 8;
            this.rd_labelprintDate.Text = "by Request \'s date";
            this.rd_labelprintDate.UseVisualStyleBackColor = true;
            // 
            // txt_productFillter
            // 
            this.txt_productFillter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_productFillter.Location = new System.Drawing.Point(631, 78);
            this.txt_productFillter.Name = "txt_productFillter";
            this.txt_productFillter.Size = new System.Drawing.Size(224, 27);
            this.txt_productFillter.TabIndex = 7;
            this.txt_productFillter.TextChanged += new System.EventHandler(this.txt_productFillter_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Product Fillter";
            // 
            // txt_IDFillter
            // 
            this.txt_IDFillter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_IDFillter.Location = new System.Drawing.Point(631, 23);
            this.txt_IDFillter.Name = "txt_IDFillter";
            this.txt_IDFillter.Size = new System.Drawing.Size(224, 27);
            this.txt_IDFillter.TabIndex = 5;
            this.txt_IDFillter.TextChanged += new System.EventHandler(this.txt_IDFillter_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID Fillter";
            // 
            // dtpk_to
            // 
            this.dtpk_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_to.Location = new System.Drawing.Point(91, 72);
            this.dtpk_to.Name = "dtpk_to";
            this.dtpk_to.Size = new System.Drawing.Size(156, 27);
            this.dtpk_to.TabIndex = 3;
            // 
            // lbl_to
            // 
            this.lbl_to.AutoSize = true;
            this.lbl_to.Location = new System.Drawing.Point(15, 76);
            this.lbl_to.Name = "lbl_to";
            this.lbl_to.Size = new System.Drawing.Size(26, 19);
            this.lbl_to.TabIndex = 2;
            this.lbl_to.Text = "To";
            this.lbl_to.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpk_from
            // 
            this.dtpk_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_from.Location = new System.Drawing.Point(91, 19);
            this.dtpk_from.Name = "dtpk_from";
            this.dtpk_from.Size = new System.Drawing.Size(156, 27);
            this.dtpk_from.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_exportExcel);
            this.groupBox2.Controls.Add(this.btn_search);
            this.groupBox2.Location = new System.Drawing.Point(871, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exportExcel.BackColor = System.Drawing.Color.White;
            this.btn_exportExcel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_exportExcel.Image = global::WindowsFormsApplication1.Properties.Resources.Excel_32;
            this.btn_exportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exportExcel.Location = new System.Drawing.Point(91, 42);
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Size = new System.Drawing.Size(131, 50);
            this.btn_exportExcel.TabIndex = 7;
            this.btn_exportExcel.Text = "Export Excel";
            this.btn_exportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_exportExcel.UseVisualStyleBackColor = false;
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.BackColor = System.Drawing.Color.White;
            this.btn_search.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.Location = new System.Drawing.Point(228, 42);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(133, 50);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "Search";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // ImportSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 650);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImportSummary";
            this.Padding = new System.Windows.Forms.Padding(4, 64, 4, 4);
            this.Text = "ImportSummary";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_importSummary)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpk_to;
        private System.Windows.Forms.Label lbl_to;
        private System.Windows.Forms.DateTimePicker dtpk_from;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_exportExcel;
        private System.Windows.Forms.DataGridView dtgv_importSummary;
        private System.Windows.Forms.TextBox txt_productFillter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_IDFillter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rd_ImportDate;
        private System.Windows.Forms.RadioButton rd_labelprintDate;
    }
}