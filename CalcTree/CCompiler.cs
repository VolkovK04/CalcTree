using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace CalcTree
{
    internal static class CCompiler
    {
        static CCompiler()
        {

        }
        public static async void ToCCode(Node root, string filename)
        {
            StreamWriter sw = new StreamWriter(filename, false, Encoding.Default);
            //sw.WriteLine("#define _CRT_SECURE_NO_WARNINGS");
            sw.WriteLine("#include <stdio.h>");
            sw.WriteLine("int main() {");

            List<string> lines = Parse(root);
            foreach (string line in lines)
            {
                sw.WriteLine(line);
            }
            OperatorNode node = (OperatorNode)root;
            sw.WriteLine($"printf(\"Result:\\t{node.VarType.Format}\\n\", {node.NodeName});");
            sw.WriteLine($"scanf(\"{node.VarType.Format}\", &{node.NodeName});");

            sw.WriteLine("return 0;");
            sw.WriteLine("}");
            sw.Close();

            cmd($"/C gcc {filename}");
            Thread.Sleep(100);
            cmd("/k a.exe");
        }
        public static List<string> Parse(Node root)
        {
            List<string> list = new List<string>();
            if (root is ConstNode)
            {
                ConstNode node = (ConstNode)root;
                list.Add($"{node.VarType.CName} {node.NodeName} = {node.Value};");
            }
            else if (root is VarNode)
            {
                VarNode node = (VarNode)root;
                list.Add($"{node.VarType.CName} {node.NodeName};");
                list.Add($"printf(\"Enter the value <{node.NodeName}>({node.VarType.CName}):\\n\");");
                list.Add($"scanf(\"{node.VarType.Format}\", &{node.NodeName});");
            }
            else if (root is OperatorNode)
            {
                OperatorNode node = (OperatorNode)root;
                foreach (Node child in node.children)
                    list.AddRange(Parse(child));
                list.Add($"{node.VarType.CName} {node.NodeName} = {node.children[0].NodeName} {node.Operator.Symbol} {node.children[1].NodeName};");
            }
            else
                throw new Exception($"Node type error undefined type:{root.GetType()}");
            return list;
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
