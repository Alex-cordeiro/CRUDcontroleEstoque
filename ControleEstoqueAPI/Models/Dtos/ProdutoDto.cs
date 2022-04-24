namespace ControleEstoqueAPI.Models.Dtos
{
    public class ProdutoDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
        public int? idCategoria { get; set; }
        public string NomeCategoria { get; set; }
    }
}
