namespace DataInterFace
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.appDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.busType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exchanLossPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exchangeReate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exchangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invocieWay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mergeState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdfInvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdfPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppServiceInvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppServiceInvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zpServiceInvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zpServiceInvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.belongMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.candidateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactDefine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linemobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shippingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainPrcie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exchanLossPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankServicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInvoiceAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnpiwB = new System.Windows.Forms.Button();
            this.btnExportPi = new System.Windows.Forms.Button();
            this.txtcusname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpE = new System.Windows.Forms.DateTimePicker();
            this.dtpS = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtfileName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(400, 22);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "读取excel";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appDate,
            this.invoiceCompany,
            this.invoiceType,
            this.busType,
            this.dep,
            this.itemcode,
            this.itemName,
            this.cusname,
            this.taxNo,
            this.depositBank,
            this.AccNo,
            this.Address,
            this.Contact,
            this.Phone,
            this.item1,
            this.Amt1,
            this.Item2,
            this.Amt2,
            this.Item3,
            this.Amt3,
            this.Item4,
            this.Amt4,
            this.Item5,
            this.Amt5,
            this.Item6,
            this.Amt6,
            this.Item7,
            this.Amt7,
            this.Item8,
            this.Amt8,
            this.Sub_total,
            this.exchanLossPrice1,
            this.currency,
            this.exchangeReate,
            this.exchangeDate,
            this.invocieWay,
            this.mergeState,
            this.dsdfInvName,
            this.dsdfPrice,
            this.ppServiceInvName,
            this.ppServiceInvPrice,
            this.zpServiceInvName,
            this.zpServiceInvPrice,
            this.belongMonth,
            this.remark,
            this.qc,
            this.dueDate,
            this.candidateName,
            this.addressee,
            this.ContactDefine,
            this.linkPhone,
            this.linemobile,
            this.shippingAddress,
            this.ECPrice,
            this.SFPrice,
            this.trainPrcie,
            this.exchanLossPrice,
            this.bankServicePrice});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1484, 471);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // appDate
            // 
            this.appDate.DataPropertyName = "appDate";
            this.appDate.Frozen = true;
            this.appDate.HeaderText = "申请日期";
            this.appDate.Name = "appDate";
            // 
            // invoiceCompany
            // 
            this.invoiceCompany.DataPropertyName = "invoiceCompany";
            this.invoiceCompany.Frozen = true;
            this.invoiceCompany.HeaderText = "开票公司";
            this.invoiceCompany.Name = "invoiceCompany";
            // 
            // invoiceType
            // 
            this.invoiceType.DataPropertyName = "invoiceType";
            this.invoiceType.Frozen = true;
            this.invoiceType.HeaderText = "开票类型";
            this.invoiceType.Name = "invoiceType";
            // 
            // busType
            // 
            this.busType.DataPropertyName = "busType";
            this.busType.Frozen = true;
            this.busType.HeaderText = "业务类型";
            this.busType.Name = "busType";
            // 
            // dep
            // 
            this.dep.DataPropertyName = "dep";
            this.dep.Frozen = true;
            this.dep.HeaderText = "部门";
            this.dep.Name = "dep";
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.Frozen = true;
            this.itemcode.HeaderText = "项目编号";
            this.itemcode.Name = "itemcode";
            // 
            // itemName
            // 
            this.itemName.DataPropertyName = "itemName";
            this.itemName.Frozen = true;
            this.itemName.HeaderText = "项目简称";
            this.itemName.Name = "itemName";
            // 
            // cusname
            // 
            this.cusname.DataPropertyName = "cusname";
            this.cusname.Frozen = true;
            this.cusname.HeaderText = "开票客户全称";
            this.cusname.Name = "cusname";
            // 
            // taxNo
            // 
            this.taxNo.DataPropertyName = "taxNo";
            this.taxNo.HeaderText = "Tax No.";
            this.taxNo.Name = "taxNo";
            // 
            // depositBank
            // 
            this.depositBank.DataPropertyName = "depositBank";
            this.depositBank.HeaderText = "Deposit Bank";
            this.depositBank.Name = "depositBank";
            // 
            // AccNo
            // 
            this.AccNo.DataPropertyName = "AccNo";
            this.AccNo.HeaderText = "Account No.";
            this.AccNo.Name = "AccNo";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // Contact
            // 
            this.Contact.DataPropertyName = "Contact";
            this.Contact.HeaderText = "Attention";
            this.Contact.Name = "Contact";
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Tel";
            this.Phone.Name = "Phone";
            // 
            // item1
            // 
            this.item1.DataPropertyName = "Item1";
            this.item1.HeaderText = "Item 1";
            this.item1.Name = "item1";
            // 
            // Amt1
            // 
            this.Amt1.DataPropertyName = "Amt1";
            this.Amt1.HeaderText = "Amt 1";
            this.Amt1.Name = "Amt1";
            // 
            // Item2
            // 
            this.Item2.DataPropertyName = "Item2";
            this.Item2.HeaderText = "Item 2";
            this.Item2.Name = "Item2";
            // 
            // Amt2
            // 
            this.Amt2.DataPropertyName = "Amt2";
            this.Amt2.HeaderText = "Amt 2";
            this.Amt2.Name = "Amt2";
            // 
            // Item3
            // 
            this.Item3.DataPropertyName = "Item3";
            this.Item3.HeaderText = "Item 3";
            this.Item3.Name = "Item3";
            // 
            // Amt3
            // 
            this.Amt3.DataPropertyName = "Amt3";
            this.Amt3.HeaderText = "Amt 3";
            this.Amt3.Name = "Amt3";
            // 
            // Item4
            // 
            this.Item4.DataPropertyName = "Item4";
            this.Item4.HeaderText = "Item 4";
            this.Item4.Name = "Item4";
            // 
            // Amt4
            // 
            this.Amt4.DataPropertyName = "Amt4";
            this.Amt4.HeaderText = "Amt 4";
            this.Amt4.Name = "Amt4";
            // 
            // Item5
            // 
            this.Item5.DataPropertyName = "Item5";
            this.Item5.HeaderText = "Item 5";
            this.Item5.Name = "Item5";
            // 
            // Amt5
            // 
            this.Amt5.DataPropertyName = "Amt5";
            this.Amt5.HeaderText = "Amt 5";
            this.Amt5.Name = "Amt5";
            // 
            // Item6
            // 
            this.Item6.DataPropertyName = "Item6";
            this.Item6.HeaderText = "Item 6";
            this.Item6.Name = "Item6";
            // 
            // Amt6
            // 
            this.Amt6.DataPropertyName = "Amt6";
            this.Amt6.HeaderText = "Amt 6";
            this.Amt6.Name = "Amt6";
            // 
            // Item7
            // 
            this.Item7.DataPropertyName = "Item7";
            this.Item7.HeaderText = "Item 7";
            this.Item7.Name = "Item7";
            // 
            // Amt7
            // 
            this.Amt7.DataPropertyName = "Amt7";
            this.Amt7.HeaderText = "Amt 7";
            this.Amt7.Name = "Amt7";
            // 
            // Item8
            // 
            this.Item8.DataPropertyName = "Item8";
            this.Item8.HeaderText = "Item 8";
            this.Item8.Name = "Item8";
            // 
            // Amt8
            // 
            this.Amt8.DataPropertyName = "Amt8";
            this.Amt8.HeaderText = "Amt 8";
            this.Amt8.Name = "Amt8";
            // 
            // Sub_total
            // 
            this.Sub_total.DataPropertyName = "Sub_total";
            this.Sub_total.HeaderText = "Sub-total amount to TS";
            this.Sub_total.Name = "Sub_total";
            // 
            // exchanLossPrice1
            // 
            this.exchanLossPrice1.DataPropertyName = "exchanLossPrice";
            this.exchanLossPrice1.HeaderText = "向客户收取的银行手续费 ";
            this.exchanLossPrice1.Name = "exchanLossPrice1";
            // 
            // currency
            // 
            this.currency.DataPropertyName = "currency";
            this.currency.HeaderText = "币种";
            this.currency.Name = "currency";
            // 
            // exchangeReate
            // 
            this.exchangeReate.DataPropertyName = "exchangeReate";
            this.exchangeReate.HeaderText = "汇率";
            this.exchangeReate.Name = "exchangeReate";
            // 
            // exchangeDate
            // 
            this.exchangeDate.DataPropertyName = "exchangeDate";
            this.exchangeDate.HeaderText = "汇率日期";
            this.exchangeDate.Name = "exchangeDate";
            // 
            // invocieWay
            // 
            this.invocieWay.DataPropertyName = "invocieWay";
            this.invocieWay.HeaderText = "开票方式";
            this.invocieWay.Name = "invocieWay";
            // 
            // mergeState
            // 
            this.mergeState.DataPropertyName = "mergeState";
            this.mergeState.HeaderText = "合并标识";
            this.mergeState.Name = "mergeState";
            // 
            // dsdfInvName
            // 
            this.dsdfInvName.DataPropertyName = "dsdfInvName";
            this.dsdfInvName.HeaderText = "普票代收代付商品名称";
            this.dsdfInvName.Name = "dsdfInvName";
            // 
            // dsdfPrice
            // 
            this.dsdfPrice.DataPropertyName = "dsdfPrice";
            this.dsdfPrice.HeaderText = "普票代收代付金额";
            this.dsdfPrice.Name = "dsdfPrice";
            // 
            // ppServiceInvName
            // 
            this.ppServiceInvName.DataPropertyName = "ppServiceInvName";
            this.ppServiceInvName.HeaderText = "普票服务费商品名称";
            this.ppServiceInvName.Name = "ppServiceInvName";
            // 
            // ppServiceInvPrice
            // 
            this.ppServiceInvPrice.DataPropertyName = "ppServiceInvPrice";
            this.ppServiceInvPrice.HeaderText = "普票服务费金额";
            this.ppServiceInvPrice.Name = "ppServiceInvPrice";
            // 
            // zpServiceInvName
            // 
            this.zpServiceInvName.DataPropertyName = "zpServiceInvName";
            this.zpServiceInvName.HeaderText = "专票服务费商品名称";
            this.zpServiceInvName.Name = "zpServiceInvName";
            // 
            // zpServiceInvPrice
            // 
            this.zpServiceInvPrice.DataPropertyName = "zpServiceInvPrice";
            this.zpServiceInvPrice.HeaderText = "专票服务费金额";
            this.zpServiceInvPrice.Name = "zpServiceInvPrice";
            // 
            // belongMonth
            // 
            this.belongMonth.DataPropertyName = "belongMonth";
            this.belongMonth.HeaderText = "所属月份";
            this.belongMonth.Name = "belongMonth";
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "发票备注栏备注";
            this.remark.Name = "remark";
            // 
            // qc
            // 
            this.qc.DataPropertyName = "qc";
            this.qc.HeaderText = "QC";
            this.qc.Name = "qc";
            // 
            // dueDate
            // 
            this.dueDate.DataPropertyName = "dueDate";
            this.dueDate.HeaderText = "应到账日期";
            this.dueDate.Name = "dueDate";
            // 
            // candidateName
            // 
            this.candidateName.DataPropertyName = "candidateName";
            this.candidateName.HeaderText = "候选人名";
            this.candidateName.Name = "candidateName";
            // 
            // addressee
            // 
            this.addressee.DataPropertyName = "addressee";
            this.addressee.HeaderText = "收件公司";
            this.addressee.Name = "addressee";
            // 
            // ContactDefine
            // 
            this.ContactDefine.DataPropertyName = "ContactDefine";
            this.ContactDefine.HeaderText = "联系人";
            this.ContactDefine.Name = "ContactDefine";
            // 
            // linkPhone
            // 
            this.linkPhone.DataPropertyName = "linkPhone";
            this.linkPhone.HeaderText = "联系电话";
            this.linkPhone.Name = "linkPhone";
            // 
            // linemobile
            // 
            this.linemobile.DataPropertyName = "linemobile";
            this.linemobile.HeaderText = "手机号码";
            this.linemobile.Name = "linemobile";
            // 
            // shippingAddress
            // 
            this.shippingAddress.DataPropertyName = "shippingAddress";
            this.shippingAddress.HeaderText = "收件详细地址";
            this.shippingAddress.Name = "shippingAddress";
            // 
            // ECPrice
            // 
            this.ECPrice.DataPropertyName = "ECPrice";
            this.ECPrice.HeaderText = "EC金额 \n（财务部使用）";
            this.ECPrice.Name = "ECPrice";
            // 
            // SFPrice
            // 
            this.SFPrice.DataPropertyName = "SFPrice";
            this.SFPrice.HeaderText = "SF金额 \n（财务部使用)";
            this.SFPrice.Name = "SFPrice";
            // 
            // trainPrcie
            // 
            this.trainPrcie.DataPropertyName = "trainPrcie";
            this.trainPrcie.HeaderText = "培训费\n（财务部使用）";
            this.trainPrcie.Name = "trainPrcie";
            // 
            // exchanLossPrice
            // 
            this.exchanLossPrice.DataPropertyName = "exchanLossPrice";
            this.exchanLossPrice.HeaderText = "和客户结算的汇兑损益 \n（财务部使用）";
            this.exchanLossPrice.Name = "exchanLossPrice";
            // 
            // bankServicePrice
            // 
            this.bankServicePrice.DataPropertyName = "bankServicePrice";
            this.bankServicePrice.HeaderText = "向客户收取的银行手续费 \n（财务部使用）";
            this.bankServicePrice.Name = "bankServicePrice";
            // 
            // btnInvoiceAdd
            // 
            this.btnInvoiceAdd.Location = new System.Drawing.Point(622, 22);
            this.btnInvoiceAdd.Name = "btnInvoiceAdd";
            this.btnInvoiceAdd.Size = new System.Drawing.Size(75, 23);
            this.btnInvoiceAdd.TabIndex = 2;
            this.btnInvoiceAdd.Text = "生成发票";
            this.btnInvoiceAdd.UseVisualStyleBackColor = true;
            this.btnInvoiceAdd.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1019, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMaker);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnpiwB);
            this.panel1.Controls.Add(this.btnExportPi);
            this.panel1.Controls.Add(this.txtcusname);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpE);
            this.panel1.Controls.Add(this.dtpS);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.txtfileName);
            this.panel1.Controls.Add(this.btnLoadData);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnInvoiceAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1484, 125);
            this.panel1.TabIndex = 4;
            // 
            // txtMaker
            // 
            this.txtMaker.Location = new System.Drawing.Point(553, 80);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(126, 21);
            this.txtMaker.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(506, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "制单人";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "英文PI-浦发",
            "英文PI交行（89811）",
            "英文PI-交行（3954）",
            "英文PI-汇丰"});
            this.comboBox1.Location = new System.Drawing.Point(907, 79);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 14;
            // 
            // btnpiwB
            // 
            this.btnpiwB.Location = new System.Drawing.Point(808, 78);
            this.btnpiwB.Name = "btnpiwB";
            this.btnpiwB.Size = new System.Drawing.Size(75, 23);
            this.btnpiwB.TabIndex = 13;
            this.btnpiwB.Text = "导出英文pi";
            this.btnpiwB.UseVisualStyleBackColor = true;
            this.btnpiwB.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExportPi
            // 
            this.btnExportPi.Location = new System.Drawing.Point(702, 78);
            this.btnExportPi.Name = "btnExportPi";
            this.btnExportPi.Size = new System.Drawing.Size(75, 23);
            this.btnExportPi.TabIndex = 12;
            this.btnExportPi.Text = "导出中文pi";
            this.btnExportPi.UseVisualStyleBackColor = true;
            this.btnExportPi.Click += new System.EventHandler(this.btnExportPi_Click);
            // 
            // txtcusname
            // 
            this.txtcusname.Location = new System.Drawing.Point(362, 77);
            this.txtcusname.Name = "txtcusname";
            this.txtcusname.Size = new System.Drawing.Size(126, 21);
            this.txtcusname.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "客户";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "到";
            // 
            // dtpE
            // 
            this.dtpE.Location = new System.Drawing.Point(197, 77);
            this.dtpE.Name = "dtpE";
            this.dtpE.Size = new System.Drawing.Size(124, 21);
            this.dtpE.TabIndex = 7;
            // 
            // dtpS
            // 
            this.dtpS.Location = new System.Drawing.Point(34, 76);
            this.dtpS.Name = "dtpS";
            this.dtpS.Size = new System.Drawing.Size(114, 21);
            this.dtpS.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(508, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtfileName
            // 
            this.txtfileName.Location = new System.Drawing.Point(34, 22);
            this.txtfileName.Name = "txtfileName";
            this.txtfileName.Size = new System.Drawing.Size(345, 21);
            this.txtfileName.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Size = new System.Drawing.Size(1484, 596);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnInvoiceAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtfileName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dtpE;
        private System.Windows.Forms.DateTimePicker dtpS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcusname;
        private System.Windows.Forms.Button btnExportPi;
        private System.Windows.Forms.Button btnpiwB;
        private System.Windows.Forms.DataGridViewTextBoxColumn appDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn busType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dep;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cusname;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn depositBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn item1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sub_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn exchanLossPrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn exchangeReate;
        private System.Windows.Forms.DataGridViewTextBoxColumn exchangeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn invocieWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn mergeState;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdfInvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdfPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppServiceInvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppServiceInvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn zpServiceInvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn zpServiceInvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn belongMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn qc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn candidateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressee;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactDefine;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn linemobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn shippingAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainPrcie;
        private System.Windows.Forms.DataGridViewTextBoxColumn exchanLossPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankServicePrice;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.Label label4;
    }
}

