namespace GerenciamentoTurismo.Data.Configurations;
using GerenciamentoTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PaisDestinoConfiguration : IEntityTypeConfiguration<PaisDestino>
{
    public void Configure(EntityTypeBuilder<PaisDestino> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(p => p.Nome)
            .IsUnique();

        builder.HasData(
           new PaisDestino { Id = 1, Nome = "Brasil" },
           new PaisDestino { Id = 2, Nome = "Itália" },
           new PaisDestino { Id = 3, Nome = "França" },
           new PaisDestino { Id = 4, Nome = "Estados Unidos" }
       );
    }
}
