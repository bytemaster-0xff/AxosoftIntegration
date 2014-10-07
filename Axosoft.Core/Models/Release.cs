using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Models
{
    public class ReleasesResponse
    {
        [JsonProperty("data")]
        public List<Release> Releases { get; set; }
    }


    public class Release
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public int StatusId { get; set; }

        [JsonProperty("release_type")]
        public int ReleaseTypeId { get; set; }

        [JsonProperty("associated_projects")]
        public List<Project> Projects { get; set; }

        [JsonProperty("start_date")]
        public String StartDate { get; set; }

        [JsonProperty("end_date")]
        public String DueData { get; set; }

        [JsonProperty("is_active")]
        public String IsActive { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("release_notes")]
        public String ReleaseNotes { get; set; }

        [JsonProperty("children")]
        public List<Release> Releases { get; set; }

    }

}
