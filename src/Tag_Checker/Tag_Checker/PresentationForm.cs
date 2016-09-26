using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tag_Checker
{
    public partial class PresentationForm : Form
    {
        public PresentationForm()
        {
            InitializeComponent();
        }
        TagsChecker _tagChecker;
        TagsChecker TagChecker
        {
            get
            {
                if (_tagChecker == null)
                {
                    IApplicationContext ctx = ContextRegistry.GetContext();
                    _tagChecker = (TagsChecker)ctx.GetObject("TagsChecker");
                }
                return _tagChecker;
            }
            set { _tagChecker = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var strInput = richTextBox1.Text.Split('\n');
            foreach (var inputparagraph in strInput)
            {
                var checkResult = TagChecker.Check(inputparagraph);
                if (!string.IsNullOrEmpty(checkResult))
                {
                    richTextBox2.Text += checkResult + '\n';
                }
            }
        }
    }
}
