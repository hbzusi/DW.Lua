using System;
using System.IO;
using System.Windows.Forms;
using LuaCodeEditor.Properties;
using LuaParser;
using LuaParser.Parser;

namespace LuaCodeEditor
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            var script = codeBox.Text;
            try
            {
                var reader = new StringReader(script);
                var tokenEnumerator = Tokenizer.Parse(reader);
                //var block = SyntaxParser.Parse(script);
                parserStatusLabel.Text = "Tokens: " + string.Join(", ",tokenEnumerator);
            }
            catch (Exception ex)
            {
                parserStatusLabel.Text = ex.Message;
            }
        }
    }
}
