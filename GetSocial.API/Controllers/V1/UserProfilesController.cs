using AutoMapper;
using GetSocial.API.Contracts.UserProfile.Requests;
using GetSocial.API.Contracts.UserProfile.Responses;
using GetSocial.Application.UserProfiles.Commands;
using GetSocial.Application.UserProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GetSocial.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route(ApiRoutes.BaseRoute)]
    public class UserProfilesController : Controller
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
            var profiles = _mapper.Map<List<UserProfileResponse>>(response);
            return Ok(profiles);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdate profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return CreatedAtAction(nameof(GetUserProfileById), 
                new { Id = response.UserProfileId},userProfile);
        }
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileByIdQuery{ UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(query);
            var profile = _mapper.Map<UserProfileResponse>(response);
            return Ok(profile);
        }

        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpPatch]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdate profile)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInfoCommand>(profile);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            return NoContent();
        }
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserProfileCommand { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command);

            return NoContent();
        }
    }
}
