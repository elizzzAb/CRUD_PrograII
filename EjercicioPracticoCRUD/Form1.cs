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
            dataGridView1.DataSource = objetoCN.MostrarProd();
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
            else if (Editar == true)
            {
                try
                {
                    objetoCN.EditarProd(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(txtStock.Text), Convert.ToInt32(IdProducto));
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

                IdProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecciona una fila, por favor.");
            }
        }

        public void limpiarForm()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        public void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                IdProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarPRod(IdProducto);
                MessageBox.Show("Eliminado correctamente.");
                MostrarProductos();
            }
            else
            
                MessageBox.Show("Por favor, selecciona una fila.");





        }

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            //{
            //    try
            //    {
            //        dataGridView1.DataSource = objetoCN.BuscarProd(txtBuscar.Text);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("No es posible realizar la búsqueda: " + ex.Message);
            //    }
            //}
            //else
            //{
            //    MostrarProductos(); // Mostrar todo si no se ingresa texto de búsqueda
            //}




        }


        //Solo se puede usando el 'Nombre del Producto'.
        public void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        public void filtro()
        {
            objetoCN = new CNProductos();

            string nombreProducto = txtBuscar.Text;

            // Llamada al método Buscar y asignación del resultado a un DataGridView
            dataGridView1.DataSource = objetoCN.BuscarProducto(nombreProducto);

        }


    }

}
