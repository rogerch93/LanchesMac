using System.ComponentModel.DataAnnotations.Schema;


namespace LanchesMacApp.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }

        [Column(TypeName="decimal(18,2)")]
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool Estoque { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
