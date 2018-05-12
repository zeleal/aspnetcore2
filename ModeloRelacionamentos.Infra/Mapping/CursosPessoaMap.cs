using Microsoft.EntityFrameworkCore;
using ModeloRelacionamentos.Domain.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModeloRelacionamentos.Infra.Mapping
{
    public class CursosPessoaMap : EntityTypeConfiguration<CursosPessoa>
    {
        public override void Map(EntityTypeBuilder<CursosPessoa> builder)
        {
            builder.ToTable("CURSOSPESSOA");

            builder.HasKey(t => new { t.CodCursos, t.CodPessoa });

            builder.Property(x => x.CodCursos).HasColumnName(@"CODCRUSOS");
            builder.Property(x => x.CodPessoa).HasColumnName(@"CODPESSOA");

            builder.HasOne(t => t.Pessoa)
                .WithMany(y => y.CursosPessoa)
                .HasForeignKey(x => x.CodPessoa)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ent => ent.Cursos)
                .WithMany(ent => ent.CursosPessoa)
                .HasForeignKey(x => x.CodCursos)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
