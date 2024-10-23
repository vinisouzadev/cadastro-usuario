using eSistem.Dev.Estagio.Api.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSistem.Dev.Estagio.Api.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("AspNetUsers");

            builder.Property(x => x.IdPessoa)
                .IsRequired();
            builder.HasIndex(x => x.IdPessoa).HasDatabaseName("ix_usuario_id_pessoa");

            builder.HasOne(x => x.Pessoa)
                .WithOne(x => x.User)
                .HasForeignKey<Usuario>(x => x.IdPessoa)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
