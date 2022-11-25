using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTree
{
    internal class COperator
    {
        public COperator(string name, string symbol, string outputType, params string[] inputTypes)
        {
            Name = name;
            Symbol = symbol;
            OutputType = outputType;
            InputTypes = new List<string>(inputTypes);
        }

        public static implicit operator COperator(string name)
        {
            COperator result = GlobalTypes.Operators.Find(op => op.Name == name);
            if (result != null)
                return result;
            else
                throw new Exception($"Undefined operator <{name}>");
        }
        public COperator(string name)
        {
            Name = name;
        }
        public string Name;
        public string Symbol;
        public List<string> InputTypes;
        public string OutputType;
    }
    //internal class BinaryOperator : COperator
    //{
    //    public BinaryOperator(string name, string leftType, string )
    //    public string LeftType => InputTypes[0];
    //    public string RightType => InputTypes[1];
    //}
}
