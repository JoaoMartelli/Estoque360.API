using GerenciarEstoque.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciarEstoque.Repositorio.Configuracoes;

public class UsuarioConfiguracoes : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios").HasKey(nameof(Usuario.Id));

        builder.Property(nameof(Usuario.Id)).HasColumnName("UsuarioID").IsRequired();
        builder.Property(nameof(Usuario.Nome)).HasColumnName("Nome").HasMaxLength(80).IsRequired();
        builder.Property(nameof(Usuario.Email)).HasColumnName("Email").HasMaxLength(130).IsRequired();
        builder.Property(nameof(Usuario.Senha)).HasColumnName("Senha").HasMaxLength(64).IsRequired();
        builder.Property(x => x.DataNascimento).HasColumnName("DataNascimento")
                                                        .HasColumnType("date")
                                                        .IsRequired().HasConversion(
                                                        x => x.ToDateTime(TimeOnly.MinValue),
                                                        x => DateOnly.FromDateTime(x));
        builder.Property(nameof(Usuario.Ativo)).HasColumnName("Ativo").IsRequired();
    }
}