#ifndef _ARBOLBINARIO_H_
#define _ARBOLBINARIO_H_

#pragma once

struct nodo
{
	int value;
	nodo *izquierda;
	nodo *derecha;
};

class ArbolBinario
{
public:
	nodo *root;
	ArbolBinario();
	~ArbolBinario();
	void insertar(int, nodo *);
	int extraer(int, nodo *);
	void recorrerEnOrden(nodo *, System::String^&);
	void recorrerPreOrden(nodo *, System::String^&);
	void recorrerPostOrden(nodo *, System::String^&);
};

#endif // !_ARBOLBINARIO_H_
