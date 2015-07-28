using System;
using System.Collections.Generic;
using System.Linq;
using CodemashApp.Configuration;
using CodemashApp.Controllers;
using CodemashApp.Interfaces;
using CodemashApp.UnitOfWork;
using CodemashApp.ViewModel;

namespace CodemashApp.ViewModelBuilder
{
    public class CodemashAgendaViewModelBuilder : BaseViewModelBuilder, 
        IViewModelBuilder<CodemashController, CodemashAgendaViewModel>
    {
        public CodemashAgendaViewModel Build(CodemashController controller, 
            CodemashAgendaViewModel viewModel)
        {
            viewModel.MetaKeywords = "Codemash v2.0.1.5 Agenda";

            var codemashUnitOfWork = new CodemashUnitOfWork();
            var records = codemashUnitOfWork.SessionRepository.GetAll();

            var dates = CodemashConfiguration.ConferenceDates.Split('-');
            DateTime startDate;
            DateTime stopDate;
            if (!DateTime.TryParse(dates[0], out startDate))
            {
                throw new Exception("StartDate is not valid.");
            }
            if (!DateTime.TryParse(dates[1], out stopDate))
            {
                throw new Exception("StopDate is not valid.");
            }
            
            viewModel.Dates = GetAllDates(startDate, stopDate);
            viewModel.GroupedSessions = records
                .Where(e => e.SessionType != "CodeMash Schedule Item" 
                    && e.SessionType != "Kidz Mash")
                .OrderBy(e=> e.SessionStartTime)
                .GroupBy(e=> e.SessionStartTime);
            viewModel.SessionItems = records;

            return viewModel;
        }

        public IEnumerable<DateTime> GetAllDates(DateTime start, DateTime end)
        {
            var list = new List<DateTime>();
            var currLoopDate = start;
            while (currLoopDate <= end)
            {
                list.Add(currLoopDate);
                currLoopDate = currLoopDate.AddDays(1);
            }
            return list;
        }
    }
}