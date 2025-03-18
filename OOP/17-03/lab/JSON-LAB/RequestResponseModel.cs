using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_LAB
{
    internal class RequestResponseModel
    {
        [Newtonsoft.Json.JsonProperty("page")]

        public int Page { get; set; }
        [Newtonsoft.Json.JsonProperty("per_page")]

        public int PerPage { get; set; }
        [Newtonsoft.Json.JsonProperty("total")]

        public int Total { get; set; }
        [Newtonsoft.Json.JsonProperty("total_pages")]

        public int TotalPages { get; set; }
        [Newtonsoft.Json.JsonProperty("data")]

        public List<User> Data { get; set; }
    }
}
