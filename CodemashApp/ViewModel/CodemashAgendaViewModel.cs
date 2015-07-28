using System;
using System.Collections.Generic;
using System.Linq;
using CodemashApp.Models;

namespace CodemashApp.ViewModel
{
    public class CodemashAgendaViewModel: CodemashBaseViewModel
    {
        public IEnumerable<DateTime> Dates { get; set; }
        public IEnumerable<IGrouping<DateTime, Session>> GroupedSessions { get; set; }
    }
}