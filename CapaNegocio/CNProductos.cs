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
        public CDProductos objetoCD = new CDProductos();
        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarPRod(string nombre, string desc, string marca, string precio, string stock) //todos son 'string' porque todos los valores de textbox son tipo string.
        {
            objetoCD.Insertar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock)); //

        }

        public void EditarProd(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        public void EliminarPRod(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

        public DataTable BuscarProd(string buscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Buscar(buscar);
            return tabla;
        }

    }
}
