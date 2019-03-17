using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _4__ASM_Translator.Models
{
    public class Translator
    {
        public static string TranslateLine(string line, bool isBinary = true)
        {
            try
            {
                line = line.Replace("  ", " ").Replace(", ", ",");
                string[] operands = line.Split(' ');
                string[] registers = operands[1].Split(',');
                var mod = "11";//завжди регістри
                char w = '0';
                var reg = GetRegisterCode(registers[0], out w);
                var rm = GetRegisterCode(registers[1], out w);
                var pattern = GetOperatorPatern(operands[0]);

                var code = pattern.Replace('w', w).Replace("mod", mod).Replace("reg", reg).Replace("rm", rm);
                return isBinary ? code : ConvertToHex(code);
            }
            catch (NotImplementedException nex)
            {
                MessageBox.Show(nex.Message, "Помилка трансляції", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Помилка";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Невідома помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Помилка";
            }
        }

        private static string GetRegisterCode(string registerName, out char w)
        {
            if (registerName.Length != 2)
            {
                w = '0';
                return "000";
                throw new NotImplementedException("Такий регістр не підтримується транслятором");
            }

            if (string.Equals(registerName[1].ToString(), "L", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(registerName[1].ToString(), "H", StringComparison.InvariantCultureIgnoreCase))
            {
                w = '0';
            }
            else
            {
                w = '1';
            }

            switch (registerName.ToUpper())
            {
                case "AL":
                case "AX":
                    return "000";
                case "CL":
                case "CX":
                    return "001";
                case "DL":
                case "DX":
                    return "010";
                case "BL":
                case "BX":
                    return "011";
                case "AH":
                case "SP":
                    return "100";
                case "CH":
                case "BP":
                    return "101";
                case "DH":
                case "SI":
                    return "110";
                case "BH":
                case "DI":
                    return "111";
                default:
                    return "000";
            }
        }

        private static string GetOperatorPatern(string operation)
        {
            switch (operation)
            {
                case "MOV":
                    return "1000 100w mod reg rm";
                case "ADD":
                    return "0000 001w mod reg rm";
                default:
                    throw new NotImplementedException("Таку операцію не підтримує транслятор");
            }
        }

        private static string ConvertToHex(string line)
        {
            line = line.Replace(" ", string.Empty);
            int numOfBytes = line.Length / 8;
            string hexCode = string.Empty;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(line.Substring(8 * i, 8), 2);
                hexCode += Convert.ToByte(line.Substring(8 * i, 8), 2).ToString("X2") + " ";
            }
            return hexCode;
        }
    }
}
