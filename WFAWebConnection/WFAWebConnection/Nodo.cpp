#include "stdafx.h"
#include "Nodo.h"
#include <stdio.h>

Nodo::Nodo(Pais *v_pais)
{
	this->miPais = v_pais;
	this->anterior = NULL;
	this->siguiente = NULL;
}

Nodo::~Nodo()
{
}
