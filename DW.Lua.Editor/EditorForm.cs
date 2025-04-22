using System;
using System.Windows.Forms;

using DW.Lua.Syntax;

namespace DW.Lua.Editor
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
                UpdateSyntaxTreeView(block);
                parserStatusLabel.Text = block.ToString();
            }
            catch (Exception ex)
            {
                parserStatusLabel.Text = ex.Message;
            }
        }

        private void UpdateSyntaxTreeView(Unit unit)
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            InsertSyntaxTreeViewNode(unit, null);
            treeView1.ExpandAll();
            treeView1.EndUpdate();
        }

        private void InsertSyntaxTreeViewNode(Unit unit, TreeNode node)
        {
            var name = unit.GetType().Name;
            var newNode = node?.Nodes.Add(name) ?? treeView1.Nodes.Add(name);
            newNode.Tag = unit;

            foreach (var child in unit.Children)
            {
                InsertSyntaxTreeViewNode(child, newNode);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is Unit u)
            {
                parserStatusLabel.Text = u.ToString();
            }
            else
            {
                parserStatusLabel.Text = "Empty";
            }
        }
    }
}