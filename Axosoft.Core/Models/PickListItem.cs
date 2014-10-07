using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axosoft.Core.Models
{
    public class PickListItemResponse
    {

        [JsonProperty("id")]
        public List<PickListItem> Items { get; set; }
    }

    public class PickListItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("color")]
        public int Color { get; set; }
    }
}
