using System;
using System.IO;
using System.Text;
using Lab1;
using Lab2;
using Lab3;

namespace Lab4
{
    public class LabsConnection
    {
        public void RunLab1(string inputFile, string outputFile)
        {
            try
            {
                Lab1.Main main = new Lab1.Main();
                main.Start(inputFile, outputFile);

                //Console.OutputEncoding = Encoding.UTF8;
                //string[] lines = File.ReadAllLines(inputFile);

                //Lab1.Program.ValidateInput(lines);
                //string result = LAB1.Program.ProcessLines(lines);

                //File.WriteAllText(outputFile, result.Trim());

                //Console.WriteLine("File OUTPUT.TXT successfully created");
                //Console.WriteLine("LAB #1");
                //Console.WriteLine("Input data:");
                //Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                //Console.WriteLine("Output data:");
                //Console.WriteLine(result.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void RunLab2(string inputFile, string outputFile)
        {

        }
        public void RunLab3(string inputFile, string outputFile)
        {

        }
    }
}
