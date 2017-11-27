// ArbolBinarioDeBusqueda.cpp: archivo de proyecto principal.

#include "stdafx.h"
#include "ArbolBinario.h"
#include "stdio.h"
#include <cstdlib>

using namespace System;

int main(array<System::String ^> ^args)
{
	int datoIngresado = 0;
	bool deseaSalir = false;
	System::String^ miCadena = "";

	ArbolBinario *miArbol = new ArbolBinario();

	Console::WriteLine("Ingrese los numeros enteros que desee y presione 0 para salir");

	while (!deseaSalir){
		datoIngresado = Convert::ToInt32(Console::ReadLine());
		miArbol->insertar(datoIngresado, miArbol->root);
		deseaSalir = (datoIngresado == 0);
	}

	Console::WriteLine("Recorrido en orden");
	miArbol->recorrerEnOrden(miArbol->root, miCadena);
	Console::WriteLine(miCadena);
	miCadena = "";

	Console::WriteLine("Recorrido pre orden");
	miArbol->recorrerPreOrden(miArbol->root, miCadena);
	Console::WriteLine(miCadena);
	miCadena = "";

	Console::WriteLine("Recorrido post orden");
	miArbol->recorrerPostOrden(miArbol->root, miCadena);
	Console::WriteLine(miCadena);

	Console::ReadKey();
    return 0;
}
