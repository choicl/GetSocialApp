using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetSocial.Application.Enums;
using GetSocial.Application.ResultsModel;
using GetSocial.Application.UserProfiles.Queries;
using GetSocial.DAL;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GetSocial.Application.UserProfiles.Handlers.QueriesHandlers
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, OperationResults<UserProfile>>
    {
        private readonly DataContext _dataContext;

        public GetUserProfileByIdQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<OperationResults<UserProfile>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResults<UserProfile>();
            var userProfile = await _dataContext.UserProfiles.FirstOrDefaultAsync
                (up => up.UserProfileId == request.UserProfileId);
            if (userProfile is null)
            {
                result.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.NotFound, 
                    Message = $"UserProfile with ID {request.UserProfileId} not found."
                };
                result.Errors.Add(error);
                return result;
            }

            result.Payload = userProfile;
            return result;
        }
    }
}
