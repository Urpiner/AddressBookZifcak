using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBook
{
    public class EmployeeList : List<Employee>
    {
        public static EmployeeList? LoadFromJson(FileInfo jsonFile)
        {
            using StreamReader r = new(jsonFile.OpenRead());
            string json = r.ReadToEnd();
            return JsonSerializer.Deserialize<EmployeeList>(json);
        }

        public void SaveToJson(FileInfo? jsonFile)
        {
            string json = JsonSerializer.Serialize(this);
            if (jsonFile != null)
                File.WriteAllText(jsonFile.FullName, json);
        }

        public IEnumerable<string> GetPositions() => this.Select(x => x.Position).Distinct().OrderByDescending(x => x);

        public IEnumerable<string> GetMainWorkplaces() => this.Where(x => x.MainWorkplace != null).Select(x => x.MainWorkplace).Distinct().OrderByDescending(x => x);

        public SearchResult Search(string? mainWorkplace = null, string? position = null, string? name = null)
        {
            List<Employee> employees = this;
            if (!string.IsNullOrEmpty(mainWorkplace))
            {
                employees = employees.Where(x => x.MainWorkplace == mainWorkplace).ToList();
            }

            if (!string.IsNullOrEmpty(position))
            {
                employees = employees.Where(x => x.Position == position).ToList();
            }

            if (!string.IsNullOrEmpty(name))
            {
                employees = employees.Where(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            SearchResult searchResult = new(employees.ToArray());
            return searchResult;
        }
    }
}
