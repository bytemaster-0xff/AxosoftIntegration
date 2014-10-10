using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Models
{

    public class FeatureResponse
    {
        [JsonProperty("data")]
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("estimated_duration")]
        public Duration Estimated { get; set; }

        [JsonProperty("actual_duration")]
        public Duration Actual { get; set; }

        [JsonProperty("remaining_duration")]
        public Duration Remaining { get; set; }

        [JsonProperty("assigned_to")]
        public Person AssignedTo { get; set; }
      
        [JsonProperty("created_by")]
        public Person CreatedBy { get; set; }
        [JsonProperty("created_date_time")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }
        [JsonProperty("build_number")]
        public String BuildNumber { get; set; }

        [JsonProperty("last_updated_by")]
        public Person LastUpdatedBy { get; set; }

        [JsonProperty("last_updated_date_time")]
        public DateTime LastUpdatedDate { get; set; }

        [JsonProperty("status")]
        public PickListItem Status { get; set; }

        [JsonProperty("workflow_step")]
        public WorkflowStep WorkFlowStep { get; set; }

        [JsonProperty("release")]
        public Release Release { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("percent_complete")]
        public int PercentComplete { get; set; }
   
    }

    public class Duration
    {
        [JsonProperty("aggregate_duration_minutes")]
        public double AggregateMinutes { get; set; }
        [JsonProperty("duration_minutes")]
        public double Minutes { get; set; }

        [JsonProperty("duration_text")]
        public String Display { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}
