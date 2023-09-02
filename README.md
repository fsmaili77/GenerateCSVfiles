# Generating CSV files in Asp.net core

CSV files are comma-separated values files that store tabular data in plain text format. They are widely used for data exchange and analysis. To generate CSV files in Asp.net core, you need to use a library that can handle the CSV format, such as CSVHelper

## Here's a step-by-step guide on how to generate CSV files in ASP.NET Core:

### Create a new ASP.NET Core project or use an existing one.

### Create a model class that represents the data you want to export to the CSV file. For example:
![image](https://github.com/fsmaili77/GenerateCSVfiles/assets/65200251/b857e675-7027-4a24-8ef2-2bf75121c355)
### In your controller, add an action method that generates the CSV file. Here's an example:
![image](https://github.com/fsmaili77/GenerateCSVfiles/assets/65200251/f0abee0e-843a-4edd-8675-7998a9a404e8)

In this example, the ExportCsv action method retrieves a list of Person objects and then uses CsvHelper to write these objects to a memory stream. Finally, it returns the CSV file as a FileStreamResult with appropriate response headers.

### Configure your route to map to the ExportCsv action. You can do this in the Startup.cs or Program.cs file by adding a route to your CsvController:
![image](https://github.com/fsmaili77/GenerateCSVfiles/assets/65200251/4e6168e1-8bc4-4ce8-a316-9ba80e008290)
Now, when you access the URL /csv/export, it will trigger the ExportCsv action, which generates and downloads the CSV file.

## Generate selected data 
In the show-data branch, as shown in the image below, after modification of the **CsvController.cs** class, we can decide which data to print out in generated CSV file.
![image](https://github.com/fsmaili77/GenerateCSVfiles/assets/65200251/8e099f46-e410-4930-a4a3-311dfa41a7f8)
