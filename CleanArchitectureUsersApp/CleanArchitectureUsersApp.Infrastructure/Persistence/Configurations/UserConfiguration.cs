using CleanArchitectureUsersApp.Domain.Entitis.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(User.NameMaxLength)
                .HasColumnName("name");

            builder.Property(u => u.Username)
                .IsRequired()
                .HasColumnName("username");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("email");

            builder.Property(u => u.AddressStreet)
                .IsRequired()
                .HasMaxLength(User.StreetAddressMaxLength)
                .HasColumnName("address_street");

            builder.Property(u => u.addressCity)
                   .IsRequired()
                   .HasMaxLength(User.CityAddressMaxLength)
                   .HasColumnName("city");

            builder.Property(u => u.Website)
                   .HasMaxLength(User.WebsiteMaxLength)
                   .HasColumnName("website");

            builder.Property(u => u.password)
                   .IsRequired()
                   .HasColumnName ("password");

            builder.Property(u => u.IsActive)
                   .IsRequired()
                   .HasColumnName("active");

            builder.OwnsOne(u => u.Location, location =>
            {
                location.Property(l => l.geoLat)
                        .HasColumnName("GeoLat")
                        .IsRequired();

                location.Property(l => l.geoLng)
                        .HasColumnName("GeoLng")
                        .IsRequired();
            });


        }
    }
}
