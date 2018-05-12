using Microsoft.EntityFrameworkCore;
using ModeloRelacionamentos.Domain.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModeloRelacionamentos.Infra.Mapping
{
    public class CursosMap : EntityTypeConfiguration<Cursos>
    {
        public override void Map(EntityTypeBuilder<Cursos> builder)
        {

            builder.ToTable("CURSOS", "dbo");
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Nome).HasColumnName(@"RUA").HasColumnType("varchar(255)").IsRequired();
        }
    }
}
