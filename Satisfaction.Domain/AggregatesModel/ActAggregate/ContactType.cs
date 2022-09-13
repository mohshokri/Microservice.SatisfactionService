using Ardalis.SmartEnum;

namespace Satisfaction.Domain.AggregatesModel.ActAggregate
{
    public class ContactType:SmartEnum<ContactType>
    {
        public ContactType() : base(" ", -1)
        {

        }
        public ContactType(string name, int value) : base(name, value)
        {

        }
        public static readonly ContactType Email = new ContactType("ایمیل", 1);
        public static readonly ContactType Mobile = new ContactType("تلفن", 2);
    }
}