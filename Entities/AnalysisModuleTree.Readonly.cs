
/****************************************************
 * 
 * 广联达软件股份有限责任公司版权所有.
 * 
 *****************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GTP.Runtime.Biz.Service;
using GTP.Runtime.Core.Loaders;
using GTP.Runtime.DataObject;
using GTP.Runtime.DataObject.Entity;
using GTP.Runtime.DataObject.Entity.Collections;
using GTP.Runtime.DataObject.Extensions;

namespace GTP.Services.Analysis.Entities
{
	/// <summary>
	/// 统计分析树
	/// </summary>
	[Serializable]
	[Generated]
    [Version("1.0.0.0")]
    [Business("GTP.Services.Analysis.AnalysisModuleTree", MetadataRuntimeType.Entity)]
	public partial class AnalysisModuleTree : GTP.Runtime.DataObject.Entity.BaseTree
	{
		public new const string METADATA_NAME = "GTP.Services.Analysis.AnalysisModuleTree";

		public AnalysisModuleTree(string typeName)
			: base(typeName)
		{
		}

		public AnalysisModuleTree()
			: base(METADATA_NAME)
		{
		}

		protected AnalysisModuleTree(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
		public new LongKey EntityKey
        {
            get
            {
                LongKey k = new LongKey(this.GetTypeName());
                k.Value = this.ID;
                return k;
            }
        }
	}
}