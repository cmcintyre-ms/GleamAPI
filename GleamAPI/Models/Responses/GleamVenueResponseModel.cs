namespace GleamAPI.Models.Responses
{
    using GleamAPI.Entities;
    using GleamAPI.Models.Shared;
    public class GleamVenueResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AddressModel Address { get; set; }

        public string PicturePath { get; set; }

        public SocialMediaModel SocialMedia { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
