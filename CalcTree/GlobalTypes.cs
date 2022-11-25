using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTree
{
    internal static class GlobalTypes
    {
        static GlobalTypes()
        {
            VarTypes.Add(new CType("Integer", "%d", "int"));
            VarTypes.Add(new CType("Double", "%f", "double"));
            VarTypes.Add(new CType("Matrix"));
            VarTypes.Add(new CType("Vector"));

            Operators.Add(new Operator("SumInt", "+", "Integer", "Integer", "Integer"));
        }

        public static List<CType> VarTypes = new List<CType>();

        public static List<Operator> Operators = new List<Operator>();
    }
}
