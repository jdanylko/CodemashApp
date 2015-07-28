using System;

namespace CodemashApp.Interfaces
{
    public interface IBaseViewModel
    {
        string Title { get; set; }
        string MetaDescription { get; set; }
        string MetaKeywords { get; set; }
        Uri Url { get; set; }
    }
}