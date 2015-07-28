using System;
using System.Collections.Generic;
using System.Web;
using CodemashApp.Models;

namespace CodemashApp.Repository
{
    public class CacheSessionRepository : SessionRepository
    {
        private static readonly object CacheLockObject = new object();

        public CacheSessionRepository(Uri url) : base(url) { }

        public override IEnumerable<Session> GetAll()
        {
            const string cacheKey = "CachedCodemashSessionRepository:GetAll";
            IEnumerable<Session> result = HttpRuntime.Cache[cacheKey] as List<Session>;
            if (result != null) return result;

            lock (CacheLockObject)
            {
                result = HttpRuntime.Cache[cacheKey] as List<Session>;
                if (result != null) return result;

                result = base.GetAll();
                HttpRuntime.Cache.Insert(cacheKey, result, null,
                    DateTime.Now.AddMinutes(15), TimeSpan.Zero);
            }
            return result;

        }
    }
}