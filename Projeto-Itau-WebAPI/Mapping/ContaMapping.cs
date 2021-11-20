using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Itau_WebAPI.Model;

namespace Projeto_Itau_WebAPI.Mapping
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(c => c.Tipo)
                   .IsRequired()
                   .HasColumnType("int");

            builder.Property(c => c.Status)
                   .IsRequired()
                   .HasColumnType("bit");

            builder.Property(c => c.Valor)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
                   
            builder.ToTable("Conta");
        }
    }
}