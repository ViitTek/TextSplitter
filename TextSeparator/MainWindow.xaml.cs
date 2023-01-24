using System;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;


namespace TextSeparator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoadText(object sender, RoutedEventArgs e)
        {
            string myPath = ConnectionString.Text;
            string text = File.ReadAllText(myPath);
            string newFilePath = Path.Combine(Path.GetDirectoryName(myPath), "Formatted_Text.txt");

            File.Delete(newFilePath);

            string[] words = text.Split(' ');
            int wordCount = 0;
            string newText = "";

            for (int i = 0; i < words.Length; i++)
            {
                if (wordCount == 180)
                {
                    while (!words[i].EndsWith(".") && !words[i].EndsWith("!") && !words[i].EndsWith("?"))
                    {
                        newText += words[i] + " ";
                        i++;
                    }
                    newText += words[i] + "\n\n\n";
                    wordCount = 0;
                }
                else
                {
                    newText += words[i] + " ";
                    wordCount++;
                }
            }

            File.WriteAllText(newFilePath, newText);



            Viewer1.Text = File.ReadAllText(myPath);
            Viewer2.Text = File.ReadAllText(newFilePath);
        }
    }
}


