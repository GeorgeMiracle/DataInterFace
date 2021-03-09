using Aspose.Cells;
using DataInterFace.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UFDB;
using UFIDA.U8.Portal.Proxy.Actions;
using UFIDA.U8.Portal.Proxy.editors;
using UFSoft.U8.Framework.LoginContext;

namespace DataInterFace
{
    public partial class Form1 : UserControl, INetUserControl
    {
        public Form1()
        {
            InitializeComponent();
            this.Title = "PI导入导出";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "All files（*.*）|*.*|All files(*.*)|*.* ";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtfileName.Text = fileDialog.FileName;
                    var data = NPOI.ReadSOData(fileDialog.FileName);
                    dataGridView1.AutoGenerateColumns = false;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            //数据检查
            //是否结账
            try
            {
                List<PIExcelData> excelDatas = dataGridView1.DataSource as List<PIExcelData>;
                if (excelDatas.Count == 0)
                {
                    MessageBox.Show("没有可以导入的数据！");
                    return;
                }
                if (VoucherCheck.bArEnd(DbManager.U8Conn, DbManager.LoginDate.Year, DbManager.LoginDate.Month))
                {
                    MessageBox.Show("登录日期对应的应收模块已经结账,不允许导入！");
                    return;
                }
                StringBuilder ErrMsg = new StringBuilder();
                //存货合法性监测

                for (int i = 0; i < excelDatas.Count; i++)
                {
                    if (excelDatas[i].invocieWay != "只开PI")
                    {
                        if (string.IsNullOrEmpty(excelDatas[i].dsdfInvName) && string.IsNullOrEmpty(excelDatas[i].ppServiceInvName) && string.IsNullOrEmpty(excelDatas[i].zpServiceInvName))
                        {
                            ErrMsg.Append(string.Format("第{0}行开票用的三栏存货必须存在有一个\r\n", (i + 1)));

                        }
                        if (!string.IsNullOrEmpty(excelDatas[i].dsdfInvName))
                        {
                            if (!VoucherCheck.InvExistsByName(excelDatas[i].dsdfInvName, DbManager.U8Conn))
                            {
                                ErrMsg.Append(string.Format("第{0}行代收代付存货:{1},不存在，请检查！\r\n", (i + 1), excelDatas[i].dsdfInvName));
                            }
                        }

                        if (!string.IsNullOrEmpty(excelDatas[i].ppServiceInvName))
                        {
                            if (!VoucherCheck.InvExistsByName(excelDatas[i].ppServiceInvName, DbManager.U8Conn))
                            {
                                ErrMsg.Append(string.Format("第{0}行普票服务费存货:{1}不存在，请检查！\r\n", (i + 1), excelDatas[i].ppServiceInvName));
                            }
                        }
                        if (!string.IsNullOrEmpty(excelDatas[i].zpServiceInvName))
                        {
                            if (!VoucherCheck.InvExistsByName(excelDatas[i].zpServiceInvName, DbManager.U8Conn))
                            {
                                ErrMsg.Append(string.Format("第{0}行专票服务费存货:{1}不存在，请检查！\r\n", (i + 1), excelDatas[i].zpServiceInvName));
                            }
                        }
                    }

                    //表头自定义项1
                    switch (excelDatas[i].busType)
                    {
                        case "Dispatch":
                            excelDatas[i].cdefine1 = "304080399";
                            break;
                        case "HRO-A":
                            excelDatas[i].cdefine1 = "304080299";
                            break;
                        case "HRO-P":
                            excelDatas[i].cdefine1 = "304080299";
                            break;
                        case "SCO-F":
                            excelDatas[i].cdefine1 = "304080399";
                            break;
                        case "SCO-H":
                            excelDatas[i].cdefine1 = "304080399";
                            break;
                        case "ESS":
                            excelDatas[i].cdefine1 = "304080399";
                            break;
                        case "MASS":
                            excelDatas[i].cdefine1 = "304080399";
                            break;
                        case "RPO":
                            excelDatas[i].cdefine1 = "304080399";
                            break;
                        case "Training":
                            excelDatas[i].cdefine1 = "307020102";
                            break;
                        case "代理记账":
                            excelDatas[i].cdefine1 = "304080208";
                            break;
                        default:
                            break;
                    }

                    using (UFDataContext uf = new UFDataContext(DbManager.U8Conn))
                    {
                        var depRet = uf.Department.FirstOrDefault(x => x.cDepName == excelDatas[i].dep);
                        if (depRet == null)
                        {
                            ErrMsg.Append(string.Format("第{0}行部门:{1}不存在，请检查！\r\n", (i + 1), excelDatas[i].dep));
                        }
                        else
                        {
                            excelDatas[i].depCode = depRet.cDepCode;
                        }
                        var personRet = uf.Person.FirstOrDefault(x => x.cPersonName == excelDatas[i].saleman);
                        if (personRet == null)
                        {
                            ErrMsg.Append(string.Format("第{0}行项目经理/猎头顾问:{1}不存在，请检查！\r\n", (i + 1), excelDatas[i].saleman));
                        }
                        else
                        {
                            excelDatas[i].salemanCode = personRet.cPersonCode;
                        }
                        var stRet = uf.SaleType.FirstOrDefault(x => x.cSTName == excelDatas[i].busType);
                        if (stRet == null)
                        {
                            ErrMsg.Append(string.Format("第{0}行业务类型:{1}不存在，请检查！\r\n", (i + 1), excelDatas[i].busType));
                        }
                        else
                        {
                            excelDatas[i].busCode = stRet.cSTCode;
                        }
                        if (string.IsNullOrEmpty(excelDatas[i].dueDate))
                        {
                            ErrMsg.Append(string.Format("第{0}行应到账日期:不能为空，请检查！\r\n", (i + 1)));
                        }
                        DateTime dt = new DateTime();
                        if (!DateTime.TryParse(excelDatas[i].dueDate, out dt))
                        {
                            ErrMsg.Append(string.Format("第{0}行应到账日期:{1}格式不正确，请检查！\r\n", (i + 1), excelDatas[i].dueDate));
                        }
                        var itemRet = uf.fitemss97.FirstOrDefault(x => x.citemcode == excelDatas[i].itemcode);
                        if (itemRet == null)
                        {
                            ErrMsg.Append(string.Format("第{0}行项目编码:{1}不存在，请检查！\r\n", (i + 1), excelDatas[i].itemcode));
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(itemRet.对应客户))
                            {
                                ErrMsg.Append(string.Format("第{0}行项目对应客户不存在:{1}不存在，请检查！\r\n", (i + 1), excelDatas[i].itemcode));
                            }
                            else
                            {
                                excelDatas[i].realcusCode = itemRet.对应客户;
                                excelDatas[i].realcusname = uf.Customer.FirstOrDefault(x => x.cCusCode == itemRet.对应客户).cCusName;
                            }
                        }
                    }

                    if (Convert.ToDouble(excelDatas[i].ECPrice) < 0 || Convert.ToDouble(excelDatas[i].SFPrice) < 0)
                    {
                        excelDatas[i].bRedVouch = true;
                    }
                    else
                    {
                        excelDatas[i].bRedVouch = false;

                    }
                }
                if (ErrMsg.ToString() != "")
                {
                    FrmLog fg = new FrmLog(ErrMsg.ToString());
                    fg.ShowDialog();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //开票导入
                VoucherInsert();
                FrmLog fg = new FrmLog("导入成功");
                fg.ShowDialog();
            }
            catch (Exception ex)
            {
                FrmLog fg = new FrmLog("发生错误：" + ex.Message+ex.StackTrace);
                fg.ShowDialog();
            }
        }

        private void VoucherInsert()
        {
            var data = dataGridView1.DataSource as List<PIExcelData>;
            using (UFDataContext uf = new UFDataContext(DbManager.U8Conn))
            {
                Dictionary<string, string> piNumDic = new Dictionary<string, string>();
                int? piNumSeed = uf.ExecuteQuery<int?>("SELECT MAX(CAST(SUBSTRING(chdefine13,9,12) AS INT)) FROM dbo.SaleBillVouch_extradefine WHERE SUBSTRING(chdefine13,1,8)='TS'+ CONVERT(varchar(6), GETDATE(), 112)").FirstOrDefault();
                piNumSeed = piNumSeed == null ? 1 : piNumSeed + 1;
                for (int i = 0; i < data.Count; i++)
                {
                  
                    //pi号赋值
                    if (string.IsNullOrEmpty(data[i].mergeState))
                    {
                        data[i].piNum = "TS" + DateTime.Today.ToString("yyyyMM") + piNumSeed.ToString().PadLeft(4, '0');
                        piNumSeed++;
                    }
                    else
                    {
                        var piNum = piNumDic.FirstOrDefault(x => x.Key == data[i].mergeState).Value;
                        if (piNum == null)
                        {
                            piNum = "TS" + DateTime.Today.ToString("yyyyMM") + piNumSeed.ToString().PadLeft(4, '0');

                            piNumDic.Add(data[i].mergeState, piNum);
                            data[i].piNum = "TS" + DateTime.Today.ToString("yyyyMM") + piNumSeed.ToString().PadLeft(4, '0');
                            piNumSeed++;
                        }
                        else
                        {
                            data[i].piNum = piNum;
                        }
                    }
                    //销售发票解析
                    //解析这行开几张发票
                    if (string.IsNullOrEmpty(data[i].invocieWay))
                    {
                        throw new Exception(string.Format("第{0}行，开票方式不能为空！", (i + 1)));
                    }
                    if (data[i].invocieWay.Contains("1张"))
                    {
                        Regex rgx = new Regex(@"(?i)(?<=\[)(.*)(?=\%)");//中括号[]
                        decimal taxRate = Convert.ToInt32(rgx.Match(data[i].invocieWay).Value);
                        string sbcType = data[i].invocieWay.Contains("普票") ? "27" : "26";
                        int ifatherid = 0;
                        InsertVouchHead(uf, sbcType, taxRate, ref ifatherid, data[i]);
                        InsertVouchHeadEx(uf, ifatherid, data[i]);
                        //专票还是普票 专票26普票27
                        //单行还是两行
                        if (sbcType == "26")
                        {
                            //ec和sf金额是否都为不为空
                            if (Convert.ToDouble(data[i].ECPrice) != 0 && Convert.ToDouble(data[i].SFPrice) != 0)
                            {
                                decimal tax = (Convert.ToDecimal(data[i].ECPrice) + Convert.ToDecimal(data[i].SFPrice)) / (1 + Convert.ToDecimal(taxRate) / 100) * (Convert.ToDecimal(taxRate) / 100);
                                //两行 一行ec07，一行sf07
                                string ecInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].zpServiceInvName && x.cInvCCode == "01").cInvCode;
                                string sfInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].zpServiceInvName && x.cInvCCode == "02").cInvCode;


                                InsertVouchBody(uf, ifatherid, data[i].cdefine1, 0, ecInv, data[i].zpServiceInvName, data[i].itemcode, data[i].itemName, 1, Convert.ToDecimal(data[i].ECPrice), taxRate.ToString());
                                InsertVouchBodySFEC(uf, ifatherid, data[i].cdefine1, tax, sfInv, data[i].zpServiceInvName, data[i].itemcode, data[i].itemName, 1, Convert.ToDecimal(data[i].SFPrice), taxRate.ToString());



                            }
                            else
                            {
                                //ec金额不为空
                                if (Convert.ToDouble(data[i].ECPrice) != 0)
                                {
                                    string ecInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].zpServiceInvName && x.cInvCCode == "01").cInvCode;
                                    InsertVouchBody(uf, ifatherid, data[i].cdefine1, taxRate, ecInv, data[i].zpServiceInvName, data[i].itemcode, data[i].itemName, 1, Convert.ToDecimal(data[i].ECPrice), taxRate.ToString());

                                }
                                else if (Convert.ToDouble(data[i].SFPrice) != 0)
                                {
                                    string sfInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].zpServiceInvName && x.cInvCCode == "02").cInvCode;
                                    //一行
                                    decimal price = Convert.ToDecimal(data[i].SFPrice);
                                    if (!string.IsNullOrEmpty(data[i].exchanLossPrice))
                                    {
                                        price += Convert.ToDecimal(data[i].exchanLossPrice);
                                    }
                                    InsertVouchBody(uf, ifatherid, data[i].cdefine1, taxRate, sfInv, data[i].zpServiceInvName, data[i].itemcode, data[i].itemName, 1, price, taxRate.ToString());
                                }
                                else
                                {
                                    throw new Exception(string.Format("第{0}行，EC和sf金额不能同时为空", (i + 1)));
                                }





                            }
                        }
                        //普票
                        if (sbcType == "27")
                        {

                            //ec和sf金额是否都为不为空
                            if (Convert.ToDouble(data[i].ECPrice) != 0 && Convert.ToDouble(data[i].SFPrice) != 0)
                            {
                                decimal tax = (Convert.ToDecimal(data[i].ECPrice) + Convert.ToDecimal(data[i].SFPrice)) / (1 + Convert.ToDecimal(taxRate) / 100) * (Convert.ToDecimal(taxRate) / 100);
                                //两行 一行ec07，一行sf07
                                string ecInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].ppServiceInvName && x.cInvCCode == "01").cInvCode;
                                string sfInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].ppServiceInvName && x.cInvCCode == "02").cInvCode;


                                InsertVouchBody(uf, ifatherid, data[i].cdefine1, 0, ecInv, data[i].ppServiceInvName, data[i].itemcode, data[i].itemName, 1, Convert.ToDecimal(data[i].ECPrice), taxRate.ToString());
                                InsertVouchBodySFEC(uf, ifatherid, data[i].cdefine1, tax, sfInv, data[i].ppServiceInvName, data[i].itemcode, data[i].itemName, 1, Convert.ToDecimal(data[i].SFPrice), taxRate.ToString());



                            }
                            else
                            {
                                //ec金额不为空
                                if (Convert.ToDouble(data[i].ECPrice) != 0)
                                {
                                    
                                    bool dsdf = data[i].dsdfInvName.Contains("代") ? true : false;
                                    
                                    string StrtaxRate = dsdf?"5":taxRate.ToString();

                                    string ecInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].dsdfInvName && x.cInvCCode == "01").cInvCode;
                                    
                                    InsertVouchBody(uf, ifatherid, data[i].cdefine1, taxRate, ecInv, data[i].dsdfInvName, data[i].itemcode, data[i].itemName, 1, Convert.ToDecimal(data[i].ECPrice), StrtaxRate, dsdf);
                                    

                                }//sf金额不为空
                                else if (Convert.ToDouble(data[i].SFPrice) != 0)
                                {
                                    string sfInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].ppServiceInvName && x.cInvCCode == "02").cInvCode;
                                    //一行
                                    decimal price = Convert.ToDecimal(data[i].SFPrice);
                                    if (!string.IsNullOrEmpty(data[i].exchanLossPrice))
                                    {
                                        price += Convert.ToDecimal(data[i].exchanLossPrice);
                                    }
                                    InsertVouchBody(uf, ifatherid, data[i].cdefine1, taxRate, sfInv, data[i].ppServiceInvName, data[i].itemcode, data[i].itemName, 1, price, taxRate.ToString());
                                }
                                else
                                {
                                    throw new Exception(string.Format("第{0}行，EC和sf金额不能同时为空", (i + 1)));
                                }





                            }
                        }
                    }
                    else if (data[i].invocieWay.Contains("2张"))
                    {
                        decimal CEtax = 0;//差额征税金额 代收代付的算


                        string invoice2Type = "";//第二张发票数据
                        string invoice2Tax = ""; //第二张发票税率
                        Regex rgx = new Regex(@"(?i)(?<=\[)(.*)(?=\%)");//中括号[]
                        //将两种开票方式以逗号分隔
                        string[] invoiceWayArry = data[i].invocieWay.Split('，');
                        //invoice1Tax = rgx.Match(invoiceWayArry[0]).Value;
                        if (invoiceWayArry[1].Contains("专票"))
                        {
                            invoice2Type = "26";

                        }
                        else
                        {
                            invoice2Type = "27";

                        }
                        invoice2Tax = rgx.Match(invoiceWayArry[1]).Value;

                        //第一张一定是普票且税额为0
                        if (!string.IsNullOrEmpty(data[i].dsdfInvName))
                        {
                            //判断金额是否为空

                            //数据正确导入发票
                            int ifatherid = 0;
                            InsertVouchHead(uf, "27", 0, ref ifatherid, data[i]);
                            bool bCeTax = false;//是否差额征税
                            if (data[i].dsdfInvName.Contains("代"))
                            {
                                bCeTax = true;
                            }

                            InsertVouchHeadEx(uf, ifatherid, data[i], bCeTax);
                            string ecInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].dsdfInvName && x.cInvCCode == "01").cInvCode;
                          
                            bool dsdf = data[i].dsdfInvName.Contains("代") ? true : false;
                            string StrtaxRate = dsdf ? "5" : invoice2Tax.ToString();
                            InsertVouchBody(uf, ifatherid, data[i].cdefine1, 0, ecInv, data[i].dsdfInvName, data[i].itemcode, data[i].itemName, 1, Convert.ToDecimal(data[i].ECPrice), StrtaxRate, dsdf);
                        }
                        //第二张发票
                        int ifatherid2 = 0;
                        InsertVouchHead(uf, invoice2Type, Convert.ToInt32(invoice2Tax), ref ifatherid2, data[i]);
                        InsertVouchHeadEx(uf, ifatherid2, data[i]);
                        if (invoice2Type == "27")//普票
                        {
                            //判断存货是否为空
                            if (!string.IsNullOrEmpty(data[i].ppServiceInvName))
                            {
                                //判断金额是否为空
                                if (!string.IsNullOrEmpty(data[i].ppServiceInvPrice))
                                {
                                    string sgfInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].ppServiceInvName && x.cInvCCode == "02").cInvCode;
                                    decimal price = Convert.ToDecimal(data[i].SFPrice);
                                    if (!string.IsNullOrEmpty(data[i].exchanLossPrice))
                                    {
                                        price += Convert.ToDecimal(data[i].exchanLossPrice);
                                    }
                                    InsertVouchBody(uf, ifatherid2, data[i].cdefine1, Convert.ToInt32(invoice2Tax), sgfInv, data[i].ppServiceInvName, data[i].itemcode, data[i].itemName, 1, price, invoice2Tax.ToString());
                                }

                            }
                        }
                        else if (invoice2Type == "26")//专票
                        {
                            //存货名是否为空
                            if (!string.IsNullOrEmpty(data[i].zpServiceInvName))
                            {
                                //判断金额是否为空
                                if (!string.IsNullOrEmpty(data[i].zpServiceInvPrice))
                                {
                                    string sgfInv = uf.Inventory.FirstOrDefault(x => x.cInvName == data[i].zpServiceInvName && x.cInvCCode == "02").cInvCode;
                                    decimal price = Convert.ToDecimal(data[i].SFPrice);
                                    if (!string.IsNullOrEmpty(data[i].exchanLossPrice))
                                    {
                                        price += Convert.ToDecimal(data[i].exchanLossPrice);
                                    }
                                    InsertVouchBody(uf, ifatherid2, data[i].cdefine1, Convert.ToInt32(invoice2Tax), sgfInv, data[i].zpServiceInvName, data[i].itemcode, data[i].itemName, 1, price, invoice2Tax.ToString());
                                }

                            }
                        }
                        //PI表写入

                    }
                    else if (data[i].invocieWay.Contains("只开PI"))
                    {
                        int ifatherid = 0;
                        InsertVouchHead(uf, "27", 0, ref ifatherid, data[i]);
                        InsertVouchHeadEx(uf, ifatherid, data[i]);
                        //跟实际代收代付和服务费走
                        int rowNum = 1;
                        //代收代付
                        if (Convert.ToDouble(data[i].ECPrice) == 0 && Convert.ToDouble(data[i].SFPrice) == 0)
                        {
                            throw new Exception("第{0}行，只开pi EC或SF金额必须有一个");
                        }
                        if (Convert.ToDouble(data[i].ECPrice) != 0)
                        {

                            InsertVouchBody(uf, ifatherid, data[i].cdefine1, 0, "EC07", "服务费", data[i].itemcode, data[i].itemName, 1, Convert.ToDecimal(data[i].ECPrice), "0");
                            rowNum++;
                        }
                        if (Convert.ToDouble(data[i].SFPrice) != 0)
                        {
                            decimal price = Convert.ToDecimal(data[i].SFPrice);
                            if (!string.IsNullOrEmpty(data[i].exchanLossPrice))
                            {
                                price += Convert.ToDecimal(data[i].exchanLossPrice);
                            }

                            InsertVouchBody(uf, ifatherid, data[i].cdefine1, 0, "SF07", "服务费", data[i].itemcode, data[i].itemName, rowNum, price, "0");

                        }
                    }

                }
                var groupedData = data.GroupBy(x => x.mergeState);
                foreach (var item in groupedData)
                {

                    if (string.IsNullOrEmpty(item.Key))
                    {
                        foreach (var items in item)
                        {
                            int bWB = 0;
                            bWB = items.invocieWay == "只开PI" ? 1 : 0;
                            //写入pi表
                            if (!string.IsNullOrEmpty(items.Item1))
                            {
                                string cno = clsGetID.getcode(DbManager.U8Conn, "U8CUSTDEF_0001");
                                Guid guid = Guid.NewGuid();
                                H_PIM h_PIM = new H_PIM();
                                h_PIM.cNo = cno;
                                h_PIM.Company = items.cusname;
                                h_PIM.taxNo = items.taxNo;
                                h_PIM.AccNo = items.AccNo;
                                h_PIM.depositBank = items.depositBank;
                                h_PIM.Address = items.Address;
                                h_PIM.Attention = items.Contact;
                                h_PIM.Telephone = items.Phone;
                                h_PIM.ExchageDate = items.exchangeDate == null ? (DateTime?)null : Convert.ToDateTime(items.exchangeDate);
                                h_PIM.ExchangeRate = Convert.ToDecimal(items.exchangeReate);
                                h_PIM.currency = items.currency;
                                h_PIM.SubtotalinCNY = Convert.ToDecimal(items.Sub_total);
                                h_PIM.BankChargeinCNY = Convert.ToDecimal(items.bankServicePrice);
                                h_PIM.cMaker = DbManager.UserName;
                                h_PIM.dMakeDateEx = Convert.ToDateTime(items.appDate);
                                h_PIM.dMakeDate = DateTime.Now;
                                h_PIM.belongMonth = items.belongMonth;
                                h_PIM.TotalAmount = Convert.ToDecimal(item.First().exchangeReate) == 0 ? (item.Sum(x => Convert.ToDecimal(x.Sub_total)) + item.Sum(x => Convert.ToDecimal(x.bankServicePrice)) + item.Sum(x => Convert.ToDecimal(x.exchanLossPrice))) : (item.Sum(x => Convert.ToDecimal(Sub_total)) + item.Sum(x => Convert.ToDecimal(x.bankServicePrice)) + item.Sum(x => Convert.ToDecimal(x.exchanLossPrice))) / Convert.ToDecimal(item.First().exchangeReate);
                                h_PIM.iswfcontrolled = 0;
                                h_PIM.UAPRuntime_RowNO = 1;
                                h_PIM.ID = guid;
                                h_PIM.piNum = items.piNum;
                                h_PIM.bWB = bWB;
                                List<H_PID> h_PIDs = new List<H_PID>();
                                int rowNum = 1;
                                if (!string.IsNullOrEmpty(items.Item1))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item1",
                                        itemName = items.Item1,
                                        price = Convert.ToDecimal(items.Amt1),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item2))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item2",
                                        itemName = items.Item2,
                                        price = Convert.ToDecimal(items.Amt2),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item3))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item3",
                                        itemName = items.Item3,
                                        price = Convert.ToDecimal(items.Amt3),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item4))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item4",
                                        itemName = items.Item4,
                                        price = Convert.ToDecimal(items.Amt4),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item5))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item5",
                                        itemName = items.Item5,
                                        price = Convert.ToDecimal(items.Amt5),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item6))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item6",
                                        itemName = items.Item6,
                                        price = Convert.ToDecimal(items.Amt6),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item7))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item7",
                                        itemName = items.Item7,
                                        price = Convert.ToDecimal(items.Amt7),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item8))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item8",
                                        itemName = items.Item8,
                                        price = Convert.ToDecimal(items.Amt8),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                uf.H_PIM.InsertOnSubmit(h_PIM);
                                uf.H_PID.InsertAllOnSubmit(h_PIDs);

                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(item.First().Item1))
                        {
                            int bWB = 0;
                            bWB = item.First().invocieWay == "只开PI" ? 1 : 0;
                            string cno = clsGetID.getcode(DbManager.U8Conn, "U8CUSTDEF_0001");
                            Guid guid = Guid.NewGuid();
                            H_PIM h_PIM = new H_PIM();
                            h_PIM.cNo = cno;
                            h_PIM.Company = item.First().cusname;
                            h_PIM.taxNo = item.First().taxNo;
                            h_PIM.AccNo = item.First().AccNo;
                            h_PIM.depositBank = item.First().depositBank;
                            h_PIM.Address = item.First().Address;
                            h_PIM.Attention = item.First().Contact;

                            h_PIM.Telephone = item.First().Phone;
                            h_PIM.ExchageDate = item.First().exchangeDate == null ? (DateTime?)null : Convert.ToDateTime(item.First().exchangeDate);
                            h_PIM.ExchangeRate = Convert.ToDecimal(item.First().exchangeReate);
                            h_PIM.currency = item.First().currency;
                            h_PIM.SubtotalinCNY = item.Sum(x=>Convert.ToDecimal( x.Sub_total));
                            h_PIM.BankChargeinCNY = item.Sum(x=>Convert.ToDecimal( x.bankServicePrice));
                            h_PIM.cMaker = DbManager.UserName;
                            h_PIM.dMakeDateEx = Convert.ToDateTime(item.First().appDate);
                            h_PIM.dMakeDate = DateTime.Now;
                            h_PIM.belongMonth = item.First().belongMonth;
                            h_PIM.TotalAmount = Convert.ToDecimal(item.First().exchangeReate) == 0 ? (item.Sum(x=>Convert.ToDecimal(x.Sub_total)) + item.Sum(x=>Convert.ToDecimal( x.bankServicePrice) ) + item.Sum(x => Convert.ToDecimal(x.exchanLossPrice))) :  (item.Sum(x=>Convert.ToDecimal(Sub_total) )+ item.Sum(x=>Convert.ToDecimal(x.bankServicePrice)) + item.Sum(x => Convert.ToDecimal(x.exchanLossPrice)))/ Convert.ToDecimal(item.First().exchangeReate);
                            h_PIM.iswfcontrolled = 0;
                            h_PIM.UAPRuntime_RowNO = 1;
                            h_PIM.ID = guid;
                            h_PIM.piNum = item.First().piNum;
                            h_PIM.bWB = bWB;
                            List<H_PID> h_PIDs = new List<H_PID>();
                            int rowNum = 1;
                            foreach (var items in item)
                            {

                                if (!string.IsNullOrEmpty(items.Item1))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item1",
                                        itemName = items.Item1,
                                        price = Convert.ToDecimal(items.Amt1),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item2))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item2",
                                        itemName = items.Item2,
                                        price = Convert.ToDecimal(items.Amt2),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item3))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item3",
                                        itemName = items.Item3,
                                        price = Convert.ToDecimal(items.Amt3),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item4))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item4",
                                        itemName = items.Item4,
                                        price = Convert.ToDecimal(items.Amt4),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item5))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item5",
                                        itemName = items.Item5,
                                        price = Convert.ToDecimal(items.Amt5),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item6))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item6",
                                        itemName = items.Item6,
                                        price = Convert.ToDecimal(items.Amt6),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item7))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item7",
                                        itemName = items.Item7,
                                        price = Convert.ToDecimal(items.Amt7),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                if (!string.IsNullOrEmpty(items.Item8))
                                {
                                    h_PIDs.Add(new H_PID()
                                    {
                                        ID = guid,
                                        item = "Item8",
                                        itemName = items.Item8,
                                        price = Convert.ToDecimal(items.Amt8),
                                        Autoid = Guid.NewGuid(),
                                        UAPRuntime_RowNO = rowNum,

                                    });
                                    rowNum++;
                                }
                                uf.H_PIM.InsertOnSubmit(h_PIM);
                                uf.H_PID.InsertAllOnSubmit(h_PIDs);

                            }
                        }

                    }
                    uf.SubmitChanges();
                }
            }
        }
        private void InsertVouchHead(UFDataContext uf, string vouchType, decimal taxRate, ref int ifatherId, PIExcelData pI)
        {
            SaleBillVouch sb = new SaleBillVouch();
            ifatherId = Convert.ToInt32(clsGetID.getAutoId(DbManager.U8Conn, "BILLVOUCH", _uLogin.GetLoginInfo().AccID, 1));
            string sbvCodeType = vouchType == "26" ? "07" : "13";
            string vtid = vouchType == "26" ? "53" : "17";
            string sbvcode = clsGetID.getcode(DbManager.U8Conn, sbvCodeType);
            sb.SBVID = ifatherId;
            sb.cSBVCode = sbvcode;
            sb.dDate = DbManager.LoginDate;
            sb.cChecker = DbManager.UserName;
            sb.cSTCode = pI.busCode;
            sb.cCusCode = pI.realcusCode;
            sb.cVouchType = vouchType;
            sb.cDepCode = pI.depCode;
            sb.cPersonCode = pI.salemanCode;
            sb.cexch_name = "人民币";
            sb.cMemo = pI.itemName + " " + pI.belongMonth + " " + pI.dsdfInvName + " " + pI.ppServiceInvName + " " + pI.zpServiceInvName;
            sb.iExchRate = 1;
            sb.iTaxRate = Convert.ToDouble(taxRate);
            sb.bReturnFlag = pI.bRedVouch;
            sb.cMaker = DbManager.UserName;
            sb.bFirst = false;
            sb.bIAFirst = false;
            sb.iVTid = Convert.ToInt32(vtid);
            sb.cDefine4 = Convert.ToDateTime(pI.appDate);
            sb.cDefine1 = pI.invoiceCompany;
            sb.cDefine2 = pI.invoiceType;
            sb.cDefine10 = pI.invocieWay;
            sb.cDefine11 = pI.qc;
            sb.cDefine12 = pI.candidateName;
            sb.cDefine13 = pI.cusname;
            sb.iDisp = 0;
            sb.cCusName = pI.realcusname;
            sb.cSource = "应收";
            sb.bCredit = false;
            sb.iverifystate = 0;
            sb.iswfcontrolled = 0;
            sb.dcreatesystime = DateTime.Now;
            sb.bcashsale = false;
            sb.bcashsale = false;
            sb.cSysBarCode = "||arpl|" + sbvcode;
            sb.iTaxBillState = 0;
            sb.citemcode = pI.itemcode;
            sb.dGatheringDate = Convert.ToDateTime(pI.dueDate);


            uf.SaleBillVouch.InsertOnSubmit(sb);
        }

        private void InsertVouchHeadEx(UFDataContext uf, int ifatherId, PIExcelData pI, bool bCETax = false)
        {
            SaleBillVouch_extradefine sbEx = new SaleBillVouch_extradefine();
            sbEx.SBVID = ifatherId;
            sbEx.chdefine1 = pI.addressee;
            sbEx.chdefine2 = pI.ContactDefine;
            sbEx.chdefine3 = pI.linkPhone;
            sbEx.chdefine4 = pI.linemobile;
            sbEx.chdefine5 = pI.shippingAddress;
            sbEx.chdefine6 = pI.taxNo;
            sbEx.chdefine7 = pI.depositBank;
            sbEx.chdefine8 = pI.AccNo;
            sbEx.chdefine9 = pI.Address;
            sbEx.chdefine10 = pI.Contact;
            sbEx.chdefine11 = pI.Phone;
            sbEx.chdefine12 = pI.belongMonth;
            sbEx.chdefine13 = pI.piNum;
            sbEx.chdefine14 = Convert.ToDouble(pI.ECPrice);
            sbEx.chdefine15 = Convert.ToDouble(pI.SFPrice);
            sbEx.chdefine16 = Convert.ToDouble(pI.trainPrcie);
            sbEx.chdefine17 = Convert.ToDouble(pI.exchanLossPrice);
            sbEx.chdefine18 = Convert.ToDouble(pI.bankServicePrice);
           
            sbEx.chdefine19 = pI.remark;
    


            uf.SaleBillVouch_extradefine.InsertOnSubmit(sbEx);
        }

        private void InsertVouchBody(UFDataContext uf, int ifatherid, string define1, decimal taxRate, string invcode, string invName, string itemcode, string itemname, int rownum, decimal price, string defineTax, bool CE = false)
        {
            SaleBillVouchs sbs = new SaleBillVouchs();
            sbs.SBVID = ifatherid;
            int autoid = Convert.ToInt32(clsGetID.getAutoId(DbManager.U8Conn, "BILLVOUCH", _uLogin.GetLoginInfo().AccID, 0));
            sbs.AutoID = autoid;
            sbs.cInvCode = invcode;
            sbs.iQuantity = price <= 0 ? -1 : 1;
            sbs.iQuotedPrice = 0;
            sbs.iUnitPrice = price <= 0 ? -(Math.Round(Convert.ToDecimal(price) / (1 + taxRate / 100), 2, MidpointRounding.AwayFromZero)) : Math.Round(Convert.ToDecimal(price) / (1 + taxRate / 100), 2, MidpointRounding.AwayFromZero);
            sbs.iTaxUnitPrice = price <= 0 ? -(Math.Round(Convert.ToDecimal(price), 2, MidpointRounding.AwayFromZero)) : Math.Round(Convert.ToDecimal(price), 2, MidpointRounding.AwayFromZero);
            sbs.iMoney = Math.Round(Convert.ToDecimal(price) / (1 + taxRate / 100), 2, MidpointRounding.AwayFromZero);
            sbs.iSum = Math.Round(Convert.ToDecimal(price), 2, MidpointRounding.AwayFromZero);
            sbs.iTax = Math.Round(Convert.ToDecimal(price) / (1 + taxRate / 100) * (taxRate / 100), 2, MidpointRounding.AwayFromZero);
            sbs.iDisCount = 0;
            sbs.iNatUnitPrice = price <= 0 ? -(Math.Round(Convert.ToDecimal(price) / (1 + taxRate / 100), 2, MidpointRounding.AwayFromZero)) : Math.Round(Convert.ToDecimal(price) / (1 + taxRate / 100), 2, MidpointRounding.AwayFromZero);
            sbs.iNatMoney = Math.Round(Convert.ToDecimal(price) / (1 + taxRate / 100), 2, MidpointRounding.AwayFromZero);
            sbs.iNatTax = Math.Round(Convert.ToDecimal(price) / (1 + taxRate / 100) * (taxRate / 100), 2, MidpointRounding.AwayFromZero);
            sbs.iNatSum = Math.Round(Convert.ToDecimal(price), 2, MidpointRounding.AwayFromZero);
            sbs.iNatDisCount = 0;
            sbs.iMoneySum = 0;
            sbs.iExchSum = 0;
            sbs.bSettleAll = false;
            sbs.iTB = 0;
            sbs.KL = 100;
            sbs.KL2 = 100;
            sbs.cInvName = invName;
            sbs.iTaxRate = taxRate;
            sbs.fOutQuantity = 0;
            sbs.fOutNum = 0;
            sbs.fSaleCost = 0;
            sbs.fSalePrice = 0;
            sbs.bgsp = false;
            sbs.cMassUnit = 0;
            sbs.bQANeedCheck = false;
            sbs.bQAUrgency = false;
            sbs.bcosting = false;
            sbs.fcusminprice = 0;
            sbs.irowno = rownum;
            sbs.cItem_class = "97";
            sbs.cItem_CName = "项目管理";
            sbs.cItemCode = itemcode;
            sbs.cItemName = itemname;
            sbs.iExpiratDateCalcu = 0;
            sbs.bneedsign = false;
            sbs.bsaleprice = true;
            sbs.bgift = false;
            sbs.bmpforderclosed = false;
            sbs.cbSysBarCode = "||arzl|" + autoid.ToString() + "| " + rownum.ToString();
            sbs.cDefine22 = define1;
            sbs.cDefine29 = defineTax;//税率
            sbs.cDefine28 = CE ? price.ToString() : "0";//金额
            uf.SaleBillVouchs.InsertOnSubmit(sbs);
        }

        private void InsertVouchBodySFEC(UFDataContext uf, int ifatherid, string define1, decimal tax, string invcode, string invName, string itemcode, string itemname, int rownum, decimal price, string defineTax, bool CE = false)
        {
            SaleBillVouchs sbs = new SaleBillVouchs();
            sbs.SBVID = ifatherid;
            int autoid = Convert.ToInt32(clsGetID.getAutoId(DbManager.U8Conn, "BILLVOUCH", _uLogin.GetLoginInfo().AccID, 0));
            sbs.AutoID = autoid;
            sbs.cInvCode = invcode;
            sbs.iQuantity = price <= 0 ? -1 : 1;
            sbs.iQuotedPrice = 0;
            sbs.iUnitPrice = price <= 0 ? -(Math.Round(price - tax, 2, MidpointRounding.AwayFromZero)) : Math.Round(price - tax, 2, MidpointRounding.AwayFromZero);
            sbs.iTaxUnitPrice = price <= 0 ? -(Math.Round(price, 2, MidpointRounding.AwayFromZero)) : (Math.Round(price, 2, MidpointRounding.AwayFromZero));
            sbs.iMoney = Math.Round(price - tax, 2, MidpointRounding.AwayFromZero);
            sbs.iSum = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            sbs.iTax = Math.Round(tax, 2, MidpointRounding.AwayFromZero);
            sbs.iDisCount = 0;
            sbs.iNatUnitPrice = price <= 0 ? -(Math.Round(price - tax, 2, MidpointRounding.AwayFromZero)) : Math.Round(price - tax, 2, MidpointRounding.AwayFromZero);
            sbs.iNatMoney = Math.Round(price - tax, 2, MidpointRounding.AwayFromZero);
            sbs.iNatTax = Math.Round(tax, 2, MidpointRounding.AwayFromZero);
            sbs.iNatSum = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            sbs.iNatDisCount = 0;
            sbs.iMoneySum = 0;
            sbs.iExchSum = 0;
            sbs.bSettleAll = false;
            sbs.iTB = 0;
            sbs.KL = 100;
            sbs.KL2 = 100;
            sbs.cInvName = invName;
            sbs.iTaxRate = Math.Round((price / (price - tax) - 1) * 100, 2, MidpointRounding.AwayFromZero);
            sbs.fOutQuantity = 0;
            sbs.fOutNum = 0;
            sbs.fSaleCost = 0;
            sbs.fSalePrice = 0;
            sbs.bgsp = false;
            sbs.cMassUnit = 0;
            sbs.bQANeedCheck = false;
            sbs.bQAUrgency = false;
            sbs.bcosting = false;
            sbs.fcusminprice = 0;
            sbs.irowno = rownum;
            sbs.cItem_class = "97";
            sbs.cItem_CName = "项目管理";
            sbs.cItemCode = itemcode;
            sbs.cItemName = itemname;
            sbs.iExpiratDateCalcu = 0;
            sbs.bneedsign = false;
            sbs.bsaleprice = true;
            sbs.bgift = false;
            sbs.bmpforderclosed = false;
            sbs.cbSysBarCode = "||arzl|" + autoid.ToString() + "| " + rownum.ToString();
            sbs.cDefine22 = define1;
            sbs.cDefine29 = defineTax;  //税率
            sbs.cDefine28 = CE ? price.ToString() : "0"; //金额
            uf.SaleBillVouchs.InsertOnSubmit(sbs);
        }
        private void ExportPI()
        {

        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            Console.Write("222");
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               dataGridView1.RowHeadersWidth - 4,
               e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var data = NPOI.ReadSOData(txtfileName.Text);
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = data;
        }

        private void btnExportPi_Click(object sender, EventArgs e)
        {
            btnExportPi.Enabled = false;
            SaveFileDialog sflg = new SaveFileDialog();
            sflg.FileName = ".xls";  //文件名
            sflg.Filter = "Excel 工作薄（*.xls）| *.xls";  //文件类型
            //this.btnPI.Enabled = false;
            try
            {
                if (sflg.ShowDialog() != DialogResult.OK)
                {
                    btnExportPi.Enabled = true;
                    return;
                }
                string directoryName = Path.GetDirectoryName(sflg.FileName);

                Workbook workbook = new Workbook();
                List<string> list = new List<string>();
                string startSheetName = string.Empty;
                string endSheetName = string.Empty;
                StringBuilder pimsb = new StringBuilder();
                pimsb.Append("select * from h_pim where  dMakeDateEx>='" + dtpS.Value.ToString("yyyy-MM-dd") + "' and dMakeDateEx<='" + dtpE.Value.ToString("yyyy-MM-dd") + "' and bWB=0  ");
                if (!string.IsNullOrEmpty(txtcusname.Text))
                {
                    pimsb.Append(" and Company='" + txtcusname.Text + "'");
                }
                if (!string.IsNullOrEmpty(txtMaker.Text))
                {
                    pimsb.Append(" and cmaker='" + txtMaker.Text + "'");
                }
                pimsb.Append(" order by piNum");
                DataTable table = clsDbHelperSQL.Query(DbManager.U8Conn, pimsb.ToString()).Tables[0];
                if (table.Rows.Count < 1)
                {
                    MessageBox.Show("没有需要导出的数据");
                    btnExportPi.Enabled = true;
                    return;
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string id = clsDataConvert.ToString(table.Rows[i]["ID"]);
                    string data = clsDataConvert.ToString(table.Rows[i]["Company"]);
                    string taxNo = clsDataConvert.ToString(table.Rows[i]["taxNo"]);
                    string depositBank = clsDataConvert.ToString(table.Rows[i]["depositBank"]);
                    string AccNo = clsDataConvert.ToString(table.Rows[i]["AccNo"]);
                    string Address = clsDataConvert.ToString(table.Rows[i]["Address"]);
                    string Telephone = clsDataConvert.ToString(table.Rows[i]["Telephone"]);
                    string cNo = clsDataConvert.ToString(table.Rows[i]["piNum"]);
                    string dMakeDateEx = clsDataConvert.ToString(table.Rows[i]["dMakeDateEx"]);
                    string belongMonth = clsDataConvert.ToDateStr(table.Rows[i]["belongMonth"], "yyyy-MM");
                    string strPiDetailSql = "SELECT  ROW_NUMBER() OVER(ORDER BY item) AS iNO ,itemName as cInvName, CAST(price AS DECIMAL(18,2))  as iSum  FROM H_PID where ID='" + id + "' ";
                    DataTable dataTable = clsDbHelperSQL.Query(DbManager.U8Conn, strPiDetailSql).Tables[0];
                    Workbook workbook2 = new Workbook(Application.StartupPath + @"\UAP\RUNTIME\PI_RMB.xlsx");
                    Worksheet worksheet = workbook2.Worksheets[0];
                    WorkbookDesigner designer = new WorkbookDesigner(workbook2);
                    dataTable.TableName = "dt";
                    designer.SetDataSource("PINO", cNo);
                    designer.SetDataSource("PIDate", clsDataConvert.ToDateStr(dMakeDateEx, "yyyy-MM-dd"));
                    designer.SetDataSource("Company", data);
                    designer.SetDataSource("TaxNO", taxNo);
                    designer.SetDataSource("Bank", depositBank);
                    designer.SetDataSource("Account", AccNo);
                    designer.SetDataSource("Address", Address);
                    designer.SetDataSource("Tel", Telephone);
                    designer.SetDataSource("SSYF", belongMonth);
                    designer.SetDataSource(dataTable);
                    designer.Process();
                    if (cNo.Length > 30)
                    {
                        designer.Workbook.Worksheets[0].Name = cNo.Substring(0, 30).Replace('/', '-');
                    }
                    else
                    {
                        designer.Workbook.Worksheets[0].Name = cNo.Replace('/', '-');
                    }
                    string sheetName = Path.Combine(Application.StartupPath, $"PI{i}.xls");
                    designer.Workbook.Save(sheetName, SaveFormat.Xlsx);
                    list.Add(sheetName);
                    if (i == 0)
                    {
                        workbook = new Workbook(sheetName);
                        startSheetName = cNo;
                    }
                    else
                    {
                        workbook2 = new Workbook(sheetName);
                        workbook.Combine(workbook2);
                    }
                    if (i == (table.Rows.Count - 1))
                    {
                        endSheetName = cNo;
                    }
                    workbook.Worksheets[0].AutoFitRows(15, 15 + dataTable.Rows.Count);
                }
                string[] textArray2 = new string[] { directoryName, @"\", startSheetName.Replace('/', '-'), "~", endSheetName.Replace('/', '-'), ".xlsx" };
                string fileName = string.Concat(textArray2);
                workbook.Save(fileName);
                foreach (string str19 in list)
                {
                    if (File.Exists(str19))
                    {
                        File.Delete(str19);
                    }
                }
                MessageBox.Show("导出完成!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("导出发生异常!\r\n具体为:" + exception.ToString());
            }
            btnExportPi.Enabled = true;


            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.FileName = "文件名.xls";  //文件名
            //sfd.Filter = "Excel 工作薄（*.xls）| *.xls";  //文件类型
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    NPOI.ExportPICN(sfd.FileName,null,null,"");

            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("请选择英文pi模板");
                return;
            }
            string excelName = "";
            switch (comboBox1.Text)
            {
                case "英文PI-浦发":
                    excelName = "PI_WB.xlsx";
                    break;
                case "英文PI交行（89811）":
                    excelName = "PIWB_JH89811.xlsx";
                    break;
                case "英文PI-汇丰":
                    excelName = "PIWB_HF.xlsx";
                    break;
                case "英文PI-交行（3954）":
                    excelName = "PIWB_JH3954.xlsx";
                    break;
                default:
                    excelName = "PI_WB.xlsx";
                    break;
            }
            btnpiwB.Enabled = false;
            SaveFileDialog sflg = new SaveFileDialog();
            sflg.FileName = ".xls";  //文件名
            sflg.Filter = "Excel 工作薄（*.xls）| *.xls";  //文件类型
            //this.btnPI.Enabled = false;
            try
            {
                if (sflg.ShowDialog() != DialogResult.OK)
                {
                    btnpiwB.Enabled = true;
                    return;
                }
                string directoryName = Path.GetDirectoryName(sflg.FileName);

                Workbook workbook = new Workbook();
                List<string> list = new List<string>();
                string startSheetName = string.Empty;
                string endSheetName = string.Empty;
                StringBuilder pimsb = new StringBuilder();
                pimsb.Append("select  case when isnull(ExchangeRate,0)=0 then 'CNY'+CAST( CAST((ISNULL(SubtotalinCNY,0) +isnull( BankChargeinCNY,0))  AS DECIMAL(18,2)) AS NVARCHAR(50)) ");
                pimsb.Append("else currency+CAST( CAST((ISNULL(SubtotalinCNY,0) +isnull( BankChargeinCNY,0))/ExchangeRate  AS DECIMAL(18,2)) AS NVARCHAR(50) )  end totalAmount, ");
                pimsb.Append(" cNo ,cMaker ,dMakeDateEx ,dMakeDate ,cMender ,dModifyDateEx ,dModifyDate ,cAuditor ,dAuditDateEx ,dAuditDate ,Company ,Address ,Attention ,Telephone ,CAST(BankChargeinCNY AS DECIMAL(18,2))BankChargeinCNY  ,TotalAmount ,ExchageDate , ");
                pimsb.Append("cast( isnull(ExchangeRate,0) as decimal(18,4) ) ExchangeRate ,");
                pimsb.Append(" currency ,taxNo ,depositBank ,AccNo ,belongMonth ,piNum ,CAST(SubtotalinCNY AS DECIMAL(18,2)) SubtotalinCNY ,ID ,iswfcontrolled ,iverifystate ,ireturncount ,UAPRuntime_RowNO ,UAP_VoucherTransform_Rowkey ,bWB ");
                pimsb.Append(" from h_pim  where  dMakeDateEx>='" + dtpS.Value.ToString("yyyy-MM-dd") + "' and dMakeDateEx<='" + dtpE.Value.ToString("yyyy-MM-dd") + "' and bWB=1  ");
                if (!string.IsNullOrEmpty(txtcusname.Text))
                {
                    pimsb.Append(" and Company='" + txtcusname.Text + "'");
                }
                if (!string.IsNullOrEmpty(txtMaker.Text))
                {
                    pimsb.Append(" and cmaker='" + txtMaker.Text + "'");
                }
                pimsb.Append(" order by piNum");
                DataTable table = clsDbHelperSQL.Query(DbManager.U8Conn, pimsb.ToString()).Tables[0];
                if (table.Rows.Count < 1)
                {
                    MessageBox.Show("没有需要导出的数据");
                    btnpiwB.Enabled = true;
                    return;
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string id = clsDataConvert.ToString(table.Rows[i]["ID"]);
                    string data = clsDataConvert.ToString(table.Rows[i]["Company"]);
                    string Address = clsDataConvert.ToString(table.Rows[i]["Address"]);
                    string Telephone = clsDataConvert.ToString(table.Rows[i]["Telephone"]);
                    string cNo = clsDataConvert.ToString(table.Rows[i]["piNum"]);
                    string dMakeDateEx = clsDataConvert.ToString(table.Rows[i]["dMakeDateEx"]);
                    decimal SubtotalinCNY = clsDataConvert.ToDecimal(table.Rows[i]["SubtotalinCNY"]);
                    decimal BankChargeinCNY = clsDataConvert.ToDecimal(table.Rows[i]["BankChargeinCNY"]);
                    string ExchageDate = clsDataConvert.ToDateStr(table.Rows[i]["ExchageDate"], "yyyy-MM-dd");
                    string ExchangeRate = clsDataConvert.ToDecimal(table.Rows[i]["ExchangeRate"]) == 0 ? "" : ":" + clsDataConvert.ToString(table.Rows[i]["ExchangeRate"]);
                    string totalAmount = clsDataConvert.ToString(table.Rows[i]["totalAmount"]);
                    string belongMonth = clsDataConvert.ToDateStr(table.Rows[i]["belongMonth"], "yyyy-MM");

                    string strPiDetailSql = "SELECT  ROW_NUMBER() OVER(ORDER BY item) AS iNO ,itemName as cInvName, CAST(price AS DECIMAL(18,2))  as iSum  FROM H_PID where ID='" + id + "' ";
                    DataTable dataTable = clsDbHelperSQL.Query(DbManager.U8Conn, strPiDetailSql).Tables[0];
                    Workbook workbook2 = new Workbook(Application.StartupPath + @"\UAP\RUNTIME\" + excelName);
                    Worksheet worksheet = workbook2.Worksheets[0];
                    WorkbookDesigner designer = new WorkbookDesigner(workbook2);
                    dataTable.TableName = "dt";
                    designer.SetDataSource("PINO", cNo);
                    designer.SetDataSource("PIDate", clsDataConvert.ToDateStr(dMakeDateEx, "yyyy-MM-dd"));
                    designer.SetDataSource("Company", data);
                    designer.SetDataSource("Address", Address);
                    designer.SetDataSource("Tel", Telephone);
                    designer.SetDataSource("SubtotalinCNY", SubtotalinCNY);
                    designer.SetDataSource("BankChargeinCNY", BankChargeinCNY);
                    designer.SetDataSource("ExchangeRate", ExchangeRate);
                    designer.SetDataSource("ExchageDate", ExchageDate);
                    designer.SetDataSource("totalAmount", totalAmount);
                    designer.SetDataSource("SSYF", belongMonth);

                    designer.SetDataSource(dataTable);
                    designer.Process();
                    if (cNo.Length > 30)
                    {
                        designer.Workbook.Worksheets[0].Name = cNo.Substring(0, 30).Replace('/', '-');
                    }
                    else
                    {
                        designer.Workbook.Worksheets[0].Name = cNo.Replace('/', '-');
                    }
                    string tempTableName = Path.Combine(Application.StartupPath, $"PI{i}.xls");
                    designer.Workbook.Save(tempTableName, SaveFormat.Xlsx);
                    list.Add(tempTableName);
                    if (i == 0)
                    {
                        workbook = new Workbook(tempTableName);
                        startSheetName = cNo;
                    }
                    else
                    {
                        workbook2 = new Workbook(tempTableName);
                        workbook.Combine(workbook2);
                    }
                    if (i == (table.Rows.Count - 1))
                    {
                        endSheetName = cNo;
                    }
                    workbook.Worksheets[0].AutoFitRows(15, 15 + dataTable.Rows.Count);
                }
                string[] textArray2 = new string[] { directoryName, @"\", startSheetName.Replace('/', '-'), "~", endSheetName.Replace('/', '-'), ".xlsx" };
                string fileName = string.Concat(textArray2);
                workbook.Save(fileName);
                foreach (string str19 in list)
                {
                    if (File.Exists(str19))
                    {
                        File.Delete(str19);
                    }
                }
                MessageBox.Show("导出完成!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("导出发生异常!\r\n具体为:" + exception.ToString());
            }
            btnpiwB.Enabled = true;
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
