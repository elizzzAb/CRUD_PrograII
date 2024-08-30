using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDConexion
    {
        // Declara un campo público 'conexion' de tipo 'SqlConnection' e instancia un nuevo objeto con la cadena de conexión proporcionada.
        public SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-GK1DJVHC\\SQLEXPRESS;Initial Catalog=Practica;Integrated Security=True;");

        public SqlConnection AbrirConexion()
        {
            // Verificamos si la conexión está cerrada ('ConnectionState.Closed').
            if (conexion.State == ConnectionState.Closed)
                conexion.Open(); // Si está cerrada, abre la conexión con la base de datos.
            // Retornamos el objeto 'conexion' ya sea abierto o si ya estaba abierto.
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            // Verifica si la conexión está abierta ('ConnectionState.Open').
            if (conexion.State == ConnectionState.Open)
                conexion.Close(); // Si está abierta, cierra la conexión con la base de datos.
            return conexion;
        }
    }
}
