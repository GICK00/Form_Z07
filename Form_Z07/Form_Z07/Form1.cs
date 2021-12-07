using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Form_Z07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStat_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str = new StringBuilder(Convert.ToString(textBoxStr.Text));
                string substr = Convert.ToString(textBoxSubstr.Text);
                if (str.Length == 0)
                    throw new Exception("Строка должна содержать хотябы 1 символ!");
                if (substr.Length == 0)
                    throw new Exception("Введите строку которую нужно удалить!");

                textBoxStr.Text = str.ToString();
                textBoxStr.Text += $"\r\nДлина строки: {str.Length}";
                textBoxStr.Text += $"\r\nЕмкость строки: {str.Capacity}\r\n";

                removStr(str, substr);
            }
            catch (Exception ex)
            {
                textBoxStr.Text = $"{ex.Message}";
            }
        }
        private void removStr(StringBuilder str, string substr)
        {
            try
            {
                Regex reg = new Regex(substr);
                do
                {
                    int n = str.ToString().IndexOf(substr);
                    str = str.Remove(n, substr.Length);
                } while (reg.IsMatch(str.ToString()) == true);

                textBoxStr.Text += "\r\n" + str.ToString();
                textBoxStr.Text += $"\r\nДлина строки: {str.Length}";
                textBoxStr.Text += $"\r\nЕмкость строки: {str.Capacity}";
            }
            catch (Exception)
            {
                textBoxStr.Text = "Нет подстраки для удаления!";
            }
        }
    }
}
