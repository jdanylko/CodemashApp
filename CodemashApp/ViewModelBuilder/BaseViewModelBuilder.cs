using System.Web.Mvc;

namespace CodemashApp.ViewModelBuilder
{
    public abstract class BaseViewModelBuilder
    {
        protected virtual void UpdateModel(Controller controller) { }
    }
}