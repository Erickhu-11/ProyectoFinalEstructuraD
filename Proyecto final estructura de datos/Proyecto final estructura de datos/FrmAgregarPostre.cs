using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static Proyecto_final_estructura_de_datos.FrmAgregarPostre;

namespace Proyecto_final_estructura_de_datos
{
    
    public partial class FrmAgregarPostre : Form
    {
        public static Postre[] postres = new Postre[10];
        public static int cantidadPostres = 0;
        //1=Se crea la clase Postre que genera un arreglo de almacenamiento de nombres, que con cada uno se conecta a una lista con sus respectivos ingredientes
        public class Postre
        {
            public string Nombre { get; }
            public List<string> Ingredientes { get; } = new List<string>();

            public Postre(string nombre, List<string> ingredientes)
            {
                Nombre = nombre;
                Ingredientes = ingredientes;
            }
        }

        public FrmAgregarPostre()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.AgregarPostre();
            
        }

        //2=En este punto con la función Buscar Postre, compara el nombre del postre a buscar y lo compara con el arreglo de los nombres de la clase.
        public Postre BuscarPostre(string nombrePostre)
        {
            for (int i = 0; i < cantidadPostres; i++)
            {
                if (postres[i].Nombre.Equals(nombrePostre, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Postre encontrado");
                    return postres[i];
                }
            }
            return null;
        }
        //3=La función para agregar postre, compara la cantidad de postres para limitar el número maximo del arreglo
        public void AgregarPostre()
        {
            if (cantidadPostres >= 10)

            {
                

                    MessageBox.Show("Capacidad máxima de postres alcanzada. No se pueden agregar más postres");
                    return;

                
               
            }

            //Agrega nuevo postre almacenandolo a un nuevo espacio en el arreglo y lo linkea a la lista de ingredientes en esa posición
            string nombreNuevoPostre;

            nombreNuevoPostre = txtNombrePostre.Text;

            Postre postreExistente = BuscarPostre(nombreNuevoPostre);
            if (postreExistente == null)
            {
                string[] nuevosIngredientes = txtIngredientes.Text.Split(',');

                List<string> ingredientes = new List<string>();
                foreach (string nuevoIngrediente in nuevosIngredientes)
                {
                    string ingrediente = nuevoIngrediente.Trim();
                    if (!string.IsNullOrEmpty(ingrediente))
                    {
                        ingredientes.Add(ingrediente);
                    }
                }



                Postre nuevoPostre = new Postre(nombreNuevoPostre, ingredientes);
                postres[cantidadPostres] = nuevoPostre;
                cantidadPostres++;



                MessageBox.Show("Postre agregado exitosamente.");
            }
            else
            {
                MessageBox.Show("El postre ya existe.");
            }

            DgvAgregarPostres.DataSource = postres;


        }
        //4)Hace llamado a la función de agregar ingredientes para en la misma pantalla de AgregarPostre ingresarlos tambien
        private void button3_Click(object sender, EventArgs e)
        {
            FrmAgregarIngredientes frm = new FrmAgregarIngredientes();
            string NombrePostre = txtNombrePostre.Text;
            string[] NuevosIngredientes = txtIngredientes.Text.Split(',');
            frm.AgregarIngredientes(NombrePostre, NuevosIngredientes);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void FrmAgregarPostre_Load(object sender, EventArgs e)
        {
            
        }
        
    }// CIERRE DE CLASE
    }//CIERRE NAMESPACE
       
