using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WpfAppCommandBegin
{
    delegate string myDelegate(string myStr, string tmp);
    internal class Class2
    {
        static private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static private Regex regex1 = new Regex(@"(\d+)", RegexOptions.IgnoreCase);
        static private Regex regex2 = new Regex(@"[+/*-]", RegexOptions.IgnoreCase);
        static private string ReadText;
        static private string a = "", result = "", b = "";
        static private string[] arrReadText;
        static private string[] SearchResults()
        {
            arrReadText = ReadText.Split('=');
            myDelegate calculator;
            int count = 0;
            do
            {
                for (int i = count; i < arrReadText.Length - 1; i++)
                {
                    MatchCollection matches1 = regex1.Matches(arrReadText[i]);

                    a = Convert.ToString(matches1[0]);
                    b = Convert.ToString(matches1[1]);
                    MatchCollection matches2 = regex2.Matches(arrReadText[i]);
                    if (Convert.ToString(matches2[0]) == "*")
                    {
                        calculator = Class1.Multiply;
                        result = calculator(a, b);
                    }
                    else if (Convert.ToString(matches2[0]) == "/")
                    {
                        calculator = Class1.Divide;
                        result = calculator(a, b);
                    }
                    else if (Convert.ToString(matches2[0]) == "+")
                    {
                        calculator = Class1.Plus;
                        result = calculator(a, b);
                    }
                    else if (Convert.ToString(matches2[0]) == "-")
                    {
                        calculator = Class1.Minus;
                        result = calculator(a, b);
                    }
                    break;
                }
                arrReadText[count] += "= " + result;
                count++;
            } while (count < arrReadText.Length - 1);
            return arrReadText;
        }
        static public string ResultToString()
        {
            string[] arrReadText = SearchResults();
            string result = "";
            for (int i = 0; i < arrReadText.Length; i++)
            {
                result += arrReadText[i];
            }
            return result;
        }

        static public void ReadTaskFile(string readText)
        {
            ReadText = readText;
        }
       
    }
  
}