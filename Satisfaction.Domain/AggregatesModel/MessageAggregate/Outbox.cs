using System;
using System.Collections.Generic;
using System.Text;
using static Satisfaction.Domain.Enumerations.Enumeration;

namespace Satisfaction.Domain.AggregatesModel.MessageAggregate
{
   
    public class Outbox
    {
        public int OutboxId { get; set; }
        public int ActId { get; set; }
        public SendType SendType { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public bool IsSent { get; set; }
    }
}
