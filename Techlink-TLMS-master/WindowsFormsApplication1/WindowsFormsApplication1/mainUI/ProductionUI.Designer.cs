namespace WindowsFormsApplication1.mainUI
{
    partial class ProductionUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_customsDeclaration = new System.Windows.Forms.Button();
            this.btn_Hose = new System.Windows.Forms.Button();
            this.btn_TypingInfor = new System.Windows.Forms.Button();
            this.btn_Oven = new System.Windows.Forms.Button();
            this.btn_FinishedGoods = new System.Windows.Forms.Button();
            this.btn_backlogReport = new System.Windows.Forms.Button();
            this.btn_Reliability = new System.Windows.Forms.Button();
            this.btn_MQCReview = new System.Windows.Forms.Button();
            this.btn_wms = new System.Windows.Forms.Button();
            this.btn_Planning = new System.Windows.Forms.Button();
            this.btn_MQC = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox1.Controls.Add(this.btn_customsDeclaration);
            this.groupBox1.Controls.Add(this.btn_Hose);
            this.groupBox1.Controls.Add(this.btn_TypingInfor);
            this.groupBox1.Controls.Add(this.btn_Oven);
            this.groupBox1.Controls.Add(this.btn_FinishedGoods);
            this.groupBox1.Controls.Add(this.btn_backlogReport);
            this.groupBox1.Controls.Add(this.btn_Reliability);
            this.groupBox1.Controls.Add(this.btn_MQCReview);
            this.groupBox1.Controls.Add(this.btn_wms);
            this.groupBox1.Controls.Add(this.btn_Planning);
            this.groupBox1.Controls.Add(this.btn_MQC);
            this.groupBox1.Location = new System.Drawing.Point(5, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 397);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // btn_customsDeclaration
            // 
            this.btn_customsDeclaration.BackColor = System.Drawing.Color.White;
            this.btn_customsDeclaration.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_customsDeclaration.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_customsDeclaration.Image = global::WindowsFormsApplication1.Properties.Resources.Customs_64;
            this.btn_customsDeclaration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_customsDeclaration.Location = new System.Drawing.Point(32, 284);
            this.btn_customsDeclaration.Margin = new System.Windows.Forms.Padding(4);
            this.btn_customsDeclaration.Name = "btn_customsDeclaration";
            this.btn_customsDeclaration.Size = new System.Drawing.Size(225, 72);
            this.btn_customsDeclaration.TabIndex = 38;
            this.btn_customsDeclaration.Text = "Customs Declaration";
            this.btn_customsDeclaration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_customsDeclaration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_customsDeclaration.UseVisualStyleBackColor = false;
            this.btn_customsDeclaration.Click += new System.EventHandler(this.btn_customsDeclaration_Click);
            // 
            // btn_Hose
            // 
            this.btn_Hose.BackColor = System.Drawing.Color.White;
            this.btn_Hose.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_Hose.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Hose.Image = global::WindowsFormsApplication1.Properties.Resources.ProductionPlan;
            this.btn_Hose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Hose.Location = new System.Drawing.Point(598, 198);
            this.btn_Hose.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Hose.Name = "btn_Hose";
            this.btn_Hose.Size = new System.Drawing.Size(223, 69);
            this.btn_Hose.TabIndex = 37;
            this.btn_Hose.Text = "PMC planning (Hose)";
            this.btn_Hose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Hose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Hose.UseVisualStyleBackColor = false;
            this.btn_Hose.Click += new System.EventHandler(this.btn_Hose_Click);
            // 
            // btn_TypingInfor
            // 
            this.btn_TypingInfor.BackColor = System.Drawing.Color.White;
            this.btn_TypingInfor.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_TypingInfor.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_TypingInfor.Image = global::WindowsFormsApplication1.Properties.Resources.materialAlarm_64;
            this.btn_TypingInfor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TypingInfor.Location = new System.Drawing.Point(598, 107);
            this.btn_TypingInfor.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TypingInfor.Name = "btn_TypingInfor";
            this.btn_TypingInfor.Size = new System.Drawing.Size(223, 72);
            this.btn_TypingInfor.TabIndex = 36;
            this.btn_TypingInfor.Text = "Product Information";
            this.btn_TypingInfor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TypingInfor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_TypingInfor.UseVisualStyleBackColor = false;
            this.btn_TypingInfor.Click += new System.EventHandler(this.btn_TypingInfor_Click);
            // 
            // btn_Oven
            // 
            this.btn_Oven.BackColor = System.Drawing.Color.White;
            this.btn_Oven.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_Oven.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Oven.Image = global::WindowsFormsApplication1.Properties.Resources.oven_64;
            this.btn_Oven.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Oven.Location = new System.Drawing.Point(600, 23);
            this.btn_Oven.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Oven.Name = "btn_Oven";
            this.btn_Oven.Size = new System.Drawing.Size(221, 72);
            this.btn_Oven.TabIndex = 35;
            this.btn_Oven.Text = "OVEN";
            this.btn_Oven.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Oven.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Oven.UseVisualStyleBackColor = false;
            this.btn_Oven.Click += new System.EventHandler(this.btn_Oven_Click);
            // 
            // btn_FinishedGoods
            // 
            this.btn_FinishedGoods.BackColor = System.Drawing.Color.White;
            this.btn_FinishedGoods.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_FinishedGoods.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_FinishedGoods.Image = global::WindowsFormsApplication1.Properties.Resources.finishedGoods_64;
            this.btn_FinishedGoods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FinishedGoods.Location = new System.Drawing.Point(32, 195);
            this.btn_FinishedGoods.Margin = new System.Windows.Forms.Padding(4);
            this.btn_FinishedGoods.Name = "btn_FinishedGoods";
            this.btn_FinishedGoods.Size = new System.Drawing.Size(225, 72);
            this.btn_FinishedGoods.TabIndex = 34;
            this.btn_FinishedGoods.Text = "Stock in / out (Finished goods)";
            this.btn_FinishedGoods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FinishedGoods.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_FinishedGoods.UseVisualStyleBackColor = false;
            this.btn_FinishedGoods.Click += new System.EventHandler(this.btn_FinishedGoods_Click);
            // 
            // btn_backlogReport
            // 
            this.btn_backlogReport.BackColor = System.Drawing.Color.White;
            this.btn_backlogReport.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_backlogReport.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_backlogReport.Image = global::WindowsFormsApplication1.Properties.Resources.Backlog;
            this.btn_backlogReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_backlogReport.Location = new System.Drawing.Point(313, 107);
            this.btn_backlogReport.Margin = new System.Windows.Forms.Padding(4);
            this.btn_backlogReport.Name = "btn_backlogReport";
            this.btn_backlogReport.Size = new System.Drawing.Size(223, 72);
            this.btn_backlogReport.TabIndex = 32;
            this.btn_backlogReport.Text = "Back-log Report";
            this.btn_backlogReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_backlogReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_backlogReport.UseVisualStyleBackColor = false;
            this.btn_backlogReport.Click += new System.EventHandler(this.btn_backlogReport_Click);
            // 
            // btn_Reliability
            // 
            this.btn_Reliability.BackColor = System.Drawing.Color.White;
            this.btn_Reliability.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_Reliability.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Reliability.Image = global::WindowsFormsApplication1.Properties.Resources.Reliability1;
            this.btn_Reliability.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reliability.Location = new System.Drawing.Point(32, 107);
            this.btn_Reliability.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Reliability.Name = "btn_Reliability";
            this.btn_Reliability.Size = new System.Drawing.Size(225, 72);
            this.btn_Reliability.TabIndex = 31;
            this.btn_Reliability.Text = "Reliability Report";
            this.btn_Reliability.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reliability.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Reliability.UseVisualStyleBackColor = false;
            this.btn_Reliability.Click += new System.EventHandler(this.btn_Reliability_Click);
            // 
            // btn_MQCReview
            // 
            this.btn_MQCReview.BackColor = System.Drawing.Color.White;
            this.btn_MQCReview.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_MQCReview.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_MQCReview.Image = global::WindowsFormsApplication1.Properties.Resources.Analysis_64;
            this.btn_MQCReview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MQCReview.Location = new System.Drawing.Point(313, 22);
            this.btn_MQCReview.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MQCReview.Name = "btn_MQCReview";
            this.btn_MQCReview.Size = new System.Drawing.Size(223, 72);
            this.btn_MQCReview.TabIndex = 29;
            this.btn_MQCReview.Text = "MQC Report";
            this.btn_MQCReview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MQCReview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_MQCReview.UseVisualStyleBackColor = false;
            this.btn_MQCReview.Click += new System.EventHandler(this.btn_MQCReview_Click);
            // 
            // btn_wms
            // 
            this.btn_wms.BackColor = System.Drawing.Color.White;
            this.btn_wms.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_wms.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_wms.Image = global::WindowsFormsApplication1.Properties.Resources.warehouse_64;
            this.btn_wms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_wms.Location = new System.Drawing.Point(313, 195);
            this.btn_wms.Margin = new System.Windows.Forms.Padding(4);
            this.btn_wms.Name = "btn_wms";
            this.btn_wms.Size = new System.Drawing.Size(225, 72);
            this.btn_wms.TabIndex = 28;
            this.btn_wms.Text = "Stock in / out (Raw material)";
            this.btn_wms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_wms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_wms.UseVisualStyleBackColor = false;
            this.btn_wms.Click += new System.EventHandler(this.btn_wms_Click);
            // 
            // btn_Planning
            // 
            this.btn_Planning.BackColor = System.Drawing.Color.White;
            this.btn_Planning.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_Planning.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_Planning.Image = global::WindowsFormsApplication1.Properties.Resources.ProductionPlan;
            this.btn_Planning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Planning.Location = new System.Drawing.Point(600, 287);
            this.btn_Planning.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Planning.Name = "btn_Planning";
            this.btn_Planning.Size = new System.Drawing.Size(223, 69);
            this.btn_Planning.TabIndex = 27;
            this.btn_Planning.Text = "PMC planning (Component)";
            this.btn_Planning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Planning.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Planning.UseVisualStyleBackColor = false;
            this.btn_Planning.Click += new System.EventHandler(this.btn_Planning_Click);
            // 
            // btn_MQC
            // 
            this.btn_MQC.BackColor = System.Drawing.Color.White;
            this.btn_MQC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MQC.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_MQC.Image = global::WindowsFormsApplication1.Properties.Resources.MQC_64;
            this.btn_MQC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MQC.Location = new System.Drawing.Point(32, 23);
            this.btn_MQC.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MQC.Name = "btn_MQC";
            this.btn_MQC.Size = new System.Drawing.Size(225, 72);
            this.btn_MQC.TabIndex = 24;
            this.btn_MQC.Text = "MQC (real-time data)";
            this.btn_MQC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MQC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_MQC.UseVisualStyleBackColor = false;
            this.btn_MQC.Click += new System.EventHandler(this.btn_MQC_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(12, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 31);
            this.button1.TabIndex = 19;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProductionUI";
            this.Text = "ProductionUI";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_TypingInfor;
        private System.Windows.Forms.Button btn_Oven;
        private System.Windows.Forms.Button btn_FinishedGoods;
        private System.Windows.Forms.Button btn_backlogReport;
        private System.Windows.Forms.Button btn_Reliability;
        private System.Windows.Forms.Button btn_MQCReview;
        private System.Windows.Forms.Button btn_wms;
        private System.Windows.Forms.Button btn_Planning;
        private System.Windows.Forms.Button btn_MQC;
        private System.Windows.Forms.Button btn_Hose;
        private System.Windows.Forms.Button btn_customsDeclaration;
    }
}