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
    // Definimos la clase 'CNProductos', que representa la capa de negocio para gestionar los productos.
    public class CNProductos
    {
        // Instancia un nuevo objeto de esa clase. 
        public CDProductos objetoCD = new CDProductos(); // Este objeto será utilizado para interactuar con la capa de datos.

        // Definimos un método
        public DataTable MostrarProd()
        {
            // Llama al método 'Mostrar' del objeto 'objetoCD' (capa de datos) y retorna el resultado
            return objetoCD.Mostrar(); 
        }

        public void InsertarPRod(string nombre, string descripcion, string marca, string precio, string stock)
        {
            // Llamamos al método 'Insertar' del objeto 'objetoCD', pasando los parámetros recibidos. Convierte el 'precio' a 'double' 
            // y el 'stock' a 'int' antes de hacerlo. Esto envía la solicitud de inserción de un nuevo producto a la capa de datos.
            objetoCD.Insertar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        // Define un método que recibe varios parámetros
        public void EditarProd(string nombre, string descripcion, string marca, double precio, int stock, int id)
        {
            objetoCD.Editar(nombre, descripcion, marca, precio, stock, id);
        }

        public void EliminarPRod(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }


        //Este método recibe un parámetro 'nombre' de tipo 'string'.
        // El método retorna un 'DataTable'.
        public DataTable BuscarProducto(string nombre)
        {
            return objetoCD.Buscar(nombre);
        }


    }

}
