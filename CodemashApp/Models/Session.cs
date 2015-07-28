using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodemashApp.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime SessionTime { get; set; }
        public DateTime SessionStartTime { get; set; }
        public DateTime SessionEndTime { get; set; }
        public object Room { get; set; }
        public List<string> Rooms { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string SessionType { get; set; }
        public List<string> Tags { get; set; }
        public List<SpeakerThinModel> Speakers { get; set; }

        [JsonIgnore]
        public string StartDate {
            get { return String.Format("{0:d}", SessionStartTime); } 
        }
        [JsonIgnore]
        public string StartTime {
            get { return String.Format("{0:h:mmtt}", SessionStartTime); }
        }
        public string EndTime
        {
            get { return String.Format("{0:h:mmtt}", SessionEndTime); }
        }

    }
}