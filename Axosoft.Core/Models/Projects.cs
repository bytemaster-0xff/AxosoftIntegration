using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Models
{
    public class ProjectsResponse
    {
        [JsonProperty("data")]
        public List<ProjectPortfolio> ProjectPortfolios { get; set; }       
    }

    public class ProjectPortfolio
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("children")]
        public List<Project> Projects { get; set; }
    }

    public class Project
    {

        [JsonProperty("id")]
        public int Id {get; set;}


        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
