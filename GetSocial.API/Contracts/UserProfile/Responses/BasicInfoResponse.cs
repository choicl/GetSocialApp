namespace GetSocial.API.Contracts.UserProfile.Responses
{
    //The idea of dto. Data container
    public record BasicInfoResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
    }
}
