using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_EF.Models
{
    public class CarOption
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<Car> Cars { get; set; } = [];
    }
}
