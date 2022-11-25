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
        static void Main(string[] args)
        {
            Node root = new OperatorNode(Operator.Sum);
            Node child1 = new VarNode<int>("x");
            root.children.Add(child1);
            child1.parents.Add(root);
            Node child2 = new VarNode<int>("y");
            root.children.Add(child2);
            child2.parents.Add(root);

            Console.WriteLine(root.GetType());
            string filename = "C:\\Users\\volkov\\source\\repos\\CalcTree\\CalcTree\\bin\\Debug\\test.c";
            CCompiler.ToCCode(root, filename);
            
            Console.ReadLine();
        }
    }
}
