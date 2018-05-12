using Microsoft.EntityFrameworkCore;
using ModeloRelacionamentos.Domain.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModeloRelacionamentos.Infra.Mapping
{
    public class FilhosMap : EntityTypeConfiguration<Filhos>
    {
        public override void Map(EntityTypeBuilder<Filhos> builder)
        {

            builder.ToTable("FILHOS", "dbo");
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Nome).HasColumnName(@"NOME").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.CodigoPai).HasColumnName(@"CODIGOPAI");

            builder.HasOne(a => a.Pai)
                .WithMany(b => b.Filhos)
                .HasForeignKey(c => c.CodigoPai)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
