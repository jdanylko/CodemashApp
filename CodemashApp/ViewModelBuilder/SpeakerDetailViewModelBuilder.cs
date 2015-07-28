using System;
using System.Collections.Generic;
using System.Linq;
using CodemashApp.Controllers;
using CodemashApp.Interfaces;
using CodemashApp.Models;
using CodemashApp.UnitOfWork;
using CodemashApp.ViewModel;

namespace CodemashApp.ViewModelBuilder
{
    public class SpeakerDetailViewModelBuilder : BaseViewModelBuilder, 
        IViewModelBuilder<CodemashController, SpeakerDetailViewModel, string>
    {
        public SpeakerDetailViewModel Build(CodemashController controller, 
            SpeakerDetailViewModel viewModel, string id)
        {
            var codemashUnitOfWork = new CodemashUnitOfWork();
            var sessions = codemashUnitOfWork.SessionRepository.GetAll();
            viewModel.Speaker = codemashUnitOfWork.SpeakerRepository
                .GetAll()
                .FirstOrDefault(e=> e.Id == id);

            if (viewModel.Speaker != null)
            {
                viewModel.Speaker.Sessions = new List<Session>();
                var speakerSessions = sessions.Where(e => 
                    e.Speakers.Any(f => f.Id == id));
                if (speakerSessions.Any())
                {
                    viewModel.Speaker.Sessions.AddRange(speakerSessions);
                };
            }

            viewModel.Title = String.Format("CodeMash Speaker: {0} {1}", 
                viewModel.Speaker.FirstName, viewModel.Speaker.LastName);

            return viewModel;
        }
    }
}