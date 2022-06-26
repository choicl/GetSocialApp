using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GetSocial.Application.UserProfiles.Commands;
using GetSocial.DAL;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace GetSocial.Application.UserProfiles.Handlers.CommandsHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        private readonly DataContext _context;

        public CreateUserCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress,
                request.Phone, request.DateOfBirth, request.City);

            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            return userProfile;
        }
    }
}
