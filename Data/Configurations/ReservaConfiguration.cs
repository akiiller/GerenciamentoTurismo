using Microsoft.EntityFrameworkCore;
using GerenciamentoTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoTurismo.Data.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(reserva => reserva.Cliente)
                .WithMany(Cliente => Cliente.Reservas)
                .HasForeignKey(reserva => reserva.ClienteId);

            builder.HasOne(reserva => reserva.PacoteTuristico)
                .WithMany(pacote => pacote.Reservas)    
                .HasForeignKey(reserva => reserva.PacoteTuristicoId);
        }
    }
}
