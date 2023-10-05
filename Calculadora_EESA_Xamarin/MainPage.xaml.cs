using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora_EESA_Xamarin
{
    public partial class MainPage : ContentPage
    {
        string entrada;
        double resultado = 0;
        string operador = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void Numero(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            string textoBoton = boton.Text;

            if (textoBoton == "AC")
            {
                entrada = "";
                resultado = 0;
                operador = "";
            }
            else if (textoBoton == "C")
            {
                entrada = "";
            }
            else if (textoBoton == "=")
            {
                if (!string.IsNullOrEmpty(entrada))
                {
                    double numeroActual = double.Parse(entrada);
                    switch (operador)
                    {
                        case "+":
                            resultado += numeroActual;
                            break;
                        case "-":
                            resultado -= numeroActual;
                            break;
                        case "*":
                            resultado *= numeroActual;
                            break;
                        case "/":
                            if (numeroActual != 0)
                                resultado /= numeroActual;
                            else
                                Resultado.Text = "Error";
                            break;
                        case "%":
                            resultado %= numeroActual;
                            break;
                        default:
                            resultado = numeroActual;
                            break;
                    }
                    entrada = resultado.ToString();
                    operador = "";
                }
            }
            else
            {
                entrada += textoBoton;
            }

            Resultado.Text = entrada;
        }
    }
}
