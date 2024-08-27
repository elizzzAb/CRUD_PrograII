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
            //comando.CommandText = "SELECT * FROM Productos";
            comando.CommandText = "MostrarProductos"; 
            comando.CommandType = CommandType.StoredProcedure;
            //comando.CommandType = CommandType.Text; // Cambia a Text si no es un procedimiento almacenado

            leer = comando.ExecuteReader(); //Devuelve filas
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string desc, string marca, double precio, int stock)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = $"insert into Productos values('{nombre}','{desc}','{marca}',{precio},{stock})";
            comando.CommandType = CommandType.Text;
            //comando.CommandType = CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue("@nombre", nombre);
            //comando.Parameters.AddWithValue("@descrip", desc);
            //comando.Parameters.AddWithValue("@Marca", marca);
            //comando.Parameters.AddWithValue("@precio", precio);
            //comando.Parameters.AddWithValue("@stock", precio);
            comando.ExecuteNonQuery(); //Solo ejecuta instrucciones
            //comando.Parameters.Clear();
            //conexion.CerrarConexion();
        }
    }
}
