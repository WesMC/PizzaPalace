using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Models
{
    public class FoodOption
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FoodOptionId { get; set; }

        //[ForeignKey("FoodOptionSet"), Required]
        public Guid FoodOptionSetId { get; set; }

        [Required(ErrorMessage = "Food Option Name is Required."), StringLength(150)]
        public string Name { get; set; }
#nullable enable
        [StringLength(400), Display(Name="Description")]
        public string? Description { get; set; }
#nullable disable

        [DataType(DataType.Currency), Required(ErrorMessage = "Food Option Has NULL Charge, Please Set Food Option Charge")]
        public double Charge { get; set; }
    }
}
