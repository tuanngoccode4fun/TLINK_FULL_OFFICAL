namespace WindowsFormsApplication1.CustomsDeclarasion.View
{
    partial class InputProduct
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
            this.button5 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_productSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nmr_weightofPallet = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_DimensionOfPallet = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nmr_weightofCarton = new System.Windows.Forms.NumericUpDown();
            this.nmr_QtyCarton = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_DimensionCarton = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_productName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgv_ProductInfor = new System.Windows.Forms.DataGridView();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nmr_SplintWeight = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nmr_CartonPallet = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_weightofPallet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_weightofCarton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_QtyCarton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ProductInfor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_SplintWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_CartonPallet)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.DarkKhaki;
            this.button5.Location = new System.Drawing.Point(1, -1);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 31);
            this.button5.TabIndex = 8;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1192, 539);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txt_productSearch);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_Update);
            this.groupBox1.Controls.Add(this.btn_Add);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1186, 64);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // txt_productSearch
            // 
            this.txt_productSearch.Location = new System.Drawing.Point(111, 26);
            this.txt_productSearch.Name = "txt_productSearch";
            this.txt_productSearch.Size = new System.Drawing.Size(271, 27);
            this.txt_productSearch.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Product";
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.White;
            this.btn_Search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Search.Image = global::WindowsFormsApplication1.Properties.Resources.search;
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search.Location = new System.Drawing.Point(783, 15);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(120, 45);
            this.btn_Search.TabIndex = 7;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.White;
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_delete.Image = global::WindowsFormsApplication1.Properties.Resources.delete_32;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Location = new System.Drawing.Point(660, 14);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(120, 45);
            this.btn_delete.TabIndex = 6;
            this.btn_delete.Text = "Delete";
            this.btn_delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.White;
            this.btn_Update.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Update.Image = global::WindowsFormsApplication1.Properties.Resources.refresh;
            this.btn_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Update.Location = new System.Drawing.Point(530, 12);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(120, 45);
            this.btn_Update.TabIndex = 5;
            this.btn_Update.Text = "Update";
            this.btn_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.White;
            this.btn_Add.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Add.Image = global::WindowsFormsApplication1.Properties.Resources.Add_32_2;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(404, 13);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(120, 45);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "Add";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtgv_ProductInfor, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.67603F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.32397F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1186, 463);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.nmr_CartonPallet);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.nmr_SplintWeight);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nmr_weightofPallet);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_DimensionOfPallet);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.nmr_weightofCarton);
            this.groupBox2.Controls.Add(this.nmr_QtyCarton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_DimensionCarton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_description);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_productName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1180, 224);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1117, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 19);
            this.label4.TabIndex = 21;
            this.label4.Text = "KG";
            // 
            // nmr_weightofPallet
            // 
            this.nmr_weightofPallet.DecimalPlaces = 3;
            this.nmr_weightofPallet.Location = new System.Drawing.Point(986, 108);
            this.nmr_weightofPallet.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmr_weightofPallet.Name = "nmr_weightofPallet";
            this.nmr_weightofPallet.Size = new System.Drawing.Size(125, 27);
            this.nmr_weightofPallet.TabIndex = 20;
            this.nmr_weightofPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmr_weightofPallet.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(837, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "Weight of Pallet";
            // 
            // txt_DimensionOfPallet
            // 
            this.txt_DimensionOfPallet.Location = new System.Drawing.Point(958, 67);
            this.txt_DimensionOfPallet.Name = "txt_DimensionOfPallet";
            this.txt_DimensionOfPallet.Size = new System.Drawing.Size(216, 27);
            this.txt_DimensionOfPallet.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(827, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Dimension Pallet";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(726, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "KG";
            // 
            // nmr_weightofCarton
            // 
            this.nmr_weightofCarton.DecimalPlaces = 3;
            this.nmr_weightofCarton.Location = new System.Drawing.Point(595, 113);
            this.nmr_weightofCarton.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmr_weightofCarton.Name = "nmr_weightofCarton";
            this.nmr_weightofCarton.Size = new System.Drawing.Size(125, 27);
            this.nmr_weightofCarton.TabIndex = 15;
            this.nmr_weightofCarton.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmr_weightofCarton.ThousandsSeparator = true;
            // 
            // nmr_QtyCarton
            // 
            this.nmr_QtyCarton.Location = new System.Drawing.Point(595, 30);
            this.nmr_QtyCarton.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmr_QtyCarton.Name = "nmr_QtyCarton";
            this.nmr_QtyCarton.Size = new System.Drawing.Size(125, 27);
            this.nmr_QtyCarton.TabIndex = 14;
            this.nmr_QtyCarton.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmr_QtyCarton.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(456, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Weight of Carton";
            // 
            // txt_DimensionCarton
            // 
            this.txt_DimensionCarton.Location = new System.Drawing.Point(595, 72);
            this.txt_DimensionCarton.Name = "txt_DimensionCarton";
            this.txt_DimensionCarton.Size = new System.Drawing.Size(208, 27);
            this.txt_DimensionCarton.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(456, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Dimension Carton";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Qty/Carton";
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(114, 67);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(330, 117);
            this.txt_description.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // txt_productName
            // 
            this.txt_productName.Enabled = false;
            this.txt_productName.Location = new System.Drawing.Point(114, 24);
            this.txt_productName.Name = "txt_productName";
            this.txt_productName.Size = new System.Drawing.Size(330, 27);
            this.txt_productName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product";
            // 
            // dtgv_ProductInfor
            // 
            this.dtgv_ProductInfor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_ProductInfor.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_ProductInfor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ProductInfor.Location = new System.Drawing.Point(3, 233);
            this.dtgv_ProductInfor.Name = "dtgv_ProductInfor";
            this.dtgv_ProductInfor.RowHeadersWidth = 51;
            this.dtgv_ProductInfor.RowTemplate.Height = 24;
            this.dtgv_ProductInfor.Size = new System.Drawing.Size(1180, 227);
            this.dtgv_ProductInfor.TabIndex = 1;
            this.dtgv_ProductInfor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_ProductInfor_CellContentClick);
            this.dtgv_ProductInfor.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgv_ProductInfor_DataBindingComplete);
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.Location = new System.Drawing.Point(52, 2);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(103, 23);
            this.lbl_Header.TabIndex = 12;
            this.lbl_Header.Text = "lbl_Header";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1118, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 19);
            this.label11.TabIndex = 24;
            this.label11.Text = "KG";
            // 
            // nmr_SplintWeight
            // 
            this.nmr_SplintWeight.DecimalPlaces = 3;
            this.nmr_SplintWeight.Location = new System.Drawing.Point(987, 147);
            this.nmr_SplintWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmr_SplintWeight.Name = "nmr_SplintWeight";
            this.nmr_SplintWeight.Size = new System.Drawing.Size(125, 27);
            this.nmr_SplintWeight.TabIndex = 23;
            this.nmr_SplintWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmr_SplintWeight.ThousandsSeparator = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(827, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 19);
            this.label12.TabIndex = 22;
            this.label12.Text = "Papper splint weight";
            // 
            // nmr_CartonPallet
            // 
            this.nmr_CartonPallet.Location = new System.Drawing.Point(985, 30);
            this.nmr_CartonPallet.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmr_CartonPallet.Name = "nmr_CartonPallet";
            this.nmr_CartonPallet.Size = new System.Drawing.Size(125, 27);
            this.nmr_CartonPallet.TabIndex = 29;
            this.nmr_CartonPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmr_CartonPallet.ThousandsSeparator = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(846, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 19);
            this.label15.TabIndex = 28;
            this.label15.Text = "Carton/Pallet";
            // 
            // InputProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1193, 578);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button5);
            this.Name = "InputProduct";
            this.Text = "InputProduct";
            this.Load += new System.EventHandler(this.InputProduct_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_weightofPallet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_weightofCarton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_QtyCarton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ProductInfor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_SplintWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_CartonPallet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_DimensionCarton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_productName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgv_ProductInfor;
        private System.Windows.Forms.TextBox txt_productSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.NumericUpDown nmr_QtyCarton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmr_weightofPallet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_DimensionOfPallet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nmr_weightofCarton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nmr_SplintWeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nmr_CartonPallet;
        private System.Windows.Forms.Label label15;
    }
}