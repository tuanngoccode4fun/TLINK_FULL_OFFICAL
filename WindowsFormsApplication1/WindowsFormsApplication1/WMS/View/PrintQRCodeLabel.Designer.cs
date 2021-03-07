namespace WindowsFormsApplication1.WMS.View
{
    partial class PrintQRCodeLabel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintQRCodeLabel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_WarehouseInfor = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xuiSuperButton3 = new XanderUI.XUISuperButton();
            this.txt_linkFile = new System.Windows.Forms.TextBox();
            this.xuiSuperButton2 = new XanderUI.XUISuperButton();
            this.xuiSuperButton1 = new XanderUI.XUISuperButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_unit = new System.Windows.Forms.Label();
            this.dtpk_ImportDate = new System.Windows.Forms.DateTimePicker();
            this.lb_importDate = new System.Windows.Forms.Label();
            this.nmr_Quantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Lot = new System.Windows.Forms.TextBox();
            this.lb_Lot = new System.Windows.Forms.Label();
            this.txt_itemsName = new System.Windows.Forms.TextBox();
            this.lb_items = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.dtpk_expiryDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_location = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_WarehouseInfor)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_Quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtgv_WarehouseInfor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1214, 611);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dtgv_WarehouseInfor
            // 
            this.dtgv_WarehouseInfor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_WarehouseInfor.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgv_WarehouseInfor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_WarehouseInfor.Location = new System.Drawing.Point(3, 203);
            this.dtgv_WarehouseInfor.Name = "dtgv_WarehouseInfor";
            this.dtgv_WarehouseInfor.RowHeadersWidth = 51;
            this.dtgv_WarehouseInfor.RowTemplate.Height = 24;
            this.dtgv_WarehouseInfor.Size = new System.Drawing.Size(1208, 405);
            this.dtgv_WarehouseInfor.TabIndex = 1;
            this.dtgv_WarehouseInfor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_WarehouseInfor_CellClick);
            this.dtgv_WarehouseInfor.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgv_WarehouseInfor_DataBindingComplete);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.86755F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.13245F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1208, 194);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.xuiSuperButton3);
            this.groupBox1.Controls.Add(this.txt_linkFile);
            this.groupBox1.Controls.Add(this.xuiSuperButton2);
            this.groupBox1.Controls.Add(this.xuiSuperButton1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // xuiSuperButton3
            // 
            this.xuiSuperButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(202)))), ((int)(((byte)(142)))));
            this.xuiSuperButton3.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xuiSuperButton3.ButtonImage")));
            this.xuiSuperButton3.ButtonSmoothing = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            this.xuiSuperButton3.ButtonStyle = XanderUI.XUISuperButton.Style.RoundedEdges;
            this.xuiSuperButton3.ButtonText = "Load Files";
            this.xuiSuperButton3.CornerRadius = 5;
            this.xuiSuperButton3.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiSuperButton3.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(217)))), ((int)(((byte)(174)))));
            this.xuiSuperButton3.HoverTextColor = System.Drawing.Color.White;
            this.xuiSuperButton3.ImagePosition = XanderUI.XUISuperButton.imgPosition.Left;
            this.xuiSuperButton3.Location = new System.Drawing.Point(127, 9);
            this.xuiSuperButton3.Name = "xuiSuperButton3";
            this.xuiSuperButton3.SelectedBackColor = System.Drawing.Color.LimeGreen;
            this.xuiSuperButton3.SelectedTextColor = System.Drawing.Color.White;
            this.xuiSuperButton3.Size = new System.Drawing.Size(115, 44);
            this.xuiSuperButton3.SuperSelected = false;
            this.xuiSuperButton3.TabIndex = 4;
            this.xuiSuperButton3.TextColor = System.Drawing.Color.White;
            this.xuiSuperButton3.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiSuperButton3.Click += new System.EventHandler(this.xuiSuperButton3_Click);
            // 
            // txt_linkFile
            // 
            this.txt_linkFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_linkFile.Location = new System.Drawing.Point(127, 68);
            this.txt_linkFile.Name = "txt_linkFile";
            this.txt_linkFile.Size = new System.Drawing.Size(396, 30);
            this.txt_linkFile.TabIndex = 3;
            // 
            // xuiSuperButton2
            // 
            this.xuiSuperButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(202)))), ((int)(((byte)(142)))));
            this.xuiSuperButton2.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xuiSuperButton2.ButtonImage")));
            this.xuiSuperButton2.ButtonSmoothing = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            this.xuiSuperButton2.ButtonStyle = XanderUI.XUISuperButton.Style.RoundedEdges;
            this.xuiSuperButton2.ButtonText = "Print";
            this.xuiSuperButton2.CornerRadius = 5;
            this.xuiSuperButton2.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiSuperButton2.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(217)))), ((int)(((byte)(174)))));
            this.xuiSuperButton2.HoverTextColor = System.Drawing.Color.White;
            this.xuiSuperButton2.ImagePosition = XanderUI.XUISuperButton.imgPosition.Left;
            this.xuiSuperButton2.Location = new System.Drawing.Point(6, 9);
            this.xuiSuperButton2.Name = "xuiSuperButton2";
            this.xuiSuperButton2.SelectedBackColor = System.Drawing.Color.LimeGreen;
            this.xuiSuperButton2.SelectedTextColor = System.Drawing.Color.White;
            this.xuiSuperButton2.Size = new System.Drawing.Size(115, 44);
            this.xuiSuperButton2.SuperSelected = false;
            this.xuiSuperButton2.TabIndex = 2;
            this.xuiSuperButton2.TextColor = System.Drawing.Color.White;
            this.xuiSuperButton2.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiSuperButton2.Click += new System.EventHandler(this.xuiSuperButton2_Click);
            // 
            // xuiSuperButton1
            // 
            this.xuiSuperButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(202)))), ((int)(((byte)(142)))));
            this.xuiSuperButton1.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xuiSuperButton1.ButtonImage")));
            this.xuiSuperButton1.ButtonSmoothing = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            this.xuiSuperButton1.ButtonStyle = XanderUI.XUISuperButton.Style.RoundedEdges;
            this.xuiSuperButton1.ButtonText = "Load";
            this.xuiSuperButton1.CornerRadius = 5;
            this.xuiSuperButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiSuperButton1.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(217)))), ((int)(((byte)(174)))));
            this.xuiSuperButton1.HoverTextColor = System.Drawing.Color.White;
            this.xuiSuperButton1.ImagePosition = XanderUI.XUISuperButton.imgPosition.Left;
            this.xuiSuperButton1.Location = new System.Drawing.Point(6, 54);
            this.xuiSuperButton1.Name = "xuiSuperButton1";
            this.xuiSuperButton1.SelectedBackColor = System.Drawing.Color.LimeGreen;
            this.xuiSuperButton1.SelectedTextColor = System.Drawing.Color.White;
            this.xuiSuperButton1.Size = new System.Drawing.Size(115, 44);
            this.xuiSuperButton1.SuperSelected = false;
            this.xuiSuperButton1.TabIndex = 1;
            this.xuiSuperButton1.TextColor = System.Drawing.Color.White;
            this.xuiSuperButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiSuperButton1.Click += new System.EventHandler(this.xuiSuperButton1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txt_location);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpk_expiryDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lb_unit);
            this.groupBox2.Controls.Add(this.dtpk_ImportDate);
            this.groupBox2.Controls.Add(this.lb_importDate);
            this.groupBox2.Controls.Add(this.nmr_Quantity);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_Lot);
            this.groupBox2.Controls.Add(this.lb_Lot);
            this.groupBox2.Controls.Add(this.txt_itemsName);
            this.groupBox2.Controls.Add(this.lb_items);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(545, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 188);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lb_unit
            // 
            this.lb_unit.AutoSize = true;
            this.lb_unit.Location = new System.Drawing.Point(356, 98);
            this.lb_unit.Name = "lb_unit";
            this.lb_unit.Size = new System.Drawing.Size(41, 25);
            this.lb_unit.TabIndex = 8;
            this.lb_unit.Text = "KG";
            // 
            // dtpk_ImportDate
            // 
            this.dtpk_ImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_ImportDate.Location = new System.Drawing.Point(121, 139);
            this.dtpk_ImportDate.Name = "dtpk_ImportDate";
            this.dtpk_ImportDate.Size = new System.Drawing.Size(134, 30);
            this.dtpk_ImportDate.TabIndex = 7;
            // 
            // lb_importDate
            // 
            this.lb_importDate.AutoSize = true;
            this.lb_importDate.Location = new System.Drawing.Point(6, 139);
            this.lb_importDate.Name = "lb_importDate";
            this.lb_importDate.Size = new System.Drawing.Size(109, 25);
            this.lb_importDate.TabIndex = 6;
            this.lb_importDate.Text = "Import date";
            // 
            // nmr_Quantity
            // 
            this.nmr_Quantity.DecimalPlaces = 3;
            this.nmr_Quantity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nmr_Quantity.Location = new System.Drawing.Point(178, 93);
            this.nmr_Quantity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nmr_Quantity.Name = "nmr_Quantity";
            this.nmr_Quantity.Size = new System.Drawing.Size(155, 30);
            this.nmr_Quantity.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quantity";
            // 
            // txt_Lot
            // 
            this.txt_Lot.Location = new System.Drawing.Point(71, 56);
            this.txt_Lot.Name = "txt_Lot";
            this.txt_Lot.Size = new System.Drawing.Size(262, 30);
            this.txt_Lot.TabIndex = 3;
            // 
            // lb_Lot
            // 
            this.lb_Lot.AutoSize = true;
            this.lb_Lot.Location = new System.Drawing.Point(6, 58);
            this.lb_Lot.Name = "lb_Lot";
            this.lb_Lot.Size = new System.Drawing.Size(39, 25);
            this.lb_Lot.TabIndex = 2;
            this.lb_Lot.Text = "Lot";
            // 
            // txt_itemsName
            // 
            this.txt_itemsName.Location = new System.Drawing.Point(71, 21);
            this.txt_itemsName.Name = "txt_itemsName";
            this.txt_itemsName.Size = new System.Drawing.Size(262, 30);
            this.txt_itemsName.TabIndex = 1;
            // 
            // lb_items
            // 
            this.lb_items.AutoSize = true;
            this.lb_items.Location = new System.Drawing.Point(6, 25);
            this.lb_items.Name = "lb_items";
            this.lb_items.Size = new System.Drawing.Size(59, 25);
            this.lb_items.TabIndex = 0;
            this.lb_items.Text = "Items";
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.DarkKhaki;
            this.button5.Location = new System.Drawing.Point(13, 13);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 31);
            this.button5.TabIndex = 14;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dtpk_expiryDate
            // 
            this.dtpk_expiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_expiryDate.Location = new System.Drawing.Point(412, 134);
            this.dtpk_expiryDate.Name = "dtpk_expiryDate";
            this.dtpk_expiryDate.Size = new System.Drawing.Size(134, 30);
            this.dtpk_expiryDate.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Expiry date";
            // 
            // txt_location
            // 
            this.txt_location.Location = new System.Drawing.Point(463, 58);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(146, 30);
            this.txt_location.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Location";
            // 
            // PrintQRCodeLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 674);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PrintQRCodeLabel";
            this.Text = "PrintQRCodeLabel";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_WarehouseInfor)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_Quantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private XanderUI.XUISuperButton xuiSuperButton2;
        private XanderUI.XUISuperButton xuiSuperButton1;
        private System.Windows.Forms.DataGridView dtgv_WarehouseInfor;
        private System.Windows.Forms.Button button5;
        private XanderUI.XUISuperButton xuiSuperButton3;
        private System.Windows.Forms.TextBox txt_linkFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpk_ImportDate;
        private System.Windows.Forms.Label lb_importDate;
        private System.Windows.Forms.NumericUpDown nmr_Quantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Lot;
        private System.Windows.Forms.Label lb_Lot;
        private System.Windows.Forms.TextBox txt_itemsName;
        private System.Windows.Forms.Label lb_items;
        private System.Windows.Forms.Label lb_unit;
        private System.Windows.Forms.DateTimePicker dtpk_expiryDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_location;
        private System.Windows.Forms.Label label3;
    }
}