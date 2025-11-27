using CleanArchitectureUsersApp.Domain.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.Configurations
{
    internal sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("companies");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(Company.CompanyNameMaxLength)
                .HasColumnName("company_name");
        }
    }
}