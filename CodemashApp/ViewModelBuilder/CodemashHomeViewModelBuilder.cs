using System;
using CodemashApp.Controllers;
using CodemashApp.Interfaces;
using CodemashApp.ViewModel;

namespace CodemashApp.ViewModelBuilder
{
    public class CodemashHomeViewModelBuilder : BaseViewModelBuilder, IViewModelBuilder<CodemashController, CodemashHomeViewModel>
    {
        public CodemashHomeViewModel Build(CodemashController controller, CodemashHomeViewModel viewModel)
        {
            viewModel.Title = "Codemash v2.0.1.5";
            viewModel.MetaKeywords = "Codemash v2.0.1.5 Agenda";

            return viewModel;
        }
    }
}