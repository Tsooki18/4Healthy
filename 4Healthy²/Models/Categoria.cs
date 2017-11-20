using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4Healthy_.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection <Alimento> Alimentos { get; set; }
    }
}