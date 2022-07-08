using AutoMapper;
using GetSocial.API.Contracts.Common;
using GetSocial.API.Contracts.UserProfile.Requests;
using GetSocial.API.Contracts.UserProfile.Responses;
using GetSocial.API.Filters;
using GetSocial.Application.Enums;
using GetSocial.Application.ResultsModel;
using GetSocial.Application.UserProfiles.Commands;
using GetSocial.Application.UserProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GetSocial.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route(ApiRoutes.BaseRoute)]
    public class UserProfilesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var query = new GetAllUserProfilesQuery();
            var response = await _mediator.Send(query);
            var profiles = _mapper.Map<List<UserProfileResponse>>(response.Payload);
            return Ok(profiles);
        }
        [HttpPost]
        [ValidateModule]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdate profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);

            return CreatedAtAction(nameof(GetUserProfileById), 
                new { Id = userProfile.UserProfileId},userProfile);
        }
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileByIdQuery{ UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(query);

            if (response.IsError)
                return HandleErrorResponse(response.Errors);
            var profile = _mapper.Map<UserProfileResponse>(response.Payload);
            return Ok(profile);
        }

        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpPatch]
        [ValidateModule]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdate profile)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInfoCommand>(profile);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            return response.IsError ? HandleErrorResponse(response.Errors) : NoContent();
        }
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserProfileCommand { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command);

            return response.IsError ? HandleErrorResponse(response.Errors) : NoContent();
        }
    }
}
