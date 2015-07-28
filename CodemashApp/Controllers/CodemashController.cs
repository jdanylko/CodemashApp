using System;
using System.Web.Mvc;
using CodemashApp.ViewModel;
using CodemashApp.ViewModelBuilder;

namespace CodemashApp.Controllers
{
    public class CodemashController : Controller
    {
        private DefaultViewModelFactory _factory = new DefaultViewModelFactory();

        public ActionResult Index()
        {
            return View(_factory.GetViewModel<CodemashController, CodemashHomeViewModel>(this));
        }

        public ActionResult Speakers()
        {
            return View(_factory.GetViewModel<CodemashController, CodemashSpeakerViewModel>(this));
        }

        public PartialViewResult SpeakerDetail(string id)
        {
            var speakerId = id;
            return PartialView("_partialSpeaker",
                _factory.GetViewModel<CodemashController, SpeakerDetailViewModel, string>(this, speakerId));
        }

        public ActionResult Sessions(string id)
        {
            return View(_factory.GetViewModel<CodemashController, CodemashSessionViewModel, string>(this, id));
        }
        
        public PartialViewResult SessionDetail(string id)
        {
            var sessionId = Int32.Parse(id);
            return PartialView("_partialSession", 
                _factory.GetViewModel<CodemashController, SessionDetailViewModel, int>(this, sessionId));
        }

        public ActionResult Agenda()
        {
            return View(_factory.GetViewModel<CodemashController, CodemashAgendaViewModel>(this));
        }
    }
}