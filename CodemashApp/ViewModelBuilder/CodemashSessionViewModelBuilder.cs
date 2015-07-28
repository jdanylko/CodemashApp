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
    public class CodemashSessionViewModelBuilder : BaseViewModelBuilder, 
        IViewModelBuilder<CodemashController, CodemashSessionViewModel, string>
    {
        public CodemashSessionViewModel Build(CodemashController controller, 
            CodemashSessionViewModel viewModel, string day)
        {
            viewModel.MetaKeywords = "Codemash v2.0.1.5 Sessions";

            var codemashUnitOfWork = new CodemashUnitOfWork();
            var records = codemashUnitOfWork.SessionRepository.GetAll();

            if (String.IsNullOrEmpty(day))
            {
                viewModel.SessionItems = records
                    .Where(e => e.SessionType != "CodeMash Schedule Item");
                viewModel.ScheduleItems = records
                    .Where(e => e.SessionType == "CodeMash Schedule Item");
                
                viewModel.Title = "Sessions";
            }
            else
            {
                // day variable should read "Day1" or "Day2", etc.
                var removeDay = day.ToLower().Replace("day", String.Empty);
                var dayNumber = Int32.Parse(removeDay);

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
                var dateList = GetAllDates(startDate, stopDate);
                var date = dateList.ToList()[dayNumber - 1];

                viewModel.Title = String.Format("Sessions on Day {0} - {1}", 
                    dayNumber, date.ToShortDateString());

                viewModel.SessionItems = records
                    .Where(e =>
                        e.SessionType != "CodeMash Schedule Item" &&
                        e.SessionStartTime.Date.ToShortDateString() == date.ToShortDateString());
                viewModel.ScheduleItems = records
                    .Where(e =>
                        e.SessionType == "CodeMash Schedule Item" &&
                        e.SessionStartTime.Date.ToShortDateString() == date.ToShortDateString());

                viewModel.Sessions = codemashUnitOfWork.SessionRepository
                    .GetAll()
                    .Where(e => e.SessionStartTime.Date.ToShortDateString() == date.ToShortDateString());
            }

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