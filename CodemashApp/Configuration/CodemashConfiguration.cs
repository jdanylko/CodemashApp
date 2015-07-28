using System.Configuration;

namespace CodemashApp.Configuration
{
    public static class CodemashConfiguration
    {
        public static string SessionUrl { get { return ConfigurationManager.AppSettings["SessionAPI"]; } }
        public static string SpeakerUrl { get { return ConfigurationManager.AppSettings["SpeakerAPI"]; } }
        public static string ConferenceDates { get { return ConfigurationManager.AppSettings["Dates"]; } }

    }
}
