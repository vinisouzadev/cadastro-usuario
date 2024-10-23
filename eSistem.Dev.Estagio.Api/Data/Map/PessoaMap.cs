using eSistem.Dev.Estagio.Api.Models;
using eSistem.Dev.Estagio.Api.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSistem.Dev.Estagio.Api.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaWithUser>
    {
        public void Configure(EntityTypeBuilder<PessoaWithUser> builder)
        {
            builder.ToTable("pessoa");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.NomeRazaoSocial)
                .HasColumnName("nome_razao_social")
                .IsRequired();

            builder.Property(p => p.Tipo)
                .HasColumnName("tipo")
                .IsRequired();

            builder.Property(p => p.CpfCnpj)
                .HasColumnName("cpf_cnpj")
                .IsRequired();

            builder.Property(p => p.Cadastro)
                .HasColumnName("cadastro")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnName("ativo")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithOne(x => x.Pessoa)
                .HasForeignKey<Usuario>(x => x.IdPessoa)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
