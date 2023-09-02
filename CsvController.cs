using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace GenerateCSVfiles
{
    public class CsvController : Controller
    {        
        public IActionResult ExportCsv()
        {
            // Replace this with your data retrieval logic.
            var people = new List<Person>
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 25},
                new Person { Id = 2, FirstName = "Mike", LastName = "Lane", Age = 36},
                new Person { Id = 3, FirstName = "Caroline", LastName = "Michele", Age = 19}
            };

            // Create a memory stream to store the CSV data
            using var stream = new MemoryStream();

            // Create a stream writer to write to the stream
            using var writer = new StreamWriter(stream);

            // Create a CSV writer to write to the stream writer
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            // Write the records to the CSV file
            // Shows only FirstName and LastName
            // With this approach we can decide which data to print out in generated CSV file
            csv.WriteField(nameof(Person.FirstName));
            csv.WriteField(nameof(Person.LastName));
            // csv.WriteField(nameof(Person.Age));
            csv.NextRecord();

            foreach (var person in people)
            {
                csv.WriteField(person.FirstName);
                csv.WriteField(person.LastName);
               // csv.WriteField(person.Age);
                csv.NextRecord();
                // Flush the writer to ensure all data is written
                writer.Flush();
            }

            // Get the byte array of the stream
            var bytes = stream.ToArray();

            // Create a file result to return the CSV file
            var result = new FileContentResult(bytes, "text/csv")
            {
                FileDownloadName = "records.csv"
            };

            // Return the file result
            return result;
        }
        
    }
}
