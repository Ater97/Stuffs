#pragma once
class Pais
{
public:
	char* nombre;
	char* codigo;
	int poblacion;
public:
	Pais(char* nombre, char* codigo, int poblacion);
	~Pais();
};

