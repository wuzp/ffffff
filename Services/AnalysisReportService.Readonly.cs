/****************************************************
 * 
 * 广联达软件股份有限责任公司版权所有.
 * 
 *****************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using GTP.Runtime.Biz.Event.Engine;
using GTP.Runtime.Biz.Query;
using GTP.Runtime.Biz.Service;
using GTP.Runtime.Core.Loaders;
using GTP.Runtime.DataObject;
using GTP.Runtime.Metadata.Common;
using GTP.Runtime.Metadata.Model.Event;
using GTP.Services.Analysis.Entities;

namespace GTP.Services.Analysis.Services
{
	#region 接口 IAnalysisReportService 

	/// <summary>
	/// 分析报表 service
	/// </summary>
    [Generated]
    [Version("1.0.0.0")]
    [Business("GTP.Services.Analysis.AnalysisReport", MetadataRuntimeType.Interface)]
    public interface IAnalysisReportService : IBaseEntityService<System.Int64, AnalysisReport>
    {
    }

	#endregion 接口结束

	#region  抽象类 AbstractAnalysisReportService

	/// <summary>
	/// 分析报表 service
	/// </summary>
    [Generated]
    [Version("1.0.0.0")]
	public abstract class AbstractAnalysisReportService : BaseEntityService<System.Int64, AnalysisReport>, IAnalysisReportService
    {
        protected const string METADATA_NAME = "GTP.Services.Analysis.AnalysisReport";
		
		protected AbstractAnalysisReportService(string entityName)
			: base(entityName)
		{
		}

		#region 实现接口 IAnalysisReportService 成员

		#endregion 实现接口结束

		#region 抽象方法 AbstractClassName 成员
    
		#endregion 抽象方法结束
	}

	#endregion 抽象类结束

	/// <summary>
	/// 分析报表 service
	/// </summary>
	[Business("GTP.Services.Analysis.AnalysisReport", MetadataRuntimeType.Service)]
	public partial class AnalysisReportService : AbstractAnalysisReportService
    {
		/// <summary>
        /// 构造方法
        /// </summary>
		protected AnalysisReportService()
            : base(METADATA_NAME)
        {
        }

		/// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="entityName"></param>
        protected AnalysisReportService(string entityName)
            : base(entityName)
        {
        }
    }
}
