#include "stdafx.h"
#include "Pais.h"


Pais::Pais(char* nombre, char* codigo, int poblacion)
{
	this->codigo = codigo;
	this->nombre = nombre;
	this->poblacion = poblacion;
}

Pais::~Pais()
{
}
