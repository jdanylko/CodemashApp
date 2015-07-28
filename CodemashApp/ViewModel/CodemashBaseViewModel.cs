using System.Collections.Generic;
using System.Linq;
using CodemashApp.Models;

namespace CodemashApp.ViewModel
{
    public class CodemashBaseViewModel
    {
        public string Title { get; set; }
        public string MetaKeywords { get; set; }

        public IEnumerable<Session> Sessions { get; set; }
        public Session Session { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
        public Speaker Speaker { get; set; }

        public IEnumerable<Session> SessionItems { get; set; }

        public IEnumerable<Session> ScheduleItems { get; set; }
    }
}