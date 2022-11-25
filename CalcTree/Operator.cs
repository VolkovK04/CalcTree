using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTree
{
    internal class Operator
    {
        public Operator(string name, string symbol, string outputType, params string[] inputTypes)
        {
            Name = name;
            Symbol = symbol;
            OutputType = outputType;
            InputTypes = new List<string>(inputTypes);
        }

        public static implicit operator Operator(string name)
        {
            return GlobalTypes.Operators.Find(type => type.Name == name);
        }
        public Operator(string name)
        {
            Name = name;
        }
        public string Name;
        public string Symbol;
        public List<string> InputTypes;
        public string OutputType;
    }
    //internal class BinaryOperator : Operator
    //{
    //    public BinaryOperator(string name, string leftType, string )
    //    public string LeftType => InputTypes[0];
    //    public string RightType => InputTypes[1];
    //}
}
