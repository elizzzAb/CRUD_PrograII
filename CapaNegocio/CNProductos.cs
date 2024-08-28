using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CNProductos
    {
        private CDProductos objetoCD = new CDProductos();

        public DataTable MostrarProd()
        {
            return objetoCD.Mostrar();
        }

        public void InsertarPRod(string nombre, string descripcion, string marca, string precio, string stock)
        {
            objetoCD.Insertar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        public void EditarProd(string nombre, string descripcion, string marca, double precio, int stock, int id)
        {
            objetoCD.Editar(nombre, descripcion, marca, precio, stock, id);
        }

        public void EliminarPRod(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

        //public DataTable BuscarProd(string buscar)
        //{
        //    return objetoCD.Buscar(buscar);
        //}

        public DataTable BuscarProd(string textoBusqueda)
        {
            return objetoCD.Buscar(textoBusqueda);
        }


    }

}
