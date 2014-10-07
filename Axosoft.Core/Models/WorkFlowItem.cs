using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Models
{
    public class WorkFlowResponse
    {
        [JsonProperty("data")]
        public List<WorkFlow> WorkFlows { get; set; }
    }

    public class WorkFlow
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("item_type")]
        public string ItemType { get; set; }
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }
        [JsonProperty("workflow_steps")]
        public List<WorkflowStep> WorkFlowsteps { get; set; }
    }


    public class WorkflowStep
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("enable_wip_limits")]
        public bool EnableWipLimits { get; set; }
        [JsonProperty("wip_items_per_step")]
        public int WipItemsPerStep { get; set; }
        [JsonProperty("enforce_wip_limits")]
        public bool EnforceWipLimits { get; set; }
        [JsonProperty("enable_wip_limits_per_user")]
        public bool EnableWipLimitsPerUser { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("wip_items_per_user")]
        public int WipItemsPerUser { get; set; }
    }


    public class Metadata
    {
        public int defects_workflows_count { get; set; }
        public int features_workflows_count { get; set; }
        public int tasks_workflows_count { get; set; }
        public int incidents_workflows_count { get; set; }
    }

    
}
