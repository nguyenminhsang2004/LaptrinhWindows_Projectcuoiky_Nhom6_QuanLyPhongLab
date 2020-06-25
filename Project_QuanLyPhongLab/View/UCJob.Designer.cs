namespace Project_QuanLyPhongLab.View
{
    partial class UCJob
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.llblTL = new System.Windows.Forms.LinkLabel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpCV = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCTCV = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDone = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.llblTL);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 44);
            this.panel1.TabIndex = 0;
            // 
            // llblTL
            // 
            this.llblTL.AutoSize = true;
            this.llblTL.Location = new System.Drawing.Point(830, 15);
            this.llblTL.Name = "llblTL";
            this.llblTL.Size = new System.Drawing.Size(41, 13);
            this.llblTL.TabIndex = 8;
            this.llblTL.TabStop = true;
            this.llblTL.Text = "Tài liệu";
            this.llblTL.Click += new System.EventHandler(this.llblTL_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(777, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(46, 29);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(725, 9);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(46, 29);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpCV);
            this.groupBox3.Location = new System.Drawing.Point(518, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(111, 36);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ngày hoàn thành:";
            // 
            // dtpCV
            // 
            this.dtpCV.CustomFormat = "dd/MM/yyyy";
            this.dtpCV.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCV.Location = new System.Drawing.Point(9, 15);
            this.dtpCV.Name = "dtpCV";
            this.dtpCV.Size = new System.Drawing.Size(96, 20);
            this.dtpCV.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtID);
            this.groupBox2.Controls.Add(this.txtCTCV);
            this.groupBox2.Location = new System.Drawing.Point(4, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 38);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin công việc:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(6, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(58, 20);
            this.txtID.TabIndex = 1;
            // 
            // txtCTCV
            // 
            this.txtCTCV.Location = new System.Drawing.Point(70, 14);
            this.txtCTCV.Name = "txtCTCV";
            this.txtCTCV.Size = new System.Drawing.Size(434, 20);
            this.txtCTCV.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDone);
            this.groupBox1.Location = new System.Drawing.Point(635, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 35);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hoàn thành:";
            // 
            // cbDone
            // 
            this.cbDone.AutoSize = true;
            this.cbDone.Location = new System.Drawing.Point(34, 16);
            this.cbDone.Name = "cbDone";
            this.cbDone.Size = new System.Drawing.Size(15, 14);
            this.cbDone.TabIndex = 0;
            this.cbDone.UseVisualStyleBackColor = true;
            this.cbDone.CheckedChanged += new System.EventHandler(this.cbDone_CheckedChanged);
            // 
            // UCJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UCJob";
            this.Size = new System.Drawing.Size(891, 44);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpCV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCTCV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbDone;
        private System.Windows.Forms.LinkLabel llblTL;
    }
}
