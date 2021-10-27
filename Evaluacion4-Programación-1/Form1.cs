using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion4_Programación_1
{
    public partial class Form1 : Form
    {
        Anatomia ana = new Anatomia();
        //public Anatomia[] Muscles { get; set; }
        // public int pos = -1;
        public ListaAlumnos Lista { get; set; } = new ListaAlumnos();
        public Form1()
        {
            InitializeComponent();
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            
            
            ana.Musculos = txtNombreMusculo.Text;
            ana.AlumnoSeleccionadoLista = Convert.ToInt32(txtNúmeroAlumno.Text);
            
            //Anatomia anatomia = new Anatomia();
            //anatomia.Musculos = txtNombreMusculo.Text;
            //anatomia.AlumnoSeleccionadoLista = Convert.ToInt32(txtNúmeroAlumno.Text);
            //pos = pos + 1;
            //Lista.Redimencionar();
            //Lista.Muscles[Lista.Muscles.Length - 1] = anatomia;

            if(!Lista.UpdatePersona(ana))
            {
                //Con el focus hacemos que valla a un determinado lugar.
                txtNúmeroAlumno.Focus();
                txtNúmeroAlumno.SelectAll();
                lblLista.Text = "Numero no encontrado en la lista";
            }
            else
            {
                btMostrar_Click(null, null);
                txtNombreMusculo.Text = "";
                txtNúmeroAlumno.Text = "";
                txtNombreMusculo.Focus();
                
            }
            ana = new Anatomia();
        }

        private void btMostrar_Click(object sender, EventArgs e)
        {
            //lblLista.Text = "Lista:\r\n";
            //foreach (Anatomia item in Lista.Muscles)
            //{
            //lblLista.Text = lblLista.Text + item.AlumnoSeleccionadoLista.ToString() + item.Musculos + "\r\n";
            lblLista.Text = Lista.ToString();
            
        }

        private void btFiltro_Click(object sender, EventArgs e)
        {
            lblLista.Text = Lista.ToStringFiltrado(0);
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            ana = Lista.BuscarCodigo(Convert.ToInt32(txtCódigo.Text));
            if(ana.Id > 0)
            {
                txtNombreMusculo.Text = ana.Musculos;
                txtNúmeroAlumno.Text = ana.AlumnoSeleccionadoLista.ToString();

                txtNombreMusculo.Focus();
            }
            else
            {
                txtCódigo.Text = "no existe";
                txtCódigo.Focus();
                txtCódigo.SelectAll();
            }
           
        }

        //private void Redimencionar()
        //{
        //if (Muscles == null)
        //{
        //Muscles = new Anatomia [1];
        //}
        //else
        //{
        //Anatomia[] Arraux = new Anatomia[Muscles.Length + 1];
        //for (int i = 0; i < Muscles.Length; i++)
        //{
        //Arraux[i] = Muscles[i];
        //}
        //Muscles = Arraux;
        //}
        //}
    }
}
