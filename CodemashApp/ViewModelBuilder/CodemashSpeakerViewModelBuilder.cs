using System.Collections.Generic;
using System.Linq;
using CodemashApp.Controllers;
using CodemashApp.Interfaces;
using CodemashApp.Models;
using CodemashApp.UnitOfWork;
using CodemashApp.ViewModel;

namespace CodemashApp.ViewModelBuilder
{
    public class CodemashSpeakerViewModelBuilder : BaseViewModelBuilder, 
        IViewModelBuilder<CodemashController, CodemashSpeakerViewModel>
    {
        public CodemashSpeakerViewModel Build(CodemashController controller, 
            CodemashSpeakerViewModel viewModel)
        {
            var title = "Codemash v2.0.1.5 - Speakers";
            viewModel.Title = viewModel.MetaKeywords = title;

            var codemashUnitOfWork = new CodemashUnitOfWork();
            var sessions = codemashUnitOfWork.SessionRepository.GetAll();
                
            viewModel.Speakers = codemashUnitOfWork.SpeakerRepository.GetAll();
            foreach (var speaker in viewModel.Speakers)
            {
                speaker.Sessions = 
                    new List<Session>(sessions.Where(e => 
                        e.Speakers.Any(f => f.Id == speaker.Id)));
            }            

            return viewModel;
        }
    }

}