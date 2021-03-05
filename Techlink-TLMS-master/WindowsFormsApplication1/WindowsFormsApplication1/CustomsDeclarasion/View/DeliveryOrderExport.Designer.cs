namespace WindowsFormsApplication1.CustomsDeclarasion.View
{
    partial class DeliveryOrderExport
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ShipmentType = new System.Windows.Forms.TextBox();
            this.txt_buyerSelect = new System.Windows.Forms.TextBox();
            this.lb_client = new System.Windows.Forms.Label();
            this.lb_Invoice = new System.Windows.Forms.Label();
            this.lb_dateExportWarehouse = new System.Windows.Forms.Label();
            this.txt_packingNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_exportExcel = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_BOMCustoms = new System.Windows.Forms.DataGridView();
            this.dtgv_deliveryInfo = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_BOMCustoms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_deliveryInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 121);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1218, 553);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1212, 244);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_ShipmentType);
            this.groupBox1.Controls.Add(this.txt_buyerSelect);
            this.groupBox1.Controls.Add(this.lb_client);
            this.groupBox1.Controls.Add(this.lb_Invoice);
            this.groupBox1.Controls.Add(this.lb_dateExportWarehouse);
            this.groupBox1.Controls.Add(this.txt_packingNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 238);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "Transportation Service";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Buyer";
            // 
            // txt_ShipmentType
            // 
            this.txt_ShipmentType.Enabled = false;
            this.txt_ShipmentType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ShipmentType.Location = new System.Drawing.Point(215, 171);
            this.txt_ShipmentType.Name = "txt_ShipmentType";
            this.txt_ShipmentType.Size = new System.Drawing.Size(339, 30);
            this.txt_ShipmentType.TabIndex = 13;
            this.txt_ShipmentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_buyerSelect
            // 
            this.txt_buyerSelect.Enabled = false;
            this.txt_buyerSelect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buyerSelect.Location = new System.Drawing.Point(215, 117);
            this.txt_buyerSelect.Name = "txt_buyerSelect";
            this.txt_buyerSelect.Size = new System.Drawing.Size(339, 30);
            this.txt_buyerSelect.TabIndex = 11;
            this.txt_buyerSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            
            // 
            // lb_client
            // 
            this.lb_client.AutoSize = true;
            this.lb_client.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_client.Location = new System.Drawing.Point(18, 68);
            this.lb_client.Name = "lb_client";
            this.lb_client.Size = new System.Drawing.Size(69, 22);
            this.lb_client.TabIndex = 4;
            this.lb_client.Text = "Client: ";
            // 
            // lb_Invoice
            // 
            this.lb_Invoice.AutoSize = true;
            this.lb_Invoice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Invoice.Location = new System.Drawing.Point(503, 34);
            this.lb_Invoice.Name = "lb_Invoice";
            this.lb_Invoice.Size = new System.Drawing.Size(85, 22);
            this.lb_Invoice.TabIndex = 3;
            this.lb_Invoice.Text = "Invoice:  ";
            // 
            // lb_dateExportWarehouse
            // 
            this.lb_dateExportWarehouse.AutoSize = true;
            this.lb_dateExportWarehouse.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dateExportWarehouse.Location = new System.Drawing.Point(503, 68);
            this.lb_dateExportWarehouse.Name = "lb_dateExportWarehouse";
            this.lb_dateExportWarehouse.Size = new System.Drawing.Size(138, 22);
            this.lb_dateExportWarehouse.TabIndex = 2;
            this.lb_dateExportWarehouse.Text = "Export \'s Date : ";
            // 
            // txt_packingNo
            // 
            this.txt_packingNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_packingNo.Location = new System.Drawing.Point(215, 39);
            this.txt_packingNo.Name = "txt_packingNo";
            this.txt_packingNo.Size = new System.Drawing.Size(244, 30);
            this.txt_packingNo.TabIndex = 1;
            this.txt_packingNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_packingNo.TextChanged += new System.EventHandler(this.txt_packingNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Packing list code";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(765, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.45378F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.54622F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(444, 238);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btn_exportExcel);
            this.groupBox2.Controls.Add(this.btn_Search);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 75);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.BackColor = System.Drawing.Color.White;
            this.btn_exportExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportExcel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_exportExcel.Image = global::WindowsFormsApplication1.Properties.Resources.Excel_32;
            this.btn_exportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exportExcel.Location = new System.Drawing.Point(33, 19);
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Size = new System.Drawing.Size(161, 50);
            this.btn_exportExcel.TabIndex = 10;
            this.btn_exportExcel.Text = "Export Excel";
            this.btn_exportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_exportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_exportExcel.UseVisualStyleBackColor = false;
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.White;
            this.btn_Search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Search.Image = global::WindowsFormsApplication1.Properties.Resources.search;
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search.Location = new System.Drawing.Point(318, 22);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(120, 45);
            this.btn_Search.TabIndex = 9;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.White;
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_delete.Image = global::WindowsFormsApplication1.Properties.Resources.delete_32;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Location = new System.Drawing.Point(198, 22);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(120, 45);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "Delete";
            this.btn_delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.dtgv_BOMCustoms, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.dtgv_deliveryInfo, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 253);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1212, 297);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // dtgv_BOMCustoms
            // 
            this.dtgv_BOMCustoms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_BOMCustoms.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_BOMCustoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_BOMCustoms.Location = new System.Drawing.Point(3, 210);
            this.dtgv_BOMCustoms.Name = "dtgv_BOMCustoms";
            this.dtgv_BOMCustoms.RowHeadersWidth = 51;
            this.dtgv_BOMCustoms.RowTemplate.Height = 24;
            this.dtgv_BOMCustoms.Size = new System.Drawing.Size(1206, 84);
            this.dtgv_BOMCustoms.TabIndex = 3;
            this.dtgv_BOMCustoms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_BOMCustoms_CellContentClick);
            this.dtgv_BOMCustoms.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgv_BOMCustoms_DataBindingComplete);
            // 
            // dtgv_deliveryInfo
            // 
            this.dtgv_deliveryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_deliveryInfo.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_deliveryInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_deliveryInfo.Location = new System.Drawing.Point(3, 3);
            this.dtgv_deliveryInfo.Name = "dtgv_deliveryInfo";
            this.dtgv_deliveryInfo.RowHeadersWidth = 51;
            this.dtgv_deliveryInfo.RowTemplate.Height = 24;
            this.dtgv_deliveryInfo.Size = new System.Drawing.Size(1206, 201);
            this.dtgv_deliveryInfo.TabIndex = 2;
            this.dtgv_deliveryInfo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgv_deliveryInfo_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbl_Header);
            this.panel1.Location = new System.Drawing.Point(409, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 64);
            this.panel1.TabIndex = 9;
            // 
            // lbl_Header
            // 
            this.lbl_Header.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.Green;
            this.lbl_Header.Location = new System.Drawing.Point(219, 23);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(123, 32);
            this.lbl_Header.TabIndex = 0;
            this.lbl_Header.Text = "Header:";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeliveryOrderExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DeliveryOrderExport";
            this.Text = "DeliveryOrderExport";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_BOMCustoms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_deliveryInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_dateExportWarehouse;
        private System.Windows.Forms.TextBox txt_packingNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.DataGridView dtgv_deliveryInfo;
        private System.Windows.Forms.Button btn_exportExcel;
        private System.Windows.Forms.Label lb_client;
        private System.Windows.Forms.Label lb_Invoice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView dtgv_BOMCustoms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ShipmentType;
        private System.Windows.Forms.TextBox txt_buyerSelect;
    }
}