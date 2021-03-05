namespace WindowsFormsApplication1.MQC
{
    partial class SummaryWindow
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
            this.dtgv_summary = new System.Windows.Forms.DataGridView();
            this.layoutHeader = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ExportExcel = new System.Windows.Forms.Button();
            this.lb_tiltle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_summary)).BeginInit();
            this.layoutHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtgv_summary, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.layoutHeader, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1273, 638);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtgv_summary
            // 
            this.dtgv_summary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_summary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_summary.Location = new System.Drawing.Point(3, 73);
            this.dtgv_summary.Name = "dtgv_summary";
            this.dtgv_summary.RowHeadersWidth = 51;
            this.dtgv_summary.RowTemplate.Height = 24;
            this.dtgv_summary.Size = new System.Drawing.Size(1267, 562);
            this.dtgv_summary.TabIndex = 0;
            this.dtgv_summary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtgv_summary_CellContentClick);
            // 
            // layoutHeader
            // 
            this.layoutHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutHeader.ColumnCount = 2;
            this.layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.layoutHeader.Controls.Add(this.btn_ExportExcel, 1, 0);
            this.layoutHeader.Controls.Add(this.lb_tiltle, 0, 0);
            this.layoutHeader.Location = new System.Drawing.Point(3, 3);
            this.layoutHeader.Name = "layoutHeader";
            this.layoutHeader.RowCount = 1;
            this.layoutHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutHeader.Size = new System.Drawing.Size(1267, 64);
            this.layoutHeader.TabIndex = 1;
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportExcel.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_ExportExcel.Location = new System.Drawing.Point(1170, 3);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Size = new System.Drawing.Size(94, 58);
            this.btn_ExportExcel.TabIndex = 0;
            this.btn_ExportExcel.Text = "Export";
            this.btn_ExportExcel.UseVisualStyleBackColor = true;
            this.btn_ExportExcel.Click += new System.EventHandler(this.Btn_ExportExcel_Click);
            // 
            // lb_tiltle
            // 
            this.lb_tiltle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_tiltle.AutoSize = true;
            this.lb_tiltle.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tiltle.ForeColor = System.Drawing.Color.Black;
            this.lb_tiltle.Location = new System.Drawing.Point(3, 0);
            this.lb_tiltle.Name = "lb_tiltle";
            this.lb_tiltle.Size = new System.Drawing.Size(1161, 64);
            this.lb_tiltle.TabIndex = 1;
            this.lb_tiltle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SummaryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 713);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SummaryWindow";
            this.Load += new System.EventHandler(this.SummaryWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_summary)).EndInit();
            this.layoutHeader.ResumeLayout(false);
            this.layoutHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dtgv_summary;
        private System.Windows.Forms.TableLayoutPanel layoutHeader;
        private System.Windows.Forms.Button btn_ExportExcel;
        private System.Windows.Forms.Label lb_tiltle;
    }
}