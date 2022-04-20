using System.Collections.Generic;
using System.Linq;
using ControleEstoqueAPI.Context;
using ControleEstoqueAPI.Models;

namespace ControleEstoqueAPI.Service
{
    interface IProdutoService
    {
        public List<Produto> FindAll();
        public Produto FindById(int IdProduto);
        public Produto Update(int IdProduto, Produto produto);
        public Produto Delete(int IdProduto, Produto produto);
    }

    public class ProdutoService : IProdutoService
    {
        private readonly EstoqueContext _estoqueContext;
        public ProdutoService(EstoqueContext estoqueContext)
        {
            _estoqueContext = estoqueContext;
        }

        public Produto Delete(int IdProduto, Produto produto)
        {
            throw new System.NotImplementedException();
        }

        public List<Produto> FindAll()
        {
            var produtosRetornados = _estoqueContext.Produtos.ToList();
            return produtosRetornados;
        }

        public Produto FindById(int IdProduto)
        {
            throw new System.NotImplementedException();
        }

        public Produto Update(int IdProduto, Produto produto)
        {
            throw new System.NotImplementedException();
        }
    }

}

