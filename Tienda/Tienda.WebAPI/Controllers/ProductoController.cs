using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.ObjectModel;
using Tienda.Entities;
using Tienda.Contratos;
using Tienda.DAL;
using System.Threading.Tasks;

namespace Tienda.WebAPI.Controllers
{
    public class ProductoController : ApiController
    {
        readonly IProducto Prod;

        ObservableCollection<Producto> DatosProductos;

        public ProductoController()
        {
            Prod = new ProductoDAL();
        }

        [HttpGet]
        public async Task<ObservableCollection<Producto>> ListaProductos()
        {
            DatosProductos = await Prod.ObtenerProductos();

            return DatosProductos;
        }

        [HttpGet]
        public async Task<ObservableCollection<Producto>> ProductoPorNombre (string x)
        {
            DatosProductos = await Prod.ObtenerProductosNombre(x);

            return DatosProductos;
        }

        [HttpGet]
        public async Task<ObservableCollection<Producto>> ProductoPresentacion (string x)
        {
            DatosProductos = await Prod.ObtenerProductoPresentacion(x);

            return DatosProductos;
        }
    }
}
