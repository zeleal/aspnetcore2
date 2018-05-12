using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModeloRelacionamentos.Domain.Dominio;

namespace ModeloRelacionamentos.Infra.Mapping
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {

            builder.ToTable("ENDERECO", "dbo");
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Rua).HasColumnName(@"RUA").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.Numero).HasColumnName(@"NUMERO").HasColumnType("int");
            builder.Property(x => x.CodigoPessoa).HasColumnName(@"CodigoPessoa");
        }
    }
}
