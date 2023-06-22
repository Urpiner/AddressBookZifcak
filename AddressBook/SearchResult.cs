namespace AddressBook
{
    public class SearchResult
    {
        public Employee[] Employees { get; }

        public SearchResult(Employee[] employees)
        {
            Employees = employees;
        }

        public void SaveToCsv(FileInfo fileInfo, string delimiter = "\t")
        {
            if (File.Exists(fileInfo.FullName))
                File.Delete(fileInfo.FullName);
            StreamWriter writer = new(fileInfo.OpenWrite());
            writer.WriteLine("Name" + delimiter + "MainWorkplace" + delimiter + "Workplace" + delimiter + "Room" + delimiter + "Phone" + delimiter + "Email" + delimiter + "Position");
            for (int i = 0; i < Employees.Length; i++)
            {
                writer.WriteLine(Employees[i].Name + delimiter + Employees[i].MainWorkplace + delimiter + Employees[i].Workplace + delimiter + Employees[i].Room + delimiter + Employees[i].Phone + delimiter + Employees[i].Email + delimiter + Employees[i].Position);
            }
            writer.Close();
        }
    }
}