namespace LuaParser.Parsers
{
    public interface IParserContext
    {
        void AddError(string error);
        IScope CurrentScope { get; }
    }
}
