using System;
using System.Windows.Forms;
using CacheLibrary;
using ServiceLibrary;

namespace FuncSerialization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cacheProvider = new CacheProvider();

            var result = cacheProvider.GetCache(
                "aaa",
                new DelegateWrapper<int>(
                    new Func<AdditionParameter, int>(new CalculatorService().Add),
                    new AdditionParameter { Number1 = 50, Number2 = 20 }));

            this.textBox1.Text = result.ToString();
        }
    }
}