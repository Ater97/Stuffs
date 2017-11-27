// MetodosDeBusqueda.cpp: archivo de proyecto principal.
#include "stdafx.h"
#include "stdio.h"
#include <cstdlib>
#include <string>

using namespace System;

bool BusquedaSecuencial(int[], int, int);
bool BusquedaBinaria(int[], int, int, int);

int main(array<System::String ^> ^args)
{
	const int SIZE = 10;
	int miVector[SIZE] = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
	char option = 'Y';
	int miDato;

	while (toupper(option) != 'E')
	{
		system("cls");
		printf("Presione S para busqueda secuencial o B para binaria y E para salir\n");
		scanf(" %c", &option);

		printf("Ingrese el numero a buscar\n");
		scanf("%d", &miDato);

		switch (toupper(option))
		{
		case 'B':
			if (BusquedaBinaria(miVector, miDato, 0, (SIZE - 1))){
				printf("Valor encontrado");
			}
			else {
				printf("Valor no encontrado");
			}
			Console::ReadKey();
			break;

		case 'S':
			if (BusquedaSecuencial(miVector, miDato, SIZE)){
				printf("Valor encontrado");
			}
			else {
				printf("Valor no encontrado");
			}
			Console::ReadKey();
			break;

		default:
			break;
		}

	}

	Console::ReadKey();
    return 0;
}

bool BusquedaSecuencial(int arreglo[], int dato, int tamanio){
	for (int i = 0; i < tamanio; i++){
		if (arreglo[i] == dato)
			return true;
	}
	return false;
}

bool BusquedaBinaria(int arreglo[], int dato, int inferior, int superior){
	if (inferior <= superior){
		int pivote = ((superior - inferior) / 2) + inferior;

		if (dato < arreglo[pivote]){
			return BusquedaBinaria(arreglo, dato, inferior, pivote - 1);
		}
		else if (dato > arreglo[pivote]){
			return BusquedaBinaria(arreglo, dato, pivote + 1, superior);
		}
		else {
			return true;
		}
	}
	else {
		return false;
	}

}