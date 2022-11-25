using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTree
{
    internal class AutoNamer
    {
        public AutoNamer(char letter)
        {
            this.letter = letter;
        }
        int index = 0;
        char letter;
        public string Next()
        {
            index++;
            return $"{letter}{index:000}";
        }
    }
}
