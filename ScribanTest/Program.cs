using Scriban;
using Shark.PdfConvert;
using System;
using System.Collections.Generic;

namespace ScribanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var pets = new List<Pet>
            {
                new Pet
                {
                    Name = "Kira"
                },
                new Pet
                {
                    Name = "Kaiser"
                }
            };
            var template = Template.Parse(@"
                <ul>
                    {{ for pet in pets }}
                        <li>{{ pet.name }}</li>
                    {{ end }}
                </ul>
            ");
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
