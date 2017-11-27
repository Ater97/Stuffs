using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace L4_Ordenamiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
          o	Burbuja
          o	Inserción
          o	Selección
          o	Shell
          o	Quicksort (Recursivo)
          o	Mergesort (Recursivo
        */
        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                string path = ofd.FileName;
                if (ofd.FileName.Trim() != "")
                {
                    string data = File.ReadAllText(ofd.FileName).Replace("\r\n", ",");
                    string[] strNumeros = data.Split(',');
                    lstDesordenado.Items.Clear();
                    for (int i = 0; i < strNumeros.Length; i++)
                    {
                        if (strNumeros[i].Trim() != "")
                        {
                            lstDesordenado.Items.Add(strNumeros[i]);
                        }
                    }

                    txtFile.Text = path;

                }
            }
        }

        void Burbuja(int[] arrNumeros)
        {
            for (int i = 0; i < arrNumeros.Length; i++)
            {
                for (int j = 0; j < arrNumeros.Length - 1; j++)
                {
                    if (arrNumeros[j] > arrNumeros[j + 1])
                    {
                        int aux = arrNumeros[j];
                        arrNumeros[j] = arrNumeros[j + 1];
                        arrNumeros[j + 1] = aux;
                    }
                }
            }
        }

        void Quicksort(int[] arrNumeros, int inf, int sup)
        {
            int i = inf - 1;
            int j = sup;
            bool bandera = true;
            int temp = 0;

            if (inf >= sup)
                return;

            int elem_div = arrNumeros[sup];

            while (bandera)
            {
                while (arrNumeros[++i] < elem_div) ;
                while ((arrNumeros[--j] > elem_div) && (j > inf)) ;

                if (i < j)
                {
                    temp = arrNumeros[i];
                    arrNumeros[i] = arrNumeros[j];
                    arrNumeros[j] = temp;
                }
                else
                {
                    bandera = false;
                }
            }

            temp = arrNumeros[i];
            arrNumeros[i] = arrNumeros[sup];
            arrNumeros[sup] = temp;
            Quicksort(arrNumeros, inf, i - 1);
            Quicksort(arrNumeros, i + 1, sup);

        }
   
        
        void Mergesort(int[] arrNumeros, int init, int n)
        {
            int n1;
            int n2;
            if (n > 1)
            {
                n1 = n / 2;
                n2 = n - n1;
                Mergesort(arrNumeros, init, n1);
                Mergesort(arrNumeros, init + n1, n2);
                Merge(arrNumeros, init, n1, n2, n);
            }
        }

        void Merge(int[] arrNumeros, int init, int n1, int n2, int n)
        {
            int[] auxNumeros = new int[n];

            for (int i = 0; i < n; i++)
            {
                auxNumeros[i] = 0;
            }

            int temp = 0;
            int temp1 = 0;
            int temp2 = 0;

            while ((temp1 < n1) && (temp2 < n2))
            {
                if (arrNumeros[init + temp1] < arrNumeros[init + n1 + temp2])
                    auxNumeros[temp++] = arrNumeros[init + (temp1++)];
                else
                    auxNumeros[temp++] = arrNumeros[init + n1 + (temp2++)];
            }

            while (temp1 < n1)
                auxNumeros[temp++] = arrNumeros[init + (temp1++)];
            while (temp2 < n2)
                auxNumeros[temp++] = arrNumeros[init + n1 + (temp2++)];

            for (int i = 0; i < n1 + n2; i++)
                arrNumeros[init + i] = auxNumeros[i];

        }
        public void Insercion(int [] arrNumeros)
        {
            int temp;
            int j;

            for (int i = 0; i < arrNumeros.Length; i++)
            {
                temp = arrNumeros[i];
                j = i - 1;
                while (j >= 0 && arrNumeros[j] > temp)
                {
                    arrNumeros[j + 1] = arrNumeros[j];
                    j--;
                }
                arrNumeros[j + 1] = temp;
            }
        }

        public void Seleccion(int[] arrNumeros)
        {

            int minimo = 0;
            int i = 0;
            int j = 0;
            int swap;
            for (i = 0; i < arrNumeros.Length - 1; i++)
            {
                minimo = i;
                for (j = i + 1; j < arrNumeros.Length; j++)
                    if (arrNumeros[minimo] > arrNumeros[j])
                        minimo = j;
                swap = arrNumeros[minimo];
                arrNumeros[minimo] = arrNumeros[i];
                arrNumeros[i] = swap;
            }
        }

        public void Shell(int[] arrNumeros)
        {
            int salto = arrNumeros.Length / 2;
            int aux;
            int j;
            int i;
            int k = 0;
            while (salto>0)
            {
                for(i = salto +1; i<arrNumeros.Length;i++)
                {
                    j = i - salto;
                    while(j>0)
                    {
                        k = j + salto;
                        if(arrNumeros[j]<=arrNumeros[k])
                        {
                            j = 0;
                        }
                        else
                        {
                            aux = arrNumeros[j];
                            arrNumeros[j] = arrNumeros[k];
                            arrNumeros[k] = aux;
                        }
                        j = j - salto;
                    }
                }
                salto = salto / 2;
            }
        }

        public void Shell2(int[] arrNumeros)
        {
            int salto = 0;
            int a = 0;
            int auxi = 0;
            int b = 0;
            salto = arrNumeros.Length / 2;
            while (salto > 0)
            {
                a = 1;
                while (a != 0)
                {
                    a = 0;
                    b = 1;

                    while (b <= (arrNumeros.Length - salto))
                    {
                        if (arrNumeros[b - 1] > arrNumeros[(b - 1) + salto])
                        {
                            auxi = arrNumeros[(b - 1) + salto];
                            arrNumeros[(b - 1) + salto] = arrNumeros[b - 1];
                            arrNumeros[(b - 1)] = auxi;
                            a = 1;
                        }
                        b++;
                    }
                }
                salto = salto / 2;
            }
        }
        private void Mostrar(int[] datos, ListBox contenedor)
        {
            contenedor.Items.Clear();
            for (int i = 0; i < datos.Length; i++)
            {
                contenedor.Items.Add(datos[i]);
            }
        }

        private int[] ObtenerDesordenados()
        {
            if (lstDesordenado.Items.Count <= 0)
                return null;

            int[] datos = new int[lstDesordenado.Items.Count];

            for (int i = 0; i < lstDesordenado.Items.Count; i++)
            {
                datos[i] = Convert.ToInt32(lstDesordenado.Items[i]);
            }

            return datos;
        }

        private void btnBurbuja_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] datos = ObtenerDesordenados();
            Burbuja(datos);
            Mostrar(datos, lstOrdenado);
            sw.Stop();
            MessageBox.Show("El tiempo ha sido: " + sw.ElapsedMilliseconds);
        }

        private void btnQuicksort_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] datos = ObtenerDesordenados();
            Quicksort(datos, 0, datos.Length - 1);
            Mostrar(datos, lstOrdenado);
            sw.Stop();
            MessageBox.Show("El tiempo ha sido: " + sw.ElapsedMilliseconds);
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] datos = ObtenerDesordenados();
            Mergesort(datos, 0, datos.Length);
            Mostrar(datos, lstOrdenado);
            sw.Stop();
            MessageBox.Show("El tiempo ha sido: " + sw.ElapsedMilliseconds);   
        }

        private void Insercion_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] datos = ObtenerDesordenados();
            Insercion(datos);
            Mostrar(datos, lstOrdenado);
            sw.Stop();
            MessageBox.Show("El tiempo ha sido: " + sw.ElapsedMilliseconds);
        }

        private void BtnSeleccion_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] datos = ObtenerDesordenados();
            Seleccion(datos);
            Mostrar(datos, lstOrdenado);
            sw.Stop();
            MessageBox.Show("El tiempo ha sido: " + sw.ElapsedMilliseconds);
        }

        private void BtnShell_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] datos = ObtenerDesordenados();
            Shell(datos);
            Mostrar(datos, lstOrdenado);
            sw.Stop();
            MessageBox.Show("El tiempo ha sido: " + sw.ElapsedMilliseconds);
        }

        private void BtnShell2_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] datos = ObtenerDesordenados();
            Shell2(datos);
            Mostrar(datos, lstOrdenado);
            sw.Stop();
            MessageBox.Show("El tiempo ha sido: " + sw.ElapsedMilliseconds);
        }
    }
}
