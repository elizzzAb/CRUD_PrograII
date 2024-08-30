using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDProductos
    {
        //Instancia un nuevo objeto de esta clase.
        // Se utiliza para gestionar la conexión con la base de datos.
        private CDConexion conexion = new CDConexion();
        // Este objeto se utiliza para ejecutar comandos SQL o procedimientos almacenados en la base de datos.
        private SqlCommand comando = new SqlCommand();
        // Este objeto se utiliza para leer los datos obtenidos de la base de datos a través de una consulta.
        private SqlDataReader leer;
        // Este objeto se utiliza para almacenar los datos obtenidos de la base de datos en formato de tabla.
        private DataTable tabla = new DataTable();

        //Retorna un 'DataTable'.
        public DataTable Mostrar()
        {
            // Asigna la conexión abierta a la propiedad 'Connection' del objeto 'comando'.
            comando.Connection = conexion.AbrirConexion();
            // Establece el texto del comando, que en este caso es el nombre del procedimiento almacenado 'MostrarProductos'.
            comando.CommandText = "MostrarProductos";
            // Indica que el 'CommandText' es un procedimiento almacenado, no una consulta SQL directa.
            comando.CommandType = CommandType.StoredProcedure;
            // Ejecuta el comando y asigna el resultado a 'leer', permitiendo la lectura de los datos devueltos por el procedimiento almacenado.
            leer = comando.ExecuteReader();
            // Carga los datos leídos en el 'DataTable' 'tabla'.
            tabla.Load(leer);
            // Cierra la conexión con la base de datos.
            conexion.CerrarConexion();
            // Retorna el 'DataTable' que contiene los productos.
            return tabla;
        }


        public void Insertar(string nombre, string descripcion, string marca, double precio, int stock)
        {
            // Asigna la conexión abierta a la propiedad 'Connection' del objeto 'comando'.
            comando.Connection = conexion.AbrirConexion();
            // Establece el texto del comando, que en este caso es el nombre del procedimiento almacenado 'InsertarProductos'.
            comando.CommandText = "InsertarProductos";
            // Indica que el 'CommandText' es un procedimiento almacenado.
            comando.CommandType = CommandType.StoredProcedure;

            // Agrega los parámetros necesarios para el procedimiento almacenado, usando los valores recibidos como argumentos.
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);

            // Ejecuta el comando sin esperar ningún resultado (ya que es una inserción).
            comando.ExecuteNonQuery();
            // Limpia los parámetros del comando para evitar conflictos en futuras ejecuciones.
            comando.Parameters.Clear();
            // Cierra la conexión con la base de datos.
            conexion.CerrarConexion();
        }

        public void Editar(string nombre, string descripcion, string marca, double precio, int stock, int id)
        {
            // Asigna la conexión abierta a la propiedad 'Connection' del objeto 'comando'.
            comando.Connection = conexion.AbrirConexion();
            // Establece el texto del comando, que en este caso es el nombre del procedimiento almacenado 'EditarProductos'.
            comando.CommandText = "EditarProductos";
            // Indica que el 'CommandText' es un procedimiento almacenado.
            comando.CommandType = CommandType.StoredProcedure;

            // Agrega los parámetros necesarios para el procedimiento almacenado, incluyendo el 'id' del producto a modificar.
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            // Agrega el parámetro necesario para el procedimiento almacenado, usando el 'id' del producto a eliminar.
            comando.Parameters.AddWithValue("@idpro", id);
            // Ejecuta el comando sin esperar ningún resultado (ya que es una eliminación).
            comando.ExecuteNonQuery();
            // Limpia los parámetros del comando para evitar conflictos en futuras ejecuciones.
            comando.Parameters.Clear();
            //conexion.CerrarConexion();


        }

        //public DataTable Buscar(string textoBusqueda)
        //{
        //    comando.Connection = conexion.AbrirConexion();
        //    comando.CommandText = "BuscarProductos";
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.AddWithValue("@buscar", textoBusqueda);

        //    leer = comando.ExecuteReader();
        //    tabla.Load(leer);
        //    conexion.CerrarConexion();
        //    comando.Parameters.Clear();

        //    return tabla;

            

        //}


        public DataTable Buscar(string nombre)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarProducto";
            // Indica que el 'CommandText' es un procedimiento almacenado.
            comando.CommandType = CommandType.StoredProcedure;
            // Agrega el parámetro necesario para el procedimiento almacenado, usando el 'nombre' recibido como argumento.
            comando.Parameters.AddWithValue("@nombre", nombre);

            // Ejecuta el comando y asigna el resultado a 'leer', permitiendo la lectura de los datos devueltos por el procedimiento almacenado.
            leer = comando.ExecuteReader();
            // Carga los datos leídos en el 'DataTable' 'tabla'.
            tabla.Load(leer);
            //Cierra la conexión
            conexion.CerrarConexion();

            // Limpia los parámetros del comando para evitar conflictos en futuras ejecuciones.
            comando.Parameters.Clear();
            //Retorna
            return tabla;
        }




    }

}
