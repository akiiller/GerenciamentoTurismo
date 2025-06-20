using Microsoft.EntityFrameworkCore;
using GerenciamentoTurismo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoTurismo.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    { 
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.HasQueryFilter(c => c.DeletedAt == null);
        }
    }
}
