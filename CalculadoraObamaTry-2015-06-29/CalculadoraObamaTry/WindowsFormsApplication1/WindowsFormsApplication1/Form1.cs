using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        double value = 0;
        double value2 = 0;
        string operacao = "";
        bool operacao_pressed = false;

        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || (operacao_pressed)) result.Clear();

            operacao_pressed = false;
            Button b = (Button)sender;
            result.Text += b.Text;
        }
        private void Vetar(object sender, KeyPressEventArgs e)
        {
            string teclasPossiveis = "01";
            e.Handled = (teclasPossiveis.IndexOf(e.KeyChar) == -1);

            if (e.KeyChar.Equals((char)8))
            {
                e.Handled = false;
            }
        }
        private void operacao_Click(object sender, EventArgs e)
        {
            if (operacao != "")
            {
                Operacoes();
            }

            value2 = double.Parse(result.Text);
            Button b = (Button)sender;

            if (value != 0)
            {
                operacao_pressed = true;
                operacao = b.Text;
            }

            else
            {
                operacao = b.Text;
                operacao_pressed = true;
            }
        }
        private void resultado_Click(object sender, EventArgs e)
        {
            Operacoes();
            operacao = "";
        }
        private void Operacoes()
        {
            value = double.Parse(result.Text);

            switch (operacao)
            {
                case "+":
                    result.Text = OperacoesConvercao.Soma((value2).ToString(),(value).ToString());
                    break;

                case "-":
                    result.Text = OperacoesConvercao.Subtracao((value2).ToString(),(value).ToString());
                    break;

                case "*":
                    result.Text = OperacoesConvercao.Multiplicacao((value2).ToString(),(value).ToString());
                    break;

                case "/":
                    result.Text = OperacoesConvercao.Divisao((value2).ToString(), (value).ToString());
                    break;
            }
        }

        
       private void CE_Click(object sender, EventArgs e)
       {
           result.Text = "0";
           result_convert.Text = "";
           value = 0;
       }
       private void C_Click(object sender, EventArgs e)
       {
           result.Clear();
           result_convert.Clear();
           value = 0;
           result.Text = "0";
           operacao = "";
       }
        private void Convert(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) 
            {
                result_convert.Text = OperacoesConvercao.BinDec(result.Text);
            }

            if (radioButton2.Checked == true)
            {
                result_convert.Text = OperacoesConvercao.BinHexa(result.Text);
            }
        }
    }         
}

            

