using System.Data;
using GerenciarEstoque.Dominio.Entidades;
using GerenciarEstoque.Repositorio.Configuracoes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class GerenciarEstoqueContexto : DbContext
{
    private readonly string stringConexao = "Server=JOÃO-PAULO\\SQLEXPRESS;Database=Estoque360;TrustServerCertificate=true;Trusted_Connection=True;";

    public GerenciarEstoqueContexto() : base(new DbContextOptions<GerenciarEstoqueContexto>())
    {
    }

    public GerenciarEstoqueContexto(DbContextOptions<GerenciarEstoqueContexto> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(stringConexao);
        }
    }

    public IDbConnection CriarConexao()
    {
        return new SqlConnection(stringConexao);
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
        modelBuilder.ApplyConfiguration(new ProdutoConfiguracoes());
        modelBuilder.ApplyConfiguration(new CategoriaConfiguracoes());
    }
}
