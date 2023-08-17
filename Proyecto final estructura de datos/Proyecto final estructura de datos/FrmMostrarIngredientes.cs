﻿using System;
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
    public partial class FrmMostrarIngredientes : Form
    {



        public FrmMostrarIngredientes()
        {
          

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          Close();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MostrarIngredientes();
        }

        //1= Recorre el nombre del postre a consultar con la clase y reproduce la lista de ingredientes en esa posición.
        public void MostrarIngredientes()
        {

            string nombrePostre = txtNombrePostre.Text;

            FrmAgregarPostre frm = new FrmAgregarPostre();


            Postre postre = frm.BuscarPostre(nombrePostre);
            if (postre != null)
            {
                MessageBox.Show($"Ingredientes del {postre.Nombre}:");



                foreach (string ingrediente in postre.Ingredientes)
                {
                    DgvPostres.Columns.Add("Ingredientes","Ingredientes");
                    DgvPostres.Rows.Add(ingrediente);
                }
            }
            else
            {
               MessageBox.Show("El postre no existe.");
            }
        }
        }//Cierre clase
}//Cierre namespace
