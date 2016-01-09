namespace DW.Lua.Parser
{
    public interface IParserContext
    {
        IScope CurrentScope { get; }
        void AddError(string error);
        IScope AcquireScope();
        void ReleaseScope(IScope scope);
    }
}