using System.Collections.Generic;

namespace CalcTree
{
    enum Operator
    {
        Sum,
        Mult
    }

    internal class Node
    {
        static AutoNamer newName = new AutoNamer();

        public Node(string name)
        {
            NodeName = name;
        }
        public Node()
        {
            NodeName = newName.Next();
        }
        public List<Node> children = new List<Node>();
        public List<Node> parents = new List<Node>();
        public string NodeName;
    }
    internal class ConstNode : Node
    {
        public ConstNode(string name, VarType varType, string value) : base(name)
        {
            VarType = varType;
            Value = value;
        }
        public ConstNode(VarType varType, string value) : base()
        {
            VarType = varType;
            Value = value;
        }
        public string Value;
        public VarType VarType;
    }

    internal class VarNode : Node
    {
        public VarNode(string name, VarType varType) : base(name)
        {
            VarType = varType;
        }
        public VarNode(VarType varType) : base()
        {
            VarType = varType;
        }
        public VarType VarType;
    }
    internal class OperatorNode : Node
    {
        public OperatorNode(string name, VarType varType, Operator @operator) : base(name)
        {
            VarType = varType;
            Operator = @operator;
        }
        public OperatorNode(VarType varType, Operator @operator) : base()
        {
            VarType = varType;
            Operator = @operator;
        }
        public VarType VarType;
        public Operator Operator;
    }
}
