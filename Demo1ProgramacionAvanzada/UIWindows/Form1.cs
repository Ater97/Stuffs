using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estructuras.Estaticas;

namespace UIWindows
{
    public partial class Form1 : Form
    {
        Lista miLista;
        Cola miCola;

        public Form1()
        {
            InitializeComponent();
            miLista = new Lista(5);
            miCola = new Cola(5);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                miLista.Insertar(Convert.ToInt32(txtValor.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarLista();
        }

        private void btnInsertarPos_Click(object sender, EventArgs e)
        {
            try
            {
                miLista.Insertar(Convert.ToInt32(txtPos.Text), Convert.ToInt32(txtValor.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarLista();
        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            try
            {
                miLista.Extraer(Convert.ToInt32(txtPos.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarLista();
        }


        private void MostrarLista()
        {
            lstLista.Items.Clear();
            for (int i = 0; i < miLista.ObtenerElementos().Length; i++) 
            {
                lstLista.Items.Add(miLista.ObtenerElementos()[i]);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
