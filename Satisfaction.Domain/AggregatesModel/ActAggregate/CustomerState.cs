using Ardalis.SmartEnum;

namespace Satisfaction.Domain.AggregatesModel.ActAggregate
{
    public class CustomerState: SmartEnum<CustomerState>
    {
        public CustomerState() : base(" ", -1)
        {

        }
        public CustomerState(string name, int value) : base(name, value)
        {

        }
        public static readonly CustomerState Respondent = new CustomerState("پاسخگو به نظرسنجی", 1);
        public static readonly CustomerState Dissatisfied = new CustomerState("ناراضی", 2);
        public static readonly CustomerState Rescheduled = new CustomerState("دارای هشدار", 3);
        public static readonly CustomerState Pending = new CustomerState("بلاتکلیف", 4);
    }
}