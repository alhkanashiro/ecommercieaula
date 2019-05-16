namespace EcommerceA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Valor = c.Double(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Imagem = c.String(),
                        Categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CategoriaId)
                .Index(t => t.Categoria_CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Categorias");
        }
    }
}
