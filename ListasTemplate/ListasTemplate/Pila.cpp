#include "stdafx.h"
#include "pila.h"
#include <cstdio>

template <class T> void pila <T>::destruir()
{
	/*Destruye cada nodo y al final inicializa la pila como vacia.*/
	nodo<T> *n;
	while (top)
	{
		n = top;
		top = top->sig;
		delete n;
	}
	top = NULL;
}
template <class T> pila <T>::pila()
{
	top = NULL;
}
template <class T> pila <T>::~pila()
{
	destruir();
}

template <class T> int pila<T>::vacio()
{
	return (!top) ? 1 : 0;
}
template <class T> int pila<T>::empilar(const T valor)
{
	nodo<T> *n = new nodo<T>;
	if (!n)
		return 0;//Retorna 0 en caso que no haya memoria disponible para otro nodo.
	n->sig = top;//Enlazamos el nodo creado con el nodo que seguía a la cima o 'top'
	top = n;//Hacemos que la cima o 'top' apunte ahora al nodo creado.
	n->val = valor;//Asignamos el valor al nodo creado.
	return 1;//La operacion tuvo exito.
}
template <class T> T pila<T>::desempilar()
{
	if (!vacio())
	{
		nodo<T> *n = top;//'n' contendra la direccion del nodo a eliminar.
		T N = n->val;//'N' contiene el valor u objeto de tipo 'T' a retornar.
		top = top->sig;//Hacemos que 'top' apunte al siguiente "eliminando" de este modo al nodo anterior.
		delete n;//Destruimos el nodo del cual retornaremos su valor y no usaremos más.
		return N;//Retornamos el valor u objeto de tipo 'T'
	}
}
