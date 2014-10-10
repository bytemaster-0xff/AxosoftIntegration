using Axosoft.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Services
{
    public class WorkItemFilter
    {
        public Project Project { get; set; }

        public Release Release { get; set; }

        public PickListItem Status { get; set; }
        public WorkflowStep WorkFlowStep { get; set; }

        public Person AssignedTo { get; set; }

        public Person RequestedBy { get; set; }

        public String Filter
        {
            get
            {
                var bldr = new StringBuilder();
                if (Project != null) bldr.AppendFormat("&project_id={0}", Project.Id);
                if (Release != null) bldr.AppendFormat("&release_id={0}", Release.Id);
                if (Release != null) bldr.AppendFormat("&release_id={0}", Release.Id);

                return bldr.ToString();
            }
        }


    }


    public class WorkItems
    {
        private static WorkItems _instance = new WorkItems();

        public static WorkItems Instance { get { return _instance; } }

        public async Task<AxoServiceCallResponse<List<TaskItem>>> GetTasksAsync(int pageIdx, int pageSize)
        {
            var uriStr = new StringBuilder(String.Format("/tasks?page={0}&page_size={1}", pageIdx, pageSize));

            return await AxoService.Instance.Call<List<TaskItem>>(uriStr.ToString());
        }

        public async Task<AxoServiceCallResponse<FeatureResponse>> GetFeaturesAsync(int pageIdx, int pageSize)
        {
            var uriStr = new StringBuilder(String.Format("/features?page={0}&page_size={1}&assigned_to_type=user", pageIdx, pageSize));
            var response = await AxoService.Instance.Call<FeatureResponse>(uriStr.ToString());
            return response;
        }
    }
}
