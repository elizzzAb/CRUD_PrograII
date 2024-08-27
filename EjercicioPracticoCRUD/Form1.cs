﻿using System;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.InsertarPRod(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                MessageBox.Show("Se insertó correctamente.");
                MostrarProductos();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No es posible insertar datos por: " + ex);
            }
            
        }
    }
}
