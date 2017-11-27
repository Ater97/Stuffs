#pragma once
#include "Nodo.h"

class Lista
{
public:
	Nodo *inicio;
	Nodo * fin;
public:
	Lista();
	~Lista();
	void Insertar(Pais *nuevoPais);
};

