using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataInterFace.model
{
     public class PIExcelData
    {
         /// <summary>
        /// 申请日期
         /// </summary>
        public string appDate { get; set; }
        /// <summary>
        /// 开票公司
        /// </summary>
        public string invoiceCompany { get; set; }
        /// <summary>
        /// 开票类型
        /// </summary>
        public string invoiceType { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string busType { get; set; }
        /// <summary>
        /// 业务类型编码
        /// </summary>
        public string busCode { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string dep { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        public string depCode { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string itemcode { get; set; }
        /// <summary>
        /// 项目简称
        /// </summary>
        public string itemName { get; set; }
        /// <summary>
        /// 开票客户全称
        /// </summary>
        public string cusname { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string realcusname { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string realcusCode { get; set; }
        /// <summary>
        /// EC
        /// </summary>

        /// <summary>
        /// 合并标识 
        /// </summary>
        public string mergeState { get; set; }
        /// <summary>
        /// Tax No. 
        /// </summary>
        public string taxNo { get; set; }
        /// <summary>
        /// Deposit Bank 
        /// </summary>
        public string depositBank { get; set; }
        /// <summary>
        /// Account No. 
        /// </summary>
        public string AccNo { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Attention
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// Tel
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Item 1
        /// </summary>
        public string Item1 { get; set; }
        /// <summary>
        /// Amt1
        /// </summary>
        public string Amt1 { get; set; }
        /// <summary>
        /// Item2
        /// </summary>
        public string Item2 { get; set; }
        /// <summary>
        /// Amt2
        /// </summary>
        public string Amt2 { get; set; }
        /// <summary>
        /// Item3
        /// </summary>
        public string Item3 { get; set; }
        /// <summary>
        /// Amt3
        /// </summary>
        public string Amt3 { get; set; }
        /// <summary>
        /// Item4
        /// </summary>
        public string Item4 { get; set; }
        /// <summary>
        /// Amt4
        /// </summary>
        public string Amt4 { get; set; }
        /// <summary>
        /// Item5
        /// </summary>
        public string Item5 { get; set; }
        /// <summary>
        /// Amt5
        /// </summary>
        public string Amt5 { get; set; }
        /// <summary>
        /// Item6
        /// </summary>
        public string Item6 { get; set; }
        /// <summary>
        /// Amt6
        /// </summary>
        public string Amt6 { get; set; }
        /// <summary>
        /// Item7
        /// </summary>
        public string Item7 { get; set; }
        /// <summary>
        /// Amt7
        /// </summary>
        public string Amt7 { get; set; }
        /// <summary>
        /// Item8
        /// </summary>
        public string Item8 { get; set; }
        /// <summary>
        /// Amt8
        /// </summary>
        public string Amt8 { get; set; }
        /// <summary>
        /// Sub_total
        /// </summary>
        public string Sub_total { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        public string exchangeReate { get; set; }
        /// <summary>
        /// 汇率日期
        /// </summary>
        public string exchangeDate { get; set; }
        /// <summary>
        /// 开票方式
        /// </summary>
        public string invocieWay { get; set; }
        /// <summary>
        /// 普票代收代付商品名称
        /// </summary>
        public string dsdfInvName { get; set; }
        /// <summary>
        /// 普票代收代付金额
        /// </summary>
        public string dsdfPrice { get; set; }
        /// <summary>
        /// 普票服务费商品名称
        /// </summary>
        public string ppServiceInvName { get; set; }
        /// <summary>
        /// 普票服务费金额
        /// </summary>
        public string ppServiceInvPrice { get; set; }
        /// <summary>
        /// 专票服务费商品名称
        /// </summary>
        public string zpServiceInvName { get; set; }
        /// <summary>
        /// 专票服务费金额
        /// </summary>
        public string zpServiceInvPrice { get; set; }
        /// <summary>
        /// 所属月份
        /// </summary>
        public string belongMonth { get; set; }
        /// <summary>
        /// 发票备注栏备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 项目经理/猎头顾问
        /// </summary>
        public string saleman { get; set; }

        public string salemanCode { get; set; }
        /// <summary>
        ///QC
        /// </summary>
        public string qc { get; set; }
        /// <summary>
        ///应到账日期
        /// </summary>
        public string dueDate { get; set; }
        /// <summary>
        ///候选人名
        /// </summary>
        public string candidateName { get; set; }
        /// <summary>
        ///收件公司
        /// </summary>
        public string addressee { get; set; }
        /// <summary>                                   
        ///联系人
        /// </summary>
        public string ContactDefine { get; set; }
        /// <summary>
        ///联系电话
        /// </summary>
        public string linkPhone { get; set; }
        /// <summary>
        ///手机号码
        /// </summary>
        public string linemobile { get; set; }
        /// <summary>
        ///收件详细地址
        /// </summary>
        public string shippingAddress { get; set; }
        public string ECPrice { get; set; }
        /// <summary>
        /// SF
        /// </summary>
        public string SFPrice { get; set; }
        /// <summary>
        /// 培训费
        /// </summary>
        public string trainPrcie { get; set; }
        /// <summary>
        /// 需和客户结算的汇兑损益
        /// </summary>
        public string exchanLossPrice { get; set; }
        /// <summary>
        /// 向客户收取的银行手续费 
        /// </summary>
        public string bankServicePrice { get; set; }
        /// <summary>
        ///验证
        /// </summary>
        public string verify { get; set; }
        
        public string piNum { get; set;  }
        public bool bRedVouch { get; set; }

        public string cdefine1 { get; set; }
    }
}
