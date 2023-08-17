using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_final_estructura_de_datos.FrmAgregarPostre;

namespace Proyecto_final_estructura_de_datos
{
    public partial class FrmEliminarIngredientes : Form
    {
        public FrmEliminarIngredientes()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //1= Se colocan los indices de los ingredientes a eliminar en la lista, y se comparan para borrar con el ID del ingrediente.
        public void EliminarIngredientes()
        {
            string nombrePostre = txtNombrePostre.Text;
            FrmAgregarPostre frm = new FrmAgregarPostre();
            Postre postre = frm.BuscarPostre(nombrePostre);

            if (!string.IsNullOrEmpty(txtIngredientes.Text))
                {

                string[] numerosIngredientesEliminar = txtIngredientes.Text.Split(',');

                List<int> indicesEliminar = new List<int>();
                foreach (string numero in numerosIngredientesEliminar)
                {
                    if (int.TryParse(numero.Trim(), out int indice) && indice >= 1 && indice <= postre.Ingredientes.Count)
                    {
                        indicesEliminar.Add(indice - 1);
                    }
                }

                //2= Por ultimo se acomoda la lista para que quede sin el ingrediente anteriormente eliminado
                indicesEliminar.Sort();
                indicesEliminar.Reverse();

                foreach (int indiceEliminar in indicesEliminar)
                {
                    postre.Ingredientes.RemoveAt(indiceEliminar);
                }

                MessageBox.Show("Ingredientes eliminados exitosamente.");

            }
            else
            {
                MessageBox.Show("El postre no existe o no ingreso el numero de los ingredientes.");
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
           this.EliminarIngredientes();
        }

        private void FrmEliminarIngredientes_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Ingrese los números de los ingredientes a eliminar separados por comas (ejemplo: 1, 3, 5): ");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        //3= Igualmente se aplica la función de buscar postre en la clase para llamar a lista con el arreglo.
        public void Buscar()
        {
            FrmAgregarPostre frm = new FrmAgregarPostre();

            string nombrePostre = txtNombrePostre.Text;

            Postre postre = frm.BuscarPostre(nombrePostre);
            if (postre != null)
            {
                MessageBox.Show($"Ingredientes del {postre.Nombre}:");

                for (int i = 0; i < postre.Ingredientes.Count; i++)
                {
                    DgvPostres.Columns.Add("Ingredientes", "Ingrediente");
                    DgvPostres.Rows.Add($"{i + 1}) {postre.Ingredientes[i]}");
                    DgvPostres.ReadOnly = true;

                }
            }
        }
    }//
}//
