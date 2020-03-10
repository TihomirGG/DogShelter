namespace DogShelter.Data.Configurations
{
    using DogShelter.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostsImagesConfiguration : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            builder.HasKey(k => new { k.ImageId, k.PostId });

            builder.HasOne(p => p.Post)
                .WithMany(i => i.PostImages)
                .HasForeignKey(k => k.PostId);

            builder.HasOne(i => i.Image)
                .WithMany(p => p.PostImages)
                .HasForeignKey(k => k.ImageId);
        }
    }
}
