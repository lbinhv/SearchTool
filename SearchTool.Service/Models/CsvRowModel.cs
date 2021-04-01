using System.Collections.Generic;

namespace SearchTool.Service.Models
{
    public class CsvRowModel : List<string>
    {
        public string LineText { get; set; }
    }
}
