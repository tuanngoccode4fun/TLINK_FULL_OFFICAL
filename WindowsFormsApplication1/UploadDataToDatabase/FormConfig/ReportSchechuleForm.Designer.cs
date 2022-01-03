namespace UploadDataToDatabase.FormConfig
{
    partial class ReportSchechuleForm
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
            this.lbl_Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_typeReport = new System.Windows.Forms.ComboBox();
            this.txt_ReportName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nmr_hours = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_day = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nmr_date = new System.Windows.Forms.NumericUpDown();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_attach = new System.Windows.Forms.Button();
            this.txt_attach = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_subject = new System.Windows.Forms.TextBox();
            this.rtb_comment = new System.Windows.Forms.RichTextBox();
            this.rtb_IsBodyHTML = new System.Windows.Forms.RadioButton();
            this.nmr_Minutes = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_Minutes)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(13, 90);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(137, 25);
            this.lbl_Name.TabIndex = 3;
            this.lbl_Name.Text = "Report Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 4;
            // 
            // cmb_typeReport
            // 
            this.cmb_typeReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_typeReport.FormattingEnabled = true;
            this.cmb_typeReport.Location = new System.Drawing.Point(179, 149);
            this.cmb_typeReport.Name = "cmb_typeReport";
            this.cmb_typeReport.Size = new System.Drawing.Size(226, 33);
            this.cmb_typeReport.TabIndex = 5;
            this.cmb_typeReport.SelectedIndexChanged += new System.EventHandler(this.cmb_typeReport_SelectedIndexChanged);
            // 
            // txt_ReportName
            // 
            this.txt_ReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ReportName.Location = new System.Drawing.Point(179, 93);
            this.txt_ReportName.Name = "txt_ReportName";
            this.txt_ReportName.Size = new System.Drawing.Size(315, 30);
            this.txt_ReportName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hours (24hs)";
            // 
            // nmr_hours
            // 
            this.nmr_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmr_hours.Location = new System.Drawing.Point(315, 236);
            this.nmr_hours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmr_hours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_hours.Name = "nmr_hours";
            this.nmr_hours.Size = new System.Drawing.Size(109, 30);
            this.nmr_hours.TabIndex = 10;
            this.nmr_hours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(453, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Day";
            // 
            // cmb_day
            // 
            this.cmb_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_day.FormattingEnabled = true;
            this.cmb_day.Location = new System.Drawing.Point(458, 235);
            this.cmb_day.Name = "cmb_day";
            this.cmb_day.Size = new System.Drawing.Size(107, 33);
            this.cmb_day.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(581, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Date";
            // 
            // nmr_date
            // 
            this.nmr_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmr_date.Location = new System.Drawing.Point(586, 238);
            this.nmr_date.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nmr_date.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_date.Name = "nmr_date";
            this.nmr_date.Size = new System.Drawing.Size(98, 30);
            this.nmr_date.TabIndex = 15;
            this.nmr_date.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmb_month
            // 
            this.cmb_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Location = new System.Drawing.Point(712, 238);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(102, 33);
            this.cmb_month.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(742, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Month";
            // 
            // btn_confirm
            // 
            this.btn_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm.Location = new System.Drawing.Point(638, 629);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(176, 51);
            this.btn_confirm.TabIndex = 18;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.Btn_confirm_Click);
            // 
            // btn_attach
            // 
            this.btn_attach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_attach.Location = new System.Drawing.Point(12, 308);
            this.btn_attach.Name = "btn_attach";
            this.btn_attach.Size = new System.Drawing.Size(116, 51);
            this.btn_attach.TabIndex = 19;
            this.btn_attach.Text = "Attach";
            this.btn_attach.UseVisualStyleBackColor = true;
            this.btn_attach.Click += new System.EventHandler(this.Btn_attach_Click_1);
            // 
            // txt_attach
            // 
            this.txt_attach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_attach.Location = new System.Drawing.Point(179, 308);
            this.txt_attach.Name = "txt_attach";
            this.txt_attach.Size = new System.Drawing.Size(635, 30);
            this.txt_attach.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 419);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Content";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "Subject";
            // 
            // txt_subject
            // 
            this.txt_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_subject.Location = new System.Drawing.Point(179, 372);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.Size = new System.Drawing.Size(443, 30);
            this.txt_subject.TabIndex = 24;
            // 
            // rtb_comment
            // 
            this.rtb_comment.Location = new System.Drawing.Point(179, 456);
            this.rtb_comment.Name = "rtb_comment";
            this.rtb_comment.Size = new System.Drawing.Size(635, 153);
            this.rtb_comment.TabIndex = 25;
            this.rtb_comment.Text = "";
            // 
            // rtb_IsBodyHTML
            // 
            this.rtb_IsBodyHTML.AutoSize = true;
            this.rtb_IsBodyHTML.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_IsBodyHTML.Location = new System.Drawing.Point(177, 419);
            this.rtb_IsBodyHTML.Name = "rtb_IsBodyHTML";
            this.rtb_IsBodyHTML.Size = new System.Drawing.Size(170, 29);
            this.rtb_IsBodyHTML.TabIndex = 26;
            this.rtb_IsBodyHTML.TabStop = true;
            this.rtb_IsBodyHTML.Text = "Is Body HTML";
            this.rtb_IsBodyHTML.UseVisualStyleBackColor = true;
            this.rtb_IsBodyHTML.CheckedChanged += new System.EventHandler(this.Rtb_IsBodyHTML_CheckedChanged);
            // 
            // nmr_Minutes
            // 
            this.nmr_Minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmr_Minutes.Location = new System.Drawing.Point(177, 235);
            this.nmr_Minutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmr_Minutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_Minutes.Name = "nmr_Minutes";
            this.nmr_Minutes.Size = new System.Drawing.Size(109, 30);
            this.nmr_Minutes.TabIndex = 28;
            this.nmr_Minutes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(172, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 25);
            this.label10.TabIndex = 27;
            this.label10.Text = "Minutes";
            // 
            // ReportSchechuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 692);
            this.Controls.Add(this.nmr_Minutes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rtb_IsBodyHTML);
            this.Controls.Add(this.rtb_comment);
            this.Controls.Add(this.txt_subject);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_attach);
            this.Controls.Add(this.btn_attach);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_month);
            this.Controls.Add(this.nmr_date);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_day);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nmr_hours);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ReportName);
            this.Controls.Add(this.cmb_typeReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Name);
            this.Name = "ReportSchechuleForm";
            this.Text = "ReportSchechuleForm";
            this.Load += new System.EventHandler(this.ReportSchechuleForm_Load);
            this.Controls.SetChildIndex(this.lbl_Name, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmb_typeReport, 0);
            this.Controls.SetChildIndex(this.txt_ReportName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.nmr_hours, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmb_day, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.nmr_date, 0);
            this.Controls.SetChildIndex(this.cmb_month, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.btn_confirm, 0);
            this.Controls.SetChildIndex(this.btn_attach, 0);
            this.Controls.SetChildIndex(this.txt_attach, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txt_subject, 0);
            this.Controls.SetChildIndex(this.rtb_comment, 0);
            this.Controls.SetChildIndex(this.rtb_IsBodyHTML, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.nmr_Minutes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nmr_hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_Minutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_typeReport;
        private System.Windows.Forms.TextBox txt_ReportName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmr_hours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_day;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nmr_date;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_attach;
        private System.Windows.Forms.TextBox txt_attach;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_subject;
        private System.Windows.Forms.RichTextBox rtb_comment;
        private System.Windows.Forms.RadioButton rtb_IsBodyHTML;
        private System.Windows.Forms.NumericUpDown nmr_Minutes;
        private System.Windows.Forms.Label label10;
    }
}