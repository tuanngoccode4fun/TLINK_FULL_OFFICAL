namespace WindowsFormsApplication1.CustomsDeclarasion
{
    partial class TypingItems
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oprationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputProductInformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputWeightProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputPackingInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipmentInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buyerInforToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipmentInforToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bOMOFPRODUCTDECLARASIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qRGeneratingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromExcelFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelChildForm = new System.Windows.Forms.Panel();
            this.printQRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PanelChildForm, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 107);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1179, 521);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oprationToolStripMenuItem,
            this.shipmentInformationToolStripMenuItem,
            this.bOMToolStripMenuItem,
            this.qRGeneratingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1179, 50);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oprationToolStripMenuItem
            // 
            this.oprationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputProductInformationsToolStripMenuItem,
            this.inputWeightProductToolStripMenuItem,
            this.inputPackingInfoToolStripMenuItem});
            this.oprationToolStripMenuItem.Name = "oprationToolStripMenuItem";
            this.oprationToolStripMenuItem.Size = new System.Drawing.Size(194, 46);
            this.oprationToolStripMenuItem.Text = "Product Information";
            // 
            // inputProductInformationsToolStripMenuItem
            // 
            this.inputProductInformationsToolStripMenuItem.Name = "inputProductInformationsToolStripMenuItem";
            this.inputProductInformationsToolStripMenuItem.Size = new System.Drawing.Size(281, 28);
            this.inputProductInformationsToolStripMenuItem.Text = "Input product General";
            this.inputProductInformationsToolStripMenuItem.Click += new System.EventHandler(this.inputProductInformationsToolStripMenuItem_Click);
            // 
            // inputWeightProductToolStripMenuItem
            // 
            this.inputWeightProductToolStripMenuItem.Name = "inputWeightProductToolStripMenuItem";
            this.inputWeightProductToolStripMenuItem.Size = new System.Drawing.Size(281, 28);
            this.inputWeightProductToolStripMenuItem.Text = "Input Weight Product";
            this.inputWeightProductToolStripMenuItem.Click += new System.EventHandler(this.inputWeightProductToolStripMenuItem_Click);
            // 
            // inputPackingInfoToolStripMenuItem
            // 
            this.inputPackingInfoToolStripMenuItem.Name = "inputPackingInfoToolStripMenuItem";
            this.inputPackingInfoToolStripMenuItem.Size = new System.Drawing.Size(281, 28);
            this.inputPackingInfoToolStripMenuItem.Text = "Input from Excel";
            this.inputPackingInfoToolStripMenuItem.Click += new System.EventHandler(this.inputPackingInfoToolStripMenuItem_Click);
            // 
            // shipmentInformationToolStripMenuItem
            // 
            this.shipmentInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buyerInforToolStripMenuItem,
            this.shipmentInforToolStripMenuItem});
            this.shipmentInformationToolStripMenuItem.Name = "shipmentInformationToolStripMenuItem";
            this.shipmentInformationToolStripMenuItem.Size = new System.Drawing.Size(206, 46);
            this.shipmentInformationToolStripMenuItem.Text = "Shipment Information";
            // 
            // buyerInforToolStripMenuItem
            // 
            this.buyerInforToolStripMenuItem.Name = "buyerInforToolStripMenuItem";
            this.buyerInforToolStripMenuItem.Size = new System.Drawing.Size(276, 28);
            this.buyerInforToolStripMenuItem.Text = "Buyer Information";
            this.buyerInforToolStripMenuItem.Click += new System.EventHandler(this.buyerInforToolStripMenuItem_Click);
            // 
            // shipmentInforToolStripMenuItem
            // 
            this.shipmentInforToolStripMenuItem.Name = "shipmentInforToolStripMenuItem";
            this.shipmentInforToolStripMenuItem.Size = new System.Drawing.Size(276, 28);
            this.shipmentInforToolStripMenuItem.Text = "Shipment Information";
            this.shipmentInforToolStripMenuItem.Click += new System.EventHandler(this.shipmentInforToolStripMenuItem_Click);
            // 
            // bOMToolStripMenuItem
            // 
            this.bOMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bOMOFPRODUCTDECLARASIONToolStripMenuItem});
            this.bOMToolStripMenuItem.Name = "bOMToolStripMenuItem";
            this.bOMToolStripMenuItem.Size = new System.Drawing.Size(71, 46);
            this.bOMToolStripMenuItem.Text = "BOM";
            // 
            // bOMOFPRODUCTDECLARASIONToolStripMenuItem
            // 
            this.bOMOFPRODUCTDECLARASIONToolStripMenuItem.Name = "bOMOFPRODUCTDECLARASIONToolStripMenuItem";
            this.bOMOFPRODUCTDECLARASIONToolStripMenuItem.Size = new System.Drawing.Size(290, 28);
            this.bOMOFPRODUCTDECLARASIONToolStripMenuItem.Text = "BOM DECLARASION";
            this.bOMOFPRODUCTDECLARASIONToolStripMenuItem.Click += new System.EventHandler(this.bOMOFPRODUCTDECLARASIONToolStripMenuItem_Click);
            // 
            // qRGeneratingToolStripMenuItem
            // 
            this.qRGeneratingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromExcelFilesToolStripMenuItem,
            this.printQRToolStripMenuItem});
            this.qRGeneratingToolStripMenuItem.Name = "qRGeneratingToolStripMenuItem";
            this.qRGeneratingToolStripMenuItem.Size = new System.Drawing.Size(155, 46);
            this.qRGeneratingToolStripMenuItem.Text = "QR Generating";
            // 
            // fromExcelFilesToolStripMenuItem
            // 
            this.fromExcelFilesToolStripMenuItem.Name = "fromExcelFilesToolStripMenuItem";
            this.fromExcelFilesToolStripMenuItem.Size = new System.Drawing.Size(234, 28);
            this.fromExcelFilesToolStripMenuItem.Text = "From Excel Files";
            this.fromExcelFilesToolStripMenuItem.Click += new System.EventHandler(this.fromExcelFilesToolStripMenuItem_Click);
            // 
            // PanelChildForm
            // 
            this.PanelChildForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelChildForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelChildForm.Location = new System.Drawing.Point(3, 53);
            this.PanelChildForm.Name = "PanelChildForm";
            this.PanelChildForm.Size = new System.Drawing.Size(1173, 465);
            this.PanelChildForm.TabIndex = 1;
            // 
            // printQRToolStripMenuItem
            // 
            this.printQRToolStripMenuItem.Name = "printQRToolStripMenuItem";
            this.printQRToolStripMenuItem.Size = new System.Drawing.Size(234, 28);
            this.printQRToolStripMenuItem.Text = "Print QR Code";
            this.printQRToolStripMenuItem.Click += new System.EventHandler(this.printQRToolStripMenuItem_Click);
            // 
            // TypingItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1189, 635);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TypingItems";
            this.Text = "TypingItems";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oprationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputProductInformationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputWeightProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputPackingInfoToolStripMenuItem;
        private System.Windows.Forms.Panel PanelChildForm;
        private System.Windows.Forms.ToolStripMenuItem shipmentInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buyerInforToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shipmentInforToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bOMOFPRODUCTDECLARASIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qRGeneratingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromExcelFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printQRToolStripMenuItem;
    }
}