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
	#region 接口 IAnalysisModuleTreeService 

	/// <summary>
	/// 统计分析树 service
	/// </summary>
    [Generated]
    [Version("1.0.0.0")]
    [Business("GTP.Services.Analysis.AnalysisModuleTree", MetadataRuntimeType.Interface)]
    public interface IAnalysisModuleTreeService : GTP.Runtime.Biz.Service.Tree.ITreeService<AnalysisModuleTree>
    {
    }

	#endregion 接口结束

	#region  抽象类 AbstractAnalysisModuleTreeService

	/// <summary>
	/// 统计分析树 service
	/// </summary>
    [Generated]
    [Version("1.0.0.0")]
	public abstract class AbstractAnalysisModuleTreeService : GTP.Runtime.Biz.Service.Tree.TreeService<AnalysisModuleTree>, IAnalysisModuleTreeService
    {
        protected const string METADATA_NAME = "GTP.Services.Analysis.AnalysisModuleTree";
		
		protected AbstractAnalysisModuleTreeService(string entityName)
			: base(entityName)
		{
		}

		#region 实现接口 IAnalysisModuleTreeService 成员

		#endregion 实现接口结束

		#region 抽象方法 AbstractClassName 成员
    
		#endregion 抽象方法结束
	}

	#endregion 抽象类结束

	/// <summary>
	/// 统计分析树 service
	/// </summary>
	[Business("GTP.Services.Analysis.AnalysisModuleTree", MetadataRuntimeType.Service)]
	public partial class AnalysisModuleTreeService : AbstractAnalysisModuleTreeService
    {
		/// <summary>
        /// 构造方法
        /// </summary>
		protected AnalysisModuleTreeService()
            : base(METADATA_NAME)
        {
        }

		/// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="entityName"></param>
        protected AnalysisModuleTreeService(string entityName)
            : base(entityName)
        {
        }
    }
}
