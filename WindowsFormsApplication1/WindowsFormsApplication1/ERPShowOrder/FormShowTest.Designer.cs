namespace WindowsFormsApplication1.ERPShowOrder
{
    partial class FormShowTest
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
            this.dtgv_test = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_OrderCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_OrderNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_test)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_test
            // 
            this.dtgv_test.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_test.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_test.Location = new System.Drawing.Point(0, 109);
            this.dtgv_test.Name = "dtgv_test";
            this.dtgv_test.Size = new System.Drawing.Size(800, 346);
            this.dtgv_test.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Order Code";
            // 
            // lab_OrderCode
            // 
            this.lab_OrderCode.AutoSize = true;
            this.lab_OrderCode.Location = new System.Drawing.Point(133, 65);
            this.lab_OrderCode.Name = "lab_OrderCode";
            this.lab_OrderCode.Size = new System.Drawing.Size(67, 13);
            this.lab_OrderCode.TabIndex = 5;
            this.lab_OrderCode.Text = "OrderCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Order No";
            // 
            // lab_OrderNo
            // 
            this.lab_OrderNo.AutoSize = true;
            this.lab_OrderNo.Location = new System.Drawing.Point(133, 90);
            this.lab_OrderNo.Name = "lab_OrderNo";
            this.lab_OrderNo.Size = new System.Drawing.Size(54, 13);
            this.lab_OrderNo.TabIndex = 7;
            this.lab_OrderNo.Text = "OrderNo";
            // 
            // FormShowTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lab_OrderNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab_OrderCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgv_test);
            this.Name = "FormShowTest";
            this.Text = "FormShowTest";
            this.Controls.SetChildIndex(this.dtgv_test, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lab_OrderCode, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lab_OrderNo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_test)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_OrderCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_OrderNo;
    }
}