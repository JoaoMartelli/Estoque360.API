using GerenciarEstoque.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciarEstoque.Repositorio.Configuracoes;

public class CategoriaConfiguracoes : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias").HasKey(nameof(Categoria.Id));

        builder.Property(nameof(Categoria.Id)).HasColumnName("CategoriaID").IsRequired();
        builder.Property(nameof(Categoria.UsuarioId)).HasColumnName("UsuarioID").IsRequired();
        builder.Property(nameof(Categoria.Nome)).HasColumnName("Nome").HasMaxLength(40).IsRequired();
        builder.Property(nameof(Categoria.Ativo)).HasColumnName("Ativo").IsRequired();

        builder.HasOne(nameof(Categoria.Usuario))
               .WithMany(nameof(Usuario.Categorias))
               .HasForeignKey(nameof(Categoria.UsuarioId));
    }
}