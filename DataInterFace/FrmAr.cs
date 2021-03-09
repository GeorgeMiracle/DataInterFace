using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.Portal.Proxy.Actions;
using UFIDA.U8.Portal.Proxy.editors;
using UFSoft.U8.Framework.LoginContext;

namespace DataInterFace
{
    public partial class FrmAr : UserControl, INetUserControl
    {
        public FrmAr()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {

        }

        #region u8成员
        private UFSoft.U8.Framework.Login.UI.clsLogin _uLogin;
        private string META_Conn, DATA_Conn;
        private NetAction[] Toolbars;
        public UFIDA.U8.Portal.Framework.MainFrames.IEditorPart EditorPart { get; set; }
        public UFIDA.U8.Portal.Framework.MainFrames.IEditorInput EditorInput { get; set; }
        public string Title { get; set; }
        public Control CreateControl(global::UFSoft.U8.Framework.Login.UI.clsLogin login, string MenuID, string Paramters)
        {
            try
            {
                this._uLogin = login;

                META_Conn = this._uLogin.GetLoginInfo().SecondConnString["META"].ToString();
                IDBServerInfo ConnInfo = this._uLogin.GetDBServerInfo(META_Conn);
                string NewConn = "Data Source={0};Initial Catalog={1};Persist Security Info=true;User ID={2};Password={3}";
                META_Conn = string.Format(NewConn, ConnInfo.ServerName, ConnInfo.DataBaseName, ConnInfo.UserName, ConnInfo.Password);

                DATA_Conn = this._uLogin.GetLoginInfo().ConnString;
                ConnInfo = this._uLogin.GetDBServerInfo(DATA_Conn);
                DATA_Conn = string.Format(NewConn, ConnInfo.ServerName, ConnInfo.DataBaseName, ConnInfo.UserName, ConnInfo.Password);

                DbManager.U8Conn = DATA_Conn;
                DbManager.UserName = this._uLogin.GetLoginInfo().UserName;

                DbManager.LoginDate = Convert.ToDateTime(this._uLogin.GetLoginInfo().operDate);
                //InitializeProcess();
                Title = "收款单导入";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return this;
        }
        public bool CloseEvent()
        {
            return true;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLoadData_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "All files（*.*）|*.*|All files(*.*)|*.* ";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtfileName.Text = fileDialog.FileName;
                    var data = NPOI.ExcelToDataTable(txtfileName.Text, 3);
                    //dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = data;

                    // string cCusCode = Convert.ToString(NewLateBinding.LateGet(objVoucher, null, "headertext", new object[] { "cCusCode" }, null, null, null));

                    // MessageBox.Show(fileDialog.FileName);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInvoiceAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable arSource = dataGridView1.DataSource as DataTable;


                ArVouch arVouch = new ArVouch(arSource);

                arVouch.AddArVouch();
                MessageBox.Show("收款单导入成功！");
                dataGridView1.DataSource = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("收款单导入出错：" + ex.Message + ex.StackTrace);
            }
        }

        public NetAction[] CreateToolbar(global::UFSoft.U8.Framework.Login.UI.clsLogin login)
        {
            List<NetAction> listAction = new List<NetAction>();
            Toolbars = listAction.ToArray();
            return Toolbars;
        }
        #endregion
    }
}
