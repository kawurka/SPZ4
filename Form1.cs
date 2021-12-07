using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace SPZ4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int n = 10; //Количество цифр
        static string FilePath; //Путь файла записи
        static string OutFilePath; // Путь выходного файла

        private void StartButton_Click(object sender, EventArgs e) //Запись в файл
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = Directory.GetCurrentDirectory();
            openfile.Filter = "txt files (*.txt)|*.txt";

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                FilePath = openfile.FileName;
                using (StreamWriter wr = new StreamWriter(FilePath))
                {
                    Random rn = new Random(1) ;
                    for (int i = 0; i < n; i++)
                    {
                        wr.Write(rn.Next(1, 5));
                        wr.Write(',');
                        if( i == n - 1)
                        {
                            wr.Write(rn.Next(1, 5));
                        }
                    }
                }
                string text = File.ReadAllText(FilePath);
                MessageBox.Show(text, "Result");
            }
        }

        private void OutButton_Click(object sender, EventArgs e) // Запись исходного файла
        {
            if (FilePath != null)
            {
                OutFilePath = FilePath.Replace(Path.GetExtension(FilePath), ".out");
                string text = File.ReadAllText(FilePath);
                string[] arr = text.Split(',');
                int count = 1;
                using (StreamWriter wr = new StreamWriter(OutFilePath))
                {
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        if (arr[i] == arr[i + 1])
                        {
                            count++;
                        }
                        else
                        {
                            wr.Write(count);
                            wr.Write(',');
                            count = 1;
                        }
                        if ( i == arr.Length - 2)
                        {
                            wr.Write(count);
                        }
                    }
                }
            }

            if (OutFilePath != null)
            {
                string text = File.ReadAllText(OutFilePath);
                MessageBox.Show(text, "Result");
            }
        }
    }
}
