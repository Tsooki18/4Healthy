using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4Healthy_.Models
{
    public class Alimento
    {
        public int AlimentoId { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int Calorias { get; set; }
        public int Carboidratos { get; set; }
        public int Proteinas { get; set; }
        public int Gorduras { get; set; }
    }
}