using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Category
{
    public class CategoryModel
    {
        public ulong Id { get; set; }
        public string CategoryName { get; set; }
        public int TypeProductId { get; set; }
        public string TypeProductName { get; set; }

        public List<CategoryListModel> CategoryChill { get; set; }
    }
}
