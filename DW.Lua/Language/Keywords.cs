using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DW.Lua.Language
{
    public static class Keywords
    {
        private static readonly List<string> AllKeywords;

        static Keywords()
        {
            var fieldInfos = typeof (Keywords).GetFields(BindingFlags.Public |
                                                         BindingFlags.Static | BindingFlags.FlattenHierarchy);
            AllKeywords =
                fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                    .Select(f => f.GetRawConstantValue())
                    .OfType<string>()
                    .ToList();
        }

        public static IList<string> All => AllKeywords.AsReadOnly();
        // ReSharper disable UnusedMember.Global
        public const string If = "if";
        public const string Then = "then";
        public const string End = "end";
        public const string Else = "else";
        public const string ElseIf = "elseif";
        public const string While = "while";
        public const string Do = "do";
        public const string Function = "function";
        public const string For = "for";
        public const string Return = "return";
        public const string Local = "local";
        public const string And = "and";
        public const string Or = "or";
        public const string Nil = "nil";
        public const string Not = "not";
        // ReSharper restore UnusedMember.Global
    }
}