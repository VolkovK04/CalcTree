using System.Collections.Generic;

namespace CalcTree
{


    internal class Node
    {
        static AutoNamer varNamer = new AutoNamer('x');

        public Node(string name)
        {
            NodeName = name;
        }
        public Node()
        {
            NodeName = varNamer.Next();
        }
        public List<Node> children = new List<Node>();
        public List<Node> parents = new List<Node>();
        public string NodeName;
    }
    internal class ConstNode : Node
    {
        public ConstNode(string name, CType varType, string value) : base(name)
        {
            VarType = varType;
            Value = value;
        }
        public ConstNode(CType varType, string value) : base()
        {
            VarType = varType;
            Value = value;
        }
        public string Value;
        public CType VarType;
    }

    internal class VarNode : Node
    {
        public VarNode(string name, CType varType) : base(name)
        {
            VarType = varType;
        }
        public VarNode(CType varType) : base()
        {
            VarType = varType;
        }
        public CType VarType;
    }
    internal class OperatorNode : Node
    {
        public OperatorNode(string name, CType varType, COperator @operator) : base(name)
        {
            VarType = varType;
            Operator = @operator;
        }
        public OperatorNode(CType varType, COperator @operator) : base()
        {
            VarType = varType;
            Operator = @operator;
        }
        public CType VarType;
        public COperator Operator;
    }
}
