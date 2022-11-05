using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public double Precio { get; set; }
        public string ImagenPath { get; set; }
    }
}
