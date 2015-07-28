using System.Web.Mvc;

namespace CodemashApp.Helpers.Url
{
    public static class UrlHelpers
    {
        public static string AllSessionsUrl(this UrlHelper helper)
        {
            return helper.RouteUrl("Default",
                new { @controller = "Codemash", @action = "sessions", @id = UrlParameter.Optional });
        }

        public static string AllSpeakersUrl(this UrlHelper helper)
        {
            return helper.RouteUrl("Default",
                new { @controller = "Codemash", @action = "Speakers", @id = UrlParameter.Optional });
        }
        
        public static string SpeakerDetailUrl(this UrlHelper helper, string speakerId)
        {
            return helper.RouteUrl("Default",
                new { @controller = "Codemash", @action = "SpeakerDetail", @id = speakerId });
        }

        public static string SessionsByDayUrl(this UrlHelper helper, string id)
        {
            return helper.RouteUrl("Default",
                new { @controller = "Codemash", @action = "Sessions", id });
        }

        public static string SessionDetailUrl(this UrlHelper helper, int sessionId)
        {
            return helper.RouteUrl("Default",
                new { @controller = "Codemash", @action = "SessionDetail", @id=sessionId });
        }
        
        public static string AgendaUrl(this UrlHelper helper)
        {
            return helper.RouteUrl("Default",
                new { @controller = "Codemash", @action = "Agenda", @id = UrlParameter.Optional });
        }
    }
}