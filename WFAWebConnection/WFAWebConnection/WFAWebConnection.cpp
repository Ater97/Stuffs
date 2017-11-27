// WFAWebConnection.cpp : main project file.

#include "stdafx.h"
#include "Lista.h"
#include "Pais.h"
#include <stdio.h>

#using <System.dll>


using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::NetworkInformation;
using namespace System::Text;
using namespace System::Xml;
using namespace System::Runtime::InteropServices;

int main(array<System::String ^> ^args)
{
	//Variables necesarias para la lectura de XML
	WebRequest^ solicitud;
	HttpWebResponse^ respuesta;
	Stream^ stream1;
	StreamReader^ reader;
	String^ respuestaCadena;
	String^ path = "http://api.geonames.org/countryInfo?username=malonsogt";
	bool estaConectado = false;
	XmlDocument^ xmlDoc = gcnew XmlDocument();
	
	//Variables necesarias para el manejo de la lista
	Lista *miLista = new Lista();

	Ping^ pingSender = gcnew Ping();
	PingReply^ pingReplay = pingSender->Send("8.8.8.8");
	
		estaConectado = (pingReplay->Status == IPStatus::Success);

		if (estaConectado){

			//Llamada a servicio Web
			solicitud = WebRequest::Create(path);
			solicitud->Credentials = CredentialCache::DefaultCredentials;
			respuesta = dynamic_cast<HttpWebResponse^>(solicitud->GetResponse());
			stream1 = respuesta->GetResponseStream();
			reader = gcnew StreamReader(stream1);
			respuestaCadena = reader->ReadToEnd();
			Console::WriteLine("Datos del servidor");
			//	Console::WriteLine(respuestaCadena);
			reader->Close();
			stream1->Close();
			respuesta->Close();

			xmlDoc->LoadXml(respuestaCadena);

			XmlNodeList^ nodos = xmlDoc->GetElementsByTagName("country");

			//Lleno la lista de paises
			for (int i = 0; i < nodos->Count; i++){
			
				//Conversion para cadenas char*
				char *name = (char*)(void*)Marshal::StringToHGlobalAnsi(nodos->Item(i)->SelectSingleNode("countryName")->InnerXml);
				char *code = (char*)(void*)Marshal::StringToHGlobalAnsi(nodos->Item(i)->SelectSingleNode("countryCode")->InnerXml);
				int population = Convert::ToInt32(nodos->Item(i)->SelectSingleNode("population")->InnerXml);

				//Inserto el nuevo pais en la lista
				Pais *nuevoPais = new Pais(name, code, population);
				miLista->Insertar(nuevoPais);
			}
		
			//Escribo en pantalla
			Nodo *nodoActual = miLista->inicio;
			while (nodoActual != NULL)
			{
				printf("*********** Pais *************\r\n");
				printf("Nombre: ");
				printf(nodoActual->miPais->nombre);
				printf("\r\n");
				printf("Codigo: ");
				printf(nodoActual->miPais->codigo);
				printf("\r\n");
				printf("Poblacion: %d", nodoActual->miPais->poblacion);
				printf("\r\n");

				//Avanzo al siguiente nodo.
				nodoActual = nodoActual->siguiente;
			}
		
		}
		else {
			Console::WriteLine("No hay conexión a internet");
		}

	Console::ReadKey();

    return 0;
}
