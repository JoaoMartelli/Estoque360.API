using GerenciarEstoque.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciarEstoque.Repositorio.Configuracoes;

public class ProdutoConfiguracoes : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos").HasKey(nameof(Produto.Id));

        builder.Property(nameof(Produto.Id)).HasColumnName("ProdutoID").IsRequired();
        builder.Property(nameof(Produto.CategoriaId)).HasColumnName("CategoriaID").IsRequired();
        builder.Property(nameof(Produto.Nome)).HasColumnName("Nome").HasMaxLength(100).IsRequired();
        builder.Property(nameof(Produto.Preco)).HasColumnName("Preco").HasPrecision(12, 2).IsRequired();
        builder.Property(nameof(Produto.Quantidade)).HasColumnName("Quantidade").IsRequired();
        builder.Property(nameof(Produto.Ativo)).HasColumnName("Ativo").IsRequired();

        builder.HasOne(nameof(Produto.Categoria))
               .WithMany(nameof(Categoria.Produtos))
               .HasForeignKey(nameof(Produto.CategoriaId));
    }
}