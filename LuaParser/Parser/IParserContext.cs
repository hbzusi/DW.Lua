namespace DW.Lua.Parsers
{
    public interface IParserContext
    {
        void AddError(string error);
        IScope CurrentScope { get; }
        IScope AcquireScope();
        void ReleaseScope(IScope scope);
    }
}
