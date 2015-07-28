using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using CodemashApp.Models;

namespace CodemashApp.Repository
{
    public class SpeakerRepository : WebRepository<Speaker>
    {
        public SpeakerRepository(Uri url) : base(url) { }

        public override IEnumerable<Speaker> GetRecords(string data)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<Speaker>>(data);
        }

        public override Speaker GetRecord(string data)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<Speaker>(data);
        }

    }
}