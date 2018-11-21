using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace BmpReader2
{
    class Program
    {
        //TODO: refactor further, implement into app

        static void Main(string[] args)
        {
            string inputFilePath = "lol.PNG";
            string outputFile = "output.txt";

            StreamWriter sw = new StreamWriter(outputFile);

            int n = 1;

            Bitmap bmp = (Bitmap)Image.FromFile(inputFilePath);

            string[] convertedBmp = BmpConverter.ConvertBmp(bmp);           

            for (int i = 0; i < convertedBmp.Length; i++)
            {
                string currentLine = convertedBmp[i];
                DrawLine(n, currentLine, sw);
            }

            sw.Close();

            string generatedText = new StreamReader(outputFile).ReadToEnd();
            Console.WriteLine(generatedText.Length);
        }

        public static void DrawLine(int n, string lineCode, StreamWriter sw)
        {
            var square = 2 * n;

            string black = new string('@', square);
            string veryDark = new string('B', square);
            string dark = new string('E', square);
            string neutralDark = new string('c', square);
            string neutralLight = new string(';', square);
            string light = new string('_', square);
            string veryLight = new string('.', square);
            string white = new string(' ', square);

            string lineFormat = string.Empty;

            foreach (char c in lineCode)
            {
                lineFormat += ("{" + c.ToString() + "}");
            }

            for (int i = 0; i < n; i++)
            {
                sw.WriteLine(lineFormat, white, veryLight, light, neutralLight, neutralDark, dark, veryDark, black);
            }
        }        
    }
}
