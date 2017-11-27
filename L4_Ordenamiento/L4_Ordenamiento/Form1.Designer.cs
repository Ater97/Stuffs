namespace L4_Ordenamiento
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMerge = new System.Windows.Forms.Button();
            this.lstOrdenado = new System.Windows.Forms.ListBox();
            this.lstDesordenado = new System.Windows.Forms.ListBox();
            this.btnQuicksort = new System.Windows.Forms.Button();
            this.btnBurbuja = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.BtnInsercion = new System.Windows.Forms.Button();
            this.BtnSeleccion = new System.Windows.Forms.Button();
            this.BtnShell = new System.Windows.Forms.Button();
            this.BtnShell2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(209, 101);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 15;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // lstOrdenado
            // 
            this.lstOrdenado.FormattingEnabled = true;
            this.lstOrdenado.Location = new System.Drawing.Point(164, 154);
            this.lstOrdenado.Name = "lstOrdenado";
            this.lstOrdenado.Size = new System.Drawing.Size(120, 160);
            this.lstOrdenado.TabIndex = 14;
            // 
            // lstDesordenado
            // 
            this.lstDesordenado.FormattingEnabled = true;
            this.lstDesordenado.Location = new System.Drawing.Point(23, 154);
            this.lstDesordenado.Name = "lstDesordenado";
            this.lstDesordenado.Size = new System.Drawing.Size(120, 160);
            this.lstDesordenado.TabIndex = 13;
            // 
            // btnQuicksort
            // 
            this.btnQuicksort.Location = new System.Drawing.Point(116, 101);
            this.btnQuicksort.Name = "btnQuicksort";
            this.btnQuicksort.Size = new System.Drawing.Size(75, 23);
            this.btnQuicksort.TabIndex = 12;
            this.btnQuicksort.Text = "Quicksort";
            this.btnQuicksort.UseVisualStyleBackColor = true;
            this.btnQuicksort.Click += new System.EventHandler(this.btnQuicksort_Click);
            // 
            // btnBurbuja
            // 
            this.btnBurbuja.Location = new System.Drawing.Point(23, 101);
            this.btnBurbuja.Name = "btnBurbuja";
            this.btnBurbuja.Size = new System.Drawing.Size(75, 23);
            this.btnBurbuja.TabIndex = 11;
            this.btnBurbuja.Text = "Bubble";
            this.btnBurbuja.UseVisualStyleBackColor = true;
            this.btnBurbuja.Click += new System.EventHandler(this.btnBurbuja_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Archivo:";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(72, 27);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(201, 20);
            this.txtFile.TabIndex = 9;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(23, 53);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(92, 23);
            this.btnCargar.TabIndex = 8;
            this.btnCargar.Text = "Cargar Archivo";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // BtnInsercion
            // 
            this.BtnInsercion.Location = new System.Drawing.Point(303, 101);
            this.BtnInsercion.Name = "BtnInsercion";
            this.BtnInsercion.Size = new System.Drawing.Size(75, 23);
            this.BtnInsercion.TabIndex = 16;
            this.BtnInsercion.Text = "Insercion";
            this.BtnInsercion.UseVisualStyleBackColor = true;
            this.BtnInsercion.Click += new System.EventHandler(this.Insercion_Click);
            // 
            // BtnSeleccion
            // 
            this.BtnSeleccion.Location = new System.Drawing.Point(394, 101);
            this.BtnSeleccion.Name = "BtnSeleccion";
            this.BtnSeleccion.Size = new System.Drawing.Size(75, 23);
            this.BtnSeleccion.TabIndex = 17;
            this.BtnSeleccion.Text = "Seleccion";
            this.BtnSeleccion.UseVisualStyleBackColor = true;
            this.BtnSeleccion.Click += new System.EventHandler(this.BtnSeleccion_Click);
            // 
            // BtnShell
            // 
            this.BtnShell.Location = new System.Drawing.Point(485, 130);
            this.BtnShell.Name = "BtnShell";
            this.BtnShell.Size = new System.Drawing.Size(75, 23);
            this.BtnShell.TabIndex = 18;
            this.BtnShell.Text = "Shell.2";
            this.BtnShell.UseVisualStyleBackColor = true;
            this.BtnShell.Click += new System.EventHandler(this.BtnShell_Click);
            // 
            // BtnShell2
            // 
            this.BtnShell2.Location = new System.Drawing.Point(485, 101);
            this.BtnShell2.Name = "BtnShell2";
            this.BtnShell2.Size = new System.Drawing.Size(75, 23);
            this.BtnShell2.TabIndex = 19;
            this.BtnShell2.Text = "Shell";
            this.BtnShell2.UseVisualStyleBackColor = true;
            this.BtnShell2.Click += new System.EventHandler(this.BtnShell2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 355);
            this.Controls.Add(this.BtnShell2);
            this.Controls.Add(this.BtnShell);
            this.Controls.Add(this.BtnSeleccion);
            this.Controls.Add(this.BtnInsercion);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.lstOrdenado);
            this.Controls.Add(this.lstDesordenado);
            this.Controls.Add(this.btnQuicksort);
            this.Controls.Add(this.btnBurbuja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnCargar);
            this.Name = "Form1";
            this.Text = "Ordenamiento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.ListBox lstOrdenado;
        private System.Windows.Forms.ListBox lstDesordenado;
        private System.Windows.Forms.Button btnQuicksort;
        private System.Windows.Forms.Button btnBurbuja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button BtnInsercion;
        private System.Windows.Forms.Button BtnSeleccion;
        private System.Windows.Forms.Button BtnShell;
        private System.Windows.Forms.Button BtnShell2;
    }
}

