using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GetSocial.Application.UserProfiles.Commands
{
    public class DeleteUserProfileCommand : IRequest
    {
        public Guid UserProfileId { get; set; }
    }
}
