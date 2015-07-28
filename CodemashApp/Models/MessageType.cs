using System.ComponentModel;

namespace CodemashApp.Models
{
    public enum MessageType
    {
        [Description("Information")]
        Information,
        [Description("Warning")]
        Warning,
        [Description("Error")]
        Error,
        [Description("Success")]
        Success
    }
}