using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace CalcTree
{
    internal static class CCompiler
    {
        static CCompiler()
        {

        }
        static string path;
        public static void ToCCode(Node root, string filename)
        {
            StreamWriter sw = new StreamWriter(filename, false, Encoding.Default);
            sw.WriteLine("#define _CRT_SECURE_NO_WARNINGS");
            sw.WriteLine("#include <stdio.h>");
            sw.WriteLine("int main() {");


            sw.WriteLine("    printf(\"hello\");");

            sw.WriteLine("    return 0;");
            sw.WriteLine("}");
            sw.Close();

            cmd($"/k gcc {filename}");
        }
        public static List<string> Parse(Node root)
        {
            foreach (Node child in root.children)
            {

            }
            List<string> list = new List<string>();
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
