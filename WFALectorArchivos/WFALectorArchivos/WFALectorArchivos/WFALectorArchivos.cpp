// WFALectorArchivos.cpp: archivo de proyecto principal.

#include "stdafx.h"
#include "FormOrdenamiento.h"

using namespace System;
using namespace WFALectorArchivos;

[STAThread]
int main(array<System::String ^> ^args)
{
	Application::Run(gcnew FormOrdenamiento());
    return 0;
}
