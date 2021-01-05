namespace DW.Lua.Syntax
{
    public struct LuaValue
    {
        private object _value;
        public LuaType Type { get; private set; }

        public static LuaValue Nil = new LuaValue { _value = "nil", Type = LuaType.Nil };

        public static LuaValue False = new LuaValue { _value = false, Type = LuaType.Boolean };

        public double NumericValue
        {
            get { return (double) _value; }
            set { SetValue(LuaType.Number, value); }
        }

        public bool BooleanValue
        {
            set { SetValue(LuaType.Boolean, value); }
        }

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