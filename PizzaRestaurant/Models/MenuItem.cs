using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Models
{
    public class MenuItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MenuItemId { get; set; }

        //[ForeignKey("MenuCategory")]
        public int MenuCategoryId { get; set; }

        [Required(ErrorMessage ="Menu Item Name is Required"), StringLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Menu Item Description is Required"), StringLength(450), Display(Name="Description")]
        public string Desc { get; set; }

#nullable enable
        [ForeignKey("MenuItemId")]
        public ICollection<FoodOptionSet>? FoodOptionSets { get; set; }


        [StringLength(150), Display(Name = "Preference")]
        public string? Pref { get; set; }
#nullable disable

        [Required(ErrorMessage = "MenuItem Has NULL Charge, Please Set Food Option Charge"), DataType(DataType.Currency)]
        public double Charge { get; set; }

        #region Health Info
        public int Calories { get; set; }
        [Display(Name = "Calories from Fat")]
        public int CaloriesFat { get; set; }
        [Display(Name = "Total Fat")]
        public int TFat { get; set; }
        [Display(Name = "Saturated Fat")]
        public int SatFat { get; set; }
        [Display(Name = "Trans Fat")]
        public int TransFat { get; set; }
        [Display(Name = "Cholesterol")]
        public int Choles { get; set; }
        public int Sodium { get; set; }
        [Display(Name = "Total Carbohydrates")]
        public int TCarbs { get; set; }
        [Display(Name = "Dietary Fiber")]
        public int Fiber { get; set; }
        [Display(Name = "Sugars")]
        public int Sugar { get; set; }
        public int Protein { get; set; }

        [StringLength(1000)]
        public string Ingredients { get; set; }
        #endregion

        #region Allergies
        [Required, Display(Name = "Gluten")]
        public bool Al_Gluten { get; set; }
        [Required, Display(Name = "Milk")]
        public bool Al_Milk { get; set; }
        [Required, Display(Name = "Wheat")]
        public bool Al_Wheat { get; set; }
        [Required, Display(Name = "Eggs")]
        public bool Al_Eggs { get; set; }
        [Required, Display(Name = "Fish")]
        public bool Al_Fish { get; set; }
        [Required, Display(Name = "Shellfish")]
        public bool Al_Shellfish { get; set; }
        [Required, Display(Name = "Tree Nuts")]
        public bool Al_TreeNuts { get; set; }
        [Required, Display(Name = "Peanuts")]
        public bool Al_Peanuts { get; set; }
        [Required, Display(Name = "Soy")]
        public bool Al_Soy { get; set; }
        #endregion

    }
}
