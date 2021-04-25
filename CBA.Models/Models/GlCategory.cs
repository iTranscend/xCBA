﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Models.Models
{
    public enum MainGlCategory
    {
        Asset, Capital, Expenses, Income, Liability
    }
    public class GlCategory
    {
        public int ID { get; set; }

        [Required(ErrorMessage = ("Category name is required")), MaxLength(40)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = ("Please enter a description")), MaxLength(150)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = ("You have to select a main GL Category"))]
        [Display(Name = "Main GL Category")]
        public MainGlCategory MainCategory { get; set; }
    }
}
