using System;
using System.Collections.Generic;
using System.Text;
using static Satisfaction.Domain.Enumerations.Enumeration;

namespace Satisfaction.Domain.AggregatesModel.SMSAggregate
{
    public class SendMessage
    {
        public int SendMessageId { get; set; }
        public int MessageTemplateId { get; set; }
        public int ActId { get; set; }
        public string CustomizedTextMessage { get; set; }
        public SendType SendType { get; set; }

        public List<MessageTemplate> MessageTemplates { get; set; }
    }
}
