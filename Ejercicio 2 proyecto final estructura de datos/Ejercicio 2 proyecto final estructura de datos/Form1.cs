using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace Ejercicio_2_proyecto_final_estructura_de_datos
{
    public partial class CompletarLista : Form
    {
        LinkedListCompleter listCompleter = new LinkedListCompleter();
        

        int valorInicial = 0;
        int valorFinal = 0;



        public CompletarLista()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
             valorInicial = int.Parse(txtNumeroInicial.Text);

             valorFinal = int.Parse(txtNumeroFinal.Text);

            listCompleter.Agregar(valorInicial);

            listCompleter.CompleteList(valorFinal);

            this.PrintList();
        }
        public void PrintList()
        {
            Node actual = listCompleter.Cabeza;
            while (actual != null)
            {
                dataGridView1.Columns.Add("Lista" , "");
                dataGridView1.Rows.Add(actual.Valor + " ")  ;
                actual = actual.Siguiente;
            }
          
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}
