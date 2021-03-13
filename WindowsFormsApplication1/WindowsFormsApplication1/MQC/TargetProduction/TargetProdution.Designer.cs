namespace WindowsFormsApplication1.MQC.TargetProduction
{
    partial class TargetProdution
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
            this.tab_targetDaily = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_target = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_insert = new System.Windows.Forms.Button();
            this.col_Dept = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_product = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_ApplyDate = new Com.Nidec.Mes.Framework.DataGridViewDateTimeColumn();
            this.col_expire = new Com.Nidec.Mes.Framework.DataGridViewDateTimeColumn();
            this.col_Flag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_TA01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TA12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_targetDaily.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_target)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_targetDaily
            // 
            this.tab_targetDaily.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_targetDaily.Controls.Add(this.tabPage1);
            this.tab_targetDaily.Controls.Add(this.tabPage2);
            this.tab_targetDaily.Location = new System.Drawing.Point(12, 67);
            this.tab_targetDaily.Name = "tab_targetDaily";
            this.tab_targetDaily.SelectedIndex = 0;
            this.tab_targetDaily.Size = new System.Drawing.Size(1117, 594);
            this.tab_targetDaily.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1109, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtgv_target, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1096, 554);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtgv_target
            // 
            this.dtgv_target.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_target.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgv_target.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dtgv_target.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.dtgv_target.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_target.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Dept,
            this.col_product,
            this.col_type,
            this.col_ApplyDate,
            this.col_expire,
            this.col_Flag,
            this.col_TA01,
            this.col_TA02,
            this.col_TA03,
            this.col_TA04,
            this.col_TA05,
            this.col_TA06,
            this.col_TA07,
            this.col_TA08,
            this.col_TA09,
            this.col_TA10,
            this.col_TA11,
            this.col_TA12});
            this.dtgv_target.GridColor = System.Drawing.Color.DarkKhaki;
            this.dtgv_target.Location = new System.Drawing.Point(3, 53);
            this.dtgv_target.Name = "dtgv_target";
            this.dtgv_target.RowHeadersWidth = 51;
            this.dtgv_target.RowTemplate.Height = 24;
            this.dtgv_target.Size = new System.Drawing.Size(1090, 498);
            this.dtgv_target.TabIndex = 1;
            this.dtgv_target.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtgv_target_CellClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btn_refresh, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_update, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_insert, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1090, 44);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1109, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_refresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(993, 3);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(94, 38);
            this.btn_refresh.TabIndex = 0;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = false;
            // 
            // btn_update
            // 
            this.btn_update.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_update.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_update.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(893, 3);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(94, 38);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = false;
            // 
            // btn_insert
            // 
            this.btn_insert.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_insert.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_insert.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insert.Location = new System.Drawing.Point(793, 3);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(94, 38);
            this.btn_insert.TabIndex = 2;
            this.btn_insert.Text = "Insert";
            this.btn_insert.UseVisualStyleBackColor = false;
            this.btn_insert.Click += new System.EventHandler(this.Btn_insert_Click);
            // 
            // col_Dept
            // 
            this.col_Dept.HeaderText = "Departments";
            this.col_Dept.MinimumWidth = 100;
            this.col_Dept.Name = "col_Dept";
            this.col_Dept.Width = 106;
            // 
            // col_product
            // 
            this.col_product.HeaderText = "Product";
            this.col_product.MinimumWidth = 100;
            this.col_product.Name = "col_product";
            this.col_product.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_type
            // 
            this.col_type.HeaderText = "Target Type";
            this.col_type.MinimumWidth = 100;
            this.col_type.Name = "col_type";
            this.col_type.Width = 103;
            // 
            // col_ApplyDate
            // 
            this.col_ApplyDate.HeaderText = "Apply Date";
            this.col_ApplyDate.MinimumWidth = 100;
            this.col_ApplyDate.Name = "col_ApplyDate";
            // 
            // col_expire
            // 
            this.col_expire.HeaderText = "Expire Date";
            this.col_expire.MinimumWidth = 100;
            this.col_expire.Name = "col_expire";
            // 
            // col_Flag
            // 
            this.col_Flag.HeaderText = "Confirmination";
            this.col_Flag.MinimumWidth = 100;
            this.col_Flag.Name = "col_Flag";
            this.col_Flag.Width = 118;
            // 
            // col_TA01
            // 
            this.col_TA01.HeaderText = "0-2";
            this.col_TA01.MinimumWidth = 6;
            this.col_TA01.Name = "col_TA01";
            this.col_TA01.Width = 61;
            // 
            // col_TA02
            // 
            this.col_TA02.HeaderText = "2-4";
            this.col_TA02.MinimumWidth = 6;
            this.col_TA02.Name = "col_TA02";
            this.col_TA02.Width = 61;
            // 
            // col_TA03
            // 
            this.col_TA03.HeaderText = "4-6";
            this.col_TA03.MinimumWidth = 6;
            this.col_TA03.Name = "col_TA03";
            this.col_TA03.Width = 61;
            // 
            // col_TA04
            // 
            this.col_TA04.HeaderText = "6-8";
            this.col_TA04.MinimumWidth = 6;
            this.col_TA04.Name = "col_TA04";
            this.col_TA04.Width = 61;
            // 
            // col_TA05
            // 
            this.col_TA05.HeaderText = "8-10";
            this.col_TA05.MinimumWidth = 6;
            this.col_TA05.Name = "col_TA05";
            this.col_TA05.Width = 70;
            // 
            // col_TA06
            // 
            this.col_TA06.HeaderText = "10-12";
            this.col_TA06.MinimumWidth = 6;
            this.col_TA06.Name = "col_TA06";
            this.col_TA06.Width = 79;
            // 
            // col_TA07
            // 
            this.col_TA07.HeaderText = "12-14";
            this.col_TA07.MinimumWidth = 6;
            this.col_TA07.Name = "col_TA07";
            this.col_TA07.Width = 79;
            // 
            // col_TA08
            // 
            this.col_TA08.HeaderText = "14-16";
            this.col_TA08.MinimumWidth = 6;
            this.col_TA08.Name = "col_TA08";
            this.col_TA08.Width = 79;
            // 
            // col_TA09
            // 
            this.col_TA09.HeaderText = "16-18";
            this.col_TA09.MinimumWidth = 6;
            this.col_TA09.Name = "col_TA09";
            this.col_TA09.Width = 79;
            // 
            // col_TA10
            // 
            this.col_TA10.HeaderText = "18-20";
            this.col_TA10.MinimumWidth = 6;
            this.col_TA10.Name = "col_TA10";
            this.col_TA10.Width = 79;
            // 
            // col_TA11
            // 
            this.col_TA11.HeaderText = "20-22";
            this.col_TA11.MinimumWidth = 6;
            this.col_TA11.Name = "col_TA11";
            this.col_TA11.Width = 79;
            // 
            // col_TA12
            // 
            this.col_TA12.HeaderText = "20-24";
            this.col_TA12.MinimumWidth = 6;
            this.col_TA12.Name = "col_TA12";
            this.col_TA12.Width = 79;
            // 
            // TargetProdution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 673);
            this.Controls.Add(this.tab_targetDaily);
            this.Name = "TargetProdution";
            this.Text = "TargetProdution";
            this.Controls.SetChildIndex(this.tab_targetDaily, 0);
            this.tab_targetDaily.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_target)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tab_targetDaily;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtgv_target;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_Dept;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_product;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_type;
        private Com.Nidec.Mes.Framework.DataGridViewDateTimeColumn col_ApplyDate;
        private Com.Nidec.Mes.Framework.DataGridViewDateTimeColumn col_expire;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA01;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA02;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA03;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA04;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA05;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA06;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA07;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA08;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA09;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA10;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA11;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TA12;
    }
}