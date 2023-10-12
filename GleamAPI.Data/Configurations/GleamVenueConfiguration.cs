using GleamAPI.Entities;
using GleamAPI.Entities.Venue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GleamAPI.Data.Configurations
{
    internal class GleamVenueConfiguration : IEntityTypeConfiguration<GleamVenue>
    {
        
        public void Configure(EntityTypeBuilder<GleamVenue> builder) 
        {

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Address, y =>
            {
                y.Property(p => p.Street)
                    .HasColumnName("Street")
                    .HasMaxLength(100)
                    .IsRequired();

                y.Property(p => p.Longitude)
                    .HasColumnName("Longitude")
                    .IsRequired();

                y.Property(p => p.Latitude)
                    .HasColumnName("Latitude")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.SocialMedia, y =>
            {
                y.Property(p => p.FacebookLink)
                    .HasColumnName("FacebookLink")
                    .HasMaxLength(100);                   ;

                y.Property(p => p.InstagramHandle)
                    .HasColumnName("InstagramHandle");

                y.Property(p => p.TwitterHandle)
                    .HasColumnName("TwitterHandle");
            });

            //builder
            //    .HasMany<Review>(x => x.Reviews)
            //    .WithOne(y => y.GleamVenue)
            //    .HasForeignKey(y => y.GleamVenueId)
            //    .OnDelete(DeleteBehavior.Cascade);
            #region Original
            // builder.ToTable("GleamVenue");

            // builder.Property(p => p.GleamVenueId).IsRequired();

            // builder.Property(p => p.VenueName).IsRequired();

            // builder.Property(p => p.Coordinates).IsRequired();

            // builder.Property(p => p.Description).IsRequired();

            // builder.Property(p => p.PhoneNumber).IsRequired();

            //// builder.Property(p => p.Emails).IsRequired();

            // builder.HasKey(p => p.GleamVenueId).HasName("PK_GleamVenue");

            //// builder.HasMany(p => p.Emails).WithOne();

            #endregion
        }


    }
}
