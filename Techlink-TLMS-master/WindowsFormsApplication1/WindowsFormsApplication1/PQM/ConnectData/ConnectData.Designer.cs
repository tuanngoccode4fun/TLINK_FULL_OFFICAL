namespace WindowsFormsApplication1.PQM.ConnectData
{
    partial class ConnectData
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_modelcode = new System.Windows.Forms.ComboBox();
            this.tv_model = new System.Windows.Forms.TreeView();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_processcode = new System.Windows.Forms.ComboBox();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Model Code:";
            // 
            // cmb_modelcode
            // 
            this.cmb_modelcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_modelcode.FormattingEnabled = true;
            this.cmb_modelcode.Location = new System.Drawing.Point(266, 94);
            this.cmb_modelcode.Name = "cmb_modelcode";
            this.cmb_modelcode.Size = new System.Drawing.Size(130, 24);
            this.cmb_modelcode.TabIndex = 11;
            this.cmb_modelcode.SelectedIndexChanged += new System.EventHandler(this.cmb_modelcode_SelectedIndexChanged);
            // 
            // tv_model
            // 
            this.tv_model.CheckBoxes = true;
            this.tv_model.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_model.Location = new System.Drawing.Point(0, 60);
            this.tv_model.Name = "tv_model";
            this.tv_model.Size = new System.Drawing.Size(238, 542);
            this.tv_model.TabIndex = 13;
            // 
            // dgv_show
            // 
            this.dgv_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Location = new System.Drawing.Point(236, 135);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.Size = new System.Drawing.Size(1066, 467);
            this.dgv_show.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(421, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Process Code:";
            // 
            // cmb_processcode
            // 
            this.cmb_processcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_processcode.FormattingEnabled = true;
            this.cmb_processcode.Location = new System.Drawing.Point(421, 94);
            this.cmb_processcode.Name = "cmb_processcode";
            this.cmb_processcode.Size = new System.Drawing.Size(130, 24);
            this.cmb_processcode.TabIndex = 15;
            this.cmb_processcode.SelectedIndexChanged += new System.EventHandler(this.cmb_processcode_SelectedIndexChanged);
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(599, 98);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(153, 20);
            this.dtp_to.TabIndex = 17;
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(788, 98);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(153, 20);
            this.dtp_from.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(596, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Date Time To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(785, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Date Time From:";
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(1008, 79);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(101, 43);
            this.btn_search.TabIndex = 21;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // ConnectData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 602);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_from);
            this.Controls.Add(this.dtp_to);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_processcode);
            this.Controls.Add(this.dgv_show);
            this.Controls.Add(this.tv_model);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_modelcode);
            this.Name = "ConnectData";
            this.Text = "ConnectData";
            this.Load += new System.EventHandler(this.ConnectData_Load);
            this.Controls.SetChildIndex(this.cmb_modelcode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tv_model, 0);
            this.Controls.SetChildIndex(this.dgv_show, 0);
            this.Controls.SetChildIndex(this.cmb_processcode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtp_to, 0);
            this.Controls.SetChildIndex(this.dtp_from, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btn_search, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_modelcode;
        private System.Windows.Forms.TreeView tv_model;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_processcode;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_search;
    }
}