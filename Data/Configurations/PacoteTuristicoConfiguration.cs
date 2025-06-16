namespace GerenciamentoTurismo.Data.Configurations;
using GerenciamentoTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PacoteTuristicoConfiguration : IEntityTypeConfiguration<PacoteTuristico>
{
    public void Configure(EntityTypeBuilder<PacoteTuristico> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Titulo)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Preco)
            .HasColumnType("decimal(18,2)");

        builder.HasData(
            new PacoteTuristico
            {
                Id = 1,
                Titulo = "Carnaval no Brasil",
                DataInicio = new DateTime(2026, 2, 14),
                CapacidadeMaxima = 50,
                Preco = 4500.00m
            },
            new PacoteTuristico
            {
                Id = 2,
                Titulo = "Tour Europeu Clássico",
                DataInicio = new DateTime(2025, 9, 10),
                CapacidadeMaxima = 30,
                Preco = 7800.00m
            },
            new PacoteTuristico
            {
                Id = 3,
                Titulo = "Aventura na Big Apple",
                DataInicio = new DateTime(2025, 12, 20),
                CapacidadeMaxima = 25,
                Preco = 6200.00m
            }
        );
    }
}
