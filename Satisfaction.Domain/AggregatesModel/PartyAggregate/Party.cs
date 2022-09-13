using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.PartyAggregate
{
    public class Party : Entity, IAggregateRoot
    {
        public Party()
        {
                
        }
        public int PartyId { get; set; }
        public string PartyCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int FranchiseId { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }

        public List<RoleType> Roles { get; set; }
        //در صورت تعریف کلاس
        //PartyRoles
        //از این استفاده میکنیم
        //public PartyRoles PartyRoles { get; set; }

        public Franchise Franchise { get; set; }
        public List<SurveyAssignment> SurveyAssignments { get; set; }
    }
}
