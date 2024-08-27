using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace EjercicioPracticoCRUD
{

    public partial class Form1 : Form
    {

        CNProductos objetoCN = new CNProductos();
        public string IdProducto = null;
        public bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        public void MostrarProductos()
        {
            CNProductos objeto = new CNProductos();

            dataGridView1.DataSource = objeto.MostrarProd();
        }

        public void btnGuardar_Click(object sender, EventArgs e)
        {

            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPRod(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se insertó correctamente.");
                    MostrarProductos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No es posible insertar datos por: " + ex.Message);
                }
            }

            if (Editar == true)
            {
                try
                {
                    double precio = Convert.ToDouble(txtPrecio.Text);
                    int stock = Convert.ToInt32(txtStock.Text);
                    int idProducto = Convert.ToInt32(IdProducto);

                    objetoCN.EditarProd(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, precio, stock, idProducto);
                    MessageBox.Show("Se editó correctamente.");
                    MostrarProductos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No es posible editar datos por: " + ex.Message);
                }
            }


        }

        public void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;

                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();

                IdProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();


            }
            else
                MessageBox.Show("Selecciona una fila, por favor.");
        }

        public void limpiarForm()
        {
            txtDescripcion.Clear();
            txtMarca.Text = "";
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Clear();
        }

        public void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                IdProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarPRod(IdProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProductos();
            }
            else
                MessageBox.Show("Selecciona una fila por favor.");

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string buscar = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(buscar))
            {
                dataGridView1.DataSource = objetoCN.BuscarProd(buscar);
            }
            else
            {
                MostrarProductos(); // Si no hay texto, muestra todos los productos
            }
        }
    }

}
