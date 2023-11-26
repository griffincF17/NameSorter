// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

//Creates a list for the names in the file
List<string> names = new List<string>();

//String for the file location
string fileName = "names.txt";

//Checks to see if the file exists in the specified location 
if (File.Exists(fileName))
{
    //StreamReader to read the file's contents
    StreamReader sr;

    try
    {
        using (sr = new StreamReader(fileName))
        {
            //Reads the contents of the file until the end of the stream
            //and adds each name to the names list
            while (!sr.EndOfStream)
            {
                names.Add(sr.ReadLine());
            }

            //Sorts the names by their last name, then by their first name
            //and finally by their middle name
            var sortedNames = names.OrderBy(x => x.Substring(x.LastIndexOf(' ')))
                    .ThenBy(x => x.Substring(0, x.IndexOf(' ')))
                    .ThenBy(x => x.Substring(x.IndexOf(' '), x.LastIndexOf(' ')));

            //Prints the sorted names 
            foreach (var name in sortedNames)
            {
                Console.WriteLine(name);
            }
        }
    }
    catch (IOException io)
    {
        Console.WriteLine(io.Message);
    }

    //Catches all other exceptions
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
else
{
    Console.WriteLine("File does not exist.");
}
