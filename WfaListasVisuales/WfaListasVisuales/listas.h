#pragma once


#include <iostream>
#include <stdlib.h>
#include <stdio.h>

using namespace std;

public class nodo
{
public:
	int valor;
	nodo *ptrSiguiente;
	nodo *ptrAnterior;

public:
	nodo(){
		ptrSiguiente = NULL;
		ptrAnterior = NULL;
	}
};

public class Lista
{
public:
	nodo *nodoInicio;
	nodo *nodoFin;

public:
	Lista(){
		nodoInicio = NULL;
		nodoFin = NULL;
	}

	void insertar(int p_valor){
		nodo *nuevo = new nodo();
		nuevo->valor = p_valor;

		if (nodoInicio == NULL){
			nodoInicio = nuevo;
			nodoFin = nuevo;
		}else{
			nodoFin->ptrSiguiente = nuevo;
			nuevo->ptrAnterior = nodoFin;
			nodoFin = nuevo;
		}
	}

	bool eliminar(int p_valor){  //verdadero si elimino elemento, falso si no lo hizo.
		nodo *posic = new nodo();
		posic = buscarNodo(p_valor);

		if (posic != NULL){
			if (nodoInicio == nodoFin){  //Es un único elemento
				nodoInicio = NULL;
				nodoFin = NULL;
				delete posic;
				return true;
			}else{
				if (posic == nodoInicio){  //Es el primer elemento.
					nodoInicio = posic->ptrSiguiente;
					nodoInicio->ptrAnterior = NULL;
					delete posic;
					return true;
				}
				else
				{
					if (posic == nodoFin){ //Si es el último de la lista
						nodoFin = posic->ptrAnterior;
						nodoFin->ptrSiguiente = NULL;
						delete posic;
						return true;
					}
					else
					{
						posic->ptrAnterior->ptrSiguiente = posic->ptrSiguiente;
						posic->ptrSiguiente->ptrAnterior = posic->ptrAnterior;
						delete posic;
						return true;
					}
				} //Fin del if que verifica si elimino el nodo inicio
			} 
		}else{ //fi del if que verifica que posic es != NULL
			return false;
		}
	}

private:
	nodo *buscarNodo(int p_valor){
		nodo *posic = new nodo();
		posic = nodoInicio;

		while (posic != NULL){
			if (posic->valor == p_valor)
				return posic;

			posic = posic->ptrSiguiente;
		}
		return posic;
	}
};

public class Pila
{
public:
	nodo *nodoInicio;
	nodo *nodoFin;

public:
	Pila(){
		nodoInicio = NULL;
		nodoFin = NULL;
	}

	void insertar(int p_valor){
		nodo *nuevo = new nodo();
		nuevo->valor = p_valor;

		if (nodoInicio == NULL){
			nodoInicio = nuevo;
			nodoFin = nuevo;
		}else{
			nuevo->ptrSiguiente = nodoInicio;
			nodoInicio = nuevo;
		}
	}//Fin del procedimiento insertar

	bool eliminar(){
		nodo *posic = new nodo();
		posic = nodoInicio;

		if (posic != NULL){
			if (nodoInicio == nodoFin){ //hay un solo elemento
				nodoInicio = NULL;
				nodoFin = NULL;
				delete posic;
				return true;
			}else{
				nodoInicio = posic->ptrSiguiente;
				delete posic;
				return true;
			}
		}else{
			return false;
		}
	}
};

public class Cola
{
public:
	nodo *nodoInicio;
	nodo *nodoFin;

public:
	Cola(){
		nodoInicio = NULL;
		nodoFin = NULL;
	}

	void insertar(int p_valor){
		nodo *nuevo = new nodo();
		nuevo->valor = p_valor;

		if (nodoInicio == NULL){
			nodoInicio = nuevo;
			nodoFin = nuevo;
		}else{
			nodoFin->ptrSiguiente = nuevo;
			nodoFin = nuevo;
		}
	}

	bool eliminar(){
		nodo *posic = new nodo();
		posic = nodoInicio;

		if (posic != NULL){
			if (nodoInicio == nodoFin){ //Hay solamente un elemento.
				nodoInicio = NULL;
				nodoFin = NULL;
				delete posic;
				return true;
			}else{ //Hay por lo menos 2 elementos
				nodoInicio = posic->ptrSiguiente;
				delete posic;
				return true;
			}
		}else{
			return false;
		}
	}
};