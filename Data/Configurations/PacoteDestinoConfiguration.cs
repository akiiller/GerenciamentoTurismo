using Microsoft.EntityFrameworkCore;
using GerenciamentoTurismo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoTurismo.Data.Configurations
{
    public class PacoteDestinoConfiguration : IEntityTypeConfiguration<PacoteDestino>
    {
        public void Configure(EntityTypeBuilder<PacoteDestino> builder)
        {
            builder.HasKey(pd => new { pd.PacoteTuristicoId, pd.CidadeDestinoId });

            builder.HasOne(pd => pd.PacoteTuristico)
                .WithMany(p => p.PacoteDestinos)
                .HasForeignKey(pd => pd.PacoteTuristicoId);

            builder.HasOne(pd => pd.CidadeDestino)
                .WithMany(c => c.PacoteDestinos)
                .HasForeignKey(pd => pd.CidadeDestinoId);

            builder.HasData(
            // Pacote 1 (Carnaval no Brasil) -> Rio de Janeiro e Salvador
            new PacoteDestino { PacoteTuristicoId = 1, CidadeDestinoId = 101 }, // Link com Rio
            new PacoteDestino { PacoteTuristicoId = 1, CidadeDestinoId = 102 }, // Link com Salvador

            // Pacote 2 (Tour Europeu Clássico) -> Paris e Roma
            new PacoteDestino { PacoteTuristicoId = 2, CidadeDestinoId = 301 }, // Link com Paris
            new PacoteDestino { PacoteTuristicoId = 2, CidadeDestinoId = 201 }, // Link com Roma

            // Pacote 3 (Aventura na Big Apple) -> Nova York
            new PacoteDestino { PacoteTuristicoId = 3, CidadeDestinoId = 401 }  // Link com Nova York
        );
        }
    }
}
