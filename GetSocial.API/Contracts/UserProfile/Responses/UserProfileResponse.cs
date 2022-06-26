﻿namespace GetSocial.API.Contracts.UserProfile.Responses
{
    public record UserProfileResponse
    {
        public Guid UserProfileId { get; set; }
        public BasicInfoResponse BasicInfo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
