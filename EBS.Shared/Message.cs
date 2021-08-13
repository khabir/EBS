using System;

namespace EBS.Shared
{
    public class Message
    {
        public Exception Exception { get; set; }

        public ExecutionStatus ExecutionStatus { get; set; }

        public MessageType MessageType { get; set; }

        public string Text { get; set; }
    }
}