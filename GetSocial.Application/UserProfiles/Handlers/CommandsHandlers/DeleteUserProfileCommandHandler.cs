using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetSocial.Application.UserProfiles.Commands;
using GetSocial.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GetSocial.Application.UserProfiles.Handlers.CommandsHandlers
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand>
    {
        private readonly DataContext _dataContext;

        public DeleteUserProfileCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _dataContext.UserProfiles.FirstOrDefaultAsync(
                up => up.UserProfileId == request.UserProfileId);

            _dataContext.UserProfiles.Remove(userProfile);
            await _dataContext.SaveChangesAsync();

            return new Unit();
        }
    }
}
