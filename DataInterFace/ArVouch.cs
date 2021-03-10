using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UFDB;
namespace DataInterFace
{
    public class ArVouch
    {


        public List<string> ArExcelHeader = new List<string>()
        {
            "单据日期",
            "项目编码",
            "客户编号",
            "部门编号",
            "项目",
            "业务员编号",
            "科目",
            "科目名称",
            "到期日",
            "收款金额",
            "结算方式编码",
            "摘要",
            "收款日期",


        };

        private List<ArHeader> arHeaders { get; set; }
        public ArVouch(DataTable dt)
        {
           
            //列校验
            foreach (string colName in ArExcelHeader)
            {
                if (!dt.Columns.Contains(colName))
                {
                    throw new Exception(string.Format("列名:{0},不存在", colName));
                }
            }
            arHeaders = new List<ArHeader>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                arHeaders.Add(new ArHeader()
                {
                    vouchDate = clsDataConvert.ToDateTime(dt.Rows[i]["收款日期"]),
                    cuscode = clsDataConvert.ToString(dt.Rows[i]["客户编号"]),
                    depcode = clsDataConvert.ToString(dt.Rows[i]["部门编号"]),
                    personcode = clsDataConvert.ToString(dt.Rows[i]["业务员编号"]),
                    km = clsDataConvert.ToString(dt.Rows[i]["科目"]),
                    jsWay = clsDataConvert.ToString(dt.Rows[i]["结算方式编码"]),
                    degist = clsDataConvert.ToString(dt.Rows[i]["摘要"]),
                    arPrice = clsDataConvert.ToDecimal(dt.Rows[i]["收款金额"]),
                    xm = clsDataConvert.ToString(dt.Rows[i]["项目编码"]),
                    itemName = clsDataConvert.ToString(dt.Rows[i]["项目"]),
                    PICode = clsDataConvert.ToString(dt.Rows[i]["订单号"]),

                });
            }

            //表体检测
            int row = 1;
            foreach (var ar in arHeaders)
            {
                if (string.IsNullOrEmpty(ar.cuscode))
                {
                    throw new Exception(string.Format("第{0}行,客户编码不能为空", row.ToString()));

                }
                if (string.IsNullOrEmpty(ar.depcode))
                {
                    throw new Exception(string.Format("第{0}行,部门编码不能为空", row.ToString()));

                }
                if (string.IsNullOrEmpty(ar.km))
                {
                    throw new Exception(string.Format("第{0}行,科目不能为空", row.ToString()));

                }
                if (string.IsNullOrEmpty(ar.jsWay))
                {
                    throw new Exception(string.Format("第{0}行,结算方式编码不能为空", row.ToString()));

                }
                if (string.IsNullOrEmpty(ar.degist))
                {
                    throw new Exception(string.Format("第{0}行,摘要不能为空", row.ToString()));

                }
                if (ar.arPrice == 0)
                {
                    throw new Exception(string.Format("第{0}行,收款金额不能为零", row.ToString()));

                }
                if (string.IsNullOrEmpty(ar.xm))
                {
                    throw new Exception(string.Format("第{0}行,项目编码不能为空", row.ToString()));

                }
                row++;

            }
        }

        public void AddArVouch()
        {
            using (UFDataContext uf = new UFDataContext(DbManager.U8Conn))
            {
                var groupedAr = arHeaders.GroupBy(x => new { x.cuscode, x.PICode, x.vouchDate, x.personcode, x.depcode, x.jsWay, x.degist });
                foreach (var item in groupedAr)
                {
                    decimal sumPrice = item.Sum(x => x.arPrice);
                    Ap_CloseBill ap_CloseBill = new Ap_CloseBill();
                    ap_CloseBill.iID = Convert.ToInt32(clsGetID.getAutoId(DbManager.U8Conn, "SK", DbManager.U8Conn.Split('_')[1], 1));
                    ap_CloseBill.cVouchType = item.First().arPrice > 0 ? "48" : "49";
                    ap_CloseBill.cVouchID = item.First().arPrice > 0 ? clsGetID.getcode(DbManager.U8Conn, "RR") : clsGetID.getcode(DbManager.U8Conn, "RP");
                    ap_CloseBill.dVouchDate = item.Key.vouchDate;
                    ap_CloseBill.iPeriod = Convert.ToByte(item.Key.vouchDate.Month);
                    ap_CloseBill.cDwCode = item.Key.cuscode;
                    ap_CloseBill.cPerson = item.Key.personcode;
                    ap_CloseBill.cDeptCode = item.Key.depcode;
                    var ccode = Voucher.GetcCodeBySettleType(item.Key.jsWay, DbManager.U8Conn);//根据结算方式编码获取结算科目
                    ap_CloseBill.cCode = ccode;
                    ap_CloseBill.cSSCode = item.Key.jsWay;//结算方式
                    ap_CloseBill.cDigest = item.Key.degist;
                    var cusRet = uf.Customer.FirstOrDefault(x => x.cCusCode == ap_CloseBill.cDwCode);
                    ap_CloseBill.cBankAccount = cusRet.cCusBankCode;//银行号
                    ap_CloseBill.cexch_name = "人民币";//币种
                    ap_CloseBill.iExchRate = 1;//汇率
                    ap_CloseBill.iAmount = Math.Round(sumPrice, 2, MidpointRounding.AwayFromZero);//本币金额
                    ap_CloseBill.iAmount_f = Math.Round(sumPrice, 2, MidpointRounding.AwayFromZero);//原币金额
                    ap_CloseBill.iRAmount = Math.Round(sumPrice, 2, MidpointRounding.AwayFromZero);//本币金额
                    ap_CloseBill.iRAmount_f = Math.Round(sumPrice, 2, MidpointRounding.AwayFromZero);//原币金额
                    ap_CloseBill.cOperator = DbManager.UserName;
                    ap_CloseBill.bPrePay = false;
                    ap_CloseBill.bStartFlag = false;
                    ap_CloseBill.iPayForOther = false;
                    ap_CloseBill.cFlag = "AR";
                    ap_CloseBill.bSend = false;
                    ap_CloseBill.bReceived = false;
                    ap_CloseBill.cBank = cusRet.cCusBank;
                    ap_CloseBill.bFromBank = false;
                    ap_CloseBill.bToBank = false;
                    ap_CloseBill.bSure = false;
                    ap_CloseBill.VT_ID = ap_CloseBill.cVouchType == "48" ? 8052 : 8055;
                    ap_CloseBill.iAmount_s = 0;
                    ap_CloseBill.IsWfControlled = false;
                    ap_CloseBill.RegisterFlag = 0;
                    ap_CloseBill.dcreatesystime = DateTime.Now;
                    ap_CloseBill.ibg_ctrl = false;
                    ap_CloseBill.ibg_overflag = 0;
                    ap_CloseBill.iPrintCount = 0;
                    ap_CloseBill.iPayType = 0;

                    ap_CloseBill.csysbarcode = "||ar" + ap_CloseBill.cVouchType + "|" + ap_CloseBill.cVouchID + "";

                    List<Ap_CloseBills> arDetails = new List<Ap_CloseBills>();
                    foreach (var items in item)
                    {
                        arDetails.Add(new Ap_CloseBills()
                        {
                            ID = Convert.ToInt32(clsGetID.getAutoId(DbManager.U8Conn, "SK", DbManager.U8Conn.Split('_')[1], 0)),
                            bPrePay = false,
                            iType = 0,
                            cCusVen = items.cuscode,
                            cKm = items.km,
                            iAmt = Math.Round(items.arPrice, 2, MidpointRounding.AwayFromZero),//本币金额
                            iAmt_f = Math.Round(items.arPrice, 2, MidpointRounding.AwayFromZero),//原币金额 
                            iRAmt = Math.Round(items.arPrice, 2, MidpointRounding.AwayFromZero),//本币金额
                            iRAmt_f = Math.Round(items.arPrice, 2, MidpointRounding.AwayFromZero),//原币金额
                            iAmt_s = 0,
                            iRAmt_s = 0,
                            RegisterFlag = 0,
                            iSrcClosesID = 0,
                            ifaresettled_f = 0,
                            iID = ap_CloseBill.iID,
                            cXmClass = "97",
                            cXm = items.xm,
                            cItemName = items.itemName,

                            cDepCode = items.depcode,
                            cPersonCode=items.personcode
                            //cDefine22 = item.cinvName

                        });
                    }

                    uf.Ap_CloseBill.InsertOnSubmit(ap_CloseBill);
                    uf.Ap_CloseBill_extradefine.InsertOnSubmit(new Ap_CloseBill_extradefine()
                    {
                        iID = ap_CloseBill.iID

                    });

                    uf.Ap_CloseBills.InsertAllOnSubmit(arDetails);
                    List<Ap_CloseBills_extradefine> ap_CloseBills_Extradefines = new List<Ap_CloseBills_extradefine>();
                    foreach (var ars in arDetails)
                    {
                        ap_CloseBills_Extradefines.Add(new Ap_CloseBills_extradefine()
                        {
                            ID = ars.ID

                        });
                    }
                    uf.Ap_CloseBills_extradefine.InsertAllOnSubmit(ap_CloseBills_Extradefines);
                }

                uf.SubmitChanges();
            }
        }
    }

    public class ArHeader
    {

        public string PICode { get; set; }
        public DateTime vouchDate { get; set; }

        public string cuscode { get; set; }

        public string personcode { get; set; }

        public string depcode { get; set; }

        public string degist { get; set; }

        public string km { get; set; }

        public string jsWay { get; set; }

        public string xm { get; set; }
        public string itemName { get; set; }


        public decimal arPrice { get; set; }



    }
}
