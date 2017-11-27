using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estructuras.Estaticas;

namespace UIConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista miLista = new Lista(5);
            Cola miCola = new Cola(5);

            char option;
            do
            {
                Console.Clear();
                Console.WriteLine("Seleccione su opción");
                Console.WriteLine("A: Lista");
                Console.WriteLine("B: Pila");
                Console.WriteLine("C: Cola");
                Console.WriteLine("D: Salir");

                option = Convert.ToChar(Console.ReadLine());

                OpcionesGenerales(option, miLista, miCola);

            }while(option != 'D');
        }

        static void OpcionesGenerales(char opt, Lista lista, Cola cola) 
        {
            switch (opt)
            {
                case 'A':
                    {
                        OpcionesLista(lista);
                    }
                    break;
                case 'B':
                    {
                    }
                    break;
                case 'C':
                    {
                        OpcionesCola(cola);
                    }
                    break;
            }
        }
        static void OpcionesLista(Lista lista) 
        {
            Console.Clear();
            Console.WriteLine("Seleccione su opción");
            Console.WriteLine("A: Insertar en posición específica");
            Console.WriteLine("B: Insertar secuencial");
            Console.WriteLine("C: Extraer");
            Console.WriteLine("D: Mostrar");

            char option = Convert.ToChar(Console.ReadLine());

            switch (option)
            {
                case 'A':
                    {
                        try
                        {
                            Console.WriteLine("Ingrese la posición");
                            int pos = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese el valor");
                            int val = Convert.ToInt32(Console.ReadLine());
                            lista.Insertar(pos, val);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 'B':
                    {
                        try
                        {
                            Console.WriteLine("Ingrese el valor");
                            int val = Convert.ToInt32(Console.ReadLine());
                            lista.Insertar(val);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 'C':
                    {
                        try
                        {
                            Console.WriteLine("Ingrese la posición que desea extraer");
                            int pos = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("El elemento extaido es: " + lista.Extraer(pos));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 'D':
                    {
                        for (int i = 0; i < lista.ObtenerElementos().Length; i++) 
                        {
                            Console.WriteLine("Elemento en la posicion " + i + ":" + lista.ObtenerElementos()[i]);
                        }
                    }
                    break;
                default:
                    Console.Clear();
                    break;

            }
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }
        static void OpcionesCola(Cola cola)
        {
            Console.Clear();
            Console.WriteLine("Seleccione su opción");           
            Console.WriteLine("A: Insertar");
            Console.WriteLine("B: Extraer");
            Console.WriteLine("C: Mostrar");

            char option = Convert.ToChar(Console.ReadLine());

            switch (option)
            {
                case 'A':
                    {
                        try
                        {
                            Console.WriteLine("Ingrese el valor");
                            int val = Convert.ToInt32(Console.ReadLine());
                            cola.Insertar(val);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 'B':
                    {
                        try
                        {
                            Console.WriteLine("El elemento extaido es: " + cola.Extraer());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 'C':
                    {
                        for (int i = 0; i < cola.ObtenerElementos().Length; i++)
                        {
                            Console.WriteLine("Elemento en la posicion " + i + ":" + cola.ObtenerElementos()[i]);
                        }
                    }
                    break;
                default:
                    Console.Clear();
                    break;

            }
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}
