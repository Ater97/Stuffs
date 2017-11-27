#include "stdafx.h"
#include "Lista.h"
#include <stdio.h>

Lista::Lista()
{
	inicio = NULL;
	fin = NULL;
}

Lista::~Lista()
{
}

void Lista::Insertar(Pais *nuevoPais)
{
	Nodo *nuevo = new Nodo(nuevoPais);

	if ((inicio == NULL) && (fin == NULL))
	{
		inicio = nuevo;
		fin = nuevo;
	}
	else 
	{
		fin->siguiente = nuevo;
		nuevo->anterior = fin;
		fin = nuevo;
	}
}
