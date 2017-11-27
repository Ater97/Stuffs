#pragma once
#include "listas.h";
#include "figuras.h"

namespace WfaListasVisuales {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace Figuras;
	Lista *miLista;
	Pila *miPila;
	Cola *miCola;

	/// <summary>
	/// Resumen de Form1
	///
	/// ADVERTENCIA: si cambia el nombre de esta clase, deberá cambiar la
	///          propiedad 'Nombre de archivos de recursos' de la herramienta de compilación de recursos administrados
	///          asociada con todos los archivos .resx de los que depende esta clase. De lo contrario,
	///          los diseñadores no podrán interactuar correctamente con los
	///          recursos adaptados asociados con este formulario.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			miLista = new Lista();
			miPila = new Pila();
			miCola = new Cola();
			//
			//TODO: agregar código de constructor aquí
			//
		}

	protected:
		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::GroupBox^  groupBox1;
	protected: 
	private: System::Windows::Forms::GroupBox^  groupBox2;
	private: System::Windows::Forms::GroupBox^  groupBox3;
	private: System::Windows::Forms::MaskedTextBox^  mskNumero;

	private: System::Windows::Forms::Button^  btnInsertar;

	private: System::Windows::Forms::GroupBox^  groupBox4;
	private: System::Windows::Forms::CheckBox^  chkCola;
	private: System::Windows::Forms::CheckBox^  chkPila;
	private: System::Windows::Forms::CheckBox^  chkLista;
	private: System::Windows::Forms::Button^  btnEliminarLista;

	private: System::Windows::Forms::ListBox^  lstLista;
	private: System::Windows::Forms::Button^  btnEliminarCola;

	private: System::Windows::Forms::Button^  btnEliminarPila;

	private: System::Windows::Forms::ListBox^  lstPila;
	private: System::Windows::Forms::ListBox^  lstCola;
	private: System::Windows::Forms::Panel^  pnlLista;

	private: System::Windows::Forms::Panel^  pnlPila;

	private: System::Windows::Forms::Panel^  pnlCola;


	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label3;

	private:
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		void InitializeComponent(void)
		{
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->btnEliminarLista = (gcnew System::Windows::Forms::Button());
			this->lstLista = (gcnew System::Windows::Forms::ListBox());
			this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->btnEliminarPila = (gcnew System::Windows::Forms::Button());
			this->lstPila = (gcnew System::Windows::Forms::ListBox());
			this->groupBox3 = (gcnew System::Windows::Forms::GroupBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->btnEliminarCola = (gcnew System::Windows::Forms::Button());
			this->lstCola = (gcnew System::Windows::Forms::ListBox());
			this->mskNumero = (gcnew System::Windows::Forms::MaskedTextBox());
			this->btnInsertar = (gcnew System::Windows::Forms::Button());
			this->groupBox4 = (gcnew System::Windows::Forms::GroupBox());
			this->chkCola = (gcnew System::Windows::Forms::CheckBox());
			this->chkPila = (gcnew System::Windows::Forms::CheckBox());
			this->chkLista = (gcnew System::Windows::Forms::CheckBox());
			this->pnlLista = (gcnew System::Windows::Forms::Panel());
			this->pnlPila = (gcnew System::Windows::Forms::Panel());
			this->pnlCola = (gcnew System::Windows::Forms::Panel());
			this->groupBox1->SuspendLayout();
			this->groupBox2->SuspendLayout();
			this->groupBox3->SuspendLayout();
			this->groupBox4->SuspendLayout();
			this->SuspendLayout();
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->label1);
			this->groupBox1->Controls->Add(this->btnEliminarLista);
			this->groupBox1->Controls->Add(this->lstLista);
			this->groupBox1->Location = System::Drawing::Point(12, 12);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(200, 184);
			this->groupBox1->TabIndex = 0;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Lista";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(10, 27);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(184, 13);
			this->label1->TabIndex = 2;
			this->label1->Text = L"Seleccione el item que desea eliminar";
			// 
			// btnEliminarLista
			// 
			this->btnEliminarLista->Location = System::Drawing::Point(102, 76);
			this->btnEliminarLista->Name = L"btnEliminarLista";
			this->btnEliminarLista->Size = System::Drawing::Size(75, 23);
			this->btnEliminarLista->TabIndex = 1;
			this->btnEliminarLista->Text = L"Eliminar";
			this->btnEliminarLista->UseVisualStyleBackColor = true;
			this->btnEliminarLista->Click += gcnew System::EventHandler(this, &Form1::btnEliminarLista_Click);
			// 
			// lstLista
			// 
			this->lstLista->FormattingEnabled = true;
			this->lstLista->Location = System::Drawing::Point(33, 57);
			this->lstLista->Name = L"lstLista";
			this->lstLista->Size = System::Drawing::Size(51, 121);
			this->lstLista->TabIndex = 0;
			// 
			// groupBox2
			// 
			this->groupBox2->Controls->Add(this->label2);
			this->groupBox2->Controls->Add(this->btnEliminarPila);
			this->groupBox2->Controls->Add(this->lstPila);
			this->groupBox2->Location = System::Drawing::Point(227, 12);
			this->groupBox2->Name = L"groupBox2";
			this->groupBox2->Size = System::Drawing::Size(200, 184);
			this->groupBox2->TabIndex = 1;
			this->groupBox2->TabStop = false;
			this->groupBox2->Text = L"Pila";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(14, 23);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(167, 13);
			this->label2->TabIndex = 3;
			this->label2->Text = L"Solo se elimina el último ingresado";
			// 
			// btnEliminarPila
			// 
			this->btnEliminarPila->Location = System::Drawing::Point(109, 76);
			this->btnEliminarPila->Name = L"btnEliminarPila";
			this->btnEliminarPila->Size = System::Drawing::Size(75, 23);
			this->btnEliminarPila->TabIndex = 2;
			this->btnEliminarPila->Text = L"Eliminar";
			this->btnEliminarPila->UseVisualStyleBackColor = true;
			this->btnEliminarPila->Click += gcnew System::EventHandler(this, &Form1::btnEliminarPila_Click);
			// 
			// lstPila
			// 
			this->lstPila->FormattingEnabled = true;
			this->lstPila->Location = System::Drawing::Point(31, 57);
			this->lstPila->Name = L"lstPila";
			this->lstPila->Size = System::Drawing::Size(51, 121);
			this->lstPila->TabIndex = 1;
			// 
			// groupBox3
			// 
			this->groupBox3->Controls->Add(this->label3);
			this->groupBox3->Controls->Add(this->btnEliminarCola);
			this->groupBox3->Controls->Add(this->lstCola);
			this->groupBox3->Location = System::Drawing::Point(433, 12);
			this->groupBox3->Name = L"groupBox3";
			this->groupBox3->Size = System::Drawing::Size(200, 184);
			this->groupBox3->TabIndex = 2;
			this->groupBox3->TabStop = false;
			this->groupBox3->Text = L"Cola";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(12, 23);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(168, 13);
			this->label3->TabIndex = 4;
			this->label3->Text = L"Solo se elimina el primer ingresado";
			// 
			// btnEliminarCola
			// 
			this->btnEliminarCola->Location = System::Drawing::Point(105, 76);
			this->btnEliminarCola->Name = L"btnEliminarCola";
			this->btnEliminarCola->Size = System::Drawing::Size(75, 23);
			this->btnEliminarCola->TabIndex = 3;
			this->btnEliminarCola->Text = L"Eliminar";
			this->btnEliminarCola->UseVisualStyleBackColor = true;
			this->btnEliminarCola->Click += gcnew System::EventHandler(this, &Form1::btnEliminarCola_Click);
			// 
			// lstCola
			// 
			this->lstCola->FormattingEnabled = true;
			this->lstCola->Location = System::Drawing::Point(35, 57);
			this->lstCola->Name = L"lstCola";
			this->lstCola->Size = System::Drawing::Size(51, 121);
			this->lstCola->TabIndex = 2;
			// 
			// mskNumero
			// 
			this->mskNumero->Location = System::Drawing::Point(192, 227);
			this->mskNumero->Mask = L"99999";
			this->mskNumero->Name = L"mskNumero";
			this->mskNumero->Size = System::Drawing::Size(38, 20);
			this->mskNumero->TabIndex = 3;
			this->mskNumero->ValidatingType = System::Int32::typeid;
			// 
			// btnInsertar
			// 
			this->btnInsertar->Location = System::Drawing::Point(258, 227);
			this->btnInsertar->Name = L"btnInsertar";
			this->btnInsertar->Size = System::Drawing::Size(78, 20);
			this->btnInsertar->TabIndex = 4;
			this->btnInsertar->Text = L"Insertar";
			this->btnInsertar->UseVisualStyleBackColor = true;
			this->btnInsertar->Click += gcnew System::EventHandler(this, &Form1::btnInsertar_Click);
			// 
			// groupBox4
			// 
			this->groupBox4->Controls->Add(this->chkCola);
			this->groupBox4->Controls->Add(this->chkPila);
			this->groupBox4->Controls->Add(this->chkLista);
			this->groupBox4->Location = System::Drawing::Point(362, 202);
			this->groupBox4->Name = L"groupBox4";
			this->groupBox4->Size = System::Drawing::Size(78, 92);
			this->groupBox4->TabIndex = 3;
			this->groupBox4->TabStop = false;
			this->groupBox4->Text = L"Insertar en:";
			// 
			// chkCola
			// 
			this->chkCola->AutoSize = true;
			this->chkCola->Location = System::Drawing::Point(6, 65);
			this->chkCola->Name = L"chkCola";
			this->chkCola->Size = System::Drawing::Size(47, 17);
			this->chkCola->TabIndex = 2;
			this->chkCola->Text = L"Cola";
			this->chkCola->UseVisualStyleBackColor = true;
			// 
			// chkPila
			// 
			this->chkPila->AutoSize = true;
			this->chkPila->Location = System::Drawing::Point(6, 42);
			this->chkPila->Name = L"chkPila";
			this->chkPila->Size = System::Drawing::Size(43, 17);
			this->chkPila->TabIndex = 1;
			this->chkPila->Text = L"Pila";
			this->chkPila->UseVisualStyleBackColor = true;
			// 
			// chkLista
			// 
			this->chkLista->AutoSize = true;
			this->chkLista->Location = System::Drawing::Point(6, 19);
			this->chkLista->Name = L"chkLista";
			this->chkLista->Size = System::Drawing::Size(48, 17);
			this->chkLista->TabIndex = 0;
			this->chkLista->Text = L"Lista";
			this->chkLista->UseVisualStyleBackColor = true;
			// 
			// pnlLista
			// 
			this->pnlLista->Location = System::Drawing::Point(12, 319);
			this->pnlLista->Name = L"pnlLista";
			this->pnlLista->Size = System::Drawing::Size(200, 219);
			this->pnlLista->TabIndex = 5;
			// 
			// pnlPila
			// 
			this->pnlPila->Location = System::Drawing::Point(227, 319);
			this->pnlPila->Name = L"pnlPila";
			this->pnlPila->Size = System::Drawing::Size(200, 219);
			this->pnlPila->TabIndex = 6;
			// 
			// pnlCola
			// 
			this->pnlCola->Location = System::Drawing::Point(443, 319);
			this->pnlCola->Name = L"pnlCola";
			this->pnlCola->Size = System::Drawing::Size(200, 219);
			this->pnlCola->TabIndex = 7;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(655, 550);
			this->Controls->Add(this->pnlCola);
			this->Controls->Add(this->pnlPila);
			this->Controls->Add(this->pnlLista);
			this->Controls->Add(this->groupBox4);
			this->Controls->Add(this->btnInsertar);
			this->Controls->Add(this->mskNumero);
			this->Controls->Add(this->groupBox3);
			this->Controls->Add(this->groupBox2);
			this->Controls->Add(this->groupBox1);
			this->Name = L"Form1";
			this->Text = L"Listas Visibles";
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->groupBox2->ResumeLayout(false);
			this->groupBox2->PerformLayout();
			this->groupBox3->ResumeLayout(false);
			this->groupBox3->PerformLayout();
			this->groupBox4->ResumeLayout(false);
			this->groupBox4->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: 
		System::Void btnInsertar_Click(System::Object^  sender, System::EventArgs^  e) {
			if (mskNumero->Text != ""){
				int iNumero = int::Parse(mskNumero->Text);

				if (chkLista->Checked){
					lstLista->Items->Add(iNumero);
					miLista->insertar(iNumero);
					nodo *miNodo = new nodo();
					miNodo = miLista->nodoInicio;
					
					pnlLista->Refresh();

					int cont = 0;
					while (miNodo != NULL){
						Rectangulo^ recElemento = gcnew Rectangulo(miNodo->valor.ToString(), 85, cont * 40);
						recElemento->dibujar(pnlLista->CreateGraphics());
						miNodo = miNodo->ptrSiguiente;
						cont++;
					}
				}

				if (chkPila->Checked){
					lstPila->Items->Add(iNumero);
					miPila->insertar(iNumero);

					nodo *miNodo = new nodo();
					miNodo = miPila->nodoInicio;

					pnlPila->Refresh();

					int cont = 0;
					while (miNodo != NULL){
						Rectangulo^ recElemento = gcnew Rectangulo(miNodo->valor.ToString(), 85, cont * 40);
						recElemento->dibujar(pnlPila->CreateGraphics());
						miNodo = miNodo->ptrSiguiente;
						cont++;
					}

				}

				if (chkCola->Checked){
					lstCola->Items->Add(iNumero);
					miCola->insertar(iNumero);

					nodo *miNodo = new nodo();
					miNodo = miCola->nodoInicio;

					pnlCola->Refresh();

					int cont = 0;
					while (miNodo != NULL){
						Rectangulo^ recElemento = gcnew Rectangulo(miNodo->valor.ToString(), 85, cont * 40);
						recElemento->dibujar(pnlCola->CreateGraphics());
						miNodo = miNodo->ptrSiguiente;
						cont++;
					}
				}

				mskNumero->Text = "";
				mskNumero->Focus();
			}else{
				MessageBox::Show("Debe de ingresar por lo menos un valor");
			}
		}

		System::Void btnEliminarLista_Click(System::Object^  sender, System::EventArgs^  e) {
			int iNumero = lstLista->SelectedIndex;
			if (iNumero >= 0){ //Hay por lo menos un item seleccionado
				if (miLista->eliminar(int::Parse(lstLista->SelectedItem->ToString()))){
					lstLista->Items->Remove(lstLista->SelectedItem);

					nodo *miNodo = new nodo();
					miNodo = miLista->nodoInicio;
					pnlLista->Refresh();

					int cont = 0;
					while (miNodo != NULL){
						Rectangulo^ recElemento = gcnew Rectangulo(miNodo->valor.ToString(), 85, cont * 40);
						recElemento->dibujar(pnlLista->CreateGraphics());
						miNodo = miNodo->ptrSiguiente;
						cont++;
					}

					MessageBox::Show("Elemento eliminado correctamente");
				}else{
					MessageBox::Show("No se ha encontrado el elemento");
				}
	
			}else{
				MessageBox::Show("Debe de seleccionar por lo menos un item");
			}
		}

		System::Void btnEliminarPila_Click(System::Object^  sender, System::EventArgs^  e) {
			if (lstPila->Items->Count > 0){
				lstPila->SelectedIndex = lstPila->Items->Count - 1;
				lstPila->Items->Remove(lstPila->SelectedItem);
				if (miPila->eliminar()){

					nodo *miNodo = new nodo();
					miNodo = miPila->nodoInicio;
					pnlPila->Refresh();

					int cont = 0;
					while (miNodo != NULL){
						Rectangulo^ recElemento = gcnew Rectangulo(miNodo->valor.ToString(), 85, cont * 40);
						recElemento->dibujar(pnlPila->CreateGraphics());
						miNodo = miNodo->ptrSiguiente;
						cont++;
					}


					MessageBox::Show("Elemento eliminado correctamente");
				}else{
					MessageBox::Show("No se ha encontrado el número");
				}
			}else{
				MessageBox::Show("No existen elementos a eliminar");
			}
		}

		System::Void btnEliminarCola_Click(System::Object^  sender, System::EventArgs^  e) {
			if (lstCola->Items->Count > 0){
				lstCola->SelectedIndex = 0;
				lstCola->Items->Remove(lstCola->SelectedItem);
				if (miCola->eliminar()){

					nodo *miNodo = new nodo();
					miNodo = miCola->nodoInicio;
					pnlCola->Refresh();

					int cont = 0;
					while (miNodo != NULL){
						Rectangulo^ recElemento = gcnew Rectangulo(miNodo->valor.ToString(), 85, cont * 40);
						recElemento->dibujar(pnlCola->CreateGraphics());
						miNodo = miNodo->ptrSiguiente;
						cont++;
					}

					MessageBox::Show("Elemento eliminado correctamente");
				}else{
					MessageBox::Show("No se ha encontrado el número");
				}
			}else{
				MessageBox::Show("No existen elementos a eliminar");
			}
		}
	};
}
