﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetSocial.Application.ResultsModel;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace GetSocial.Application.UserProfiles.Commands
{
    public class CreateUserCommand : IRequest<OperationResults<UserProfile>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }

    }
}
