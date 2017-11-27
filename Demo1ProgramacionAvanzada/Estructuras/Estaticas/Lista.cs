using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras.Estaticas
{
    public class Lista
    {
        protected int[] arregloInterno; 
        protected int posInicial;
        protected int posFinal;
        public Lista(int cantidad)
        {
            if (cantidad > 0)
            {
                arregloInterno = new int[cantidad];
                posInicial = 0;
                posFinal = cantidad - 1;
            }
            else
            {
                throw new Exception("La cantidad debe ser mayor que 0");
            }
        }
        public virtual void Insertar(int pos, int val) 
        {
            if ((pos >= posInicial) && (pos <= posFinal))
            {
                arregloInterno[pos] = val;
            }
            else
            {
                throw new Exception("El rango de posicones es entre 0 y " + posFinal);
            }
        }
        public virtual void Insertar(int val)
        {
            for (int i = 0; i <= posFinal; i++)
            {
                if (arregloInterno[i] == 0)
                {
                    arregloInterno[i] = val;
                    return; 
                }
            }

            throw new Exception("Lista llena, por favor eliminar elementos o extraer"); 
        }

        public virtual int Extraer(int pos)
        {
            if ((pos >= posInicial) && (pos <= posFinal))
            {
                int val = arregloInterno[pos];
                arregloInterno[pos] = 0; 
                return val;
            }
            else
            {
                throw new Exception("El rango de posicones es entre 0 y " + posFinal);
            }
        }
        public virtual int[] ObtenerElementos() 
        {
            return arregloInterno;
        }
    }
}
