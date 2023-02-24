using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ActivityProduct
    {
        public Guid ActivityId { get; set; }
        public Guid ProductId { get; set; }

        public Models.Activity Activity { get; set; }
        public Models.Product Product { get; set; }
    }
}
