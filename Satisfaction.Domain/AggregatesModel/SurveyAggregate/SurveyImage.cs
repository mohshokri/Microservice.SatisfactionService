using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public class SurveyImage : ValueObject
    {
        private SurveyImage()
        {

        }
        public byte[] LogoAttachmentContent { get; private set; }
        public string LogoFileExtention { get; private set; }
        public SurveyImage(byte[] logoAttachmentContent, string logoFileExtention)
        {
            LogoAttachmentContent = logoAttachmentContent;
            LogoFileExtention = logoFileExtention;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
