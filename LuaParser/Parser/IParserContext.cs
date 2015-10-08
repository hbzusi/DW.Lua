namespace DW.Lua.Parser
{
    public interface IParserContext
    {
        void AddError(string error);
        IScope CurrentScope { get; }
        IScope AcquireScope();
        void ReleaseScope(IScope scope);
    }
}
