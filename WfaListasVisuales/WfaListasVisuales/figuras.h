#pragma once

#include <iostream>
#include <stdlib.h>
#include <stdio.h>

using namespace System;
using namespace System::Drawing;

namespace Figuras
{
	using namespace System;
	using namespace System::Drawing;

	ref class Rectangulo
	{
	public:
		Rectangulo(String^ p_dato, int p_x, int p_y){
			MiColor = Color::DarkBlue;
			MiColor2 = Color::White;
			iTamanio = 30;
			sDato = p_dato;
			posicion = gcnew Point(p_x, p_y);
		}

		void dibujar(Graphics^ Canvas){
			Brush^ brush = gcnew SolidBrush(MiColor);
			Brush^ brDato = gcnew SolidBrush(MiColor2);
			Font^ letra = gcnew Font("Arial",15);
			RectangleF rec = RectangleF(posicion->X, posicion->Y, iTamanio, 30);
			Canvas->FillRectangle(brush, rec);
			Canvas->DrawString(sDato, letra, brDato, posicion->X + 5, posicion->Y + 5);
		} //fin del método dibujar;

	private:
		Color MiColor;
		Color MiColor2;
		static String^ sDato;
		static Point^ posicion;
		int iTamanio;
	};
}