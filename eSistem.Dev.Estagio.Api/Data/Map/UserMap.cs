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

            builder.Property(x => x.IdPerson)
                .IsRequired();
            builder.HasIndex(x => x.IdPerson).HasDatabaseName("ix_usuario_id_pessoa");

            builder.HasOne(x => x.Person)
                .WithOne(x => x.Usuario)
                .HasForeignKey<Usuario>(x => x.IdPerson)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
