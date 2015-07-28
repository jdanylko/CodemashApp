using System;
using System.Collections.Generic;
using System.Web;
using CodemashApp.Models;

namespace CodemashApp.Repository
{
    public class CacheSpeakerRepository : SpeakerRepository
    {
        private static readonly object CacheLockObject = new object();

        public CacheSpeakerRepository(Uri url) : base(url) { }

        public override IEnumerable<Speaker> GetAll()
        {
            const string cacheKey = "CachedCodemashSpeakerRepository:GetAll";
            IEnumerable<Speaker> result = HttpRuntime.Cache[cacheKey] as List<Speaker>;
            if (result == null)
            {
                lock (CacheLockObject)
                {
                    result = HttpRuntime.Cache[cacheKey] as List<Speaker>;
                    if (result == null)
                    {
                        result = base.GetAll();
                        HttpRuntime.Cache.Insert(cacheKey, result, null,
                                                 DateTime.Now.AddMinutes(15), TimeSpan.Zero);
                    }
                }
            }
            return result;
        }
        
    }
}