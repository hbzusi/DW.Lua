namespace LuaParser.Syntax
{
    public struct Value
    {
        private object _value;
        public LuaType Type { get; private set; }

        public double NumericValue
        {
            get { return (double) _value; }
            set
            {
                SetValue(LuaType.Number, value);
            }
        }

        public bool BooleanValue { set {SetValue(LuaType.Boolean, value);} }

        private void SetValue(LuaType luaType, object value)
        {
            Type = luaType;
            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}