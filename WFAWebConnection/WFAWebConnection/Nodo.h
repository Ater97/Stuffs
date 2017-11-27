#pragma once
#include "Pais.h"

class Nodo
{
public:
	Pais *miPais;
	Nodo *siguiente;
	Nodo *anterior;

public:
	Nodo(Pais *miPais);
	~Nodo();
};

