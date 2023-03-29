using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoUniversidad
{
    public enum operacion
    {
        noDefinida = 0,
        suma = 1,
        resta = 2,
        multiplicacion = 3,
        division = 4,
        modulo = 5
    }
    public partial class Main : Form
    {
        double v1 = 0, v2 = 0;
        operacion operador = operacion.noDefinida;
        bool nroLeido = false;
        public Main()
        {
            InitializeComponent();
        }

        private void leerNumero(string numero)
        {
            nroLeido = true;
            if (txtResult.Text == "0" && txtResult.Text != null)
            {
                txtResult.Text = numero;
            }
            else
            {
                txtResult.Text += numero;
            }
        }

        private double ejecutarOperaciones()
        {
            double res = 0;
            switch (operador)
            {
                case operacion.suma:
                    res = v1 + v2;
                    break;
                case operacion.resta:
                    res = v1 - v2;
                    break;
                case operacion.multiplicacion:
                    res = v1 * v2;
                    break;
                case operacion.division:
                    if(v2 == 0)
                    {
                        lblHistory.Text = "Error";
                        res = 0;
                    }
                    else
                    {
                        res = v1 / v2;
                    }
                    break;
                case operacion.modulo:
                    res = v1 % v2;
                    break;
            }
            return res;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            nroLeido = true;
            if (txtResult.Text == "0")
            {
                return;
            }
            else
            {
                txtResult.Text += "0";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            leerNumero("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            leerNumero("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            leerNumero("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            leerNumero("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            leerNumero("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            leerNumero("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            leerNumero("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            leerNumero("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            leerNumero("9");
        }

        private void obtenerValor(string operador)
        {
            v1 = Convert.ToDouble(txtResult.Text);
            lblHistory.Text = txtResult.Text + operador;
            txtResult.Text = "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            operador = operacion.suma;
            obtenerValor("+");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            operador = operacion.resta;
            obtenerValor("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            operador = operacion.multiplicacion;
            obtenerValor("x");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            operador = operacion.division;
            obtenerValor("/");
        }

        private void bntPercent_Click(object sender, EventArgs e)
        {
            operador = operacion.modulo;
            obtenerValor("%");
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if(v2 == 0 && nroLeido)
            {
                v2 = Convert.ToDouble(txtResult.Text);
                lblHistory.Text += v2 + "=";
                double res = ejecutarOperaciones();
                v1 = 0; v2 = 0;
                nroLeido = false;
                txtResult.Text = Convert.ToString(res);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            lblHistory.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtResult.Text.Length > 1)
            {
                string txtResul = txtResult.Text;
                txtResul = txtResul.Substring(0, txtResul.Length - 1);

                if(txtResul.Length == 1 && txtResul.Contains("-")){
                    txtResult.Text = "0";
                }
                else
                {
                    txtResult.Text = txtResul;
                }
            }
            else
            {
                txtResult.Text = "0";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(txtResult.Text.Contains("."))
            {
                return;
            }
            txtResult.Text += ",";
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Preguntamos al usuario si realmente desea cerrar la aplicación
            DialogResult respuesta = MessageBox.Show("¿Desea cerrar la aplicación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario presiona "No", cancelamos el cierre de la aplicación
            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                // Si el usuario presiona "Sí", cerramos la aplicación
                e.Cancel = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
