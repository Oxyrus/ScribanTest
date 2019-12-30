using Scriban;
using Shark.PdfConvert;
using System;
using System.Collections.Generic;
using System.IO;

namespace ScribanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var templateFile = File.ReadAllText($"{currentDirectory}/basetemplate.html");
            var pets = new List<Pet>
            {
                new Pet
                {
                    Name = "Kira"
                },
                new Pet
                {
                    Name = "Kaiser"
                },
                new Pet
                {
                    Name = "Keitty"
                }
            };
            var template = Template.Parse(templateFile);
            var result = template.Render(new { Pets = pets }).ToString();
            PdfConvert.Convert(new PdfConversionSettings
            {
                Title = "My Static Content",
                Content = result,
                OutputPath = @"E:\Desktop\temp.pdf"
            });
            Console.WriteLine(result);
        }
    }

    class Pet
    {
        public string Name { get; set; }
    }
}
