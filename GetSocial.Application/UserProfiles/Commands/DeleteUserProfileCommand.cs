using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetSocial.Application.ResultsModel;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace GetSocial.Application.UserProfiles.Commands
{
    public class DeleteUserProfileCommand : IRequest<OperationResults<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
    }
}
