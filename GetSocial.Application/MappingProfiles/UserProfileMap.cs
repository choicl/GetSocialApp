using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GetSocial.Application.UserProfiles.Commands;
using GetSocial.Domain.Aggregates.UserProfileAggregate;

namespace GetSocial.Application.MappingProfiles
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<CreateUserCommand, BasicInfo>().ReverseMap();
        }
    }
}
