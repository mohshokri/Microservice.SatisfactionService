using System.Collections.Generic;

namespace Satisfaction.Domain.AggregatesModel.PartyAggregate
{
    public class PartyRoles
    {

        public List<RoleType> Roles { get; set; }

        public void ASignRole(RoleType role)
        {

        }

    }
}