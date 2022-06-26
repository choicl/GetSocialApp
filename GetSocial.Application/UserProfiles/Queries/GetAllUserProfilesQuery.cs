﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace GetSocial.Application.UserProfiles.Queries
{
    public class GetAllUserProfilesQuery : IRequest<IEnumerable<UserProfile>>
    {
        
    }
}
