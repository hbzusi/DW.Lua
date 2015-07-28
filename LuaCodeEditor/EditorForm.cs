using System;
using System.Windows.Forms;
using LuaCodeEditor.Properties;
using LuaParser;

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
                var block = SyntaxParser.Parse(script);
                parserStatusLabel.Text = Resources.Text_Status_OK;
            }
            catch (Exception ex)
            {
                parserStatusLabel.Text = ex.Message;
            }
        }
    }
}
