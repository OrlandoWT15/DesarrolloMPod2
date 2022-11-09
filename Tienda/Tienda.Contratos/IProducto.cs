using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities;

namespace Tienda.Contratos
{
    public interface IProducto
    {
        Task<ObservableCollection<Producto>> ObtenerProductos();
        Task<ObservableCollection<Producto>> ObtenerProductosNombre(string nombre);
        Task<ObservableCollection<Producto>> ObtenerProductoPresentacion(string presentacion);
    }
}
