using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_EF.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Country { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}
