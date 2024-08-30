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
        // Esta instancia se utilizará para interactuar con los productos.
        CNProductos objetoCN = new CNProductos();
        // Se utiliza para realizar operaciones de edición y eliminación.
        public string IdProducto = null;
        // Inicialmente es 'false', lo que indica que se está en modo de inserción.
        public bool Editar = false;

        public Form1()
        {
            //Inicializa los componentes del formulario
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // Llama al método 'MostrarProductos' para cargar los productos en el DataGridView.
            MostrarProductos();
        }

        public void MostrarProductos()
        {
            // Establece la fuente de datos del 'dataGridView1' como el resultado del método 'MostrarProd' de la capa de negocio.
            dataGridView1.DataSource = objetoCN.MostrarProd();
            
            // Refresca el DataGridView para asegurarse de que se muestren los datos actualizados.
            dataGridView1.Refresh();
        }

        public void btnGuardar_Click(object sender, EventArgs e)
        {
            // Si no se está en modo de edición (es decir, es una inserción de un nuevo producto):
            if (Editar == false)
            {
                try
                {
                    // Llama al método 'InsertarPRod' de la capa de negocio para insertar un nuevo producto con los datos del formulario.
                    objetoCN.InsertarPRod(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se insertó correctamente.");
                    // Actualiza el DataGridView para mostrar los productos después de la inserción.
                    MostrarProductos();
                    limpiarForm(); // Limpia los campos del formulario.
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje de error en caso de que la inserción falle.
                    MessageBox.Show("No es posible insertar datos por: " + ex.Message);
                }
            }
            else if (Editar == true)
            {
                // Si se está en modo de edición:
                try
                {
                    // Llama al método 'EditarProd' de la capa de negocio para editar un producto existente con los datos del formulario y el ID del producto seleccionado.
                    objetoCN.EditarProd(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(txtStock.Text), Convert.ToInt32(IdProducto));
                    MessageBox.Show("Se editó correctamente.");
                    // Actualiza el DataGridView para mostrar los productos después de la edición.
                    MostrarProductos();
                    // Limpia los campos del formulario.
                    limpiarForm();
                    // Restaura el modo de inserción al desactivar el modo edición.
                    Editar = false;
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje de error en caso de que la edición falle.
                    MessageBox.Show("No es posible editar datos por: " + ex.Message);
                }
            }
        }

        public void btnEditar_Click(object sender, EventArgs e)
        {
            // Verifica que haya al menos una fila seleccionada en el DataGridView:
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Activa el modo edición.
                Editar = true;

                // Rellena los campos del formulario con los datos de la fila seleccionada.
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();

                // Almacena el ID del producto seleccionado en 'IdProducto' para poder editarlo.
                IdProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecciona una fila, por favor.");
            }
        }

        public void limpiarForm()
        {
            // Limpia todos los campos del formulario, dejándolos vacíos.
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
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
            //Llamamos al método para filtrar
            filtro();
        }

        public void filtro()
        {
            // Reinicializa el objeto 'objetoCN' de la capa de negocio.
            objetoCN = new CNProductos();

            // Obtiene el texto de búsqueda del cuadro de texto 'txtBuscar'.
            string nombreProducto = txtBuscar.Text;

            // Llamada al método Buscar y asignación del resultado a un DataGridView
            dataGridView1.DataSource = objetoCN.BuscarProducto(nombreProducto);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica que haya al menos una fila seleccionada en el DataGridView:
            if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obtiene el ID del producto seleccionado.
                    IdProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    // Llama al método 'EliminarPRod' de la capa de negocio para eliminar el producto seleccionado.
                    objetoCN.EliminarPRod(IdProducto);
                    MessageBox.Show("Eliminado correctamente.");
                    MostrarProductos(); // Actualiza el DataGridView.
            }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fila.");
                }


        }
    }

}
