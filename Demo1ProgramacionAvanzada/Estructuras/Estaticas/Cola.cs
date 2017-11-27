using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras.Estaticas
{
    public class Cola: Lista //Hereda de lista
    {
        public Cola(int cantidad) : base(cantidad) { } //Constructor heredado

        /// <summary>
        /// En una cola solamente se puede insertar en la última posición, este método no debe ser implementado
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="val"></param>
        public override void Insertar(int pos, int val)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// La inserción en la lista con este método se realiza secuencialmente, se utiliza la anterior implementación.
        /// </summary>
        /// <param name="val"></param>
        public override void Insertar(int val)
        {
            base.Insertar(val);
        }

        /// <summary>
        /// Extrae el primer elemento que ingresó a la lista
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int Extraer()
        {
            int val = arregloInterno[0];

            //Debo de correr los elementos que aun quedan en la cola
            for (int i = 0; i <= posFinal; i++) {
                if (i < posFinal) {
                    arregloInterno[i] = arregloInterno[i + 1];
                }
            }

            return val;
        }

        /// <summary>
        /// Devuelve los elementos del arreglo interno
        /// </summary>
        /// <returns>Arreglo de enteros internos</returns>
        public override int[] ObtenerElementos()
        {
            return base.ObtenerElementos();
        }

    }
}
