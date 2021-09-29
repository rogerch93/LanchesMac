using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LanchesMacApp.Models
{
    public class Lanche
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Nome { get; set; }
        
        [StringLength(250)]
        public string DescricaoCurta { get; set; }
        
        [StringLength(250)]
        public string DescricaoDetalhada { get; set; }

        [Column(TypeName="decimal(18,2)")]
        public decimal Preco { get; set; }
        
        [StringLength(250)]
        public string ImagemUrl { get; set; }
        
        [StringLength(250)]
        public string ImagemThumbnailUrl { get; set; }
        
        public bool IsLanchePreferido { get; set; }
        public bool Estoque { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
