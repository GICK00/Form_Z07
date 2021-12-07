using System;
using System.Text;
using System.Windows.Forms;

namespace Form_Z07_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonResult_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str = new StringBuilder(textBoxStr.Text);
                if (str.Length == 0)
                    throw new Exception("Строка должна содержать хотябы 1 символ!");

                textBoxResult.Text = "Строка состоит из " + numberUpp(str.ToString()) +  " слов которые состоят только изпрописных букв.";
            }
            catch (Exception ex)
            {
                textBoxResult.Text = $"{ex.Message}";
            }
        }
        static int numberUpp(string str)
        {
            int lowercase = 0;
            int uppercase = 0;
            int i = 0;
            int n = 0;
            while (i < str.Length)
            {
                uppercase = 0;
                lowercase = 0;
                while (i < str.Length && char.IsLetter(str[i]))
                {
                    if (char.IsUpper(str[i])) uppercase++;
                    if (char.IsLower(str[i])) lowercase++;
                    i++;
                }
                if (uppercase > 0 && lowercase == 0)
                    n++;
                while (i < str.Length && !char.IsLetter(str[i]))
                    i++;
            }
            return n;
        }
    }
}
