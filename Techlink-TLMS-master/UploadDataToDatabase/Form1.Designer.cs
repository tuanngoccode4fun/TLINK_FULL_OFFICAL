namespace UploadDataToDatabase
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Start = new System.Windows.Forms.Button();
            this.lbl_tittle = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.num_seconds = new System.Windows.Forms.NumericUpDown();
            this.lbl_seconds = new System.Windows.Forms.Label();
            this.num_minutes = new System.Windows.Forms.NumericUpDown();
            this.lbl_minutes = new System.Windows.Forms.Label();
            this.num_hours = new System.Windows.Forms.NumericUpDown();
            this.lbl_hours = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Backlog2Excel = new System.Windows.Forms.CheckBox();
            this.dgv_export = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_startSendmail = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nmr_secondSendmail = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nmr_minutesSendMail = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nmr_hoursSendmail = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_seconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_hours)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_export)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_secondSendmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_minutesSendMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_hoursSendmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(321, 74);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(98, 50);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // lbl_tittle
            // 
            this.lbl_tittle.AutoSize = true;
            this.lbl_tittle.Location = new System.Drawing.Point(15, 14);
            this.lbl_tittle.Name = "lbl_tittle";
            this.lbl_tittle.Size = new System.Drawing.Size(0, 17);
            this.lbl_tittle.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.num_seconds);
            this.groupBox3.Controls.Add(this.lbl_seconds);
            this.groupBox3.Controls.Add(this.num_minutes);
            this.groupBox3.Controls.Add(this.lbl_minutes);
            this.groupBox3.Controls.Add(this.num_hours);
            this.groupBox3.Controls.Add(this.lbl_hours);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 95);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Timer";
            // 
            // num_seconds
            // 
            this.num_seconds.Location = new System.Drawing.Point(205, 56);
            this.num_seconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.num_seconds.Name = "num_seconds";
            this.num_seconds.Size = new System.Drawing.Size(79, 23);
            this.num_seconds.TabIndex = 34;
            this.num_seconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_seconds
            // 
            this.lbl_seconds.AutoSize = true;
            this.lbl_seconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_seconds.Location = new System.Drawing.Point(200, 19);
            this.lbl_seconds.Name = "lbl_seconds";
            this.lbl_seconds.Size = new System.Drawing.Size(74, 20);
            this.lbl_seconds.TabIndex = 33;
            this.lbl_seconds.Text = "Seconds";
            // 
            // num_minutes
            // 
            this.num_minutes.Location = new System.Drawing.Point(105, 56);
            this.num_minutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.num_minutes.Name = "num_minutes";
            this.num_minutes.Size = new System.Drawing.Size(79, 23);
            this.num_minutes.TabIndex = 32;
            // 
            // lbl_minutes
            // 
            this.lbl_minutes.AutoSize = true;
            this.lbl_minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_minutes.Location = new System.Drawing.Point(99, 19);
            this.lbl_minutes.Name = "lbl_minutes";
            this.lbl_minutes.Size = new System.Drawing.Size(68, 20);
            this.lbl_minutes.TabIndex = 31;
            this.lbl_minutes.Text = "Minutes";
            // 
            // num_hours
            // 
            this.num_hours.Location = new System.Drawing.Point(11, 56);
            this.num_hours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.num_hours.Name = "num_hours";
            this.num_hours.Size = new System.Drawing.Size(79, 23);
            this.num_hours.TabIndex = 30;
            // 
            // lbl_hours
            // 
            this.lbl_hours.AutoSize = true;
            this.lbl_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hours.Location = new System.Drawing.Point(7, 19);
            this.lbl_hours.Name = "lbl_hours";
            this.lbl_hours.Size = new System.Drawing.Size(55, 20);
            this.lbl_hours.TabIndex = 29;
            this.lbl_hours.Text = "Hours";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.61524F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.38476F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 113);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.51546F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1058, 389);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btn_Start);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.dgv_export);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 383);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(342, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 28);
            this.button2.TabIndex = 35;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 55);
            this.button1.TabIndex = 34;
            this.button1.Text = "MQC Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_2);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cb_Backlog2Excel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 118);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Task Run";
            // 
            // cb_Backlog2Excel
            // 
            this.cb_Backlog2Excel.AutoSize = true;
            this.cb_Backlog2Excel.Checked = true;
            this.cb_Backlog2Excel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Backlog2Excel.Location = new System.Drawing.Point(6, 39);
            this.cb_Backlog2Excel.Name = "cb_Backlog2Excel";
            this.cb_Backlog2Excel.Size = new System.Drawing.Size(328, 29);
            this.cb_Backlog2Excel.TabIndex = 0;
            this.cb_Backlog2Excel.Text = "Export BackLog Data To Excel";
            this.cb_Backlog2Excel.UseVisualStyleBackColor = true;
            // 
            // dgv_export
            // 
            this.dgv_export.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_export.Location = new System.Drawing.Point(0, 282);
            this.dgv_export.Name = "dgv_export";
            this.dgv_export.ReadOnly = true;
            this.dgv_export.RowHeadersWidth = 51;
            this.dgv_export.RowTemplate.Height = 24;
            this.dgv_export.Size = new System.Drawing.Size(437, 69);
            this.dgv_export.TabIndex = 32;
            this.dgv_export.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_startSendmail);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.btn_Remove);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Controls.Add(this.dgv_show);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(455, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 379);
            this.panel2.TabIndex = 1;
            // 
            // btn_startSendmail
            // 
            this.btn_startSendmail.Location = new System.Drawing.Point(324, 92);
            this.btn_startSendmail.Name = "btn_startSendmail";
            this.btn_startSendmail.Size = new System.Drawing.Size(119, 55);
            this.btn_startSendmail.TabIndex = 35;
            this.btn_startSendmail.Text = "Start";
            this.btn_startSendmail.UseVisualStyleBackColor = true;
            this.btn_startSendmail.Click += new System.EventHandler(this.Btn_startSendmail_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nmr_secondSendmail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nmr_minutesSendMail);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nmr_hoursSendmail);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(4, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 95);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timer";
            // 
            // nmr_secondSendmail
            // 
            this.nmr_secondSendmail.Location = new System.Drawing.Point(205, 56);
            this.nmr_secondSendmail.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmr_secondSendmail.Name = "nmr_secondSendmail";
            this.nmr_secondSendmail.Size = new System.Drawing.Size(79, 23);
            this.nmr_secondSendmail.TabIndex = 34;
            this.nmr_secondSendmail.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(200, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Seconds";
            // 
            // nmr_minutesSendMail
            // 
            this.nmr_minutesSendMail.Location = new System.Drawing.Point(105, 56);
            this.nmr_minutesSendMail.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmr_minutesSendMail.Name = "nmr_minutesSendMail";
            this.nmr_minutesSendMail.Size = new System.Drawing.Size(79, 23);
            this.nmr_minutesSendMail.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(99, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Minutes";
            // 
            // nmr_hoursSendmail
            // 
            this.nmr_hoursSendmail.Location = new System.Drawing.Point(11, 56);
            this.nmr_hoursSendmail.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmr_hoursSendmail.Name = "nmr_hoursSendmail";
            this.nmr_hoursSendmail.Size = new System.Drawing.Size(79, 23);
            this.nmr_hoursSendmail.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Hours";
            // 
            // btn_Remove
            // 
            this.btn_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Remove.Location = new System.Drawing.Point(467, 11);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(119, 52);
            this.btn_Remove.TabIndex = 33;
            this.btn_Remove.Text = "REMOVE";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.Btn_Remove_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(324, 11);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(119, 52);
            this.btn_add.TabIndex = 32;
            this.btn_add.Text = "ADD";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // dgv_show
            // 
            this.dgv_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Location = new System.Drawing.Point(4, 161);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.RowHeadersWidth = 51;
            this.dgv_show.RowTemplate.Height = 24;
            this.dgv_show.Size = new System.Drawing.Size(591, 215);
            this.dgv_show.TabIndex = 31;
            this.dgv_show.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_show_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "Set Time to Send Mail";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 502);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbl_tittle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.lbl_tittle, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_seconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_hours)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_export)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_secondSendmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_minutesSendMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_hoursSendmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label lbl_tittle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown num_seconds;
        private System.Windows.Forms.Label lbl_seconds;
        private System.Windows.Forms.NumericUpDown num_minutes;
        private System.Windows.Forms.Label lbl_minutes;
        private System.Windows.Forms.NumericUpDown num_hours;
        private System.Windows.Forms.Label lbl_hours;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nmr_secondSendmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmr_minutesSendMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmr_hoursSendmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_startSendmail;
        private System.Windows.Forms.DataGridView dgv_export;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_Backlog2Excel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

