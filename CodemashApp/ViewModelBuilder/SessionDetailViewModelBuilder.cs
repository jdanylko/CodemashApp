using System.Linq;
using CodemashApp.Controllers;
using CodemashApp.Interfaces;
using CodemashApp.UnitOfWork;
using CodemashApp.ViewModel;

namespace CodemashApp.ViewModelBuilder
{
    public class SessionDetailViewModelBuilder : BaseViewModelBuilder, 
        IViewModelBuilder<CodemashController, SessionDetailViewModel, int>
    {
        public SessionDetailViewModel Build(CodemashController controller, 
            SessionDetailViewModel viewModel, int id)
        {
            var codemashUnitOfWork = new CodemashUnitOfWork();
            viewModel.Session = codemashUnitOfWork.SessionRepository
                .GetAll()
                .FirstOrDefault(e=> e.Id == id);

            viewModel.Title = viewModel.Session.Title;
            viewModel.MetaKeywords = viewModel.Session.Title;

            return viewModel;
        }
    }
}