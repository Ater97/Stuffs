#include "stdafx.h"
#include "ArbolBinario.h"
#include <cstdio>


ArbolBinario::ArbolBinario()
{
	root = NULL;
}


ArbolBinario::~ArbolBinario()
{
}

void ArbolBinario::insertar(int value, nodo *actual)
{
	nodo *nuevo = new nodo();
	nuevo->value = value;

	if (!actual){ //Es la raiz
		root = nuevo;
	}
	else { //No es la raiz, busco en sus ramas
		if (nuevo->value < actual->value){
			if (actual->izquierda){
				insertar(value, actual->izquierda);
			}
			else {
				actual->izquierda = nuevo;
			}
		}
		else if (nuevo->value > actual->value){
			if (actual->derecha){
				insertar(value, actual->derecha);
			}
			else {
				actual->derecha = nuevo;
			}
		}
	}
}

void ArbolBinario::recorrerEnOrden(nodo *actual, System::String^ &cadena){

	if (actual)
	{
		if (actual->izquierda){
			recorrerEnOrden(actual->izquierda, cadena);
		}

		cadena += " " + actual->value;

		if (actual->derecha){
			recorrerEnOrden(actual->derecha, cadena);
		}

	}
}

void ArbolBinario::recorrerPreOrden(nodo *actual, System::String^ &cadena){

	if (actual)
	{
		cadena += " " + actual->value;

		if (actual->izquierda){
			recorrerPreOrden(actual->izquierda, cadena);
		}

		if (actual->derecha){
			recorrerPreOrden(actual->derecha, cadena);
		}

		
	}
}


void ArbolBinario::recorrerPostOrden(nodo *actual, System::String^ &cadena){

	if (actual)
	{
		if (actual->izquierda){
			recorrerPostOrden(actual->izquierda, cadena);
		}

		if (actual->derecha){
			recorrerPostOrden(actual->derecha, cadena);
		}

		cadena += " " + actual->value;
	}
}


int ArbolBinario::extraer(int value, nodo *actual){
	return 0;
}