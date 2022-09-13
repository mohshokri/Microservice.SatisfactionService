using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.PartyAggregate
{
    public class RoleType : SmartEnum<RoleType>
    {
        public RoleType():base(" ",-1)
        {
                
        }

        public RoleType(string name, int value) : base(name, value)
        {

        }

        public static readonly RoleType CrmSupervisor = new RoleType("CRM رئیس", 1);
        public static readonly RoleType CrmManager = new RoleType("CRM مدیر", 2);
        public static readonly RoleType Expert = new RoleType("کارشناس", 3);
        public static readonly RoleType FranchiseManager = new RoleType("مدیر نمایندگی", 4);
        public static readonly RoleType FranchiseExpert = new RoleType("کارشناس نمایندگی", 5);
    }
}

