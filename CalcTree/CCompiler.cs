using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;

namespace CalcTree
{
    internal static class CCompiler
    {
        static CCompiler()
        {

        }
        public static void ToCCode(Node root, string filename)
        {
            StreamWriter sw = new StreamWriter(filename, false, Encoding.Default);
            sw.WriteLine("#define _CRT_SECURE_NO_WARNINGS");
            sw.WriteLine("#include <stdio.h>");
            sw.WriteLine("int main() {");

            List<string> lines = Parse(root);
            foreach (string line in lines)
            {
                sw.WriteLine(line);
            }
            OperatorNode node = (OperatorNode)root;
            sw.WriteLine($"printf(\"Result:\\t{GetFromat(node.VarType)}\\n\", {node.NodeName});");
            sw.WriteLine($"scanf(\"{GetFromat(node.VarType)}\", &{node.NodeName});");

            sw.WriteLine("return 0;");
            sw.WriteLine("}");
            sw.Close();

            cmd($"/k gcc {filename}");

        }
        public static List<string> Parse(Node root)
        {
            List<string> list = new List<string>();
            if (root is ConstNode)
            {
                ConstNode node = (ConstNode)root;
                list.Add($"{GetCType(node.VarType)} {node.NodeName} = {node.Value};");
            }
            else if (root is VarNode)
            {
                VarNode node = (VarNode)root;
                list.Add($"{GetCType(node.VarType)} {node.NodeName};");
                list.Add($"printf(\"Enter the value <{node.NodeName}>({node.VarType}):\\n\");");
                list.Add($"scanf(\"{GetFromat(node.VarType)}\", &{node.NodeName});");
            }
            else if (root is OperatorNode)
            {
                OperatorNode node = (OperatorNode)root;
                foreach (Node child in node.children)
                    list.AddRange(Parse(child));
                list.Add($"{GetCType(node.VarType)} {node.NodeName} = {node.children[0].NodeName} {GetOperator(node.Operator)} {node.children[1].NodeName};");
            }
            else
                throw new Exception($"Node type error undefined type:{root.GetType()}");
            return list;
        }
        static string GetFromat(VarType type)
        {
            switch (type)
            {
                case VarType.Integer:
                    return "%d";
                case VarType.Double:
                    return "%f";
                default:
                    throw new Exception("GetFormat doesn't defined for this type");
            }
        }

        static string GetCType(VarType type)
        {
            switch (type)
            {
                case VarType.Integer:
                    return "int";
                case VarType.Double:
                    return "double";
                default:
                    throw new Exception("GetCType doesn't defined for this type");
            }
        }


        static string GetOperator(Operator @operator)
        {
            switch (@operator)
            {
                case Operator.Sum:
                    return "+";
                case Operator.Mult:
                    return "*";
                default:
                    throw new Exception("GetOperator doesn't defined for this operator");
            }
        }
        static void cmd(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd";
            psi.Arguments = command;
            Process.Start(psi);
        }
    }
}
