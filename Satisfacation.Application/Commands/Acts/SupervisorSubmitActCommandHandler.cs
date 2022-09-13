using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Satisfaction.Domain.AggregatesModel.ActAggregate;

namespace Satisfaction.Application.Commands.Acts
{
    public class SupervisorSubmitActCommandHandler : AsyncRequestHandler<SupervisorSubmitActCommand>
    {
        private readonly IActRepository _actRepository;

        public SupervisorSubmitActCommandHandler(IActRepository actRepository)
        {
            _actRepository = actRepository;
        }
        protected override async Task Handle(SupervisorSubmitActCommand request, CancellationToken cancellationToken)
        {
            var contactTypeId = ContactType.FromValue(request.ContactTypeId);
            var act = new Act(request.AssignedChassisId, request.IsSuccessCall, request.ActDate, request.AlarmDate, request.AlarmTime,
                request.AlarmDescription, request.CrmSupervisorDescription, contactTypeId, request.Creator);

            await _actRepository.AddAsync(act);
        }
    }
}