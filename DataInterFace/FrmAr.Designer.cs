namespace DataInterFace
{
    partial class FrmAr
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtfileName = new System.Windows.Forms.TextBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnInvoiceAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtfileName);
            this.panel1.Controls.Add(this.btnLoadData);
            this.panel1.Controls.Add(this.btnInvoiceAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 61);
            this.panel1.TabIndex = 0;
            // 
            // txtfileName
            // 
            this.txtfileName.Location = new System.Drawing.Point(14, 17);
            this.txtfileName.Name = "txtfileName";
            this.txtfileName.Size = new System.Drawing.Size(323, 21);
            this.txtfileName.TabIndex = 8;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(343, 17);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 6;
            this.btnLoadData.Text = "读取excel";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click_1);
            // 
            // btnInvoiceAdd
            // 
            this.btnInvoiceAdd.Location = new System.Drawing.Point(475, 17);
            this.btnInvoiceAdd.Name = "btnInvoiceAdd";
            this.btnInvoiceAdd.Size = new System.Drawing.Size(75, 23);
            this.btnInvoiceAdd.TabIndex = 7;
            this.btnInvoiceAdd.Text = "生成发票";
            this.btnInvoiceAdd.UseVisualStyleBackColor = true;
            this.btnInvoiceAdd.Click += new System.EventHandler(this.btnInvoiceAdd_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(931, 389);
            this.dataGridView1.TabIndex = 1;
            // 
            // FrmAr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAr";
            this.Size = new System.Drawing.Size(931, 450);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtfileName;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnInvoiceAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}