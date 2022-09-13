using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SMSAggregate
{
    /// <summary>
    /// ایجاد متن آماده برای ارسال پیام
    /// </summary>
   public class MessageTemplate
    {
        public int MessageTemplateId { get; set; }
        public string TemplateTitle { get; set; }
        public string TemplateText { get; set; }
        public bool IsFix { get; set; }

        public SendMessage SendMessage { get; set; }
    }
}
