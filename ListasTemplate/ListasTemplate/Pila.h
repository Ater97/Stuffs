#ifndef _PILA_H_
#define _PILA_H_

#pragma once

template <class T> struct nodo
{
	T val;
	nodo *sig;
};

template <class T> class pila
{
private:
	nodo<T> *top;
public:
	void destruir(); //Destruye toda la pila reiniciando 'top' a NULL como si estuviera la pila vacia.
	pila(); //Constructor para inicializar 'top' a NULL
	~pila(); //Destructor que llama a la funcion 'destruir()'
	int vacio(); //Retorna 1 si la pila esta vacía, 0 en caso contrario.
	int empilar(const T); //Empila un valor u objeto de tipo 'T' en la pila. Retorna 1 si la operacion tuvo exito, 0 en caso contrario.
	T desempilar(); //Nos retorna el valor u objeto de tipo 'T' que se encuentra en la cima.
};
#endif


