using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace GetSocial.Application.UserProfiles.Queries
{
    public class GetUserProfileByIdQuery : IRequest<UserProfile>
    {
        public Guid UserProfileId { get; set; }
    }
}
