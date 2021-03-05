namespace WindowsFormsApplication1.ERPShowOrder
{
    partial class ERP_KPI_Report
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
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.groupbox = new System.Windows.Forms.GroupBox();
            this.lbl_todate = new System.Windows.Forms.Label();
            this.chb_yearly = new System.Windows.Forms.CheckBox();
            this.dtp_todate = new System.Windows.Forms.DateTimePicker();
            this.chb_monthly = new System.Windows.Forms.CheckBox();
            this.lal_fromdate = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.chb_weekly = new System.Windows.Forms.CheckBox();
            this.btn_toExcel = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_sendmail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_show
            // 
            this.dgv_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Location = new System.Drawing.Point(0, 187);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.RowHeadersWidth = 51;
            this.dgv_show.RowTemplate.Height = 24;
            this.dgv_show.Size = new System.Drawing.Size(1203, 491);
            this.dgv_show.TabIndex = 3;
            // 
            // groupbox
            // 
            this.groupbox.Controls.Add(this.lbl_todate);
            this.groupbox.Controls.Add(this.chb_yearly);
            this.groupbox.Controls.Add(this.dtp_todate);
            this.groupbox.Controls.Add(this.chb_monthly);
            this.groupbox.Controls.Add(this.lal_fromdate);
            this.groupbox.Controls.Add(this.dtp_from);
            this.groupbox.Controls.Add(this.chb_weekly);
            this.groupbox.Location = new System.Drawing.Point(0, 81);
            this.groupbox.Name = "groupbox";
            this.groupbox.Size = new System.Drawing.Size(661, 100);
            this.groupbox.TabIndex = 4;
            this.groupbox.TabStop = false;
            this.groupbox.Text = "Report Time-Line";
            // 
            // lbl_todate
            // 
            this.lbl_todate.AutoSize = true;
            this.lbl_todate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_todate.Location = new System.Drawing.Point(542, 39);
            this.lbl_todate.Name = "lbl_todate";
            this.lbl_todate.Size = new System.Drawing.Size(69, 20);
            this.lbl_todate.TabIndex = 30;
            this.lbl_todate.Text = "To Date";
            // 
            // chb_yearly
            // 
            this.chb_yearly.AutoSize = true;
            this.chb_yearly.Location = new System.Drawing.Point(304, 22);
            this.chb_yearly.Name = "chb_yearly";
            this.chb_yearly.Size = new System.Drawing.Size(192, 21);
            this.chb_yearly.TabIndex = 2;
            this.chb_yearly.Text = "Yearly (From January)";
            this.chb_yearly.UseVisualStyleBackColor = true;
            // 
            // dtp_todate
            // 
            this.dtp_todate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_todate.CustomFormat = "yyyy-MM-dd";
            this.dtp_todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_todate.Location = new System.Drawing.Point(477, 63);
            this.dtp_todate.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_todate.Name = "dtp_todate";
            this.dtp_todate.Size = new System.Drawing.Size(134, 23);
            this.dtp_todate.TabIndex = 29;
            // 
            // chb_monthly
            // 
            this.chb_monthly.AutoSize = true;
            this.chb_monthly.Location = new System.Drawing.Point(12, 53);
            this.chb_monthly.Name = "chb_monthly";
            this.chb_monthly.Size = new System.Drawing.Size(176, 21);
            this.chb_monthly.TabIndex = 1;
            this.chb_monthly.Text = "Monthly (From 1 st )";
            this.chb_monthly.UseVisualStyleBackColor = true;
            // 
            // lal_fromdate
            // 
            this.lal_fromdate.AutoSize = true;
            this.lal_fromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lal_fromdate.Location = new System.Drawing.Point(349, 43);
            this.lal_fromdate.Name = "lal_fromdate";
            this.lal_fromdate.Size = new System.Drawing.Size(89, 20);
            this.lal_fromdate.TabIndex = 28;
            this.lal_fromdate.Text = "From Date";
            // 
            // dtp_from
            // 
            this.dtp_from.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.CustomFormat = "yyyy-MM-dd";
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(304, 63);
            this.dtp_from.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(134, 23);
            this.dtp_from.TabIndex = 27;
            // 
            // chb_weekly
            // 
            this.chb_weekly.AutoSize = true;
            this.chb_weekly.Location = new System.Drawing.Point(13, 23);
            this.chb_weekly.Name = "chb_weekly";
            this.chb_weekly.Size = new System.Drawing.Size(226, 21);
            this.chb_weekly.TabIndex = 0;
            this.chb_weekly.Text = "Weekly (Monday-Saturday)";
            this.chb_weekly.UseVisualStyleBackColor = true;
            // 
            // btn_toExcel
            // 
            this.btn_toExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_toExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_toExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_toExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_toExcel.Image = global::WindowsFormsApplication1.Properties.Resources.excel_icon;
            this.btn_toExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_toExcel.Location = new System.Drawing.Point(1058, 112);
            this.btn_toExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_toExcel.Name = "btn_toExcel";
            this.btn_toExcel.Size = new System.Drawing.Size(132, 55);
            this.btn_toExcel.TabIndex = 28;
            this.btn_toExcel.Text = "Export";
            this.btn_toExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_toExcel.UseVisualStyleBackColor = false;
            this.btn_toExcel.Click += new System.EventHandler(this.Btn_toExcel_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_search.Image = global::WindowsFormsApplication1.Properties.Resources.Search_icon;
            this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.Location = new System.Drawing.Point(893, 112);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(140, 55);
            this.btn_search.TabIndex = 29;
            this.btn_search.Text = "Search";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // btn_sendmail
            // 
            this.btn_sendmail.Location = new System.Drawing.Point(746, 112);
            this.btn_sendmail.Name = "btn_sendmail";
            this.btn_sendmail.Size = new System.Drawing.Size(119, 55);
            this.btn_sendmail.TabIndex = 30;
            this.btn_sendmail.Text = "Send Mail";
            this.btn_sendmail.UseVisualStyleBackColor = true;
            this.btn_sendmail.Click += new System.EventHandler(this.Btn_sendmail_Click);
            // 
            // ERP_KPI_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 677);
            this.Controls.Add(this.btn_sendmail);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_toExcel);
            this.Controls.Add(this.groupbox);
            this.Controls.Add(this.dgv_show);
            this.Name = "ERP_KPI_Report";
            this.Text = "ERP_KPI_Report";
            this.Controls.SetChildIndex(this.dgv_show, 0);
            this.Controls.SetChildIndex(this.groupbox, 0);
            this.Controls.SetChildIndex(this.btn_toExcel, 0);
            this.Controls.SetChildIndex(this.btn_search, 0);
            this.Controls.SetChildIndex(this.btn_sendmail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.groupbox.ResumeLayout(false);
            this.groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.GroupBox groupbox;
        private System.Windows.Forms.CheckBox chb_yearly;
        private System.Windows.Forms.CheckBox chb_monthly;
        private System.Windows.Forms.CheckBox chb_weekly;
        private System.Windows.Forms.Label lbl_todate;
        private System.Windows.Forms.DateTimePicker dtp_todate;
        private System.Windows.Forms.Label lal_fromdate;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Button btn_toExcel;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_sendmail;
    }
}