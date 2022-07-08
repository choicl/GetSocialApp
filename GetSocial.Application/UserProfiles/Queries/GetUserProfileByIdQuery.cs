using GetSocial.Application.ResultsModel;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace GetSocial.Application.UserProfiles.Queries
{
    public class GetUserProfileByIdQuery : IRequest<OperationResults<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
    }
}
