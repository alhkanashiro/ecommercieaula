using EcommerceA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceA.DAL
{
    public class ProdutoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarProduto(Produto p)
        {
            ctx.Produtos.Add(p);
            ctx.SaveChanges();
        }
        public static List<Produto> RetornarProdutos()
        {
            return ctx.Produtos.ToList();
        }
        public static Produto BuscarProdutoPorId(int? id)
        {
            return ctx.Produtos.Find(id);
        }
        public static void RemoverProduto(Produto produto)
        {
            ctx.Produtos.Remove(produto);
            ctx.SaveChanges();
        }

        public static void AlterarProduto(Produto p)
        {
            ctx.Entry(p).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}