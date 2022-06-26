using AutoMapper;
using GetSocial.API.Contracts.UserProfile.Requests;
using GetSocial.API.Contracts.UserProfile.Responses;
using GetSocial.Application.UserProfiles.Commands;
using GetSocial.Domain.Aggregates.UserProfileAggregate;

namespace GetSocial.API.MappingProfiles
{
    public class UserProfileMappings : Profile
    {
        //mapping from domain model to api contract
        public UserProfileMappings()
        {
            CreateMap<UserProfileCreateUpdate, CreateUserCommand>();
            CreateMap<UserProfileCreateUpdate, UpdateUserProfileBasicInfoCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfo, BasicInfoResponse>();
        }
    }
}
