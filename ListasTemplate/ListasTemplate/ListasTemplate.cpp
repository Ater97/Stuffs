// ListasTemplate.cpp: archivo de proyecto principal.
#include "stdafx.h"
#include "pila.h"
#include "pila.cpp"
#include <cstdlib>

using namespace System;

void menu1();
void menu2(char*);

int main(array<System::String ^> ^args)
{
	bool deseaSalir = false;
	char opt = 'n';
	char *tipoDato = "Entero";
	pila <char> *Pc = new pila<char>();
	pila <int> *Pi = new pila<int>();

	while (!deseaSalir){
		system("cls");
		menu1();
		scanf("%c",&opt);

		switch (opt)
		{
		case 'i':
			tipoDato = "Entero";

			while (opt != 'm')
			{
				system("cls");
				menu2(tipoDato);
				scanf("%c", &opt);

				switch (opt)
				{

				case 'e':{
					system("cls");
					printf("Porfavor insert un numero\n");
					int numero = 0;
					if (scanf("%d", &numero)){

						if (!Pi->empilar(numero)){
							printf("Ha ocurrido un error a la hora de empilar\n");
						}

						printf("Valor %d insertado Presione una tecla para continuar...\n", numero);
						system("PAUSE");
					}
					else {
						printf("Ingrese un valor correcto\n");
						printf("Presione una tecla para continuar...\n");
						system("PAUSE");
					}
				}break;

				case 'd':{
					if (Pi->vacio())
						printf("No hay numeros en la pila\n");
					else
						printf("%d\n", Pi->desempilar());

					printf("Presione una tecla para continuar...");
					system("PAUSE");
				}break;

				case 'v':{
					Pi->destruir();
					printf("Pila vacia presione una tecla para continuar...");
					system("PAUSE");
				}break;

				default:
					system("cls");
					break;
				}
			}

			break;

		case 'c':
			tipoDato = "Caracter";

			while (opt != 'm')
			{
				system("cls");
				menu2(tipoDato);
				scanf("%c", &opt);

				switch (opt)
				{

				case 'e':{
					system("cls");
					printf("Por favor inserte un caracter\n");
					char car = 'n';
					if (scanf(" %c", &car)){

						if (!Pc->empilar(car)){
							printf("Ha ocurrido un error a la hora de empilar\n");
						}

						printf("Valor %c insertado Presione una tecla para continuar...\n", car);
						system("PAUSE");
					}
					else {
						printf("Ingrese un valor correcto\n");
						printf("Presione una tecla para continuar...");
						system("PAUSE");
					}
				}break;

				case 'd':{
					if (Pc->vacio())
						printf("No hay numeros en la pila\n");
					else
						printf("%c\n", Pc->desempilar());

					printf("Presione una tecla para continuar...");
					system("PAUSE");
				}break;

				case 'v':{
					Pc->destruir();
					printf("Pila vacia presione una tecla para continuar...");
					system("PAUSE");
				}break;

				default:
					system("cls");
					break;
				}
			}

			break;
		case 's':
			deseaSalir = true;
			break;
		default:
			printf("Comando desconocido\n");
			break;
		}
	}

	return 0;
}

void menu1()
{
	printf("Tipo de dato\n");
	printf("  i  Insertar valores de tipo entero\n");
	printf("  c  Insertar valores de tipo char\n");
	printf("  s  Salir del programa\n");
}

void menu2(char* tipodato)
{
	printf("Opciones\n");
	printf("  e  Empilar un valor %s a la pila\n", tipodato);
	printf("  d  Desempilar un valor  %s de la cima\n", tipodato);
	printf("  v  Vaciar o destruir la pila\n");
	printf("  m  Regresar al menu anterior\n");
}