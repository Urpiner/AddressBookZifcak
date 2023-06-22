using AddressBook;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = string.Empty;
        var name = string.Empty;
        var position = string.Empty;
        var mainWorkplace = string.Empty;
        var output = string.Empty;
        for (int i = 0; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "--input":
                    input = args[i + 1];
                    break;
                case "--name":
                    name = args[i + 1];
                    break;
                case "--position":
                    position = args[i + 1];
                    break;
                case "--main-workplace":
                    mainWorkplace = args[i + 1];
                    break;
                case "--output":
                    output = args[i + 1];
                    break;
            default:
                    break;
            }
        }
        var employees = EmployeeList.LoadFromJson(new FileInfo(input));
        if (employees == null)
            Console.Error.WriteLine("Zadaný vstupný súbor " + input + " neexistuje");
        else
        {
            SearchResult searchResult = employees.Search(mainWorkplace, position, name);
            for (int i = 0; i < searchResult.Employees.Length; i++)
            {
                Console.WriteLine("[" + (i + 1).ToString() + "] " + searchResult.Employees[i].Name);
                if (!string.IsNullOrEmpty(searchResult.Employees[i].Workplace))
                    Console.WriteLine("Pracovisko: " + searchResult.Employees[i].Workplace);
                if (!string.IsNullOrEmpty(searchResult.Employees[i].Room))
                    Console.WriteLine("Miestnosť: " + searchResult.Employees[i].Room);
                if (!string.IsNullOrEmpty(searchResult.Employees[i].Phone))
                    Console.WriteLine("Telefón: " + searchResult.Employees[i].Phone);
                if (!string.IsNullOrEmpty(searchResult.Employees[i].Email))
                    Console.WriteLine("E-mail: " + searchResult.Employees[i].Email);
                Console.WriteLine("Funkcia: " + searchResult.Employees[i].Position);
                Console.WriteLine();
            }
            if (!string.IsNullOrEmpty(output))
            {
                if (File.Exists(output))
                    File.Delete(output);
                searchResult.SaveToCsv(new FileInfo(output), ";");
            }
        }
    }
}