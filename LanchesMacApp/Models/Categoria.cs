using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMacApp.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        
        [StringLength(250)]
        public string CategoriaNome { get; set; }

        [StringLength(250)]
        public string Descricao { get; set; }
        
        public List<Lanche> Lanches { get; set; }
    }
}
