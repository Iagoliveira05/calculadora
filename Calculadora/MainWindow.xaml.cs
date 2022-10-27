using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double numeroAtual;
        double numeroAnterior;
        string strNumeroAtual;
        string strNumeroAnterior;
        string operadorEscolhido;
        double resultado;
        bool error;
        public MainWindow()
        {
            InitializeComponent();
            btnFoco.Focus();  // Habilitar a entrada de tecla inicial
            ResetarInformacoes();
            
        }

        private void LimparUltimoRegistro(object sender = null, RoutedEventArgs e = null)
        {
            txtNumeroAtual.Text = "0";
            strNumeroAtual = "0";
            
        }

        private void LimparTudo(object sender = null, RoutedEventArgs e = null)
        {
            txtNumeroAnterior.Text = "";
            txtNumeroAtual.Text = "0";
            ResetarInformacoes();
            
        }

        private void ResetarInformacoes()
        {
            numeroAtual = 0;
            strNumeroAtual = "0";
            txtNumeroAtual.Text = strNumeroAtual;
            txtNumeroAnterior.Text = "";
            operadorEscolhido = "";
            error = false;
            
        }
        private void ApagarUltimoCaractere(object sender = null, RoutedEventArgs e = null)
        {
            strNumeroAtual = strNumeroAtual.Length == 1 ? "0" : strNumeroAtual.Remove(strNumeroAtual.Length - 1);
            txtNumeroAtual.Text = strNumeroAtual;
            
        }

        private void NumeroApertado(object sender, RoutedEventArgs e)
        {
            Button btnApertado = (Button)sender;
            string nomeBotao = btnApertado.Name.ToString();
            VerificarNumero(nomeBotao);
            
        }

        private void VerificarNumero(string nomeBotao)
        {
            if (error) ResetarInformacoes();
            if (strNumeroAtual == "0" && nomeBotao != "btnNumero0") ApagarZero();
            switch (nomeBotao)
            {
                case "btnNumero0":
                    strNumeroAtual = strNumeroAtual != "0" ? strNumeroAtual + "0" : "0";
                    break;
                case "btnNumero1":
                    strNumeroAtual += "1";
                    break;
                case "btnNumero2":
                    strNumeroAtual += "2";
                    break;
                case "btnNumero3":
                    strNumeroAtual += "3";
                    break;
                case "btnNumero4":
                    strNumeroAtual += "4";
                    break;
                case "btnNumero5":
                    strNumeroAtual += "5";
                    break;
                case "btnNumero6":
                    strNumeroAtual += "6";
                    break;
                case "btnNumero7":
                    strNumeroAtual += "7";
                    break;
                case "btnNumero8":
                    strNumeroAtual += "8";
                    break;
                case "btnNumero9":
                    strNumeroAtual += "9";
                    break;
            }
            txtNumeroAtual.Text = strNumeroAtual;
            
        }

        private void ApagarZero()
        {
            strNumeroAtual = "";
        }

        private void Dividir(object sender = null, RoutedEventArgs e = null)      // Criar metodo operadores para abranger todos 
        {
            if (operadorEscolhido != "÷")
            {
                txtNumeroAnterior.Text = $"{strNumeroAtual} ÷";
                operadorEscolhido = "÷";
                numeroAnterior = Convert.ToDouble(strNumeroAtual);
                strNumeroAnterior = txtNumeroAtual.Text;
                strNumeroAtual = "0";
                numeroAtual = 0;
            }
            else
            {
                RealizarOperacao();
            }
            
        }

        private void Multiplicar(object sender = null, RoutedEventArgs e = null)
        {
            if (operadorEscolhido != "x")
            {
                txtNumeroAnterior.Text = $"{strNumeroAtual} x";
                operadorEscolhido = "x";
                numeroAnterior = Convert.ToDouble(strNumeroAtual);
                strNumeroAnterior = txtNumeroAtual.Text;
                strNumeroAtual = "0";
                numeroAtual = 0;
            }
            else
            {
                RealizarOperacao();
            }
            
        }

        private void Subtrair(object sender = null, RoutedEventArgs e = null)
        {
            if (operadorEscolhido != "-")
            {
                txtNumeroAnterior.Text = $"{strNumeroAtual} -";
                operadorEscolhido = "-";
                numeroAnterior = Convert.ToDouble(strNumeroAtual);
                strNumeroAnterior = txtNumeroAtual.Text;
                strNumeroAtual = "0";
                numeroAtual = 0;
            }
            else
            {
                RealizarOperacao();
            }
            
        }

        private void Somar(object sender = null, RoutedEventArgs e = null)
        {
            if (operadorEscolhido != "+")
            {
                txtNumeroAnterior.Text = $"{strNumeroAtual} +";
                operadorEscolhido = "+";
                numeroAnterior = Convert.ToDouble(strNumeroAtual);
                strNumeroAnterior = txtNumeroAtual.Text;
                strNumeroAtual = "0";
                numeroAtual = 0;
            }
            else
            {
                RealizarOperacao();
            }
            
        }

        private void RealizarOperacao()
        {
            numeroAtual = Convert.ToDouble(strNumeroAtual);
            switch (operadorEscolhido)
            {
                case "÷":
                    if (numeroAtual == 0)
                    {
                        txtNumeroAtual.Text = "Error";
                        resultado = 0;
                        error = true;
                    }
                    else
                    {
                        resultado = numeroAnterior / numeroAtual;
                        txtNumeroAtual.Text = resultado.ToString();
                    }
                    break;
                case "x":
                    resultado = numeroAnterior * numeroAtual;
                    txtNumeroAtual.Text = resultado.ToString();
                    break;
                case "-":
                    if (numeroAtual != 0)
                    {
                        resultado = numeroAnterior - numeroAtual;
                        txtNumeroAtual.Text = resultado.ToString();
                    }
                    break;
                case "+":
                    resultado = numeroAnterior + numeroAtual;
                    txtNumeroAtual.Text = resultado.ToString();
                    break;
            }

            txtNumeroAnterior.Text = $"{resultado} {operadorEscolhido}";
            strNumeroAtual = "0";
            numeroAnterior = resultado;
            numeroAtual = 0;
            
        }

        private void AdicionarVirgula(object sender = null, RoutedEventArgs e = null)
        {
            if (strNumeroAtual.IndexOf(",") == -1)  // Não possui virgula
            {
                strNumeroAtual += ",";
                txtNumeroAtual.Text = strNumeroAtual;
                numeroAtual = Convert.ToDouble(strNumeroAtual);
            }
            
        }

        private void Igualar(object sender = null, RoutedEventArgs e = null)
        {
            if (operadorEscolhido != "")
            {
                RealizarOperacao();
                txtNumeroAnterior.Text = txtNumeroAnterior.Text.Remove(txtNumeroAtual.Text.Length);
                txtNumeroAnterior.Text += " =";
            }
            else
            {
                txtNumeroAnterior.Text = $"{strNumeroAtual} =";
            }
            
        }

        private void TeclaPressionada(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0 or Key.NumPad0:
                    VerificarNumero("btnNumero0");
                    break;
                case Key.D1 or Key.NumPad1:
                    VerificarNumero("btnNumero1");
                    break;
                case Key.D2 or Key.NumPad2:
                    VerificarNumero("btnNumero2");
                    break;
                case Key.D3 or Key.NumPad3:
                    VerificarNumero("btnNumero3");
                    break;
                case Key.D4 or Key.NumPad4:
                    VerificarNumero("btnNumero4");
                    break;
                case Key.D5 or Key.NumPad5:
                    VerificarNumero("btnNumero5");
                    break;
                case Key.D6 or Key.NumPad6:
                    VerificarNumero("btnNumero6");
                    break;
                case Key.D7 or Key.NumPad7:
                    VerificarNumero("btnNumero7");
                    break;
                case Key.D8 or Key.NumPad8:
                    VerificarNumero("btnNumero8");
                    break;
                case Key.D9 or Key.NumPad9:
                    VerificarNumero("btnNumero9");
                    break;
                case Key.Delete:
                    LimparUltimoRegistro();
                    break;
                case Key.Escape:
                    LimparTudo();
                    break;
                case Key.Back:
                    ApagarUltimoCaractere();
                    break;
                case Key.Divide or Key.AbntC1:
                    Dividir();
                    break;
                case Key.Multiply:
                    Multiplicar();
                    break;
                case Key.Subtract or Key.OemMinus:
                    Subtrair();
                    break;
                case Key.Add or Key.OemPlus:
                    Somar();
                    break;
                case Key.Decimal or Key.OemComma:
                    AdicionarVirgula();
                    break;
                case Key.Return:
                    Igualar();
                    break;
            }
        }
    }
}
