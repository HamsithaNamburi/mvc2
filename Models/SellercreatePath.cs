using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvcproject.Models
{
    public class SellercreatePath
    {
        [Key]
        [Required(ErrorMessage = "Id feild is mandatory")]
        [MaxLength(5, ErrorMessage = "The length should be five 5")]
        public string s_id { get; set; }
        [Required(ErrorMessage = "Name feild is mandatory")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "the  name should between 5 to 20")]
        public string Uname { get; set; }
        [Required(ErrorMessage = "Password feild is mandatory")]
        [DataType(DataType.Password)]
        [RegularExpression(@"[a-z0-9]{6,8}", ErrorMessage = "Password invalid")]
        public string Pwd { get; set; }
        public string C_name { get; set; }
        [Required(ErrorMessage = "Email feild is mandatory")]
        [EmailAddress(ErrorMessage = "InvalidEmail address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "contact number feild is mandatory")]
        [Phone(ErrorMessage = "invalid phn number")]
        public string C_No { get; set; }
        public int GSTIN { get; set; }
        public IFormFile Photopath { get; set; }
    }
}
