namespace WindowsFormsApplication1.WMS.View
{
    partial class ProductionMaterial
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
            this.dtgv_data = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_confirm = new System.Windows.Forms.Label();
            this.txt_QRManpulation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_QRScanLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_QrScanMaterial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_materialRequest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_data)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtgv_data, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1190, 561);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dtgv_data
            // 
            this.dtgv_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_data.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_data.Location = new System.Drawing.Point(3, 203);
            this.dtgv_data.Name = "dtgv_data";
            this.dtgv_data.RowHeadersWidth = 51;
            this.dtgv_data.RowTemplate.Height = 24;
            this.dtgv_data.Size = new System.Drawing.Size(1184, 355);
            this.dtgv_data.TabIndex = 1;
            this.dtgv_data.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgv_data_DataBindingComplete);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1184, 194);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lb_confirm);
            this.groupBox1.Controls.Add(this.txt_QRManpulation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_QRScanLocation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_QrScanMaterial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_materialRequest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1178, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_confirm
            // 
            this.lb_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_confirm.AutoSize = true;
            this.lb_confirm.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_confirm.Location = new System.Drawing.Point(974, 50);
            this.lb_confirm.Name = "lb_confirm";
            this.lb_confirm.Size = new System.Drawing.Size(0, 27);
            this.lb_confirm.TabIndex = 8;
            // 
            // txt_QRManpulation
            // 
            this.txt_QRManpulation.Location = new System.Drawing.Point(218, 140);
            this.txt_QRManpulation.Name = "txt_QRManpulation";
            this.txt_QRManpulation.Size = new System.Drawing.Size(248, 30);
            this.txt_QRManpulation.TabIndex = 7;
            this.txt_QRManpulation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_QRManpulation.TextChanged += new System.EventHandler(this.txt_QRManpulation_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Scan QR Manpulation";
            // 
            // txt_QRScanLocation
            // 
            this.txt_QRScanLocation.Location = new System.Drawing.Point(185, 100);
            this.txt_QRScanLocation.Name = "txt_QRScanLocation";
            this.txt_QRScanLocation.Size = new System.Drawing.Size(713, 30);
            this.txt_QRScanLocation.TabIndex = 5;
            this.txt_QRScanLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_QRScanLocation.TextChanged += new System.EventHandler(this.txt_QRScanLocation_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Scan QR location";
            // 
            // txt_QrScanMaterial
            // 
            this.txt_QrScanMaterial.Location = new System.Drawing.Point(185, 62);
            this.txt_QrScanMaterial.Name = "txt_QrScanMaterial";
            this.txt_QrScanMaterial.Size = new System.Drawing.Size(713, 30);
            this.txt_QrScanMaterial.TabIndex = 3;
            this.txt_QrScanMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_QrScanMaterial.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scan QR Material";
            // 
            // txt_materialRequest
            // 
            this.txt_materialRequest.Location = new System.Drawing.Point(185, 24);
            this.txt_materialRequest.Name = "txt_materialRequest";
            this.txt_materialRequest.Size = new System.Drawing.Size(281, 30);
            this.txt_materialRequest.TabIndex = 1;
            this.txt_materialRequest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_materialRequest.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material Request";
            // 
            // ProductionMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 674);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProductionMaterial";
            this.Padding = new System.Windows.Forms.Padding(4, 64, 4, 4);
            this.Text = "ProductionMaterial";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_data)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_materialRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgv_data;
        private System.Windows.Forms.TextBox txt_QRScanLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_QrScanMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_QRManpulation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_confirm;
    }
}