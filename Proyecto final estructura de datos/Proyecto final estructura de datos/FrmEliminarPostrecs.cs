using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Proyecto_final_estructura_de_datos.FrmAgregarPostre;

namespace Proyecto_final_estructura_de_datos
{
    public partial class FrmEliminarPostrecs : Form
    {
        public FrmEliminarPostrecs()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        //1=Se busca el postre a eliminar del arreglo, se compara y si existe se elimina la clase completa incluyendo la lista de ingredientes en la respectiva posición.
        public void EliminarPostre()
        {
            FrmAgregarPostre frm = new FrmAgregarPostre();
            string nombrePostreEliminar = txtNombrePostreEliminar.Text;

            Postre postreEliminar = frm.BuscarPostre(nombrePostreEliminar);
            if (postreEliminar != null)
            {
                for (int i = 0; i < FrmAgregarPostre.cantidadPostres; i++)
                {
                    if (FrmAgregarPostre.postres[i] == postreEliminar)
                    {
                        for (int j = i; j < FrmAgregarPostre.cantidadPostres - 1; j++)
                        {
                            FrmAgregarPostre.postres[j] = FrmAgregarPostre.postres[j + 1];
                        }
                        FrmAgregarPostre.postres[FrmAgregarPostre.cantidadPostres - 1] = null;
                        FrmAgregarPostre.cantidadPostres--;

                        MessageBox.Show("Postre eliminado exitosamente.");
                        return;
                        
                    }
                    DgvPostres.DataSource = FrmAgregarPostre.postres;
                }
            }
            else
            {
                MessageBox.Show("El postre no existe.");
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.EliminarPostre();
        }
    }//
}//
