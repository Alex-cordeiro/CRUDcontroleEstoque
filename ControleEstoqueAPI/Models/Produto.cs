namespace ControleEstoqueAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
