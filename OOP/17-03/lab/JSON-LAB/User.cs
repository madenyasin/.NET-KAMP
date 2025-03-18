using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_LAB
{
    internal class User
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }
        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }
        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }
        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }
        [Newtonsoft.Json.JsonProperty("avatar")]

        public string Avatar { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Email} {Avatar}";
        }
    }
}
