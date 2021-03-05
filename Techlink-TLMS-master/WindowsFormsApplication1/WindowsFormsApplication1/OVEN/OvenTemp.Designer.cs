namespace WindowsFormsApplication1.OVEN
{
    partial class OvenTemp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xuiGauge1 = new XanderUI.XUIGauge();
            this.xuiCard1 = new XanderUI.XUICard();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.xuiGauge1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.xuiCard1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 252);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // xuiGauge1
            // 
            this.xuiGauge1.DialColor = System.Drawing.Color.Gray;
            this.xuiGauge1.DialThickness = 5;
            this.xuiGauge1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xuiGauge1.FilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.xuiGauge1.GaugeStyle = XanderUI.XUIGauge.Style.Material;
            this.xuiGauge1.Location = new System.Drawing.Point(3, 129);
            this.xuiGauge1.Name = "xuiGauge1";
            this.xuiGauge1.Percentage = 75;
            this.xuiGauge1.Size = new System.Drawing.Size(374, 120);
            this.xuiGauge1.TabIndex = 0;
            this.xuiGauge1.Text = "xuiGauge1";
            this.xuiGauge1.Thickness = 8;
            this.xuiGauge1.UnfilledColor = System.Drawing.Color.Gray;
            // 
            // xuiCard1
            // 
            this.xuiCard1.BackColor = System.Drawing.Color.Transparent;
            this.xuiCard1.Color1 = System.Drawing.Color.DodgerBlue;
            this.xuiCard1.Color2 = System.Drawing.Color.LimeGreen;
            this.xuiCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xuiCard1.ForeColor = System.Drawing.Color.White;
            this.xuiCard1.Location = new System.Drawing.Point(3, 3);
            this.xuiCard1.Name = "xuiCard1";
            this.xuiCard1.Size = new System.Drawing.Size(374, 120);
            this.xuiCard1.TabIndex = 1;
            this.xuiCard1.Text = "xuiCard1";
            this.xuiCard1.Text1 = "Savings Card";
            this.xuiCard1.Text2 = "1234 5678 9101 1121";
            this.xuiCard1.Text3 = "Exp: 01/02 - 03/04";
            // 
            // OvenTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OvenTemp";
            this.Size = new System.Drawing.Size(387, 263);
            this.Load += new System.EventHandler(this.OvenTemp_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private XanderUI.XUIGauge xuiGauge1;
        private XanderUI.XUICard xuiCard1;
    }
}
