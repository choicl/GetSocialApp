using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetSocial.Application.UserProfiles.Queries;
using GetSocial.DAL;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GetSocial.Application.UserProfiles.Handlers.QueriesHandlers
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, IEnumerable<UserProfile>>
    {
        private readonly DataContext _dataContext;

        public GetAllUserProfilesQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfilesQuery request, 
            CancellationToken cancellationToken)
        {
            return await _dataContext.UserProfiles.ToListAsync();
        }
    }
}
