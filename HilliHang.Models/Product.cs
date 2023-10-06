using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string ProductName { get; set; }
		[Display(Name = "Product Description")]
		public string ProductDescription { get; set; }
		[Required]
		public string Company { get; set; }
		[Required]
        public string Size { get; set; }
		[Required]
		[Display(Name ="MRP")]
		[Range(1,10000)]
        public double Mrp { get; set; }


		[Display(Name = "Whole Sale Price")]
		[Range(1, 10000)]
		public double WholeSale { get; set; }


		[Display(Name = "Retail Price")]
		[Range(1, 10000)]
		public double RetailPrice { get; set; }
		
        public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		[ValidateNever]
        public Category Category { get; set; }
		[ValidateNever]
        public string ImageUrl { get; set; }


    }
}
