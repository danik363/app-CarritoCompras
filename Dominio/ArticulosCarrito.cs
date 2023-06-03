using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArticulosCarrito
    {
        public int cantidad { get; set; }
        public int idArticulo { get; set; }
        public decimal precio { get; set; }

        public string nombre { get; set; }
    }
}
