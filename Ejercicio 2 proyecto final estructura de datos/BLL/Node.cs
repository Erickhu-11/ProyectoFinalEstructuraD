using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Node
    {
        public int Valor { get; set; }
        public Node Siguiente { get; set; }

        public Node(int value)
        {
            Valor = value;
            Siguiente = null;
        }


    }
    public class LinkedListCompleter
    {
        public Node Cabeza { get; set; }

        public LinkedListCompleter()
        {
            Cabeza = null;
        }

        public void Agregar(int value)
        {
            if (Cabeza == null)
            {
                Cabeza = new Node(value);
            }
            else
            {
                Node actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = new Node(value);
            }
        }

        public void CompleteList(int valorFinal)
        {
            Node actual = Cabeza;
            int valorSiguiente = Cabeza.Valor + 1;

            while (valorSiguiente <= valorFinal)
            {
                if (actual.Siguiente == null || actual.Siguiente.Valor > valorSiguiente)
                {
                    Node newNode = new Node(valorSiguiente);
                    newNode.Siguiente = actual.Siguiente;
                    actual.Siguiente = newNode;
                }
                actual = actual.Siguiente;
                valorSiguiente++;
            }

           
        }
        

    }
}
