using System;

namespace CodemashApp.Models
{
    public class ViewMessage
    {
        public ViewMessage()
        {
            MsgType = MessageType.Information;
            MsgText = String.Empty;
            MsgTitle = String.Empty;
        }

        public ViewMessage(MessageType msgType, string msg, string title)
        {
            MsgType = msgType;
            MsgText = msg;
            MsgTitle = title;
        }

        public MessageType MsgType { get; set; }
        public string MsgText { get; set; }
        public string MsgTitle { get; set; }
    }
}