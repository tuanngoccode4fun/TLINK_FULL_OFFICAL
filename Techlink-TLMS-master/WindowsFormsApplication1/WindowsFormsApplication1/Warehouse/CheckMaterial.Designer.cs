namespace WindowsFormsApplication1.Warehouse
{
    partial class CheckMaterial
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
            this.grb_hearder = new System.Windows.Forms.GroupBox();
            this.txt_Lot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_materialcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.btn_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.cmb_warehousecode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grb_hearder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_hearder
            // 
            this.grb_hearder.Controls.Add(this.label4);
            this.grb_hearder.Controls.Add(this.cmb_warehousecode);
            this.grb_hearder.Controls.Add(this.txt_Lot);
            this.grb_hearder.Controls.Add(this.label2);
            this.grb_hearder.Controls.Add(this.btn_save);
            this.grb_hearder.Controls.Add(this.txt_materialcode);
            this.grb_hearder.Controls.Add(this.label3);
            this.grb_hearder.Controls.Add(this.dtp_to);
            this.grb_hearder.Controls.Add(this.btn_search);
            this.grb_hearder.Controls.Add(this.label1);
            this.grb_hearder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grb_hearder.Location = new System.Drawing.Point(0, 60);
            this.grb_hearder.Name = "grb_hearder";
            this.grb_hearder.Size = new System.Drawing.Size(1471, 163);
            this.grb_hearder.TabIndex = 3;
            this.grb_hearder.TabStop = false;
            this.grb_hearder.Text = "Header";
            // 
            // txt_Lot
            // 
            this.txt_Lot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Lot.Location = new System.Drawing.Point(179, 93);
            this.txt_Lot.Name = "txt_Lot";
            this.txt_Lot.Size = new System.Drawing.Size(244, 30);
            this.txt_Lot.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 41;
            this.label2.Text = "LOT";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(981, 93);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 38);
            this.btn_save.TabIndex = 40;
            this.btn_save.Text = "Export Excel";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_materialcode
            // 
            this.txt_materialcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_materialcode.Location = new System.Drawing.Point(179, 35);
            this.txt_materialcode.Name = "txt_materialcode";
            this.txt_materialcode.Size = new System.Drawing.Size(244, 30);
            this.txt_materialcode.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 35;
            this.label3.Text = "Date Time To:";
            // 
            // dtp_to
            // 
            this.dtp_to.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.CustomFormat = "yyyy-MM-dd";
            this.dtp_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(651, 99);
            this.dtp_to.Margin = new System.Windows.Forms.Padding(5);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(202, 26);
            this.dtp_to.TabIndex = 33;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(981, 33);
            this.btn_search.Margin = new System.Windows.Forms.Padding(5);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(148, 37);
            this.btn_search.TabIndex = 32;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Material Code:";
            // 
            // dgv_show
            // 
            this.dgv_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Location = new System.Drawing.Point(12, 229);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.RowHeadersWidth = 62;
            this.dgv_show.RowTemplate.Height = 28;
            this.dgv_show.Size = new System.Drawing.Size(1366, 369);
            this.dgv_show.TabIndex = 6;
            // 
            // cmb_warehousecode
            // 
            this.cmb_warehousecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_warehousecode.FormattingEnabled = true;
            this.cmb_warehousecode.Location = new System.Drawing.Point(651, 37);
            this.cmb_warehousecode.Name = "cmb_warehousecode";
            this.cmb_warehousecode.Size = new System.Drawing.Size(202, 33);
            this.cmb_warehousecode.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(455, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 25);
            this.label4.TabIndex = 44;
            this.label4.Text = "WarehouseCode:";
            // 
            // CheckMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 610);
            this.Controls.Add(this.dgv_show);
            this.Controls.Add(this.grb_hearder);
            this.Name = "CheckMaterial";
            this.Text = "CheckMaterial";
            this.Load += new System.EventHandler(this.CheckMaterial_Load);
            this.Controls.SetChildIndex(this.grb_hearder, 0);
            this.Controls.SetChildIndex(this.dgv_show, 0);
            this.grb_hearder.ResumeLayout(false);
            this.grb_hearder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_hearder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_materialcode;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_Lot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_warehousecode;
    }
}