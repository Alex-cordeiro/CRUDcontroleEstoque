using System;
using System.Collections.Generic;
using System.Linq;
using ControleEstoqueAPI.Context;
using ControleEstoqueAPI.Models;
using ControleEstoqueAPI.Models.Dtos;

namespace ControleEstoqueAPI.Service
{
    interface IProdutoService
    {
        public IEnumerable<ProdutoDto> FindAll();
        public IEnumerable<ProdutoDto> FindById(int IdProduto);
        public bool Insert(Produto produto);
        public bool Update(Produto produto);
        public bool Delete(int IdProduto);
        public Produto Exists(int Id);
    }

    public class ProdutoService : IProdutoService
    {
        private readonly EstoqueContext _estoqueContext;
        public ProdutoService(EstoqueContext estoqueContext)
        {
            _estoqueContext = estoqueContext;
        }

        public IEnumerable<ProdutoDto> FindAll()
        {
            var produtosRetornadosDto =  from  produto in _estoqueContext.Produtos 
                                            join categoria in _estoqueContext.Categorias on produto.CategoriaId equals categoria.Id
                                      select new ProdutoDto()
                                      {
                                          Id = produto.Id,
                                          Nome = produto.Nome,
                                          Marca = produto.Marca,
                                          Preco = produto.Preco,
                                          Quantidade = produto.Quantidade,
                                          idCategoria  = produto.CategoriaId,
                                          NomeCategoria = categoria.Nome
                                      };     
            return produtosRetornadosDto;
        }

        public IEnumerable<ProdutoDto> FindById(int IdProduto)
        {

            var produtoRetornado = from produto in _estoqueContext.Produtos
                                   join categoria in _estoqueContext.Categorias on produto.CategoriaId equals categoria.Id
                                   where produto.Id  == IdProduto
                                   select new ProdutoDto()
                                   {
                                       Id = produto.Id,
                                       Nome = produto.Nome,
                                       Marca = produto.Marca,
                                       Preco = produto.Preco,
                                       idCategoria = produto.CategoriaId,
                                       NomeCategoria = categoria.Nome
                                   };

            return produtoRetornado;
        }

        public bool Insert(Produto produto)
        {
            try
            {
                _estoqueContext.Produtos.Add(produto);
                _estoqueContext.SaveChanges();
                return true;
            }
            catch 
            {
                return false;       
            }
            
        }

        public bool Update(Produto produto)
        {
            int produtoId = Convert.ToInt32(produto.Id);
            try
            {
                var produtoRetornado = Exists(produtoId);
                if(produtoRetornado != null)
                {
                    _estoqueContext.Entry(produtoRetornado).CurrentValues.SetValues(produto);
                    _estoqueContext.SaveChanges();
                    return true;
                }
                  
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Delete(int IdProduto)
        {
            var produtoRetornado = Exists(IdProduto);
            if (produtoRetornado != null)
            {
                _estoqueContext.Produtos.Remove(produtoRetornado);
                _estoqueContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Produto Exists(int Id)
        {
            var produtoRetornado = _estoqueContext.Produtos.SingleOrDefault(p => p.Id.Equals(Id));
            if(produtoRetornado != null)        
                return produtoRetornado;
            return null;
        }
    }

}

