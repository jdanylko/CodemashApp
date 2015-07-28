using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using CodemashApp.Models;

namespace CodemashApp.Repository
{
    public class SessionRepository : WebRepository<Session>
    {
        public SessionRepository(Uri url): base(url) { }

        public override IEnumerable<Session> GetRecords(string data)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<Session>>(data);
        }

        public override Session GetRecord(string data)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<Session>(data);
        }
    }
}