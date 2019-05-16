using EcommerceA.DAL;
using EcommerceA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceA.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Produtos = ProdutoDAO.RetornarProdutos();
            ViewBag.DataAtual = DateTime.Now;
            return View();
        }
        public ActionResult Cadastrar()
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "Nome");
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(string txtNome, string txtDescricao, double txtValor, int txtQuantidade, int Categorias, HttpPostedFileBase fupImagem)
        {
            Produto p = new Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Valor = txtValor,
                Quantidade = txtQuantidade,
                Categoria = CategoriaDAO.BuscarCategoriaPorId(Categorias)
            };
            if (fupImagem == null)
            {
                p.Imagem = "semimagem.jpeg";
            }
            else
            {
                string caminho = System.IO.Path.Combine(Server.MapPath("~/Images/"), fupImagem.FileName);
                fupImagem.SaveAs(caminho);
                p.Imagem = fupImagem.FileName;
            }

            ProdutoDAO.CadastrarProduto(p);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult Remover(int? id)
        {
            ProdutoDAO.RemoverProduto(ProdutoDAO.BuscarProdutoPorId(id));
            return RedirectToAction("Index", "Produto");
        }
        public ActionResult Alterar(int? id)
        {
            ViewBag.Produto = ProdutoDAO.BuscarProdutoPorId(id);
            return View();
        }
        [HttpPost]
        public ActionResult Alterar(string txtNome, string txtDescricao, double txtValor, int txtQuantidade, int hdnId, int txtId)
        {
            Produto p = ProdutoDAO.BuscarProdutoPorId(txtId);

            p.Nome = txtNome;
            p.Descricao = txtDescricao;
            p.Valor = txtValor;
            p.Quantidade = txtQuantidade;

            ProdutoDAO.AlterarProduto(p);
            return RedirectToAction("Index", "Produto");
        }
    }
}