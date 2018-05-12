using Microsoft.EntityFrameworkCore;
using ModeloRelacionamentos.Domain.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModeloRelacionamentos.Infra.Mapping
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public override void Map(EntityTypeBuilder<Pessoa> builder)
        {

            builder.ToTable("PESSOA", "dbo");
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Nome).HasColumnName(@"NOME").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName(@"DATACADASTRO").HasColumnType("datetime").IsRequired();

            builder.HasOne(p => p.Endereco)
                .WithOne(i => i.Pessoa)
                .HasForeignKey<Endereco>(b => b.CodigoPessoa);
        }
    }
}
