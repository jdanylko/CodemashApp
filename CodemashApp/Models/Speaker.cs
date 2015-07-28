using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodemashApp.Models
{
    public class Speaker
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string GravatarUrl { get; set; }
        public string TwitterLink { get; set; }
        public string GitHubLink { get; set; }
        public string LinkedInProfile { get; set; }
        public string BlogUrl { get; set; }

        [JsonIgnore]
        public List<Session> Sessions { get; set; }
    }
}