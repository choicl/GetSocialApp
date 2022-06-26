using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetSocial.Application.UserProfiles.Commands;
using GetSocial.DAL;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GetSocial.Application.UserProfiles.Handlers.CommandsHandlers
{
    public class UpdateUserProfileBasicInfoCommandHandler : IRequestHandler<UpdateUserProfileBasicInfoCommand>
    {
        private readonly DataContext _dataContext;

        public UpdateUserProfileBasicInfoCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Unit> Handle(UpdateUserProfileBasicInfoCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _dataContext.UserProfiles.FirstOrDefaultAsync(
                up => up.UserProfileId == request.UserProfileId);

            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress,
                request.Phone, request.DateOfBirth, request.City);

            userProfile.UpdateBasicInfo(basicInfo);

            _dataContext.UserProfiles.Update(userProfile);
            await _dataContext.SaveChangesAsync();

            return new Unit();
        }
    }
}
