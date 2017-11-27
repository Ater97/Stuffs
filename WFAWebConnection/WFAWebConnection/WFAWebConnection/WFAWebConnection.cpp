// WFAWebConnection.cpp : main project file.

#include "stdafx.h"
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::NetworkInformation;
using namespace System::Text;
using namespace System::Xml;

int main(array<System::String ^> ^args)
{
	WebRequest^ solicitud;
	HttpWebResponse^ respuesta;
	Stream^ stream1;
	StreamReader^ reader;
	String^ respuestaCadena;
	String^ path = "http://api.geonames.org/countryInfo?username=malonsogt";
	bool estaConectado = false;
	XmlDocument^ xmlDoc = gcnew XmlDocument();
	


	Ping^ pingSender = gcnew Ping();
	PingReply^ pingReplay = pingSender->Send("8.8.8.8");
	
	estaConectado = (pingReplay->Status == IPStatus::Success);

	if (estaConectado){

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

		for (int i = 0; i < nodos->Count; i++){
			
			Console::WriteLine("Pais: " + nodos->Item(i)->SelectSingleNode("countryName")->InnerXml);
		}
		
		
	}
	else {
		Console::WriteLine("No hay conexión a internet");
	}

	Console::ReadKey();

    return 0;
}
