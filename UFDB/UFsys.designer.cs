﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace UFDB
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="UFSystem")]
	public partial class UFsysDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertUA_Account(UA_Account instance);
    partial void UpdateUA_Account(UA_Account instance);
    partial void DeleteUA_Account(UA_Account instance);
    partial void InsertUA_Account_sub(UA_Account_sub instance);
    partial void UpdateUA_Account_sub(UA_Account_sub instance);
    partial void DeleteUA_Account_sub(UA_Account_sub instance);
    partial void InsertUA_AccountDatabase(UA_AccountDatabase instance);
    partial void UpdateUA_AccountDatabase(UA_AccountDatabase instance);
    partial void DeleteUA_AccountDatabase(UA_AccountDatabase instance);
    #endregion
		
		public UFsysDataContext() : 
				base(global::UFDB.Properties.Settings.Default.UFSystemConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public UFsysDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UFsysDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UFsysDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UFsysDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<UA_Account> UA_Account
		{
			get
			{
				return this.GetTable<UA_Account>();
			}
		}
		
		public System.Data.Linq.Table<UA_Account_sub> UA_Account_sub
		{
			get
			{
				return this.GetTable<UA_Account_sub>();
			}
		}
		
		public System.Data.Linq.Table<UA_AccountDatabase> UA_AccountDatabase
		{
			get
			{
				return this.GetTable<UA_AccountDatabase>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UA_Account")]
	public partial class UA_Account : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _iSysID;
		
		private string _cAcc_Id;
		
		private string _cAcc_Name;
		
		private string _cAcc_Path;
		
		private short _iYear;
		
		private short _iMonth;
		
		private string _cAcc_Master;
		
		private string _cCurCode;
		
		private string _cCurName;
		
		private string _cUnitName;
		
		private string _cUnitAbbre;
		
		private string _cUnitAddr;
		
		private string _cUnitZap;
		
		private string _cUnitTel;
		
		private string _cUnitFax;
		
		private string _cUnitEMail;
		
		private string _cUnitTaxNo;
		
		private string _cUnitLP;
		
		private string _cFinKind;
		
		private string _cFinType;
		
		private string _cEntType;
		
		private string _cTradeKind;
		
		private char _cIsCompanyVer;
		
		private string _cDomain;
		
		private string _cOrgCode;
		
		private string _cUnitNameEn;
		
		private string _cUnitAddress1En;
		
		private string _cUnitAddress2En;
		
		private string _cUnitAddress3En;
		
		private string _cUnitAddress4En;
		
		private string _cCustomCode;
		
		private string _cPortCode;
		
		private string _cCustomBrokerCode;
		
		private string _cDescription;
		
		private string _cIndustryCode;
		
		private System.Nullable<bool> _bIM;
		
		private System.Nullable<bool> _bIntelligentInput;
		
		private string _cESpaceID;
		
		private EntitySet<UA_Account_sub> _UA_Account_sub;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OniSysIDChanging(string value);
    partial void OniSysIDChanged();
    partial void OncAcc_IdChanging(string value);
    partial void OncAcc_IdChanged();
    partial void OncAcc_NameChanging(string value);
    partial void OncAcc_NameChanged();
    partial void OncAcc_PathChanging(string value);
    partial void OncAcc_PathChanged();
    partial void OniYearChanging(short value);
    partial void OniYearChanged();
    partial void OniMonthChanging(short value);
    partial void OniMonthChanged();
    partial void OncAcc_MasterChanging(string value);
    partial void OncAcc_MasterChanged();
    partial void OncCurCodeChanging(string value);
    partial void OncCurCodeChanged();
    partial void OncCurNameChanging(string value);
    partial void OncCurNameChanged();
    partial void OncUnitNameChanging(string value);
    partial void OncUnitNameChanged();
    partial void OncUnitAbbreChanging(string value);
    partial void OncUnitAbbreChanged();
    partial void OncUnitAddrChanging(string value);
    partial void OncUnitAddrChanged();
    partial void OncUnitZapChanging(string value);
    partial void OncUnitZapChanged();
    partial void OncUnitTelChanging(string value);
    partial void OncUnitTelChanged();
    partial void OncUnitFaxChanging(string value);
    partial void OncUnitFaxChanged();
    partial void OncUnitEMailChanging(string value);
    partial void OncUnitEMailChanged();
    partial void OncUnitTaxNoChanging(string value);
    partial void OncUnitTaxNoChanged();
    partial void OncUnitLPChanging(string value);
    partial void OncUnitLPChanged();
    partial void OncFinKindChanging(string value);
    partial void OncFinKindChanged();
    partial void OncFinTypeChanging(string value);
    partial void OncFinTypeChanged();
    partial void OncEntTypeChanging(string value);
    partial void OncEntTypeChanged();
    partial void OncTradeKindChanging(string value);
    partial void OncTradeKindChanged();
    partial void OncIsCompanyVerChanging(char value);
    partial void OncIsCompanyVerChanged();
    partial void OncDomainChanging(string value);
    partial void OncDomainChanged();
    partial void OncOrgCodeChanging(string value);
    partial void OncOrgCodeChanged();
    partial void OncUnitNameEnChanging(string value);
    partial void OncUnitNameEnChanged();
    partial void OncUnitAddress1EnChanging(string value);
    partial void OncUnitAddress1EnChanged();
    partial void OncUnitAddress2EnChanging(string value);
    partial void OncUnitAddress2EnChanged();
    partial void OncUnitAddress3EnChanging(string value);
    partial void OncUnitAddress3EnChanged();
    partial void OncUnitAddress4EnChanging(string value);
    partial void OncUnitAddress4EnChanged();
    partial void OncCustomCodeChanging(string value);
    partial void OncCustomCodeChanged();
    partial void OncPortCodeChanging(string value);
    partial void OncPortCodeChanged();
    partial void OncCustomBrokerCodeChanging(string value);
    partial void OncCustomBrokerCodeChanged();
    partial void OncDescriptionChanging(string value);
    partial void OncDescriptionChanged();
    partial void OncIndustryCodeChanging(string value);
    partial void OncIndustryCodeChanged();
    partial void OnbIMChanging(System.Nullable<bool> value);
    partial void OnbIMChanged();
    partial void OnbIntelligentInputChanging(System.Nullable<bool> value);
    partial void OnbIntelligentInputChanged();
    partial void OncESpaceIDChanging(string value);
    partial void OncESpaceIDChanged();
    #endregion
		
		public UA_Account()
		{
			this._UA_Account_sub = new EntitySet<UA_Account_sub>(new Action<UA_Account_sub>(this.attach_UA_Account_sub), new Action<UA_Account_sub>(this.detach_UA_Account_sub));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iSysID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string iSysID
		{
			get
			{
				return this._iSysID;
			}
			set
			{
				if ((this._iSysID != value))
				{
					this.OniSysIDChanging(value);
					this.SendPropertyChanging();
					this._iSysID = value;
					this.SendPropertyChanged("iSysID");
					this.OniSysIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cAcc_Id", DbType="NVarChar(3) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string cAcc_Id
		{
			get
			{
				return this._cAcc_Id;
			}
			set
			{
				if ((this._cAcc_Id != value))
				{
					this.OncAcc_IdChanging(value);
					this.SendPropertyChanging();
					this._cAcc_Id = value;
					this.SendPropertyChanged("cAcc_Id");
					this.OncAcc_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cAcc_Name", DbType="NVarChar(40) NOT NULL", CanBeNull=false)]
		public string cAcc_Name
		{
			get
			{
				return this._cAcc_Name;
			}
			set
			{
				if ((this._cAcc_Name != value))
				{
					this.OncAcc_NameChanging(value);
					this.SendPropertyChanging();
					this._cAcc_Name = value;
					this.SendPropertyChanged("cAcc_Name");
					this.OncAcc_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cAcc_Path", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string cAcc_Path
		{
			get
			{
				return this._cAcc_Path;
			}
			set
			{
				if ((this._cAcc_Path != value))
				{
					this.OncAcc_PathChanging(value);
					this.SendPropertyChanging();
					this._cAcc_Path = value;
					this.SendPropertyChanged("cAcc_Path");
					this.OncAcc_PathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iYear", DbType="SmallInt NOT NULL")]
		public short iYear
		{
			get
			{
				return this._iYear;
			}
			set
			{
				if ((this._iYear != value))
				{
					this.OniYearChanging(value);
					this.SendPropertyChanging();
					this._iYear = value;
					this.SendPropertyChanged("iYear");
					this.OniYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iMonth", DbType="SmallInt NOT NULL")]
		public short iMonth
		{
			get
			{
				return this._iMonth;
			}
			set
			{
				if ((this._iMonth != value))
				{
					this.OniMonthChanging(value);
					this.SendPropertyChanging();
					this._iMonth = value;
					this.SendPropertyChanged("iMonth");
					this.OniMonthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cAcc_Master", DbType="NVarChar(20)")]
		public string cAcc_Master
		{
			get
			{
				return this._cAcc_Master;
			}
			set
			{
				if ((this._cAcc_Master != value))
				{
					this.OncAcc_MasterChanging(value);
					this.SendPropertyChanging();
					this._cAcc_Master = value;
					this.SendPropertyChanged("cAcc_Master");
					this.OncAcc_MasterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cCurCode", DbType="NVarChar(4) NOT NULL", CanBeNull=false)]
		public string cCurCode
		{
			get
			{
				return this._cCurCode;
			}
			set
			{
				if ((this._cCurCode != value))
				{
					this.OncCurCodeChanging(value);
					this.SendPropertyChanging();
					this._cCurCode = value;
					this.SendPropertyChanged("cCurCode");
					this.OncCurCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cCurName", DbType="NVarChar(8) NOT NULL", CanBeNull=false)]
		public string cCurName
		{
			get
			{
				return this._cCurName;
			}
			set
			{
				if ((this._cCurName != value))
				{
					this.OncCurNameChanging(value);
					this.SendPropertyChanging();
					this._cCurName = value;
					this.SendPropertyChanged("cCurName");
					this.OncCurNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitName", DbType="NVarChar(80) NOT NULL", CanBeNull=false)]
		public string cUnitName
		{
			get
			{
				return this._cUnitName;
			}
			set
			{
				if ((this._cUnitName != value))
				{
					this.OncUnitNameChanging(value);
					this.SendPropertyChanging();
					this._cUnitName = value;
					this.SendPropertyChanged("cUnitName");
					this.OncUnitNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitAbbre", DbType="NVarChar(40)")]
		public string cUnitAbbre
		{
			get
			{
				return this._cUnitAbbre;
			}
			set
			{
				if ((this._cUnitAbbre != value))
				{
					this.OncUnitAbbreChanging(value);
					this.SendPropertyChanging();
					this._cUnitAbbre = value;
					this.SendPropertyChanged("cUnitAbbre");
					this.OncUnitAbbreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitAddr", DbType="NVarChar(80)")]
		public string cUnitAddr
		{
			get
			{
				return this._cUnitAddr;
			}
			set
			{
				if ((this._cUnitAddr != value))
				{
					this.OncUnitAddrChanging(value);
					this.SendPropertyChanging();
					this._cUnitAddr = value;
					this.SendPropertyChanged("cUnitAddr");
					this.OncUnitAddrChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitZap", DbType="NVarChar(20)")]
		public string cUnitZap
		{
			get
			{
				return this._cUnitZap;
			}
			set
			{
				if ((this._cUnitZap != value))
				{
					this.OncUnitZapChanging(value);
					this.SendPropertyChanging();
					this._cUnitZap = value;
					this.SendPropertyChanged("cUnitZap");
					this.OncUnitZapChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitTel", DbType="NVarChar(30)")]
		public string cUnitTel
		{
			get
			{
				return this._cUnitTel;
			}
			set
			{
				if ((this._cUnitTel != value))
				{
					this.OncUnitTelChanging(value);
					this.SendPropertyChanging();
					this._cUnitTel = value;
					this.SendPropertyChanged("cUnitTel");
					this.OncUnitTelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitFax", DbType="NVarChar(30)")]
		public string cUnitFax
		{
			get
			{
				return this._cUnitFax;
			}
			set
			{
				if ((this._cUnitFax != value))
				{
					this.OncUnitFaxChanging(value);
					this.SendPropertyChanging();
					this._cUnitFax = value;
					this.SendPropertyChanged("cUnitFax");
					this.OncUnitFaxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitEMail", DbType="NVarChar(40)")]
		public string cUnitEMail
		{
			get
			{
				return this._cUnitEMail;
			}
			set
			{
				if ((this._cUnitEMail != value))
				{
					this.OncUnitEMailChanging(value);
					this.SendPropertyChanging();
					this._cUnitEMail = value;
					this.SendPropertyChanged("cUnitEMail");
					this.OncUnitEMailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitTaxNo", DbType="NVarChar(20)")]
		public string cUnitTaxNo
		{
			get
			{
				return this._cUnitTaxNo;
			}
			set
			{
				if ((this._cUnitTaxNo != value))
				{
					this.OncUnitTaxNoChanging(value);
					this.SendPropertyChanging();
					this._cUnitTaxNo = value;
					this.SendPropertyChanged("cUnitTaxNo");
					this.OncUnitTaxNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitLP", DbType="NVarChar(16)")]
		public string cUnitLP
		{
			get
			{
				return this._cUnitLP;
			}
			set
			{
				if ((this._cUnitLP != value))
				{
					this.OncUnitLPChanging(value);
					this.SendPropertyChanging();
					this._cUnitLP = value;
					this.SendPropertyChanged("cUnitLP");
					this.OncUnitLPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cFinKind", DbType="NVarChar(16)")]
		public string cFinKind
		{
			get
			{
				return this._cFinKind;
			}
			set
			{
				if ((this._cFinKind != value))
				{
					this.OncFinKindChanging(value);
					this.SendPropertyChanging();
					this._cFinKind = value;
					this.SendPropertyChanged("cFinKind");
					this.OncFinKindChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cFinType", DbType="NVarChar(16)")]
		public string cFinType
		{
			get
			{
				return this._cFinType;
			}
			set
			{
				if ((this._cFinType != value))
				{
					this.OncFinTypeChanging(value);
					this.SendPropertyChanging();
					this._cFinType = value;
					this.SendPropertyChanged("cFinType");
					this.OncFinTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cEntType", DbType="NVarChar(12) NOT NULL", CanBeNull=false)]
		public string cEntType
		{
			get
			{
				return this._cEntType;
			}
			set
			{
				if ((this._cEntType != value))
				{
					this.OncEntTypeChanging(value);
					this.SendPropertyChanging();
					this._cEntType = value;
					this.SendPropertyChanged("cEntType");
					this.OncEntTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cTradeKind", DbType="NVarChar(100)")]
		public string cTradeKind
		{
			get
			{
				return this._cTradeKind;
			}
			set
			{
				if ((this._cTradeKind != value))
				{
					this.OncTradeKindChanging(value);
					this.SendPropertyChanging();
					this._cTradeKind = value;
					this.SendPropertyChanged("cTradeKind");
					this.OncTradeKindChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cIsCompanyVer", DbType="NChar(1) NOT NULL")]
		public char cIsCompanyVer
		{
			get
			{
				return this._cIsCompanyVer;
			}
			set
			{
				if ((this._cIsCompanyVer != value))
				{
					this.OncIsCompanyVerChanging(value);
					this.SendPropertyChanging();
					this._cIsCompanyVer = value;
					this.SendPropertyChanged("cIsCompanyVer");
					this.OncIsCompanyVerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cDomain", DbType="NVarChar(40)")]
		public string cDomain
		{
			get
			{
				return this._cDomain;
			}
			set
			{
				if ((this._cDomain != value))
				{
					this.OncDomainChanging(value);
					this.SendPropertyChanging();
					this._cDomain = value;
					this.SendPropertyChanged("cDomain");
					this.OncDomainChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cOrgCode", DbType="NVarChar(50)")]
		public string cOrgCode
		{
			get
			{
				return this._cOrgCode;
			}
			set
			{
				if ((this._cOrgCode != value))
				{
					this.OncOrgCodeChanging(value);
					this.SendPropertyChanging();
					this._cOrgCode = value;
					this.SendPropertyChanged("cOrgCode");
					this.OncOrgCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitNameEn", DbType="NVarChar(255)")]
		public string cUnitNameEn
		{
			get
			{
				return this._cUnitNameEn;
			}
			set
			{
				if ((this._cUnitNameEn != value))
				{
					this.OncUnitNameEnChanging(value);
					this.SendPropertyChanging();
					this._cUnitNameEn = value;
					this.SendPropertyChanged("cUnitNameEn");
					this.OncUnitNameEnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitAddress1En", DbType="NVarChar(255)")]
		public string cUnitAddress1En
		{
			get
			{
				return this._cUnitAddress1En;
			}
			set
			{
				if ((this._cUnitAddress1En != value))
				{
					this.OncUnitAddress1EnChanging(value);
					this.SendPropertyChanging();
					this._cUnitAddress1En = value;
					this.SendPropertyChanged("cUnitAddress1En");
					this.OncUnitAddress1EnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitAddress2En", DbType="NVarChar(255)")]
		public string cUnitAddress2En
		{
			get
			{
				return this._cUnitAddress2En;
			}
			set
			{
				if ((this._cUnitAddress2En != value))
				{
					this.OncUnitAddress2EnChanging(value);
					this.SendPropertyChanging();
					this._cUnitAddress2En = value;
					this.SendPropertyChanged("cUnitAddress2En");
					this.OncUnitAddress2EnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitAddress3En", DbType="NVarChar(255)")]
		public string cUnitAddress3En
		{
			get
			{
				return this._cUnitAddress3En;
			}
			set
			{
				if ((this._cUnitAddress3En != value))
				{
					this.OncUnitAddress3EnChanging(value);
					this.SendPropertyChanging();
					this._cUnitAddress3En = value;
					this.SendPropertyChanged("cUnitAddress3En");
					this.OncUnitAddress3EnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUnitAddress4En", DbType="NVarChar(255)")]
		public string cUnitAddress4En
		{
			get
			{
				return this._cUnitAddress4En;
			}
			set
			{
				if ((this._cUnitAddress4En != value))
				{
					this.OncUnitAddress4EnChanging(value);
					this.SendPropertyChanging();
					this._cUnitAddress4En = value;
					this.SendPropertyChanged("cUnitAddress4En");
					this.OncUnitAddress4EnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cCustomCode", DbType="NVarChar(30)")]
		public string cCustomCode
		{
			get
			{
				return this._cCustomCode;
			}
			set
			{
				if ((this._cCustomCode != value))
				{
					this.OncCustomCodeChanging(value);
					this.SendPropertyChanging();
					this._cCustomCode = value;
					this.SendPropertyChanged("cCustomCode");
					this.OncCustomCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cPortCode", DbType="NVarChar(10)")]
		public string cPortCode
		{
			get
			{
				return this._cPortCode;
			}
			set
			{
				if ((this._cPortCode != value))
				{
					this.OncPortCodeChanging(value);
					this.SendPropertyChanging();
					this._cPortCode = value;
					this.SendPropertyChanged("cPortCode");
					this.OncPortCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cCustomBrokerCode", DbType="NVarChar(20)")]
		public string cCustomBrokerCode
		{
			get
			{
				return this._cCustomBrokerCode;
			}
			set
			{
				if ((this._cCustomBrokerCode != value))
				{
					this.OncCustomBrokerCodeChanging(value);
					this.SendPropertyChanging();
					this._cCustomBrokerCode = value;
					this.SendPropertyChanged("cCustomBrokerCode");
					this.OncCustomBrokerCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cDescription", DbType="NVarChar(100)")]
		public string cDescription
		{
			get
			{
				return this._cDescription;
			}
			set
			{
				if ((this._cDescription != value))
				{
					this.OncDescriptionChanging(value);
					this.SendPropertyChanging();
					this._cDescription = value;
					this.SendPropertyChanged("cDescription");
					this.OncDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cIndustryCode", DbType="NVarChar(100)")]
		public string cIndustryCode
		{
			get
			{
				return this._cIndustryCode;
			}
			set
			{
				if ((this._cIndustryCode != value))
				{
					this.OncIndustryCodeChanging(value);
					this.SendPropertyChanging();
					this._cIndustryCode = value;
					this.SendPropertyChanged("cIndustryCode");
					this.OncIndustryCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bIM", DbType="Bit")]
		public System.Nullable<bool> bIM
		{
			get
			{
				return this._bIM;
			}
			set
			{
				if ((this._bIM != value))
				{
					this.OnbIMChanging(value);
					this.SendPropertyChanging();
					this._bIM = value;
					this.SendPropertyChanged("bIM");
					this.OnbIMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bIntelligentInput", DbType="Bit")]
		public System.Nullable<bool> bIntelligentInput
		{
			get
			{
				return this._bIntelligentInput;
			}
			set
			{
				if ((this._bIntelligentInput != value))
				{
					this.OnbIntelligentInputChanging(value);
					this.SendPropertyChanging();
					this._bIntelligentInput = value;
					this.SendPropertyChanged("bIntelligentInput");
					this.OnbIntelligentInputChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cESpaceID", DbType="NVarChar(50)")]
		public string cESpaceID
		{
			get
			{
				return this._cESpaceID;
			}
			set
			{
				if ((this._cESpaceID != value))
				{
					this.OncESpaceIDChanging(value);
					this.SendPropertyChanging();
					this._cESpaceID = value;
					this.SendPropertyChanged("cESpaceID");
					this.OncESpaceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UA_Account_UA_Account_sub", Storage="_UA_Account_sub", ThisKey="cAcc_Id", OtherKey="cAcc_Id")]
		public EntitySet<UA_Account_sub> UA_Account_sub
		{
			get
			{
				return this._UA_Account_sub;
			}
			set
			{
				this._UA_Account_sub.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UA_Account_sub(UA_Account_sub entity)
		{
			this.SendPropertyChanging();
			entity.UA_Account = this;
		}
		
		private void detach_UA_Account_sub(UA_Account_sub entity)
		{
			this.SendPropertyChanging();
			entity.UA_Account = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UA_Account_sub")]
	public partial class UA_Account_sub : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _cAcc_Id;
		
		private short _iYear;
		
		private string _cSub_Id;
		
		private bool _bIsDelete;
		
		private System.Nullable<bool> _bClosing;
		
		private System.Nullable<byte> _iModiPeri;
		
		private System.Nullable<System.DateTime> _dSubSysUsed;
		
		private string _cUser_Id;
		
		private System.Nullable<System.DateTime> _dSubOriDate;
		
		private EntityRef<UA_Account> _UA_Account;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OncAcc_IdChanging(string value);
    partial void OncAcc_IdChanged();
    partial void OniYearChanging(short value);
    partial void OniYearChanged();
    partial void OncSub_IdChanging(string value);
    partial void OncSub_IdChanged();
    partial void OnbIsDeleteChanging(bool value);
    partial void OnbIsDeleteChanged();
    partial void OnbClosingChanging(System.Nullable<bool> value);
    partial void OnbClosingChanged();
    partial void OniModiPeriChanging(System.Nullable<byte> value);
    partial void OniModiPeriChanged();
    partial void OndSubSysUsedChanging(System.Nullable<System.DateTime> value);
    partial void OndSubSysUsedChanged();
    partial void OncUser_IdChanging(string value);
    partial void OncUser_IdChanged();
    partial void OndSubOriDateChanging(System.Nullable<System.DateTime> value);
    partial void OndSubOriDateChanged();
    #endregion
		
		public UA_Account_sub()
		{
			this._UA_Account = default(EntityRef<UA_Account>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cAcc_Id", DbType="NVarChar(3) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string cAcc_Id
		{
			get
			{
				return this._cAcc_Id;
			}
			set
			{
				if ((this._cAcc_Id != value))
				{
					if (this._UA_Account.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncAcc_IdChanging(value);
					this.SendPropertyChanging();
					this._cAcc_Id = value;
					this.SendPropertyChanged("cAcc_Id");
					this.OncAcc_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iYear", DbType="SmallInt NOT NULL", IsPrimaryKey=true)]
		public short iYear
		{
			get
			{
				return this._iYear;
			}
			set
			{
				if ((this._iYear != value))
				{
					this.OniYearChanging(value);
					this.SendPropertyChanging();
					this._iYear = value;
					this.SendPropertyChanged("iYear");
					this.OniYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cSub_Id", DbType="NVarChar(2) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string cSub_Id
		{
			get
			{
				return this._cSub_Id;
			}
			set
			{
				if ((this._cSub_Id != value))
				{
					this.OncSub_IdChanging(value);
					this.SendPropertyChanging();
					this._cSub_Id = value;
					this.SendPropertyChanged("cSub_Id");
					this.OncSub_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bIsDelete", DbType="Bit NOT NULL")]
		public bool bIsDelete
		{
			get
			{
				return this._bIsDelete;
			}
			set
			{
				if ((this._bIsDelete != value))
				{
					this.OnbIsDeleteChanging(value);
					this.SendPropertyChanging();
					this._bIsDelete = value;
					this.SendPropertyChanged("bIsDelete");
					this.OnbIsDeleteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bClosing", DbType="Bit")]
		public System.Nullable<bool> bClosing
		{
			get
			{
				return this._bClosing;
			}
			set
			{
				if ((this._bClosing != value))
				{
					this.OnbClosingChanging(value);
					this.SendPropertyChanging();
					this._bClosing = value;
					this.SendPropertyChanged("bClosing");
					this.OnbClosingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iModiPeri", DbType="TinyInt")]
		public System.Nullable<byte> iModiPeri
		{
			get
			{
				return this._iModiPeri;
			}
			set
			{
				if ((this._iModiPeri != value))
				{
					this.OniModiPeriChanging(value);
					this.SendPropertyChanging();
					this._iModiPeri = value;
					this.SendPropertyChanged("iModiPeri");
					this.OniModiPeriChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dSubSysUsed", DbType="DateTime")]
		public System.Nullable<System.DateTime> dSubSysUsed
		{
			get
			{
				return this._dSubSysUsed;
			}
			set
			{
				if ((this._dSubSysUsed != value))
				{
					this.OndSubSysUsedChanging(value);
					this.SendPropertyChanging();
					this._dSubSysUsed = value;
					this.SendPropertyChanged("dSubSysUsed");
					this.OndSubSysUsedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cUser_Id", DbType="NVarChar(20)")]
		public string cUser_Id
		{
			get
			{
				return this._cUser_Id;
			}
			set
			{
				if ((this._cUser_Id != value))
				{
					this.OncUser_IdChanging(value);
					this.SendPropertyChanging();
					this._cUser_Id = value;
					this.SendPropertyChanged("cUser_Id");
					this.OncUser_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dSubOriDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> dSubOriDate
		{
			get
			{
				return this._dSubOriDate;
			}
			set
			{
				if ((this._dSubOriDate != value))
				{
					this.OndSubOriDateChanging(value);
					this.SendPropertyChanging();
					this._dSubOriDate = value;
					this.SendPropertyChanged("dSubOriDate");
					this.OndSubOriDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UA_Account_UA_Account_sub", Storage="_UA_Account", ThisKey="cAcc_Id", OtherKey="cAcc_Id", IsForeignKey=true)]
		public UA_Account UA_Account
		{
			get
			{
				return this._UA_Account.Entity;
			}
			set
			{
				UA_Account previousValue = this._UA_Account.Entity;
				if (((previousValue != value) 
							|| (this._UA_Account.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._UA_Account.Entity = null;
						previousValue.UA_Account_sub.Remove(this);
					}
					this._UA_Account.Entity = value;
					if ((value != null))
					{
						value.UA_Account_sub.Add(this);
						this._cAcc_Id = value.cAcc_Id;
					}
					else
					{
						this._cAcc_Id = default(string);
					}
					this.SendPropertyChanged("UA_Account");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UA_AccountDatabase")]
	public partial class UA_AccountDatabase : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _cAcc_Id;
		
		private short _iBeginYear;
		
		private System.Nullable<short> _iEndYear;
		
		private string _cDatabase;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OncAcc_IdChanging(string value);
    partial void OncAcc_IdChanged();
    partial void OniBeginYearChanging(short value);
    partial void OniBeginYearChanged();
    partial void OniEndYearChanging(System.Nullable<short> value);
    partial void OniEndYearChanged();
    partial void OncDatabaseChanging(string value);
    partial void OncDatabaseChanged();
    #endregion
		
		public UA_AccountDatabase()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cAcc_Id", DbType="NVarChar(3) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string cAcc_Id
		{
			get
			{
				return this._cAcc_Id;
			}
			set
			{
				if ((this._cAcc_Id != value))
				{
					this.OncAcc_IdChanging(value);
					this.SendPropertyChanging();
					this._cAcc_Id = value;
					this.SendPropertyChanged("cAcc_Id");
					this.OncAcc_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iBeginYear", DbType="SmallInt NOT NULL", IsPrimaryKey=true)]
		public short iBeginYear
		{
			get
			{
				return this._iBeginYear;
			}
			set
			{
				if ((this._iBeginYear != value))
				{
					this.OniBeginYearChanging(value);
					this.SendPropertyChanging();
					this._iBeginYear = value;
					this.SendPropertyChanged("iBeginYear");
					this.OniBeginYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iEndYear", DbType="SmallInt")]
		public System.Nullable<short> iEndYear
		{
			get
			{
				return this._iEndYear;
			}
			set
			{
				if ((this._iEndYear != value))
				{
					this.OniEndYearChanging(value);
					this.SendPropertyChanging();
					this._iEndYear = value;
					this.SendPropertyChanged("iEndYear");
					this.OniEndYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cDatabase", DbType="NVarChar(128) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string cDatabase
		{
			get
			{
				return this._cDatabase;
			}
			set
			{
				if ((this._cDatabase != value))
				{
					this.OncDatabaseChanging(value);
					this.SendPropertyChanging();
					this._cDatabase = value;
					this.SendPropertyChanged("cDatabase");
					this.OncDatabaseChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
