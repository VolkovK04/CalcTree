using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTree
{
    internal class AutoNamer
    {
        int index = 0;
        public string Next()
        {
            index++;
            return $"x{index:000}";
        }
    }
}
