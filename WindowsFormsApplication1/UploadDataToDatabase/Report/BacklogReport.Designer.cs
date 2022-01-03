namespace UploadDataToDatabase.Report
{
    partial class BacklogReport
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
            this.dtgr = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgr)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgr
            // 
            this.dtgr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgr.Location = new System.Drawing.Point(29, 257);
            this.dtgr.Name = "dtgr";
            this.dtgr.RowHeadersWidth = 51;
            this.dtgr.RowTemplate.Height = 24;
            this.dtgr.Size = new System.Drawing.Size(733, 150);
            this.dtgr.TabIndex = 0;
            // 
            // BacklogReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgr);
            this.Name = "BacklogReport";
            this.Text = "BacklogReport";
            this.Load += new System.EventHandler(this.BacklogReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgr;
    }
}