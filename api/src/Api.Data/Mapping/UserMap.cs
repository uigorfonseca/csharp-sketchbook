using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(entity => entity.Id);
            builder.HasIndex(entity => entity.Email)
                   .IsUnique();

            builder.Property(entity => entity.Name)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(entity => entity.Email)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}
