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
        public CDConexion conexion = new CDConexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            //
            comando.Connection = conexion.AbrirConexion();
            //comando.CommandText = "SELECT * FROM Productos"; //Con código normal de la BD
            comando.CommandText = "MostrarProductos"; //Con Procedimiento Almacenado
            comando.CommandType = CommandType.StoredProcedure;
            //comando.CommandType = CommandType.Text; // Cambia a Text si no es un procedimiento almacenado

            leer = comando.ExecuteReader(); //Devuelve filas
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string desc, string marca, double precio, int stock)
        {

            //Procedimiento Almacenado
            comando.Connection = conexion.AbrirConexion();
            //comando.CommandText = $"insert into Productos values('{nombre}','{desc}','{marca}',{precio},{stock})"; //Con código normal de la BD
            comando.CommandText = "InsetarProductos"; //Con Procedimiento Almacenado
            //comando.CommandType = CommandType.Text; //Con código normal de la BD
            comando.CommandType = CommandType.StoredProcedure; //Con Procedimiento Almacenado

            //Agregamos valores a los partámetros del Procedimiento
            //con los parámetros que recibe el método.
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", precio);
           
            comando.ExecuteNonQuery(); //Solo ejecuta instrucciones
            comando.Parameters.Clear();
            //conexion.CerrarConexion();
        }

        public void Editar(string nombre, string descripcion, string marca, double precio, int stock, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos"; //Con Procedimiento Almacenado
            comando.CommandType = CommandType.StoredProcedure; //Con Procedimiento Almacenado
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery(); //Solo ejecuta instrucciones
            comando.Parameters.Clear();

        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpro", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public DataTable Buscar(string buscar)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarProductos"; // Procedimiento Almacenado
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@buscar", buscar);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            comando.Parameters.Clear();
            return tabla;
        }


    }
}
