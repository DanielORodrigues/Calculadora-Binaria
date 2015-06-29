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
    class OperacoesConvercao
    {
        public static string[] normalizeString(string ovo, string galinha)
        {
            int FisrtNum = ovo.Length;
            int LastNum = galinha.Length;

            if (ovo.Length > galinha.Length)
            {
                for (int i = 0; i < (FisrtNum - LastNum); i++)
                {
                    galinha = "0" + galinha;
                }
            }
            else if (ovo.Length < galinha.Length)
            {
                for (int i = 0; i < (LastNum - FisrtNum); i++)
                {
                    ovo = "0" + ovo;
                }
            }
            string[] r = new string[] { ovo, galinha };
            return r;
        }
        public static string Subtracao(string n1, string n2)
        {
            string ovo = (normalizeString(n1, n2))[0];
            string galinha = (normalizeString(n1, n2))[1];
            string result = "";

            galinha = galinha.Replace('1', 'a');
            galinha = galinha.Replace('0', '1');
            galinha = galinha.Replace('a', '0');

            galinha = Soma(galinha, "1");

            result = Soma(ovo, galinha);
            result = result.Remove(0, 1);
            return result;
        }
        public static string Soma(string soma1, string soma2)
        {
            char[] love = (normalizeString(soma1, soma2))[0].ToCharArray();
            char[] amor = (normalizeString(soma1, soma2))[1].ToCharArray();

            string overflow = "";
            string resultado = "";

            for (int i = love.Length - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(overflow))
                {
                    if (love[i].Equals('0') && amor[i].Equals('0')) resultado = '0' + resultado;
                    if (love[i].Equals('0') && amor[i].Equals('1')) resultado = '1' + resultado;
                    if (love[i].Equals('1') && amor[i].Equals('0')) resultado = '1' + resultado;
                    if (love[i].Equals('1') && amor[i].Equals('1'))
                    {
                        overflow = "1";
                        resultado = "0" + resultado;
                    }
                }
                else if ((love[i].Equals('1') && amor[i].Equals('0')) || love[i].Equals('0') && amor[i].Equals('1'))
                {
                    overflow = "1";
                    resultado = "0" + resultado;
                }
                else if ((love[i].Equals('0') && amor[i].Equals('0')))
                {
                    overflow = "";
                    resultado = "1" + resultado;
                }
                else if (love[i].Equals('1') && amor[i].Equals('1'))
                {
                    overflow = "1";
                    resultado = "1" + resultado;
                }
            }
            string num4 = overflow + resultado;
            string numfinal = num4.Substring(1, num4.Length - 1);
            return overflow + resultado;
        }
        public static string Multiplicacao(string ovo, string galinha)
        {
            string resultado = "0";
            string n = BinDec(galinha);
            for (int i = 0; i < int.Parse(n); i++)
            {
                resultado = Soma(resultado, ovo);
            }
            return resultado;
        }
        public static string InverterString(string s)
        {

            int tamanho = s.Length;

            char[] caract = new char[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                caract[i] = s[tamanho - 1 - i];
            }
            return new string(caract);
        }

        public static string BinDec(string bin)
        {
            int expoente = 0;
            int num;
            int soma = 0;
            string invertnumero = InverterString(bin);

            for (int i = 0; i < bin.Length; i++)
            {
                num = Convert.ToInt32(invertnumero.Substring(i, 1));
                soma += num * (int)(Math.Pow(2, expoente));
                expoente++;
            }
            return soma + "";
        }
        public static string letrasHexa(int d)
        {

            switch (d)
            {
                case 10:
                    return "A";
                    break;
                case 11:
                    return "B";
                    break;
                case 12:
                    return "C";
                    break;
                case 13:
                    return "D";
                    break;
                case 14:
                    return "E";
                    break;
                case 15:
                    return "F";
                    break;
                default:
                    return d + "";
                    break;
            }
        }

        public static string BinHexa(string b)
        {
            string d = BinDec(b);
            return DecHexa(int.Parse(d));
        }
        public static string DecHexa(int d)
        {
            int resto = d % 16;
            int result = (d - resto) / 16;

            if (d == 0)
            {
                return "";
            }
            else
            {
                return DecHexa(result) + letrasHexa(resto);
            }

        }
        public static string DecBin(int n)
        {
            string num = "";
            int dividendo = Convert.ToInt32(n);
            int q;

            if (n == 0)
            {
                return "";
            }
            while (dividendo >= 1)
            {
                q = dividendo / 2;
                num += (dividendo % 2).ToString();
                dividendo = q;
            }
            return InverterString(num);

        }
        public static string Divisao(string ovo, string galinha)
        {
            string resultado = "0";

            if (int.Parse(ovo) >= int.Parse(galinha))
            {
                for (int i = 1; i < int.MaxValue; i++)
                {
                    string d = Multiplicacao(DecBin(i), galinha.ToString());

                    if (int.Parse(d) > int.Parse(ovo))
                    {
                        resultado = DecBin(i - 1);
                        return resultado;
                    }

                    if (int.Parse(d) == int.Parse(ovo))
                    {
                        resultado = DecBin(i);
                        return resultado;
                    }
                }
            }
            else
            {
                MessageBox.Show("Não é possível realizar essa conta pois o segundo número é maior que o primeiro");
                return "";
            }
            return resultado;
        }
    }

}