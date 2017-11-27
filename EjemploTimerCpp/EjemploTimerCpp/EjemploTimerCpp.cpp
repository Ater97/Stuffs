// EjemploTimerCpp.cpp : main project file.

#include "stdafx.h"

using namespace System;
using namespace System::Timers;

static int puntuacion = 0;
static int posicionX = 0;
static int posicionY = 0;
static int desplazamientoX = 1;
static int desplazamientoY = 2;

static void Tick(Object^ sender, ElapsedEventArgs^ e)
{
	Console::Clear(); //Limpio consola

	posicionX = posicionX + desplazamientoX; //aumento la posicion en x de 2 en 2, es lo mismo que poner: posicionX = PosicionX + 2;
	posicionY = posicionY + desplazamientoY; //aumento la posicion en y de 1 en 1, es lo mismo que poner: posicionY = PosicionY + 1;

	Console::SetCursorPosition(posicionX, posicionY);
	Console::Write("0");

	if ((posicionX >= (Console::WindowWidth - 1)) || (posicionX <= 0)) //Topó en la derecha o en la izquierda
	{
		desplazamientoX = desplazamientoX * (-1);
		puntuacion++; //Aumento la puntuacion cada vez que topa en las pardes, esto es lo mismo que hacer: puntuacion = puntuacion + 1;
	}

	if ((posicionY >= (Console::WindowHeight - 1)) || (posicionY <= 0)) //Llego a la parte superior o inferior
	{
		desplazamientoY = desplazamientoY * (-1);
		puntuacion++; //Aumento la puntuacion cada vez que topa en las pardes, esto es lo mismo que hacer: puntuacion = puntuacion + 1;
	}

	//Dibujo la puntuacion en la parte inferior de la pantalla
	Console::SetCursorPosition(1, (Console::WindowHeight - 2));
	Console::Write("Puntuacion: " + puntuacion);
}

int main(array<System::String ^> ^args)
{
	Timer^ tmr = gcnew Timer(); //Nuevo timer para levantar un nuevo proceso

	tmr->Interval = 200; //Intervalo de tiempo en cada repeticion
	tmr->Elapsed += gcnew ElapsedEventHandler(Tick); //Asigno procedimienot Tick al timer
	tmr->Start(); //Inicio del timer

	Console::ReadKey();

    return 0;
}

