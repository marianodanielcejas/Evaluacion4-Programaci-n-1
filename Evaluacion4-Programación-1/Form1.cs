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
        
        public ListaAlumnos Lista { get; set; } = new ListaAlumnos();
        public Form1()
        {
            InitializeComponent();

            dg.DataSource = Lista.DT;
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            
            
            ana.Musculos = txtNombreMusculo.Text;
            ana.AlumnoSeleccionadoLista = Convert.ToInt32(txtNúmeroAlumno.Text);
            ana.CondiciónAlumno = txtCondiciónAlumno.Text;
            
            

            if(!Lista.UpdatePersona(ana))
            {
                
                txtNúmeroAlumno.Focus();
                txtNúmeroAlumno.SelectAll();
                lblLista.Text = "Numero no encontrado en la lista";
            }
            else
            {
                Limpiar();
            }
            ana = new Anatomia();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            ana = Lista.BuscarCodigo(Convert.ToInt32(txtCódigo.Text));
            if(ana.Id > 0)
            {
                txtNombreMusculo.Text = ana.Musculos;
                txtNúmeroAlumno.Text = ana.AlumnoSeleccionadoLista.ToString();
                txtCondiciónAlumno.Text = ana.CondiciónAlumno;

                txtNombreMusculo.Focus();
                txtCódigo.Text = "";
            }
            else
            {
                txtCódigo.Text = "no existe";
                txtCódigo.Focus();
                txtCódigo.SelectAll();
            }
           
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            if (Lista.DeleteMuscle(ana))
            {
                Limpiar();
            }
            else
            {
                lblLista.Text = "El registro " + ana.Musculos + "No se pudo borrar";
                Limpiar();
            }
            ana = new Anatomia();
        }
        private void Limpiar()
        {
            txtNombreMusculo.Text = "";
            txtNúmeroAlumno.Text = "";
            txtCondiciónAlumno.Text = "";
            txtNombreMusculo.Focus();
            lblLista.Text = "";
        }

    }
}
