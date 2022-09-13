using System.Collections.Generic;
using MediatR;

namespace Satisfaction.Application.Queries.ContactTypes
{
    public class ContactTypeQuery : IRequest<List<ContactTypeInfo>>
    {

    }
}