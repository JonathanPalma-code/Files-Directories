using System;
using ManagingFileContent.Entities;
using System.IO;

namespace ManagingFileContent
{
    class Print
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full path:");
            string fullpath = Console.ReadLine();

            try
            {
                var lines = File.ReadAllLines(fullpath);
                string sourceFolderPath = Path.GetDirectoryName(fullpath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.txt";

                Directory.CreateDirectory(targetFolderPath);

                using StreamWriter sw = File.AppendText(targetFilePath);
                foreach (string line in lines)
                {
                    var fields = line.Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1]);
                    int quantity = int.Parse(fields[2]);

                    Product product = new Product(name, price, quantity);

                    sw.WriteLine($"{product.Name}, {product.TotalPrice()}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
