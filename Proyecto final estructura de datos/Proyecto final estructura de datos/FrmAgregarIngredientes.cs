using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_final_estructura_de_datos.FrmAgregarPostre;

namespace Proyecto_final_estructura_de_datos
{
    public partial class FrmAgregarIngredientes : Form
    {
        public FrmAgregarIngredientes()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        
        private void button3_Click(object sender, EventArgs e)
        {

            string NombrePostre = txtNombrePostre.Text;
            string[] NuevosIngredientes = txtIngredientes.Text.Split(',');
            this.AgregarIngredientes(NombrePostre,NuevosIngredientes);

        }
        //1= Para la función toma el nombre del postre en el arreglo, y le agrega los ingredientes a la lista en la misma posición.
        public void AgregarIngredientes(string NombrePostre, string[] NuevosIngredientes)
        {
            FrmAgregarPostre frm = new FrmAgregarPostre();

            Postre postre = frm.BuscarPostre(NombrePostre);
            if (postre != null)
            {

                foreach (string nuevoIngrediente in NuevosIngredientes)
                {
                    string ingrediente = nuevoIngrediente.Trim();
                    if (!string.IsNullOrEmpty(ingrediente))
                    {
                        postre.Ingredientes.Add(ingrediente);
                    }
                }



                MessageBox.Show("Ingredientes agregados exitosamente.");
            }
            else
            {
                MessageBox.Show("El postre no existe.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmAgregarIngredientes_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIngredientes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
