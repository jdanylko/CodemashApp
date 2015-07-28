using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using CodemashApp.Interfaces;

namespace CodemashApp.Repository
{
    public class WebRepository<T>: IWebRepository<T> where T: class
    {
        public Uri Uri { get; set; }
        
        public WebRepository(Uri url)
        {
            Uri = url;
        }

        public virtual IEnumerable<T> GetRecords(string data)
        {
            return null;
        }

        public virtual T GetRecord(string data)
        {
            return null;
        }

        private string GetData(Uri uri, string headerType = "xml")
        {
            using (var web = new WebClient())
            {
                web.Encoding = Encoding.UTF8;
                web.Headers["Content-Type"] = headerType;
                return web.DownloadString(uri);
            }
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return null;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var data = GetData(Uri, "json");
            return GetRecords(data);
        }

        public T GetById(string id)
        {
            var newUri = new Uri(Uri+"/"+id);
            var data = GetData(newUri);
            return GetRecord(data);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
        }
    }
}