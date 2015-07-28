using System;
using CodemashApp.Interfaces;

namespace CodemashApp.ViewModel
{
    public class BaseViewModel : IBaseViewModel
    {
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public Uri Url { get; set; }
    }
}