namespace GerenciamentoTurismo.Data.Configurations;
using GerenciamentoTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CidadeDestinoConfiguration : IEntityTypeConfiguration<CidadeDestino>
{
    public void Configure(EntityTypeBuilder<CidadeDestino> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);


        builder.HasOne(cidade => cidade.Pais)
            .WithMany(pais => pais.Cidades)
            .HasForeignKey(cidade => cidade.PaisDestinoId);

        builder.HasData(
            // Cidades do Brasil (PaisDestinoId = 1)
            new CidadeDestino { Id = 101, Nome = "Rio de Janeiro", PaisDestinoId = 1 },
            new CidadeDestino { Id = 102, Nome = "Salvador", PaisDestinoId = 1 },

            // Cidades da Itália (PaisDestinoId = 2)
            new CidadeDestino { Id = 201, Nome = "Roma", PaisDestinoId = 2 },
            new CidadeDestino { Id = 202, Nome = "Veneza", PaisDestinoId = 2 },

            // Cidades da França (PaisDestinoId = 3)
            new CidadeDestino { Id = 301, Nome = "Paris", PaisDestinoId = 3 },

            // Cidades dos EUA (PaisDestinoId = 4)
            new CidadeDestino { Id = 401, Nome = "Nova York", PaisDestinoId = 4 }
        );
    }
}
