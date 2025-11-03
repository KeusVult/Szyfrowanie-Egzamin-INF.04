using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Pi
{
    class Cesar
    {
        static public string Szyfr(int key, string tab)
        {
            string encrypted = "";
            int length = tab.Length;

            if (key < -26 || key > 26)
                return "Error";

            for (int i = 0; i < length; i++)
            {
                char c = tab[i];

                if (c == ' ')
                {
                    encrypted += c;
                    continue;
                }

                if (c >= 'A' && c <= 'Z')
                {
                    int shifted = c + key;

                    if (shifted > 'Z')
                        shifted -= 26;
                    else if (shifted < 'A')
                        shifted += 26;

                    encrypted += (char)shifted;
                }
                else if (c >= 'a' && c <= 'z')
                {
                    int shifted = c + key;

                    if (shifted > 'z')
                        shifted -= 26;
                    else if (shifted < 'a')
                        shifted += 26;

                    encrypted += (char)shifted;
                }
                else
                {
                    encrypted += c;
                }
            }
            return encrypted;
        }
    }
}
