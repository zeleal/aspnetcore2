using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ModeloRelacionamentos.Application.Service.Util
{
    public class Util
    {

        /// <summary>
        /// Verifica se o CPF ou CNPJ é valida
        /// </summary>
        /// <param name="cpfcnpj">string</param>
        /// <returns>true ou false</returns>
        public static bool IsCPFCNPJ(string cpfcnpj)
        {
            cpfcnpj = SemFormatacao(cpfcnpj);

            int[] d = new int[14];
            int[] v = new int[2];
            int j, i, soma;
            string Sequencia, SoNumero;

            SoNumero = Regex.Replace(cpfcnpj, "[^0-9]", string.Empty);

            //verificando se todos os numeros são iguais
            if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;

            // se a quantidade de dígitos numérios for igual a 11
            // iremos verificar como CPF
            if (SoNumero.Length == 11)
            {
                for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                for (i = 0; i <= 1; i++)
                {
                    soma = 0;
                    for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                    v[i] = (soma * 10) % 11;
                    if (v[i] == 10) v[i] = 0;
                }
                return (v[0] == d[9] & v[1] == d[10]);
            }
            // se a quantidade de dígitos numérios for igual a 14
            // iremos verificar como CNPJ
            else if (SoNumero.Length == 14)
            {
                Sequencia = "6543298765432";
                for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                for (i = 0; i <= 1; i++)
                {
                    soma = 0;
                    for (j = 0; j <= 11 + i; j++)
                        soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

                    v[i] = (soma * 10) % 11;
                    if (v[i] == 10) v[i] = 0;
                }
                return (v[0] == d[12] & v[1] == d[13]);
            }
            // CPF ou CNPJ inválido se
            // a quantidade de dígitos numérios for diferente de 11 e 14
            else return false;
        }

        /// <summary>
        /// Criptografar senha para salvar no banco
        /// </summary>
        /// <param name="value">string</param>
        /// <returns>senha criptografada</returns>
        public static string HashValue(string value)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] hashBytes;
            using (HashAlgorithm hash = SHA1.Create())
                hashBytes = hash.ComputeHash(encoding.GetBytes(value));

            StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return hashValue.ToString();
        }

        /// <summary>
        /// Criptografar senha para salvar no banco
        /// </summary>
        /// <param name="valor">string</param>
        /// <returns>senha criptografada para o ISS</returns>
        public static string gerarHash(string valor)
        {
            SHA1Managed sha1 = new SHA1Managed();
            sha1.ComputeHash(Encoding.Default.GetBytes(valor));
            return Convert.ToBase64String(sha1.Hash);
        }

        /// <summary>
        /// Validação de email
        /// </summary>
        /// <param name="string"></param>
        /// <returns>Verdadeiro ou Falso</returns>
        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        /// <summary>
        /// Formatar uma string CNPJ
        /// </summary>
        /// <param name="CNPJ">string CNPJ sem formatacao</param>
        /// <returns>string CNPJ formatada</returns>
        /// <example>Recebe '99999999999999' Devolve '99.999.999/9999-99'</example>
        public static string FormatCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        /// <summary>
        /// Formatar uma string CPF
        /// </summary>
        /// <param name="CPF">string CPF sem formatacao</param>
        /// <returns>string CPF formatada</returns>
        /// <example>Recebe '99999999999' Devolve '999.999.999-99'</example>
        public static string FormatCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        /// <summary>
        /// Formatar CPF ou CNPJ com base no tamanho
        /// </summary>
        /// <param name="CPFCNPJ">string para formatar</param>
        /// <returns>string CPF / CNPJ formatado</returns>
        public static string FormataCPF_CNPJ(string CPFCNPJ)
        {
            if(CPFCNPJ.Length > 11)
            {
                return FormatCNPJ(CPFCNPJ);
            } else
            {
                return FormatCPF(CPFCNPJ);
            }
        }

        /// <summary>
        /// Formata com a mascara de CEP
        /// </summary>
        /// <param name="CEP">string sem formatação</param>
        /// <returns>string CEP formatada</returns>
        /// <example>Recebe 99999999 Devolve 99.999-999</example>
        public static string FormatCEP(string CEP)
        {
            return Convert.ToUInt64(CEP).ToString(@"00\.000\-000");
        }

        /// <summary>
        /// Formata uma string em mascara de Telefone
        /// </summary>
        /// <param name="telefone"></param>
        /// <returns></returns>
        public static string FormataTelefone(string telefone)
        {
            if (String.IsNullOrEmpty(telefone))
                return String.Empty;
            else
                return telefone.Length == 8 ? Convert.ToUInt64(telefone).ToString(@"0000\-0000") : Convert.ToUInt64(telefone).ToString(@"00000\-0000");
        }

        /// <summary>
        /// Retira a Formatacao de uma string CNPJ/CPF
        /// </summary>
        /// <param name="Codigo">string Codigo Formatada</param>
        /// <returns>string sem formatacao</returns>
        /// <example>Recebe '99.999.999/9999-99' Devolve '99999999999999'</example>
        public static string SemFormatacao(string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }

        public static decimal FormatarStringBrasiltoDecimal(string valor)
        {
            string format1 = valor.Replace(".", "");
            //string format2 = format1.Replace(",",".");
            decimal formatoDecimal = Convert.ToDecimal(format1);
            decimal d = decimal.Parse(format1, CultureInfo.InvariantCulture);
            return Convert.ToDecimal(valor);
        }
    }
}
