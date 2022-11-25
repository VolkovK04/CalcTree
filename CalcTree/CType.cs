namespace CalcTree
{
    internal class CType
    {
        public CType(string name, string format, string type)
        {
            Name = name;
            Format = format;
            CName = type;
        }
        public static implicit operator CType(string name)
        {
            return GlobalTypes.VarTypes.Find(type => type.Name == name);
        }
        public CType(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public string Format;
        public string CName;
    }
}
