using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnABinario_Click(object sender, EventArgs e)
        {
            Numero numeroResultado = new Numero(lblResultado.Text);
            if (lblResultado.Text != "Valor invalido" & lblResultado.Text != "")
            {
                lblResultado.Text = numeroResultado.DecimalBinario(lblResultado.Text);
            }
        }

        private void btnADecimal_Click(object sender, EventArgs e)
        {
            Numero numeroResultado = new Numero(lblResultado.Text);
            if (lblResultado.Text != "Valor invalido" & lblResultado.Text != "")
            {
                lblResultado.Text = numeroResultado.BinarioDecimal(lblResultado.Text);
            }
        }

        public void LaCalculadora() 
        {

        }
        public void Limpiar() 
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }
        static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }
    }
}