using GleamAPI.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GleamAPI.Data.Configurations
{
    internal class ReviewConfiguration
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(x => x.ReviewersEmail)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
