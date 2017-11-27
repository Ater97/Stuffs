﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Arbol_B
{
    public class BTree<TLlave, T> where TLlave : IComparable<TLlave> where T : IComparable<T>
    {
        Fabrica<TLlave, T> fabricar;
        BNode<TLlave, T> root;
        string llaveNull = "####################################";
        int grado;

        public BTree(string FileName, int Grado)
        {
            fabricar = new Fabrica<TLlave, T>(FileName, Grado);
            root = null;
            grado = Grado;
        }

        public BTree(string FileName)
        {
            fabricar = new Fabrica<TLlave, T>(FileName);
            root = fabricar.TraerNodo(fabricar.ObtenerRaiz());
            grado = fabricar.ObtenerGrado();
        }
        #region Insertar
        //Metodos Insertar
        public void Insertar(TLlave key, T dato)
        {
            if (fabricar.Empty())
            {
                //Cuando lo que este insertando sea la raiz
                int raiz = fabricar.ObtenerPosicionLibre();
                fabricar.CambiarRaiz(raiz);
                fabricar.NodoDeFabrica();
                BNode<TLlave, T> nodo = fabricar.TraerNodo(raiz);
                nodo.Llaves[0] = key.ToString();
                nodo.Datos[0] = dato.ToString();
                fabricar.GuardarNodo(nodo.Informacion());

                //Modificar tamaño
                int tamanio = fabricar.ObtenerTamaño();
                tamanio++;
                fabricar.CambiarTamaño(tamanio);
            }
            else
            {
                //Cuando no se incerta en la raiz   
                Insertando(key, dato);

                //Modificar tamaño
                int tamanio = fabricar.ObtenerTamaño();
                tamanio++;
                fabricar.CambiarTamaño(tamanio);
            }
        }

        private void Insertando(TLlave key, T dato)
        {
            int raiz = fabricar.ObtenerRaiz();
            BNode<TLlave, T> nodo = fabricar.TraerNodo(raiz);

            while (!EsHoja(nodo.Hijos))
            {
                int hijo = ADondeIr(nodo.Llaves, key);
                nodo = fabricar.TraerNodo(int.Parse(nodo.Hijos[hijo]));
            }

            if (HayEspacio(nodo.Llaves))
            {
                //Si hay espacio para insertar el elemento
                nodo = InsertaEnNodoHoja(nodo, key, dato);
                fabricar.GuardarNodo(nodo.Informacion());
            }
            else
            {
                // Esta Lleno, entonces hay que crear nuevos nodos :s
                InsertarEnNodoLleno(nodo, key, dato);
            }
        }

        private BNode<TLlave, T> InsertaEnNodoHoja(BNode<TLlave, T> nodo, TLlave key, T dato)
        {
            int i = 0;

            for (i = 0; i < nodo.Llaves.Count; i++)
            {
                //Si en caso el dato era mayor a todos los anteriores se inserta en la primera posicion
                //vacia que encuentre

                if (nodo.Llaves[i] == llaveNull)
                {
                    nodo.Llaves[i] = key.ToString();
                    nodo.Datos[i] = dato.ToString();
                    return nodo;
                }
                else
                {
                    if (!(key.ToString().CompareTo(nodo.Llaves[i]) > 0))
                    {
                        //Si la llave es menor a la llave del registro ingresa e inserta el dato en esa posicion y
                        //automaticamente se corren los registros...

                        //Llaves
                        nodo.Llaves.Insert(i, key.ToString());
                        nodo.Llaves.RemoveAt(nodo.Llaves.Count - 1);

                        //Datos
                        nodo.Datos.Insert(i, dato.ToString());
                        nodo.Datos.RemoveAt(nodo.Llaves.Count - 1);

                        return nodo;
                    }
                }
            }

            return nodo;
        }

        private void InsertarEnNodoLleno(BNode<TLlave, T> nodo, TLlave key, T dato)
        {
            string llave = key.ToString();
            string info = dato.ToString();
            BNode<TLlave, T> Padre;
            BNode<TLlave, T> Nuevo;
            BNode<TLlave, T> hijo1 = null;
            BNode<TLlave, T> hijo2 = null;
            int i, j;

            bool salir = false;

            do
            {
                if (nodo == null)
                {
                    int posicion = fabricar.ObtenerPosicionLibre();
                    fabricar.NodoDeFabrica();
                    fabricar.CambiarRaiz(posicion);
                    nodo = fabricar.TraerNodo(posicion);
                    root = nodo;

                    //Cambiar altura
                    int altura = fabricar.ObtenerAltura();
                    altura++;
                    fabricar.CambiarAltura(altura);
                }

                Padre = fabricar.TraerNodo(nodo.Padre);

                if (!HayEspacio(nodo.Llaves))
                {
                    //Overflow

                    List<string> lista = new List<string>();
                    List<string> listaDatos = new List<string>();
                    List<string> listapunt = new List<string>();

                    //Se crea el nodo Derecho
                    int libre = fabricar.ObtenerPosicionLibre();
                    fabricar.NodoDeFabrica();
                    Nuevo = fabricar.TraerNodo(libre);

                    //Se crean listas para encontrar el nodo que debe subir
                    i = 0;

                    while ((llave.CompareTo(nodo.Llaves[i]) > 0) && (i < grado - 1))
                    {
                        lista.Insert(i, nodo.Llaves[i]);
                        listaDatos.Insert(i, nodo.Datos[i]);
                        listapunt.Insert(i, nodo.Hijos[i]);
                        i++;

                        if (i == nodo.Llaves.Count())
                        {
                            break;
                        }

                    }

                    lista.Insert(i, llave);
                    listaDatos.Insert(i, info);

                    if (hijo1 != null)
                    {
                        listapunt.Insert(i, hijo1.Posicion.ToString("D11"));
                    }
                    else
                    {
                        listapunt.Insert(i, int.MinValue.ToString());
                    }

                    if (hijo2 != null)
                    {
                        listapunt.Insert(i + 1, hijo2.Posicion.ToString("D11"));
                    }
                    else
                    {
                        listapunt.Insert(i + 1, int.MinValue.ToString());
                    }


                    while (i < grado - 1)
                    {
                        lista.Insert(i + 1, nodo.Llaves[i]);
                        listaDatos.Insert(i + 1, nodo.Datos[i]);
                        listapunt.Insert(i + 2, nodo.Hijos[i + 1]);
                        i++;
                    }


                    //Se reconoce cual es el centro del nodo.

                    int centro = 0;

                    if ((lista.Count % 2) == 0)
                    {
                        //Grado Par
                        centro = (lista.Count / 2) - 1;
                    }
                    else
                    {
                        //Grado Impar
                        centro = lista.Count / 2;
                    }


                    //Dividir los nodos

                    //Nodo Izquierdo

                    for (j = 0; j < nodo.Llaves.Count; j++)
                    {
                        if (j < centro)
                        {
                            nodo.Llaves[j] = lista[j];
                            nodo.Datos[j] = listaDatos[j];
                            nodo.Hijos[j] = listapunt[j];
                        }
                        else
                        {
                            nodo.Llaves[j] = llaveNull;
                            nodo.Datos[j] = llaveNull;
                            nodo.Hijos[j] = int.MinValue.ToString();
                        }
                    }


                    //Para limpiar los demas nodos :s
                    nodo.Hijos[centro] = listapunt[centro];

                    if (centro != nodo.Hijos.Count)
                    {
                        for (int x = centro + 1; x < nodo.Hijos.Count; x++)
                        {
                            nodo.Hijos[x] = int.MinValue.ToString();
                        }
                    }

                    //Nodo Derecho

                    for (j = 0; j < Nuevo.Llaves.Count; j++)
                    {
                        if (grado % 2 == 0)
                        {
                            if (j <= centro)
                            {
                                Nuevo.Llaves[j] = lista[centro + j + 1];
                                Nuevo.Datos[j] = listaDatos[centro + j + 1];
                                Nuevo.Hijos[j] = listapunt[centro + j + 1];
                            }
                        }
                        else
                        {
                            if (j < centro)
                            {
                                Nuevo.Llaves[j] = lista[centro + j + 1];
                                Nuevo.Datos[j] = listaDatos[centro + j + 1];
                                Nuevo.Hijos[j] = listapunt[centro + j + 1];
                            }
                        }

                    }

                    Nuevo.Hijos[EspaciosUsados(Nuevo.Llaves)] = listapunt[grado];

                    //Hay que corregir los hijos en cada nodo creado

                    for (j = 0; j <= EspaciosUsados(nodo.Llaves); j++)
                    {
                        BNode<TLlave, T> temp = fabricar.TraerNodo(int.Parse(nodo.Hijos[j]));

                        if (temp != null)
                        {
                            temp.Padre = nodo.Posicion;
                            fabricar.GuardarNodo(temp.Informacion());
                        }
                    }
                    //if (nodo->Hijos[j])
                    //    (nodo->Hijos[j])->Padre = nodo;

                    for (j = 0; j <= EspaciosUsados(Nuevo.Llaves); j++)
                    {
                        BNode<TLlave, T> temp = fabricar.TraerNodo(int.Parse(Nuevo.Hijos[j]));
                        if (temp != null)
                        {
                            temp.Padre = Nuevo.Posicion;
                            fabricar.GuardarNodo(temp.Informacion());
                        }
                    }

                    llave = lista[centro];
                    info = listaDatos[centro];
                    hijo1 = nodo;
                    hijo2 = Nuevo;
                    fabricar.GuardarNodo(hijo1.Informacion());
                    fabricar.GuardarNodo(hijo2.Informacion());
                    nodo = Padre;
                }
                else
                {
                    //Continua insertando
                    //Inserta la clave en su lugar

                    i = 0;

                    if (EspaciosUsados(nodo.Llaves) > 0)
                    {
                        int llavesUsadas = EspaciosUsados(nodo.Llaves);

                        while ((i < llavesUsadas) && (llave.CompareTo(nodo.Llaves[i]) > 0)) i++;
                        {
                            for (j = llavesUsadas; j > i; j--)
                            {
                                nodo.Llaves[j] = nodo.Llaves[j - 1];
                                nodo.Datos[j] = nodo.Datos[j - 1];
                            }

                            for (j = llavesUsadas + 1; j > i; j--)
                            {
                                nodo.Hijos[j] = nodo.Hijos[j - 1];
                            }
                        }
                    }

                    nodo.Llaves[i] = llave;
                    nodo.Datos[i] = info;

                    //Asignar hijo 1 al nodo
                    if (hijo1 != null)
                    {
                        nodo.Hijos[i] = int.Parse(hijo1.Posicion.ToString()).ToString("D11");
                        hijo1.Padre = nodo.Posicion;
                    }
                    else
                    {
                        nodo.Hijos[i] = int.MinValue.ToString();
                    }

                    //Asignar hijo 2 al nodo
                    if (hijo2 != null)
                    {
                        nodo.Hijos[i + 1] = int.Parse(hijo2.Posicion.ToString()).ToString("D11");
                        hijo2.Padre = nodo.Posicion;
                    }
                    else
                    {
                        nodo.Hijos[i + 1] = int.MinValue.ToString();
                    }

                    //Guardamos los datos
                    fabricar.GuardarNodo(nodo.Informacion());
                    fabricar.GuardarNodo(hijo1.Informacion());
                    fabricar.GuardarNodo(hijo2.Informacion());

                    salir = true;
                }

            }
            while (!salir);
        }
        #endregion

        //Metodos de Busqueda

        public int Buscar(TLlave key, T dato)
        {
            BNode<TLlave, T> nodo;

            if (fabricar.Empty())
            {
                return int.MinValue;
            }
            else if(fabricar.buscar(key, dato))
            {
                return int.MinValue;
            }
            else
            {
                int raiz = fabricar.ObtenerRaiz();
                nodo = fabricar.TraerNodo(raiz);

                //Inicia la busqueda desde la raiz.
                while (nodo != null)
                {
                    for (int i = 0; i < nodo.Datos.Count; i++)
                    {
                        if (nodo.Datos[i] == dato.ToString())
                        {
                            return nodo.Posicion;
                        }
                    }

                    int siguiente = int.Parse(nodo.Hijos[ADondeIr(nodo.Llaves, key)]);
                    nodo = fabricar.TraerNodo(siguiente);
                }

                return int.MinValue;
            }
        }


        private bool HayEspacio(List<string> llaves)
        {
            return llaves.Contains(llaveNull);
        }

        private int EspaciosUsados(List<string> llaves)
        {
            int espacios = 0;

            for (int i = 0; i < llaves.Count; i++)
            {
                if (llaves[i] != llaveNull)
                {
                    espacios++;
                }
            }
            return espacios;
        }

        /// <summary>
        /// Posicion vacia de las llaves.
        /// </summary>
        /// <param name="nodo"></param>
        /// <returns></returns>
        private int EncontrarPosicionVacia(string[] llaves)
        {
            //Encontrar la posicion vacia mas cercana
            for (int x = 0; x < llaves.Length; x++)
            {
                if (llaves[x] == llaveNull)
                {
                    return x;
                }
            }

            return 0;
        }

        private bool EsHoja(List<string> hijos)
        {
            for (int x = 0; x < hijos.Count; x++)
            {
                if (hijos[x] != int.MinValue.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        private int ADondeIr(List<string> llaves, TLlave key)
        {
            //El arreglo que se recibe es el arreglo de llaves.
            int hijo = grado - 1;

            for (int i = 0; i < grado - 1; i++)
            {
                if (llaves[i] != llaveNull)
                {
                    if (!(key.ToString().CompareTo(llaves[i]) > 0))
                    {
                        hijo = i;
                        return hijo;
                    }
                }
                else
                {
                    hijo = i;
                    return hijo;
                }
            }
            return hijo;
        }


        #region Eliminar
        public bool Elimina(TLlave key)
        {
            if (fabricar.Empty())
            {
                return false;
            }
            else
            {
                int raiz = fabricar.ObtenerRaiz();
                BNode<TLlave, T> nodo = fabricar.TraerNodo(raiz);
                EliminarInterno(nodo, key);

                //βετα
                if (nodo.Datos.Count() == 0 && !EsHoja(nodo.Hijos))
                {
                    int altura = fabricar.ObtenerAltura();
                    altura--;
                    fabricar.CambiarAltura(altura);
                }
                return true;
            }
        }

        private int aDondeir(List<string> llaves, TLlave key, int casilla)
        {
            //τερμιναδο
            if (llaves.Count() == casilla)
            {
                if (llaves.Contains("####################################"))
                {
                    int index = Array.IndexOf(llaves.ToArray(), "####################################");
                    return index - 1;
                }
                return (llaves.Count() - 1);
            }
            if (llaves[casilla].CompareTo(key) < 0)
            {
                return aDondeir(llaves, key, casilla + 1);
            }
            else
                return casilla;
        }

        private void EliminarInterno(BNode<TLlave, T> node, TLlave keyToDelete)
        {
            //τερμιναδο
            int i = Array.IndexOf(node.Llaves.ToArray(), keyToDelete.ToString());
            if (i < 0)
            {
                i = aDondeir(node.Llaves, keyToDelete, 0);
                if (i < 0) //nodo nulo, eliminar nodo completamente....
                    i = 0;
            }
            if (i < node.Llaves.Count() && node.Llaves[i].CompareTo(keyToDelete) == 0)
            {
                EliminarLlaveNodo(node, keyToDelete, i);
                return;
            }
            if (!EsHoja(node.Hijos))
            {
                EliminarLlavedeSubarbol(node, keyToDelete, i);
            }
        }

        private void EliminarLlaveNodo(BNode<TLlave, T> node, TLlave keyToDelete, int keyIndexInNode)
        {
            //τερμιναδο
            if (EsHoja(node.Hijos))
            {
                // if ((node.Datos.Count() >1))
                {
                    string KeyToRemove = node.Llaves[keyIndexInNode];
                    string ItemToRemove = node.Datos[keyIndexInNode];
                    node.Datos = node.Datos.Where(val => val != ItemToRemove).ToArray().ToList();
                    node.Llaves = node.Llaves.Where(val => val != KeyToRemove).ToArray().ToList();
                    fabricar.GuardarNodo(node.Informacion());

                    int tamanio = fabricar.ObtenerTamaño();
                    tamanio--;
                    fabricar.CambiarTamaño(tamanio);
                    return;
                }
                //γθμπλεταρ
                //Eliminar nodo completamente
            }
            //γθμπλεταρ
            BNode<TLlave, T> predecessorChild = fabricar.TraerNodo(keyIndexInNode);

            if (predecessorChild.Datos.Count() >= grado)
            {
                //   BNode<TLlave, T> predecessor = DeletePredecessor(predecessorChild);
            }
        }

        //private BNode<TLlave, T> DeletePredecessor(BNode<TLlave, T> node)
        //{
        //    //γθμπλεταρ
        //    if (EsHoja(node.Hijos))
        //    {
        //        string ItemToRemove = node.Datos[node.Datos.Count() - 1];
        //        node.Datos = node.Datos.Where(val => val != ItemToRemove).ToArray();
        //        node.Llaves = node.Llaves.Where(val => val != ItemToRemove).ToArray();

        //    }
        //}

        private void EliminarLlavedeSubarbol(BNode<TLlave, T> parentNode, TLlave keyToDelete, int subtreeIndexInNode)
        {
            BNode<TLlave, T> childNode = fabricar.TraerNodo(int.Parse(parentNode.Hijos[subtreeIndexInNode]));

            if ((childNode.Datos.Count() > 0))
            {
                int leftIndex = subtreeIndexInNode - 1;
                int rightIndex = subtreeIndexInNode + 1;

                BNode<TLlave, T> leftSibling = subtreeIndexInNode > 0 ?
                    fabricar.TraerNodo(int.Parse(parentNode.Hijos[leftIndex])) : null;
                BNode<TLlave, T> rightSibling = subtreeIndexInNode < parentNode.Hijos.Count() - 1 ?
                    fabricar.TraerNodo(int.Parse(parentNode.Hijos[rightIndex])) : null;

                if (leftSibling != null && leftSibling.Datos.Count() > fabricar.ObtenerGrado() - 1)
                {

                    //βετα
                    List<string> lst = childNode.Datos.OfType<string>().ToList();
                    lst.Insert(0, parentNode.Datos[subtreeIndexInNode]);
                    childNode.Datos = lst;

                    lst = childNode.Llaves.OfType<string>().ToList();
                    lst.Insert(0, parentNode.Llaves[subtreeIndexInNode]);
                    childNode.Llaves = lst;

                    parentNode.Datos[subtreeIndexInNode] = leftSibling.Datos.Last();

                    string KeyToRemove = leftSibling.Llaves[leftSibling.Datos.Count() - 1];
                    string ItemToRemove = leftSibling.Datos[leftSibling.Datos.Count() - 1];
                    leftSibling.Datos = leftSibling.Datos.Where(val => val != ItemToRemove).ToArray().ToList();
                    leftSibling.Llaves = leftSibling.Llaves.Where(val => val != KeyToRemove).ToArray().ToList();

                    if (!EsHoja(leftSibling.Hijos))
                    {
                        //βετα
                        lst = childNode.Hijos.OfType<string>().ToList();
                        lst.Insert(0, leftSibling.Hijos.Last());
                        childNode.Hijos = lst;

                        KeyToRemove = leftSibling.Hijos[leftSibling.Hijos.Count() - 1];
                        leftSibling.Hijos = leftSibling.Hijos.Where(val => val != KeyToRemove).ToArray().ToList();

                    }
                    fabricar.GuardarNodo(leftSibling.Informacion());
                    fabricar.GuardarNodo(parentNode.Informacion());
                    fabricar.GuardarNodo(childNode.Informacion());
                }
                else if (rightSibling != null && rightSibling.Datos.Count() > fabricar.ObtenerGrado() - 1)
                {
                    //βετα
                    childNode.Hijos[childNode.Hijos.Count() - 1] = (parentNode.Hijos[subtreeIndexInNode]);
                    parentNode.Datos[subtreeIndexInNode] = rightSibling.Datos.First();
                    parentNode.Llaves[subtreeIndexInNode] = rightSibling.Llaves.First();

                    string ItemToRemove = rightSibling.Datos[0];
                    rightSibling.Datos = rightSibling.Datos.Where(val => val != ItemToRemove).ToArray().ToList();

                    ItemToRemove = rightSibling.Llaves[0];
                    rightSibling.Llaves = rightSibling.Llaves.Where(val => val != ItemToRemove).ToArray().ToList();

                    if (!EsHoja(rightSibling.Hijos))
                    {
                        List<string> lst = childNode.Hijos.OfType<string>().ToList();
                        lst.Insert(0, rightSibling.Hijos.Last());
                        childNode.Hijos = lst;

                        ItemToRemove = rightSibling.Hijos[0];
                        rightSibling.Hijos = rightSibling.Hijos.Where(val => val != ItemToRemove).ToArray().ToList();
                    }
                    fabricar.GuardarNodo(rightSibling.Informacion());
                    fabricar.GuardarNodo(parentNode.Informacion());
                    fabricar.GuardarNodo(childNode.Informacion());
                }
                else
                {
                    //βετα
                    if (leftSibling != null)
                    {
                        List<string> lst = childNode.Datos.OfType<string>().ToList();
                        lst.Insert(0, parentNode.Datos[subtreeIndexInNode]);
                        childNode.Datos = lst;

                        lst = childNode.Llaves.OfType<string>().ToList();
                        lst.Insert(0, parentNode.Llaves[subtreeIndexInNode]);
                        childNode.Llaves = lst;

                        var oldEntries = childNode.Datos;
                        var oldEntriesKey = childNode.Llaves;
                        childNode.Datos = leftSibling.Datos;
                        childNode.Llaves = leftSibling.Llaves;

                        var a = new string[oldEntries.Count + childNode.Datos.Count];
                        childNode.Datos.CopyTo(a, 0);
                        oldEntries.CopyTo(a, childNode.Datos.Count);

                        a = new string[oldEntriesKey.Count + childNode.Llaves.Count];
                        childNode.Llaves.CopyTo(a, 0);
                        oldEntriesKey.CopyTo(a, childNode.Llaves.Count);

                        if (!EsHoja(leftSibling.Hijos))
                        {
                            //βετα
                            var oldChildren = childNode.Hijos;
                            childNode.Hijos = leftSibling.Hijos;

                            a = new string[oldEntries.Count + childNode.Datos.Count];
                            childNode.Datos.CopyTo(a, 0);
                            oldEntries.CopyTo(a, childNode.Datos.Count);

                            a = new string[oldEntriesKey.Count + childNode.Llaves.Count];
                            childNode.Llaves.CopyTo(a, 0);
                            oldEntriesKey.CopyTo(a, childNode.Llaves.Count);
                        }

                        string ItemToRemove = parentNode.Hijos[leftIndex];
                        parentNode.Hijos = parentNode.Hijos.Where(val => val != ItemToRemove).ToArray().ToList();

                        ItemToRemove = parentNode.Datos[subtreeIndexInNode];
                        parentNode.Datos = parentNode.Datos.Where(val => val != ItemToRemove).ToArray().ToList();

                        ItemToRemove = parentNode.Llaves[subtreeIndexInNode];
                        parentNode.Llaves = parentNode.Llaves.Where(val => val != ItemToRemove).ToArray().ToList();
                        fabricar.GuardarNodo(parentNode.Informacion());
                        fabricar.GuardarNodo(childNode.Informacion());
                    }
                    else if (rightSibling != null)
                    {
                        //βετα
                        childNode.Datos[childNode.Datos.Count() - 1] = (parentNode.Datos[subtreeIndexInNode]);
                        childNode.Llaves[childNode.Llaves.Count() - 1] = (parentNode.Llaves[subtreeIndexInNode]);
                        if (rightSibling != null)
                        {
                            var a = new string[rightSibling.Datos.Count + childNode.Datos.Count];
                            childNode.Datos.CopyTo(a, 0);
                            rightSibling.Datos.CopyTo(a, childNode.Datos.Count);

                            a = new string[rightSibling.Llaves.Count + childNode.Llaves.Count];
                            childNode.Llaves.CopyTo(a, 0);
                            rightSibling.Llaves.CopyTo(a, childNode.Llaves.Count);

                            if (!EsHoja(rightSibling.Hijos))
                            {
                                a = new string[rightSibling.Hijos.Count + childNode.Hijos.Count];
                                childNode.Hijos.CopyTo(a, 0);
                                rightSibling.Hijos.CopyTo(a, childNode.Hijos.Count);
                            }

                            string ItemToRemove = parentNode.Hijos[rightIndex];
                            parentNode.Hijos = parentNode.Hijos.Where(val => val != ItemToRemove).ToArray().ToList();

                            ItemToRemove = parentNode.Datos[subtreeIndexInNode];
                            parentNode.Datos = parentNode.Datos.Where(val => val != ItemToRemove).ToArray().ToList();

                            ItemToRemove = parentNode.Llaves[subtreeIndexInNode];
                            parentNode.Llaves = parentNode.Llaves.Where(val => val != ItemToRemove).ToArray().ToList();

                            fabricar.GuardarNodo(parentNode.Informacion());
                            fabricar.GuardarNodo(childNode.Informacion());
                        }
                    }
                }
            }
            EliminarInterno(childNode, keyToDelete);
        }
        #region E
        public bool Eliminar(TLlave key)
        {
            if (fabricar.Empty())
            {
                return false;
            }
            else
            {
                int raiz = fabricar.ObtenerRaiz();
                BNode<TLlave, T> nodo = fabricar.TraerNodo(raiz);
                EliminarIntern(nodo, key);
                return true;
            }
        }

        private void EliminarIntern(BNode<TLlave, T> node, TLlave keyToDelete)
        {
            int i = Array.IndexOf(node.Llaves.ToArray(), keyToDelete.ToString());
            if (i < 0)
            {
                i = aDondeir(node.Llaves, keyToDelete, 0);
                if (i < 0) //nodo nulo, eliminar nodo completamente....
                    i = 0;
            }
            if (i < node.Llaves.Count() && node.Llaves[i].CompareTo(keyToDelete) == 0)
            {
                EliminarLlaveNode(node, keyToDelete, i);
                return;
            }
            if (!EsHoja(node.Hijos))
            {
                EliminarLlavedeSubarbo(node, keyToDelete, i);
            }
        }
        private void EliminarLlavedeSubarbo(BNode<TLlave, T> parentNode, TLlave keyToDelete, int subtreeIndexInNode)
        {
            BNode<TLlave, T> childNode = fabricar.TraerNodo(int.Parse(parentNode.Hijos[subtreeIndexInNode]));
            EliminarIntern(childNode, keyToDelete);
        }
        private void EliminarLlaveNode(BNode<TLlave, T> node, TLlave keyToDelete, int keyIndexInNode)
        {
            string KeyToRemove = node.Llaves[keyIndexInNode];
            string ItemToRemove = node.Datos[keyIndexInNode];

            fabricar.NodoDeFabrica();
            BNode<TLlave, T> nodo = fabricar.NodoV();
            nodo.Llaves[0] = KeyToRemove.ToString();
            nodo.Datos[0] = ItemToRemove.ToString();
            fabricar.Eliminar(nodo.Informacion());
        }
        #endregion
        #endregion
    }
}
