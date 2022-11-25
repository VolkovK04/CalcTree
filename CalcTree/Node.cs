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
        public List<Node> children = new List<Node>();
        public List<Node> parents = new List<Node>();
        public string NodeName;
    }
    internal class ConstNode<T> : Node
    {
        public ConstNode(T value)
        {
            C = value;
        }
        T C;
    }

    internal class VarNode<T> : Node
    {
        public VarNode(string name)
        {
            Name = name;
        }
        public System.Type type = typeof(T);
        public string Name;
    }
    internal class OperatorNode : Node
    {
        public OperatorNode(Operator @operator)
        {
            Operator = @operator;
        }
        public Operator Operator;
    }
}
