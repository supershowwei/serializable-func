using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace FuncDeserialization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(@"D:\aaa.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var delegateFunc = formatter.Deserialize(fs);

                this.textBox1.Text = delegateFunc.GetType().GetMethod("Invoke").Invoke(delegateFunc, null).ToString();
            }
        }
    }
}