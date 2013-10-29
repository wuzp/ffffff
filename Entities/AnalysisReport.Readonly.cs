
/****************************************************
 * 
 * 广联达软件股份有限责任公司版权所有.
 * 
 *****************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GTP.Org.Entities;
using GTP.Runtime.Biz.Service;
using GTP.Runtime.Core.Loaders;
using GTP.Runtime.DataObject;
using GTP.Runtime.DataObject.Entity;
using GTP.Runtime.DataObject.Entity.Collections;
using GTP.Runtime.DataObject.Extensions;

namespace GTP.Services.Analysis.Entities
{
	/// <summary>
	/// 分析报表
	/// </summary>
	[Serializable]
	[Generated]
    [Version("1.0.0.0")]
    [Business("GTP.Services.Analysis.AnalysisReport", MetadataRuntimeType.Entity)]
	public partial class AnalysisReport : BaseEntity
	{
		public const string P_Id = "Id";
		public const string P_Name = "Name";
		public const string P_ReportUrl = "ReportUrl";
		public const string P_ModuleFullCode = "ModuleFullCode";
		public const string P_User = "User";
		public const string P_CreateTime = "CreateTime";
		public const string P_PublishDept = "PublishDept";
		public new const string METADATA_NAME = "GTP.Services.Analysis.AnalysisReport";

		public AnalysisReport(string typeName)
			: base(typeName)
		{
		}

		public AnalysisReport()
			: base(METADATA_NAME)
		{
		}

		protected AnalysisReport(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
		public new LongKey EntityKey
        {
            get
            {
                LongKey k = new LongKey(this.GetTypeName());
                k.Value = this.Id;
                return k;
            }
        }

		/// <summary>
		/// </summary>
		public Int64 Id
		{
			get{ return this.GetLong(P_Id);}
			set{ this.SetLong(P_Id, value); }
		}

		/// <summary>
		/// </summary>
		public String Name
		{
			get{ return this.GetString(P_Name);}
			set{ this.SetString(P_Name, value); }
		}

		/// <summary>
		/// </summary>
		public String ReportUrl
		{
			get{ return this.GetString(P_ReportUrl);}
			set{ this.SetString(P_ReportUrl, value); }
		}

		/// <summary>
		/// </summary>
		public String ModuleFullCode
		{
			get{ return this.GetString(P_ModuleFullCode);}
			set{ this.SetString(P_ModuleFullCode, value); }
		}

		/// <summary>
		/// 用户
		/// </summary>
		public User User
		{
			get{ return (User)this.GetEntity(P_User);}
			set{ this.SetEntity(P_User, value); }
		}

		/// <summary>
		/// </summary>
		public DateTime CreateTime
		{
			get{ return this.GetDateTime(P_CreateTime);}
			set{ this.SetDateTime(P_CreateTime, value); }
		}

		/// <summary>
		/// 部门
		/// </summary>
		public Dept PublishDept
		{
			get{ return (Dept)this.GetEntity(P_PublishDept);}
			set{ this.SetEntity(P_PublishDept, value); }
		}
	}
}