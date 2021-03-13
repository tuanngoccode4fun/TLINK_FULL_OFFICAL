namespace WindowsFormsApplication1.CustomsDeclarasion.View
{
    partial class SelectBuyerWin
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
            this.dtgv_buyerSelect = new System.Windows.Forms.DataGridView();
            this.btn_Comfirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_buyerSelect)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.dtgv_buyerSelect, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 101);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1095, 586);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dtgv_buyerSelect
            // 
            this.dtgv_buyerSelect.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dtgv_buyerSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_buyerSelect.Location = new System.Drawing.Point(3, 103);
            this.dtgv_buyerSelect.Name = "dtgv_buyerSelect";
            this.dtgv_buyerSelect.RowHeadersWidth = 51;
            this.dtgv_buyerSelect.RowTemplate.Height = 24;
            this.dtgv_buyerSelect.Size = new System.Drawing.Size(1089, 480);
            this.dtgv_buyerSelect.TabIndex = 0;
            this.dtgv_buyerSelect.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_buyerSelect_CellContentClick);
            this.dtgv_buyerSelect.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgv_buyerSelect_DataBindingComplete);
            // 
            // btn_Comfirm
            // 
            this.btn_Comfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Comfirm.BackColor = System.Drawing.Color.White;
            this.btn_Comfirm.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Comfirm.Image = global::WindowsFormsApplication1.Properties.Resources.confirm_32;
            this.btn_Comfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Comfirm.Location = new System.Drawing.Point(14, 29);
            this.btn_Comfirm.Name = "btn_Comfirm";
            this.btn_Comfirm.Size = new System.Drawing.Size(132, 48);
            this.btn_Comfirm.TabIndex = 8;
            this.btn_Comfirm.Text = "Confirm";
            this.btn_Comfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Comfirm.UseVisualStyleBackColor = false;
            this.btn_Comfirm.Click += new System.EventHandler(this.btn_Comfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Comfirm);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1089, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // SelectBuyerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 694);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SelectBuyerWin";
            this.Padding = new System.Windows.Forms.Padding(4, 64, 4, 4);
            this.Text = "SelectBuyerWin";
            this.Load += new System.EventHandler(this.SelectBuyerWin_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_buyerSelect)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dtgv_buyerSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Comfirm;
    }
}