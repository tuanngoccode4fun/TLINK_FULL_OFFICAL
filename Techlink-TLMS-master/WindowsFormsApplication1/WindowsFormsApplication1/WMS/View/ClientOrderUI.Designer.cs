namespace WindowsFormsApplication1.WMS.View
{
    partial class ClientOrderUI
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_ComfirmExport = new System.Windows.Forms.Button();
            this.nmr_selectedQty = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgv_stockWH = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_exportPacking = new System.Windows.Forms.RadioButton();
            this.rd_exportPallet = new System.Windows.Forms.RadioButton();
            this.txt_DeliveryProduct = new System.Windows.Forms.TextBox();
            this.lb_deliveryProduct = new System.Windows.Forms.Label();
            this.txt_ClientOrderFillter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_filterProduct = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericPriceUnit = new System.Windows.Forms.NumericUpDown();
            this.lbl_currency = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Client = new System.Windows.Forms.Label();
            this.nmr_deliveryQty = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_selectClientOrder = new System.Windows.Forms.Button();
            this.dtgv_clientOrder = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_selectedQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_stockWH)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPriceUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_deliveryQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_clientOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 100);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1394, 616);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 78);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1388, 535);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtgv_stockWH, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 270);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1382, 262);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_ComfirmExport);
            this.groupBox2.Controls.Add(this.nmr_selectedQty);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1376, 69);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Stock in Warehouse";
            // 
            // btn_ComfirmExport
            // 
            this.btn_ComfirmExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ComfirmExport.BackColor = System.Drawing.Color.White;
            this.btn_ComfirmExport.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_ComfirmExport.Image = global::WindowsFormsApplication1.Properties.Resources.confirm_32;
            this.btn_ComfirmExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ComfirmExport.Location = new System.Drawing.Point(1263, 16);
            this.btn_ComfirmExport.Name = "btn_ComfirmExport";
            this.btn_ComfirmExport.Size = new System.Drawing.Size(107, 47);
            this.btn_ComfirmExport.TabIndex = 7;
            this.btn_ComfirmExport.Text = "Confirm";
            this.btn_ComfirmExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ComfirmExport.UseVisualStyleBackColor = false;
            this.btn_ComfirmExport.Click += new System.EventHandler(this.btn_ComfirmExport_Click_1);
            // 
            // nmr_selectedQty
            // 
            this.nmr_selectedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmr_selectedQty.Location = new System.Drawing.Point(485, 24);
            this.nmr_selectedQty.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nmr_selectedQty.Name = "nmr_selectedQty";
            this.nmr_selectedQty.Size = new System.Drawing.Size(104, 27);
            this.nmr_selectedQty.TabIndex = 4;
            this.nmr_selectedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selected Quantity";
            // 
            // dtgv_stockWH
            // 
            this.dtgv_stockWH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_stockWH.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_stockWH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_stockWH.Location = new System.Drawing.Point(3, 78);
            this.dtgv_stockWH.Name = "dtgv_stockWH";
            this.dtgv_stockWH.ReadOnly = true;
            this.dtgv_stockWH.RowHeadersWidth = 51;
            this.dtgv_stockWH.RowTemplate.Height = 24;
            this.dtgv_stockWH.Size = new System.Drawing.Size(1376, 181);
            this.dtgv_stockWH.TabIndex = 1;
            this.dtgv_stockWH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_stockWH_CellContentClick);
            this.dtgv_stockWH.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_stockWH_CellValueChanged);
            this.dtgv_stockWH.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgv_stockWH_DataBindingComplete);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtgv_clientOrder, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1382, 261);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rd_exportPacking);
            this.groupBox1.Controls.Add(this.rd_exportPallet);
            this.groupBox1.Controls.Add(this.txt_DeliveryProduct);
            this.groupBox1.Controls.Add(this.lb_deliveryProduct);
            this.groupBox1.Controls.Add(this.txt_ClientOrderFillter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_filterProduct);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericPriceUnit);
            this.groupBox1.Controls.Add(this.lbl_currency);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lb_Client);
            this.groupBox1.Controls.Add(this.nmr_deliveryQty);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_selectClientOrder);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1376, 94);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Client Order";
            // 
            // rd_exportPacking
            // 
            this.rd_exportPacking.AutoSize = true;
            this.rd_exportPacking.Location = new System.Drawing.Point(1045, 54);
            this.rd_exportPacking.Name = "rd_exportPacking";
            this.rd_exportPacking.Size = new System.Drawing.Size(165, 21);
            this.rd_exportPacking.TabIndex = 16;
            this.rd_exportPacking.Text = "Export By Package";
            this.rd_exportPacking.UseVisualStyleBackColor = true;
            // 
            // rd_exportPallet
            // 
            this.rd_exportPallet.AutoSize = true;
            this.rd_exportPallet.Checked = true;
            this.rd_exportPallet.Location = new System.Drawing.Point(1045, 19);
            this.rd_exportPallet.Name = "rd_exportPallet";
            this.rd_exportPallet.Size = new System.Drawing.Size(144, 21);
            this.rd_exportPallet.TabIndex = 15;
            this.rd_exportPallet.TabStop = true;
            this.rd_exportPallet.Text = "Export By Pallet";
            this.rd_exportPallet.UseVisualStyleBackColor = true;
            // 
            // txt_DeliveryProduct
            // 
            this.txt_DeliveryProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_DeliveryProduct.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DeliveryProduct.Location = new System.Drawing.Point(519, 17);
            this.txt_DeliveryProduct.Name = "txt_DeliveryProduct";
            this.txt_DeliveryProduct.Size = new System.Drawing.Size(172, 27);
            this.txt_DeliveryProduct.TabIndex = 4;
            this.txt_DeliveryProduct.Visible = false;
            // 
            // lb_deliveryProduct
            // 
            this.lb_deliveryProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_deliveryProduct.AutoSize = true;
            this.lb_deliveryProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_deliveryProduct.Location = new System.Drawing.Point(371, 19);
            this.lb_deliveryProduct.Name = "lb_deliveryProduct";
            this.lb_deliveryProduct.Size = new System.Drawing.Size(133, 20);
            this.lb_deliveryProduct.TabIndex = 3;
            this.lb_deliveryProduct.Text = "Delivery Product";
            this.lb_deliveryProduct.Visible = false;
            // 
            // txt_ClientOrderFillter
            // 
            this.txt_ClientOrderFillter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_ClientOrderFillter.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ClientOrderFillter.Location = new System.Drawing.Point(197, 52);
            this.txt_ClientOrderFillter.Name = "txt_ClientOrderFillter";
            this.txt_ClientOrderFillter.Size = new System.Drawing.Size(191, 27);
            this.txt_ClientOrderFillter.TabIndex = 14;
            this.txt_ClientOrderFillter.TextChanged += new System.EventHandler(this.txt_ClientOrderFillter_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Client Order Filter";
            // 
            // txt_filterProduct
            // 
            this.txt_filterProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_filterProduct.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_filterProduct.Location = new System.Drawing.Point(519, 50);
            this.txt_filterProduct.Name = "txt_filterProduct";
            this.txt_filterProduct.Size = new System.Drawing.Size(186, 27);
            this.txt_filterProduct.TabIndex = 12;
            this.txt_filterProduct.TextChanged += new System.EventHandler(this.txt_filterProduct_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(394, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Product Filter";
            // 
            // numericPriceUnit
            // 
            this.numericPriceUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericPriceUnit.DecimalPlaces = 4;
            this.numericPriceUnit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericPriceUnit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericPriceUnit.Location = new System.Drawing.Point(841, 19);
            this.numericPriceUnit.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericPriceUnit.Name = "numericPriceUnit";
            this.numericPriceUnit.Size = new System.Drawing.Size(104, 27);
            this.numericPriceUnit.TabIndex = 10;
            this.numericPriceUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_currency
            // 
            this.lbl_currency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_currency.AutoSize = true;
            this.lbl_currency.Location = new System.Drawing.Point(951, 23);
            this.lbl_currency.Name = "lbl_currency";
            this.lbl_currency.Size = new System.Drawing.Size(40, 17);
            this.lbl_currency.TabIndex = 9;
            this.lbl_currency.Text = "VND";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(729, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Price";
            // 
            // lb_Client
            // 
            this.lb_Client.AutoSize = true;
            this.lb_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Client.Location = new System.Drawing.Point(6, 28);
            this.lb_Client.Name = "lb_Client";
            this.lb_Client.Size = new System.Drawing.Size(52, 20);
            this.lb_Client.TabIndex = 6;
            this.lb_Client.Text = "Client";
            // 
            // nmr_deliveryQty
            // 
            this.nmr_deliveryQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nmr_deliveryQty.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmr_deliveryQty.Location = new System.Drawing.Point(841, 53);
            this.nmr_deliveryQty.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nmr_deliveryQty.Name = "nmr_deliveryQty";
            this.nmr_deliveryQty.Size = new System.Drawing.Size(104, 27);
            this.nmr_deliveryQty.TabIndex = 2;
            this.nmr_deliveryQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(729, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Delivery Qty";
            // 
            // btn_selectClientOrder
            // 
            this.btn_selectClientOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectClientOrder.BackColor = System.Drawing.Color.White;
            this.btn_selectClientOrder.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_selectClientOrder.Image = global::WindowsFormsApplication1.Properties.Resources.Add_32_2;
            this.btn_selectClientOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_selectClientOrder.Location = new System.Drawing.Point(1262, 45);
            this.btn_selectClientOrder.Name = "btn_selectClientOrder";
            this.btn_selectClientOrder.Size = new System.Drawing.Size(108, 39);
            this.btn_selectClientOrder.TabIndex = 0;
            this.btn_selectClientOrder.Text = "Choosen";
            this.btn_selectClientOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_selectClientOrder.UseVisualStyleBackColor = false;
            this.btn_selectClientOrder.Click += new System.EventHandler(this.btn_selectClientOrder_Click);
            // 
            // dtgv_clientOrder
            // 
            this.dtgv_clientOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_clientOrder.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_clientOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_clientOrder.Location = new System.Drawing.Point(3, 103);
            this.dtgv_clientOrder.Name = "dtgv_clientOrder";
            this.dtgv_clientOrder.ReadOnly = true;
            this.dtgv_clientOrder.RowHeadersWidth = 51;
            this.dtgv_clientOrder.RowTemplate.Height = 24;
            this.dtgv_clientOrder.Size = new System.Drawing.Size(1376, 155);
            this.dtgv_clientOrder.TabIndex = 2;
            this.dtgv_clientOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_clientOrder_CellContentClick);
            this.dtgv_clientOrder.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgv_clientOrder_DataBindingComplete);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1388, 69);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // ClientOrderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 723);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClientOrderUI";
            this.Text = "ClientOrderUI";
            this.Load += new System.EventHandler(this.ClientOrderUI_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_selectedQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_stockWH)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPriceUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_deliveryQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_clientOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dtgv_stockWH;
        private System.Windows.Forms.DataGridView dtgv_clientOrder;
        private System.Windows.Forms.Button btn_ComfirmExport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_selectClientOrder;
        private System.Windows.Forms.NumericUpDown nmr_deliveryQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_DeliveryProduct;
        private System.Windows.Forms.Label lb_deliveryProduct;
        private System.Windows.Forms.NumericUpDown nmr_selectedQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_Client;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_currency;
        private System.Windows.Forms.NumericUpDown numericPriceUnit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_filterProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ClientOrderFillter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rd_exportPacking;
        private System.Windows.Forms.RadioButton rd_exportPallet;
    }
}