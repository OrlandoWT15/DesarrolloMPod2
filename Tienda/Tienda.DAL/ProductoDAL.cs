﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Tienda.Contratos;
using Tienda.Entities;
namespace Tienda.DAL
{
    public class ProductoDAL:IProducto
    {
        string dbconexion;

        public ProductoDAL()
        {
            dbconexion = ConfigurationManager.ConnectionStrings["ConectarProductos"].ConnectionString;
        }

        public async Task <ObservableCollection<Producto>> ObtenerProductos()
        {
            ObservableCollection<Producto> ListProductos = new ObservableCollection<Producto>();

            using (SqlConnection cn = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await cn.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListProductos.Add(new Producto
                            {
                                Nombre = sdr["Nombre"].ToString(),
                                Presentacion = sdr["Presentacion"].ToString(),
                                PMayoreo = Convert.ToDouble(sdr["PMayoreo"]),
                                PMenudeo = Convert.ToDouble(sdr["PMenudeo"]),
                                Existencia = Convert.ToInt32(sdr["Existencia"]),
                                CostoUnitario = Convert.ToDouble(sdr["CostoUnitario"]),
                                ImagenPath = sdr["ImagenPath"].ToString(),
                                ProductoId = Convert.ToInt32(sdr["ProductoId"]),
                            });
                        }
                        cn.Close();
                    }
                    else
                    {
                        ListProductos = null;
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                }
                return (ListProductos);
            }
        }
        public async Task<ObservableCollection<Producto>> ObtenerProductosNombre(string nombre)
        {
            ObservableCollection<Producto> ListaProductos = new ObservableCollection<Producto>();
            using (SqlConnection cn = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductoPorNombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                try
                {
                    await cn.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListaProductos.Add(new Producto 
                            { 
                                Nombre = sdr["Nombre"].ToString(),
                                Presentacion = sdr["Presentacion"].ToString(),
                                PMayoreo = Convert.ToDouble(sdr["PMayoreo"]),
                                PMenudeo = Convert.ToDouble(sdr["PMenudeo"]),
                                Existencia = Convert.ToInt16(sdr["Existencia"]),
                                CostoUnitario = Convert.ToDouble(sdr["CostoUnitario"])
                            });
                        }
                        cn.Close();
                    }
                    else
                    {
                        ListaProductos = null;
                    }
                }
                catch(Exception)
                {
                    cn.Close();
                }
                return (ListaProductos);
            }
        }
    }
}
