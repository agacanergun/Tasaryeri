using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.DAL.Entities
{
    public class ProductCategory
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int CategoryID { get; set; }
        public SubCategory Category { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }
    }
}
