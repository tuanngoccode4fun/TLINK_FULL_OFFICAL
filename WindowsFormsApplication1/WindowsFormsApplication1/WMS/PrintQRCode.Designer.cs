namespace WindowsFormsApplication1.WMS
{
    partial class PrintQRCode
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nmr_quanityPrinting = new System.Windows.Forms.NumericUpDown();
            this.txt_Invoice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nmr_quantity = new System.Windows.Forms.NumericUpDown();
            this.btn_GenerateSupplier = new System.Windows.Forms.Button();
            this.txt_LotPo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dt_ExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_materialCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Purchasingcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_QRERP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Generatecode = new System.Windows.Forms.Button();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_GenerateLocation = new System.Windows.Forms.Button();
            this.txt_Rack = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_location = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_warehouse = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_quanityPrinting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_quantity)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbl_Header);
            this.panel1.Location = new System.Drawing.Point(450, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 64);
            this.panel1.TabIndex = 6;
            // 
            // lbl_Header
            // 
            this.lbl_Header.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.Green;
            this.lbl_Header.Location = new System.Drawing.Point(3, 17);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(168, 46);
            this.lbl_Header.TabIndex = 0;
            this.lbl_Header.Text = "Header:";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.777F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.18815F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 93);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1148, 536);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.nmr_quanityPrinting);
            this.groupBox1.Controls.Add(this.txt_Invoice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nmr_quantity);
            this.groupBox1.Controls.Add(this.btn_GenerateSupplier);
            this.groupBox1.Controls.Add(this.txt_LotPo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dt_ExpiryDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_materialCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Purchasingcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 530);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QR Barcode Supplier";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 417);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 23);
            this.label12.TabIndex = 17;
            this.label12.Text = "Numbers Print";
            // 
            // nmr_quanityPrinting
            // 
            this.nmr_quanityPrinting.Location = new System.Drawing.Point(394, 410);
            this.nmr_quanityPrinting.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_quanityPrinting.Name = "nmr_quanityPrinting";
            this.nmr_quanityPrinting.Size = new System.Drawing.Size(120, 30);
            this.nmr_quanityPrinting.TabIndex = 16;
            this.nmr_quanityPrinting.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_quanityPrinting.ValueChanged += new System.EventHandler(this.Nmr_quanityPrinting_ValueChanged);
            // 
            // txt_Invoice
            // 
            this.txt_Invoice.Location = new System.Drawing.Point(196, 353);
            this.txt_Invoice.Name = "txt_Invoice";
            this.txt_Invoice.Size = new System.Drawing.Size(318, 30);
            this.txt_Invoice.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Invoice :";
            // 
            // nmr_quantity
            // 
            this.nmr_quantity.DecimalPlaces = 2;
            this.nmr_quantity.Location = new System.Drawing.Point(309, 172);
            this.nmr_quantity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nmr_quantity.Name = "nmr_quantity";
            this.nmr_quantity.Size = new System.Drawing.Size(205, 30);
            this.nmr_quantity.TabIndex = 13;
            // 
            // btn_GenerateSupplier
            // 
            this.btn_GenerateSupplier.Location = new System.Drawing.Point(383, 461);
            this.btn_GenerateSupplier.Name = "btn_GenerateSupplier";
            this.btn_GenerateSupplier.Size = new System.Drawing.Size(131, 41);
            this.btn_GenerateSupplier.TabIndex = 12;
            this.btn_GenerateSupplier.Text = "Generate";
            this.btn_GenerateSupplier.UseVisualStyleBackColor = true;
            this.btn_GenerateSupplier.Click += new System.EventHandler(this.Btn_Generate_Click);
            // 
            // txt_LotPo
            // 
            this.txt_LotPo.Location = new System.Drawing.Point(196, 285);
            this.txt_LotPo.Name = "txt_LotPo";
            this.txt_LotPo.Size = new System.Drawing.Size(318, 30);
            this.txt_LotPo.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "LOT/PO:";
            // 
            // dt_ExpiryDate
            // 
            this.dt_ExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_ExpiryDate.Location = new System.Drawing.Point(309, 222);
            this.dt_ExpiryDate.Name = "dt_ExpiryDate";
            this.dt_ExpiryDate.Size = new System.Drawing.Size(205, 30);
            this.dt_ExpiryDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Expiry Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quantity:";
            // 
            // txt_materialCode
            // 
            this.txt_materialCode.Location = new System.Drawing.Point(196, 105);
            this.txt_materialCode.Name = "txt_materialCode";
            this.txt_materialCode.Size = new System.Drawing.Size(318, 30);
            this.txt_materialCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material Code:";
            // 
            // txt_Purchasingcode
            // 
            this.txt_Purchasingcode.Location = new System.Drawing.Point(196, 46);
            this.txt_Purchasingcode.Name = "txt_Purchasingcode";
            this.txt_Purchasingcode.Size = new System.Drawing.Size(318, 30);
            this.txt_Purchasingcode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purchasing code:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txt_QRERP);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txt_Name);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btn_Generatecode);
            this.groupBox3.Controls.Add(this.txt_code);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox3.Location = new System.Drawing.Point(921, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 530);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "QR code Function";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(87, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 41);
            this.button1.TabIndex = 19;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_QRERP
            // 
            this.txt_QRERP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_QRERP.Location = new System.Drawing.Point(63, 250);
            this.txt_QRERP.Name = "txt_QRERP";
            this.txt_QRERP.Size = new System.Drawing.Size(150, 30);
            this.txt_QRERP.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(-4, 250);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 23);
            this.label13.TabIndex = 17;
            this.label13.Text = "Code:";
            // 
            // txt_Name
            // 
            this.txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Name.Location = new System.Drawing.Point(87, 98);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(131, 30);
            this.txt_Name.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "Name:";
            // 
            // btn_Generatecode
            // 
            this.btn_Generatecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Generatecode.Location = new System.Drawing.Point(87, 147);
            this.btn_Generatecode.Name = "btn_Generatecode";
            this.btn_Generatecode.Size = new System.Drawing.Size(131, 41);
            this.btn_Generatecode.TabIndex = 14;
            this.btn_Generatecode.Text = "Generate";
            this.btn_Generatecode.UseVisualStyleBackColor = true;
            this.btn_Generatecode.Click += new System.EventHandler(this.Btn_Generatecode_Click);
            // 
            // txt_code
            // 
            this.txt_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_code.Location = new System.Drawing.Point(104, 53);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(114, 30);
            this.txt_code.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 23);
            this.label10.TabIndex = 2;
            this.label10.Text = "Code:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_GenerateLocation);
            this.groupBox2.Controls.Add(this.txt_Rack);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_location);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_warehouse);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox2.Location = new System.Drawing.Point(540, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 530);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QR Barcode Location";
            // 
            // btn_GenerateLocation
            // 
            this.btn_GenerateLocation.Location = new System.Drawing.Point(224, 209);
            this.btn_GenerateLocation.Name = "btn_GenerateLocation";
            this.btn_GenerateLocation.Size = new System.Drawing.Size(131, 41);
            this.btn_GenerateLocation.TabIndex = 13;
            this.btn_GenerateLocation.Text = "Generate";
            this.btn_GenerateLocation.UseVisualStyleBackColor = true;
            this.btn_GenerateLocation.Click += new System.EventHandler(this.Btn_GenerateLocation_Click);
            // 
            // txt_Rack
            // 
            this.txt_Rack.Location = new System.Drawing.Point(161, 153);
            this.txt_Rack.Name = "txt_Rack";
            this.txt_Rack.Size = new System.Drawing.Size(194, 30);
            this.txt_Rack.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 23);
            this.label9.TabIndex = 5;
            this.label9.Text = "Rack:";
            // 
            // txt_location
            // 
            this.txt_location.Location = new System.Drawing.Point(161, 98);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(194, 30);
            this.txt_location.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 23);
            this.label8.TabIndex = 3;
            this.label8.Text = "Location:";
            // 
            // txt_warehouse
            // 
            this.txt_warehouse.Location = new System.Drawing.Point(161, 50);
            this.txt_warehouse.Name = "txt_warehouse";
            this.txt_warehouse.Size = new System.Drawing.Size(194, 30);
            this.txt_warehouse.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Warehouse:";
            // 
            // PrintQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 636);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "PrintQRCode";
            this.Padding = new System.Windows.Forms.Padding(4, 64, 4, 4);
            this.Text = "PrintQRCode";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_quanityPrinting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_quantity)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nmr_quantity;
        private System.Windows.Forms.Button btn_GenerateSupplier;
        private System.Windows.Forms.TextBox txt_LotPo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt_ExpiryDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Purchasingcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_GenerateLocation;
        private System.Windows.Forms.TextBox txt_Rack;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_location;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_warehouse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Generatecode;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_materialCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Invoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nmr_quanityPrinting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_QRERP;
        private System.Windows.Forms.Label label13;
    }
}