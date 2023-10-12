namespace GleamAPI.Models.Requests
{
    using GleamAPI.Models.Shared;
    public class GleamVenueRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public AddressModel Address { get; set; }

        public string PicturePath { get; set; }

        public SocialMediaModel socialMediaModel { get; set; }
    }
}
