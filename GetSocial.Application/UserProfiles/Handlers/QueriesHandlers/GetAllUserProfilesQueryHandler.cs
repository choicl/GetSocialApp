using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetSocial.Application.ResultsModel;
using GetSocial.Application.UserProfiles.Queries;
using GetSocial.DAL;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GetSocial.Application.UserProfiles.Handlers.QueriesHandlers
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, 
        OperationResults<IEnumerable<UserProfile>>>
    {
        private readonly DataContext _dataContext;

        public GetAllUserProfilesQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<OperationResults<IEnumerable<UserProfile>>> Handle(GetAllUserProfilesQuery request, 
            CancellationToken cancellationToken)
        {
            var result = new OperationResults<IEnumerable<UserProfile>>();
            result.Payload = await _dataContext.UserProfiles.ToListAsync();
            return result;
        }
    }
}
