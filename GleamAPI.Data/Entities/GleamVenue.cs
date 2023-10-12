using GleamAPI.Data.ValueObjects;

namespace GleamAPI.Entities.Venue
{
    public class GleamVenue
    {

        //public GleamVenue()
        //{
        //    Reviews = new List<Review>();
        //}



        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Description { get; set; }

        // 'Address' as ValueObject
        public Address Address { get; set; }

        public string PicturePath { get; set; }
        public SocialMedia SocialMedia { get; set; }

      

        // Relationship one-to-many to reviews
        //public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public List<Review> Reviews { get; set; }

       
        #region Original

        // public Guid GleamVenueId { get; set; } //PK
        // //DTO will not have GleamVenueId because this is generated

        // public string VenueName { get; set; } 

        // public string? Website { get; set; }

        // public VenueType VenueType { get; set; }
        //// LEAVE OUT FOR NOW public SocialMedia? SocialMedias { get; set; }

        //LEAVE FOR NOW public List<Picture> Pictures { get; set; } = new List<Picture>();  

        // public string Description { get; set; } 

        // NOW ADDRESS public string? Coordinates { get; set; } 
        // //check data type - might need additonal table to store: "lat, long, rad, limit"

        // public City City { get; set; } 

        // public Guid CityId { get; set; } //not in DTO

        // public string PhoneNumber { get; set; } 

        // SINGLE FOR NOW public List<Email> Emails { get; set; } = new List<Email>(); 

        // TRY BUT GET RID IF NOT public List<Review> Reviews { get; set; } = new List<Review>();

        #endregion
    }
}
