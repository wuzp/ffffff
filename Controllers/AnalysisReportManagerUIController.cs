using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GTP.Runtime.Biz.Query;
using GTP.Runtime.Biz.Service;
using GTP.Runtime.Core.Loaders;
using GTP.Runtime.DataService;
using GTP.Runtime.WebUI.Controllers;
using GTP.Runtime.WebUI.Direct;
using GTP.Services.Analysis.Biz.Utils;
using GTP.Services.Analysis.Entities;
using GTP.Services.Analysis.Services;
using GTP.Services.Common.Entities;
using GTP.Services.Common.Services;

namespace GTP.Services.Analysis.Controllers
{
    public partial class AnalysisReportManagerUIController
    {
        [UIAction]
        public IList<ModuleTree> GetGridByNoduleName(string name)
        {
            IList<GTP.Services.Common.Entities.ModuleTree> list = new List<ModuleTree>();
            var svc = ServiceFactory.GetService<IModuleTreeService>();
            list = svc.GetNodesByFilter(Filter.Like(GTP.Services.Common.Entities.ModuleTree.P_Name, name, null, MatchMode.Like));
            var svcAnalysis = ServiceFactory.GetService<IAnalysisModuleTreeService>();
            foreach (var item in svcAnalysis.GetNodesByFilter(Filter.Like(AnalysisModuleTree.P_Name, name, null, MatchMode.Like)))
            {
                ModuleTree info = new ModuleTree();
                info.ID = item.ID;
                info.Name = item.Name;
                info.PID = item.PID;
                info.FullCode = item.FullCode;
                info.IsLeaf = item.IsLeaf;
                info.Tag = "Analy";
                list.Add(info);
            }
            return FilterModuleList(list);
        }
        [UIAction]
        public IList<ModuleTree> GetRootMoudleTreeNodes()
        {
            IList<GTP.Services.Common.Entities.ModuleTree> list = new List<ModuleTree>();
            var svc = ServiceFactory.GetService<IModuleTreeService>();
            list = svc.GetNodesFromRoot(1, null);
            var svcAnalysis = ServiceFactory.GetService<IAnalysisModuleTreeService>();
            foreach (var item in svcAnalysis.GetNodesFromRoot(1, null))
            {
                ModuleTree info = new ModuleTree();
                info.ID = item.ID;
                info.Name = item.Name;
                info.PID = item.PID;
                info.FullCode = item.FullCode;
                info.IsLeaf = item.IsLeaf;
                info.Tag = "Analy";
                list.Add(info);
            }
            return FilterModuleList(list);
        }
        [UIAction]
        public IList<ModuleTree> GetMoudleTreeChildNodes(long pid, string tag)
        {
            IList<GTP.Services.Common.Entities.ModuleTree> list = new List<ModuleTree>();
            var svcAnalysis = ServiceFactory.GetService<IAnalysisModuleTreeService>();
            if (tag == "Analy")
            {

                foreach (var item in svcAnalysis.GetNodesByPid(pid))
                {
                    ModuleTree info = new ModuleTree();
                    info.ID = item.ID;
                    info.Name = item.Name;
                    info.PID = item.PID;
                    info.FullCode = item.FullCode;
                    info.IsLeaf = item.IsLeaf;
                    info.Tag = "Analy";
                    list.Add(info);
                }
            }
            else
            {
                var svc = ServiceFactory.GetService<IModuleTreeService>();
                list = svc.GetNodesByPid(pid);
                foreach (var item in svcAnalysis.GetNodesByPid(pid))
                {
                    ModuleTree info = new ModuleTree();
                    info.ID = item.ID;
                    info.Name = item.Name;
                    info.PID = item.PID;
                    info.FullCode = item.FullCode;
                    info.IsLeaf = item.IsLeaf;
                    info.Tag = "Analy";
                    list.Add(info);
                }
            }
            return FilterModuleList(list);
        }
        [UIAction]
        public IList<AnalysisReport> GetReportList(string fullCode, string reportName)
        {
            var svc = ServiceFactory.GetService<IAnalysisReportService>();
            Criteria _criteria = new Criteria();
            Filter filter = Filter.Like(AnalysisReport.P_ModuleFullCode, fullCode + ".", null, MatchMode.LeftLike) | Filter.Equal(AnalysisReport.P_ModuleFullCode, fullCode);
            if (!string.IsNullOrEmpty(reportName))
            {
                filter = filter & Filter.Like(AnalysisReport.P_Name, reportName, null, MatchMode.Like);
            }
            _criteria.SetFilter(filter);
            var list = svc.GetEntityList(_criteria);
            return list;
        }
        [UIAction]
        public IList<WorkflowCb> GetWorkflowProcessList(string moduleCode)
        {
            string gsql = string.Format(@"SELECT P.F_PROCESS_CODE, P.F_PROCESS_NAME_ZH_CN FROM T_WF_PROCESS P, (SELECT DISTINCT F_PROCESS_CODE FROM T_WF_TASK) T WHERE P.F_PROCESS_CODE=T.F_PROCESS_CODE and p.F_MODULE_FCODE=:moduleCode");
            IList<WorkflowCb> list = new List<WorkflowCb>();
            DataSet ds = GSqlDataAccess.SelectDataSet("default", gsql, new DataParameter() { ParameterName = ":moduleCode", Value = moduleCode });
            var rows = ds.Tables[0].Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                DataRow dr = rows[i];
                list.Add(new WorkflowCb() { ProcessCode = dr["F_PROCESS_CODE"].ToString(), ProcessName = dr["F_PROCESS_NAME_ZH_CN"].ToString() });
            }
            return list;
        }

        /// <summary>
        /// 过滤模块树
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        IList<ModuleTree> FilterModuleList(IList<ModuleTree> items)
        {
            List<string> codes = GetModuleCode();
            IList<ModuleTree> list = new List<ModuleTree>();
            foreach (var item in items)
            {
                if (codes.Any(p => p.StartsWith(item.FullCode)))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取数据库已存在记录的模块编码集合
        /// </summary>
        /// <returns></returns>
        private List<string> GetModuleCode()
        {
            var svc = ServiceFactory.GetService<IAnalysisReportService>();
            var list = svc.GetEntityList(null);
            return (from p in list
                    select p.ModuleFullCode).Distinct().ToList();
        }
    }
}

