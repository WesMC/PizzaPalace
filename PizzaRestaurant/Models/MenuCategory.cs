using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Models
{
    public class MenuCategory
    {
        [Key]
        public int MenuCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

#nullable enable
        [ForeignKey("MenuCategoryId")]
        public ICollection<MenuItem>? MenuItems { get; set; }

#nullable disable

    }
}
