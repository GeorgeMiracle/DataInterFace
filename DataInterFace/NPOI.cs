using DataInterFace.model;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataInterFace
{
    public class NPOI
    {
        /// <summary>
        /// 读取Excel中数据
        /// </summary>
        /// <param name="filePath"></param>
        public static List<model.PIExcelData> ReadSOData(string filePath)
        {
            try
            {
                if (!File.Exists(filePath.ToString()))
                {
                    throw new Exception("文件不存在!");
                }
                FileStream fsRead = new FileStream(filePath.ToString(), FileMode.Open);
                //创建工作薄
                IWorkbook workBook;
                string extenName = Path.GetExtension(filePath);
                if (extenName.ToUpper() == ".XLS")
                {
                    workBook = new HSSFWorkbook(fsRead);
                }
                else if (extenName.ToUpper() == ".XLSX")
                {
                    workBook = new XSSFWorkbook(fsRead);
                }
                else
                {
                    throw new Exception("不是有效的excel文件!");

                }
                var sheet = workBook.GetSheetAt(0);
                if (sheet.GetRow(1).GetCell(0).StringCellValue != "申请日期")
                {
                    throw new Exception("不是正确的excel模板!");
                }
                List<model.PIExcelData> piexcel = new List<model.PIExcelData>();

                //获取数据
                for (int i = 0; i < sheet.LastRowNum - 1; i++)
                {
                    bool bemptyRow = true;
                    PIExcelData pIExcelData = new PIExcelData();
                    //申请日期
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(0, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.appDate = GetCellValue(sheet.GetRow(2 + i).GetCell(0, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //开票公司
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(1, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.invoiceCompany = GetCellValue(sheet.GetRow(2 + i).GetCell(1, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //开票类型
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(2, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.invoiceType = GetCellValue(sheet.GetRow(2 + i).GetCell(2, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //业务类型
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(3, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.busType = GetCellValue(sheet.GetRow(2 + i).GetCell(3, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //部门
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(4, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.dep = GetCellValue(sheet.GetRow(2 + i).GetCell(4, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //项目编号
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(5, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.itemcode = GetCellValue(sheet.GetRow(2 + i).GetCell(5, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //项目简称
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(6, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.itemName = GetCellValue(sheet.GetRow(2 + i).GetCell(6, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //开票客户全称
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(7, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.cusname = GetCellValue(sheet.GetRow(2 + i).GetCell(7, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Tax No.
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(8, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.taxNo = GetCellValue(sheet.GetRow(2 + i).GetCell(8, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Deposit Bank
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(9, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.depositBank = GetCellValue(sheet.GetRow(2 + i).GetCell(9, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Account No.
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(10, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.AccNo = GetCellValue(sheet.GetRow(2 + i).GetCell(10, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Address
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(11, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Address = GetCellValue(sheet.GetRow(2 + i).GetCell(11, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Attention
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(12, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Contact = GetCellValue(sheet.GetRow(2 + i).GetCell(12, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Tel
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(13, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Phone = GetCellValue(sheet.GetRow(2 + i).GetCell(13, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Item 1
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(14, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Item1 = GetCellValue(sheet.GetRow(2 + i).GetCell(14, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Amt 1
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(15, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Amt1 = GetCellValue(sheet.GetRow(2 + i).GetCell(15, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Item 2
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(16, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Item2 = GetCellValue(sheet.GetRow(2 + i).GetCell(16, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Amt 2
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(17, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Amt2 = GetCellValue(sheet.GetRow(2 + i).GetCell(17, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Item 3
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(18, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Item3 = GetCellValue(sheet.GetRow(2 + i).GetCell(18, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Amt 3
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(19, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Amt3 = GetCellValue(sheet.GetRow(2 + i).GetCell(19, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Item 4
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(20, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Item4 = GetCellValue(sheet.GetRow(2 + i).GetCell(20, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Amt 4
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(21, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Amt4 = GetCellValue(sheet.GetRow(2 + i).GetCell(21, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Item 5
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(22, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Item5 = GetCellValue(sheet.GetRow(2 + i).GetCell(22, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Amt 5
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(23, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Amt5 = GetCellValue(sheet.GetRow(2 + i).GetCell(23, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Item 6
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(24, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Item6 = GetCellValue(sheet.GetRow(2 + i).GetCell(24, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Amt 6
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(25, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Amt6 = GetCellValue(sheet.GetRow(2 + i).GetCell(25, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Item 7
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(26, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Item7 = GetCellValue(sheet.GetRow(2 + i).GetCell(26, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Amt 7
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(27, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Amt7 = GetCellValue(sheet.GetRow(2 + i).GetCell(27, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Item 8
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(28, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Item8 = GetCellValue(sheet.GetRow(2 + i).GetCell(28, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Amt 8
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(29, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Amt8 = GetCellValue(sheet.GetRow(2 + i).GetCell(29, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //Sub-total amount to TS
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(30, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.Sub_total = GetCellValue(sheet.GetRow(2 + i).GetCell(30, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //向客户收取的银行手续费 
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(31, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.bankServicePrice = GetCellValue(sheet.GetRow(2 + i).GetCell(31, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //币种
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(32, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.currency = GetCellValue(sheet.GetRow(2 + i).GetCell(32, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //汇率
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(33, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.exchangeReate = GetCellValue(sheet.GetRow(2 + i).GetCell(33, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //汇率日期
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(34, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.exchangeDate = GetCellValue(sheet.GetRow(2 + i).GetCell(34, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //开票方式
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(35, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.invocieWay = GetCellValue(sheet.GetRow(2 + i).GetCell(35, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //合并标识
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(36, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.mergeState = GetCellValue(sheet.GetRow(2 + i).GetCell(36, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //普票代收代付商品名称
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(37, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.dsdfInvName = GetCellValue(sheet.GetRow(2 + i).GetCell(37, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //普票代收代付金额
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(38, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.dsdfPrice = GetCellValue(sheet.GetRow(2 + i).GetCell(38, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //普票服务费商品名称
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(39, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.ppServiceInvName = GetCellValue(sheet.GetRow(2 + i).GetCell(39, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //普票服务费金额
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(40, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.ppServiceInvPrice = GetCellValue(sheet.GetRow(2 + i).GetCell(40, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //专票服务费商品名称
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(41, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.zpServiceInvName = GetCellValue(sheet.GetRow(2 + i).GetCell(41, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //专票服务费金额
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(42, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.zpServiceInvPrice = GetCellValue(sheet.GetRow(2 + i).GetCell(42, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //所属月份
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(43, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.belongMonth = GetCellValue(sheet.GetRow(2 + i).GetCell(43, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //发票备注栏备注
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(44, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.remark = GetCellValue(sheet.GetRow(2 + i).GetCell(44, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //项目经理/猎头顾问
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(45, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.saleman = GetCellValue(sheet.GetRow(2 + i).GetCell(45, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //QC
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(46, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.qc = GetCellValue(sheet.GetRow(2 + i).GetCell(46, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //应到账日期
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(47, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.dueDate = GetCellValue(sheet.GetRow(2 + i).GetCell(47, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //候选人名
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(48, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.candidateName = GetCellValue(sheet.GetRow(2 + i).GetCell(48, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //收件公司
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(49, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.addressee = GetCellValue(sheet.GetRow(2 + i).GetCell(49, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //联系人
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(50, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.ContactDefine = GetCellValue(sheet.GetRow(2 + i).GetCell(50, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //联系电话
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(51, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.linkPhone = GetCellValue(sheet.GetRow(2 + i).GetCell(51, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //手机号码
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(52, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.linemobile = GetCellValue(sheet.GetRow(2 + i).GetCell(52, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //收件详细地址
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(53, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.shippingAddress = GetCellValue(sheet.GetRow(2 + i).GetCell(53, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //"EC金额 
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(54, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.ECPrice = GetCellValue(sheet.GetRow(2 + i).GetCell(54, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //"SF金额 
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(55, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.SFPrice = GetCellValue(sheet.GetRow(2 + i).GetCell(55, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //"培训费
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(56, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.trainPrcie = GetCellValue(sheet.GetRow(2 + i).GetCell(56, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }
                    //"向客户收取的银行手续费 
                    if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(58, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))
                    {
                        bemptyRow = false;
                        pIExcelData.bankServicePrice = GetCellValue(sheet.GetRow(2 + i).GetCell(58, MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();
                    }



                    if (!bemptyRow)
                    {
                        piexcel.Add(pIExcelData);
                    }
                }
                
                return piexcel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExportPICN(string path,DateTime? sD,DateTime? eD,string ccusname)
        {
            string modelPath = Application.StartupPath + @"\UAP\RUNTIME\PI.xlsx";
            if (!File.Exists(modelPath.ToString()))
            {
                throw new Exception("文件不存在!");
            }
            FileStream fsRead = new FileStream(modelPath, FileMode.Open);
            //创建工作薄
            IWorkbook workBook;
            string extenName = Path.GetExtension(modelPath);
            if (extenName.ToUpper() == ".XLS")
            {
                workBook = new HSSFWorkbook(fsRead);
            }
            else if (extenName.ToUpper() == ".XLSX")
            {
                workBook = new XSSFWorkbook(fsRead);
            }
            else
            {
                throw new Exception("不是有效的excel文件!");

            }
            var Osheet = workBook.GetSheetAt(0);

            var newWorkBook = new XSSFWorkbook();
            for (int i = 0; i < 3; i++)
            {
                newWorkBook.Insert(i,Osheet);
                
            }
            newWorkBook.GetSheetAt(0).CreateRow(1).CreateCell(0).SetCellValue("11");
            using (FileStream files = new FileStream(path, FileMode.Create))
            {
                newWorkBook.Write(files);
            }
        }
        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static object GetCellValue(ICell item)
        {
            if (item == null)
            {
                return string.Empty;
            }
            switch (item.CellType)
            {
                case CellType.Boolean:
                    return item.BooleanCellValue;

                case CellType.Error:
                    return ErrorEval.GetText(item.ErrorCellValue);

                case CellType.Formula:
                    switch (item.CachedFormulaResultType)
                    {
                        case CellType.Boolean:
                            return item.BooleanCellValue;

                        case CellType.Error:
                            return ErrorEval.GetText(item.ErrorCellValue);

                        case CellType.Numeric:
                            if (DateUtil.IsCellDateFormatted(item))
                            {
                                return item.DateCellValue.ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                return item.NumericCellValue;
                            }
                        case CellType.String:
                            string str = item.StringCellValue;
                            if (!string.IsNullOrEmpty(str))
                            {
                                return str.ToString();
                            }
                            else
                            {
                                return string.Empty;
                            }
                        case CellType.Unknown:
                        case CellType.Blank:
                        default:
                            return string.Empty;
                    }
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(item))
                    {
                        return item.DateCellValue.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        return item.NumericCellValue;
                    }
                case CellType.String:
                    string strValue = item.StringCellValue;
                    return strValue.ToString().Trim();

                case CellType.Unknown:
                case CellType.Blank:
                default:
                    return string.Empty;
            }
        }
    }
}
