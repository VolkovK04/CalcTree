using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CalcTree
{
    internal class Program
    {
        static string filename = "C:\\Users\\volkov\\source\\repos\\CalcTree\\CalcTree\\bin\\Debug\\test.c";
        static void Main(string[] args)
        {
            AutoNamer namer = new AutoNamer();
            Node root = new OperatorNode(namer.Next(), VarType.Integer, Operator.Sum);
            Node child1 = new VarNode(namer.Next(), VarType.Integer);
            root.children.Add(child1);
            child1.parents.Add(root);
            Node child2 = new VarNode(namer.Next(), VarType.Integer);
            root.children.Add(child2);
            child2.parents.Add(root);

            CCompiler.ToCCode(root, filename);
        }
    }
}
