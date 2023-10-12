namespace GleamAPI.Entities.Venue
{
    public class GleamVenueAddDto
    {
           
        public string VenueName { get; set; } 

        public string? Website { get; set; }

        //public SocialMediaAddDto? SocialMedias { get; set; }

       // public List<Picture> Pictures { get; set; } = new List<Picture>();

        public string Description { get; set; } 

        public string? Coordinates { get; set; } 
        //check data type - might need additonal table to store: "lat, long, rad, limit"

        //public City City { get; set; }      

        public string PhoneNumber { get; set; } 

       //public List<Email> Emails { get; set; } = new List<Email>(); 


       //public List<Review> Reviews { get; set; } = new List<Review>();


    }
}
