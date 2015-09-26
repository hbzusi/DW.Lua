using System.IO;
using System.Text;

namespace LuaParser.Extensions
{
    public static class StringReaderExtensions
    {
        public static string ReadWord(this TextReader reader)
        {
            var sb = new StringBuilder();
            do
            {
                var next = reader.Peek();
                if (next == -1)
                    break;
                var nextChar = (char) next;
                if (char.IsWhiteSpace(nextChar))
                    break;
                sb.Append(nextChar);
                reader.Read();
            } while (true);
            return sb.ToString();
        }

        public static void SkipWhitespace(this TextReader reader)
        {
            while (true)
            {
                var next = reader.Peek();
                if (next == -1) return;
                var nextChar = (char) next;
                if (!char.IsWhiteSpace(nextChar) && next != '\r' && next != '\n')
                    break;
                reader.Read();
            }
        }
    }
}
