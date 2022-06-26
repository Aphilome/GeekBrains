using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Catalog.Models
{
    public class Product
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public string? Name { get; set; }
    }
}
