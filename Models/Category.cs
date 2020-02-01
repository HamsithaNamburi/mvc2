using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mvcproject.Models
{
    public class Category
    {
        [Key]
        [Required(ErrorMessage ="Id Field is Mandatory")]
        [MaxLength(10, ErrorMessage = "The length should be five 5")]
        public  string C_id {get;set;}
        [Required(ErrorMessage = "Category Name feild is mandatory")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "the  name should between 3 to 20")]
        public string Cat_name { get; set; }
        public string Breif_details { get; set; }
        public Category()
        {

        }
        public Category(string c_id,string cat_name)
        {
            this.C_id = c_id;
            this.Cat_name = cat_name;
        }
    }
}
